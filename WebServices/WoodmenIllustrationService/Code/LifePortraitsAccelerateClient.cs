using log4net;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using WOW.Illustration.Model.ACORD;
using WOW.Illustration.Model.Generation.Response;
using WOW.WoodmenIllustrationService.Builders;
using WOW.WoodmenIllustrationService.Properties;
using WOW.WoodmenIllustrationService.SharedModels;

namespace WOW.WoodmenIllustrationService.Code
{
    /// <summary>
    /// LPA Gateway Service client for sending illustration requests.
    /// </summary>
    internal class LifePortraitsAccelerateClient
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(LifePortraitsAccelerateClient));

        /// <summary>
        /// Common method for creating ACORD factory & LifePortraits client and sending requests to LifePortraits.
        /// </summary>
        /// <param name="wowPolicy">WOW.Illustration.Model.Generation.Request.Policy</param>
        /// <returns>WOW.WoodmenIllustrationService.Models.WoodmenIllustrationResponse</returns>
        internal WoodmenIllustrationResponse FetchIllustration(Illustration.Model.Generation.Request.Policy wowPolicy, string username)
        {
            if (log.IsInfoEnabled) { log.Info($"FetchIllustration called with username: {username}."); }

            try
            {
                if (wowPolicy == null)
                {
                    throw new ArgumentNullException("wowPolicy", "The Woodmen Policy object cannot be null.");
                }

                // Create request configuration object
                // This object is used to set the batch username, password and distribution channel sent in the ACORD model.
                // e-App needs to override the username using the parameter above
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

                // This code won't work for e-App, so I'm moving it back to the RaterController
                // Check to see if an NLGUL request was submitted
                //var nlgPolicy = wowPolicy as NoLapseGuaranteedUniversalLifePolicy;

                //if (nlgPolicy != null && nlgPolicy.NLGInt == 0M)
                //{
                //    // If so, fetch the current rate and add it to the request
                //    nlgPolicy.NLGInt = LifePortraitsDAO.FetchCurrentNlgInterestRate();
                //}

                PayloadLoggerResponse requestPayload = null;
                JsonSerializerSettings settings = null;

                if (log.IsInfoEnabled) { log.Info($"LogWimMessages: {Settings.Default.LogWimMessages}."); }

                // Write serialized JSON request out to file system for logging.
                if (Settings.Default.LogWimMessages)
                {
                    settings = new JsonSerializerSettings();
                    settings.TypeNameHandling = TypeNameHandling.All;
                    var state = JsonConvert.SerializeObject(wowPolicy, Newtonsoft.Json.Formatting.Indented, settings);
                    requestPayload = LargePayloadLogger.LogPayloadToFile(state, "REQUEST-WOW",wowPolicy.RequestId);
                    if (log.IsDebugEnabled) log.DebugFormat("REQUEST-WOW - ACORD Request File: {0}, File ID: {1}", requestPayload.PayloadFilePath, requestPayload.PayloadFileId);
                }

                // Create ACORD factory
                var factory = BaseAcordFactory.BuildFactory(wowPolicy);

                // Manufacture ACORD object
                var acordRequestObject = factory.CreateLifeRequestModel(wowPolicy, config);

                // Log request XML
                var acordString = ServiceHelper.SerializeAcordObject(acordRequestObject);
                requestPayload = LargePayloadLogger.LogPayloadToFile(acordString, "REQUEST-ACORD", wowPolicy.RequestId);
                if (log.IsDebugEnabled) log.DebugFormat("REQUEST-ACORD - ACORD Request File: {0}, File ID: {1}", requestPayload.PayloadFilePath, requestPayload.PayloadFileId);

                // Create LPA client object
                var client = new LifePortraitsAccelerateClient();

                // Send XML object to server
                var acordResponseObject = client.FetchIllustration(acordRequestObject, wowPolicy.RequestId);

                // Create new Woodmen Illustration Response from TXLife object
                var wowResponse = WoodmenIllustrationResponseBuilder.BuildFromTXLife(acordResponseObject);
                wowResponse.RequestId = wowPolicy.RequestId;

                // Write serialized JSON response out to file system for logging.
                if (Settings.Default.LogWimMessages)
                {
                    var state = JsonConvert.SerializeObject(wowResponse, Newtonsoft.Json.Formatting.Indented, settings);
                    var responsePayload = LargePayloadLogger.LogPayloadToFile(state, "RESPONSE-WOW", wowPolicy.RequestId);
                    if (log.IsDebugEnabled) log.DebugFormat("RESPONSE-WOW - ACORD Response File: {0}, File ID: {1}", responsePayload.PayloadFilePath, responsePayload.PayloadFileId);
                }

                return wowResponse;
            }
            catch (Exception ex)
            {
                var message = "There was an error sending an Woodmen Policy request to LPA for processing.";
                if (log.IsErrorEnabled) { log.Error(message, ex); }
                throw new LpaClientException(message, ex);
            }
        }

        /// <summary>
        /// Sends an ACORD message to the LifePortraits Accelerate Gateway Service and deserializes the response.
        /// </summary>
        /// <param name="acordRequest">An ACORD TX111 request as an XmlDocument</param>
        /// <returns>An ACORD TX111 response serialize to a TXLife object</returns>
        internal TXLife FetchIllustration(XmlDocument acordRequest, string requestId="")
        {
            if (log.IsInfoEnabled) { log.Info($"FetchIllustration called with XmlDocument acordRequest."); }

            try
            {
                if (acordRequest == null)
                {
                    throw new ArgumentNullException("acordRequest", "The XML Document parameter cannot be null.");
                }

                var acordString = string.Empty;
                PayloadLoggerResponse requestPayload = null;

                // Capture request XML in case of error
                var firstChild = acordRequest.FirstChild;
                if (firstChild != null && firstChild.NodeType == XmlNodeType.XmlDeclaration)
                {
                    var xml = (XmlDeclaration)firstChild;
                    xml.Encoding = Encoding.UTF8.WebName;
                }
                acordString = acordRequest.OuterXml;

                // Write serialized XML request out to file system for logging.
                if (Settings.Default.LogAcordMessages)
                {
                    requestPayload = LargePayloadLogger.LogPayloadToFile(acordRequest.DocumentElement, "REQUEST", requestId);
                    if (log.IsDebugEnabled) log.DebugFormat("ACORD Request File: {0}, File ID: {1}", requestPayload.PayloadFilePath, requestPayload.PayloadFileId);
                }

                // Set TLS protocol
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                // Create WCF client
                var client = new LpaGatewayService.GatewayServiceClient(Settings.Default.WcfGatewayServiceClientName);
               
                // Send request to LPA
                var response = client.processXmlRequest(acordRequest.DocumentElement);

                if (!response.InnerXml.Contains("Input string was not in a correct format."))
                {
                    System.Diagnostics.Debug.Assert(true);
                }
                // Write serialized XML response out to file system for logging.
                if (Settings.Default.LogAcordMessages)
                {
                    var responsePayload = LargePayloadLogger.LogPayloadToFile(response, "RESPONSE", requestPayload.PayloadFileId);
                    if (log.IsDebugEnabled) log.DebugFormat("ACORD Response File: {0}, File ID: {1}", responsePayload.PayloadFilePath, responsePayload.PayloadFileId);
                }

                // Create serializer
                var ser = new XmlSerializer(typeof(TXLife));

                // Deserializer response to TXLife object
                using (var sr = new StringReader(response.OuterXml))
                using (var xr = XmlReader.Create(sr))
                {
                    var acordResponse = (TXLife)ser.Deserialize(xr);

                    return acordResponse;
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error("There was an error fetching the requested illustration for the XmlDocument acordRequest.", ex); }

                throw new LpaClientException("There was an error sending an ACORD request to LPA for processing.", ex);
            }
        }

        /// <summary>
        /// Sends an ACORD message to the LifePortraits Accelerate Gateway Service and deserializes the response.
        /// </summary>
        /// <param name="acordRequest">An ACORD TX111 request as an XmlDocument</param>
        /// <returns>An ACORD TX111 response serialize to a TXLife object</returns>
        internal TXLife FetchIllustration(string acordRequest, string requestId = "")
        {
            if (log.IsInfoEnabled) { log.Info($"FetchIllustration called with string acordRequest."); }

            try
            {
                // Need XmlElement object
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(acordRequest);

                return FetchIllustration(xmlDoc, requestId);
            }
            catch (LpaClientException)
            {
                // I've already thrown a custom exception, pass it up
                throw;
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error("There was an error fetching the requested illustration for the string acordRequest.", ex); }

                throw new LpaClientException("There was an error sending an ACORD request to LPA for processing.", ex);
            }
        }

        /// <summary>
        /// Sends an ACORD message to the LifePortraits Accelerate Gateway Service and deserializes the response.
        /// </summary>
        /// <param name="acordRequest">An ACORD TX111 request as an XmlDocument</param>
        /// <returns>An ACORD TX111 response serialize to a TXLife object</returns>
        internal TXLife FetchIllustration(TXLife acordObject, string requestId = "")
        {
            if (log.IsInfoEnabled) { log.Info($"FetchIllustration called with TXLife acordObject."); }

            try
            {
                // Serialize TXLife to XML string
                var acordString = ServiceHelper.SerializeAcordObject(acordObject);

                return FetchIllustration(acordString, requestId);
            }
            catch (LpaClientException)
            {
                throw;
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error("There was an error fetching the requested illustration for the TXLife acordObject.", ex); }

                throw new LpaClientException("There was an error sending an ACORD request to LPA for processing.", ex);
            }
        }
    }
}