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
    public partial class dataFieldGroup
    {
        /// <remarks/>
        [XmlElement("dataField", Order = 0)]
        public dataField[] dataField { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string name { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string controlType { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string dataRef { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string required { get; set; }
    }
}
