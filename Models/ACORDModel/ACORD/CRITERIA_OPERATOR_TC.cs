using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum CRITERIA_OPERATOR_TC
    {
        /// <summary>OR Logical OR</summary>
        [XmlEnum("1")]
        LOGICAL_OPERATOR_OR = 1,

        /// <summary>AND - Logical And</summary>
        [XmlEnum("2")]
        LOGICAL_OPERATOR_AND = 2,

        /// <summary>NOT - Logical Not</summary>
        [XmlEnum("3")]
        LOGICAL_OPERATOR_NOT = 3,

        /// <summary>"XOR" (exclusive or) logical operator</summary>
        [XmlEnum("4")]
        LOGICAL_OPERATOR_XOR = 4,
    }
}
