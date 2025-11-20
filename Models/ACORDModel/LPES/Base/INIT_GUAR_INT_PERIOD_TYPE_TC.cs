using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.LPES.Base
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    public enum INIT_GUAR_INT_PERIOD_TYPE_TC
    {
        /// <remarks/>
        [XmlEnum("0")]
        OneMonth,

        /// <remarks/>
        [XmlEnum("1")]
        TwelveMonth,
    }
}
