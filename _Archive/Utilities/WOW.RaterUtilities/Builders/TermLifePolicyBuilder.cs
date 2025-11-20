
using System;
using WOW.Illustration.Model.Generation.Request;
using WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Requests;
namespace WOW.RaterUtilities
{
    class TermLifePolicyBuilder : PolicyBuilder
    {
        private TermLifePolicy _policy;

        public TermLifePolicyBuilder()
        {
            _policy = new TermLifePolicy();
            base.Policy = _policy;
        }

        public override void HydratePolicySpecificData(RaterRequest raterData)
        {
            _policy.FaceCode = raterData.FaceCode;
            //_policy.PremiumCode = 1;

            //FaceCode 1 means face amount, FaceCode 2 means premium amount.
            if (_policy.FaceCode == 1)
                _policy.FaceAmount = raterData.FacePremAmt;
            if (_policy.FaceCode == 2)
                _policy.PremiumAmount = raterData.FacePremAmt;

            _policy.PremiumMode = raterData.PremMode;
            _policy.BillType = raterData.BillType;
            //_policy.VanishType = raterData.VanishType;
            //_policy.VanishCode = 0;
            //_policy.VanishAge = 0;
            //_policy.ResumeAge = 0;
            //_policy.PrimaryDiv1 = 101;
            //_policy.PrimaryDiv2 = 1;
            //_policy.PrimaryDiv3 = 1;
            //_policy.SecondaryDiv1 = 0;
            //_policy.SecondaryDiv2 = 0;
            //_policy.SecondaryDiv3 = 1;
            //_policy.DivToAge1 = 0;
            //_policy.DivToAge2 = 0;
            //_policy.DivToAge3 = 0;
            //_policy.MortgageRate = 0;
            //_policy.MortgageTerm = 0;
            //_policy.MortgageDBType = 0;
            //_policy.TenYearGuarantee = 0;
            //_policy.ReducedPaidUp = 0M;
            //_policy.ReducedPaidUpAge = 0;
            //_policy.ReducedPaidUpPrimaryDividend = raterData.RPUPrimaryDiv;
            //_policy.ReducedPaidUpSecondardDividend = 0M;
            //_policy.VanishMaintainCode = raterData.VanishMaintainCode;
            //_policy.PaidUpAdditionsStopPremium = raterData.PUAStopPremium;
            _policy.FraternalDues = raterData.FrDues;
            //_policy.ReducedTermOption = 0;
            //_policy.ReducedTermOptionAge = 0;
            //_policy.ReducedTermOptionAmountCode = 0;
            //_policy.ReducedTermOptionAmount = 0;
            _policy.CertificateDate = DateTime.Today;
            //_policy.CertificateNumber = string.Empty;
            _policy.ModalizedLoanRepayment = 0M;
            _policy.LodgeState = string.Empty;
            _policy.LodgeNumber = string.Empty;
            _policy.WaiverDate = DateTime.Now;
        }

        public override Policy GetPolicy()
        {
            return _policy;
        }
    }
}
