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
    public partial class Form
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public int FormCode { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool FormCodeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string FormName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string FormFile { get; set; }
    }
}
