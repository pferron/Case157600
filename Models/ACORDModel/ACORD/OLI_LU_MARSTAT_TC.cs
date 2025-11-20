using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_MARSTAT_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Married</summary>
        [XmlEnum("1")]
        OLI_MARITAL_MARRIED = 1,

        /// <summary>Single</summary>
        [XmlEnum("2")]
        OLI_MARITAL_SINGLE = 2,

        /// <summary>Divorced</summary>
        [XmlEnum("3")]
        OLI_MARITAL_DIVORCED = 3,

        /// <summary>Widowed</summary>
        [XmlEnum("4")]
        OLI_MARITAL_WIDOWED = 4,

        /// <summary>Legally Separated</summary>
        [XmlEnum("5")]
        OLI_MARITAL_SEPARATED = 5,

        /// <summary>Common Law (Defacto)</summary>
        [XmlEnum("6")]
        OLI_MARITAL_COMMONLAW = 6,

        /// <summary>Estranged</summary>
        /// <remarks>When a married couple is not legally separated but is living apart.</remarks>
        [XmlEnum("7")]
        OLI_MARITAL_ESTRANGED = 7,

        /// <summary>Head of Household</summary>
        /// <remarks>Head of Household for tax withholding purposes</remarks>
        [XmlEnum("8")]
        OLI_MARITAL_HEADOFHOUSEHOLD = 8,

        /// <summary>Married, withholding single.</summary>
        /// <remarks>Married, but withholding at a higher single rate</remarks>
        [XmlEnum("9")]
        OLI_MARITAL_MARRIEDSINGLEWTHHLD = 9,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
