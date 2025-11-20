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
    [XmlRoot("Table", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class Table_Type
    {
        /// <remarks/>
        [XmlArray(Order = 0)]
        [XmlArrayItem("AxisDef", IsNullable = false)]
        public AxisDef_Type[] MetaData { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public Values_Type Values { get; set; }
    }
}
