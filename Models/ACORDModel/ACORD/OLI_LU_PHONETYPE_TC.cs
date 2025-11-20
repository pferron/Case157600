using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_PHONETYPE_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Home</summary>
        [XmlEnum("1")]
        OLI_PHONETYPE_HOME = 1,

        /// <summary>Business</summary>
        [XmlEnum("2")]
        OLI_PHONETYPE_BUS = 2,

        /// <summary>Vacation</summary>
        [XmlEnum("3")]
        OLI_PHONETYPE_VAC = 3,

        /// <summary>Business Fax</summary>
        [XmlEnum("4")]
        OLI_PHONETYPE_BUSFAX = 4,

        /// <summary>Marine</summary>
        [XmlEnum("6")]
        OLI_PHONETYPE_YACHT = 6,

        /// <summary>Corporate Office</summary>
        [XmlEnum("7")]
        OLI_PHONETYPE_CORPOFFICE = 7,

        /// <summary>Regional Office</summary>
        [XmlEnum("9")]
        OLI_PHONETYPE_REGOFFICE = 9,

        /// <summary>Emergency</summary>
        [XmlEnum("10")]
        OLI_PHONETYPE_EMERG = 10,

        /// <summary>Temporary</summary>
        [XmlEnum("11")]
        OLI_PHONETYPE_TEMP = 11,

        /// <summary>Mobile</summary>
        [XmlEnum("12")]
        OLI_PHONETYPE_MOBILE = 12,

        /// <summary>Pager (beeper)</summary>
        [XmlEnum("13")]
        OLI_PHONETYPE_PAGER = 13,

        /// <summary>Modem/data line</summary>
        [XmlEnum("14")]
        OLI_PHONETYPE_MODEM = 14,

        /// <summary>Home Fax</summary>
        [XmlEnum("15")]
        OLI_PHONETYPE_HOMEFAX = 15,

        /// <summary>"General" voice number unspecified as to location</summary>
        [XmlEnum("16")]
        OLI_PHONETYPE_VOICE = 16,

        /// <summary>Business Toll-Free</summary>
        /// <remarks>This is a business toll free number for a Corporation.  i.e. 1-800...</remarks>
        [XmlEnum("17")]
        OLI_PHONETYPE_BUSTOLLFREE = 17,

        /// <summary>Claim Center</summary>
        /// <remarks>Indicates that the phone number is the phone number for claim inquiries or claim processing information.</remarks>
        [XmlEnum("18")]
        OLI_PHONETYPE_CLAIMCENTER = 18,

        /// <summary>Fax</summary>
        /// <remarks>This value is used when a fax number is given and the party does not indicate whether or not it is their business or personal fax number.If a more specific fax type code is available, it should be used instead of this code. This code should only be used when a fax number is provided and there is no indication as to whether it is a home or business fax.</remarks>
        [XmlEnum("19")]
        OLI_PHONETYPE_FAX = 19,

        /// <summary>Agent customer service phone number</summary>
        /// <remarks>Carrier's phone number agent will use for customer service.</remarks>
        [XmlEnum("20")]
        OLI_PHONETYPE_AGENTCSA = 20,

        /// <summary>Client customer service phone number</summary>
        /// <remarks>Carrier's phone number the client will use for customer service.</remarks>
        [XmlEnum("21")]
        OLI_PHONETYPE_CLIENTCSA = 21,

        /// <summary>Headquarters Main Phone Number</summary>
        /// <remarks>The main phone number for a company or organization's headquarters location.</remarks>
        [XmlEnum("22")]
        OLI_PHONETYPE_HDQRTRS = 22,

        /// <summary>Primary Phone</summary>
        /// <remarks>Used when a phone number has been designated as the primary number for phone contact. No other information (home, mobile, business, etc.) is known.</remarks>
        [XmlEnum("26")]
        OLI_PHONETYPE_PRIMARY = 26,

        /// <summary>Secondary or Alternate Phone</summary>
        /// <remarks>Used when a phone number has been designated as the secondary or alternate address for phone contact when use of the Primary Phone Number is unsuccessful. For example, the Primary Phone Number may no longer be in service or the voice mailbox may be full. No other information (home, mobile, business, etc.) is known.</remarks>
        [XmlEnum("27")]
        OLI_PHONETYPE_ALTERNATE = 27,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
