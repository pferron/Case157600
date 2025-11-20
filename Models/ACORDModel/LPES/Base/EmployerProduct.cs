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
    public partial class EmployerProduct
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string EmployerProductLinkKey { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public bool IsCRate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool IsCRateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public bool IsGI { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool IsGISpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public bool IsSCGI { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool IsSCGISpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public int Section125 { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool Section125Specified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public int Section125Lock { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool Section125LockSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public bool IsTakeOver { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool IsTakeOverSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public bool IsNewRate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool IsNewRateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public bool EmployerContribution { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EmployerContributionSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 9)]
        public bool EmployerContributionNon { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EmployerContributionNonSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 10)]
        public int ProductID { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool ProductIDSpecified { get; set; }

        /// <remarks/>
        [XmlElement("EmployerProductPackage", Order = 11)]
        public EmployerProductPackage[] EmployerProductPackage { get; set; }

        /// <remarks/>
        [XmlElement(Order = 12)]
        public EmployerGrpEnrollContribute EmployerGrpEnrollContribute { get; set; }

        /// <remarks/>
        [XmlElement("Template", Order = 13)]
        public Template[] Template { get; set; }
    }
}
