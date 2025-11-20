using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_BENEDESIGNATION_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Named</summary>
        [XmlEnum("1")]
        OLI_BENEDES_NAMED = 1,

        /// <summary>Estate</summary>
        [XmlEnum("2")]
        OLI_BENEDES_ESTATE = 2,

        /// <summary>Complex</summary>
        [XmlEnum("3")]
        OLI_BENEDES_COMPLEX = 3,

        /// <summary>Creditors</summary>
        [XmlEnum("4")]
        OLI_BENEDES_CREDITORS = 4,

        /// <summary>Fractions</summary>
        [XmlEnum("5")]
        OLI_BENEDES_FRACTIONS = 5,

        /// <summary>Last Will and Testament</summary>
        [XmlEnum("6")]
        OLI_BENEDES_LASTWILL = 6,

        /// <summary>Trust Agreement</summary>
        [XmlEnum("7")]
        OLI_BENEDES_TRUST = 7,

        /// <summary>Split Dollar</summary>
        [XmlEnum("8")]
        OLI_BENEDES_SPLITDOLLAR = 8,

        /// <summary>Spouse</summary>
        [XmlEnum("9")]
        OLI_BENEDES_SPOUSE = 9,

        /// <summary>Domestic partner</summary>
        [XmlEnum("10")]
        OLI_BENEDES_DOMESTICPTNR = 10,

        /// <summary>Children of marriage</summary>
        [XmlEnum("11")]
        OLI_BENEDES_CHILDRENMARRIAGE = 11,

        /// <summary>Children born of marriage.</summary>
        [XmlEnum("12")]
        OLI_BENEDES_CHILDRENBORNMARRIAGE = 12,

        /// <summary>Children of Insured</summary>
        [XmlEnum("13")]
        OLI_BENEDES_CHILDREN = 13,

        /// <summary>Legally adopted children of insured</summary>
        [XmlEnum("14")]
        OLI_BENEDES_ADOPTEDCHILDREN = 14,

        /// <summary>Lawful children of insured</summary>
        [XmlEnum("15")]
        OLI_BENEDES_LAWFULCHILDREN = 15,

        /// <summary>Brothers of Insured</summary>
        [XmlEnum("16")]
        OLI_BENEDES_BROTHERS = 16,

        /// <summary>Sisters of Insured</summary>
        [XmlEnum("17")]
        OLI_BENEDES_SISTERS = 17,

        /// <summary>Siblings of Insured</summary>
        [XmlEnum("18")]
        OLI_BENEDES_SIBLINGS = 18,

        /// <summary>Uniform Gifts to Minors</summary>
        [XmlEnum("19")]
        OLI_BENEDES_GIFTTOMINORS = 19,

        /// <summary>Parents of insured</summary>
        [XmlEnum("20")]
        OLI_BENEDES_PARENTS = 20,

        /// <summary>PVT CSC Primary Beneficiary</summary>
        [XmlEnum("21")]
        OLI_BENEDES_PRIBENE = 21,

        /// <summary>PVT CSC Child of Primary Beneficiary</summary>
        [XmlEnum("22")]
        OLI_BENEDES_PRICHILD = 22,

        /// <summary>PVT CSC Parents of Primary Beneficiary</summary>
        [XmlEnum("23")]
        OLI_BENEDES_PRIPARENT = 23,

        /// <summary>Business Agreement</summary>
        [XmlEnum("24")]
        OLI_BENEDES_BUSINESSAGMT = 24,

        /// <summary>Spouse and Children</summary>
        [XmlEnum("25")]
        OLI_BENEDES_SPOUSEANDCHILDREN = 25,

        /// <summary>Estate of Primary Beneficiary</summary>
        [XmlEnum("26")]
        OLI_BENEDES_ESTATEPRIBENE = 26,

        /// <summary>Children of Primary Beneficiary</summary>
        [XmlEnum("27")]
        OLI_BENEDES_CHILDRNPRIBENE = 27,

        /// <summary>Parents of Primary Beneficiary</summary>
        [XmlEnum("28")]
        OLI_BENEDES_PARENTSPRIBENE = 28,

        /// <summary>All natural children of the insured</summary>
        [XmlEnum("29")]
        OLI_BENEDES_CHILDNAT = 29,

        /// <summary>Ex-Spouse of Insured</summary>
        [XmlEnum("30")]
        OLI_BENEDES_EX_SPOUSE = 30,

        /// <summary>Step-parents of insured</summary>
        /// <remarks>Step-parents of insured</remarks>
        [XmlEnum("33")]
        OLI_BENEDES_STEPPARENTS = 33,

        /// <summary>Adult Dependents</summary>
        /// <remarks>One or more adult dependents</remarks>
        [XmlEnum("34")]
        OLI_BENEDES_ADULT = 34,

        /// <summary>Stepchild(ren)</summary>
        /// <remarks>Stepchildren of Insured</remarks>
        [XmlEnum("35")]
        OLI_BENEDES_STEPCHILDREN = 35,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
