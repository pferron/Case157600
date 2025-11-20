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
    public partial class EmployerEnrollmentPeriod
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string EmployerEnrollmentPeriodLinkKey { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string EnrollmentPeriodName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string YearOfEnrollment { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public string DateString { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public int Status { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool StatusSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public EnrollmentEventType EnrollmentEventType { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public int EnrollmentKeepOpen { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EnrollmentKeepOpenSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public int RetroactiveAvailable { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool RetroactiveAvailableSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public string ExternalMappingID { get; set; }

        /// <remarks/>
        [XmlElement(Order = 9)]
        public LPNamedValuePair LPNamedValuePair { get; set; }

        /// <remarks/>
        [XmlElement(Order = 10)]
        public EnrollmentPeriodDateDetail EnrollmentDateDetail { get; set; }

        /// <remarks/>
        [XmlElement(Order = 11)]
        public EnrollmentPeriodDateDetail EligibilityDateDetail { get; set; }

        /// <remarks/>
        [XmlElement(Order = 12)]
        public EnrollmentPeriodDateDetail CoverageDateDetail { get; set; }

        /// <remarks/>
        [XmlElement("EmployerEnrollmentPeriodPackage", Order = 13)]
        public EmployerEnrollmentPeriodPackage[] EmployerEnrollmentPeriodPackage { get; set; }
    }
}
