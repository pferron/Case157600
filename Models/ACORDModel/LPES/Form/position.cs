using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.LPES.Form
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.fiservinsurance.com/LPES/Form")]
    [XmlRoot(Namespace = "http://www.fiservinsurance.com/LPES/Form", IsNullable = false)]
    public partial class position
    {
        /// <remarks/>
        [XmlAttribute()]
        public decimal bottom { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public decimal top { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public decimal right { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public decimal left { get; set; }
    }
}
