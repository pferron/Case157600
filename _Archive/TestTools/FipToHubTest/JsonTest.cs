using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FipToHubTest
{
    class JsonTest
    {
        //private string Nome;
        //private string Cognome;
        //public string moglie;
        //public string figlio;
        public string[] figli = new string[] { "Alfredo", "Luigia", "Francesco" }; 
        //private JsonTest()
        //{
        //    Nome = "Livio";          
        //    Cognome = "Felicella";
        //    moglie = "Matilde";
        //    figlio = "Alfredo";
        //}
        static private string family = "{'Nome':'','Cognome':'','Moglie':'Matilde','Figlio':'Alfredo','Figlio':'Luigia','Figlio':'Francesco'}";
        static internal string Serialize()
        {

            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };

            var obj = JsonConvert.DeserializeObject<JsonTest>(family);
            obj = new JsonTest();
            return JsonConvert.SerializeObject(obj, settings);

        }
    }
}
