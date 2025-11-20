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
    [XmlRoot("MetaData", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class MetaData_Type
    {
        /// <remarks/>
        [XmlElement("AxisDef", Order = 0)]
        public AxisDef_Type[] AxisDef { get; set; }
    }
}
