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
    public partial class CoveredInsuredOption
    {
        /// <remarks/>
        [XmlElement("CoveredInsured", Order = 0)]
        public AWD_LU_COVEREDINSUREDTYPE[] CoveredInsured { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public ControlInfo ControlInfo { get; set; }
    }
}
