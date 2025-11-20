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
    public partial class ResultInfo
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public RESULT_INFO_CODES ResultInfoCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string ResultInfoDesc { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public OLifEExtension OLifEExtension { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string ProblemRef { get; set; }
    }
}
