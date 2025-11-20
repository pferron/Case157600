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
    public partial class EmployerGrpEnrollContribute
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string EnrollContributeLinkKey { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public long ProductType { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool ProductTypeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        [CLSCompliant(false)]
        public sbyte EEContributeType { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EEContributeTypeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public double EEContributeAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EEContributeAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        [CLSCompliant(false)]
        public sbyte DepContributeType { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool DepContributeTypeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public double DepContributeAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool DepContributeAmtSpecified { get; set; }
    }
}
