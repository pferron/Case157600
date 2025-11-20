using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.LPES.Base
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    [XmlRoot(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView", IsNullable = false)]
    public partial class EmployerCaseProduct
    {
        /// <remarks/>
        [XmlElement(Namespace = "http://ACORD.org/Standards/Life/2", Order = 0)]
        public string ProductCode { get; set; }

        /// <remarks/>
        [XmlElement(Namespace = "http://ACORD.org/Standards/Life/2", Order = 1)]
        public string PlanName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public int Section125 { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool Section125Specified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        [CLSCompliant(false)]
        public sbyte TakeOverStatus { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool TakeOverStatusSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        [CLSCompliant(false)]
        public sbyte SCGIFlag { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool SCGIFlagSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        [CLSCompliant(false)]
        public sbyte CompRateFlag { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool CompRateFlagSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        [CLSCompliant(false)]
        public sbyte GIFlag { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool GIFlagSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        [CLSCompliant(false)]
        public sbyte ExceedUwOffer { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool ExceedUwOfferSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 8)]
        [CLSCompliant(false)]
        public sbyte SICFlag { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool SICFlagSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 9)]
        [CLSCompliant(false)]
        public sbyte DINewRateFlag { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool DINewRateFlagSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 10)]
        [CLSCompliant(false)]
        public sbyte EEPaidContribution { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EEPaidContributionSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 11)]
        public double EEPaidContributionPct { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EEPaidContributionPctSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 12)]
        [CLSCompliant(false)]
        public sbyte ERPaidContribution { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool ERPaidContributionSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 13)]
        public double ERPaidContributionPct { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool ERPaidContributionPctSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 14)]
        public CasePlanSCGIDetails CasePlanSCGIDetails { get; set; }
    }
}
