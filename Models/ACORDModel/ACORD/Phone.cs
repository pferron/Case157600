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
    [XmlType(AnonymousType = true, Namespace = "http://ACORD.org/Standards/Life/2")]
    [XmlRoot(Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class Phone
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public OLI_LU_PHONETYPE PhoneTypeCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string AreaCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string DialNumber { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public string Ext { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", Order = 4)]
        public OLifEExtension[] OLifEExtension { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }
    }
}
