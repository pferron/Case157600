using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Wow.IllustrationCommonModels.Request
{
    /// <summary>
    /// ClientPerson:Person
    /// The client person object
    /// Inherits from Person
    /// </summary>
    public class ClientPerson
    {
        [Required, MinLength(1, ErrorMessage = "Client FirstName cannot be empty.")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "Client MiddleName cannot be null.")]
        public string MiddleName { get; set; }

        [Required, MinLength(1, ErrorMessage = "Client LastName cannot be empty.")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "Client NameSuffix cannot be null.")]
        public string NameSuffix { get; set; }

        [Required(ErrorMessage = "Client BirthDate cannot be empty.")]
        public DateTime? BirthDate { get; set; }

        /// <summary>Male = 0, Female = 1</summary>
        [Required, MinLength(1, ErrorMessage = "Client GenderCode cannot be empty.")]
        public string GenderCode { get; set; }

        [Required, MinLength(1, ErrorMessage = "Client AddressStateCode cannot be empty.")]
        public string AddressStateCode { get; set; }

        [Required, MinLength(1, ErrorMessage = "Client AddressCountryCode cannot be empty.")]
        public string AddressCountryCode { get; set; }

        [Required, Range(0, 85, ErrorMessage = "Client Age must be greater than 0.")]
        public int Age { get; set; }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
