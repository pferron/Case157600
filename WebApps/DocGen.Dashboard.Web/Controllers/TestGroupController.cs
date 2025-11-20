using log4net;
using LPA.Dashboard.Web.ActionCode;
using LPA.Dashboard.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using WOW.IllustrationMgmntTool.Common.DAO.LPAManagement;
using WOW.IllustrationMgmntTool.Common.DTO;
using WOW.IllustrationMgmntTool.Common.Models.CimFile;

namespace LPA.Dashboard.Web.Controllers
{
    public class TestGroupController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(TestGroupController));

        // GET: TestGroup
        public ActionResult Index()
        {
            if (log.IsInfoEnabled) log.Info($"Calling Index.");

            TestGroupViewModel testGroupViewModel = new TestGroupViewModel();

            try
            {
                TestGroupActions testGroupActions = new TestGroupActions();
                testGroupViewModel.Page = 1;
                testGroupViewModel = testGroupActions.ProcessIndex();                
            }
            catch (Exception ex)
            {
                var message = $"An exception occurred while retrieving test groups.";
                testGroupViewModel.ErrorMessage = message;
                if (log.IsErrorEnabled)
                {
                    log.Error(message, ex);
                }
            }

            return View(testGroupViewModel);
        }

        public ActionResult Search()
        {
            if (log.IsInfoEnabled) log.Info($"Calling Search.");

            TestGroupSearchViewModel testGroupSearchViewModel = new TestGroupSearchViewModel();

            try
            {
                TestGroupActions testGroupActions = new TestGroupActions();
                testGroupSearchViewModel = testGroupActions.ProcessSearch();
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    var message = $"An exception occurred while retrieving the transform statuses.";
                    log.Error(message, ex);
                }
            }

            return View("Index", testGroupSearchViewModel);
        }


        public ActionResult AddTestGroup()
        {
            if (log.IsInfoEnabled) log.Info($"Calling AddTestGroup.");

            TestGroupViewModel testGroupViewModel = new TestGroupViewModel();

            try
            {
                TestGroupActions testGroupActions = new TestGroupActions();
                testGroupViewModel = testGroupActions.ProcessAddTestGroup();
            }
            catch (Exception ex)
            {
                var message = $"An exception occurred while inserting the test group.";
                testGroupViewModel.ErrorMessage = message;
                if (log.IsErrorEnabled)
                {
                    log.Error(message, ex);
                }
            }
            return View("AddTestGroup", testGroupViewModel);
        }

        public ActionResult New([Bind(Prefix = "TestGroupDao")]TestGroupDao testGroupDao)
        {
            if (log.IsInfoEnabled) log.Info($"Calling New with TestGroupDao: {testGroupDao}.");

            TestGroupViewModel testGroupViewModel = new TestGroupViewModel();

            try
            {
                if (ModelState.IsValid)
                {
                    TestGroupActions testGroupActions = new TestGroupActions();
                    testGroupViewModel = testGroupActions.ProcessNew(testGroupDao);

                    return RedirectToAction("Index", new RouteValueDictionary(new { controller = "Testgroup", action = "Index" }));
                }
                else
                {
                    var errors = ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .Select(x => new { x.Key, x.Value.Errors })
                        .ToArray();
                    testGroupViewModel.ErrorMessage = "Invalid Entries, Kindly Recheck.";
                    testGroupViewModel.TestGroupDao = testGroupDao;
                    return View("AddTestGroup", testGroupViewModel);
                }
            }
            catch (Exception ex)
            {
                var message = $"An exception occurred while creating the test group.";
                testGroupViewModel.ErrorMessage = message;
                if (log.IsErrorEnabled)
                {
                    log.Error(message, ex);
                }
            }

            return View("Index");
        }

        public ActionResult DoSearch(TestGroupSearchDto searchDto, int? pageNumber)
        {
            if (log.IsInfoEnabled) log.Info($"Calling DoSearch with searchDto: {searchDto.ToString()} and pageNumber: {pageNumber}.");
            
            TestGroupSearchViewModel testGroupSearchViewModel = new TestGroupSearchViewModel();             

            try
            {
                TestGroupActions testGroupActions = new TestGroupActions();
                List<TestGroupDao> testGroupDaos = new List<TestGroupDao>();
                testGroupSearchViewModel = testGroupActions.ProcessDoSearch(searchDto, pageNumber);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    var message = $"An exception occurred while retrieving the transform statuses.";
                    log.Error(message, ex);
                }
            }

        return PartialView("Search", testGroupSearchViewModel);
    }

        public ActionResult Cims(int id)
        {
            if (log.IsInfoEnabled) log.Info($"Calling Cims.");

            var viewModel = new CimFileViewModel();

            try
            {
                viewModel.GetTestCims(id);
            }
            catch (Exception ex)
            {
                var message = $"An exception occurred while retrieving test files.";
                viewModel.ErrorMessage = message;
                if (log.IsErrorEnabled)
                {
                    log.Error(message, ex);
                }
            }

            //if the test group does requested does not exist then return 404
            if (viewModel.CurrentTestGroup == null)
                return new HttpNotFoundResult();

            return View(viewModel);
        }

        public ActionResult FileDetail(int id)
        {
            if (log.IsInfoEnabled) log.Info($"Calling FileDetail.");

            var viewModel = new FileDetailViewModel();

            try
            {
                viewModel.GetTestFile(id);
                viewModel.GetTestGroup(viewModel.TestFile.TestGroupId);
            }
            catch (Exception ex)
            {
                var message = $"An exception occurred while retrieving test files.";
                viewModel.ErrorMessage = message;
                if (log.IsErrorEnabled)
                {
                    log.Error(message, ex);
                }
            }

            return View(viewModel);
        }

        public ActionResult CreateCim(int id)
        {
            if (log.IsInfoEnabled) log.Info($"Calling CreateCim.");

            var viewModel = new CreateCimViewModel();
            try
            {
                viewModel.GetTestGroup(id);
            }
            catch (Exception ex)
            {
                var message = $"An exception occurred while trying to create the cim file.";
                viewModel.ErrorMessage = message;
                if (log.IsErrorEnabled)
                {
                    log.Error(message, ex);
                }
            }

            return View(viewModel);
        }
        public ActionResult AddCim(CreateCimFileModel model)
        {
            if (log.IsInfoEnabled) log.Info($"Calling AddCim.");
            var viewModel = new CreateCimViewModel();

            try
            {
                model.Creator = User.Identity.Name;
                model.FileName = "FileName";
                viewModel.AddCim(model);
            }
            catch (Exception ex)
            {
                var message = $"An exception occurred while trying to create the cim file.";
                viewModel.ErrorMessage = message;
                if (log.IsErrorEnabled)
                {
                    log.Error(message, ex);
                }

                //TODO: come back to this
                return View(nameof(CreateCim), model);
            }

            return RedirectToAction("1");

        }
    }
}