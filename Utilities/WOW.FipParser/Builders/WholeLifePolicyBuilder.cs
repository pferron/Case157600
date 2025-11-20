using System;
using System.Collections.Generic;
using System.Linq;
using WOW.Illustration.Model.Generation.Request;

namespace WOW.FipUtilities
{
    class WholeLifePolicyBuilder : PolicyBuilder
    {
        private WholeLifePolicy _policy;

        public WholeLifePolicyBuilder()
        {
            _policy = new WholeLifePolicy();
            base.Policy = _policy;
        }

        public override void HydratePolicySpecificData(IList<FipDataModel> fipData)
        {
            // [WLDATA] section applies to traditional life products
            var wldataSection = fipData.FirstOrDefault(f => f.Section == "[WLDATA]");

            if (wldataSection != null)
            {
                _policy.FaceCode = wldataSection.Data.SafeGetValue("FACECODE", 1);
                //_policy.PremiumCode = wldataSection.Data.SafeGetValue("PREMCODE", 1);

                //FaceCode 1 means face amount, FaceCode 2 means premium amount.
                if (_policy.FaceCode == 1)
                    _policy.FaceAmount = wldataSection.Data.SafeGetValue("FACEPREMAMT", 0M);
                if (_policy.FaceCode == 2)
                    _policy.PremiumAmount = wldataSection.Data.SafeGetValue("FACEPREMAMT", 0M);

                _policy.PremiumMode = wldataSection.Data.SafeGetValue("PREMMODE", 1); // default to annual
                _policy.BillType = wldataSection.Data.SafeGetValue("BILLTYPE", 1); // default to direct bill
                //_policy.VanishType = wldataSection.Data.SafeGetValue("VANISHTYPE", 0);
                //_policy.VanishCode = wldataSection.Data.SafeGetValue("VANISHCODE", 0);
                //_policy.VanishAge = wldataSection.Data.SafeGetValue("VANISHAGE", 0);
                //_policy.ResumeAge = wldataSection.Data.SafeGetValue("RESUMEAGE", 0);
                //_policy.PrimaryDiv1 = wldataSection.Data.SafeGetValue("PRIMARYDIV_1", 101);
                //_policy.PrimaryDiv2 = wldataSection.Data.SafeGetValue("PRIMARYDIV_2", 1);
                //_policy.PrimaryDiv3 = wldataSection.Data.SafeGetValue("PRIMARYDIV_3", 1);
                //_policy.SecondaryDiv1 = wldataSection.Data.SafeGetValue("SECONDARYDIV_1", 0);
                //_policy.SecondaryDiv2 = wldataSection.Data.SafeGetValue("SECONDARYDIV_2", 0);
                //_policy.SecondaryDiv3 = wldataSection.Data.SafeGetValue("SECONDARYDIV_3", 1);
                //_policy.DivToAge1 = wldataSection.Data.SafeGetValue("DIVTOAGE_1", 0);
                //_policy.DivToAge2 = wldataSection.Data.SafeGetValue("DIVTOAGE_2", 0);
                //_policy.DivToAge3 = wldataSection.Data.SafeGetValue("DIVTOAGE_3", 0);
                //_policy.MortgageRate = wldataSection.Data.SafeGetValue("MORTGAGERATE", 0);
                //_policy.MortgageTerm = wldataSection.Data.SafeGetValue("MORTGAGETERM", 0);
                //_policy.MortgageDBType = wldataSection.Data.SafeGetValue("MORTGAGEDBTYPE", 0);
                //_policy.TenYearGuarantee = wldataSection.Data.SafeGetValue("TENYEARGUAR", 0);
                //_policy.ReducedPaidUp = wldataSection.Data.SafeGetValue("RPU", 0M);
                //_policy.ReducedPaidUpAge = wldataSection.Data.SafeGetValue("RPUAGE", 0);
                //_policy.ReducedPaidUpPrimaryDividend = wldataSection.Data.SafeGetValue("RPUPRIMARYDIV", 101M);
                //_policy.ReducedPaidUpSecondardDividend = wldataSection.Data.SafeGetValue("RPUSECONDARYDIV", 0M);
                //_policy.VanishMaintainCode = wldataSection.Data.SafeGetValue("VANISHMAINTAINCODE", 0);
                //_policy.PaidUpAdditionsStopPremium = wldataSection.Data.SafeGetValue("PUASTOPPREMIUM", 0);
                _policy.FraternalDues = wldataSection.Data.SafeGetValue("FRDUES", 0M);
                //_policy.ReducedTermOption = wldataSection.Data.SafeGetValue("REDTERMOPT", 0);
                //_policy.ReducedTermOptionAge = wldataSection.Data.SafeGetValue("RTOAGE", 0);
                //_policy.ReducedTermOptionAmountCode = wldataSection.Data.SafeGetValue("RTOAMTCODE", 0);
                //_policy.ReducedTermOptionAmount = wldataSection.Data.SafeGetValue("RTOAMOUNT", 0);
                _policy.CertificateDate = wldataSection.Data.SafeGetValue("CERTIFICATEDATE", DateTime.Today);
                if (string.IsNullOrWhiteSpace(Policy.PolicyNumber))
                {
                    Policy.PolicyNumber = wldataSection.Data.SafeGetValue("CERTIFICATENUMBER");
                }
                //_policy.CertificateNumber = wldataSection.Data.SafeGetValue("CERTIFICATENUMBER");
                _policy.ModalizedLoanRepayment = wldataSection.Data.SafeGetValue("MODALLOANREPAY", 0M);
                _policy.LodgeState = wldataSection.Data.SafeGetValue("LODGESTATE");
                _policy.LodgeNumber = wldataSection.Data.SafeGetValue("LODGENUMBER");
                _policy.WaiverDate = wldataSection.Data.SafeGetValue("WAIVERDATE", DateTime.MinValue);
            }
            else
            {
                throw new FipParseException("Required [WLDATA] section is missing.");
            }
        }

        public override Policy GetPolicy()
        {
            return _policy;
        }
    }
}
