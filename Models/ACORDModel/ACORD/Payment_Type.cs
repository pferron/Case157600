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
    [XmlRoot("Payment", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class Payment_Type
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public decimal PaymentAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool PaymentAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public OLI_LU_SOURCEOFFUNDS SourceOfFundsTC { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public OLI_LU_BOOLEAN PaymentPartialInd { get; set; }

        /// <remarks/>
        [XmlElement("KeyedValue", Order = 3)]
        public KeyedValue_Type[] KeyedValue { get; set; }
    }
}
