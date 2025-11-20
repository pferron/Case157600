using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_GENDER_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Male</summary>
        [XmlEnum("1")]
        OLI_GENDER_MALE = 1,

        /// <summary>Female</summary>
        [XmlEnum("2")]
        OLI_GENDER_FEMALE = 2,

        /// <summary>Unisex</summary>
        [XmlEnum("3")]
        OLI_GENDER_UNISEX = 3,

        /// <summary>Issued on a combined rate blended from male and female</summary>
        [XmlEnum("4")]
        OLI_GENDER_COMBINED = 4,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
