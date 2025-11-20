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
    [XmlRoot("CoverageProduct", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class CoverageProduct_Type
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string ProductCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string ShortName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public OLI_LU_COVINDCODE IndicatorCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public DeathBenefitOptCC_Type DeathBenefitOptCC { get; set; }

        /// <remarks/>
        [XmlArray(Order = 4)]
        [XmlArrayItem("IssueGender", IsNullable = false)]
        public OLI_LU_GENDER[] IssueGenderCC { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public OLI_LU_COVUNITTYPE CovUnitType { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public decimal MaxAmtOfBase { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MaxAmtOfBaseSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public decimal MinAmtOfBase { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MinAmtOfBaseSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public decimal MinRatioToBase { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MinRatioToBaseSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 9)]
        public decimal MaxRatioToBase { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MaxRatioToBaseSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "integer", Order = 10)]
        public string MaturityAge { get; set; }

        /// <remarks/>
        [XmlElement(Order = 11)]
        public decimal MaxFlatExtra { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MaxFlatExtraSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 12)]
        public OLI_LU_COVTYPE LifeCovTypeCode { get; set; }

        /// <remarks/>
        [XmlElement("UnderwritingClassProduct", Order = 13)]
        public UnderwritingClassProduct_Type[] UnderwritingClassProduct { get; set; }

        /// <remarks/>
        [XmlElement(Order = 14)]
        public DisabilityHealthProvisions_Type DisabilityHealthProvisions { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", Order = 15)]
        public OLifEExtension[] OLifEExtension { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }
    }
}
