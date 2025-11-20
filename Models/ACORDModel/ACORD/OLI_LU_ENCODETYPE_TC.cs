using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_ENCODETYPE_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>X-Token</summary>
        [XmlEnum("1")]
        OLI_ENCODE_X_TOKEN = 1,

        /// <summary>IETF-Token</summary>
        [XmlEnum("2")]
        OLI_ENCODE_IETF_TOKEN = 2,

        /// <summary>Base24</summary>
        [XmlEnum("3")]
        OLI_ENCODE_BASE24 = 3,

        /// <summary>Base64</summary>
        [XmlEnum("4")]
        OLI_ENCODE_BASE64 = 4,

        /// <summary>Quoted- Printable</summary>
        [XmlEnum("5")]
        OLI_ENCODE_QUOTED_PRINTABLE = 5,

        /// <summary>Binary</summary>
        [XmlEnum("6")]
        OLI_ENCODE_BINARY = 6,

        /// <summary>8bit</summary>
        [XmlEnum("7")]
        OLI_ENCODE_8BIT = 7,

        /// <summary>7bit</summary>
        [XmlEnum("8")]
        OLI_ENCODE_7BIT = 8,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
