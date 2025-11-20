using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_POLISSUE_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Full Underwriting</summary>
        [XmlEnum("1")]
        OLI_COVISSU_FULL = 1,

        /// <summary>Simplified Underwriting</summary>
        [XmlEnum("2")]
        OLI_COVISSU_SIMP = 2,

        /// <summary>Guaranteed Issue</summary>
        [XmlEnum("3")]
        OLI_COVISSU_GUAR = 3,

        /// <summary>Field Issue</summary>
        [XmlEnum("4")]
        OLI_COVISSU_FIELDISSUE = 4,

        /// <summary>Financial Underwriting</summary>
        [XmlEnum("5")]
        OLI_COVISSU_FINANCIALUNDERWRITTEN = 5,

        /// <summary>Mass Underwriting</summary>
        [XmlEnum("6")]
        OLI_COVISSU_MASSUNDERWRITING = 6,

        /// <summary>Reduced Underwriting</summary>
        [XmlEnum("7")]
        OLI_COVISSU_REDUCEDUNDERWRITING = 7,

        /// <summary>Blended (Policy has Underwritten and Guaranteed Issue coverages.) Only applies at Policy Level</summary>
        [XmlEnum("8")]
        OLI_COVISSU_PERCOVERAGE = 8,

        /// <summary>Conversion - No underwriting done</summary>
        [XmlEnum("9")]
        OLI_COVISSU_CONVERTED = 9,

        /// <summary>Aviation</summary>
        /// <remarks>Underwriting rules used to issue the coverage are specific to those required to issue aviation based life insurance</remarks>
        [XmlEnum("10")]
        OLI_COVISSU_AVIATION = 10,

        /// <summary>Conversion -  Non-contractual</summary>
        /// <remarks>Non-contractual conversion - Underwriting is needed</remarks>
        [XmlEnum("11")]
        OLI_COVISSU_NONCNTRCTCONVERT = 11,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
