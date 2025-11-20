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
    public partial class EmployerClassPackage
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string EmployerClassPackageLinkKey { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public LPNamedValuePair LPNamedValuePair { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public EmployerProductPackage EmployerProductPackage { get; set; }

        /// <remarks/>
        [XmlElement("EmployerEnrollmentPeriodPackage", Order = 3)]
        public EmployerEnrollmentPeriodPackage[] EmployerEnrollmentPeriodPackage { get; set; }
    }
}
