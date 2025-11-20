using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_UNWRITECLASS_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Standard Risk</summary>
        [XmlEnum("1")]
        OLI_UNWRITE_STANDARD = 1,

        /// <summary>Preferred risk</summary>
        [XmlEnum("2")]
        OLI_UNWRITE_PREFERRED = 2,

        /// <summary>Rated/Substandard Risk</summary>
        [XmlEnum("3")]
        OLI_UNWRITE_RATED = 3,

        /// <summary>Aerobic (super Preferred)</summary>
        [XmlEnum("4")]
        OLI_UNWRITE_AEROBIC = 4,

        /// <summary>Declined</summary>
        /// <remarks>This value has been deprecated A coverage can be declined.</remarks>
        [XmlEnum("5")]
        OLI_UNWRITE_DECLINED = 5,

        /// <summary>Standard Plus (represents level between standard  and preferred).</summary>
        [XmlEnum("6")]
        OLI_UNWRITE_STANDARDPLUS = 6,

        /// <summary>Uninsurable</summary>
        [XmlEnum("7")]
        OLI_UNWRITE_UNINSURABLE = 7,

        /// <summary>PVT ING</summary>
        [XmlEnum("8")]
        OLI_UNWRITE_ING08 = 8,

        /// <summary>PVT ING</summary>
        [XmlEnum("9")]
        OLI_UNWRITE_ING09 = 9,

        /// <summary>PVT ING</summary>
        [XmlEnum("10")]
        OLI_UNWRITE_ING10 = 10,

        /// <summary>PVT ING</summary>
        [XmlEnum("11")]
        OLI_UNWRITE_ING11 = 11,

        /// <summary>PVT ING</summary>
        [XmlEnum("12")]
        OLI_UNWRITE_ING12 = 12,

        /// <summary>PVT ING</summary>
        [XmlEnum("13")]
        OLI_UNWRITE_ING13 = 13,

        /// <summary>PVT ING</summary>
        [XmlEnum("14")]
        OLI_UNWRITE_ING14 = 14,

        /// <summary>PVT ING</summary>
        [XmlEnum("15")]
        OLI_UNWRITE_ING15 = 15,

        /// <summary>PVT ING</summary>
        [XmlEnum("16")]
        OLI_UNWRITE_ING16 = 16,

        /// <summary>PVT ING</summary>
        [XmlEnum("17")]
        OLI_UNWRITE_ING17 = 17,

        /// <summary>Preferred Plus</summary>
        /// <remarks>An Underwriting class code that places an individual between "Preferred" and "Aerobic/super preferred".</remarks>
        [XmlEnum("19")]
        OLI_UNWRITE_PREFPLUS = 19,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
