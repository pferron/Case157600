using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.LPES.Base
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    [XmlRoot("TemplateIssueType", Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView", IsNullable = false)]
    public enum TemplateIssueTypeList
    {
        /// <remarks/>
        [XmlEnum("1")]
        Item1,

        /// <remarks/>
        [XmlEnum("2")]
        Item2,

        /// <remarks/>
        [XmlEnum("5")]
        Item5,
    }
}
