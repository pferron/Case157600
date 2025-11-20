using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_CREDCARDTYPE_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,


        /// <summary>Discover</summary>
        [XmlEnum("1")]
        OLI_CREDCARDTYPE_DISCOVER = 1,


        /// <summary>Visa</summary>
        [XmlEnum("2")]
        OLI_CREDCARDTYPE_VISA = 2,


        /// <summary>Master Card</summary>
        [XmlEnum("3")]
        OLI_CREDCARDTYPE_MC = 3,


        /// <summary>American Express</summary>
        [XmlEnum("4")]
        OLI_CREDCARD_AMEX = 4,


        /// <summary>Diner's Club</summary>
        [XmlEnum("5")]
        OLI_CREDCARDTYPE_DINERS = 5,


        /// <summary>Bank Card</summary>
        [XmlEnum("6")]
        OLI_CREDCARDTYPE_BANKCARD = 6,


        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
