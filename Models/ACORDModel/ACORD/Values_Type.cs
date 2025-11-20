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
    [XmlRoot("Values", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class Values_Type
    {
        /// <remarks/>
        [XmlElement("Axis", typeof(Axis_Type), Order = 0)]
        [XmlElement("Key", typeof(Key_Type), Order = 0)]
        [XmlElement("Y", typeof(string), Order = 0)]
        public object[] Items { get; set; }
    }
}
