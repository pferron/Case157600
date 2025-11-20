using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_RATINGS_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>None</summary>
        [XmlEnum("1")]
        OLI_TBLRATE_NONE = 1,

        /// <summary>125%</summary>
        [XmlEnum("2")]
        OLI_TBLRATE_A = 2,

        /// <summary>137.50%</summary>
        [XmlEnum("3")]
        OLI_TBLRATE_AA = 3,

        /// <summary>150%</summary>
        [XmlEnum("4")]
        OLI_TBLRATE_B = 4,

        /// <summary>162.50%</summary>
        [XmlEnum("5")]
        OLI_TBLRATE_BB = 5,

        /// <summary>175%</summary>
        [XmlEnum("6")]
        OLI_TBLRATE_C = 6,

        /// <summary>200%</summary>
        [XmlEnum("7")]
        OLI_TBLRATE_D = 7,

        /// <summary>225%</summary>
        [XmlEnum("8")]
        OLI_TBLRATE_E = 8,

        /// <summary>250%</summary>
        [XmlEnum("9")]
        OLI_TBLRATE_F = 9,

        /// <summary>275%</summary>
        [XmlEnum("10")]
        OLI_TBLRATE_G = 10,

        /// <summary>300%</summary>
        [XmlEnum("11")]
        OLI_TBLRATE_H = 11,

        /// <summary>325%</summary>
        [XmlEnum("12")]
        OLI_TBLRATE_I = 12,

        /// <summary>350%</summary>
        [XmlEnum("13")]
        OLI_TBLRATE_J = 13,

        /// <summary>375%</summary>
        [XmlEnum("14")]
        OLI_TBLRATE_K = 14,

        /// <summary>400%</summary>
        [XmlEnum("15")]
        OLI_TBLRATE_L = 15,

        /// <summary>425%</summary>
        [XmlEnum("16")]
        OLI_TBLRATE_M = 16,

        /// <summary>450%</summary>
        [XmlEnum("17")]
        OLI_TBLRATE_N = 17,

        /// <summary>475%</summary>
        [XmlEnum("18")]
        OLI_TBLRATE_O = 18,

        /// <summary>500%</summary>
        [XmlEnum("19")]
        OLI_TBLRATE_P = 19,

        /// <summary>Uninsurable and/or declined</summary>
        [XmlEnum("20")]
        OLI_TBLRATE_U = 20,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
