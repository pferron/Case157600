using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.LPES.Base
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    public enum INCLUDE_GRAPH_TYPE_TC
    {
        /// <remarks/>
        [XmlEnum("1")]
        ReportOnly = 1,

        /// <remarks/>
        [XmlEnum("4")]
        GraphOnly = 4,

        /// <remarks/>
        [XmlEnum("5")]
        ReportAndGraph = 5,
    }
}
