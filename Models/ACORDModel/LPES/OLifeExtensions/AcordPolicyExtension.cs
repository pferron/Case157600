using System;
using System.Xml.Serialization;
using WOW.Illustration.Model.ACORD;
using WOW.Illustration.Model.LPES.Base;

namespace WOW.Illustration.Model.LPES.OLifeExtensions
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    public class AcordPolicyExtension : OLifEExtension
    {
        [XmlElement("TemplateID", Order = 1)]
        public string TemplateId { get; set; }

        [XmlElement("CostBenefitReport", Order = 2)]
        public COST_BENEFIT_REPORT_TYPE CostBenefitReport { get; set; }

        [XmlElement("NbrOwners", Order = 3)]
        public int NumberOfOwners { get; set; }

        [XmlIgnore()]
        public bool NumberOfOwnersSpecified { get { return NumberOfOwners > 0; } }

        [XmlElement("AnnualFraternalDues", Order = 4)]
        public decimal AnnualFraternalDues { get; set; }

        [XmlIgnore()]
        public bool AnnualFraternalDuesSpecified { get { return !AnnualFraternalDues.Equals(decimal.Zero); } }

        [XmlElement("Refunds", Order = 5)]
        public REFUNDS_TYPE Refunds { get; set; }

        [XmlElement("RateDeterminationDate", Order = 6, DataType = "date")]
        public DateTime RateDeterminationDate { get; set; }

        [XmlIgnore()]
        public bool RateDeterminationDateSpecified { get { return !RateDeterminationDate.Equals(DateTime.MinValue); } }

        [XmlElement("LumpSumPaymentOption", Order = 7)]
        public LumpSumPaymentOptionType LumpSumPaymentOption { get; set; }

        [XmlElement("ConformTAMRA", Order = 8)]
        public OLI_LU_BOOLEAN ConformTAMRA { get; set; }

        [XmlElement("RevisedIllustration", Order = 9)]
        public OLI_LU_BOOLEAN RevisedIllustration { get; set; }

        [XmlElement("StatKind", Order = 10)]
        public int StatKind { get; set; }

        [XmlIgnore()]
        public bool StatKindSpecified { get { return !StatKind.Equals(0); } }

        [XmlElement("ModalLoanRepay", Order = 11)]
        public decimal ModalLoanRepay { get; set; }

        [XmlIgnore()]
        public bool ModalLoanRepaySpecified { get { return !ModalLoanRepay.Equals(decimal.Zero); } }

        [XmlElement("NLGLoadTarget", Order = 12)]
        public decimal NLGLoadTarget { get; set; }

        [XmlIgnore()]
        public bool NLGLoadTargetSpecified { get { return !NLGLoadTarget.Equals(decimal.Zero); } }

        [XmlElement("NLGAccountValue", Order = 13)]
        public decimal NLGAccountValue { get; set; }

        [XmlIgnore()]
        public bool NLGAccountValueSpecified { get { return !NLGAccountValue.Equals(decimal.Zero); } }

        [XmlElement("RefundsOnDeposit", Order = 14)]
        public decimal RefundsOnDeposit { get; set; }

        [XmlIgnore()]
        public bool RefundsOnDepositSpecified { get { return !RefundsOnDeposit.Equals(decimal.Zero); } }

        [XmlElement("SceneModifyDate", Order = 15, DataType = "date")]
        public DateTime SceneModifyDate { get; set; }

        [XmlIgnore()]
        public bool SceneModifyDateSpecified { get { return !SceneModifyDate.Equals(DateTime.MinValue); } }

        [XmlElement("APFBalance", Order = 16)]
        public decimal APFBalance { get; set; }

        [XmlIgnore()]
        public bool APFBalanceSpecified { get { return !APFBalance.Equals(decimal.Zero); } }

        [XmlElement("PrintAsTobacco", Order = 17)]
        public int PrintAsTobacco { get; set; }

        [XmlIgnore()]
        public bool PrintAsTobaccoSpecified { get { return !PrintAsTobacco.Equals(0); } }

        [XmlElement("NLGInt", Order = 18)]
        public decimal NLGInterest { get; set; }

        [XmlIgnore()]
        public bool NLGInterestSpecified { get { return !NLGInterest.Equals(decimal.Zero); } }

        [XmlElement("BelowMinPrem", Order = 19)]
        public bool BelowMinimumPremium { get; set; }

        [XmlIgnore()]
        public bool BelowMinimumPremiumSpecified { get { return BelowMinimumPremium; } }

        [XmlElement("ChapterState", Order = 20)]
        public string ChapterState { get; set; }

        [XmlElement("ChapterNumber", Order = 21)]
        public string ChapterNumber { get; set; }        

        [XmlElement("RefundLastAnniversary", Order = 22)]
        public decimal RefundLastAnniversary { get; set; }

        [XmlIgnore()]
        public bool RefundLastAnniversarySpecified { get { return !RefundLastAnniversary.Equals(decimal.Zero); } }

        [XmlElement("FaceAmountInforceFromRefunds", Order = 23)]
        public decimal FaceAmountInforceFromRefunds { get; set; }

        [XmlIgnore()]
        public bool FaceAmountInforceFromRefundsSpecified { get { return !FaceAmountInforceFromRefunds.Equals(decimal.Zero); } }

        [XmlElement("Tamra7PayPremium", Order = 24)]
        public decimal Tamra7PayPremium { get; set; }

        [XmlIgnore()]
        public bool Tamra7PayPremiumSpecified { get { return !Tamra7PayPremium.Equals(decimal.Zero); } }

        [XmlElement("PostDEFRAMXCV", Order = 25)]
        public decimal PostDEFRAMXCV { get; set; }

        [XmlIgnore()]
        public bool PostDEFRAMXCVSpecified { get; set; } = false;

        [XmlElement("ReducedFaceAmountOpt", Order = 26)]
        public int ReducedFaceAmountOpt { get; set; }

        [XmlIgnore()]
        public bool ReducedFaceAmountOptSpecified { get; set; } = false;

        [XmlElement("PartialSurrenderToClearDebt", Order = 27)]
        public int PartialSurrenderToClearDebt { get; set; }

        [XmlIgnore()]
        public bool PartialSurrenderToClearDebtSpecified { get; set; } = false;

        [XmlElement("PolicyOnWaiver", Order = 28)]
        public int PolicyOnWaiver { get; set; }

        [XmlIgnore()]
        public bool PolicyOnWaiverSpecified { get; set; } = false;

        [XmlElement("YTDAccumulatedRefunds", Order = 29)]
        public decimal YTDAccumulatedRefunds { get; set; }

        [XmlIgnore()]
        public bool YTDAccumulatedRefundsSpecified { get { return !YTDAccumulatedRefunds.Equals(decimal.Zero); } }

        [XmlElement("InforceRefunds", Order = 30)]
        public REFUNDS_TYPE InforceRefunds { get; set; }

        [XmlIgnore()]
        public bool InforceRefundsSpecified { get; set; } = false;
    }
}