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
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    [XmlRoot("PolicyStatement", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class PolicyStatement_Type
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string PolNumber { get; set; }

        /// <remarks/>
        [XmlElement("PolicyStatementDetail", Order = 1)]
        public PolicyStatementDetail_Type[] PolicyStatementDetail { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "IDREF")]
        public string HoldingID { get; set; }
    }
}
