using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_BANKACCTTYPE_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Savings Account</summary>
        [XmlEnum("1")]
        OLI_BANKACCT_SAVINGS = 1,

        /// <summary>Checking Account</summary>
        [XmlEnum("2")]
        OLI_BANKACCT_CHECKING = 2,

        /// <summary>Credit Card</summary>
        [XmlEnum("3")]
        OLI_BANKACCT_CREDITCARD = 3,

        /// <summary>Debit Card</summary>
        [XmlEnum("4")]
        OLI_BANKACCT_DEBITCARD = 4,

        /// <summary>Brokerage Account</summary>
        /// <remarks>An account at a brokerage by which a customer may place money in order to make trades.</remarks>
        [XmlEnum("5")]
        OLI_BANKACCT_BA = 5,

        /// <summary>CD - Certificate of Deposit</summary>
        /// <remarks>Bank account type of CD. This is the actual certificate of deposit account.</remarks>
        [XmlEnum("7")]
        OLI_BANKACCT_CD = 7,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
