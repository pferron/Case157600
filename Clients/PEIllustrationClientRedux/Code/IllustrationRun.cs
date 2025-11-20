using log4net;
using Newtonsoft.Json;
using Polly;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WOW.Illustration.Model.Generation.Response;
using WOW.PEIllustrationClient.Exceptions;
using WOW.PEIllustrationClient.Properties;

namespace WOW.PEIllustrationClient.Code
{

    public class IllustrationRun : IDisposable
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(IllustrationRun));
        private static readonly ILog _email = LogManager.GetLogger("EmailLogger");

        private int _runID;
        private HttpClient _client;
        private List<Task> _transactionTasks = new List<Task>();

        private int _illustrationErrorCount = 0;
        private object _classLock = new object();
        private SemaphoreSlim _semaphore = new SemaphoreSlim(Settings.Default.MaxConcurrentRequests, Settings.Default.MaxConcurrentRequests);

        //private Dictionary<string, string> _configList = new Dictionary<string,string>();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_client != null)
                {
                    try
                    {
                        _client.Dispose();
                    }
                    catch
                    {
                        // Ignore
                    }

                    _client = null;
                }
            }
        }

        public IllustrationRun(int runID)
        {
            _runID = runID;
        }

        public void StartRun()
        {
            try
            {
                if (_log.IsDebugEnabled) { _log.DebugFormat(CultureInfo.InvariantCulture, "RunID: {0} entering StartRun", _runID); }

                _client = new HttpClient();
                _client.BaseAddress = new Uri(Settings.Default.IllustrationServiceBaseUrl);
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                _client.Timeout = Settings.Default.HttpClientRequestTimeout;

                var fipFilePath = String.Format(CultureInfo.InvariantCulture, Settings.Default.InputFipFilePath, _runID);

                if (_log.IsDebugEnabled) { _log.DebugFormat(CultureInfo.InvariantCulture, "Input FIP file: {0}", fipFilePath); }

                var fips = FipHandler.LoadFipRequests(fipFilePath);

                if (_log.IsDebugEnabled) { _log.DebugFormat(CultureInfo.InvariantCulture, "Loaded {0} FIP requests.", fips.Count); }
                if (_log.IsDebugEnabled) { _log.DebugFormat(CultureInfo.InvariantCulture, "Max concurrent requests: {0}", Settings.Default.MaxConcurrentRequests); }

                // Setup sleep durations for Polly
                var sleepDurations = new TimeSpan[Settings.Default.RetryCount];

                for(int x = 0; x < sleepDurations.Length; x++)
                {
                    // 2 ^ 1 = 2 seconds
                    // 2 ^ 2 = 4 seconds
                    // 2 ^ 3 = 8 seconds
                    // etc.
                    sleepDurations[x] = TimeSpan.FromSeconds(Math.Pow(2, (x + 1)));
                }
                
                var retryPolicy = Policy
                                    .Handle<CommunicationException>()
                                    .WaitAndRetryAsync(sleepDurations, (exception, timeSpan, retryCount, context) =>
                                    {
                                        _log.Warn(string.Format("Communication problem detected. Request will be retried. TimeSpan: {0}, RetryCount: {1}", timeSpan, retryCount), exception);
                                    });

                foreach (var fip in fips)
                {
                    var task = retryPolicy.ExecuteAsync(() => SendIllustrationRequest(fip));
                    task.ContinueWith((x) => _semaphore.Release());

                    _transactionTasks.Add(task);
                }

                Task.WaitAll(_transactionTasks.ToArray());

                CheckForIllustrationErrors();
            }
            catch (Exception ex)
            {
                if (_log.IsErrorEnabled) { _log.Error(String.Format(CultureInfo.InvariantCulture, "There was a problem in StartRun processing with RunID:{0}", _runID), ex); }
            }
        }

        private void CheckForIllustrationErrors()
        {
            string message = String.Empty;

            int totalTasksCount = _transactionTasks.Count;
            int faultedTasksCount = _transactionTasks.Count(t => t.IsFaulted || t.IsCanceled);

            var failRate = (faultedTasksCount + _illustrationErrorCount) / (double)totalTasksCount;

            if (faultedTasksCount > 0 || _illustrationErrorCount > 0)
            {
                // Build message for illustration tasks that have faulted or cancelled.
                if (faultedTasksCount > 0)
                {
                    if (_log.IsErrorEnabled) { _log.ErrorFormat("{0} out of {1} illustration requests faulted for run {2}. Illustration files may be missing.", faultedTasksCount, totalTasksCount, _runID); }

                    message += String.Format("{0} out of {1} illustration requests faulted for run {2}.", faultedTasksCount, totalTasksCount, _runID);
                    message += Environment.NewLine + Environment.NewLine;
                }

                // Build message for illustration requests that finished, but may have had a 500 error or failed to write out the attached files.
                if (_illustrationErrorCount > 0)
                {
                    if (_log.IsErrorEnabled) { _log.ErrorFormat("{0} out of {1} illustration requests for run {2} failed. Please check the log.", _illustrationErrorCount, totalTasksCount, _runID); }

                    message += String.Format("{0} out of {1} illustration requests for run {2} failed.", _illustrationErrorCount, totalTasksCount, _runID);
                    message += Environment.NewLine + Environment.NewLine;
                }

                if (_log.IsDebugEnabled) { _log.DebugFormat("The illustration request fail rate for run {0} is {1:P}.", _runID, failRate); }

                // Add warning if ratio of fail/total exceed configured threshold
                if (failRate >= Settings.Default.WarningThresholdRatio)
                {
                    if (_log.IsErrorEnabled) { _log.ErrorFormat("The illustration request fail rate ({0:P}) exceeds the configured threshold ({1:P}) for run {2}.", failRate, Settings.Default.WarningThresholdRatio, _runID); }

                    message += String.Format("The illustration request fail rate ({0:P}) exceeds the configured threshold ({1:P}) for run {2}. Please contact on-call support immediately.", failRate, Settings.Default.WarningThresholdRatio, _runID);
                    message += Environment.NewLine + Environment.NewLine;
                }
                else
                {
                    if (_log.IsErrorEnabled) { _log.ErrorFormat("The illustration request fail rate ({0:P}) does not exceed the configurable threshold ({1:P}) for run {2}.", failRate, Settings.Default.WarningThresholdRatio, _runID); }

                    message += String.Format("The illustration request fail rate did not exceed the configured threshold for run {0}. This message is for informational purposes only. There is no need to contact on-call support.", _runID);
                    message += Environment.NewLine + Environment.NewLine;
                }

                _email.Error(message);

            }
            
        }

        private string GetFipValue(string fipContent, string fieldName)
        {
            if (String.IsNullOrWhiteSpace(fipContent))
            {
                if (_log.IsErrorEnabled) { _log.Error("GetFipValue: 'fipContent' is null or empty."); }
                throw new ArgumentException("FIP data is required to use this method.", "fipContent");
            }

            if (String.IsNullOrWhiteSpace(fieldName))
            {
                if (_log.IsErrorEnabled) { _log.Error("GetFipValue: 'fieldName' is null or empty."); }
                throw new ArgumentException("Field Name cannot be null or empty.", "fieldName");
            }

            string result = null;

            using (StringReader reader = new StringReader(fipContent))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith(fieldName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        // ex. outputName , Illus_1660631
                        var tmpDataPair = line.Split(',');

                        // Either no comma or too many commas
                        if (tmpDataPair.Length != 2)
                        {
                            throw new ApplicationException(String.Format(CultureInfo.InvariantCulture, "FIP data in unexpected format. Data: {0}", line));
                        }

                        result = tmpDataPair[1].Trim();
                    }
                }
            }

            return result;
        }

        private async Task SendIllustrationRequest(string fipContent)
        {
            try
            {
                _semaphore.Wait();

                var encodedFip = Encoding.UTF8.GetBytes(fipContent);

                var outputFolderPath = GetFipValue(fipContent, "outputPath");
                var outputFilename = GetFipValue(fipContent, "outputName"); // Does not usually include an extension

                var outputFilenameNoExt = Path.GetFileNameWithoutExtension(outputFilename);

                var pdfFilePath = Path.Combine(outputFolderPath, outputFilenameNoExt + ".pdf");
                var txtFilePath = Path.Combine(outputFolderPath, outputFilenameNoExt + ".txt");

                using (var content = new MultipartFormDataContent())
                using (var ms = new MemoryStream(encodedFip))
                using (var contentStream = new StreamContent(ms))
                {
                    content.Add(contentStream, "fipFile", "pefile.fip");

                    var responseObj = await _client.PostAsync(Settings.Default.FipEndpoint, content);

                    if (responseObj.IsSuccessStatusCode)
                    {
                        var response = await responseObj.Content.ReadAsStringAsync();

                        var wisResponse = JsonConvert.DeserializeObject<WoodmenIllustrationResponse>(response);

                        ProcessResponse(wisResponse, pdfFilePath, txtFilePath);
                    }
                    else
                    {
                        if (_log.IsErrorEnabled) { _log.ErrorFormat("The Woodmen Illustration Service returned an error. Response: {0}", responseObj); }

                        // This means a response like 404 or 500 was received and there are no files available. Warn the team.
                        IncrementIllustrationErrorCounter();
                    }
                }
            }
            catch (Exception ex)
            {
                if (_log.IsErrorEnabled) { _log.Error("Error processing FIP request to the Woodmen Illustration Service.", ex); }

                throw new CommunicationException("An error occurred while attempting to communicate with remote host.", ex);
            }
        }

        private void IncrementIllustrationErrorCounter()
        {
            try
            {
                lock (_classLock)
                {
                    _illustrationErrorCount++;
                }
            }
            catch(Exception ex)
            {
                if (_log.IsErrorEnabled) { _log.Error("Error incrementing error count field.", ex); }
            }
        }

        private void ProcessResponse(WoodmenIllustrationResponse wisResponse, string pdfFilePath, string txtFilePath)
        {
            if (wisResponse == null)
            {
                if (_log.IsErrorEnabled) { _log.Error("ProcessResponse: 'wisResponse' is null."); }
                throw new ArgumentNullException("The Woodmen Illustration Response object cannot be null.", "wisResponse");
            }

            if (String.IsNullOrWhiteSpace(pdfFilePath))
            {
                if (_log.IsErrorEnabled) { _log.Error("ProcessResponse: 'pdfFilePath' is null or empty."); }
                throw new ArgumentException("A file path is required to use this method.", "targetFilePath");
            }

            if (String.IsNullOrWhiteSpace(txtFilePath))
            {
                if (_log.IsErrorEnabled) { _log.Error("ProcessResponse: 'txtFilePath' is null or empty."); }
                throw new ArgumentException("A file path is required to use this method.", "targetFilePath");
            }


            if (wisResponse.HasError)
            {
                if (_log.IsErrorEnabled) { _log.ErrorFormat("The Woodmen Illustration Service returned an error. Error: {0}, Target PDF Path: {1}, Target TXT Path: {2}", wisResponse.ErrorMessage, pdfFilePath, txtFilePath); }

                // This means LPA returned an internal error code and there are no files available. Warn the team.
                IncrementIllustrationErrorCounter();

                return;
            }
            else
            {
                if (wisResponse.HasPdfFile && wisResponse.HasValuesFile)
                {
                    try
                    {
                        if (_log.IsDebugEnabled) { _log.DebugFormat(CultureInfo.InvariantCulture, "Saving PDF attachment: {0}.", pdfFilePath); }
                        SaveDecodedFile(pdfFilePath, wisResponse.PdfFileAttachment);

                        if (_log.IsDebugEnabled) { _log.DebugFormat(CultureInfo.InvariantCulture, "Saving TXT attachment: {0}.", txtFilePath); }
                        SaveDecodedFile(txtFilePath, wisResponse.ValuesFileAttachment);
                    }
                    catch (Exception ex)
                    {
                        if (_log.IsErrorEnabled) { _log.Error(String.Format(CultureInfo.InvariantCulture, "An error occurred while saving the illustration attachments. PDF File Target: {0}, TXT File Target: {1}", pdfFilePath, txtFilePath), ex); }

                        // This means files are missing. Warn the team.
                        IncrementIllustrationErrorCounter();
                    }
                }
                else
                {
                    if (_log.IsErrorEnabled) { _log.ErrorFormat(CultureInfo.InvariantCulture, "One or both LPA file attachments are missing. WIS Response: {0}.", wisResponse); }

                    // This means files are missing. Warn the team.
                    IncrementIllustrationErrorCounter();
                }
            }
        }

        private static void SaveDecodedFile(string targetFilePath, string encodedContent)
        {
            if (String.IsNullOrWhiteSpace(targetFilePath))
            {
                if (_log.IsErrorEnabled) { _log.Error("SaveDecodedFile: 'targetFilePath' is null or empty."); }
                throw new ArgumentException("A file path is required to use this method.", "targetFilePath");
            }

            if (String.IsNullOrWhiteSpace(encodedContent))
            {
                if (_log.IsErrorEnabled) { _log.Error("SaveDecodedFile: 'encodedContent' is null or empty."); }
                throw new ArgumentException("Base64 encoded data is required to use this method.", "encodedContent");
            }

            try
            {
                var filebytes = Convert.FromBase64String(encodedContent);
                File.WriteAllBytes(targetFilePath, filebytes);
            }
            catch (Exception ex)
            {
                if (_log.IsErrorEnabled) { _log.Error(String.Format(CultureInfo.InvariantCulture, "An error occurred while writing out file '{0}'.", targetFilePath), ex); }

                throw;
            }
        }
    }
}


