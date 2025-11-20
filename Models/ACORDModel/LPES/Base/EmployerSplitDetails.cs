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
    public partial class EmployerSplitDetails
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string SplitDetailLinkKey { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string RoleName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public double RolePercent { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool RolePercentSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public int RoleType { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool RoleTypeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public int OtherRoleType { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool OtherRoleTypeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public string SplitAgentGUID { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public string SplitAgentClientID { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public string SplitAgentName { get; set; }
    }
}
