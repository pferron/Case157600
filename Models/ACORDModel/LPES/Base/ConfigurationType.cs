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
    public partial class ConfigurationType
    {
        /// <remarks/>
        [XmlAttribute()]
        public AWD_TEMPLATE_CONFIGURATION_TYPE_TC tc { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool tcSpecified { get; set; }

        /// <remarks/>
        [XmlText()]
        public string Value { get; set; }
    }
}
