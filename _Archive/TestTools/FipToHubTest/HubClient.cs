using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WOW.Illustration.Model.Generation.Response;
using FipToHubTest.Properties;

namespace HubIllustrationServiceTest
{
    public class HubClient
    {
       private HttpClient _httpClient;
       public HubClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Settings.Default.HubIllustrationServiceUrl);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.Timeout = Settings.Default.HttpClientRequestTimeout;

        }
        public MemoryStream GetAsync(string request)
        {
            using (var httpContent = new StringContent(request, null, "application/json"))
            {
                var httpResponse = _httpClient.PostAsync(Settings.Default.HubEndPoint, httpContent);
                httpResponse.Wait();
                if (httpResponse.Result.IsSuccessStatusCode)
                {
                    var response = httpResponse.Result.Content.ReadAsStreamAsync();
                    response.Wait();
                    return response.Result as MemoryStream;
                }
                else
                {
                    throw new Exception($"An error was returned to the Hub Illustration request. Response: {httpResponse}");
                }
            }
        }
        public async Task<WoodmenIllustrationResponse> GetAsync1(string request, string endpoint = null)
        {
            try
            {
                using (var httpContent = new StringContent(request, null, "application/json"))
                {
                    var responseObj = await _httpClient.PostAsync(endpoint != null ? endpoint : Settings.Default.HubEndPoint, httpContent);

                    if (responseObj.IsSuccessStatusCode)
                    {
                        var response = await responseObj.Content.ReadAsStringAsync();

                        return JsonConvert.DeserializeObject<WoodmenIllustrationResponse>(response);
                    }
                    else
                    {
                        throw new Exception($"The Woodmen Illustration Service returned an error. Response: {responseObj}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error returned to the Fip Illustration request. {ex}");
            }
        }

    }
}
