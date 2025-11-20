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
    public partial class Attachment
    {
        /// <remarks/>
        [XmlElement(DataType = "date", Order = 0)]
        public DateTime DateCreated { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool DateCreatedSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public OLI_LU_BASICATTACHMENTTYPE AttachmentBasicType { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string Description { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public string AttachmentData { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public OLI_LU_ATTACHMENTTYPE AttachmentType { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public OLI_LU_MIMETYPE MimeTypeTC { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public OLI_LU_ENCODETYPE TransferEncodingTypeTC { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public OLI_LU_IMAGEFORMAT ImageType { get; set; }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public OLI_LU_ATTACHLOCATION AttachmentLocation { get; set; }
    }
}
