using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_HOLDINGFORM_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Individual</summary>
        [XmlEnum("1")]
        OLI_HOLDFORM_IND = 1,

        /// <summary>Group (generic)</summary>
        [XmlEnum("2")]
        OLI_HOLDFORM_GRPGEN = 2,

        /// <summary>Group Association</summary>
        [XmlEnum("3")]
        OLI_HOLDFORM_GRPASSOC = 3,

        /// <summary>Group Supplemental</summary>
        [XmlEnum("4")]
        OLI_HOLDFORM_GRPSUP = 4,

        /// <summary>Group Voluntary</summary>
        [XmlEnum("5")]
        OLI_HOLDFORM_GRPVOL = 5,

        /// <summary>Cafeteria Group Plan</summary>
        [XmlEnum("6")]
        OLI_HOLDFORM_CAFETERIA = 6,

        /// <summary>Traditional Group Plan</summary>
        [XmlEnum("7")]
        OLI_HOLDFORM_TRADITIONAL = 7,

        /// <summary>Joint Individual</summary>
        [XmlEnum("8")]
        OLI_HOLDFORM_JOINTIND = 8,

        /// <summary>Industrial insurance</summary>
        /// <remarks>Industrial insurance</remarks>
        [XmlEnum("9")]
        OLI_HOLDFORM_INDUSTRIAL = 9,

        /// <summary>Sponsored Benefit Plan</summary>
        [XmlEnum("10")]
        OLI_HOLDFORM_EMPBEN = 10,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
