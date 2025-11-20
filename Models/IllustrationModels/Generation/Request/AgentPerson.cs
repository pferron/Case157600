
using Newtonsoft.Json;

namespace WOW.Illustration.Model.Generation.Request
{
    /// <summary>
    /// AgentPerson:Person
    /// The agent person class object
    /// Inherits from Person
    /// </summary>
    public class AgentPerson : Person
    {

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressCity { get; set; }

        public string AddressState { get; set; }

        public string AddressZipCode { get; set; }

        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
