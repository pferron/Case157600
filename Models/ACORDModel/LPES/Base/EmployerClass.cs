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
    public partial class EmployerClass
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string EmployerClassLinkKey { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string CensusCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public ClassName ClassName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public int Status { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool StatusSpecified { get; set; }

        /// <remarks/>
        [XmlElement("EnrollmentPeriodView", Order = 4)]
        public EnrollmentPeriodView[] EnrollmentPeriodView { get; set; }

        /// <remarks/>
        [XmlElement("EmployerClassPackage", Order = 5)]
        public EmployerClassPackage[] EmployerClassPackage { get; set; }

        /// <remarks/>
        [XmlElement("EmployerEnrollmentPeriod", Order = 6)]
        public EmployerEnrollmentPeriod[] EmployerEnrollmentPeriod { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public int MinimumHours { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MinimumHoursSpecified { get; set; }
    }
}
