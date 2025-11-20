using Newtonsoft.Json;
using System.Xml.Serialization;
namespace WOW.Illustration.Model.Search.Request
{
    [XmlType("PersonSceneSearchRequest")]
    public class SearchRequest
    {
        [XmlElement("UserName", Order = 1)]
        public string Username { get; set; } // opt

        [XmlElement("PersonSearchFirstName", Order = 2)]
        public string FirstName { get; set; } // opt

        [XmlElement("PersonSearchLastName", Order = 3)]
        public string LastName { get; set; } //  req

        [XmlElement("PersonSearchAge", Order = 4)]
        public int? Age { get; set; } // opt

        [XmlIgnore]
        public bool AgeSpecified { get { return Age.HasValue; } }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
