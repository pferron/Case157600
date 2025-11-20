using log4net;
using LPA.Dashboard.Web.ActionCode;
using LPA.Dashboard.Web.ViewModels;
using System;
using System.Web;
using System.Web.Mvc;

namespace LPA.Dashboard.Web.Controllers
{
    public class VaTestToolController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(VaTestToolController));

        public ActionResult Index()
        {
            if (log.IsInfoEnabled) log.Info($"Calling Index.");

            VaTestToolViewModel vaTestToolViewModel = new VaTestToolViewModel();

            try
            {
            }
            catch (Exception ex)
            {
                var message = $"An exception occurred while loading index page.";
                vaTestToolViewModel.ErrorMessage = message;
                if (log.IsErrorEnabled)
                {
                    log.Error(message, ex);
                }
            }

            return View(vaTestToolViewModel);
        }

        public ActionResult DisplayExcelFiles()
        {
            if (log.IsInfoEnabled) log.Info($"Calling Index.");

            DisplayExcelFilesViewModel displayExcelFilesViewModel = new DisplayExcelFilesViewModel();

            try
            {
                VaTestToolActions vaTestToolActions = new VaTestToolActions();
                displayExcelFilesViewModel = vaTestToolActions.ProcessDisplayExcelFiles();
            }
            catch (Exception ex)
            {
                var message = $"An exception occurred while loading index page.";
                displayExcelFilesViewModel.ErrorMessage = message;
                if (log.IsErrorEnabled)
                {
                    log.Error(message, ex);
                }
            }

            return PartialView("DisplayExcelFiles", displayExcelFilesViewModel);
        }
    }
}