using WOW.Illustration.Model.Generation.Request;
using WOW.WoodmenIllustrationService.SharedModels;
namespace WOW.RaterUtilities
{
    class AccumulationUniversalLifePolicyBuilder : PolicyBuilder
    {
        private AccumulationUniversalLifePolicy _policy;

        public AccumulationUniversalLifePolicyBuilder()
        {
            _policy = new AccumulationUniversalLifePolicy();
            base.Policy = _policy;
        }

        public override void HydratePolicySpecificData(RaterRequest raterData)
        {
            //_policy.LumpSumUsage = raterData.LumpSumUsage;
            _policy.RefundOption = raterData.RefundOpt;
            _policy.FraternalDues = raterData.FrDues;
            _policy.IsTAMRAApplicable = (raterData.ConformToTamra == 1);
            //_policy.RtgAmtPerm = raterData.RtgAmtPerm;
            //_policy.RtgAmtPerm_ToAge = raterData.RtgAmtPermToAge;
            //_policy.AdvancePremiumFund = 0M;
            _policy.BillType = raterData.BillType;
            _policy.NoLapseGuaranteedInterest = 0M;
            _policy.ModalizedLoanRepayment = 0M;
            //_policy.ExchangePolicyMEC = 0;
            _policy.PrintAsTobacco = false;
        }

        public override Policy GetPolicy()
        {
            return _policy;
        }
    }
}
