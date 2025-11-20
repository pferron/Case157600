using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using WebServiceTestManager.Exceptions;
using WebServiceTestManager.Models;
using WebServiceTestManager.Properties;

namespace WebServiceTestManager.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// The entry point of application, where the tests actually happen
        /// </summary>
        /// <returns>The main view</returns>
        public ActionResult Index()
        {
            //turn all test sets into a list and feed it to the view.
            using (var context = new Database())
            {
                var model = new List<TestSetModel>();

                var currentUser = GetUser();

                //var results = context.FetchTestSetsByUser(currentUser.Id);

               var results = context.TestSets.ToList();

                foreach(var item in results)
                {
                    //item.
                    model.Add(new TestSetModel() { Id = item.Id, Name = item.Name });
                }

                if (Request.IsAjaxRequest())
                    return PartialView(model);

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult EditTestSet(TestSetModel testset)
        {
            try
            {
                using (var context = new Database())
                {
                    var set = context.TestSets.Find(testset.Id);

                    if (set == null)
                        return Json(0);

                    set.Name = testset.Name;
                    context.SaveChanges();

                    return Json(1);
                }
            }
            catch (Exception)
            {
                return Json(0);
                throw;
            }
        }

        #region Test Files (Raters)

        /// <summary>
        /// Creates a new rater to be tested
        /// </summary>
        /// <param name="MobileRaterFile">The uploaded file</param>
        /// <returns>Main page if no errors</returns>
        [HttpPost]
        public ActionResult CreateRater(RaterModel rater)
        {
            string filePath = Server.MapPath(Settings.Default.FileUploadLocation);
           
            //check if the file isn't null
            if (rater != null && rater.File != null)
            {
                //verify directory
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                try
                {
                    //create a file id and then save it to the fs
                    Guid fileID = Guid.NewGuid();
                    rater.File.SaveAs(filePath + fileID.ToString() + Path.GetExtension(rater.File.FileName));

                    using (var context = new Database())
                    {
                        //create a file based on the db's format.
                        var file = new Models.File
                        {
                            Id = fileID,
                            Name = rater.FileName,
                            DateCreated = DateTime.Now,
                            DateModified = DateTime.Now,
                            TestSetId = rater.TestSetId,
                        };
                        context.Files.Add(file);

                        //add each of the expected values (list) to the db
                        foreach (var item in rater.Expected)
                        {
                            Guid expectedID = Guid.NewGuid();
                            var expectedResult = new ExpectedValue
                            {
                                Id = expectedID,
                                PropertyName = item.PropertyName,
                                ExpectedResult = item.ExpectedValue,
                                FileId = fileID,
                                Type = item.Type
                            };

                            context.ExpectedValues.Add(expectedResult);
                        }

                        context.SaveChanges();

                    }

                    //If we want to add another save the results and return to the page.
                    if(rater.AddAnother == true)
                    {
                        return RedirectToAction("Create", new { @model = (int)ModifierType.File, @actionName = "CreateRater", @testSet = rater.TestSetId });
                    }
                }
                
                catch (Exception)
                { 
                }

            }
            else
            {
                return View("a", rater);    
            }
            
            return RedirectToAction("ViewTest", new { @id = rater.TestSetId});
        }

        /// <summary>
        /// The method that executes a test
        /// </summary>
        /// <param name="testSetID">The id that will be tested</param>
        /// <returns>A Json result that is a not used</returns>
        public ActionResult EvaluateTest(int testSetId, int destinationId)
        {
            Directory.CreateDirectory(Server.MapPath(Settings.Default.CheckFolderPath));

            //dispose of stream to release use of file so that the TestService can delete it.
            System.IO.File.Create(Path.Combine(Server.MapPath(Settings.Default.CheckFolderPath), $"{testSetId} {destinationId}")).Dispose();
            return RedirectToAction("TestExecution");
        }

        public ActionResult UpdateFile(FileEditModel fileEditModel)
        {
            try
            {
                int? testSetId = 0;
                using (var context = new Database())
                {
                    var file = context.Files.Find(fileEditModel.FileId);
                    context.Files.Attach(file);
                    testSetId = file.TestSetId;
                    file.Name = fileEditModel.FileName;
                    file.DateModified = DateTime.Now;

                    foreach (var item in fileEditModel.ExpectedResults)
                    {
                        var expectedResult = context.ExpectedValues.Find(item.Id);

                        if (expectedResult == null)
                        {
                            Guid expectedID = Guid.NewGuid();
                            var newExpected = new ExpectedValue
                            {
                                Id = expectedID,
                                PropertyName = item.PropertyName,
                                ExpectedResult = item.ExpectedValue,
                                FileId = fileEditModel.FileId,
                                Type = item.Type
                            };

                            context.ExpectedValues.Add(newExpected);
                        }
                        else
                        {
                            expectedResult.PropertyName = item.PropertyName;
                            expectedResult.ExpectedResult = item.ExpectedValue;
                        }
                    }
                    context.SaveChanges();
                }

                if (fileEditModel.File != null)
                {
                    string filePath = Server.MapPath(Settings.Default.FileUploadLocation);
                    System.IO.File.Delete(Directory.GetFiles(filePath, fileEditModel.FileId.ToString() + ".*").First());
                    fileEditModel.File.SaveAs(filePath + fileEditModel.FileId.ToString() +
                        Path.GetExtension(fileEditModel.File.FileName));

                }

                return RedirectToAction("ViewTest", new { @id = testSetId });
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Destination

        /// <summary>
        /// The Destination view
        /// </summary>
        /// <returns>A list of all destinations presented in a friendly view</returns>
        public ActionResult Destination()
        {
            using (var context = new Database())
            {
                var model = new List<Destination>();

                var currentUser = GetUser();

                var results = context.FetchDestinationsByUser(currentUser.Id);

                foreach (var item in results)
                {
                    //model.Add(new Destination() { Id = item.DestinationId, Name = item.DestinationName, Url = item.DestinationUrl});
                }
                return View(model);
            }  
        }

        /// <summary>
        /// Create a new destination based on the destination model..
        /// </summary>
        /// <param name="destination"></param>
        /// <returns>The destination view or the create destination view if it is null.</returns>
        [HttpPost]
        public ActionResult CreateDestination(Destination destination)
        {
            if(ModelState.IsValid)
            {
                //create a new db context
                using (var context = new Database())
                {
                    //use the destination that we got
                    var newDestination = new Destination()
                    {
                        Name = destination.Name,
                        Url = destination.Url
                    };

                    context.Destinations.Add(newDestination);
                    context.SaveChanges();
                    //context.UserDestinations.Add(new UserDestination { UserId = GetUser().Id, DestinationId = newDestination.Id });
                    context.SaveChanges();

                }
            }
            else
            {
                return View(destination);
            }

            return RedirectToAction("Destination");
        }

        /// <summary>
        /// Update a destinaiton
        /// </summary>
        /// <param name="destination">the model that we will use to update the db</param>
        /// <returns>The base destination view</returns>
        public ActionResult UpdateDestination(DestinationViewModel destination)
        {
            if (ModelState.IsValid)
            {
                //create a new db context
                using (var context = new Database())
                {
                    var update = context.Destinations.Find(destination.Id);
                    context.Entry(update).CurrentValues.SetValues(destination);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Destination");
        }
        #endregion

        #region Create, Edit, and View

        /// <summary>
        /// The generic create page
        /// </summary>
        /// <param name="model">The model that we will use to populate the page</param>
        /// <param name="actionName">The endpoint we will post to on submit</param>
        /// <returns>A view with the data based on a model</returns>
        public ActionResult Create(int model, string actionName)
        {
            try
            {
                int.TryParse(Request["testSet"], out int testSetId);
                var factory = ModifierFactory.GetModifyModel((ModifierType)model, testSetId == 0 ? 0 : testSetId, GetUser());
                ViewData["ActionName"] = actionName;
                return View(factory.GetEmptyModel());
            }
            catch (Exception)
            {
                return RedirectToAction("index");
            }
        }

        /// <summary>
        /// Edit a given resouce
        /// </summary>
        /// <param name="model">The model to edit based off of <see cref="ModifierType"/></param>
        /// <param name="id">The id of the item</param>
        /// <param name="actionName">The endpoint to post back to</param>
        /// <returns>An edit view with the correct values based on id</returns>
        public ActionResult Edit(int model, int id, string actionName)
        {
            try
            {
                var factory = ModifierFactory.GetModifyModel((ModifierType)model, id, GetUser());
                ViewData["ActionName"] = actionName;
                return View(factory.GetModel());
            }
            catch (Exception)
            {
                return RedirectToAction("index");
            }

        }
        
        /// <summary>
        /// Provides an edit for items with a guid id vs int id
        /// </summary>
        /// <param name="model">The string name of the model</param>
        /// <param name="id">The guid id</param>
        /// <param name="actionName">The actionname of the results that you want to be posted.</param>
        /// <returns>Edit view with the model from the id param</returns>
        [ActionName("EditGuid")]
        public ActionResult Edit(int model, Guid id, string actionName)
        {
            try
            {
                var editFactory = ModifierFactory.GetModifyModel((ModifierType)model, id);
                ViewBag.message = model;
                ViewData["ActionName"] = actionName;
                return View("Edit" ,editFactory.GetModel());
            }
            catch (Exception)
            {
                return RedirectToAction("index");
            }
        }

        public ActionResult ViewDetail(int detailType, int id)
        {
            try
            {
                var detailFactory = DetailViewFactory.GetDetailView((DetailType)detailType, id);
                return View(detailFactory.Model);
            }
            catch (Exception)
            {
                return RedirectToAction("index");
            }
        }

        /// <summary>
        /// View the detail of an Item by guid
        /// </summary>
        /// <param name="id">The item's id that we will view</param>
        /// <returns>A view that has a model populated with data based on the id</returns>
        [ActionName("ViewDetailGuid")]
        public ActionResult ViewDetail(int detailType, Guid id)
        {
            try
            {
                var detailFactory = DetailViewFactory.GetDetailView((DetailType)detailType, id);
                return View("ViewDetail",detailFactory.Model);
            }
            catch (Exception)
            { 
                return RedirectToAction("index");
            }
        }

        public JsonResult Remove(int modifierType, int id)
        {
            var removableFactory = ModifierFactory.GetRemovable((ModifierType)modifierType, id, GetUser());

            if (removableFactory.Remove())
            {
                return Json("OK");
            }
            return Json("Fail");
        }

        [ActionName("RemoveGuid")]
        public JsonResult Remove(int modifierType, Guid id)
        {
            var removableFactory = ModifierFactory.GetRemovable((ModifierType)modifierType, id);

            if(removableFactory.Remove())
            {
                return Json("OK");
            }
            return Json("Fail");
        }
        #endregion

        #region Test Set
        /// <summary>
        /// View a given test set based on ID
        /// </summary>
        /// <param name="id">The id of the test set</param>
        /// <returns>A ViewTest view with files based on id of test set</returns>
        public ActionResult ViewTest(int id)
        {
            
            using (var context = new Database())
            {
                var testSet = context.TestSets.Find(id);
                var currentUser = GetUser();

                if (context.UserTestSets.Where(uts => uts.UserId == currentUser.Id && uts.TestSetId == testSet.Id).ToList().Count == 0)
                    return RedirectToAction("index");

                return View(context.Files.Where(f => f.TestSetId == id).ToList());
            }
        }

        /// <summary>
        /// Create a test set endpoint
        /// </summary>
        /// <param name="testSet">The test set information from posted <seealso cref="Create(string, string)"/> </param>
        /// <returns>The main test set view.</returns>
        public ActionResult CreateTestSet(TestSetModel testSet)
        {
            if (!string.IsNullOrEmpty(testSet.Name))
            {
                using (var context = new Database())
                {
                    var newTestSet = new TestSet { Name = testSet.Name };
                    context.TestSets.Add(newTestSet);
                    context.SaveChanges();

                    context.UserTestSets.Add(new UserTestSet { TestSetId = newTestSet.Id, UserId = GetUser().Id });
                    context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult UpdateTestSet(TestSetModel testSet)
        {
            //create a new db context
            using (var context = new Database())
            {
                var update = context.TestSets.Find(testSet.Id);
                context.TestSets.Attach(update);
                update.Name = testSet.Name;
                context.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        #endregion

        public ActionResult TestExecution()
        {
            using (var context = new Database())
            {
                //return View(context.TestExecutions.ToList());
                var list = new List<TestExecution>();
                list = context.TestExecutions.ToList();
                var a = list.GroupBy(te => te.TestIdentifier).Select(g => g.Distinct());
                var b = new List<TestExecutionModel>();
                foreach (var item in a)
                {
                    b.Add(new TestExecutionModel()
                    {
                        Name = $"{item.First().TestSetName}",
                        Url = item.First().DestinationUrl,
                        ExecutionDate = item.First().ExecutionDate,
                        TestIdentifier = item.First().TestIdentifier,
                        DestinationName = $"{item.First().DestinationName}"
                    });
                }
                return View(b);
            }

        }

        public ActionResult ViewExecution(Guid id)
        {
            using (var context = new Database())
            {
                return View(context.TestExecutions.Where(te => te.TestIdentifier == id).ToList());
            }
        }

        public JsonResult DeleteExecution(Guid id)
        {
            try
            {
                //use the context to find a db
                using (var context = new Database())
                {
                    //get the test
                    var executions = context.TestExecutions.Where(te => te.TestIdentifier == id).ToList();

                    foreach (var item in executions)
                    {
                        context.TestExecutions.Remove(item);
                    }
                    context.SaveChanges();
                }
                return Json("OK");
            }
            catch (Exception)
            {
                return Json("Error, the item you are trying to delete may already be assigned to a test.");
            }
        }

        /// <summary>
        /// Get a userid or create a user based on the windows user name <seealso cref="User.Identity.Name"/>
        /// </summary>
        /// <returns>A user object</returns>
        public User GetUser()
        {
            using (var context = new Database())
            {
                //Text doesn't support compare.. (https://stackoverflow.com/a/37785787)
                var user = context.Users.Where(u => u.WindowsUsername.Contains(User.Identity.Name)).FirstOrDefault();

                if (user == null)
                {
                    user = context.Users.Add(new Models.User { WindowsUsername = User.Identity.Name });
                }
                return user;
            }
        }
    }

}