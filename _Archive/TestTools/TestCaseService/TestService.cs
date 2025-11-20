using log4net;
using log4net.Config;
using Newtonsoft.Json;
using Polly;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestCaseService.Properties;
using WebServiceTestManager.Models;

namespace TestCaseService
{
    public partial class TestService : ServiceBase
    {
        #region Private members
        private static readonly ILog log = LogManager.GetLogger(typeof(TestService));
        private CancellationTokenSource _tokenSource = new CancellationTokenSource();
        private Task _runTest;
        private Task _recover;
        #endregion

        #region Constructor and related
        public TestService()
        {
            InitializeComponent();

            CanPauseAndContinue = false;
            CanShutdown = true;
            CanStop = true;
            CanHandlePowerEvent = false;
            CanHandleSessionChangeEvent = false;
        }

        static void Main(string[] args)
        {
            try
            {
                // Configure log4net to use the service's app path instead of the system32 folder.
                Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
                XmlConfigurator.Configure();

                // Wire-up unhandled exception event
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledServiceException);

                if (log.IsDebugEnabled) log.Debug("TestCaseService: Initiating service");

                if (Environment.UserInteractive)
                {
                    var service = new TestService();
                    service.OnStart(args);

                    Console.WriteLine("Cool service is running. Press enter to stop.");
                    Console.Read();

                    service.OnStop();
                }
                else
                {
                    var ServicesToRun = new ServiceBase[] { new TestService() };
                    Run(ServicesToRun);
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("The TestCaseService has crashed.", ex);
            }
        }
        #endregion

        #region Internal Methods and Overrides
        internal static void UnhandledServiceException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e == null)
            {
                if (log.IsFatalEnabled) { log.Fatal("TestCaseService produced an unhandled exception. (Null UnhandledExceptionEventArgs)"); }
            }
            else if (e.ExceptionObject == null)
            {
                if (log.IsFatalEnabled) { log.Fatal("TestCaseService Service produced an unhandled exception. (Null ExceptionObject)"); }
            }
            else
            {
                var exception = e.ExceptionObject as Exception;

                if (exception == null)
                {
                    if (log.IsFatalEnabled) { log.FatalFormat(CultureInfo.InvariantCulture, "The TestCaseService produced an unhandled exception.  e.ExceptionObject: {0}", e.ExceptionObject); }
                }
                else
                {
                    if (log.IsFatalEnabled) { log.Fatal("The TestCaseService produced an unhandled exception.", exception); }
                }
            }
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                //System.Diagnostics.Debugger.Launch();
                _runTest = Task.Run(() => RunTest(Settings.Default.FolderPath, Settings.Default.CheckFolderPath), _tokenSource.Token);
                _recover = Task.Run(() => Recover(), _tokenSource.Token);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("The TestCaseService was unable to start.", ex);
                throw;
            }
        }

        protected override void OnStop()
        {
            try
            {
                if (log.IsDebugEnabled) log.Debug("Stop reqeusted");
                _tokenSource.Cancel();
                _runTest.Wait( _tokenSource.Token);

                base.OnStop();
            }
            catch (AggregateException e)
            {
                foreach (var i in e.InnerExceptions)
                {
                    if (log.IsErrorEnabled) { log.Error("RunTest task exception caught during shutdown.", i); }
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

            if (log.IsDebugEnabled) log.Debug("Stopped TestCaseService, goodnight.");
        }
        #endregion

        /// <summary>
        /// Listen for a new test set to execute.
        /// </summary>
        /// <param name="folderPath">the folder that contains the tests</param>
        /// <param name="checkFolderPath">The shared folder that will be checked, should contain one file with the Test Set ID</param>
        private void RunTest(string folderPath, string checkFolderPath)
        {
            try
            {
                //XOR
                if(!Directory.Exists(folderPath) && !Directory.Exists(checkFolderPath))
                {
                    if (log.IsErrorEnabled) log.Error($"The directory for folder path or check folder path was not found. folderPath: {folderPath}, checkFolderPath: {checkFolderPath}");
                    throw new DirectoryNotFoundException("The directory for folder path or check folder path was not found.");
                }


                while (!_tokenSource.IsCancellationRequested)
                {
                     if(Directory.EnumerateFileSystemEntries(checkFolderPath).Any())
                     {
                        Console.WriteLine("Directory found");
                        var checkFileName = Directory.GetFiles(checkFolderPath).First();
                        checkFileName = Path.GetFileName(checkFileName);

                        var checkFileNameValues = checkFileName.Split(' ');

                        if (checkFileNameValues.Length != 2)
                            continue;

                        if (!int.TryParse(checkFileNameValues[0], out int testSetId) || !int.TryParse(checkFileNameValues[1], out int destinationId))
                        {
                            if (log.IsDebugEnabled) log.Debug($"Found a file, however it was of the wrong format and was deleted. {checkFileName[0]}");
                            Console.WriteLine("Found a file, however it is of incorrect format. Deleting anyways");
                            System.IO.File.Delete(checkFileName);
                            continue;
                        }

                        Console.WriteLine($"First test set found: {checkFileName[0]}");

                        var filesToTest = new List<WebServiceTestManager.Models.File>();
                        using (var context = new Database())
                        {
                            filesToTest = context.Files.Where(f => f.TestSetId == testSetId).ToList();
                        }

                        if (log.IsDebugEnabled) log.Debug($"Starting a new run with {filesToTest.Count} files");

                        //Give all test set a guid
                        Guid identifier = Guid.NewGuid();

                        //create a list of new tests and add them to the database.
                        var executions = new List<TestExecution>();
                        using (var context = new Database())
                        {
                            foreach (var file in filesToTest)
                            {
                                var testSet = context.TestSets.Find(file.TestSetId);
                                var destination = context.Destinations.Find(destinationId);

                                var testExecution = new TestExecution()
                                {
                                    FileId = file.Id,
                                    TestSetName = testSet.Name,
                                    DestinationName = destination.Name,
                                    DestinationUrl = destination.Url,
                                    TestSetId = (int)file.TestSetId,
                                    Result = 0,
                                    ExecutionDate = DateTime.Now,
                                    TestIdentifier = identifier
                                };
                                context.TestExecutions.Add(testExecution);

                                executions.Add(testExecution);
                                    
                            }
                            context.SaveChanges();
                        }

                        //remove the file 
                        System.IO.File.Delete(Directory.GetFiles(checkFolderPath).First());
                        //checkFile = Directory.GetFiles(checkFolderPath);
                        if (checkFileName.Length == 0)
                        {
                            Directory.Delete(checkFolderPath);
                        }

                        //evalutate a test set 5 tests at a time.
                        Parallel.ForEach(executions, new ParallelOptions { MaxDegreeOfParallelism = 5 }, file =>
                        { 
                            EvaluateTest(file);
                        });
                    }
                    Thread.Sleep(Directory.Exists(checkFolderPath) && Directory.EnumerateFileSystemEntries(checkFolderPath).Any() ? 0 : 5000);
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("The RunTest encountered an unrecoverable error..", ex);
                throw;
            }
        }

        /// <summary>
        /// Check if any tests need to be completed by checking the db (Only run on launch)
        /// </summary>
        private void Recover()
        {
            try
            {
                if (log.IsDebugEnabled) log.Debug("Attempting to recover.");
                var filesToTest = new List<TestExecution>();
                using (var context = new Database())
                {
                    //find files where the result is 0 (needs to be run)
                    filesToTest = context.TestExecutions.Where(f => f.Result == 0).ToList();
                    if (log.IsDebugEnabled) log.Debug($"Files to recover count: {filesToTest.Count}");
                }

                Parallel.ForEach(filesToTest, new ParallelOptions { MaxDegreeOfParallelism = 1 }, file =>
                {
                    //evaluate the test for each of the files
                    EvaluateTest(file);
                });
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Recover threw an error", ex);
            }
        }

        #region Helper Methods
        /// <summary>
        /// Run all tests by a given set id
        /// </summary>
        /// <param name="testExecution"> The file that we will be testing.</param>
        private void EvaluateTest(TestExecution testExecution)
        {
            try
            {
                if (log.IsDebugEnabled) log.Debug($"{testExecution.Id}: Evaluating a test file with the parameter: {FileToString(testExecution)}");

                //get the file from the fs and prepare to send it to the server.
                var testFile = System.IO.File.ReadAllText(Directory.GetFiles(Settings.Default.FolderPath, testExecution.FileId.ToString() + ".*").First());
                var content = new StringContent(testFile, Encoding.Default, "application/json");
                Console.WriteLine($"Starting {testExecution.Id}");


                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, 1, 0);
                    string endpoint = string.Empty;

                    httpClient.BaseAddress = new Uri(testExecution.DestinationUrl);

                    //set up polly retry time
                    var sleepDurations = new TimeSpan[2];

                    for (int x = 0; x < sleepDurations.Length; x++)
                    {
                        sleepDurations[x] = TimeSpan.FromSeconds(Math.Pow(2, (x + 1)));
                    }
                    string blarg = string.Empty;

                    //handle retry of a request
                    var retryPolicy = Policy
                    .Handle<Exception>()
                    .WaitAndRetryAsync(sleepDurations, (exception, timeSpan, retryCount, context) =>
                    {
                        if (log.IsErrorEnabled) log.Error($"Test Execution id: {testExecution.Id} failed.", exception);
                        Console.WriteLine($"{testExecution.Id}: Hey we failed..");
                    })
                    .ExecuteAsync(() => httpClient.PostAsync(string.Empty, content));

                    var task = retryPolicy.ContinueWith(t => blarg = t.Result.Content.ReadAsStringAsync().Result);
                    task.Wait();



                    //TODO: fix polly and the async.

                    //var requestTask = httpClient.PostAsync(endpoint, content);
                    //requestTask.Wait();

                    //var response = requestTask.Result;

                    //retryPolicy.EnsureSuccessStatusCode();

                    //var contentTask = retryPolicy.Content.ReadAsStringAsync();
                    //contentTask.Wait();

                    //take the results and turn them into json.
                    //dynamic jsonResult = JsonConvert.DeserializeObject(contentTask.Result);
                    var jsonResult = JsonConvert.DeserializeObject<List<RateResponseModel>>(blarg);

                    var expectedList = new List<ExpectedValue>();

                    using (var context = new Database())
                    {
                        expectedList = context.ExpectedValues.Where(e => e.FileId == testExecution.FileId).ToList();
                    }
                    var processor = ProcessorFactory.Processor(blarg, ProcessorType.MobileRater, expectedList);

                    var result = processor.Process();
                    
                    //check every item against a list.
                    var errorList = new List<string>();
                    errorList.AddRange(result.ErrorList);
                    Console.WriteLine($"Finshed {testExecution.Id}");

                    errorList.Add($"Response: {blarg}");

                    //save the results.
                    using (var context = new Database())
                    {
                        context.TestExecutions.Attach(testExecution);
                        testExecution.Result = result.Pass ? 1 : 2;
                        testExecution.Summary = string.Join("", errorList);
                        context.SaveChanges();
                    }
                }
                if (log.IsDebugEnabled) log.Debug($"{testExecution.Id}: Completed successfully.");
            }
            catch (AggregateException ae)
            {
                var exceptionList = new List<string>();
                exceptionList.Add("The following error(s) occured.*");
                foreach (var e in ae.Flatten().InnerExceptions)
                {
                    exceptionList.Add(e.Message + "*");
                }
                using (var context = new Database())
                {
                    context.TestExecutions.Attach(testExecution);
                    testExecution.Result = 2;
                    testExecution.Summary = string.Join("", exceptionList);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error($"Evaluate Test encountered an unrecoverable error. File that was passed in {FileToString(testExecution)}", ex);
                Console.WriteLine($"Error {ex}");

                using (var context = new Database())
                {
                    context.TestExecutions.Attach(testExecution);
                    testExecution.Result = 2;
                    testExecution.Summary = $"Unable to test.* {ex.Message}*";
                    context.SaveChanges();
                }
                return;
            }
        }

        /// <summary>
        /// TestExecution model is an auto generated file which can't implement the ToString method, so this is a way to see a string version.
        /// </summary>
        /// <param name="file">The execution that will be tested</param>
        /// <returns>The string version of the execution.</returns>
        private static string FileToString(TestExecution file)
        {
            try
            {
                if (file == null)
                    throw new ArgumentNullException(nameof(file), "The file was null");

                return $"File ID: {file.FileId} Test ID: {file.TestIdentifier} " +
                    $"Destination: {file.DestinationUrl}({file.DestinationName}) from test set: {file.TestSetName}({file.TestSetId})";

            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error($"FileToString threw an error, {ex.Message}");
                return "File Threw an error. Check Logs";
            }
        }

        #endregion


    }
}
