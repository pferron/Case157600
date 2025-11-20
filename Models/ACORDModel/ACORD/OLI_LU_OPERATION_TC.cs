using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_OPERATION_TC
    {
        /// <summary>Is equal to</summary>
        [XmlEnum("1")]
        OLI_OP_EQUAL = 1,

        /// <summary>Not equal</summary>
        [XmlEnum("2")]
        OLI_OP_NOTEQUAL = 2,

        /// <summary>Less Than</summary>
        [XmlEnum("3")]
        OLI_OP_LESSTHAN = 3,

        /// <summary>Greater Than</summary>
        [XmlEnum("4")]
        OLI_OP_GREATERTHAN = 4,

        /// <summary>Less than or equal to</summary>
        [XmlEnum("5")]
        OLI_OP_LESSTHANEQUALTO = 5,

        /// <summary>Greater than or equal to</summary>
        [XmlEnum("6")]
        OLI_OP_GREATERTHANEQUALTO = 6,

        /// <summary>Like</summary>
        [XmlEnum("7")]
        OLI_OP_LIKE = 7,

        /// <summary>Not like</summary>
        [XmlEnum("8")]
        OLI_OP_NOTLIKE = 8,

        /// <summary>Similar to "Like" except allows searches for wildcards and sub-strings</summary>
        [XmlEnum("9")]
        LOGICAL_OPERATOR_WILDCARDMATCH = 9,

        /// <summary>Phonetic</summary>
        /// <remarks>Used to request a phonetic search.</remarks>
        [XmlEnum("10")]
        OLI_OPERATION_PHONETIC = 10,

        /// <summary>Thesaurus</summary>
        /// <remarks>Used to request a thesaurus search.</remarks>
        [XmlEnum("11")]
        OLI_OPERATION_THESAURUS = 11,

        /// <summary>Constrained Like</summary>
        /// <remarks>Constrained Like</remarks>
        [XmlEnum("12")]
        OLI_OP_CONSTRAINEDLIKE = 12,
    }
}
