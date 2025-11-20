using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_BENEPERIOD_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>180 Days</summary>
        [XmlEnum("1")]
        OLI_DIBENPRD_180DAY = 1,

        /// <summary>200 weeks</summary>
        [XmlEnum("2")]
        OLI_DIBENPRD_200WKS = 2,

        /// <summary>3 months (90 days)</summary>
        [XmlEnum("3")]
        OLI_DIBENPRD_3MNTHS = 3,

        /// <summary>6 months (180 days)</summary>
        [XmlEnum("4")]
        OLI_DIBENPRD_6MNTHS = 4,

        /// <summary>15 months</summary>
        [XmlEnum("5")]
        OLI_DIBENPRD_15MNTHS = 5,

        /// <summary>1 year (12 months, 52 weeks, 365 Days)</summary>
        [XmlEnum("6")]
        OLI_DIBENPRD_1YR = 6,

        /// <summary>2 years (24 months)</summary>
        [XmlEnum("7")]
        OLI_DIBENPRD_2YRS = 7,

        /// <summary>3 years (36 months)</summary>
        [XmlEnum("8")]
        OLI_DIBENPRD_3YRS = 8,

        /// <summary>4 years (48 months)</summary>
        [XmlEnum("9")]
        OLI_DIBENPRD_4YRS = 9,

        /// <summary>5 years (60 months)</summary>
        [XmlEnum("10")]
        OLI_DIBENPRD_5YRS = 10,

        /// <summary>6 years</summary>
        [XmlEnum("11")]
        OLI_DIBENPRD_6YRS = 11,

        /// <summary>7 years</summary>
        [XmlEnum("12")]
        OLI_DIBENPRD_7YRS = 12,

        /// <summary>5-9 years</summary>
        [XmlEnum("13")]
        OLI_DIBENPRD_5TO9YRS = 13,

        /// <summary>10-14 years</summary>
        [XmlEnum("14")]
        OLI_DIBENPRD_10TO14YRS = 14,

        /// <summary>15 years</summary>
        [XmlEnum("15")]
        OLI_DIBENPRD_15YRS = 15,

        /// <summary>Coverage to age 65</summary>
        [XmlEnum("16")]
        OLI_DIBENPRD_AGE65 = 16,

        /// <summary>Coverage to age 67</summary>
        [XmlEnum("17")]
        OLI_DIBENPRD_AGE67 = 17,

        /// <summary>Lifetime</summary>
        [XmlEnum("18")]
        OLI_DIBENPRD_LIFE = 18,

        /// <summary>Extended - 2 years or to age 50 (reduced 50% to age 65)</summary>
        [XmlEnum("19")]
        OLI_DIBENPRD_EXT2YRS = 19,

        /// <summary>Life time if disability commences prior to age 50, otherwise 2 years</summary>
        [XmlEnum("20")]
        OLI_DIBENPRD_LIFE50 = 20,

        /// <summary>Aggregate limit - 15 times monthly income</summary>
        [XmlEnum("21")]
        OLI_DIBENPRD_AGGRLMT15X = 21,

        /// <summary>Aggregate limit - 50 months</summary>
        [XmlEnum("22")]
        OLI_DIBENPRD_AGGRLMT50 = 22,

        /// <summary>Coverage to age 60 - reduced 50% after age 60</summary>
        [XmlEnum("23")]
        OLI_DIBENPRD_AGE60RED50PCT = 23,

        /// <summary>25 years from date of issue</summary>
        [XmlEnum("24")]
        OLI_DIBENPRD_25YRS = 24,

        /// <summary>10 years from date of issue</summary>
        [XmlEnum("25")]
        OLI_DIBENPRD_10YRS = 25,

        /// <summary>Coverage to age 55</summary>
        [XmlEnum("26")]
        OLI_DIBENPRD_AGE55 = 26,

        /// <summary>Coverage to age 60</summary>
        [XmlEnum("27")]
        OLI_DIBENPRD_AGE60 = 27,

        /// <summary>2 months (60 days)</summary>
        [XmlEnum("28")]
        OLI_DIBENPRD_2MNTHS = 28,

        /// <summary>9 months (270 days)</summary>
        [XmlEnum("29")]
        OLI_DIBENPRD_9MNTHS = 29,

        /// <summary>18 months</summary>
        [XmlEnum("30")]
        OLI_DIBENPRD_18MNTHS = 30,

        /// <summary>20 years</summary>
        [XmlEnum("31")]
        OLI_DIBENPRD_20YRS = 31,

        /// <summary>25 years</summary>
        [XmlEnum("32")]
        OLI_DIBENPRD_25YRSONSET = 32,

        /// <summary>30 years</summary>
        [XmlEnum("33")]
        OLI_DIBENPRD_30YRS = 33,

        /// <summary>Benefit that pays a lump sum disability benefit only</summary>
        [XmlEnum("35")]
        OLI_DIBENPRD_LUMPSUM = 35,

        /// <summary>Amount specified in Days</summary>
        [XmlEnum("40")]
        OLI_DIBENPRD_DAYS = 40,

        /// <summary>Period is expressed in Months</summary>
        [XmlEnum("41")]
        OLI_DIBENPRD_MONTHS = 41,

        /// <summary>Benefit Period in Years</summary>
        [XmlEnum("42")]
        OLI_DIBENPRD_YEARS = 42,

        /// <summary>Coverage to Age 75</summary>
        /// <remarks>The benefit period that an option is guaranteed to Age 75</remarks>
        [XmlEnum("43")]
        OLI_DIBENPRD_AGE75 = 43,

        /// <summary>Coverage to Age 85</summary>
        /// <remarks>The benefit period that an option is guaranteed to Age 85</remarks>
        [XmlEnum("44")]
        OLI_DIBENPRD_AGE85 = 44,

        /// <summary>Maximum Benefit Period Available</summary>
        /// <remarks>This is used to identify the selection of the maximum benefit period available, as specified by the carrier's product rules.</remarks>
        [XmlEnum("47")]
        OLI_DIBENPRD_MAX = 47,

        /// <summary>10 years</summary>
        /// <remarks>10 years from onset of disability</remarks>
        [XmlEnum("48")]
        OLI_DIBENPRD_10YRPER = 48,

        /// <summary>Coverage to Age 80</summary>
        [XmlEnum("49")]
        OLI_DIBENPRD_AGE80 = 49,

        /// <summary>Coverage to premium paid up</summary>
        /// <remarks>The benefit applies until a coverage is paid up.</remarks>
        [XmlEnum("50")]
        OLI_DIBENPRD_PAIDUP = 50,

        /// <summary>Coverage to policy expiration</summary>
        /// <remarks>This benefit is in effect until the policy expires.</remarks>
        [XmlEnum("51")]
        OLI_DIBENPRD_POLEXP = 51,

        /// <summary>Limit Variation</summary>
        /// <remarks>The benefit will change as defined by the LimitVariation Object.</remarks>
        [XmlEnum("52")]
        OLI_DIBENPRD_LIMVARIES = 52,

        /// <summary>Coverage to specified age</summary>
        [XmlEnum("53")]
        OLI_DIBENPRD_AGESPEC = 53,

        /// <summary>5 days</summary>
        /// <remarks>Benefit Period is 5 days</remarks>
        [XmlEnum("54")]
        OLI_DIBENPRD_5DAYS = 54,

        /// <summary>11 days</summary>
        /// <remarks>Benefit Period is 11 days</remarks>
        [XmlEnum("55")]
        OLI_DIBENPRD_11DAYS = 55,

        /// <summary>20 days</summary>
        /// <remarks>Benefit Period is 20 days</remarks>
        [XmlEnum("56")]
        OLI_DIBENPRD_20DAYS = 56,

        /// <summary>100 days</summary>
        /// <remarks>Benefit Period is 100 days</remarks>
        [XmlEnum("57")]
        OLI_DIBENPRD_100DAYS = 57,

        /// <summary>360 days</summary>
        /// <remarks>Benefit Period is 360 days</remarks>
        [XmlEnum("58")]
        OLI_DIBENPRD_360DAYS = 58,

        /// <summary>500 days</summary>
        /// <remarks>Benefit Period is 500 days</remarks>
        [XmlEnum("59")]
        OLI_DIBENPRD_500DAYS = 59,

        /// <summary>1000 days</summary>
        /// <remarks>Benefit Period is 1000 days</remarks>
        [XmlEnum("60")]
        OLI_DIBENPRD_1000DAYS = 60,

        /// <summary>1500  days</summary>
        /// <remarks>Benefit Period is 1500 days</remarks>
        [XmlEnum("61")]
        OLI_DIBENPRD_1500DAYS = 61,

        /// <summary>2000 days</summary>
        /// <remarks>Benefit Period is 2000 days</remarks>
        [XmlEnum("62")]
        OLI_DIBENPRD_2000DAYS = 62,

        /// <summary>2500 days</summary>
        /// <remarks>Benefit Period is 2500 days</remarks>
        [XmlEnum("63")]
        OLI_DIBENPRD_2500DAYS = 63,

        /// <summary>2920 days</summary>
        /// <remarks>Benefit Period is 2920 days</remarks>
        [XmlEnum("64")]
        OLI_DIBENPRD_2920DAYS = 64,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
