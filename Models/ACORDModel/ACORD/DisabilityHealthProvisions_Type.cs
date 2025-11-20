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
    [XmlRoot("DisabilityHealthProvisions", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class DisabilityHealthProvisions_Type
    {
        /// <remarks/>
        [XmlElement("ElimPeriodAccOption", Order = 0)]
        public ElimPeriodAccOption_Type[] ElimPeriodAccOption { get; set; }

        /// <remarks/>
        [XmlElement("ElimPeriodSickOption", Order = 1)]
        public ElimPeriodSickOption_Type[] ElimPeriodSickOption { get; set; }

        /// <remarks/>
        [XmlElement("BenePeriodAccOption", Order = 2)]
        public BenePeriodAccOption_Type[] BenePeriodAccOption { get; set; }

        /// <remarks/>
        [XmlElement("BenePeriodSickOption", Order = 3)]
        public BenePeriodSickOption_Type[] BenePeriodSickOption { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", Order = 4)]
        public OLifEExtension[] OLifEExtension { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }
    }
}
