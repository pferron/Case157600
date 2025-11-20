using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_RIDERCAT_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Discount</summary>
        /// <remarks>Rider represents a discount on the base plan.</remarks>
        [XmlEnum("1")]
        OLI_RIDERCAT_DISC = 1,

        /// <summary>Rider</summary>
        /// <remarks>Rider represents a traditional rider.</remarks>
        [XmlEnum("2")]
        OLI_RIDERCAT_RIDER = 2,

        /// <summary>Benefit</summary>
        /// <remarks>Rider represents a benefit or option on the base plan.</remarks>
        [XmlEnum("3")]
        OLI_RIDERCAT_BENE = 3,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
