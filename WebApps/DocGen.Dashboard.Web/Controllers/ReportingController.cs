using Highsoft.Web.Mvc.Charts;
using log4net;
using LPA.Dashboard.Models.View;
using LPA.Dashboard.Web.ActionCode;
using LPA.Dashboard.Web.Code;
using LPA.Dashboard.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LPA.Dashboard.Web.Controllers
{
    public class ReportingController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ReportingController));
        
        public ActionResult SalesLaptopUptake()
        {
            if (log.IsInfoEnabled) log.Info($"Calling SalesLaptopUptake Search.");

            SalesLaptopUptakeViewModel salesLaptopUptakeViewModel = new SalesLaptopUptakeViewModel();

            try
            {
                SalesLaptopUptakeActions salesLaptopUptakeActions = new SalesLaptopUptakeActions();
                salesLaptopUptakeViewModel = salesLaptopUptakeActions.ProcessSalesLaptopUptake();
            }
            catch (Exception ex)
            {
                var message = $"An exception occurred while retrieving laptopUptake information.";
                salesLaptopUptakeViewModel.ErrorMessage = message;

                if (log.IsErrorEnabled)
                {
                    log.Error(message, ex);
                }
            }
            
            return View(salesLaptopUptakeViewModel);
        }
    }
}