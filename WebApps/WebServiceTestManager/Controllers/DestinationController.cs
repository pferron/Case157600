using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebServiceTestManager.Models;

namespace WebServiceTestManager.Controllers
{
    public class DestinationController : Controller
    {
        // GET: Destination
        public ActionResult Index()
        {
            using (var context = new Database())
            {
                var model = new List<Models.ViewModels.DestinationViewModel>();

                model = context.Destinations.ToList().Select(d => new Models.ViewModels.DestinationViewModel
                {
                    Id = d.DestinationId,
                    Name = d.Name,
                    Url = d.Url
                }).ToList();
                

                return View(model);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDestination(CreateDestinationModel model)
        {
            using (var context = new Database())
            {
                context.Destinations.Add(new Destination
                {
                    Name = model.Name,
                    Url = model.Url
                });
                context.SaveChanges();
            }
            return RedirectToAction("");
        }


        [HttpPost]
        public ActionResult EditDesination(CreateDestinationModel model)
        {
            using (var context = new Database())
            {
                var destination = context.Destinations.Find(model.Id);

                if(destination != null)
                {
                    destination.Name = model.Name;
                    destination.Url = model.Url;
                    context.SaveChanges();
                    return Json(1);
                }
            }
            return Json(0);
        }
    }
}