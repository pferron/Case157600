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
    public partial class EmployerEnrollmentPeriodPackage
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string EmployerEnrollmentPeriodPackageLinkKey { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public int Status { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool StatusSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public double MinFaceAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MinFaceAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public double MaxFaceAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MaxFaceAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public double MinPremium { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MinPremiumSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public double MaxPremium { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MaxPremiumSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public double MinBenefit { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MinBenefitSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public double MaxBenefit { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MaxBenefitSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public double MonthlyBenefit { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MonthlyBenefitSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 9)]
        public int IsDefaultPlan { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool IsDefaultPlanSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 10)]
        public int DisplayOrder { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool DisplayOrderSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 11)]
        public int RequiredCGI { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool RequiredCGISpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 12)]
        public int RequiredGI { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool RequiredGISpecified { get; set; }

        /// <remarks/>
        [XmlElement("EnrollmentPeriodPackageCGIDetail", Order = 13)]
        public EnrollmentPeriodPackageCGIDetail[] EnrollmentPeriodPackageCGIDetail { get; set; }
    }
}
