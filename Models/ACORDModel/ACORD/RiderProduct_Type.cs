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
    [XmlRoot("RiderProduct", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class RiderProduct_Type
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public OLI_LU_RIDERTYPE RiderTypeCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string Description { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "integer", Order = 2)]
        public string MaturityAge { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public string RiderCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public OLI_LU_RIDERCAT RiderCategory { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public OLI_LU_COVUNITTYPE CovUnitType { get; set; }

        /// <remarks/>
        [XmlElement("UnderwritingClassProduct", Order = 6)]
        public UnderwritingClassProduct_Type[] UnderwritingClassProduct { get; set; }

        /// <remarks/>
        [XmlElement("CovOptionProduct", Order = 7)]
        public CovOptionProduct_Type[] CovOptionProduct { get; set; }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public DisabilityHealthProvisions_Type DisabilityHealthProvisions { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", Order = 9)]
        public OLifEExtension[] OLifEExtension { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }
    }
}
