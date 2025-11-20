using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_TAXSTAT_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Fully Taxed</summary>
        [XmlEnum("1")]
        OLI_TAXSTAT_FULL = 1,

        /// <summary>Tax Deferred</summary>
        [XmlEnum("2")]
        OLI_TAXSTAT_DEFERRED = 2,

        /// <summary>Tax Exempt</summary>
        [XmlEnum("3")]
        OLI_TAXSTAT_EXEMPT = 3,

        /// <summary>Conforming to State President Regulation</summary>
        /// <remarks>Conforming to standard tax rules / legislation in accordance to State President Regulation.</remarks>
        [XmlEnum("4")]
        OLI_TAXSTAT_CONFPRESREG = 4,

        /// <summary>Nonconforming to State President Regulation</summary>
        /// <remarks>Non-Conforming - a special tax dispensation will be applied</remarks>
        [XmlEnum("5")]
        OLI_TAXSTAT_NONCONFPRESREG = 5,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
