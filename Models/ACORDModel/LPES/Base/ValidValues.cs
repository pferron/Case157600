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
    public partial class ValidValues
    {
        /// <remarks/>
        [XmlArray(Order = 0)]
        [XmlArrayItem("Expression", typeof(Expression), IsNullable = false)]
        public Expression[] ValidValue { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string Operator { get; set; }
    }
}
