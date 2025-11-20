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
    public partial class Person
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string FirstName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string MiddleName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string LastName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public string Prefix { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public string Suffix { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public string Title { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public string Occupation { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public OLI_LU_MARSTAT MarStat { get; set; }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public OLI_LU_GENDER Gender { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 9)]
        public DateTime BirthDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool BirthDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 10)]
        public OLI_LU_BOOLEAN DOBEstimated { get; set; }

        /// <remarks/>
        [XmlElement(Order = 11)]
        public string Age { get; set; }

        /// <remarks/>
        [XmlElement(Order = 12)]
        public OLI_LU_SMOKERSTAT SmokerStat { get; set; }

        /// <remarks/>
        [XmlElement(Order = 13)]
        public OLI_LU_OCCUPCLASS OccupClass { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "integer", Order = 14)]
        public string Height { get; set; }

        /// <remarks/>
        [XmlElement(Order = 15)]
        public double Weight { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool WeightSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 16)]
        public Height2_Type Height2 { get; set; }

        /// <remarks/>
        [XmlElement(Order = 17)]
        public Weight2_Type Weight2 { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 18)]
        public DateTime TobaccoFree { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool TobaccoFreeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 19)]
        public string DriversLicenseNum { get; set; }

        /// <remarks/>
        [XmlElement(Order = 20)]
        public OLI_LU_STATE DriversLicenseState { get; set; }

        /// <remarks/>
        [XmlElement(Order = 21)]
        public OLI_LU_NATION DriversLicenseCountry { get; set; }

        /// <remarks/>
        [XmlElement(Order = 22)]
        public OLI_LU_NATION BirthCountry { get; set; }

        /// <remarks/>
        [XmlElement(Order = 23)]
        public string BirthJurisdiction { get; set; }

        /// <remarks/>
        [XmlElement(Order = 24)]
        public OLI_LU_STATE BirthJurisdictionTC { get; set; }

        /// <remarks/>
        [XmlElement(Order = 25)]
        public decimal EstSalary { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EstSalarySpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 26)]
        public decimal EstGrossAnnualOtherIncome { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EstGrossAnnualOtherIncomeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 27)]
        public decimal NetIncomeAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool NetIncomeAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 28)]
        public DateTime VisaExpDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool VisaExpDateSpecified { get; set; }
    }
}
