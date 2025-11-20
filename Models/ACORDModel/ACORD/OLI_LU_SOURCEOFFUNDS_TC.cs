using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_SOURCEOFFUNDS_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Voluntary Cash</summary>
        /// <remarks>Normal cash contribution. (In cases where there are employee and employer contributions this represents the employee's contribution.)</remarks>
        [XmlEnum("1")]
        OLI_SOURCE_CASH = 1,

        /// <summary>1035 Exchange</summary>
        [XmlEnum("2")]
        OLI_SOURCE_1035EXCH = 2,

        /// <summary>Death Benefit</summary>
        [XmlEnum("3")]
        OLI_SOURCE_DEATHBENEFIT = 3,

        /// <summary>Annuity</summary>
        [XmlEnum("4")]
        OLI_SOURCE_ANNUITY = 4,

        /// <summary>Pension</summary>
        /// <remarks>Money came from a Pension Fund, a Pension Plan or some other Tax Qualified plan</remarks>
        [XmlEnum("5")]
        OLI_SOURCE_PENSION = 5,

        /// <summary>Full Cash Surrender</summary>
        /// <remarks>Full Cash Surrender is sometimes one of the options for source of funding that appears on a policy application.</remarks>
        [XmlEnum("6")]
        OLI_SOURCE_FULLCASHSURR = 6,

        /// <summary>Partial Cash Surrender</summary>
        /// <remarks>Partial Cash Surrender is sometimes one of the options for source of funding that appears on a policy</remarks>
        [XmlEnum("7")]
        OLI_SOURCE_PARTCASHSURR = 7,

        /// <summary>Loan</summary>
        /// <remarks>Loan is sometimes one of the options for source of funding that appears on a policy application.</remarks>
        [XmlEnum("8")]
        OLI_SOURCE_LOAN = 8,

        /// <summary>Dividend</summary>
        /// <remarks>Dividends is sometimes one of the options for source of funding that appears on a policy application.</remarks>
        [XmlEnum("9")]
        OLI_SOURCE_DIVIDENDS = 9,

        /// <summary>Money from other policy reducing coverage amount</summary>
        /// <remarks>Withdrawal of cash value. Money from another policy which may reduce the existing policy's face amount is sometimes one of the options for source of funding that appears on a policy application.</remarks>
        [XmlEnum("10")]
        OLI_SOURCE_REDUCTIONCOV = 10,

        /// <summary>Earned Income</summary>
        /// <remarks>Earning Income amount is sometimes one of the options for source of funding that appears on a policy application.</remarks>
        [XmlEnum("11")]
        OLI_SOURCE_EARNEDINC = 11,

        /// <summary>Money Market Fund</summary>
        /// <remarks>Money from a Money Market Fund is sometimes one of the options for source of funding that appears on a policy application.</remarks>
        [XmlEnum("12")]
        OLI_SOURCE_MMKTFUND = 12,

        /// <summary>Certificate Of Deposit</summary>
        /// <remarks>Money from a certificate of deposit is sometimes one of the options for source of funding that appears on a policy application.</remarks>
        [XmlEnum("13")]
        OLI_SOURCE_CD = 13,

        /// <summary>Rollover/Transfer - Not Policy</summary>
        /// <remarks>Money rolled over or transferred from an instrument other than a policy is sometimes one of the options for source of funding that appears on a policy application.</remarks>
        [XmlEnum("14")]
        OLI_SOURCE_XFERNOTPOLICY = 14,

        /// <summary>Savings</summary>
        /// <remarks>Money from a savings account is sometimes one of the options for source of funding that appears on a policy application.</remarks>
        [XmlEnum("15")]
        OLI_SOURCE_SAVINGS = 15,

        /// <summary>Mutual Fund</summary>
        /// <remarks>Money from a mutual fund.</remarks>
        [XmlEnum("16")]
        OLI_SOURCE_MUTUALFUND = 16,

        /// <summary>Rollover/Transfer - Another Insurance Policy</summary>
        /// <remarks>Money rolled over or transferred from a policy is sometimes one of the options for source of funding that appears on a policy application.</remarks>
        [XmlEnum("17")]
        OLI_SOURCE_XFERPOLICY = 17,

        /// <summary>Gift</summary>
        [XmlEnum("18")]
        OLI_LU_SOURCE_GIFT = 18,

        /// <summary>Employer Contribution</summary>
        /// <remarks>In cases where there are employee and employer contributions this represents the employer's contribution.</remarks>
        [XmlEnum("19")]
        OLI_SOURCE_ERCONTRIBUTION = 19,

        /// <summary>Paid Up Additions</summary>
        /// <remarks>Paid-up insurance, commonly purchased under a dividend option, but may sometimes be purchased with additional premiums and/or lump sums. Since this insurance is purchased at premium rates based on the insured's original underwriting class, the right to purchase Paid-Up Additions is quite valuable. These additions have cash value as well as a death benefit. OR An option whereby the insured can leave dividends with the insurer, and each dividend is used to buy a single premium life insurance policy for whatever amount it will purchase. Also called Dividend Additions.</remarks>
        [XmlEnum("20")]
        OLI_SOURCE_PUA = 20,

        /// <summary>Life Insurance</summary>
        /// <remarks>Life insurance policy</remarks>
        [XmlEnum("22")]
        OLI_SOURCE_LIFEINSURANCE = 22,

        /// <summary>Retirement Annuity Fund</summary>
        /// <remarks>Money came from a Retirement Annuity Fund</remarks>
        [XmlEnum("26")]
        OLI_SOURCE_RAFUNDOWNED = 26,

        /// <summary>Provident Fund</summary>
        /// <remarks>Money came from a Provident Fund</remarks>
        [XmlEnum("27")]
        OLI_SOURCE_PROVFUNDOWNED = 27,

        /// <summary>Brokerage Account</summary>
        /// <remarks>Money from a brokerage account.</remarks>
        [XmlEnum("28")]
        OLI_SOURCE_BROKERAGEACCT = 28,

        /// <summary>Conversion Proceeds</summary>
        /// <remarks>Funds relating to a conversion</remarks>
        [XmlEnum("29")]
        OLI_SOURCE_CONV = 29,

        /// <summary>Policy Split</summary>
        /// <remarks>Money from splitting a policy into two or more policies.</remarks>
        [XmlEnum("30")]
        OLI_SOURCE_POLICYSPLT = 30,

        /// <summary>Inheritance</summary>
        /// <remarks>Money taken from an inheritance.</remarks>
        [XmlEnum("31")]
        OLI_SOURCE_INHERITANCE = 31,

        /// <summary>Retirement</summary>
        /// <remarks>Money taken from retirement funds other than pensions.</remarks>
        [XmlEnum("32")]
        OLI_SOURCE_RETIREMENT = 32,

        /// <summary>Social Security</summary>
        /// <remarks>Money taken from Social Security Payments</remarks>
        [XmlEnum("33")]
        OLI_SOURCE_SOCIALSECURITY = 33,

        /// <summary>Premium Deposit Fund</summary>
        /// <remarks>Account into which money is deposited so that amounts necessary to fund premium payments can be withdrawn on a modal basis.</remarks>
        [XmlEnum("34")]
        OLI_SOURCE_PREMDEPOSIT = 34,

        /// <summary>Multiple sources of funds such as Cash and 1035 money</summary>
        [XmlEnum("98")]
        OLI_SOURCE_MULTIPLE = 98,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
