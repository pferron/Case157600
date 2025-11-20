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
    [XmlRoot("IllustrationResult", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class IllustrationResult_Type
    {
        /// <remarks/>
        [XmlElement("ResultBasis", Order = 0)]
        public ResultBasis_Type[] ResultBasis { get; set; }

        /// <remarks/>
        [XmlElement("Attachment", Order = 1)]
        public Attachment[] Attachment { get; set; }
    }
}
