using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_COVUNITTYPE_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Currency of the Plan</summary>
        [XmlEnum("1")]
        OLI_COVUNIT_CURRENCY = 1,

        /// <summary>Coverage is specified in Units or Fractional Units</summary>
        [XmlEnum("2")]
        OLI_COVUNIT_UNITS = 2,

        /// <summary>Percentage</summary>
        [XmlEnum("3")]
        OLI_COVUNIT_PERCENT = 3,

        /// <summary>Not specified</summary>
        [XmlEnum("4")]
        OLI_COVUNIT_NONE = 4,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
