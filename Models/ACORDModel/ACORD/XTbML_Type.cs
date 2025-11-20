using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    [XmlRoot("XTbML", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class XTbML_Type
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public ContentClassification_Type ContentClassification { get; set; }

        /// <remarks/>
        [XmlElement("Table", Order = 1)]
        public Table_Type[] Table { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string Version { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }
    }
}
