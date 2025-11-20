using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_INCOPTION_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Life Only</summary>
        [XmlEnum("1")]
        OLI_IO_LIFEONLY = 1,

        /// <summary>Greater of Period Certain and Life</summary>
        /// <remarks>Payments are made through the greater of the specified certain periods or to the covered person's (or persons' on a joint) death.</remarks>
        [XmlEnum("2")]
        OLI_IO_CERTANDLIFE = 2,

        /// <summary>Period Certain Only</summary>
        /// <remarks>Payments will be made through the number of specified certain periods, regardless of when the covered person(s) death occurs.</remarks>
        [XmlEnum("3")]
        OLI_IO_CERTONLY = 3,

        /// <summary>Lesser of Period Certain and Life</summary>
        /// <remarks>Payments are made through the specified certain periods, but will cease if the covered person's (or persons' on a joint) death occurs before the periods are completed.</remarks>
        [XmlEnum("4")]
        OLI_IO_CERTORLIFE = 4,

        /// <summary>Life Plus Lump Sum (AKA Lump Sum Refund)</summary>
        [XmlEnum("5")]
        OLI_IO_LIFEPLUSLUMP = 5,

        /// <summary>Payable in one lump sum refund</summary>
        [XmlEnum("6")]
        OLI_IO_LUMPSUM = 6,

        /// <summary>Required Minimum Distribution</summary>
        [XmlEnum("7")]
        OLI_IO_RMD = 7,

        /// <summary>Deposit At interest</summary>
        [XmlEnum("8")]
        OLI_IO_DEPOSITINT = 8,

        /// <summary>Life Plus Installment Refund</summary>
        /// <remarks>The payout lasts for the life of the annuitant. Upon death, an additional installment payments are made of any remaining principal (i.e. "return of premium") to the contract beneficiary/ies.</remarks>
        [XmlEnum("9")]
        OLI_IO_CASHREFUND = 9,

        /// <summary>Pay a percentage of Accumulated Value</summary>
        /// <remarks>It indicates that the annuitant will be paid a stipulated percentage of his accumulated value each year.</remarks>
        [XmlEnum("10")]
        OLI_IO_PERCVALUE = 10,

        /// <summary>Maximum distribution</summary>
        /// <remarks>The income payment is the annual maximum specified by the current tax legislation</remarks>
        [XmlEnum("11")]
        OLI_IO_TAXMAX = 11,

        /// <summary>Indexed</summary>
        /// <remarks>The income payment  will be increased by the Consumer Pricing Index each year</remarks>
        [XmlEnum("12")]
        OLI_IO_INDEXED = 12,

        /// <summary>Percentage Increase</summary>
        /// <remarks>The income payment will be increased by an amount specified by the policyholder each year.</remarks>
        [XmlEnum("13")]
        OLI_IO_PERINC = 13,

        /// <summary>Level</summary>
        /// <remarks>The client specifies a level income payment. It will remain level for a specified period , a specified age,  or until changed by the client.</remarks>
        [XmlEnum("14")]
        OLI_IO_LEVEL = 14,

        /// <summary>Customer Specified</summary>
        /// <remarks>The client chooses  a specified amount that continues until the funds are exhausted.</remarks>
        [XmlEnum("15")]
        OLI_IO_SPEC = 15,

        /// <summary>Interest Only</summary>
        /// <remarks>The amount paid out  is only the interest earned on investment</remarks>
        [XmlEnum("16")]
        OLI_IO_INT = 16,

        /// <summary>Carry Forward</summary>
        /// <remarks>The difference between the legislated maximum amount and the actual amount paid out within a calendar year which can be carried forward to the next calendar year.</remarks>
        [XmlEnum("17")]
        OLI_IO_CRRYFRWD = 17,

        /// <summary>Dividend Payment</summary>
        /// <remarks>The payout to the client is equivalent to the dividend payment earned.</remarks>
        [XmlEnum("18")]
        OLI_IO_DIVIDEND_PAY = 18,

        /// <summary>Fixed Amount Plus Interest</summary>
        /// <remarks>The client specifies a fixed amount plus a percentage based upon the interest made on the policy.</remarks>
        [XmlEnum("19")]
        OLI_IO_FIXED_PLUS_INT = 19,

        /// <summary>Initial lump sum and period certain</summary>
        /// <remarks>Pay the beneficiary a lump sum at insured's death, then a period income stream for  the number of specified certain periods, and any fund left at end will be paid with a final lunp sum.</remarks>
        [XmlEnum("22")]
        OLI_IO_LUMPANDCERT = 22,

        /// <summary>Life with Return of Premium</summary>
        /// <remarks>The option is Life  with a Return of Premium where when the annuitant dies a percentage of the premium is returned to the Beneficiary.</remarks>
        [XmlEnum("23")]
        OLI_IO_LIFEWITHRETURN = 23,

        /// <summary>Fixed Settlement Option Endorsement</summary>
        /// <remarks>Fixed Settlement Option Endorsement</remarks>
        [XmlEnum("24")]
        OLI_IO_FIXSETTLMNTOPTENDORSMNT = 24,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
