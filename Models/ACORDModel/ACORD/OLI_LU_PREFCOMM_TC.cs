using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_PREFCOMM_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Phone</summary>
        [XmlEnum("1")]
        OLI_PREFCOMM_PHONE = 1,

        /// <summary>Fax</summary>
        [XmlEnum("2")]
        OLI_PREFCOMM_FAX = 2,

        /// <summary>E-Mail</summary>
        [XmlEnum("3")]
        OLI_PREFCOMM_EMAIL = 3,

        /// <summary>Regular Mail</summary>
        [XmlEnum("4")]
        OLI_PREFCOMM_MAIL = 4,

        /// <summary>Don't Contact</summary>
        [XmlEnum("5")]
        OLI_PREFCOMM_NONE = 5,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
