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
    [XmlRoot("PaymentModeMethProduct", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class PaymentModeMethProduct_Type
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public OLI_LU_PAYMODE PaymentMode { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", Order = 1)]
        public OLifEExtension[] OLifEExtension { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }
    }
}
