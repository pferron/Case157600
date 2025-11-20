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
    public partial class FormInstance
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string FormName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public OLI_LU_BOOLEAN PrimaryFormInd { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string ProviderFormNumber { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public string FormVersion { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public string FormInstanceCategory { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public string CarrierCode { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 6)]
        public DateTime CreationDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool CreationDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "time", Order = 7)]
        public DateTime CreationTime { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool CreationTimeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public string FormInstanceVersion { get; set; }

        /// <remarks/>
        [XmlElement(Order = 9)]
        public OLI_LU_IMAGEFORM ImageForm { get; set; }

        /// <remarks/>
        [XmlElement("FormResponse", Order = 10)]
        public FormResponse_Type[] FormResponse { get; set; }

        /// <remarks/>
        [XmlElement("SignatureInfo", Order = 11)]
        public SignatureInfo_Type[] SignatureInfo { get; set; }

        /// <remarks/>
        [XmlElement("Attachment", Order = 12)]
        public Attachment[] Attachment { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", Order = 13)]
        public OLifEExtension[] OLifEExtension { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }
    }
}
