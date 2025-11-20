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
    public partial class Address
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public OLI_LU_ADTYPE AddressTypeCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string Line1 { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string Line2 { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public string City { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public string AddressState { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public OLI_LU_STATE AddressStateTC { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public string Zip { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public string CountyName { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", Order = 8)]
        public OLifEExtension[] OLifEExtension { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }
    }
}
