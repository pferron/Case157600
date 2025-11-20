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
    [XmlRoot("PolicyProduct", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class PolicyProduct_Type
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string CarrierCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string CarrierName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string PlanName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public string ProductCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public string ShortName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public OLI_LU_POLPROD PolicyProductTypeCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public OLI_LU_HOLDINGFORM PolicyProductForm { get; set; }

        /// <remarks/>
        [XmlElement("PaymentModeMethProduct", Order = 7)]
        public PaymentModeMethProduct_Type[] PaymentModeMethProduct { get; set; }

        /// <remarks/>
        [XmlElement("DisabilityHealthProduct", typeof(DisabilityHealthProduct_Type), Order = 8)]
        [XmlElement("LifeProduct", typeof(LifeProduct_Type), Order = 8)]
        public object Item { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", Order = 9)]
        public OLifEExtension[] OLifEExtension { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "IDREF")]
        public string PartyID { get; set; }
    }
}
