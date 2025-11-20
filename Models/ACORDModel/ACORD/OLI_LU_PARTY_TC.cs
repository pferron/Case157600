using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_PARTY_TC
    {
        /// <summary></summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Person</summary>
        [XmlEnum("1")]
        OLI_PT_PERSON = 1,

        /// <summary>Organization</summary>
        [XmlEnum("2")]
        OLI_PT_ORG = 2,
    }
}
