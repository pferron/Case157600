using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_BASICATTACHMENTTYPE_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>This attachment is text only. Used for comments, notes, etc.</summary>
        [XmlEnum("1")]
        OLI_LU_BASICATTMNTTY_TEXT = 1,

        /// <summary>Image - This attachment contains only an image</summary>
        [XmlEnum("2")]
        OLI_LU_BASICATTMNTTY_IMAGE = 2,

        /// <summary>File - This attachment has a file attached.</summary>
        [XmlEnum("3")]
        OLI_LU_BASICATTMNTTY_FILE = 3,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
