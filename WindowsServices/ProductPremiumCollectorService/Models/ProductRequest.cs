using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ProductPremiumCollectorService.Models
{
    public class ProductRequest
    {
        public int HeaderCode { get; set; }
        public int StartingAge { get; set; }
        public int MaxAge { get; set; }
        public int StartingFaceAmount { get; set; }
        public int MaxFaceAmount { get; set; }
        public DateTime RateDeterminationDate { get; set; }
        public List<Transaction> Transactions { get; set; }

        public override string ToString()
        {
            var jsonSerialiser = new JavaScriptSerializer();
            return jsonSerialiser.Serialize(this);
        }


    }
}
