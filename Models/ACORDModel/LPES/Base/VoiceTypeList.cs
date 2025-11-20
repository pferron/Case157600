using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.LPES.Base
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    [XmlRoot("VoiceType", Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView", IsNullable = false)]
    public enum VoiceTypeList
    {
        /// <remarks/>
        [XmlEnum("0")]
        Item0,

        /// <remarks/>
        [XmlEnum("1")]
        Item1,

        /// <remarks/>
        [XmlEnum("2")]
        Item2,
    }
}
