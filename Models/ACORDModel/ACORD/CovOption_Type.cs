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
    [XmlRoot("CovOption", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class CovOption_Type
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public OLI_LU_POLSTAT CovOptionStatus { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public OLI_LU_OPTTYPE LifeCovOptTypeCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public decimal OptionAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool OptionAmtSpecified { get; set; }
    }
}
