using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebServiceTestManager.Models;

namespace WebServiceTestManager.Controllers
{
    [RoutePrefix("TestSet")]
    public class TestSetController : Controller
    {
        public ActionResult Index()
        {
            //using (var context = new Database())
            //{
            //    var testSet = context.TestSets.Find(id);
            //    //var currentUser = GetUser();

            //    //if (context.UserTestSets.Where(uts => uts.UserId == currentUser.Id && uts.TestSetId == testSet.Id).ToList().Count == 0)
            //    //    return RedirectToAction("index");

            //    return View(context.Files.Where(f => f.TestSetId == id).ToList());
            //}
            return View();
        }

        //[Route("View/{title}-{id}")]
        public ActionResult View(int id)//, string title)
        {
            using (var context = new Database())
            {
                var testSet = context.TestSets.Find(id);
                //var currentUser = GetUser();

                //if (context.UserTestSets.Where(uts => uts.UserId == currentUser.Id && uts.TestSetId == testSet.Id).ToList().Count == 0)
                //    return RedirectToAction("index");
                ViewBag.TestSetName = testSet.Name;

                return View("Index",context.Files.Where(f => f.TestSetId == id).ToList());
            }

        }

        [Route("Detail/{id}")]
        public ActionResult ViewDetail(Guid id)
        {
            using (var context = new Database())
            {
                var file = context.Files.Find(id);
                var testSet = file.TestSet;
                var expectedFiles = context.ExpectedValues.Where(e => e.FileId == file.Id).ToList();

                ViewBag.FileName = file.Name;
                ViewBag.TestName = testSet.Name;
                ViewBag.TestId = testSet.Id;
                
                var model = new FileDetailViewModel()
                {
                    FileName = file.Name,
                    Expected = expectedFiles
                };
                
            }

            return View();
        }

        [Route("Create/TestCase/{id}")]
        public ActionResult Create(int id)
        {
            using (var context = new Database())
            {
                var testSet = context.TestSets.Find(id);
                ViewBag.TestName = testSet.Name;
                ViewBag.TestId = testSet.Id;
            }
            return View();
        }
    }
}