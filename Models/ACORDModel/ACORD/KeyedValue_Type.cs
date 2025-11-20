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
    [XmlRoot("KeyedValue", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class KeyedValue_Type
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string KeyName { get; set; }

        /// <remarks/>
        [XmlElement("KeyValue", Order = 1)]
        public KeyValue[] KeyValue { get; set; }
    }
}
