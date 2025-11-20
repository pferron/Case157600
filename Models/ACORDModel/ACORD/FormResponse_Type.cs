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
    [XmlRoot("FormResponse", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class FormResponse_Type
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string QuestionNumber { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string QuestionText { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "integer", Order = 2)]
        public string ResponseCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public string ResponseData { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public string ResponseText { get; set; }

        /// <remarks/>
        [XmlElement("Attachment", Order = 5)]
        public Attachment[] Attachment { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", Order = 6)]
        public OLifEExtension[] OLifEExtension { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }
    }
}
