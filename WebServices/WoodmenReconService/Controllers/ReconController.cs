using log4net;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WOW.WoodmenReconService.Code;
using WOW.WoodmenReconService.Models;

namespace WOW.WoodmenReconService.Controllers
{
    public class ReconController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ReconController));


        [ActionName("SubmitReport")]
        [HttpPost]
        [CheckModelForNull]
        [ValidateModelState]
        public void SubmitReport(ReconReportRequest report)
        {
            try
            {
                using (var ef = new WoodmenReconServiceEntities())
                {
                    var model = new ReconReport();

                    model.DateReceived = DateTime.Now;
                    model.DateCreatedUtc = report.ReportCreateDateUtc;
                    model.Hostname = report.Hostname;
                    model.ReportName = report.ReportName;

                    if (report.DataItems != null)
                    {
                        model.ReconReportDataItems = new List<ReconReportDataItem>();

                        foreach (var item in report.DataItems)
                        {
                            model.ReconReportDataItems.Add(new ReconReportDataItem() { DataName = item.DataName, DataValue = item.DataValue });
                        }
                    }

                    ef.ReconReports.Add(model);
                    ef.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error("An error occurred submitting the report.", ex); }

                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                throw new HttpResponseException(errorResponse);
            }
        }

        [HttpGet]
        [ActionName("Heartbeat")]
        public ServiceStatus Heartbeat()
        {
            if (log.IsDebugEnabled) { log.Debug("Heartbeat requested."); }

            return new ServiceStatus { Result = "ONLINE", HasError = false };
        }

        [HttpGet]
        [ActionName("DatabaseCheck")]
        public ServiceStatus DatabaseCheck()
        {
            if (log.IsDebugEnabled) { log.Debug("DatabaseCheck requested."); }

            try
            {
                // Try to connect to database
                using (var ef = new WoodmenReconServiceEntities())
                {
                    ef.Database.Exists();

                    if (log.IsDebugEnabled) { log.Debug("Database is online."); }

                    return new ServiceStatus { Result = "ONLINE", HasError = false };
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error("DatabaseCheck: Error connecting to database.", ex); }

                return new ServiceStatus { Result = "OFFLINE", HasError = true };
            }
        }
    }
}
