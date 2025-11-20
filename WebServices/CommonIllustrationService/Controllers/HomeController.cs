using System.Web.Mvc;

namespace Wow.CommonIllustrationService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Woodmen Common Illustration Service";

            var api = new ServiceController();

            return View(api.Heartbeat());
        }
    }
}
