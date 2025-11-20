using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.LPES.Base
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    [XmlRoot(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView", IsNullable = false)]
    public partial class CCDetail
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string ContactEMail { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string ContactName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string ContactPhone { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public string DocumentLeft { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public string ReasonForCC { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public int ReqStatusPIN { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool ReqStatusPINSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public int ReqStatusVoice { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool ReqStatusVoiceSpecified { get; set; }
    }
}
