using log4net;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Hosting;
using System.Web.Http;
using WOW.WoodmenIllustrationService.Properties;

namespace WOW.WoodmenIllustrationService.Controllers
{
    public class PayloadController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(PayloadController));

        [HttpGet]
        [ActionName("GetWimByRequestId")]
        public HttpResponseMessage GetWimByRequestId(string requestId)
        {
            if (log.IsInfoEnabled) { log.InfoFormat("GetWimByRequestId called. Request Id: {0}.", requestId); }

            try
            {
                string payloadStorageFolderPath;

                if (Settings.Default.PayloadStorageFolder.Contains("~"))
                {
                    // This path needs to be mapped to the file system
                    payloadStorageFolderPath = HostingEnvironment.MapPath(Settings.Default.PayloadStorageFolder); // web service folder e.g. ~/App_Data/uploads
                }
                else
                {
                    payloadStorageFolderPath = Settings.Default.PayloadStorageFolder;
                }

                //REQUEST-WOW_9c9838fc171b4f8ea78bb2c41c024227.payload
                string payloadFile = Path.Combine(payloadStorageFolderPath, string.Format("REQUEST-WOW_{0}.{1}", requestId.ToLower(),Settings.Default.PayloadFileExtension));

                if (File.Exists(payloadFile))
                {
                    var stream = new MemoryStream(File.ReadAllBytes(payloadFile));
                    
                    var response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StreamContent(stream);

                    return response;
                }
                else
                {
                    throw new Exception(string.Format("WIM file not found: {0}",payloadFile));
                }                
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Error fetching WIM file.", ex);

                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

                throw new HttpResponseException(errorResponse);
            }
        }

        [HttpGet]
        [ActionName("GetAcordByRequestId")]
        public HttpResponseMessage GetAcordByRequestId(string requestId)
        {
            if (log.IsInfoEnabled) { log.InfoFormat("GetAcordByRequestId called. Request Id: {0}.", requestId); }

            try
            {
                string payloadStorageFolderPath;

                if (Settings.Default.PayloadStorageFolder.Contains("~"))
                {
                    // This path needs to be mapped to the file system
                    payloadStorageFolderPath = HostingEnvironment.MapPath(Settings.Default.PayloadStorageFolder); // web service folder e.g. ~/App_Data/uploads
                }
                else
                {
                    payloadStorageFolderPath = Settings.Default.PayloadStorageFolder;
                }

                //REQUEST-ACORD_9c9838fc171b4f8ea78bb2c41c024227.payload
                string payloadFile = Path.Combine(payloadStorageFolderPath, string.Format("REQUEST-ACORD_{0}.{1}", requestId.ToLower(), Settings.Default.PayloadFileExtension));

                if (File.Exists(payloadFile))
                {
                    var stream = new MemoryStream(File.ReadAllBytes(payloadFile));

                    var response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StreamContent(stream);
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/xml");

                    return response;
                }
                else
                {
                    throw new Exception(string.Format("Acord file not found: {0}", payloadFile));
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Error fetching Acord file.", ex);

                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

                throw new HttpResponseException(errorResponse);
            }
        }
    }
}
