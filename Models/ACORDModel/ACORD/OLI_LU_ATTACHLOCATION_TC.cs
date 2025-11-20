using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_ATTACHLOCATION_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Inline Data</summary>
        /// <remarks>Indicates that the referenced property contains a binary representation of an attachment.</remarks>
        [XmlEnum("1")]
        OLI_INLINE = 1,

        /// <summary>URL Reference</summary>
        /// <remarks>Indicates that the referenced property contains an accessible URL Reference to a file not included in the XMLife data stream.</remarks>
        [XmlEnum("2")]
        OLI_URLREFERENCE = 2,

        /// <summary>Multipart Mime</summary>
        /// <remarks>Indicates that an attachment is included as part of a multipart mime.</remarks>
        [XmlEnum("3")]
        OLI_MULTIPART = 3,

        /// <summary>Attachment IDREF</summary>
        /// <remarks>Indicates that the attached file is referenced via AttachmentReference.</remarks>
        [XmlEnum("4")]
        OLI_ATTACHREF = 4,

        /// <summary>XOP</summary>
        /// <remarks>The attachment location is specified via an XOP:Include element.  For a description of XOP:Include, please refer to the W3C Web site at http://www.w3.org/TR/xop10/#xop_include.</remarks>
        [XmlEnum("5")]
        OLI_LU_ATTACHLOCATION_XOP = 5,

        /// <summary>Externally Provided</summary>
        /// <remarks>Indicates that attachment is NOT sent with this message's data stream and is not accessible via URL.  If this code is specified then corresponding Attachment must not specify AttachmentData, AttachmentReference, or AttachmentBinary64. If file is accessible via a URL reference do not use this code, use URL Reference (@tc=2) instead.</remarks>
        [XmlEnum("6")]
        OLI_ATTACHLOCATION_EXT = 6,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
