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
    public partial class MissingRequiredDataForm
    {
        /// <remarks/>
        [XmlArray(Order = 0)]
        [XmlArrayItem("QuestionNumber", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
        public string[] MissingRequiredDataFields { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "IDREF")]
        public string FormID { get; set; }
    }
}
