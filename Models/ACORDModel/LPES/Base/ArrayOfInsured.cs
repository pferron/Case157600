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
    [XmlRoot("insureds", Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView", IsNullable = false)]
    public partial class ArrayOfInsured
    {
        /// <remarks/>
        [XmlElement("Insured", Order = 0)]
        public Insured[] Insured { get; set; }
    }
}
