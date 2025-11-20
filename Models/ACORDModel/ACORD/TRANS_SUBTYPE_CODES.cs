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
    [XmlRoot("TransSubType", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class TRANS_SUBTYPE_CODES
    {
        /// <remarks/>
        [XmlAttribute()]
        public TRANS_SUBTYPE_CODES_TC tc { get; set; }

        /// <remarks/>
        [XmlText()]
        public string Value { get; set; }
    }
}
