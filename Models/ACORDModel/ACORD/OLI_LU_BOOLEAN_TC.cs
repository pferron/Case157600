using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_BOOLEAN_TC
    {
        /// <summary>False</summary>
        [XmlEnum("0")]
        OLI_BOOL_FALSE = 0,

        /// <summary>True</summary>
        [XmlEnum("1")]
        OLI_BOOL_TRUE = 1,
    }
}
