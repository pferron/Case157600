using System;
using System.Xml.Serialization;
using WOW.Illustration.Model.ACORD;
using WOW.Illustration.Model.LPES.Base;

namespace WOW.Illustration.Model.LPES.OLifeExtensions
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    [XmlRoot(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView", IsNullable = false)]
    public class AcordAnnuityExtension : OLifEExtension
    {
        [XmlElement("FIPQualPlanType", Order = 1)]
        public FIP_QUAL_PLAN_TYPE QualifiedPlanType { get; set; }

        [XmlElement("InitGuarIntPeriod", Order = 2)]
        public INIT_GUAR_INT_PERIOD_TYPE InitialGuaranteeIntPeriod { get; set; }

        [XmlElement("AnnuityRateCode", Order = 3)]
        public ANNUITY_RATE_CODE_TYPE AnnuityRateCode { get; set; }

        [XmlElement("DeferAnnuityCertYear", Order = 4)]
        public DEFER_ANNUITY_CERT_YEAR_TYPE DeferAnnuityCertificateYear { get; set; }

        [XmlElement("SurvivorPercentage", Order = 5)]
        public decimal SurvivorPercentage { get; set; }

        [XmlIgnore()]
        public bool SurvivorPercentageSpecified { get { return !SurvivorPercentage.Equals(decimal.Zero); } }

        [XmlElement("LifeIncomeFixedRate", Order = 6)]
        public decimal LifeIncomeFixedRate { get; set; }

        [XmlIgnore()]
        public bool LifeIncomeFixedRateSpecified { get { return !LifeIncomeFixedRate.Equals(decimal.Zero); } }

        [XmlElement("LifeIncomeVariableRate", Order = 7)]
        public decimal LifeIncomeVariableRate { get; set; }

        [XmlIgnore()]
        public bool LifeIncomeVariableRateSpecified { get { return !LifeIncomeVariableRate.Equals(decimal.Zero); } }

        [XmlElement("NonLifeIncomePayRate", Order = 8)]
        public decimal NonLifeIncomePayRate { get; set; }

        [XmlIgnore()]
        public bool NonLifeIncomePayRateSpecified { get { return !NonLifeIncomePayRate.Equals(decimal.Zero); } }

        [XmlElement("SecondaryGuarRate", Order = 9)]
        public decimal SecondaryGuaranteedRate { get; set; }

        [XmlIgnore()]
        public bool SecondaryGuaranteedRateSpecified { get { return !SecondaryGuaranteedRate.Equals(decimal.Zero); } }

        [XmlElement("MinGuarRate", Order = 10)]
        public decimal MinimumGuaranteedRate { get; set; }

        [XmlIgnore()]
        public bool MinimumGuaranteedRateSpecified { get { return !MinimumGuaranteedRate.Equals(decimal.Zero); } }

        [XmlElement("InitGuarRate", Order = 11)]
        public decimal InitialGuaranteeRate { get; set; }

        [XmlIgnore()]
        public bool InitialGuaranteeRateSpecified { get { return !InitialGuaranteeRate.Equals(decimal.Zero); } }

        [XmlElement("BonusRate", Order = 12)]
        public decimal BonusRate { get; set; }

        [XmlIgnore()]
        public bool BonusRateSpecified { get { return !BonusRate.Equals(decimal.Zero); } }

        [XmlElement("AnTableSettleOpt", Order = 13)]
        public decimal AnnuityTableSettleOption { get; set; }

        [XmlIgnore()]
        public bool AnnuityTableSettleOptionSpecified { get { return !AnnuityTableSettleOption.Equals(decimal.Zero); } }
    }
}