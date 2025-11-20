using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_IMAGEFORM_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Electronic</summary>
        /// <remarks>FormInstance or attachment is stored in electronic form</remarks>
        [XmlEnum("1")]
        OLI_IMAGEFORM_ELECTRONIC = 1,

        /// <summary>Microfilm</summary>
        /// <remarks>FormInstance or attachment is stored on microfilm</remarks>
        [XmlEnum("2")]
        OLI_IMAGEFROM_MICROFILM = 2,

        /// <summary>Microfiche</summary>
        /// <remarks>FormInstance or attachment is stored on microfiche</remarks>
        [XmlEnum("3")]
        OLI_IMAGEFORM_MICROFICHE = 3,

        /// <summary>Paper</summary>
        /// <remarks>FormInstance or attachment is stored in paper form</remarks>
        [XmlEnum("4")]
        OLI_IMAGEFORM_PAPER = 4,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
