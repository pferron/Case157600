using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_MEASUREUNITS_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Metric System</summary>
        /// <remarks>Lengths are measured in centimetersWeights are measured in Kilograms</remarks>
        [XmlEnum("1")]
        OLI_MEASURE_METRIC = 1,

        /// <summary>US System Standard</summary>
        /// <remarks>Lengths are measured in inchesWeights are measured in pounds</remarks>
        [XmlEnum("2")]
        OLI_MEASURE_USSTANDARD = 2,

        /// <summary>Alternate US format</summary>
        /// <remarks>Lengths are measured in in feet with decimal being inchesWeights are measured in pounds with decimal being ounces</remarks>
        [XmlEnum("3")]
        OLI_MEASURE_USSECOND = 3,

        /// <summary>Another US method</summary>
        /// <remarks>Lengths are measured in feet with decimal being decimal fraction of feetWeights are measured in pounds with decimal being decimal fraction of pound</remarks>
        [XmlEnum("4")]
        OLI_MEASURE_USTHIRD = 4,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
