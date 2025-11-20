using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_SUPPSOLVETYPE_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Solving for Amount</summary>
        [XmlEnum("1")]
        ILL_SUPP_SOLVETYPE_AMT = 1,

        /// <summary>Solving for Years</summary>
        [XmlEnum("2")]
        ILL_SUPP_SOLVETYPE_YRS = 2,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
