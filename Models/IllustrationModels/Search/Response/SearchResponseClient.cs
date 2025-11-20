using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.Search.Response
{
    [XmlType("Client")]
    public class SearchResponseClient
    {
        public SearchResponseClient()
        {
            scenes = new Collection<SearchResponseScene>();
        }

        [XmlElement("ClientID")]
        public string clientId { get; set; }

        [XmlElement("FirstName")]
        public string firstName { get; set; }

        [XmlElement("MiddleName")]
        public string middleName { get; set; }

        [XmlElement("LastName")]
        public string lastName { get; set; }

        [XmlElement("Suffix")]
        public string suffix { get; set; }

        [XmlElement("Gender")]
        public string gender { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public DateTime? Birthdate { get; set; }

        [XmlElement("BirthDate")]
        public string dateOfBirth
        {
            get
            {
                if (Birthdate.HasValue)
                {
                    return Birthdate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                }
                else
                {
                    return null;
                }
            }

            set
            {
                DateTime temp;
                if (DateTime.TryParse(value, out temp))
                {
                    Birthdate = temp;
                }
                else
                {
                    Birthdate = null;
                }
            }
        }

        [XmlElement("Age", IsNullable = true)]
        public int? age { get; set; }

        [XmlArray("Scenes")]
        public Collection<SearchResponseScene> scenes { get; set; }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}