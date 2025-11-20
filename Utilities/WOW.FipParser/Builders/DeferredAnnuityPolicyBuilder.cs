using System.Collections.Generic;
using System.Linq;
using WOW.Illustration.Model.Generation.Request;

namespace WOW.FipUtilities
{
    class DeferredAnnuityPolicyBuilder : PolicyBuilder
    {
        private DeferredAnnuityPolicy _policy;

        public DeferredAnnuityPolicyBuilder()
        {
            _policy = new DeferredAnnuityPolicy();
            base.Policy = _policy;
        }

        public override void HydratePolicySpecificData(IList<FipDataModel> fipData)
        {
            // [ANDATA] section applies to annuity products
            var andataSection = fipData.FirstOrDefault(f => f.Section == "[ANDATA]");

            if (andataSection != null)
            {
                //_policy.CostBasis = andataSection.Data.SafeGetValue("COSTBASIS", 0);
                //_policy.SinglePremiumImmediateAnnuityOption = andataSection.Data.SafeGetValue("SPIAOPTION", 0);
                //_policy.SinglePremiumImmediateAnnuityAmount = andataSection.Data.SafeGetValue("SPIAAMOUNT", 0M);
                //_policy.IncomeOption = andataSection.Data.SafeGetValue("INCOMEOPTION", 1);
                //_policy.IncomeRate = andataSection.Data.SafeGetValue("INCOMERATE", 0M);
                _policy.PrimaryPercent = andataSection.Data.SafeGetValue("PRIMARYPCT", 0M);
                //_policy.SecondaryPercent = andataSection.Data.SafeGetValue("SECONDARYPCT", 0M);
                _policy.CertainYear = andataSection.Data.SafeGetValue("CERTAINYEAR", 10);
                //_policy.CertainMonth = andataSection.Data.SafeGetValue("CERTAINMONTH", 0);
                //_policy.SinglePremiumImmediateAnnuityIncome = andataSection.Data.SafeGetValue("SPIAINCOME", 0);
                _policy.DeferredAnnuityCertainYear = andataSection.Data.SafeGetValue("DFRANCERTYR", 9);
                _policy.InitialGuaranteePeriod = andataSection.Data.SafeGetValue("INITGUARPERIOD", 0);
                _policy.AnnuityRateCode = andataSection.Data.SafeGetValue("ANRATECODE", 0);
                //_policy.AnnuityInterestRate = andataSection.Data.SafeGetValue("ANINTRATE", 0M);
                //_policy.IsJointAnnuity = andataSection.Data.SafeGetValue("ANWANTJOINT", false);
                _policy.InitialPremium = andataSection.Data.SafeGetValue("MONEYWITHAPP", 0M);
                //_policy.LifeIncomeFixedRate = andataSection.Data.SafeGetValue("LIFEINCFXDRATE", 0M);
                //_policy.LifeIncomeVariableRate = andataSection.Data.SafeGetValue("LIFEINCVARRATE", 0M);
                //_policy.NonLifeIncomePayRate = andataSection.Data.SafeGetValue("NONLIFEINCPAYRATE", 0M);
                //_policy.SettlementOption = andataSection.Data.SafeGetValue("SETTLEOPTION", 0);
                _policy.HeaderBandRates.Add(andataSection.Data.SafeGetValue("HDRBANDRATE1", 0M));
                _policy.HeaderBandRates.Add(andataSection.Data.SafeGetValue("HDRBANDRATE2", 0M));
                _policy.HeaderBandRates.Add(andataSection.Data.SafeGetValue("HDRBANDRATE3", 0M));
                _policy.HeaderBandRates.Add(andataSection.Data.SafeGetValue("HDRBANDRATE4", 0M));
                _policy.HeaderBandRates.Add(andataSection.Data.SafeGetValue("HDRBANDRATE5", 0M));
                _policy.HeaderBandRates.Add(andataSection.Data.SafeGetValue("HDRBANDRATE6", 0M));
                _policy.SecondaryGuaranteeRate = andataSection.Data.SafeGetValue("SECONDARYGUARRATE", 0M);
                _policy.MinimumGuaranteeRate = andataSection.Data.SafeGetValue("MINGUARRATE", 0M);
                _policy.BonusRate = andataSection.Data.SafeGetValue("BONUSRATE", 0M);
            }
            else
            {
                throw new FipParseException("Required [ANDATA] section is missing.");
            }
        }

        public override Policy GetPolicy()
        {
            return _policy;
        }
    }
}
