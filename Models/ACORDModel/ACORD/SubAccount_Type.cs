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
    [XmlRoot("SubAccount", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class SubAccount_Type
    {
        /// <remarks/>
        [XmlAttribute()]
        public string id { get; set; }

        /// <remarks/>
        [XmlElement(Order = 0)]
        public string ProductCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string ProductFullName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string AllocPercent { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public double BaseRate { get; set; }


    }
}
