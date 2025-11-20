using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.LPES.Base
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    [XmlRoot(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView", IsNullable = false)]
    public partial class Replacement
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string CompanyName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string PolicyNumber { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public int YearIssued { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool YearIssuedSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public double BenefitAmount { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool BenefitAmountSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        [CLSCompliant(false)]
        public sbyte BeingReplaced { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool BeingReplacedSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 5)]
        public System.DateTime TerminationEffectiveDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool TerminationEffectiveDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public int ProposedCoverage { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool ProposedCoverageSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public int ExistingCoverage { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool ExistingCoverageSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public int ExistingCoverageLTC { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool ExistingCoverageLTCSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 9)]
        public string OtherCoverage { get; set; }

        /// <remarks/>
        [XmlElement(Order = 10)]
        public int ExistingEliminationPeriod { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool ExistingEliminationPeriodSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 11)]
        public int ExistingBenefitPeriod { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool ExistingBenefitPeriodSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 12)]
        public int DataID { get; set; }

        /// <remarks/>
        [XmlElement(Order = 13)]
        public int YrLapsed { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool YrLapsedSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 14)]
        public bool InternalReplace { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool InternalReplaceSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 15)]
        public System.DateTime CoverageEffectiveDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool CoverageEffectiveDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 16)]
        public string HoldingID { get; set; }

        /// <remarks/>
        [XmlElement(Order = 17)]
        public int Exchange1035 { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool Exchange1035Specified { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }
    }
}
