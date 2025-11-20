using WOW.Illustration.Model.Generation.Request;
using WOW.WoodmenIllustrationService.SharedModels;

namespace WOW.RaterUtilities
{
    class NoLapseUniversalLifePolicyBuilder : PolicyBuilder
    {
        private NoLapseGuaranteedUniversalLifePolicy _policy;

        public NoLapseUniversalLifePolicyBuilder()
        {
            _policy = new NoLapseGuaranteedUniversalLifePolicy();
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
            // I need to call out to a helper function to lookup the current interest rate
            // I'll do that at the service level
            //_policy.NLGInt
            _policy.ModalizedLoanRepayment = 0M;
            //_policy.ExchangePolicyMEC = 0;
        }

        public override Policy GetPolicy()
        {
            return _policy;
        }
    }
}
