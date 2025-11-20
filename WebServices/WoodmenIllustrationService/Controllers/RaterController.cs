using log4net;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WOW.WoodmenIllustrationService.Code;
using WOW.WoodmenIllustrationService.SharedModels;

namespace WOW.WoodmenIllustrationService.Controllers
{
    public class RaterController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(RaterController));

        [HttpPost]
        [ActionName("FetchRate")]
        public RaterResponse FetchRate(RaterRequest raterRequest)
        {
            if (log.IsInfoEnabled) { log.InfoFormat("Receiving Rate Request client. Source IP Address: {0}.", Request.GetClientIpAddress()); }

            // This request object's ToString method returns the object in JSON format for easy logging.
            if (log.IsInfoEnabled) { log.InfoFormat("RateRequest: {0}.", raterRequest); }

            try
            {
                // Pass rater request into parser
                var wowPolicy = RaterUtilities.Parser.Parse(raterRequest);

                // Create client object
                var client = new LifePortraitsAccelerateClient();

                // Request Illustration
                var wowResponse = client.FetchIllustration(wowPolicy, null);

                // Extract rater response values from WIS response
                var raterResponse = RaterUtilities.Parser.ExtractValues(wowResponse);

                return raterResponse;
            }
            catch (Exception ex)
            {
                log.Error("The was an error fetching rates.", ex);

                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                throw new HttpResponseException(errorResponse);
            }
        }

        /// <summary>
        /// This method accepts a POSTed FIP file, parses the FIP file to a Woodmen Illustration Request Model and sends it to the backend illustration system.
        /// </summary>
        /// <returns>A Woodmen Illustration Response Model</returns>
        [HttpPost]
        [ActionName("FetchRateViaJson")]
        [ValidateMimeMultipartContentFilterAttribute]
        public Task<RaterResponse> FetchRateViaJson()
        {
            if (Request.Content.IsMimeMultipartContent())
            {
                if (log.IsInfoEnabled) { log.InfoFormat("Receiving JSON file upload from client. Source IP Address: {0}.", Request.GetClientIpAddress()); }

                try
                {
                    string uploadRoot = ServiceHelper.GetUploadDirectoryPath();

                    var provider = new MultipartFormDataStreamProvider(uploadRoot);
                    var task = Request.Content.ReadAsMultipartAsync(provider).ContinueWith<RaterResponse>(t =>
                    {
                        if (t.IsFaulted || t.IsCanceled)
                        {
                            log.Error("ReadAsMultipartAsync Task in FetchRateViaJson is faulted or cancelled.");
                            throw new HttpResponseException(HttpStatusCode.InternalServerError);
                        }

                        // Read uploaded file into a string
                        string fipRequest;
                        string fipUploadFileName = provider.FileData.First().LocalFileName;

                        // Expecting FIP files to contain one request per upload
                        using (var streamReader = new StreamReader(fipUploadFileName))
                        {
                            fipRequest = streamReader.ReadToEnd();
                        }

                        var jsonRequest = JsonConvert.DeserializeObject<RaterRequest>(fipRequest);

                        return FetchRate(jsonRequest);
                    });

                    return task;
                }
                catch (Exception ex)
                {
                    log.Error("Error processing Fetch Rate via JSON request.", ex);

                    var errorResponse = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                    throw new HttpResponseException(errorResponse);
                }
            }
            else
            {
                log.Error("Invalid Fetch Rate via JSON request received. Request must be in a multipart/form-data request.");

                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Request must be a multipart/form-data request and contain one file.");
                throw new HttpResponseException(errorResponse);
            }
        }
    }
}
