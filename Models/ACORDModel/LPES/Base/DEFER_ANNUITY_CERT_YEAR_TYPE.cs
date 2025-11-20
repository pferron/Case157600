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
    [XmlRoot("DeferAnnuityCertYear", Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView", IsNullable = false)]
    public partial class DEFER_ANNUITY_CERT_YEAR_TYPE
    {
        /// <remarks/>
        [XmlAttribute()]
        public DEFER_ANNUITY_CERT_YEAR_TYPE_TC tc { get; set; }

        /// <remarks/>
        [XmlText()]
        public string Value { get; set; }
    }
}
