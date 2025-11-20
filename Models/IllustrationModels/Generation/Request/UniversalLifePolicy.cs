using Newtonsoft.Json;

namespace WOW.Illustration.Model.Generation.Request
{
    /// <summary>
    /// UniversalLifePolicy:LifePolicy
    /// The universal life product object
    /// Inherits from LifePolicy
    /// </summary>
    public abstract class UniversalLifePolicy : LifePolicy
    {
        private const int YearsToMaturityUniversalLife = 121;

        /// <summary>FIP:RefundOpt, application of refunds on policy, LeftToAccumulateOnDeposit = 3, BuyPaidUpAdditions = 8, ReducePremium = 7, Cash = 1</summary>
        public int RefundOption { get; set; }

        /// <summary>Flag indicating that TAMRA (modified endowment) regulations should be applied to this policy, 1 if policy does not have a ModifiedEndowmentContractOption, otherwise, 0</summary>
        public bool IsTAMRAApplicable { get; set; }        

        public decimal NoLapseGuaranteedInterest { get; set; }

        public override int YearsToMaturity
        {
            get { return YearsToMaturityUniversalLife; }
        }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };

            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
