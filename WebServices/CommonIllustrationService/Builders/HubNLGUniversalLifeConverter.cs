using WOW.Illustration.Model.Generation.Request;
using Hub = Wow.IllustrationCommonModels.Request;
using Wow.CommonIllustrationService.Code;

namespace Wow.CommonIllustrationService.Builders
{
    public class HubNLGUniversalLifePolicyConverter : HubPolicyConverter
    {
        private NoLapseGuaranteedUniversalLifePolicy _Policy;
        public HubNLGUniversalLifePolicyConverter()
        {
            _Policy = new NoLapseGuaranteedUniversalLifePolicy();
            base.Policy = _Policy;
        }
        public override void HydratePolicySpecificData(Hub.IllustrationRequest hubPolicy)
        {
            _Policy.RefundOption = hubPolicy.RefundOption;
            _Policy.BillType = ConvertFromCMBillingMethod(hubPolicy.BillingMethod);
            _Policy.FraternalDues = hubPolicy.FraternalDues;
            _Policy.NoLapseGuaranteedInterest = hubPolicy.NoLapseGuaranteedInterest;
            _Policy.ModalizedLoanRepayment = hubPolicy.LoanModalRepayment;
        }
        private int ConvertFromCMBillingMethod(string bm)
        {
            switch (bm.ToUpper())
            {
                case "REGBILL":
                    return 1;
                case "LISTBILL":
                    return 2;
                default:
                    return 3;
            }
        }
    }
}