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
    public partial class EmployerGrpEnrollSplit
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        [CLSCompliant(false)]
        public sbyte AgtRoleType { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool AgtRoleTypeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string AgtID { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string AgtGUID { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public string AgtName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public double AgtRolePercent { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool AgtRolePercentSpecified { get; set; }
    }
}
