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
    public partial class EB_ExistingCoverage
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string EB_CoverageID { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public long EB_CoverageSequence { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EB_CoverageSequenceSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string EB_EAPPlanCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public string EB_ABPlanCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public string EB_ABPlanDesc { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public double EB_PolicyUnits { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EB_PolicyUnitsSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public double EB_FaceAmount { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EB_FaceAmountSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 7)]
        public System.DateTime EB_IssueDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EB_IssueDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 8)]
        public System.DateTime EB_CoverageCreatedDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EB_CoverageCreatedDateSpecified { get; set; }
    }
}
