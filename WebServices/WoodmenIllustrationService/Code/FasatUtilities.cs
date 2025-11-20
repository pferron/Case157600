using log4net;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WOW.WoodmenIllustrationService.Models;
using WOW.WoodmenIllustrationService.Properties;

namespace WOW.WoodmenIllustrationService.Code
{
    public class FasatUtilities
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(FasatUtilities));

        public async Task<Agents> GetAgents(string RepCode)
        {
            var endpoint = Settings.Default.FRHierarchyServiceEndpoint + RepCode;
            
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(endpoint);

                if (response.IsSuccessStatusCode)
                {
                    Agents results = new Agents();
                    var obj = await response.Content.ReadAsStringAsync();
                    results.RelatedAgents = JsonConvert.DeserializeObject<Agent[]>(obj.ToString());
                    return results;
                }
                else
                {
                    log.Error("There was a problem calling FRHierarchyService for RepCode " + RepCode);
                    return null;
                }
            }
        }
    }
}