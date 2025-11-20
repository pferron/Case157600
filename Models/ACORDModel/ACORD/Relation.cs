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
    public partial class Relation
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public OLI_LU_OBJECTTYPE OriginatingObjectType { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public OLI_LU_OBJECTTYPE RelatedObjectType { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public OLI_LU_REL RelationRoleCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public OLI_LU_RELDESC RelationDescription { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", Order = 4)]
        public OLifEExtension[] OLifEExtension { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "IDREF")]
        public string OriginatingObjectID { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "IDREF")]
        public string RelatedObjectID { get; set; }
    }
}
