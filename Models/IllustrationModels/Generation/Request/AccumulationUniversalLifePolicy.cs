
using Newtonsoft.Json;

namespace WOW.Illustration.Model.Generation.Request
{
    /// <summary>
    /// AccumulationUniversalLifePolicy:UniversalLifePolicy
    /// The accumulation Universal life policy product object
    /// Inherits from UniversalLifePolicy
    /// </summary>
    public class AccumulationUniversalLifePolicy : UniversalLifePolicy
    {
        public bool PrintAsTobacco { get; set; }

        public decimal ModalPremium { get; set; }

        public int OldBillType { get; set; }

        public int OldPremiumMode { get; set; }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
