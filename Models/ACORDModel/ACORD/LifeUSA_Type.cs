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
    [XmlRoot("LifeUSA", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class LifeUSA_Type
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public OLI_LU_BOOLEAN MECInd { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public decimal SevenPayPrem { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool SevenPayPremSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public decimal CumSevenPayPrem { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool CumSevenPayPremSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public decimal Amount1035 { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool Amount1035Specified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public decimal Basis1035 { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool Basis1035Specified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public OLI_LU_BOOLEAN MEC1035 { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 6)]
        public DateTime? SevenPayPremStartDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool SevenPayPremStartDateSpecified { get { return SevenPayPremStartDate != null; } }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }
    }
}
