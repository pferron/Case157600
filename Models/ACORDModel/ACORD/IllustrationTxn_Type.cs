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
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    [XmlRoot("IllustrationTxn", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class IllustrationTxn_Type
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public TC_ILLUSPRIMTYPE IllusTxnPrimaryType { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public TC_ILLUSSECTYPE IllusTxnSecondaryType { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public TC_ILLUSTERTTYPE IllusTxnTertiaryType { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public decimal IllusTxnAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool IllusTxnAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public OLI_LU_PAYMODE IllusTxnMode { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 5)]
        public DateTime StartDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool StartDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 6)]
        public DateTime EndDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EndDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public double IncreasePercent { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool IncreasePercentSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public OLI_LU_SUPPSOLVETYPE SuppSolveType { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", typeof(AcordIllustrationTxnExtension), Order = 9)]
        public OLifEExtension[] OLifEExtension { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "IDREF")]
        public string CoverageID { get; set; }
    }
}
