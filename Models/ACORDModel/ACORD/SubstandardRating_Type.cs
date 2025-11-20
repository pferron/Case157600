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
    [XmlRoot("SubstandardRating", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class SubstandardRating_Type
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public OLI_LU_RATINGS PermTableRating { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 1)]
        public DateTime PermTableRatingEndDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool PermTableRatingEndDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public OLI_LU_RATINGS TempTableRating { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 3)]
        public DateTime TempTableRatingStartDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool TempTableRatingStartDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 4)]
        public DateTime TempTableRatingEndDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool TempTableRatingEndDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 5)]
        public DateTime TempFlatStartDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool TempFlatStartDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 6)]
        public DateTime TempFlatEndDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool TempFlatEndDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public decimal TempFlatExtraAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool TempFlatExtraAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public decimal PermFlatExtraAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool PermFlatExtraAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 9)]
        public DateTime PermFlatExtraEndDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool PermFlatExtraEndDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", Order = 10)]
        public OLifEExtension[] OLifEExtension { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }
    }
}
