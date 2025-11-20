
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Wow.IllustrationCommonModels.Request
{
    /// <summary>
    /// AgentPerson:Person
    /// The agent person class object
    /// Inherits from Person
    /// </summary>
    public class AgentPerson
    {

        [Required, MinLength(1, ErrorMessage = "Agent FirstName cannot be empty.")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "Agent MiddleName cannot be null.")]
        public string MiddleName { get; set; }

        [Required, MinLength(1, ErrorMessage = "Agent LastName cannot be empty.")]
        public string LastName { get; set; }

        [Required, MinLength(1, ErrorMessage = "Agent AddressLine1 cannot be empty.")]
        public string AddressLine1 { get; set; }
        
        [Required(AllowEmptyStrings = true, ErrorMessage = "Agent AddressLine2 cannot be null.")]
        public string AddressLine2 { get; set; }

        [Required, MinLength(1, ErrorMessage = "Agent AddressCity cannot be empty.")]
        public string AddressCity { get; set; }

        [Required, MinLength(1, ErrorMessage = "Agent AddressStateCode cannot be empty.")]
        public string AddressStateCode { get; set; }

        [Required, MinLength(1, ErrorMessage = "Agent AddressZip cannot be empty.")]
        public string AddressZip { get; set; }

        [Required, MinLength(1, ErrorMessage = "Agent PhoneNumber cannot be empty.")]
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
