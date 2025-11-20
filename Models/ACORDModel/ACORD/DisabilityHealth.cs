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
    public partial class DisabilityHealth
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public decimal BenefitAmtAcc { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool BenefitAmtAccSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public decimal BenefitAmtSick { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool BenefitAmtSickSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public decimal BenefitAmtMaximum { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool BenefitAmtMaximumSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public OLI_LU_BENEPERIOD BenefitPeriodAcc { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public OLI_LU_BENEPERIOD BenefitPeriodSick { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public OLI_LU_ELIMPERIOD ElimPeriodAcc { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public OLI_LU_ELIMPERIOD ElimPeriodSick { get; set; }

        /// <remarks/>
        [XmlElement("Rider", Order = 7)]
        public Rider[] Rider { get; set; }

        /// <remarks/>
        [XmlElement("Participant", Order = 8)]
        public Participant[] Participant { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", Order = 9)]
        public OLifEExtension[] OLifEExtension { get; set; }
    }
}
