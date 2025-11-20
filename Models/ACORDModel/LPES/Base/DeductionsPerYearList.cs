using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.LPES.Base
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    [XmlRoot("DeductionsPerYear", Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView", IsNullable = false)]
    public enum DeductionsPerYearList
    {
        /// <remarks/>
        [XmlEnum("1")]
        Item1,

        /// <remarks/>
        [XmlEnum("2")]
        Item2,

        /// <remarks/>
        [XmlEnum("4")]
        Item4,

        /// <remarks/>
        [XmlEnum("9")]
        Item9,

        /// <remarks/>
        [XmlEnum("10")]
        Item10,

        /// <remarks/>
        [XmlEnum("12")]
        Item12,

        /// <remarks/>
        [XmlEnum("24")]
        Item24,

        /// <remarks/>
        [XmlEnum("26")]
        Item26,

        /// <remarks/>
        [XmlEnum("52")]
        Item52,
    }
}
