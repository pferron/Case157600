using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
namespace WOW.Illustration.Model.Search.Response
{
    [XmlType("PersonSceneSearchResponse")]
    public class SearchResponse
    {
        public SearchResponse()
        {
            clients = new Collection<SearchResponseClient>();
        }

        [XmlArray("Clients")]
        public Collection<SearchResponseClient> clients { get; set; }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
