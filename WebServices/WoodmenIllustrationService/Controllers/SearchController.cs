using log4net;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Xml.Serialization;
using WOW.Illustration.Model.Search.Request;
using WOW.Illustration.Model.Search.Response;
using WOW.WoodmenIllustrationService.Properties;
using System;
using WOW.WoodmenIllustrationService.Code;

namespace WOW.WoodmenIllustrationService.Controllers
{
    public class SearchController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SearchController));


        [HttpPost]
        [ActionName("Search")]
        public Collection<SearchResponseClient> Search(SearchRequest model)
        {
            if (log.IsInfoEnabled) log.Info($"Receiving Search request for model: {model.ToString()}. Source IP Address: {Request.GetClientIpAddress()}.");

            // Model validation
            if (model == null)
            {
                if (log.IsDebugEnabled) { log.Debug("SearchRequest model is null. Throwing exception to client."); }

                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("The search request cannot be null."),
                    ReasonPhrase = "SearchRequest model is null."
                });
            }

            // Model validation
            if (string.IsNullOrEmpty(model.LastName))
            {
                if (log.IsDebugEnabled) { log.Debug("SearchRequest.LastName is null or empty. Throwing exception to client."); }

                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Last Name is a required field in the search request."),
                    ReasonPhrase = "SearchRequest.LastName is null or empty."
                });
            }

            // Log incoming request
            if (log.IsDebugEnabled) { log.DebugFormat("SearchRequest: {0}", model); }

            try
            {
                // Query LifePortraits
                var results = QueryIllustrationSystem(model);

                if (results != null && results.Count > 0)
                {
                    if (log.IsDebugEnabled) { log.DebugFormat("Found {0} results.", results.Count); }

                    return results;
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Error processing Search request.", ex);

                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                throw new HttpResponseException(errorResponse);

            }

            if (log.IsDebugEnabled) { log.Debug("No results found. Throwing 404 exception to client."); }

            // Nothing was found at this point, return a 404
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(string.Format(CultureInfo.InvariantCulture, "No records were found. SearchRequest: LastName '{0}', FirstName '{1}', Age {2}, Username, '{3}'.", model.LastName, model.FirstName, model.Age, model.Username)),
                ReasonPhrase = "No results found."
            });
        }

        private static Collection<SearchResponseClient> QueryIllustrationSystem(SearchRequest model)
        {
            var wcfSetting = Settings.Default.WcfSearchServiceClientName;

            if (log.IsDebugEnabled) { log.DebugFormat("Querying LifePortraits using endpoint configuration name: {0}", wcfSetting); }

            var request = SerializeRequest(model);
            var serviceClient = new LpaSearchService.PersonSceneSearchServiceClient(wcfSetting);
            var response = serviceClient.processRequest(request);

            if (log.IsDebugEnabled) { log.DebugFormat("Response from LifePortraits: {0}", response); }

            var searchResponse = DeserializeResponse(response);

            RemoveDues(searchResponse);

            NormalizeValues(searchResponse);

            return searchResponse.clients;
        }

        private static void NormalizeValues(SearchResponse searchResponse)
        {
            // This method is needed to make some of the returned values from LPA consistent
            // Some unknown number of API values are tied to the GUI values; when one is change so is the other
            // Instead of paying for a new feature to force different values, we'll handle it in the WIS

            // Normalize the DeathBenefitOption value
            if(searchResponse == null || searchResponse.clients == null)
            {
                return;
            }

            foreach(var client in searchResponse.clients)
            {
                foreach(var scene in client.scenes)
                {
                    if(!string.IsNullOrWhiteSpace(scene.deathBenefitOption))
                    {
                        // Strip out the numbers, dashes & spaces
                        scene.deathBenefitOption = Regex.Replace(scene.deathBenefitOption, "[^a-zA-Z]", string.Empty);
                    }
                }
            }
        }

        private static void RemoveDues(SearchResponse searchResponse)
        {
            if (searchResponse == null) return;

            if(searchResponse.clients != null)
            {
                foreach(var client in searchResponse.clients)
                {
                    if(client.scenes != null)
                    {
                        foreach(var scene in client.scenes)
                        {
                            if(Settings.Default.HeaderCodesWithSuppressedDues.Contains(scene.headerCode.ToString()))
                            {
                                scene.lodgeDues = 0M;
                            }
                        }
                    }
                }
            }
        }

        private static string SerializeRequest(SearchRequest model)
        {
            var result = string.Empty;

            using (var writer = new StringWriter(CultureInfo.InvariantCulture))
            {
                var serializer = new XmlSerializer(typeof(SearchRequest));
                serializer.Serialize(writer, model);
                result = writer.ToString();
            }

            return result;
        }

        private static SearchResponse DeserializeResponse(string response)
        {
            SearchResponse list;

            var serializer = new XmlSerializer(typeof(SearchResponse));
            using (var reader = new StringReader(response))
            {
                list = (SearchResponse)serializer.Deserialize(reader);
            }

            return list;
        }
    }
}
