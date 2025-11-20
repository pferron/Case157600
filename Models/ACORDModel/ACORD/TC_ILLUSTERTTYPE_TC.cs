using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum TC_ILLUSTERTTYPE_TC
    {
        /// <summary>Specified Amount of Cash Value</summary>
        /// <remarks>The amount of target cash value will be specified in the Illustration Transaction Amt. This is the default.</remarks>
        [XmlEnum("170")]
        ILL_TER_CASHVAL_SPECAMT = 170,

        /// <summary>Endowment Cash Value</summary>
        /// <remarks>The amount of target cash value is assumed to be the face amount of the policy so as to endow the policy.  When solving for a coverage amount, this is an unknown amount and cannot be specified.</remarks>
        [XmlEnum("171")]
        ILL_TER_CASHVAL_ENDOW = 171,

        /// <summary>External Transfer In</summary>
        /// <remarks>Perform an external transfer in on the transaction date</remarks>
        [XmlEnum("400")]
        ILL_TER_EXTERNAL_TRANSFER = 400,

        /// <summary>1035 Exchange</summary>
        /// <remarks>Perform a 1035 exchange payment on the specified date</remarks>
        [XmlEnum("401")]
        ILL_TER_1035EXCHANGE = 401,

        /// <summary>lifetime (default)</summary>
        [XmlEnum("3370")]
        ILL_TER_PREMGDB_LIFETIME = 3370,

        /// <summary>limited</summary>
        [XmlEnum("3371")]
        ILL_TER_PREMGDB_LIMITED = 3371,

        /// <summary>Loaded</summary>
        [XmlEnum("3411")]
        ILL_TER_PREMTXN_LOADED = 3411,

        /// <summary>Unloaded</summary>
        [XmlEnum("3412")]
        ILL_TER_PREMTXN_UNLOADED = 3412,

        /// <summary>Distribution as transaction amount</summary>
        [XmlEnum("3500")]
        ILL_TER_PREMTXN_ALLOCTAX = 3500,

        /// <summary>Amount Specified / Before Tax</summary>
        [XmlEnum("3501")]
        ILL_TER_TXNAMT_BFRTAX = 3501,

        /// <summary>Amount Specified / After Tax Gross Up</summary>
        [XmlEnum("3502")]
        ILL_TER_TXNAMT_AFTRTAXGROSS = 3502,

        /// <summary>After Tax / Switch to loans as transaction amount</summary>
        [XmlEnum("3503")]
        ILL_TER_TXNAMT_AFTRTAXLOAN = 3503,

        /// <summary>After Tax/Gross up/then loans as transaction amout</summary>
        [XmlEnum("3504")]
        ILL_TER_TXNAMT_AFTRTAXGULOAN = 3504,

        /// <summary>Preferred loans followed by withdrawal to basis followed by regular loan as transaction amount</summary>
        [XmlEnum("3505")]
        ILL_TER_TXNAMT_PREFLOAN = 3505,

        /// <summary>Before Tax</summary>
        [XmlEnum("3511")]
        ILL_TER_MAX_BFRTAX = 3511,

        /// <summary>After Tax Gross Up</summary>
        [XmlEnum("3512")]
        ILL_TER_MAX_AFRTAXGROSS = 3512,

        /// <summary>After Tax / Switch to loans as max amount</summary>
        [XmlEnum("3513")]
        ILL_TER_MAX_AFRTAXLOAN = 3513,

        /// <summary>After Tax / Gross up / then loans as max amount</summary>
        [XmlEnum("3514")]
        ILL_TER_MAX_AFRTAXGULOAN = 3514,

        /// <summary>Preferred loans followed by withdrawal to basis followed by regular loan as max amount</summary>
        [XmlEnum("3515")]
        ILL_TER_MAX_PREFLOAN = 3515,

        /// <summary>Withdrawal as transaction amount (default)</summary>
        [XmlEnum("3520")]
        ILL_TER_SURRPARTIAL_WTHDRWL = 3520,

        /// <summary>Over the specified period, withdraw cumulative premiums less surrender fees paid as of start of transaction.</summary>
        /// <remarks>Example -- if cumulative premiums are 20,000, then over period I get back 20,000.</remarks>
        [XmlEnum("3521")]
        ILL_TER_SURRPARTIAL_CUMPREM = 3521,

        /// <summary>Over specified period, withdraw current basis.</summary>
        /// <remarks>withdraw current basis"</remarks>
        [XmlEnum("3522")]
        ILL_TER_SURRPARTIAL_WITHSPDPRD = 3522,

        /// <summary>Withdraw current year maximum premium</summary>
        [XmlEnum("3523")]
        ILL_TER_SURRPARTIAL_WITHCURRYR = 3523,

        /// <summary>Loan as transaction amount (default)</summary>
        [XmlEnum("3530")]
        ILL_TER_SCHEDLOANAMT_TXNAMT = 3530,

        /// <summary>Max Regular loan available at time</summary>
        [XmlEnum("3531")]
        ILL_TER_SCHEDLOANAMT_MAX = 3531,

        /// <summary>Max Preferred loan available at time</summary>
        [XmlEnum("3532")]
        ILL_TER_SCHEDLOANAMT_MAXPREF = 3532,

        /// <summary>Over the specified period, take loans equal to cumulative premiums as start of this transaction.</summary>
        /// <remarks>take loans equal to cumulative premiums as start of this transaction"</remarks>
        [XmlEnum("3533")]
        ILL_TER_SCHEDLOANAMT_CUMPREM = 3533,

        /// <summary>Percentage of cash value</summary>
        [XmlEnum("3534")]
        ILL_TER_SCHEDLOANAMT_CVPCT = 3534,

        /// <summary>A (125 %)</summary>
        [XmlEnum("31511")]
        ILL_TER_UNDCHG_TBLRTNG_A = 31511,

        /// <summary>AA (137.5 %)</summary>
        [XmlEnum("31512")]
        ILL_TER_UNDCHG_TBLRTNG_AA = 31512,

        /// <summary>B (150 %)</summary>
        [XmlEnum("31513")]
        ILL_TER_UNDCHG_TBLRTNG_B = 31513,

        /// <summary>BB (162.5 %)</summary>
        [XmlEnum("31514")]
        ILL_TER_UNDCHG_TBLRTNG_BB = 31514,

        /// <summary>C (175 %)</summary>
        [XmlEnum("31515")]
        ILL_TER_UNDCHG_TBLRTNG_C = 31515,

        /// <summary>D (200 %)</summary>
        [XmlEnum("31516")]
        ILL_TER_UNDCHG_TBLRTNG_D = 31516,

        /// <summary>E (225 %)</summary>
        [XmlEnum("31517")]
        ILL_TER_UNDCHG_TBLRTNG_E = 31517,

        /// <summary>F (250 %)</summary>
        [XmlEnum("31518")]
        ILL_TER_UNDCHG_TBLRTNG_F = 31518,

        /// <summary>G (275 %)</summary>
        [XmlEnum("31519")]
        ILL_TER_UNDCHG_TBLRTNG_G = 31519,

        /// <summary>Nonsmoker</summary>
        [XmlEnum("31521")]
        ILL_TER_UNDCHG_SMOKERSTAT_NON = 31521,

        /// <summary>Smoker</summary>
        [XmlEnum("31522")]
        ILL_TER_UNDCHG_SMOKERSTAT_SMKR = 31522,

        /// <summary>H (300 %)</summary>
        [XmlEnum("315110")]
        ILL_TER_UNDCHG_TBLRTNG_H = 315110,

        /// <summary>I (325 %)</summary>
        [XmlEnum("315111")]
        ILL_TER_UNDCHG_TBLRTNG_I = 315111,

        /// <summary>J (350 %)</summary>
        [XmlEnum("315112")]
        ILL_TER_UNDCHG_TBLRTNG_J = 315112,

        /// <summary>K (375 %)</summary>
        [XmlEnum("315113")]
        ILL_TER_UNDCHG_TBLRTNG_K = 315113,

        /// <summary>L (400 %)</summary>
        [XmlEnum("315114")]
        ILL_TER_UNDCHG_TBLRTNG_L = 315114,

        /// <summary>M (425 %)</summary>
        [XmlEnum("315115")]
        ILL_TER_UNDCHG_TBLRTNG_M = 315115,

        /// <summary>N (450 %)</summary>
        [XmlEnum("315116")]
        ILL_TER_UNDCHG_TBLRTNG_N = 315116,

        /// <summary>O (475 %)</summary>
        [XmlEnum("315117")]
        ILL_TER_UNDCHG_TBLRTNG_O = 315117,

        /// <summary>P (500 %)</summary>
        [XmlEnum("315118")]
        ILL_TER_UNDCHG_TBLRTNG_P = 315118,

        /// <summary>U (uninsurable and/or declined)</summary>
        [XmlEnum("315119")]
        ILL_TER_UNDCHG_TBLRTNG_U = 315119,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
