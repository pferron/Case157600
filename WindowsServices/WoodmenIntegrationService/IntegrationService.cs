using log4net;
using log4net.Config;
using Microsoft.Owin.Hosting;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using WOW.WoodmenIntegrationService.Properties;

namespace WOW.WoodmenIntegrationService
{
    public partial class IntegrationService : ServiceBase
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(IntegrationService));
        private DateTime _lastPurge;
        private Task _purgePayloadsTask;
        private Task _purgeUploadsTask;
        private CancellationTokenSource _tokenSource = new CancellationTokenSource();

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

                if (log.IsDebugEnabled) log.Debug("WoodmenIntegrationService: Initiating service");

                if (Environment.UserInteractive)
                {
                    var service = new IntegrationService();
                    service.OnStart(args);

                    Console.WriteLine("Woodmen Illustration Service Listener is running. Press enter to stop.");
                    Console.Read();

                    service.OnStop();
                }
                else
                {
                    var ServicesToRun = new ServiceBase[] { new IntegrationService() };
                    ServiceBase.Run(ServicesToRun);
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("The WoodmenIntegrationService has crashed.", ex);
            }
        }

        public IntegrationService()
        {
            InitializeComponent();

            CanPauseAndContinue = false;
            CanShutdown = true;
            CanStop = true;
            CanHandlePowerEvent = false;
            CanHandleSessionChangeEvent = false;
        }

        protected override void OnStart(string[] args)
        {
            StartOptions options = new StartOptions();
            // The plus seems to wild card the hostname. Otherwise, you'd have to add URLs for 127.0.0.1, localhost and the machine name.
            options.Urls.Add(Settings.Default.ServiceUrl);

            if (log.IsDebugEnabled) { log.Debug("Start up web host."); }

            WebApp.Start<IntegrationServiceStartup>(options);

            // Initialize purge datetime to distance past so files get cleaned up on start.
            _lastPurge = DateTime.MinValue;

            // Kick off conversion processes
            _purgePayloadsTask = Task.Factory.StartNew(() => PurgeFiles(WOW.WoodmenIllustrationService.Properties.Settings.Default.PayloadStorageFolder));
            _purgeUploadsTask = Task.Factory.StartNew(() => PurgeFiles(WOW.WoodmenIllustrationService.Properties.Settings.Default.UploadStorageFolder));
        }

        private void PurgeFiles(string folderPath)
        {
            try
            {
                if (String.IsNullOrEmpty(folderPath))
                {
                    throw new ArgumentException("A valid folder path is required for purging files.", "folderPath");
                }

                // How many hours should the task wait to before checking for files to delete.
                double checkInterval = Convert.ToDouble(Math.Abs(Settings.Default.PurgeFilesCheckHours) * -1);
                // How many days old a file needs to be for it to be deleted.
                double purgeAfterXDays = Convert.ToDouble(Math.Abs(Settings.Default.PurgeFilesAfterDays) * -1);
                // How many milliseconds to sleep while looping.
                // This interval should be very short so that the service shutsdown in a timely manner.
                int checkSleepMilliseconds = Settings.Default.PurgeFilesCheckSleepMilliseconds;

                while (!_tokenSource.IsCancellationRequested)
                {
                    // checkInterval will be a negative number
                    if (_lastPurge < DateTime.Now.AddHours(checkInterval) && Directory.Exists(folderPath))
                    {
                        var outboxFolder = new DirectoryInfo(folderPath);
                        var oldFiles = outboxFolder.GetFiles().Where(f => f.CreationTime < DateTime.Now.AddDays(purgeAfterXDays));

                        // If we find some old files, let's update the _lastPurge value
                        // This should have the effect of deleting 1 or more files and then waiting checkInterval hours and deleting another batch.
                        if (oldFiles.Count() > 0)
                        {
                            _lastPurge = DateTime.Now;
                        }

                        foreach (var file in oldFiles)
                        {
                            // In case there are a lot of files and the service is stopped, check the token before each file.
                            if (_tokenSource.IsCancellationRequested) return;

                            try
                            {
                                file.Delete();
                                if (log.IsDebugEnabled) { log.Debug(String.Format("Deleted file '{0}'.", file.FullName)); }
                            }
                            catch (Exception ex)
                            {
                                // IO exception might be a temporary condition.
                                // Log it and continue processing.
                                if (log.IsErrorEnabled) { log.Error(String.Format("Error deleting file '{0}'. Moving to next file.", file.FullName), ex); }
                            }
                        }
                    }

                    Thread.Sleep(checkSleepMilliseconds);
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error("Unexpected error in PurgeFiles method.", ex); }
                throw;
            }
        }

        protected override void OnStop()
        {
            try
            {
                log.Info("Woodmen Integration Service is shutting down.");

                _tokenSource.Cancel();

                _purgePayloadsTask.Wait(_tokenSource.Token);
                _purgeUploadsTask.Wait(_tokenSource.Token);

                base.OnStop();
            }
            catch (AggregateException e)
            {
                foreach (var i in e.InnerExceptions)
                {
                    if (log.IsErrorEnabled) { log.Error("PurgeFiles task exception caught during shutdown.", i); }
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

            if (log.IsInfoEnabled) { log.Info("Woodmen Integration Service shutdown complete."); }
        }

        internal static void UnhandledServiceException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e == null)
            {
                if (log.IsFatalEnabled) { log.Fatal("The Woodmen Integration Service produced an unhandled exception. (Null UnhandledExceptionEventArgs)"); }
            }
            else if (e.ExceptionObject == null)
            {
                if (log.IsFatalEnabled) { log.Fatal("The Woodmen Integration Service produced an unhandled exception. (Null ExceptionObject)"); }
            }
            else
            {
                var exception = e.ExceptionObject as Exception;

                if (exception == null)
                {
                    if (log.IsFatalEnabled) { log.FatalFormat(CultureInfo.InvariantCulture, "The Woodmen Integration Service produced an unhandled exception.  e.ExceptionObject: {0}", e.ExceptionObject); }
                }
                else
                {
                    if (log.IsFatalEnabled) { log.Fatal("The Woodmen Integration Service produced an unhandled exception.", exception); }
                }
            }
        }
    }
}
