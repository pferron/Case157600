using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_ELIMPERIOD_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>0 days elimination or Not applicable</summary>
        [XmlEnum("1")]
        OLI_DISELIM_ZERO = 1,

        /// <summary>365 days elimination (360 days, 1 year, 12 months)</summary>
        [XmlEnum("2")]
        OLI_DISELIM_365 = 2,

        /// <summary>3 days elimination</summary>
        [XmlEnum("3")]
        OLI_DISELIM_3 = 3,

        /// <summary>30 days elimination (1 month)</summary>
        [XmlEnum("4")]
        OLI_DISELIM_30 = 4,

        /// <summary>14 days elimination (15 days)</summary>
        [XmlEnum("5")]
        OLI_DISELIM_14 = 5,

        /// <summary>180 days elimination</summary>
        [XmlEnum("6")]
        OLI_DISELIM_180 = 6,

        /// <summary>60 days elimination</summary>
        [XmlEnum("7")]
        OLI_DISELIM_60 = 7,

        /// <summary>7 days elimination</summary>
        [XmlEnum("8")]
        OLI_DISELIM_7 = 8,

        /// <summary>90 days elimination (3 months, 13 weeks)</summary>
        [XmlEnum("9")]
        OLI_DISELIM_90 = 9,

        /// <summary>28 days elimination</summary>
        [XmlEnum("10")]
        OLI_DISELIM_28 = 10,

        /// <summary>720 days elimination (2 years, 730 days, 24 months)</summary>
        [XmlEnum("11")]
        OLI_DISELIM_720 = 11,

        /// <summary>540 days elimination (18 months)</summary>
        [XmlEnum("12")]
        OLI_DISELIM_540 = 12,

        /// <summary>270 days elimination (9 months)</summary>
        [XmlEnum("13")]
        OLI_DISELIM_270 = 13,

        /// <summary>120 days elimination</summary>
        [XmlEnum("14")]
        OLI_DISELIM_120 = 14,

        /// <summary>20 days elimination</summary>
        /// <remarks>20 days elimination (Period of time after disability before benefits are paid)</remarks>
        [XmlEnum("15")]
        OLI_DISELIM_20 = 15,

        /// <summary>45 days elimination</summary>
        /// <remarks>45 days elimination (Period of time after disability before benefits are paid)</remarks>
        [XmlEnum("16")]
        OLI_DISELIM_45 = 16,

        /// <summary>100 days elimination</summary>
        /// <remarks>100 days elimination (Period of time after disability before benefits are paid)</remarks>
        [XmlEnum("17")]
        OLI_DISELIM_100 = 17,

        /// <summary>3 months elimination</summary>
        [XmlEnum("18")]
        OLI_DISELIM_3MOS = 18,

        /// <summary>6 months elimination</summary>
        [XmlEnum("19")]
        OLI_DISELIM_6MOS = 19,

        /// <summary>5 days</summary>
        /// <remarks>5 days elimination</remarks>
        [XmlEnum("20")]
        OLI_DISELIM_15DAYS = 20,

        /// <summary>42 days</summary>
        /// <remarks>42 days elimination</remarks>
        [XmlEnum("21")]
        OLI_DISELIM_42DAYS = 21,

        /// <summary>150 days</summary>
        /// <remarks>150 days elimination</remarks>
        [XmlEnum("22")]
        OLI_DISELIM_150DAYS = 22,

        /// <summary>1095 days</summary>
        /// <remarks>1095 days elimination</remarks>
        [XmlEnum("23")]
        OLI_DISELIM_1095DAYS = 23,

        /// <summary>1460 days</summary>
        /// <remarks>1460 days elimination</remarks>
        [XmlEnum("24")]
        OLI_DISELIM_1460DAYS = 24,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
