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
    [XmlRoot(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView", IsNullable = false)]
    public partial class ReflexiveQuestionData
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public int totalPages { get; set; }

        /// <remarks/>
        [XmlElement("insureds", typeof(ArrayOfInsured), Order = 1)]
        [XmlElement("pages", typeof(ArrayOfPage), Order = 1)]
        [XmlElement("questions", typeof(ArrayOfQuestion1), Order = 1)]
        [XmlElement("sections", typeof(ArrayOfSection), Order = 1)]
        public object[] Items { get; set; }
    }
}
