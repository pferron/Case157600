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
    [XmlRoot("LifeProduct", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class LifeProduct_Type
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public decimal MinModalPayment { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MinModalPaymentSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public decimal MinSingleWithdrawal { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MinSingleWithdrawalSpecified { get; set; }

        /// <remarks/>
        [XmlElement("CoverageProduct", Order = 2)]
        public CoverageProduct_Type[] CoverageProduct { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public LifeUSAProduct_Type LifeUSAProduct { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", Order = 4)]
        public OLifEExtension[] OLifEExtension { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }
    }
}
