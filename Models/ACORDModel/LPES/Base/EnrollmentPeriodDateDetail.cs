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
    [XmlType(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    [XmlRoot("EnrollmentDateDetail", Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView", IsNullable = false)]
    public partial class EnrollmentPeriodDateDetail
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string EnrollmentPeriodDateDetailLinkKey { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public int StartDateType { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool StartDateTypeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string StartDate { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public int StartDateContext { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool StartDateContextSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public int StartDateAnchor { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool StartDateAnchorSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public int StartNumberOfDays { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool StartNumberOfDaysSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public int EndDateType { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EndDateTypeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public string EndDate { get; set; }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public int EndDateContext { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EndDateContextSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 9)]
        public int EndDateAnchor { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EndDateAnchorSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 10)]
        public int EndNumberOfDays { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EndNumberOfDaysSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 11)]
        public int EnrollmentPeriodDateType { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EnrollmentPeriodDateTypeSpecified { get; set; }
    }
}
