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
    [XmlRoot("CriteriaExpression", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class CriteriaExpression_Type
    {
        /// <remarks/>
        [XmlElement("Criteria", typeof(Criteria_Type), Order = 0)]
        [XmlElement("CriteriaExpression", typeof(CriteriaExpression_Type), Order = 0)]
        [XmlElement("CriteriaOperator", typeof(CRITERIA_OPERATOR), Order = 0)]
        [XmlElement("OLifEExtension", typeof(OLifEExtension), Order = 0)]
        public object[] Items { get; set; }
    }
}
