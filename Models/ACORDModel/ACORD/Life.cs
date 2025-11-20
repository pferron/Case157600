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
    public partial class Life
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public decimal InitDepositAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool InitDepositAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public decimal InitialPremAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool InitialPremAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement("Coverage", Order = 2)]
        public Coverage[] Coverage { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public LifeUSA_Type LifeUSA { get; set; }
    }
}
