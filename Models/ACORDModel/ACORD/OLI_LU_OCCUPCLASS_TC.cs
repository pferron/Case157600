using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_OCCUPCLASS_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Salaried</summary>
        [XmlEnum("1")]
        OLI_OCCUPCLASS_SALARY = 1,

        /// <summary>Self-Employed</summary>
        [XmlEnum("2")]
        OLI_OCCUPCLASS_SELFEMP = 2,

        /// <summary>Retired</summary>
        [XmlEnum("3")]
        OLI_OCCUPCLASS_RETIRED = 3,

        /// <summary>Unemployed</summary>
        [XmlEnum("4")]
        OLI_OCCUPCLASS_UNEMPL = 4,

        /// <summary>Student</summary>
        [XmlEnum("5")]
        OLI_OCCUPCLASS_STUDENT = 5,

        /// <summary>Military</summary>
        [XmlEnum("6")]
        OLI_OCCUPCLASS_MILITARY = 6,

        /// <summary>Homemaker</summary>
        [XmlEnum("7")]
        OLI_OCCUPCLASS_HOMEMAKER = 7,

        /// <summary>Flagged Occupation</summary>
        [XmlEnum("8")]
        OLI_OCCUPCLASS_FLAGGED = 8,

        /// <summary>Professional, Managerial</summary>
        [XmlEnum("9")]
        OLI_OCCUPCLASS_PROFMANAGER = 9,

        /// <summary>Skilled, Semi-skilled</summary>
        [XmlEnum("10")]
        OLI_OCCUPCLASS_SKILLED = 10,

        /// <summary>Office, Sales</summary>
        [XmlEnum("11")]
        OLI_OCCUPCLASS_OFFICE = 11,

        /// <summary>Unskilled</summary>
        [XmlEnum("12")]
        OLI_OCCUPCLASS_UNSKILLED = 12,

        /// <summary>Part-Time Employee</summary>
        [XmlEnum("13")]
        OLI_OCCUPCLASS_PT = 13,

        /// <summary>Corporate Officer</summary>
        [XmlEnum("14")]
        OLI_OCCUPCLASS_CORPOFFICER = 14,

        /// <summary>Officer/Board Member</summary>
        [XmlEnum("15")]
        OLI_OCCUPCLASS_OFFICERBRDMEM = 15,

        /// <summary>Board Member</summary>
        [XmlEnum("16")]
        OLI_OCCUPCLASS_BRDMEM = 16,

        /// <summary>Partner</summary>
        [XmlEnum("17")]
        OLI_OCCUPCLASS_PARTNER = 17,

        /// <summary>Owner/Employee</summary>
        [XmlEnum("18")]
        OLI_OCCUPCLASS_OWNEREMP = 18,

        /// <summary>Owner</summary>
        [XmlEnum("19")]
        OLI_OCCUPCLASS_OWNER = 19,

        /// <summary>Sole Proprietor</summary>
        [XmlEnum("20")]
        OLI_OCCUPCLASS_SOLEPROPRIETOR = 20,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
