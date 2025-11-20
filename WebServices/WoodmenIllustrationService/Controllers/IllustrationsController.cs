using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using WoodmenLife.Enterprise.Illustration.Models.Titanium;
using log4net;
using Newtonsoft.Json;
using WOW.FipUtilities;
using WOW.Illustration.Model.Generation.Response;
using WOW.WoodmenIllustrationService.Builders;
using WOW.WoodmenIllustrationService.Code;
using WOW.WoodmenIllustrationService.Properties;
using WOW.WoodmenIllustrationService.SharedModels;

namespace WOW.WoodmenIllustrationService.Controllers
{
    public class IllustrationsController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(IllustrationsController));

        [HttpPost]
        [ActionName("ConvertFipFile")]
        [ValidateMimeMultipartContentFilter]
        public HttpResponseMessage ConvertFipFile()
        {
            if (log.IsInfoEnabled) log.InfoFormat("Receiving FIP file upload from client. Source IP Address: {0}.", Request.GetClientIpAddress());

            try
            {
                var fipRequest = HttpRequestParser.ExtractFile(Request);

                // Pass FIP file into parser
                var wowPolicy = FipParser.Parse(fipRequest);

                // For e-App integration support, I need to check the request for a custom header containing a username
                var username = HttpRequestParser.ExtractUserName(Request);

                var config = new ServiceRequestConfig();

                if (string.IsNullOrWhiteSpace(username))
                {
                    config.Username = Settings.Default.LpaBatchUsername;
                    config.Password = Settings.Default.LpaBatchPassword;
                }
                else
                {
                    config.Username = username;
                    config.Password = string.Empty;
                }

                config.DistributionChannel = Settings.Default.DistributionChannelName;

                // Create ACORD factory
                var factory = BaseAcordFactory.BuildFactory(wowPolicy);

                // Manufacture ACORD object
                var acordObject = factory.CreateLifeRequestModel(wowPolicy, config);

                var acordXml = ServiceHelper.SerializeAcordObject(acordObject);

                acordXml = acordXml.Replace("utf-16", "utf-8");

                // Create response and send to client
                var response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(acordXml, System.Text.Encoding.Default, "text/xml")
                };

                return response;
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Error converting FIP file to ACORD.", ex);

                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

                throw new HttpResponseException(errorResponse);
            }
        }

        [HttpPost]
        [ActionName("ConvertFipFileToWIM")]
        [ValidateMimeMultipartContentFilter]
        public HttpResponseMessage ConvertFipFileToWIM()
        {
            if (log.IsInfoEnabled) log.InfoFormat("Receiving FIP file upload from client. Source IP Address: {0}.", Request.GetClientIpAddress());

            try
            {
                var fipRequest = HttpRequestParser.ExtractFile(Request);

                // Pass FIP file into parser
                var wowPolicy = FipParser.Parse(fipRequest);

                // For e-App integration support, I need to check the request for a custom header containing a username
                var username = HttpRequestParser.ExtractUserName(Request);

                var config = new ServiceRequestConfig();

                if (string.IsNullOrWhiteSpace(username))
                {
                    config.Username = Settings.Default.LpaBatchUsername;
                    config.Password = Settings.Default.LpaBatchPassword;
                }
                else
                {
                    config.Username = username;
                    config.Password = string.Empty;
                }

                config.DistributionChannel = Settings.Default.DistributionChannelName;

                // Serialize response
                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                };

                var modelString = JsonConvert.SerializeObject(wowPolicy, settings);

                // Create response and send to client
                var response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(modelString, System.Text.Encoding.Default, "application/json")
                };

                return response;
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Error converting FIP file to WIM.", ex);

                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

                throw new HttpResponseException(errorResponse);
            }
        }

        /// <summary>
        /// This method accepts a POSTed ACORD XML file and sends it to the backend illustration system.
        /// </summary>
        /// <returns>ACORD TX111 Life Response</returns>
        [HttpPost]
        [ActionName("GenerateIllustrationViaAcord")]
        [ValidateMimeMultipartContentFilter]
        public HttpResponseMessage GenerateIllustrationViaAcord()
        {
            if (log.IsInfoEnabled) { log.InfoFormat("Receiving ACORD file upload from client. Source IP Address: {0}.", Request.GetClientIpAddress()); }

            try
            {
                var acordString = HttpRequestParser.ExtractFile(Request);

                // Create client object
                var client = new LifePortraitsAccelerateClient();

                // Send XML string to server
                var acordResponseObject = client.FetchIllustration(acordString);

                var acordXml = ServiceHelper.SerializeAcordObject(acordResponseObject);

                acordXml = acordXml.Replace("utf-16", "utf-8");

                // Create response and send to client
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(acordXml, System.Text.Encoding.Default, "text/xml")
                };

                return response;
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Error processing ACORD illustration request.", ex);

                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

                throw new HttpResponseException(errorResponse);
            }
        }

        /// <summary>
        /// This method accepts a POSTed FIP file, parses the FIP file to a Woodmen Illustration Request Model and sends it to the backend illustration system.
        /// </summary>
        /// <returns>A Woodmen Illustration Response Model</returns>
        [HttpPost]
        [ActionName("GenerateIllustrationViaFip")]
        [ValidateMimeMultipartContentFilter]
        public WoodmenIllustrationResponse GenerateIllustrationViaFip()
        {
            if (log.IsInfoEnabled) log.InfoFormat("Receiving FIP file upload from client. Source IP Address: {0}.", Request.GetClientIpAddress());

            try
            {
                var fipRequest = HttpRequestParser.ExtractFile(Request);

                // Pass FIP file into parser
                var wowPolicy = FipParser.Parse(fipRequest);

                // Log FIP file path with certificate number
                if (log.IsDebugEnabled) log.DebugFormat("FIP file was successfully parsed for certificate '{0}'.", wowPolicy.PolicyNumber);

                // For e-App integration support, I need to check the request for a custom header containing a username
                string username = HttpRequestParser.ExtractUserName(Request);

                // Create client object
                var client = new LifePortraitsAccelerateClient();

                return client.FetchIllustration(wowPolicy, username);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Error processing FIP illustration request.", ex);

                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

                throw new HttpResponseException(errorResponse);
            }
        }

        internal WoodmenIllustrationResponse GenerateIllustration(Illustration.Model.Generation.Request.Policy policy, string username)
        {
            if (log.IsInfoEnabled) { log.Info($"GenerateIllustration called with policy class and username: {username}."); }

            try
            {
                // Create client object
                var client = new LifePortraitsAccelerateClient();

                // Create new Woodmen Illustration Response from TXLife object
                var wowResponse = client.FetchIllustration(policy, username);

                return wowResponse;
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Error fetching the illustration request.", ex);

                throw;
            }
        }

        [HttpPost]
        [ActionName("FetchIllustrationPdf")]
        [ValidateMimeMultipartContentFilter]
        public HttpResponseMessage FetchIllustrationPdf()
        {
            try
            {
                var illustrationResponse = GenerateIllustrationViaFip();

                MemoryStream ms = new MemoryStream(Convert.FromBase64String(illustrationResponse.PdfFileAttachment));

                var response = new HttpResponseMessage { Content = new StreamContent(ms) };

                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

                return response;
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Error fetching Illustration PDF.", ex);

                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

                throw new HttpResponseException(errorResponse);
            }
        }

        [HttpPost]
        [ActionName("FetchIllustrationValues")]
        [ValidateMimeMultipartContentFilter]
        public HttpResponseMessage FetchIllustrationValues()
        {
            try
            {
                var illustrationResponse = GenerateIllustrationViaFip();

                MemoryStream ms = new MemoryStream(Convert.FromBase64String(illustrationResponse.ValuesFileAttachment));

                var response = new HttpResponseMessage { Content = new StreamContent(ms) };

                response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");

                return response;
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Error fetching Illustration PDF.", ex);

                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

                throw new HttpResponseException(errorResponse);
            }
        }

        [HttpPost]
        [ActionName("FetchIllustrationPdfViaWIM")]
        public HttpResponseMessage FetchIllustrationPdfViaWIM(Illustration.Model.Generation.Request.Policy policy)
        {
            try
            {
                var username = HttpRequestParser.ExtractUserName(Request);

                var illustrationResponse = GenerateIllustration(policy, username);

                MemoryStream ms = new MemoryStream(Convert.FromBase64String(illustrationResponse.PdfFileAttachment));

                var response = new HttpResponseMessage { Content = new StreamContent(ms) };

                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

                return response;
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Error fetching Illustration PDF.", ex);

                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

                throw new HttpResponseException(errorResponse);
            }
        }

        [HttpPost]
        [ActionName("FetchIllustrationValuesviaWIM")]
        public HttpResponseMessage FetchIllustrationValuesviaWIM(Illustration.Model.Generation.Request.Policy policy)
        {
            try
            {
                var username = HttpRequestParser.ExtractUserName(Request);

                var illustrationResponse = GenerateIllustration(policy, username);

                MemoryStream ms = new MemoryStream(Convert.FromBase64String(illustrationResponse.ValuesFileAttachment));

                var response = new HttpResponseMessage { Content = new StreamContent(ms) };

                response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");

                return response;
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Error fetching Illustration PDF.", ex);

                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

                throw new HttpResponseException(errorResponse);
            }
        }

        [HttpPost]
        [ActionName("FetchIllustrationPdfViaAcord")]
        [ValidateMimeMultipartContentFilter]
        public HttpResponseMessage FetchIllustrationPdfViaAcord()
        {
            if (log.IsInfoEnabled) { log.InfoFormat("Receiving ACORD file upload from client. Source IP Address: {0}.", Request.GetClientIpAddress()); }

            try
            {
                var acordString = HttpRequestParser.ExtractFile(Request);

                // Create client object
                var client = new LifePortraitsAccelerateClient();

                // Send XML string to server
                var acordResponseObject = client.FetchIllustration(acordString);

                // Build Woodmen Response Model
                var woodmenResponse = WoodmenIllustrationResponseBuilder.BuildFromTXLife(acordResponseObject);

                // Convert Base64 string to stream
                MemoryStream ms = new MemoryStream(Convert.FromBase64String(woodmenResponse.PdfFileAttachment));

                // Create PDF response and return to client
                var response = new HttpResponseMessage { Content = new StreamContent(ms) };

                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

                return response;
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Error processing ACORD illustration request.", ex);

                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

                throw new HttpResponseException(errorResponse);
            }
        }

        [HttpPost]
        [ActionName("FetchIllustrationValuesViaAcord")]
        [ValidateMimeMultipartContentFilter]
        public HttpResponseMessage FetchIllustrationValuesViaAcord()
        {
            if (log.IsInfoEnabled) { log.InfoFormat("Receiving ACORD file upload from client. Source IP Address: {0}.", Request.GetClientIpAddress()); }

            try
            {
                var acordString = HttpRequestParser.ExtractFile(Request);

                // Create client object
                var client = new LifePortraitsAccelerateClient();

                // Send XML string to server
                var acordResponseObject = client.FetchIllustration(acordString);

                var woodmenResponse = WoodmenIllustrationResponseBuilder.BuildFromTXLife(acordResponseObject);

                MemoryStream ms = new MemoryStream(Convert.FromBase64String(woodmenResponse.ValuesFileAttachment));

                var response = new HttpResponseMessage { Content = new StreamContent(ms) };

                response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");

                return response;
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Error processing ACORD illustration request.", ex);

                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

                throw new HttpResponseException(errorResponse);
            }
        }

        [HttpPost]
        [ActionName("GenerateIllustration")]
        public WoodmenIllustrationResponse GenerateIllustration()
        {
            if (log.IsInfoEnabled) { log.InfoFormat("GenerateIllustration called. Receiving Policy file upload from client. Source IP Address: {0}.", Request.GetClientIpAddress()); }

            try
            {
                var username = HttpRequestParser.ExtractUserName(Request);

                var task = Task.Run(async () => await Request.Content.ReadAsStringAsync());

                task.Wait();

                var stringJson = task.Result;

                if (log.IsDebugEnabled) { log.Debug(stringJson); }

                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                };

                var policy = JsonConvert.DeserializeObject<WOW.Illustration.Model.Generation.Request.Policy>(stringJson, settings);

                return GenerateIllustration(policy, username);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Error processing illustration request.", ex);

                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

                throw new HttpResponseException(errorResponse);
            }
        }

        [HttpGet]
        [ActionName("TestHeartbeat")]
        public bool TestHeartbeat()
        {
            if (log.IsInfoEnabled) log.Info($"Illustrations TestHeartbeat called by {Request.GetClientIpAddress()}.");

            return true;
        }

        [HttpPost]
        [ActionName("FetchIllustrationPdfViaPolicyDetails")]
        public async Task<HttpResponseMessage> FetchIllustrationPdfViaPolicyDetails()
        {
            if (log.IsInfoEnabled) { log.InfoFormat("FetchIllustrationPdfViaPolicyDetails called. Source IP Address: {0}.", Request.GetClientIpAddress()); }

            try
            {
                var requestJson = await Request.Content.ReadAsStringAsync();

                var tiPolicyDetail = JsonConvert.DeserializeObject<TiPolicyDetail>(requestJson);

                // Manufacture WIM object
                var wimObject = ConverterFactory.CreaterConverter(tiPolicyDetail);

                var wimjson = JsonConvert.SerializeObject(wimObject, Formatting.Indented);

                wimObject.RequestId = tiPolicyDetail.RequestGuid.ToString();

                var wimResponse = GenerateIllustration(wimObject, "");

                if (wimResponse.HasError)
                {
                    throw new Exception(wimResponse.ErrorMessage);
                }
                else
                {
                    if (wimResponse.HasPdfFile)
                    {
                        var response = new HttpResponseMessage { Content = new StreamContent(new MemoryStream(Convert.FromBase64String(wimResponse.PdfFileAttachment))) };

                        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

                        return response;
                    }
                    else
                    {
                        throw new Exception("No Error Message or PDF returned.");
                    }
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Error fetching illustration pdf via policy details.", ex);

                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

                throw new HttpResponseException(errorResponse);
            }
        }
    }
}