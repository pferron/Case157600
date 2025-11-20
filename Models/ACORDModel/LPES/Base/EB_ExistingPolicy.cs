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
    public partial class EB_ExistingPolicy
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string EB_PolicyID { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string EB_PolicyNumber { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string EB_CaseNumber { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public string EB_CaseName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public string EB_IssueState { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 5)]
        public System.DateTime EB_TerminationDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EB_TerminationDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public string EB_PolicyStatus { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public string EB_PolicyType { get; set; }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public double EB_BillingPremium { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EB_BillingPremiumSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 9)]
        public double EB_MonthlyPremium { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EB_MonthlyPremiumSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 10)]
        public double EB_AnnualPremium { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EB_AnnualPremiumSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 11)]
        public string EB_BillingMode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 12)]
        public string EB_PrimaryInsuredSSN { get; set; }

        /// <remarks/>
        [XmlElement(Order = 13)]
        public string EB_CoverageLevel { get; set; }

        /// <remarks/>
        [XmlElement(Order = 14)]
        public long EB_ABETLLoadID { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EB_ABETLLoadIDSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 15)]
        public System.DateTime EB_PolicyCreatedDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EB_PolicyCreatedDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 16)]
        public System.DateTime EB_EMWSyncDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EB_EMWSyncDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement("EB_ExistingCoverage", Order = 17)]
        public EB_ExistingCoverage[] EB_ExistingCoverage { get; set; }
    }
}
