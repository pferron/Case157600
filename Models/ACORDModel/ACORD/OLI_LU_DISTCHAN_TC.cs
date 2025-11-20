using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_DISTCHAN_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Wirehouse</summary>
        [XmlEnum("1")]
        OLI_DISTCHNNL_WH = 1,

        /// <summary>Registered Investment Advisor</summary>
        [XmlEnum("2")]
        OLI_DISTCHNNL_RIA = 2,

        /// <summary>Independent Agency</summary>
        [XmlEnum("3")]
        OLI_DISTCHNNL_IA = 3,

        /// <summary>Financial Planning Firm</summary>
        [XmlEnum("4")]
        OLI_DISTCHNNL_FPF = 4,

        /// <summary>Financial Institution</summary>
        [XmlEnum("5")]
        OLI_DISTCHNNL_FI = 5,

        /// <summary>Broker/Dealer</summary>
        [XmlEnum("6")]
        OLI_DISTCHNNL_BD = 6,

        /// <summary>Direct Marketing (Mail, Web, Telephone)</summary>
        /// <remarks>The marketing of insurance products directly, typically without a producer meeting face to face with the customer. Sales are solicited via phone, web or mail.</remarks>
        [XmlEnum("7")]
        OLI_DISTRIBUTIONCHANNEL_DIRECT = 7,

        /// <summary>Bank Market</summary>
        /// <remarks>The retail banking marketplace, where insurance products are offered in the traditional bank channel.</remarks>
        [XmlEnum("8")]
        OLI_DISTRIBUTIONCHANNEL_BANK = 8,

        /// <summary>Brokerage/Independent Market</summary>
        /// <remarks>Brokerage market is made up of independent, non-captive agents who typically write for a variety of insurance carriers.</remarks>
        [XmlEnum("9")]
        OLI_DISTRIBUTIONCHANNEL_BROKERAGE = 9,

        /// <summary>Captive Market</summary>
        /// <remarks>Captive market is one where the agents write primarily, generally exclusively, for one carrier. Producers are typically salaried employees and receive their offices, administrative staff and support directly from the carrier.</remarks>
        [XmlEnum("10")]
        OLI_DISTRIBUTIONCHANNEL_CAPTIVE = 10,

        /// <summary>Affiliated Agency</summary>
        /// <remarks>Distribution via affiliated companies, who are affiliates of the company who offers the product.</remarks>
        [XmlEnum("11")]
        OLI_DISTCHNNL_AFF = 11,

        /// <summary>Institutional Market</summary>
        /// <remarks>The market consisting of churches, museums, private hospitals, schools and colleges, clubs, and many other organizations that have objectives that differ basically from those of traditional business organizations.</remarks>
        [XmlEnum("12")]
        OLI_DISTCHNNL_INST = 12,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
