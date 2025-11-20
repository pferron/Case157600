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
    public partial class TransResult
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public RESULT_CODES ResultCode { get; set; }

        /// <remarks/>
        [XmlElement("ResultInfo", Order = 1)]
        public ResultInfo[] ResultInfo { get; set; }
    }
}
