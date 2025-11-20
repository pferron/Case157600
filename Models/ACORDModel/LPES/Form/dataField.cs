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
    public partial class dataField
    {
        /// <remarks/>
        [XmlElement("items", typeof(items), Order = 0)]
        [XmlElement("position", typeof(position), Order = 0)]
        public object[] Items { get; set; }

        /// <remarks/>
        [XmlText()]
        public string[] Text { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string name { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public bool multipleLine { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public int maxLength { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool maxLengthSpecified { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string dataRef { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string screenText { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string dataFormat { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string origDataFormat { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string dataType { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string controlType { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public int visibility { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool visibilitySpecified { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public int valueType { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool valueTypeSpecified { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string checkValue { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public bool required { get; set; }
    }
}
