using System.Web.Mvc;

namespace WOW.WoodmenIllustrationService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Woodmen Illustration Service";

            // Use existing API code for checking on database.
            var api = new ServiceController();

            return View(api.DatabaseCheck());
        }
    }
}
