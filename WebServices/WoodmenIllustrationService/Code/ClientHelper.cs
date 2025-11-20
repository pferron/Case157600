using System.Collections.Generic;
using System.Linq;
using System.Web;
using WoodmenLife.Enterprise.Illustration.Models.Titanium;

namespace WOW.WoodmenIllustrationService.Code
{
    public class ClientHelper
    {
        public Client GetPrimaryClient(IList<PolicyClient> policyClients, IList<Client> clients)
        {
            Client primaryClient = new Client();
            PolicyClient primaryPolicyHolder = new PolicyClient();

            primaryPolicyHolder = policyClients.First(c => c.ClientRole.Code == "PRIMARY");

            primaryClient = clients.First(p => p.ClientId == primaryPolicyHolder.ClientId);
            return primaryClient;
        }
    }
}