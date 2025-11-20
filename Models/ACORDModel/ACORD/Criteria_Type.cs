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
    [XmlRoot("Criteria", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class Criteria_Type
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public OLI_LU_OBJECTTYPE ObjectType { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string PropertyName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public PropertyValue PropertyValue { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public OLI_LU_OPERATION Operation { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", Order = 4)]
        public OLifEExtension[] OLifEExtension { get; set; }
    }
}
