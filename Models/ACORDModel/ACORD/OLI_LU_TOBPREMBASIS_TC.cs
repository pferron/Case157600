using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_TOBPREMBASIS_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Non Smoker</summary>
        [XmlEnum("1")]
        OLI_TOBPREMBASIS_NONSMOKER = 1,

        /// <summary>Smoker</summary>
        [XmlEnum("2")]
        OLI_TOBPREMBASIS_SMOKER = 2,

        /// <summary>Non tobacco user i.e. snuff</summary>
        [XmlEnum("3")]
        OLI_TOBPREMBASIS_NONTOBACCO = 3,

        /// <summary>Tobacco user is snuff</summary>
        [XmlEnum("4")]
        OLI_TOBPREMBASIS_TOBACCO = 4,

        /// <summary>Blended Rate could be smoker, tobacco user, both, or non user.</summary>
        [XmlEnum("5")]
        OLI_TOBPREMBASIS_BLENDED = 5,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
