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
    [XmlRoot("SignatureInfo", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class SignatureInfo_Type
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string SignatureCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public OLI_LU_PARTICROLE SignatureRoleCode { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 2)]
        public DateTime SignatureDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool SignatureDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public string SignatureCity { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public OLI_LU_STATE SignatureState { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public string SignatureText { get; set; }

        /// <remarks/>
        [XmlElement("Attachment", Order = 6)]
        public Attachment[] Attachment { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", Order = 7)]
        public OLifEExtension[] OLifEExtension { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "IDREF")]
        public string SignaturePartyID { get; set; }
    }
}
