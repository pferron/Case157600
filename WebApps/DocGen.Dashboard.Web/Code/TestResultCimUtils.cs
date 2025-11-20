using log4net;
using LPA.Dashboard.Web.Properties;
using LPA.Dashboard.Web.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Polly;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WOW.IllustrationMgmntTool.Common.DAL;
using WOW.IllustrationMgmntTool.Common.DAO.LPAManagement;
using WOW.IllustrationMgmntTool.Common.DTO;

namespace LPA.Dashboard.Web.Code
{
    /// <summary>
    /// The test result CIM utilities.
    /// </summary>
    public class TestResultCimUtils
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(TestResultCimUtils));

        /// <summary>
        /// Gets the test results CIM.
        /// </summary>
        /// <returns>A list of test result CIM DAOs.</returns>
        public List<TestResultCIMDao> GetTestResultsCim()
        {
            if (log.IsInfoEnabled) log.Info("GetTestResultsCim called.");

            TestResultCimLogic testResultCimLogic = new TestResultCimLogic();

            return testResultCimLogic.GetTestResultsCIM();
        }

        /// <summary>
        /// Gets the test result CIM json.
        /// </summary>
        /// <param name="testResultId">The test result id.</param>
        /// <returns>A string.</returns>
        public string GetTestResultCimJson(long testResultId)
        {
            if (log.IsInfoEnabled) log.Info($"GetTestResultsCim called with testResultId: {testResultId}.");

            TestResultCimLogic testResultCimLogic = new TestResultCimLogic();
            var testResult = testResultCimLogic.GetTestResult(testResultId);
            var cimJson = testResult.CimJson;

            return PretifyCimJson(cimJson);
        }

        /// <summary>
        /// Gets the test result illustration.
        /// </summary>
        /// <param name="testResultId">The test result id.</param>
        /// <returns>An array of bytes</returns>
        public byte[] GetTestResultIllustration(long testResultId)
        {
            if (log.IsInfoEnabled) log.Info($"GetTestResultsCim called with testResultId: {testResultId}.");

            TestResultCimLogic testResultCimLogic = new TestResultCimLogic();
            var testResult = testResultCimLogic.GetTestResult(testResultId);
            var stringIllustration = testResult.Illustration;

            return Convert.FromBase64String(stringIllustration);
        }

        /// <summary>
        /// Gets the test results CIM.
        /// </summary>
        /// <param name="testGroupId">The test group id.</param>
        /// <returns>A list of test result CIM DAOs.</returns>
        public List<TestResultCIMDao> GetTestResultsCim(int testGroupId)
        {
            if (log.IsInfoEnabled) log.Info($"GetTestResultsCim called with testGroupId: {testGroupId}.");

            TestResultCimLogic testResultCimLogic = new TestResultCimLogic();

            return testResultCimLogic.GetTestResultsCIM(testGroupId);
        }

        /// <summary>
        /// Gets the test results CIM.
        /// </summary>
        /// <param name="searchDto">The search DTO.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A list of test result CIM DAOs.</returns>
        public List<TestResultCIMDao> GetTestResultsCim(TestResultCimSearchDto searchDto, int pageNumber, int pageSize)
        {
            if (log.IsInfoEnabled) log.Info($"GetTestResultsCim called with searchDto: {searchDto}, pageNumber: {pageNumber} and pageSize: {pageSize}.");

            TestResultCimLogic testResultCimLogic = new TestResultCimLogic();

            return testResultCimLogic.GetTestResultsCIM(searchDto, pageNumber, pageSize);
        }

        /// <summary>
        /// Gets the test results CIM count.
        /// </summary>
        /// <param name="searchDto">The search DTO.</param>
        /// <returns>An int.</returns>
        public int GetTestResultsCimCount(TestResultCimSearchDto searchDto)
        {
            if (log.IsInfoEnabled) log.Info($"GetTestResultsCim called with searchDto: {searchDto}.");

            TestResultCimLogic testResultCimLogic = new TestResultCimLogic();

            return testResultCimLogic.GetTestResultsCimCount(searchDto);
        }

        /// <summary>
        /// Gets the test file results.
        /// </summary>
        /// <param name="testGroupId">The test group id.</param>
        /// <param name="url">The url.</param>
        /// <returns>A ProcessCimFilesViewModel.</returns>
        public async Task<ProcessCimFilesViewModel> GetTestFileResults(int testGroupId, string url)
        {
            if (log.IsInfoEnabled) log.Info($"GetTestFileResults called with testGroupId: {testGroupId} and url: {url}.");

            ProcessCimFilesViewModel processCimFilesViewModel = new ProcessCimFilesViewModel();
            TestFileCimUtils testFileCimUtils = new TestFileCimUtils();
            var testFilesCim = testFileCimUtils.GetTestFilesCim(testGroupId);
            List<Task<TestResultCIMDao>> tasks = new List<Task<TestResultCIMDao>>();
            List<TestResultCIMDao> testResults = new List<TestResultCIMDao>();

            foreach (var testFile in testFilesCim)
            {
                var task = Task.Run(() => GenerateIllustrationsWebServiceCall(testFile, url));
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);

            foreach (var task in tasks)
            {
                var taskResult = await task;
                testResults.Add(taskResult);
            }

            //adds results to the database
            TestResultCimLogic testResultCimLogic = new TestResultCimLogic();
            testResultCimLogic.CreateTestResults(testResults);

            processCimFilesViewModel.TestResults = testResults;

            return processCimFilesViewModel;
        }

        /// <summary>
        /// Prettifies the CIM json.
        /// </summary>
        /// <param name="cimJson">The cim json.</param>
        /// <returns>A string.</returns>
        public string PretifyCimJson(string cimJson)
        {
            if (log.IsInfoEnabled) log.Info("PretifyJsonString called.");

            cimJson = cimJson.Trim();

            JObject jObj = JObject.Parse(cimJson);

            return JsonConvert.SerializeObject(jObj, Formatting.Indented);
        }

        private async Task<TestResultCIMDao> GenerateIllustrationsWebServiceCall(TestFileCIMDao testFileCIMDao, string url)
        {
            if (log.IsInfoEnabled) log.Info($"GenerateIllustrationsWebServiceCall called with testFileCIMDao: {testFileCIMDao} url: {url}.");

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    // Call Illustrations web service

                    var policy = Policy.Handle<Exception>()
                        .WaitAndRetry(Settings.Default.WebCallRetries, attempt => TimeSpan.FromTicks(Settings.Default.WebCallDelay.Ticks * attempt),
                        (ex, timeSpan) =>
                        {
                        });

                    //var jsonSerialiser = new JavaScriptSerializer();
                    //var json = jsonSerialiser.Serialize(testFileCIMDao.CimJson);

                    HttpContent content = new StringContent(testFileCIMDao.CimJson, Encoding.UTF8, "application/json");

                    Task<HttpResponseMessage> taskPost = policy.Execute(() => httpClient.PostAsync(url, content));
                    taskPost.Wait();

                    HttpResponseMessage response = taskPost.Result;
                    var responseString = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return new TestResultCIMDao
                        {
                            Age = testFileCIMDao.Age,
                            CimJson = testFileCIMDao.CimJson,
                            Completed = true,
                            Creator = testFileCIMDao.Creator,
                            DateCreated = DateTime.Now,
                            FaceAmount = testFileCIMDao.FaceAmount,
                            Gender = testFileCIMDao.Gender,
                            Illustration = responseString,
                            IllustrationReportType = testFileCIMDao.IllustrationReportType,
                            //TODO need to get actual value somehow
                            LPAVersion = "one",
                            PermanentTableRating = testFileCIMDao.PermanentTableRating,
                            ProductTypeCode = testFileCIMDao.ProductTypeCode,
                            RegionName = "test",
                            StateCode = testFileCIMDao.StateCode,
                            TestGroupId = testFileCIMDao.TestGroupId
                        };
                    }
                    else
                    {
                        var message = $"Status code: {response.StatusCode}. {responseString}.";
                        throw new Exception(message);
                    }
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error($"An error occurred while generating the illustrations web service call for TestFileCimId: {testFileCIMDao.TestFileCimId}.", ex);

                throw new Exception($"Unable to complete the call to the Illustrations web service call unsuccessful for TestFileCimId: {testFileCIMDao.TestFileCimId} Message: {ex.Message}.");
            }
        }
    }
}