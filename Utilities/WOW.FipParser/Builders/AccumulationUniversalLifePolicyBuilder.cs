using System.Collections.Generic;
using System.Linq;
using WOW.Illustration.Model.Generation.Request;

namespace WOW.FipUtilities
{
    class AccumulationUniversalLifePolicyBuilder : PolicyBuilder
    {
        private AccumulationUniversalLifePolicy _policy;

        public AccumulationUniversalLifePolicyBuilder()
        {
            _policy = new AccumulationUniversalLifePolicy();
            base.Policy = _policy;
        }

        public override void HydratePolicySpecificData(IList<FipDataModel> fipData)
        {
            // [ULDATA] section applies to univeral life products
            var uldataSection = fipData.FirstOrDefault(f => f.Section == "[ULDATA]");

            if (uldataSection != null)
            {
                //_policy.LumpSumUsage = uldataSection.Data.SafeGetValue("LUMPSUMUSAGE", 0);
                _policy.RefundOption = uldataSection.Data.SafeGetValue("REFUNDOPT", 0);
                _policy.FraternalDues = uldataSection.Data.SafeGetValue("FRDUES", 0M);
                _policy.IsTAMRAApplicable = uldataSection.Data.SafeGetValue("ULTAMRA", false);
                //_policy.RtgAmtPerm = uldataSection.Data.SafeGetValue("RTGAMTPERM", 0);
                //_policy.RtgAmtPerm_ToAge = uldataSection.Data.SafeGetValue("RTGAMTPERM_TOAGE", 0);
                //_policy.AdvancePremiumFund = uldataSection.Data.SafeGetValue("ADVPREMFUND", 0M);
                _policy.BillType = uldataSection.Data.SafeGetValue("BILLTYPE", 0);
                _policy.NoLapseGuaranteedInterest = uldataSection.Data.SafeGetValue("NLGINT", 0M);
                _policy.ModalizedLoanRepayment = uldataSection.Data.SafeGetValue("MODALLOANREPAY", 0);
                //_policy.ExchangePolicyMEC = uldataSection.Data.SafeGetValue("EXCHPOLICYMEC", 0);
            }
            else
            {
                throw new FipParseException("Required [ULDATA] section is missing.");
            }

            //PrintAsTobacco can be present in either Policy Data (InForce) or Common Data (New Biz)
            //Check Policy Data first.
            var policyDataSection = fipData.FirstOrDefault(f => f.Section == "[POLICYDATA]");

            if (policyDataSection != null)
            {
                _policy.PrintAsTobacco = policyDataSection.Data.SafeGetValue("PRINTASTOBACCO", false);
                _policy.ModalPremium = policyDataSection.Data.SafeGetValue("MODALPREM", 0M);
                _policy.OldBillType = policyDataSection.Data.SafeGetValue("BILLTYPE", 0);
                _policy.OldPremiumMode = policyDataSection.Data.SafeGetValue("MODE", 0);
            }
            else
            {
                var commonDataSection = fipData.FirstOrDefault(f => f.Section == "[COMMONDATA]");
                if (commonDataSection != null)
                {
                    _policy.PrintAsTobacco = commonDataSection.Data.SafeGetValue("PRINTASTOBACCO", false);
                }
            }
        }

        public override Policy GetPolicy()
        {
            return _policy;
        }
    }
}
