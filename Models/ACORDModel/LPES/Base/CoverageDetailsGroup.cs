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
    public partial class CoverageDetailsGroup
    {
        /// <remarks/>
        [XmlElement("CoverageDetails", Order = 0)]
        public CoverageDetails[] CoverageDetails { get; set; }

        /// <remarks/>
        [XmlElement("CoverageDetailsGroup", Order = 1)]
        public CoverageDetailsGroup[] CoverageDetailsGroup1 { get; set; }

        /// <remarks/>
        [XmlElement("Conditions", Order = 2)]
        public Conditions[] Conditions { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string Operator { get; set; }
    }
}
