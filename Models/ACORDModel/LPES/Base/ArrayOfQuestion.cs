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
    [XmlRoot("childQuestions", Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView", IsNullable = false)]
    public partial class ArrayOfQuestion
    {
        /// <remarks/>
        [XmlElement("Question", Order = 0)]
        public Question[] Question { get; set; }
    }
}
