using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_ADTYPE_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Residence</summary>
        [XmlEnum("1")]
        OLI_ADTYPE_HOME = 1,

        /// <summary>Business</summary>
        [XmlEnum("2")]
        OLI_ADTYPE_BUS = 2,

        /// <summary>Vacation</summary>
        [XmlEnum("3")]
        OLI_ADTYPE_VAC = 3,

        /// <summary>Regional Office</summary>
        [XmlEnum("9")]
        OLI_ADTYPE_REGOFFICE = 9,

        /// <summary>Temporary</summary>
        [XmlEnum("11")]
        OLI_ADTYPE_TEMP = 11,

        /// <summary>Previous</summary>
        [XmlEnum("12")]
        OLI_ADTYPE_PREVIOUS = 12,

        /// <summary>Address to be used for appointment purposes</summary>
        /// <remarks>This Address is applicable for an appointment such as a paramed exam, signature, or some other appointment.</remarks>
        [XmlEnum("13")]
        OLI_ADTYPE_APPTPURPOSE = 13,

        /// <summary>Billing Return To Address</summary>
        [XmlEnum("14")]
        OLI_ADTYPE_BILLINGRETTO = 14,

        /// <summary>Individual Work Location</summary>
        [XmlEnum("15")]
        OLI_ADTYPE_INDVWORKLOC = 15,

        /// <summary>Business Shipping Address</summary>
        [XmlEnum("16")]
        OLI_ADTYPE_BUSSHIPPING = 16,

        /// <summary>Mailing</summary>
        /// <remarks>The address to receive all correspondence unless otherwise specified address and can be different from a residential or business address. It can be different from a business shipping address. This address might be a post office box.</remarks>
        [XmlEnum("17")]
        OLI_ADTYPE_MAILING = 17,

        /// <summary>Claim Center</summary>
        /// <remarks>Indicates that the address is the address for claim inquiries or claim processing submission.</remarks>
        [XmlEnum("18")]
        OLI_ADTYPE_CLAIMCENTER = 18,

        /// <summary>Overnight Mail Address</summary>
        [XmlEnum("19")]
        OLI_ADTYPE_OVERNIGHT = 19,

        /// <summary>Policy Mailing Address</summary>
        [XmlEnum("20")]
        OLI_ADTYPE_POLMAIL = 20,

        /// <summary>Commission Mailing Address</summary>
        [XmlEnum("21")]
        OLI_ADTYPE_COMM = 21,

        /// <summary>Agent customer service address</summary>
        /// <remarks>Carrier's address to be used by the agent for customer service.</remarks>
        [XmlEnum("24")]
        OLI_ADTYPE_AGENTCSA = 24,

        /// <summary>Client customer service address</summary>
        /// <remarks>Carrier's address to be used by the client for customer service.</remarks>
        [XmlEnum("25")]
        OLI_ADTYPE_CLIENTCSA = 25,

        /// <summary>Billing Mailing</summary>
        /// <remarks>The address used to send the bill notices.</remarks>
        [XmlEnum("26")]
        OLI_ADTYPE_BILLMAIL = 26,

        /// <summary>Headquarters Address</summary>
        /// <remarks>The address of a company or organization's headquarters location.</remarks>
        [XmlEnum("27")]
        OLI_ADTYPE_HDQRTRS = 27,

        /// <summary>Previous Business Address</summary>
        [XmlEnum("28")]
        OLI_ADTYPE_PREVBUS = 28,

        /// <summary>Previous Residence Address</summary>
        [XmlEnum("29")]
        OLI_ADTYPE_PREVRES = 29,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
