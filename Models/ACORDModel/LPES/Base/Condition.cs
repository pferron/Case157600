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
    public partial class Condition
    {
        /// <remarks/>
        [XmlElement("Expression", Order = 0)]
        public Expression[] Expression { get; set; }

        /// <remarks/>
        [XmlElement("CoverageDetails", Order = 1)]
        public CoverageDetails[] CoverageDetails { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string FieldType { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string FieldName { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string FieldValue { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string Operator { get; set; }
    }
}
