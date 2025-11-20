using log4net;
using log4net.Config;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using WOW.WoodmenReconClient.Code;
using WOW.WoodmenReconClient.Exceptions;
using WOW.WoodmenReconClient.Properties;
using WOW.WoodmenReconClient.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Collections.Generic;

namespace WOW.WoodmenReconClient
{
    partial class ReconClientService : ServiceBase
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ReconClientService));

        private Task _reportTransmitterTask;
        private Task _reportGeneratorTask;
        private Task _pruneOldReportsTask;

        private DateTime _previousPruneCheck;
        private CancellationTokenSource _tokenSource = new CancellationTokenSource();

        private List<ReportFactory> _factories = new List<ReportFactory>();

        public ReconClientService()
        {
            InitializeComponent();

            CanPauseAndContinue = false;
            CanShutdown = true;
            CanStop = true;
            CanHandlePowerEvent = false;
            CanHandleSessionChangeEvent = false;

            if(Settings.Default.DesktopReportEnabled)
                _factories.Add(new LpaDesktopReportFactory());

            if(Settings.Default.ServerReportEnabled)
                _factories.Add(new LpaServerReportFactory());

            if(Settings.Default.MiddlwareReportEnabled)
                _factories.Add(new LpaMiddlewareReportFactory());
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                // Configure log4net to use the service's app path instead of the system32 folder.
                Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
                XmlConfigurator.Configure();

                // Wire-up unhandled exception event
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledServiceException);

                if (log.IsDebugEnabled) log.Debug("Initiating Woodmen Recon Client Service...");

                if (Environment.UserInteractive)
                {
                    var service = new ReconClientService();
                    service.OnStart(args);

                    Console.WriteLine("Woodmen Recon Client is running. Press enter to stop.");
                    Console.Read();

                    service.OnStop();
                }
                else
                {
                    var ServicesToRun = new ServiceBase[] { new ReconClientService() };
                    ServiceBase.Run(ServicesToRun);
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("The Woodmen Recon Client Service has crashed.", ex);
            }
        }

        protected override void OnStart(string[] args)
        {
            if (Settings.Default.ReportDeletionInterval < TimeSpan.Zero)
            {
                if (log.IsErrorEnabled) { log.Error("The Report Deletion Interval needs to be positive."); }
                throw new ArgumentException("The Report Deletion Interval needs to be positive.", "ReportDeletionInterval");
            }

            if (Settings.Default.ReportGenerationInterval < TimeSpan.Zero)
            {
                if (log.IsErrorEnabled) { log.Error("The Report Generation Interval needs to be positive."); }
                throw new ArgumentException("The Report Generation Interval needs to be positive.", "ReportGenerationInterval");
            }

            if (Settings.Default.ReportTransmissionRetryInterval < TimeSpan.Zero)
            {
                if (log.IsErrorEnabled) { log.Error("The Report Transmission Retry Interval needs to be positive."); }
                throw new ArgumentException("The Report Transmission Retry Interval needs to be positive.", "ReportTransmissionRetryInterval");
            }

            // Initialize prune datetime to distance past so files get checked on start.
            _previousPruneCheck = DateTime.MinValue;

            if (log.IsDebugEnabled)
            {
                log.DebugFormat("Report Deletion Interval: {0}", Settings.Default.ReportDeletionInterval.ToString());
                log.DebugFormat("Report Generation Interval: {0}", Settings.Default.ReportGenerationInterval.ToString());
                log.DebugFormat("Transmission Retry Interval: {0}", Settings.Default.ReportTransmissionRetryInterval.ToString());
            }

            // Create folder for report storage
            SetupReportFolder();

            // File pruner task, report generator task and report transmitter task
            _pruneOldReportsTask = Task.Run(() => PruneReports())
                .ContinueWith((previous) => Stop(), TaskContinuationOptions.OnlyOnFaulted);

            _reportTransmitterTask = Task.Run(() => TransmitReports())
                .ContinueWith((previous) => Stop(), TaskContinuationOptions.OnlyOnFaulted);

            _reportGeneratorTask = Task.Run(() => GenerateReports())
                .ContinueWith((previous) => Stop(), TaskContinuationOptions.OnlyOnFaulted);
        }

        protected override void OnStop()
        {
            log.Info("Woodmen Recon Client Service is shutting down.");

            // Signal tasks to start shutting down.
            _tokenSource.Cancel();

            try
            {
                Task.WaitAll(_pruneOldReportsTask, _reportGeneratorTask, _reportTransmitterTask);
            }
            catch (AggregateException ex)
            {
                foreach (var i in ex.InnerExceptions)
                {
                    if(i is TaskCanceledException)
                    {
                        // This can be ignored.
                    }
                    else
                    {
                        if (log.IsErrorEnabled) { log.Error("Service task exception caught during shutdown.", i); }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // This can be ignored.
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error("Exception while waiting for tasks to shutdown.", ex); }
            }

            if (log.IsInfoEnabled) { log.Info("Woodmen Recon Client Service shutdown complete."); }
        }

        private void SetupReportFolder()
        {
            try
            {
                var dir = Directory.CreateDirectory(Settings.Default.ReportFolderPath);

                if (log.IsDebugEnabled) { log.DebugFormat("Report folder: {0}", dir.FullName); }
            }
            catch(Exception ex)
            {
                if(log.IsErrorEnabled) { log.Error(String.Format("Error setting up report directory. Directory: {0}", Settings.Default.ReportFolderPath), ex); }
                throw; // Throw up to cause service shutdown. We need these folder.
            }
        }

        private async Task TransmitReports()
        {
            var reportDir = new DirectoryInfo(Settings.Default.ReportFolderPath);

            while (!_tokenSource.IsCancellationRequested)
            {
                try
                {
                    bool useFullDelay;

                    // For each .pending file in folder, transmit, oldest to newest
                    // Use similar logic used for pruning to avoid trying to transmit old reports.
                    var newReports = reportDir.GetFiles("*.pending").Where(f => f.CreationTime > DateTime.Now.Subtract(Settings.Default.ReportDeletionInterval)).OrderBy(f => f.CreationTime).ToList();

                    if(newReports.Any())
                    {
                        if(NetworkingHelper.HasConnection(Settings.Default.ReportWebServiceUri))
                        {
                            if (log.IsDebugEnabled) { log.DebugFormat("Internet connectivity check passed: {0}", Settings.Default.ReportWebServiceUri); }

                            foreach (var report in newReports)
                            {
                                try
                                {
                                    SendReport(report);
                                }
                                catch(Exception ex)
                                {
                                    var problemFileFullName = String.Empty;

                                    if (report != null)
                                    {
                                        problemFileFullName = report.FullName;
                                    }

                                    if (log.IsErrorEnabled) { log.Error(String.Format("An error occurred while trying to transmit one of the pending reports. Problem File: {0}", problemFileFullName), ex); }
                                }
                                
                            }

                            // Full delay since reports were (hopefully) transmitted successfully
                            // If one or more files throws an exception for some reason, I don't want a tight loop on that.
                            useFullDelay = true;
                        }
                        else
                        {
                            // Internet not available right now. Shorten the delay to try an catch an active internet connection
                            if (log.IsDebugEnabled) { log.DebugFormat("Internet connectivity check failed: {0}", Settings.Default.ReportWebServiceUri); }
                            useFullDelay = false;
                        }
                    }
                    else
                    {
                        // No new reports right now.
                        // Reports are generated based on the reporting interval. No need to check more than that.
                        if (log.IsDebugEnabled) { log.Debug("No reports found for transmission."); }
                        useFullDelay = true;
                    }


                    // Delay based on whether report server was available or not
                    if(useFullDelay)
                    {
                        if (log.IsDebugEnabled) { log.DebugFormat("Using long delay interval: {0}", Settings.Default.ReportGenerationInterval); }
                        await Task.Delay(Settings.Default.ReportGenerationInterval, _tokenSource.Token);
                    }
                    else
                    {
                        if (log.IsDebugEnabled) { log.DebugFormat("Using short delay interval: {0}", Settings.Default.ReportTransmissionRetryInterval); }
                        await Task.Delay(Settings.Default.ReportTransmissionRetryInterval, _tokenSource.Token);
                    }
                }
                catch (TaskCanceledException)
                {
                    // Task has been canceled while sitting in delay
                    return;
                }
                catch (Exception ex)
                {
                    if(log.IsErrorEnabled) { log.Error("Error while transmitting new reports to the server.", ex); }
                }
            }
        }

        private async Task<bool> TransmitReport(string reportJson)
        {
            if (String.IsNullOrWhiteSpace(reportJson))
            {
                throw new ArgumentNullException("reportJson", "The JSON string cannot be null or empty.");
            }

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Settings.Default.ReportWebServiceUri);
                client.DefaultRequestHeaders
                      .Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, Settings.Default.ReportWebServiceEndpoint);

                request.Content = new StringContent(reportJson, Encoding.UTF8, "application/json");

                var response = await client.SendAsync(request);

                if (log.IsDebugEnabled) { log.DebugFormat("Response: {0}", response); }

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error(String.Format("Could not transmit report '{0}'. Internet connection may not be available.", reportJson), ex); }
                // Don't throw. Exceptions here will likely be communication errors and could be temporary.
                return false;
            }
        }

        private void SendReport(FileInfo report)
        {
            if(report == null)
            {
                throw new ArgumentNullException("report", "The report FileInfo object cannot be null.");
            }

            try
            {
                if (log.IsDebugEnabled) { log.DebugFormat("Transmitting report '{0}'...", report.FullName); }

                var reportJson = File.ReadAllText(report.FullName);

                TransmitReport(reportJson).ContinueWith((transmitTask) =>
                {
                    if (transmitTask.Result)
                    {
                        var sentFileName = Path.ChangeExtension(report.FullName, ".sent");

                        File.Move(report.FullName, sentFileName);

                        if (log.IsDebugEnabled) { log.DebugFormat("Report sent and renamed to '{0}'.", sentFileName); }
                    }
                    else
                    {
                        var pendingFileName = Path.ChangeExtension(report.FullName, ".pending");

                        File.Move(report.FullName, pendingFileName);

                        if (log.IsDebugEnabled) { log.DebugFormat("Unable to transmit at this time. Renamed report to '{0}'.", pendingFileName); }
                    }
                });
            }
            catch(Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error(String.Format("Error transmitting report '{0}'.", report.FullName), ex); }
                throw;
            }
        }

        private void SendReport(string reportFilePath)
        {
            if(String.IsNullOrWhiteSpace(reportFilePath))
            {
                throw new ArgumentException("reportFilePath", "The report file path string cannot be null or empty.");
            }

            try
            {
                var file = new FileInfo(reportFilePath);

                SendReport(file);
            }
            catch(Exception ex)
            {
                if(log.IsErrorEnabled) { log.Error(String.Format("An error occurred trying to transmit report file '{0}'.", reportFilePath), ex); }
                throw;
            }            
        }

        private async Task GenerateReports()
        {
            try
            {
                // I'm going to use the create date of the report files
                var reportDir = new DirectoryInfo(Settings.Default.ReportFolderPath);

                while (!_tokenSource.IsCancellationRequested)
                {
                    // Get file info for most recent report file (sent or new)
                    var latestFile = reportDir.GetFiles().OrderByDescending(f => f.CreationTime).FirstOrDefault();

                    if (latestFile == null || latestFile.CreationTime < DateTime.Now.Subtract(Settings.Default.ReportGenerationInterval))
                    {
                        foreach(var factory in _factories)
                        {
                            factory.CreateReconReport();
                            // Attempt to transmit immediately.
                            // If this fails, the file will sit on the file system and transmit at some future time.
                            SendReport(SaveReport(factory.Report));
                        }
                    }

                    // Wait for the next interval. Using delay with a cancel token means
                    // we don't need a tight loop to stop the service.
                    await Task.Delay(Settings.Default.ReportGenerationInterval, _tokenSource.Token);
                }
            }
            catch (TaskCanceledException)
            {
                // Task has been canceled while sitting in delay
                return;
            }
            catch (Exception ex)
            {
                // An exception caught here would likely be related to service settings and is probably fatal.
                // Log the ex and start the service shutdown.
                if (log.IsFatalEnabled) { log.Fatal("Error occurred while preparing to generate reports. Possible service configuration error.", ex); };
                throw;
            }
        }

        private string SaveReport(ReconReport reportModel)
        {
            if(reportModel == null)
            {
                throw new ArgumentNullException("reportModel");
            }

            try
            {
                var serializeModel = JsonConvert.SerializeObject(reportModel, Formatting.Indented);

                var tmpFilename = reportModel.ReportId.ToString("N") + ".tmp";
                var reportFilename = reportModel.ReportId.ToString("N") + ".new";

                var tmpFilePath = Path.Combine(Settings.Default.ReportFolderPath, tmpFilename);
                var reportFilePath = Path.Combine(Settings.Default.ReportFolderPath, reportFilename);

                using (var sw = new StreamWriter(tmpFilePath, false))
                {
                    sw.Write(serializeModel);
                }

                File.Move(tmpFilePath, reportFilePath);

                if (log.IsDebugEnabled) { log.DebugFormat("Saved new report to file '{0}'.", reportFilePath); }

                return reportFilePath;
            }
            catch(Exception ex)
            {
                if(log.IsErrorEnabled) { log.Error("Error occurred while writing the report model to the file system.", ex); }
                throw;
            }
        }

        private async Task PruneReports()
        {
            try
            {
                while (!_tokenSource.IsCancellationRequested)
                {
                    // Perform some clean up.
                    PruneFiles(Settings.Default.ReportFolderPath);

                    await Task.Delay(Settings.Default.ReportGenerationInterval, _tokenSource.Token);
                }
            }
            catch(TaskCanceledException)
            {
                // Task has been canceled while sitting in delay
                return;
            }
            catch (Exception ex)
            {
                // An exception caught here is most likely fatal. Log the ex and start the service shutdown.
                if (log.IsFatalEnabled) { log.Fatal("Error occurred while trying to delete old reports.", ex); };
                throw;
            }
        }

        private void PruneFiles(string filePath)
        {
            try
            {
                var theThinRedLine = DateTime.Now.Subtract(Settings.Default.ReportDeletionInterval);
                
                // It should be quicker to check if enough time has even gone by to find old files without actually
                // creating a collection of files. Let's do that first.
                if (_previousPruneCheck < theThinRedLine)
                {
                    var reportFolder = new DirectoryInfo(filePath);
                    var oldFiles = reportFolder.GetFiles().Where(f => f.CreationTime < theThinRedLine).ToList();

                    // If we find some old files, let's update the _lastPurge value
                    // This should have the effect of deleting 1 or more files and then waiting X hours and deleting another batch.
                    if (oldFiles.Any())
                    {
                        _previousPruneCheck = DateTime.Now;
                    }

                    foreach (var file in oldFiles)
                    {
                        // In case there are a lot of files and the service is stopped, check the token before each file.
                        if (_tokenSource.IsCancellationRequested) return;

                        try
                        {
                            file.Delete();
                            if (log.IsDebugEnabled) { log.Debug(String.Format("Deleted file '{0}' from report folder.", file.FullName)); }
                        }
                        catch (IOException ex)
                        {
                            // IO exception might be a temporary condition.
                            // Log it and continue processing.
                            if (log.IsWarnEnabled) { log.Warn(String.Format("Error deleting file '{0}' from report folder. Moving to next file.", file.FullName), ex); }
                        }
                        catch (Exception ex)
                        {
                            // Unexpected exception. Log the error, create custom exception and throw it up.
                            if (log.IsErrorEnabled) { log.Error(String.Format("Error deleting file '{0}' from report folder.", file.FullName), ex); }
                            throw new FileSystemAccessException(String.Format("Error deleting file '{0}' from report folder.", file.FullName), ex);
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                // Access exception might be a temporary condition.
                // Log it and continue processing.
                if (log.IsWarnEnabled) { log.Warn(String.Format("Access denied exception occurred while attempting to access '{0}'. Will retry later.", filePath), ex); }
            }
            catch (IOException ex)
            {
                // IO exception might be a temporary condition.
                // Log it and continue processing.
                if (log.IsWarnEnabled) { log.Warn(String.Format("IO exception occurred while attempting to access '{0}'. Will retry later.", filePath), ex); }
            }
            catch (FileSystemAccessException)
            {
                // Already logged as an unexpected exception, throw up to start service shutdown.
                throw;
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error("Unexpected error in PruneFiles method.", ex); }
                throw new FileSystemAccessException(String.Format("Unexpected error in PruneFiles method. FilePath: {0}.", filePath), ex);
            }
        }

        internal static void UnhandledServiceException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e == null)
            {
                if (log.IsFatalEnabled) { log.Fatal("The Woodmen Recon Client Service produced an unhandled exception. (Null UnhandledExceptionEventArgs)"); }
            }
            else if (e.ExceptionObject == null)
            {
                if (log.IsFatalEnabled) { log.Fatal("The Woodmen Recon Client Service produced an unhandled exception. (Null ExceptionObject)"); }
            }
            else
            {
                var exception = e.ExceptionObject as Exception;

                if (exception == null)
                {
                    if (log.IsFatalEnabled) { log.FatalFormat(CultureInfo.InvariantCulture, "The Woodmen Recon Client Service produced an unhandled exception.  e.ExceptionObject: {0}", e.ExceptionObject); }
                }
                else
                {
                    if (log.IsFatalEnabled) { log.Fatal("The Woodmen Recon Client Service produced an unhandled exception.", exception); }
                }
            }
        }
    }
}
