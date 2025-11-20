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
    [XmlRoot("Payout", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class Payout_Type
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public OLI_LU_INCOPTION IncomeOption { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public decimal PayoutAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool PayoutAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public double PayoutPct { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool PayoutPctSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public OLI_LU_PAYMODE PayoutMode { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "integer", Order = 4)]
        public string PayoutAge { get; set; }

        /// <remarks/>
        [XmlElement("Participant", Order = 5)]
        public Participant[] Participant { get; set; }

        /// <remarks/>
        [XmlElement("PeriodCertainCC", Order = 6)]
        public PeriodCertainCC_Type[] PeriodCertainCC { get; set; }
    }
}
