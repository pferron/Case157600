using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.LPES.Base
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    public enum SOLVE_INTEREST_BASIS_TC
    {
        /// <remarks/>
        [XmlEnum("0")]
        Guaranteed,

        /// <remarks/>
        [XmlEnum("1")]
        Item1,

        /// <remarks/>
        [XmlEnum("2")]
        NonGuaranteed,

        /// <remarks/>
        [XmlEnum("3")]
        Item3,

        /// <remarks/>
        [XmlEnum("4")]
        Item4,

        /// <remarks/>
        [XmlEnum("5")]
        Item5,

        /// <remarks/>
        [XmlEnum("2147483647")]
        Item2147483647 = 2147483647,
    }
}
