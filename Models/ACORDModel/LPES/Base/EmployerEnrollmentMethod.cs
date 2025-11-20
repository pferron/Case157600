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
    public partial class EmployerEnrollmentMethod
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string EmployerEnrollmentMethodLinkKey { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public int EnrollmentMethod { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EnrollmentMethodSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public int Status { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool StatusSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public LPNamedValuePair LPNamedValuePair { get; set; }
    }
}
