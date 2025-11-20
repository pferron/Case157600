using log4net;
using LPA.Dashboard.Web.ActionCode;
using LPA.Dashboard.Web.Code;
using LPA.Dashboard.Web.Properties;
using LPA.Dashboard.Web.ViewModels;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using WOW.IllustrationMgmntTool.Common.DTO;

namespace LPA.Dashboard.Web.Controllers
{
    public class CisTestToolController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(CisTestToolController));

        public ActionResult Index()
        {
            if (log.IsInfoEnabled) log.Info($"Calling Index.");

            TestResultCimIndexViewModel cisTestResultIndexViewModel = new TestResultCimIndexViewModel();

            try
            {
                CisTestToolActions cisTestToolActions = new CisTestToolActions();
                cisTestResultIndexViewModel = cisTestToolActions.ProcessTestResultCimIndex();
            }
            catch (Exception ex)
            {
                var message = $"An exception occurred while retrieving the productTypeCodes";
                cisTestResultIndexViewModel.ErrorMessage = message;

                if (log.IsErrorEnabled)
                {
                    log.Error(message, ex);
                }
            }

            return View(cisTestResultIndexViewModel);
        }

        public async Task<ActionResult> ProcessCimFiles(int testGroupId, string cisUrl)
        {
            if (log.IsInfoEnabled) log.Info($"Calling ProcessCimFiles with testGroupId: {testGroupId}, and cisUrl: {cisUrl}.");

            ProcessCimFilesViewModel processCimFilesViewModel = new ProcessCimFilesViewModel();

            try
            {
                CisTestToolActions cisTestToolActions = new CisTestToolActions();
                processCimFilesViewModel = await cisTestToolActions.ProcessCimFiles(testGroupId, cisUrl);
            }
            catch (Exception ex)
            {
                var message = $"An exception occurred while processing the testGroup for testgroupId: {testGroupId}.";
                processCimFilesViewModel.ErrorMessage = message;

                if (log.IsErrorEnabled)
                {
                    log.Error(message, ex);
                }
            }
            return View("ProcessCimFiles", processCimFilesViewModel);
        }

        public ActionResult Search()
        {
            if (log.IsInfoEnabled) log.Info($"Calling Search.");

            TestResultCimSearchViewModel cisTestResultSearchViewModel = new TestResultCimSearchViewModel();
            
            try
            {
                CisTestToolActions cisTestToolActions = new CisTestToolActions();
                cisTestResultSearchViewModel = cisTestToolActions.ProcessSearch();
            }
            catch (Exception ex)
            {
                var message = $"An exception occurred while retrieving the Cis Test Results.";
                cisTestResultSearchViewModel.ErrorMessage = message;

                if (log.IsErrorEnabled)
                {
                    log.Error(message, ex);
                }
            }

            return View(cisTestResultSearchViewModel);
        }

        public ActionResult SearchResults()
        {
            if (log.IsInfoEnabled) log.Info($"Calling Search.");

            TestResultCimSearchViewModel cisTestResultSearchViewModel = new TestResultCimSearchViewModel();

            try
            {
            }
            catch (Exception ex)
            {
                var message = $"An exception occurred while retrieving the Cis Test Results.";
                cisTestResultSearchViewModel.ErrorMessage = message;

                if (log.IsErrorEnabled)
                {
                    log.Error(message, ex);
                }
            }

            return View("SearchResults", cisTestResultSearchViewModel);
        }

        public ActionResult DoSearch(TestResultCimSearchDto searchDto, int? pageNumber)
        {
            if (log.IsInfoEnabled) log.Info($"Calling DoSearch with searchDto: {searchDto.ToString()}.");

            TestResultCimSearchViewModel cisTestResultSearchViewModel = new TestResultCimSearchViewModel();

            try
            {
                CisTestToolActions cisTestToolActions = new CisTestToolActions();
                cisTestResultSearchViewModel = cisTestToolActions.ProcessDoSearch(searchDto, pageNumber);
            }
            catch (Exception ex)
            {
                var message = $"An exception occurred while retrieving the Cis Test Results.";
                cisTestResultSearchViewModel.ErrorMessage = message;

                if (log.IsErrorEnabled)
                {
                    log.Error(message, ex);
                }
            }

            return PartialView("SearchResults", cisTestResultSearchViewModel);
        }

        public ActionResult DisplayCimJson(long testResultId)
        {
            if (log.IsInfoEnabled) log.Info($"Calling DisplayCimJson with testResultId: {testResultId}.");

            DisplayCimJsonViewModel displayCimJsonViewModel = new DisplayCimJsonViewModel();

            try
            {
                CisTestToolActions cisTestToolActions = new CisTestToolActions();
                displayCimJsonViewModel = cisTestToolActions.ProcessDisplayCimJson(testResultId);
            }
            catch (Exception ex)
            {
                var message = $"An exception occurred while displaying the cim json.";
                displayCimJsonViewModel.ErrorMessage = message;

                if (log.IsErrorEnabled)
                {
                    log.Error(message, ex);
                }
            }
            return View("DisplayCimJson", displayCimJsonViewModel);
        }

        public ActionResult DisplayIllustration(long testResultId)
        {
            if (log.IsInfoEnabled) log.Info($"Calling DisplayIllustration with testResultId: {testResultId}.");

            DisplayIllustrationViewModel displayIllustrationViewModel = new DisplayIllustrationViewModel();

            try
            {
                displayIllustrationViewModel.TestResultId = testResultId;
            }
            catch (Exception ex)
            {
                var message = $"An exception occurred while displaying the cim json.";
                displayIllustrationViewModel.ErrorMessage = message;

                if (log.IsErrorEnabled)
                {
                    log.Error(message, ex);
                }
            }
            return View("DisplayIllustration", displayIllustrationViewModel);
        }
    }
}