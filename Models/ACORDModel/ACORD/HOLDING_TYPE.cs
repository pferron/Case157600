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
    [XmlRoot("Holding", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class HOLDING_TYPE
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public OLI_LU_HOLDTYPE HoldingTypeCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public OLI_LU_HOLDSTAT HoldingStatus { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public Policy Policy { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public Investment_Type Investment { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", Order = 4)]
        public OLifEExtension[] OLifEExtension { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }
    }
}
