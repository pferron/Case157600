using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_PAYMODE_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Annual or Annually</summary>
        [XmlEnum("1")]
        OLI_PAYMODE_ANNUAL = 1,

        /// <summary>Semi-Annual (twice a year)</summary>
        [XmlEnum("2")]
        OLI_PAYMODE_BIANNUAL = 2,

        /// <summary>Quarter or Quarterly</summary>
        [XmlEnum("3")]
        OLI_PAYMODE_QUARTLY = 3,

        /// <summary>Month or Monthly</summary>
        [XmlEnum("4")]
        OLI_PAYMODE_MNTHLY = 4,

        /// <summary>Semi-Monthly (twice a month)</summary>
        [XmlEnum("5")]
        OLI_PAYMODE_BIMNTHLY = 5,

        /// <summary>Week or Weekly</summary>
        [XmlEnum("6")]
        OLI_PAYMODE_WKLY = 6,

        /// <summary>Bi-Weekly (every two weeks)</summary>
        [XmlEnum("7")]
        OLI_PAYMODE_BIWKLY = 7,

        /// <summary>Day or Daily</summary>
        [XmlEnum("8")]
        OLI_PAYMODE_DAILY = 8,

        /// <summary>Single Payment</summary>
        [XmlEnum("9")]
        OLI_PAYMODE_SINGLEPAY = 9,

        /// <summary>Monthly for Nine months</summary>
        [XmlEnum("10")]
        OLI_PAYMODE_MNTH49 = 10,

        /// <summary>Random</summary>
        /// <remarks>Random means "Triggered by a random event"</remarks>
        [XmlEnum("11")]
        OLI_PAYMODE_RANDOM = 11,

        /// <summary>Every 4 weeks (4 weekly)</summary>
        [XmlEnum("12")]
        OLI_PAYMODE_4WKLY = 12,

        /// <summary>Monthly for 10 months</summary>
        [XmlEnum("13")]
        OLI_PAYMODE_MNTH410 = 13,

        /// <summary>Monthly for 8 months</summary>
        [XmlEnum("14")]
        OLI_PAYMODE_MNTH48 = 14,

        /// <summary>Every 2 months</summary>
        [XmlEnum("15")]
        OLI_PAYMODE_EVERY2MTHS = 15,

        /// <summary>Every 4 months</summary>
        [XmlEnum("16")]
        OLI_PAYMODE_EVERY4MTHS = 16,

        /// <summary>Every 5 months</summary>
        [XmlEnum("17")]
        OLI_PAYMODE_EVERY5MTHS = 17,

        /// <summary>Every 7 months</summary>
        [XmlEnum("18")]
        OLI_PAYMODE_EVERY7MTHS = 18,

        /// <summary>Every 8 months</summary>
        [XmlEnum("19")]
        OLI_PAYMODE_EVERY8MTHS = 19,

        /// <summary>Every 9 months</summary>
        [XmlEnum("20")]
        OLI_PAYMODE_EVERY9MTHS = 20,

        /// <summary>Every 10 months</summary>
        [XmlEnum("21")]
        OLI_PAYMODE_EVERY10MTHS = 21,

        /// <summary>Every 11 months</summary>
        [XmlEnum("22")]
        OLI_PAYMODE_EVERY11MTHS = 22,

        /// <summary>Fiscal Quarterly mode of payment</summary>
        /// <remarks>Assumes fiscal date is based off start date</remarks>
        [XmlEnum("23")]
        OLI_PAYMODE_FISCALQUARTER = 23,

        /// <summary>Every three weeks</summary>
        [XmlEnum("24")]
        OLI_PAYMODE_EVERY3WKS = 24,

        /// <summary>Payments made 7 times per year.</summary>
        [XmlEnum("25")]
        OLI_PAYMODE_SEVENTHLY = 25,

        /// <summary>Payments made 11 times per year.</summary>
        [XmlEnum("26")]
        OLI_PAYMODE_ELEVENTHLY = 26,

        /// <summary>Payments made 14 times per year.</summary>
        [XmlEnum("27")]
        OLI_PAYMODE_FOURTEENTHLY = 27,

        /// <summary>Payments made 28 times per year.</summary>
        [XmlEnum("28")]
        OLI_PAYMODE_TWENTYEIGHTHLY = 28,

        /// <summary>Payment made 5 times a year</summary>
        /// <remarks>Policy is paid on a quarterly basis with first payment being paid at beginning of billing cycle, and final payment being paid at end of billing cycle.</remarks>
        [XmlEnum("29")]
        OLI_PAYMODE_QTRFIVE = 29,

        /// <summary>Annual Calendar</summary>
        /// <remarks>Payment is paid annually, and is driven off of calendar year as opposed to policy anniversary.</remarks>
        [XmlEnum("30")]
        OLI_PAYMODE_ANNUALCAL = 30,

        /// <summary>Once every 5 years</summary>
        [XmlEnum("31")]
        OLI_PAYMODE_5YEARS = 31,

        /// <summary>Lifetime</summary>
        /// <remarks>Used to define a Lifetime period of time</remarks>
        [XmlEnum("40")]
        OLI_PAYMODE_LIFETIME = 40,

        /// <summary>Payment is made once every three years</summary>
        [XmlEnum("41")]
        OLI_PAYMODE_TRIANNUAL = 41,

        /// <summary>Payments made 9 times a year</summary>
        [XmlEnum("42")]
        OLI_PAYMODE_NINETHLY = 42,

        /// <summary>Payments made 10 times a year</summary>
        [XmlEnum("43")]
        OLI_PAYMODE_TENTHLY = 43,

        /// <summary>Payments made 13 times a year</summary>
        [XmlEnum("44")]
        OLI_PAYMODE_THIRTTEENLY = 44,

        /// <summary>Payments made 16 times a year</summary>
        [XmlEnum("45")]
        OLI_PAYMODE_SIXTEENTHLY = 45,

        /// <summary>Payments made 18 times a year</summary>
        [XmlEnum("46")]
        OLI_PAYMODE_EIGTHTEENLY = 46,

        /// <summary>Payments made 19 times a year</summary>
        [XmlEnum("47")]
        OLI_PAYMODE_NINETEENLY = 47,

        /// <summary>Payments made 20 times a year</summary>
        [XmlEnum("48")]
        OLI_PAYMODE_TWENTYLY = 48,

        /// <summary>Payments made 21 times a year</summary>
        [XmlEnum("49")]
        OLI_PAYMODE_TWENTHFIRSTLY = 49,

        /// <summary>Payments made 22 times a year</summary>
        [XmlEnum("50")]
        OLI_PAYMODE_TWENTYSECONDLY = 50,

        /// <summary>None</summary>
        [XmlEnum("99")]
        OLI_PAYMODE_NONE = 99,

        /// <summary>Any Paymode is allowed</summary>
        /// <remarks>Used in Product Definitions only</remarks>
        [XmlEnum("100")]
        OLI_PAYMODE_ANY = 100,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
