using Newtonsoft.Json;
using System;

namespace WOW.Illustration.Model.Generation.Request
{
    /// <summary>
    /// ClientPerson:Person
    /// The client person object
    /// Inherits from Person
    /// </summary>
    public class ClientPerson : Person
    {
        public DateTime Birthdate { get; set; }

        public int Age { get; set; }

        /// <summary>Male = 0, Female = 1</summary>
        public int Gender { get; set; }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
