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
    public partial class Rider
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public OLI_LU_RIDERTYPE RiderTypeCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string Description { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string RiderCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public decimal TotAmt { get; set; }

        /// <remarks/>
        [XmlElement("Participant", Order = 4)]
        public Participant[] Participant { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", Order = 5)]
        public OLifEExtension[] OLifEExtension { get; set; }
    }
}
