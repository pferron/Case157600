using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    [XmlRoot("LifeParticipantRoleCode", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class OLI_LU_PARTICROLE
    {
        /// <remarks/>
        [XmlAttribute()]
        public OLI_LU_PARTICROLE_TC tc { get; set; }

        /// <remarks/>
        [XmlText()]
        public string Value { get; set; }
    }
}
