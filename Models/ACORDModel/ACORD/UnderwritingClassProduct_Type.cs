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
    [XmlRoot("UnderwritingClassProduct", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class UnderwritingClassProduct_Type
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public OLI_LU_UNWRITECLASS UnderwritingClass { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public OLI_LU_TOBPREMBASIS TobaccoPremiumBasis { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "integer", Order = 2)]
        public string MinIssueAge { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "integer", Order = 3)]
        public string MaxIssueAge { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public decimal MinIssueAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MinIssueAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public decimal MaxIssueAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MaxIssueAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public string ClassName { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "integer", Order = 7)]
        public string MaxIssueUnits { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "integer", Order = 8)]
        public string MinIssueUnits { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", Order = 9)]
        public OLifEExtension[] OLifEExtension { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }
    }
}
