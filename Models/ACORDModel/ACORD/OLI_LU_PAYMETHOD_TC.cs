using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_PAYMETHOD_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>No Billing</summary>
        [XmlEnum("1")]
        OLI_PAYMETH_NOBILL = 1,

        /// <summary>Regular Billing</summary>
        /// <remarks>Regular or Direct Billing</remarks>
        [XmlEnum("2")]
        OLI_PAYMETH_REGBILL = 2,

        /// <summary>Irregular Billing</summary>
        [XmlEnum("3")]
        OLI_PAYMETH_IRREGBILL = 3,

        /// <summary>Paid in Advance</summary>
        [XmlEnum("4")]
        OLI_PAYMETH_PAID = 4,

        /// <summary>List Bill</summary>
        /// <remarks>Multiple policy bills are sent in a single logical "bill" (physical or electronic), and that the recipient of the bill (e.g. a corporate owner) is the source of the funds to pay the bill.</remarks>
        [XmlEnum("5")]
        OLI_PAYMENT_LISTBILL = 5,

        /// <summary>Payroll Deduction</summary>
        /// <remarks>Multiple policy bills are sent in a single logical "bill" (physical or electronic), but that payroll deductions of the multiple insured's are the source of the funds to pay the bill.</remarks>
        [XmlEnum("6")]
        OLI_PAYMENT_PAYROLL = 6,

        /// <summary>Electronic Funds Transfer</summary>
        /// <remarks>Traditional EFT, like ACH: Automated Clearing House. Use Pre-Authorized Check for PAC.</remarks>
        [XmlEnum("7")]
        OLI_PAYMETH_ETRANS = 7,

        /// <summary>Government Allotment</summary>
        /// <remarks>Fraction amounts are collected via payroll deduction by a government agency and submitted to the carrier (without a "bill"), and the carrier aggregates these amounts until enough to pay the next modal premium is accumulated.</remarks>
        [XmlEnum("8")]
        OLI_PAYMENT_GOVALLOT = 8,

        /// <summary>Credit Card Billing</summary>
        [XmlEnum("9")]
        OLI_PAYMETH_CREDCARD = 9,

        /// <summary>Collection Institution</summary>
        [XmlEnum("10")]
        OLI_PAYMETH_COLLECTION = 10,

        /// <summary>Suspended Billing</summary>
        [XmlEnum("11")]
        OLI_PAYMETH_SUSPNDBILL = 11,

        /// <summary>Pay from a Premium Deposit Fund</summary>
        [XmlEnum("12")]
        OLI_PAYMETH_PREMDEPFUND = 12,

        /// <summary>Pay from Special Accounts</summary>
        /// <remarks>The payment for the policy will come from "special accounts".  An example is Salary Savings. Special Accounts payment method would be any payments outside of modal orbank draft.  IE. salary savings, commercial company payments, etc."</remarks>
        [XmlEnum("13")]
        OLI_PAYMETH_SPECACCT = 13,

        /// <summary>Combined Billing</summary>
        /// <remarks>This is usually used for a private policy owner who has numerous personal policies for himself / herself and maybe for others intheir household.</remarks>
        [XmlEnum("14")]
        OLI_PAYMETH_COMBBILL = 14,

        /// <summary>Automatic Premium Loan</summary>
        [XmlEnum("15")]
        OLI_PAYMETH_APL = 15,

        /// <summary>Discounted Premium</summary>
        [XmlEnum("16")]
        OLI_PAYMETH_DISCPREM = 16,

        /// <summary>Dividends on Deposit</summary>
        /// <remarks>Premiums are paid systematically from the dividend accumulations on deposit.</remarks>
        [XmlEnum("17")]
        OLI_PAYMETH_DIVDEP = 17,

        /// <summary>Paid based on premium offset</summary>
        /// <remarks>Premium offset method in effect is defined using Life.PremOffsetMethod.  That field indicates what premium offset method is selected.  This value identifies when it has been invoked.</remarks>
        [XmlEnum("25")]
        OLI_PAYMETH_PREMOFF = 25,

        /// <summary>Pre-Authorized Check</summary>
        /// <remarks>A form of electronic fund transfer that may be processed differently from ACH (Automatic Clearing House). Includes Pre-Arranged Withdrawal (PAW).</remarks>
        [XmlEnum("26")]
        OLI_PAYMETH_PAC = 26,

        /// <summary>Receiving Carrier to Request Release of Funds</summary>
        /// <remarks>The Receiving Carrier will need to Request the release of funds, based upon paperwork to follow or on instructions included with the transaction.</remarks>
        [XmlEnum("27")]
        OLI_PAYMETH_CARRIERREQ = 27,

        /// <summary>Distributor Has Requested Release of Funds</summary>
        /// <remarks>The Distributor has requested the release of funds, which will follow.  For a new policy, the carrier should initiate the set up of the policy.</remarks>
        [XmlEnum("28")]
        OLI_PAYMETH_DISTRIREQ = 28,

        /// <summary>Pre-signed, post dated cheques</summary>
        /// <remarks>The cheques are signed in advance and are post dated to correlate with premium due dates.</remarks>
        [XmlEnum("29")]
        OLI_PAYMETH_POSTDATECHK = 29,

        /// <summary>Premium Waiver</summary>
        /// <remarks>A premium waiver is in effect</remarks>
        [XmlEnum("30")]
        OLI_PAYMETH_WAIVER = 30,

        /// <summary>Deferred Premium Facility</summary>
        /// <remarks>This indicates that premiums have been deferred until a future date as the Savings Benefit is being used as security for the deferred premiums.</remarks>
        [XmlEnum("31")]
        OLI_PAYMETH_DPF = 31,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
