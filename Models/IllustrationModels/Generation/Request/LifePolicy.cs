using Newtonsoft.Json;

namespace WOW.Illustration.Model.Generation.Request
{
    /// <summary>
    /// LifePolicy:Policy
    /// The life product policy object
    /// Inherits from Policy
    /// </summary>
    public abstract class LifePolicy : Policy
    {
        /// <summary>Code indicating how the premium is collected. (PAC, List Bill, Direct Bill)</summary>
        public int BillType { get; set; }

        // Moved from TradLife and UniLife to this level
        /// <summary>FIP:ModalLoanRepay, Modalized loan repayment for in-force with loan in place</summary>
        public decimal ModalizedLoanRepayment { get; set; }

        public abstract int YearsToMaturity { get; }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };

            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
