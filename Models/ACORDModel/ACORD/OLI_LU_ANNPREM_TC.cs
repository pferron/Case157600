using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_ANNPREM_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Single</summary>
        /// <remarks>Only one payment is allowed</remarks>
        [XmlEnum("1")]
        OLI_ANNPREM_SINGLE = 1,

        /// <summary>Flexible</summary>
        /// <remarks>Payments of differing amount are allowed. If an annuity is a single premium that allows subsequent payments, it should e identified as flexible.</remarks>
        [XmlEnum("2")]
        OLI_ANNPREM_FLEX = 2,

        /// <summary>Fixed</summary>
        /// <remarks>Regular scheduled payments are required</remarks>
        [XmlEnum("3")]
        OLI_ANNPREM_FIXED = 3,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
