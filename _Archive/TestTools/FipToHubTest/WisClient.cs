using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using WOW.Illustration.Model.Generation.Response;
using Newtonsoft.Json;
using FipToHubTest.Properties;



namespace HubIllustrationServiceTest
{
    public class WisClient
    {
        private HttpClient _httpClient;

        public WisClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Settings.Default.IllustrationServiceBaseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.Timeout = Settings.Default.HttpClientRequestTimeout;

        }
        public async Task<WoodmenIllustrationResponse> GetAsync(string fipContent)
        {
            try
            {
                var encodedFip = Encoding.UTF8.GetBytes(fipContent);

                using (var content = new MultipartFormDataContent())
                using (var ms = new MemoryStream(encodedFip))
                using (var contentStream = new StreamContent(ms))
                {
                    content.Add(contentStream, "fipFile", "pefile.fip");

                    var responseObj = await _httpClient.PostAsync(Settings.Default.FipEndpoint, content);

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
