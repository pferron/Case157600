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
    public partial class FormCategory
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string FormCategoryID { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string FormCategoryName { get; set; }

        /// <remarks/>
        [XmlElement("Form", Order = 2)]
        public Form[] Form { get; set; }
    }
}
