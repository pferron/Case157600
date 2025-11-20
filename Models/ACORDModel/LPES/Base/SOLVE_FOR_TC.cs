using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.LPES.Base
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    public enum SOLVE_FOR_TC
    {
        /// <remarks/>
        [XmlEnum("1")]
        Face = 1,

        /// <remarks/>
        [XmlEnum("2")]
        Premium = 2,

        /// <remarks/>
        [XmlEnum("3")]
        Item3 = 3,

        /// <remarks/>
        [XmlEnum("4")]
        Item4 = 4,

        /// <remarks/>
        [XmlEnum("5")]
        Item5 = 5,

        /// <remarks/>
        [XmlEnum("2147483647")]
        Item2147483647 = 2147483647,
    }
}
