using Newtonsoft.Json;
using System.Collections.Generic;

namespace WOW.Illustration.Model.Generation.Request
{
    public class AdjustableLifeFlexibleLifePolicy : UniversalLifePolicy
    {
        public decimal ModalPremium { get; set; }

        public int OldBillType { get; set; }

        public int OldPremiumMode { get; set; }

        public int? NewRatingAmount { get; set; }

        public int? NewClassType { get; set; }       

        public IList<SubAccount> SubAccounts { get; set; }

        public int InforceRefundOption { get; set; }

        public bool HasFuturePremiumChange { get; set; }        

        public AdjustableLifeFlexibleLifePolicy()
        {
            SubAccounts = new List<SubAccount>();
        }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };

            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
