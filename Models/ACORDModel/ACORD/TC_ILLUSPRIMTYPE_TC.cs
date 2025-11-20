using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum TC_ILLUSPRIMTYPE_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Annual Death Benefit Option</summary>
        [XmlEnum("1")]
        ILL_PRI_DBOPT = 1,

        /// <summary>Tax Bracket of a Proposal</summary>
        [XmlEnum("2")]
        ILL_PRI_TAXBRACK = 2,

        /// <summary>Payment Schedule</summary>
        [XmlEnum("3")]
        ILL_PRI_PMTSCHD = 3,

        /// <summary>Net or lump-sum payments to the contract</summary>
        [XmlEnum("4")]
        ILL_PRI_NETPMT = 4,

        /// <summary>Distribution</summary>
        [XmlEnum("5")]
        ILL_PRI_DIST = 5,

        /// <summary>Loan repayment</summary>
        [XmlEnum("6")]
        ILL_PRI_LOANREPAY = 6,

        /// <summary>Coverage/Benefit</summary>
        [XmlEnum("7")]
        ILL_PRI_COV = 7,

        /// <summary>Interest rate for a scenario</summary>
        [XmlEnum("8")]
        ILL_PRI_INTRATE = 8,

        /// <summary>Mortality rate of a scenario</summary>
        [XmlEnum("9")]
        ILL_PRI_MORTRATE = 9,

        /// <summary>Temporary flat extra amount</summary>
        [XmlEnum("10")]
        ILL_PRI_TEMPFLATEXTRAAMT = 10,

        /// <summary>MEC Avoidance</summary>
        [XmlEnum("11")]
        ILL_PRI_MECAVOID = 11,

        /// <summary>MEC Remedy</summary>
        [XmlEnum("12")]
        ILL_PRI_MECREMEDY = 12,

        /// <summary>Prevent Lapse</summary>
        [XmlEnum("13")]
        ILL_PRI_PREVLAPSE = 13,

        /// <summary>Income Tax Outlay</summary>
        [XmlEnum("14")]
        ILL_PRI_INCTAX = 14,

        /// <summary>Change to underwriting class</summary>
        [XmlEnum("15")]
        ILL_PRI_UNDCHG = 15,

        /// <summary>Dividend Option</summary>
        [XmlEnum("16")]
        ILL_PRI_DIVOPT = 16,

        /// <summary>Cash Value</summary>
        /// <remarks>Only used for a solve. Specifies a cash value.  It can only being used in conjunction with an additional  Illustration Txn which is a solve.  The Search Goal Indicator must be true.</remarks>
        [XmlEnum("17")]
        ILL_PRI_TARGCV = 17,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
