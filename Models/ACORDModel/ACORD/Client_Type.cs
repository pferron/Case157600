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
    [XmlRoot("Client", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class Client_Type
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public OLI_LU_CLIENTLANGUAGES PrefLanguage { get; set; }

        /// <remarks/>
        [XmlElement("KeyedValue", Order = 1)]
        public KeyedValue_Type[] KeyedValue { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", Order = 2)]
        public OLifEExtension[] OLifEExtension { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }
    }
}
