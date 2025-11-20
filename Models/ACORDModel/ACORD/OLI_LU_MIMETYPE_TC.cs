using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_MIMETYPE_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,


        /// <summary>text/plain charset=us-ascii or charset=iso-8859-x</summary>
        [XmlEnum("1")]
        OLI_MIMETYPE_TEXTPLAIN = 1,


        /// <summary>text/richtext</summary>
        [XmlEnum("2")]
        OLI_MIMETYPE_TEXTRICH = 2,


        /// <summary>image/jpeg</summary>
        [XmlEnum("3")]
        OLI_MIMETYPE_JPEG = 3,


        /// <summary>image/gif</summary>
        [XmlEnum("4")]
        OLI_MIMETYPE_GIF = 4,


        /// <summary>image/g3fax</summary>
        [XmlEnum("5")]
        OLI_MIMETYPE_G3FAX = 5,


        /// <summary>video/mpeg</summary>
        [XmlEnum("6")]
        OLI_MIMETYPE_MPEG = 6,


        /// <summary>audio/basic</summary>
        [XmlEnum("7")]
        OLI_MIMETYPE_AUDIO = 7,


        /// <summary>application/postscript</summary>
        [XmlEnum("8")]
        OLI_MIMETYPE_POSTSCRIPT = 8,


        /// <summary>application/octet-stream</summary>
        [XmlEnum("9")]
        OLI_MIMETYPE_OCTET = 9,


        /// <summary>application/oda</summary>
        [XmlEnum("10")]
        OLI_MIMETYPE_ODA = 10,


        /// <summary>image/tiff</summary>
        [XmlEnum("11")]
        OLI_MIMETYPE_TIFF = 11,


        /// <summary>multipart/mixed</summary>
        [XmlEnum("12")]
        OLI_MIMETYPE_MULTIMIXED = 12,


        /// <summary>image/PDF</summary>
        [XmlEnum("17")]
        OLI_MIMETYPE_PDF = 17,


        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
