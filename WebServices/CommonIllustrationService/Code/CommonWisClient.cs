
using log4net;
using Newtonsoft.Json;
using Polly;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using Wow.CommonIllustrationService.Exceptions;
using Wow.CommonIllustrationService.Properties;
using WOW.Illustration.Model.Generation.Response;
using WIM = WOW.Illustration.Model.Generation.Request;


namespace Wow.CommonIllustrationService.Code
{
    public class CommonWisClient
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(CommonWisClient));

        public WoodmenIllustrationResponse GetIllustration(WIM.Policy request)
        {
            try
            {
                var content = ConsumeWimServiceAsync(request);
                return content;
            }
            catch (WimResponseException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new CommunicationException($"Exception in \"{nameof(CommonWisClient)}\": {ex.Message}", ex.InnerException);
            }
        }

        public WoodmenIllustrationResponse ConsumeWimServiceAsync(WIM.Policy request)
        {
            WoodmenIllustrationResponse wisResponse = null;

            string endpoint = Settings.Default.WimEndpoint;

            var settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.All;

            string jsonRequest = JsonConvert.SerializeObject(request, settings);
            var httpContent = new StringContent(jsonRequest, null, "application/json");

            using (HttpClient httpClient = new HttpClient())
            {
                if (log.IsInfoEnabled) log.Info($"Call WIM service {endpoint}.");

                httpClient.BaseAddress = new Uri(Settings.Default.WimServiceUrl);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.Timeout = Settings.Default.HttpClientRequestTimeout;

                var policy = Polly.Policy.Handle<Exception>()
                    .WaitAndRetry(Settings.Default.WebCallRetries, attempt => TimeSpan.FromTicks(Settings.Default.WebCallDelay.Ticks * attempt),
                    (ex, timeSpan) =>
                    {
                        if (log.IsErrorEnabled) log.Error($"There was an error calling the WIM Service.", ex);
                    });

                Task<HttpResponseMessage> taskPost = policy.Execute(() => httpClient.PostAsync(endpoint, httpContent));
                taskPost.Wait();

                if (log.IsInfoEnabled) log.Info(taskPost.Result);
                HttpResponseMessage response = taskPost.Result;
                var responseString = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    if (log.IsInfoEnabled) log.Info($"WIM service call was successful.");
                    wisResponse = JsonConvert.DeserializeObject<WoodmenIllustrationResponse>(responseString);
                }
                else
                {
                    var httpError = response.Content.ReadAsAsync<HttpError>();
                    if (log.IsErrorEnabled) log.Error(httpError.Exception.Message);
                    if (log.IsErrorEnabled) log.Error(httpError.Exception);

                    var message = $"WIM service call was unsuccessful.";
                    if (log.IsErrorEnabled) log.Error(message, httpError.Exception);
                    throw new WimResponseException(message, httpError.Exception);
                }

                return wisResponse;
            }
        }
    }
}
