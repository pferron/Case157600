using log4net;
using LPA.Dashboard.Web.ActionCode;
using LPA.Dashboard.Web.Code;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace LPA.Dashboard.Web.Controllers
{
    [RoutePrefix("api")]
    public class VaServicesController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(VaServicesController));

        [HttpGet]
        [Route("ProcessRateData")]
        public IHttpActionResult ProcessRateData(string filePath)
        {
            if (log.IsInfoEnabled) log.Info($"API ProcessRateData called.");

            try
            {
                FileInfo fileInfo = new FileInfo(filePath);

                VaTestToolActions vaTestToolActions = new VaTestToolActions();

                vaTestToolActions.GenerateSql(fileInfo);

                IHttpActionResult response;
                HttpResponseMessage responseMsg = new HttpResponseMessage(HttpStatusCode.OK);
                responseMsg.Content = new StringContent("Successfully initiated to process excel file.");
                response = ResponseMessage(responseMsg);
                return response;
            }
            catch (Exception ex)
            {
                ILog logger = LogManager.GetLogger("EmailErrorLogger");
                if (logger.IsFatalEnabled) logger.Fatal($"Exception: {ex.Message}.", ex);

                //don't return our internal error message, create a new one to return
                HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                message.Content = new StringContent(ex.Message);
                throw new HttpResponseException(message);
            }
        }

        [HttpPost]
        [Route("UploadExcelFile")]
        public IHttpActionResult UploadExcelFile()
        {
            if (log.IsInfoEnabled) log.Info($"API UploadExcelFile called.");

            try
            {
                VaTestToolActions vaTestToolActions = new VaTestToolActions();
                vaTestToolActions.ProcessUploadExcel(Request.Content);

                IHttpActionResult response;
                HttpResponseMessage responseMsg = new HttpResponseMessage(HttpStatusCode.OK);
                responseMsg.Content = new StringContent("Successfully initiated Upload excel file.");
                response = ResponseMessage(responseMsg);
                return response;
            }
            catch (Exception ex)
            {
                ILog logger = LogManager.GetLogger("EmailErrorLogger");
                if (logger.IsFatalEnabled) logger.Fatal($"Exception: {ex.Message}.", ex);

                //don't return our internal error message, create a new one to return
                HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                message.Content = new StringContent(ex.Message);
                throw new HttpResponseException(message);
            }
        }
    }
}
