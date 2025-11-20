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
    public partial class EnrollmentPeriodPackageCGIDetail
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string EmployerEnrollmentPeriodPackageCGIDetailLinkKey { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string EmployerEnrollmentPeriodPackageLinkKey { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public int CGIRole { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool CGIRoleSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public int SpouseWorkStatus { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool SpouseWorkStatusSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public int CGIType { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool CGITypeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public int CGIStatus { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool CGIStatusSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public double MinWeeklyPremium { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MinWeeklyPremiumSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public double MaxWeeklyPremium { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MaxWeeklyPremiumSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public double MinIssue { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MinIssueSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 9)]
        public double MaxIssue { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MaxIssueSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 10)]
        public int EEMultipleOfSalary { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EEMultipleOfSalarySpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 11)]
        public int OmitAids { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool OmitAidsSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 12)]
        public int OmitHosp { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool OmitHospSpecified { get; set; }
    }
}
