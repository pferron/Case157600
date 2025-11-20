using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://ACORD.org/Standards/Life/2")]
    [XmlRoot(Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class OLifE
    {
        /// <remarks/>
        [XmlElement("FinancialStatement", typeof(FinancialStatement_Type), Order = 0)]
        [XmlElement("FormInstance", typeof(FormInstance), Order = 0)]
        [XmlElement("Holding", typeof(HOLDING_TYPE), Order = 0)]
        [XmlElement("OLifEExtension", typeof(OLifEExtension), Order = 0)]
        [XmlElement("Party", typeof(Party), Order = 0)]
        [XmlElement("PolicyProduct", typeof(PolicyProduct_Type), Order = 0)]
        [XmlElement("Relation", typeof(Relation), Order = 0)]
        public object[] Items { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string Version { get; set; }
    }
}
