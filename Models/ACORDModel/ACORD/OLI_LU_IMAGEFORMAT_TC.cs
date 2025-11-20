using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_IMAGEFORMAT_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>JPEG</summary>
        /// <remarks>Allows the user to see what type of Image format the attachment was sent as so they know what open it up as.</remarks>
        [XmlEnum("1")]
        OLI_IMAGE_JPEG = 1,

        /// <summary>GIF</summary>
        /// <remarks>Allows the user to see what type of Image format the attachment was sent as so they know what open it up as.</remarks>
        [XmlEnum("2")]
        OLI_IMAGE_GIF = 2,

        /// <summary>TIFF</summary>
        /// <remarks>Allows the user to see what type of Image format the attachment was sent as so they know what open it up as.</remarks>
        [XmlEnum("3")]
        OLI_IMAGE_TIFF = 3,

        /// <summary>PDF</summary>
        /// <remarks>Allows the user to see what type of Image format the attachment was sent as so they know what open it up as.</remarks>
        [XmlEnum("4")]
        OLI_IMAGE_PDF = 4,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
