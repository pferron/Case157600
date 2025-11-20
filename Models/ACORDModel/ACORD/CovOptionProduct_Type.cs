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
    [XmlRoot("CovOptionProduct", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class CovOptionProduct_Type
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public decimal MaxAmtOfParent { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MaxAmtOfParentSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public decimal MinAmtOfParent { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MinAmtOfParentSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public decimal MinRatioToParent { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MinRatioToParentSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public decimal MaxRatioToParent { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MaxRatioToParentSpecified { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", Order = 4)]
        public OLifEExtension[] OLifEExtension { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }
    }
}
