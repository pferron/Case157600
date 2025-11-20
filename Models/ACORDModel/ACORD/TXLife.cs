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
    public partial class TXLife
    {
        /// <remarks/>
        [XmlElement("TXLifeRequest", typeof(TXLifeRequest), Order = 0)]
        [XmlElement("TXLifeResponse", typeof(TXLifeResponse), Order = 0)]
        [XmlElement("UserAuthRequest", typeof(UserAuthRequest), Order = 0)]
        [XmlElement("UserAuthResponse", typeof(UserAuthResponse), Order = 0)]
        public object[] Items { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string Version { get; set; }
    }
}
