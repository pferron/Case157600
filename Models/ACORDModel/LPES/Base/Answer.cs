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
    [XmlType(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    public partial class Answer
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public int questionId { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public int answer { get; set; }
    }
}
