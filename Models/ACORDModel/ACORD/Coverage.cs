using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using WOW.Illustration.Model.LPES.OLifeExtensions;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://ACORD.org/Standards/Life/2")]
    [XmlRoot(Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class Coverage
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string PlanName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string ShortName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string ProductCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public OLI_LU_POLSTAT LifeCovStatus { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public OLI_LU_COVTYPE LifeCovTypeCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public OLI_LU_COVINDCODE IndicatorCode { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "integer", Order = 6)]
        public string DurationDesign { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public OLI_LU_DTHBENETYPE DeathBenefitOptType { get; set; }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public decimal CurrentAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool CurrentAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 9)]
        public decimal InitCovAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool InitCovAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 10)]
        public decimal ModalPremAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool ModalPremAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 11)]
        public DateTime EffDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EffDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 12)]
        public DateTime TermDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool TermDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement("CovOption", Order = 13)]
        public CovOption_Type[] CovOption { get; set; }

        /// <remarks/>
        [XmlElement("LifeParticipant", Order = 14)]
        public LifeParticipant[] LifeParticipant { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "integer", Order = 15)]
        public string Duration { get; set; }

        /// <remarks/>
        [XmlElement(Order = 16)]
        public OLI_LU_LINEBUS LineOfBusiness { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", typeof(AcordCoverageExtension), Order = 17)]
        public OLifEExtension[] OLifEExtension { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }
    }
}
