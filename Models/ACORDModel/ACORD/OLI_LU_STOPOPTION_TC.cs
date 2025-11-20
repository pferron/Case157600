using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_STOPOPTION_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Number of years.</summary>
        /// <remarks>Run illustration for a specified number of years.</remarks>
        [XmlEnum("1")]
        OLI_STOPOPTION_NUMYEARS = 1,

        /// <summary>Attained age.</summary>
        /// <remarks>Run illustration to a specified attained age of the primary insured or the annuitant.</remarks>
        [XmlEnum("2")]
        OLI_STOPOPTION_ATTAGE = 2,

        /// <summary>Maturity.</summary>
        /// <remarks>Run illustration to the natural contract maturity.</remarks>
        [XmlEnum("3")]
        OLI_STOPOPTION_MATURITY = 3,

        /// <summary>Age next birthday</summary>
        /// <remarks>Run illustration to the specified age next birthday of the primary insured or the annuitant.</remarks>
        [XmlEnum("4")]
        OLI_STOPOPTION_ANB = 4,

        /// <summary>End of the premium term.</summary>
        /// <remarks>Run illustration to the end of the premium term.</remarks>
        [XmlEnum("5")]
        OLI_STOPOPTION_PREMTERM = 5,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
