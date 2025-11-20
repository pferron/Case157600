using System;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.LPES.Base
{
    /// <remarks/>
    [Serializable()]
    [XmlType(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    public enum FIP_ILLUS_TXN_SECONDARY_TYPE_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Solve for (Face/Premium Option)</summary>
        [XmlEnum("5")]
        SOLVE_FOR = 5,

        /// <summary>Max-out at Issue (Face/Premium Option)</summary>
        [XmlEnum("10")]
        MAX_OUT_AT_ISSUE = 10,

        /// <summary>NLG (Face Option) OR To Age 120 (Premium Option)</summary>
        [XmlEnum("12")]
        NO_LAPSE_GUARANTEE_OR_TO_AGE_120 = 12,

        /// <summary>To Age 80 (Premium Option)</summary>
        [XmlEnum("13")]
        TO_AGE_80 = 13,

        /// <summary>To Age 100 (Premium Option)</summary>
        [XmlEnum("14")]
        TO_AGE_100 = 14,

        /// <summary>Left With Woodmen at Interest</summary>
        [XmlEnum("107")]
        LEFT_WITH_WOODMEN_AT_INTEREST = 107,

        /// <summary>Loan Repayment/Paid Up Additional Insurance</summary>
        [XmlEnum("111")]
        LOAN_REPAY_PAID_UP_ADDITIONAL_INSURANCE = 111,

        /// <summary>Loan Repayment/Reduce Premiums</summary>
        [XmlEnum("113")]
        LOAN_REPAY_REDUCE_PREMIUMS = 113,

        /// <summary>Loan Repayment/Cash</summary>
        [XmlEnum("114")]
        LOAN_REPAY_CASH = 114,

        /// <summary>Loan Repayment/Left With Woodmen at Interest</summary>
        [XmlEnum("117")]
        LOAN_REPAY_LEFT_WITH_WOODMEN_AT_INTEREST = 117,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
