using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_SMOKERSTAT_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Never used tobacco in any form.</summary>
        [XmlEnum("1")]
        OLI_TOBACCO_NEVER = 1,

        /// <summary>Prior tobacco user</summary>
        [XmlEnum("2")]
        OLI_TOBACCO_PRIOR = 2,

        /// <summary>Current tobacco user</summary>
        [XmlEnum("3")]
        OLI_TOBACCO_CURRENT = 3,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
