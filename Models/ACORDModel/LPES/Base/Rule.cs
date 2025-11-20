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
    public partial class Rule
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public ValidValues ValidValues { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public Conditions Conditions { get; set; }

        /// <remarks/>
        [XmlElement("CoverageDetailsGroup", Order = 2)]
        public CoverageDetailsGroup[] CoverageDetailsGroup { get; set; }

        /// <remarks/>
        [XmlElement("CoverageDetails", Order = 3)]
        public CoverageDetails[] CoverageDetails { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public int RuleID { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public int RuleTypeID { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string RuleType { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string ErrorMsg { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string Scope { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public int PartyAppliesTo { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool PartyAppliesToSpecified { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public int CoverageMatchNum { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool CoverageMatchNumSpecified { get; set; }
    }
}
