using LPA.Dashboard.Web.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LPA.Dashboard.Web.Controllers
{
    public class ImagesController : Controller
    {
        // GET: Images
        public ActionResult Index(long testResultId)
        {
            TestResultCimUtils testResultCimUtils = new TestResultCimUtils();
            byte[] imageData = testResultCimUtils.GetTestResultIllustration(testResultId);

            return File(imageData, "application/pdf");
        }
    }
}