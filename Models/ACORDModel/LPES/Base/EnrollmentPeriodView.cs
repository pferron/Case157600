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
    public partial class EnrollmentPeriodView
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string EnrollmentPeriodViewLinkKey { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string StartDate { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string EndDate { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public int Year { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool YearSpecified { get; set; }

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
        public int GroupEnrollmentPeriodDateType { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool GroupEnrollmentPeriodDateTypeSpecified { get; set; }
    }
}
