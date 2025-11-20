using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_ILLUSREPORTTYPE_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Basic Illustration</summary>
        /// <remarks>The basic illustration for this product.  For products regulated by NAIC this will consist of a narrative summary, a numeric summary, and a tabular detail</remarks>
        [XmlEnum("1")]
        ILL_REP_BASIC = 1,

        /// <summary>Annual Statement</summary>
        /// <remarks>Policy Holder's Annual Statement</remarks>
        [XmlEnum("2")]
        IL_REP_ANNSTATEMENT = 2,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
