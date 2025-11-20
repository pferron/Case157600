using System.Web.Mvc;

namespace WOW.MobileRaterService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Mobile Rater Service";

            var api = new ServiceController();

            return View(api.DatabaseCheck());
        }
    }
}
