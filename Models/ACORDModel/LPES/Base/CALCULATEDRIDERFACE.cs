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
    public partial class CALCULATEDRIDERFACE
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public double AMT { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public AWD_LU_RIDERTYPE FIPRiderType { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public AWD_LU_SUBRIDERTYPE FIPRiderSubType { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public string FIPRiderShortName { get; set; }
    }
}
