using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_GOVTIDTC_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Social Security Number US</summary>
        [XmlEnum("1")]
        OLI_GOVTID_SSN = 1,

        /// <summary>Taxpayer Identification Number</summary>
        /// <remarks>Corporation, Partnership, Doing Business As, Trust, etc</remarks>
        [XmlEnum("2")]
        OLI_GOVTID_TID = 2,

        /// <summary>Social Insurance Number in Canada</summary>
        [XmlEnum("3")]
        OLI_GOVTID_SIN = 3,

        /// <summary>Tax Reference Number South Africa</summary>
        [XmlEnum("4")]
        OLI_GOVTID_TRN = 4,

        /// <summary>ACN number Australia</summary>
        [XmlEnum("5")]
        OLI_GOVTID_ACN = 5,

        /// <summary>ARBN number Australia</summary>
        [XmlEnum("6")]
        OLI_GOVTID_ARBN = 6,

        /// <summary>SIS number Australia</summary>
        [XmlEnum("7")]
        OLI_GOVTID_SIS = 7,

        /// <summary>US Employer Identification Number</summary>
        [XmlEnum("8")]
        OLI_GOVTID_USEMPID = 8,

        /// <summary>Tax ID for US non-resident alien</summary>
        [XmlEnum("9")]
        OLI_GOVTID_USNONRESTID = 9,

        /// <summary>Generic Foreign ID</summary>
        /// <remarks>A generic ID from a foreign country. The country may or may not be known.</remarks>
        [XmlEnum("10")]
        OLI_GOVTID_CITIZENSHIPID = 10,

        /// <summary>Canadian Business Number</summary>
        /// <remarks>This is the business number assigned to an corporation by the Canadian Government</remarks>
        [XmlEnum("11")]
        OLI_GOVTID_CANBN = 11,

        /// <summary>Canadian Quebec Enterprise Number</summary>
        /// <remarks>This is the enterprise number assigned to an corporation by the Canadian Quebec Government</remarks>
        [XmlEnum("12")]
        OLI_GOVTID_CANNEQ = 12,

        /// <summary>Canadian Employer Identification Number</summary>
        /// <remarks>The Employer ID Number assigned to an corporation by the Canadian Government</remarks>
        [XmlEnum("13")]
        OLI_GOVTID_CANEIN = 13,

        /// <summary>Passport Number</summary>
        /// <remarks>Indicates the GovtID is a Passport Number or Identifier.</remarks>
        [XmlEnum("17")]
        OLI_GOVTID_PASSPORTID = 17,

        /// <summary>Green Card (US)</summary>
        /// <remarks>Indicates the GovtID is a US issued "Green Card" (INS Alien Registration Receipt Card) Number or Identifier which is issued as proof of permanent residency for a non-US citizen living in the US.</remarks>
        [XmlEnum("18")]
        OLI_GOVTID_GREENCARD = 18,

        /// <summary>Medicare Number</summary>
        /// <remarks>The number entered is a Medicare Number in the United States.</remarks>
        [XmlEnum("19")]
        OLI_GOVTID_MEDICARENUM = 19,

        /// <summary>Medicaid Number</summary>
        /// <remarks>The number entered is a Medicaid Number in the United States.</remarks>
        [XmlEnum("20")]
        OLI_GOVTID_MEDICAIDNUM = 20,

        /// <summary>Chinese Military ID</summary>
        /// <remarks>China began a residential identity card system in 1985 which ruled that servicemen and armed police had separate military or armed police cards instead of civilian identity cards. A Law on Resident Identity Cards which came into effect in 2004 for the first time enlarged the card issuance scope to servicemen and armed police.OLI_GOVTID_CHINAMIL represents this card.</remarks>
        [XmlEnum("21")]
        OLI_GOVTID_CHINAMIL = 21,

        /// <summary>National Provider Identifier (NPI)</summary>
        /// <remarks>A National Provider Identifier or NPI is a unique 10-digit identification number issued to health care providers in the United States by the Centers for Medicare and Medicaid Services</remarks>
        [XmlEnum("22")]
        OLI_GOVTID_NPI = 22,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
