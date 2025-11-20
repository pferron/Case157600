using System;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.LPES.Base
{
    /// <remarks/>
    [Serializable()]
    [XmlType(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    public enum FIP_QUAL_PLAN_TYPE_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Workplace Non-Qualified</summary>
        [XmlEnum("7")]
        WORKPLACE_NON_QUALIFIED = 7,

        /// <summary>Workplace Traditional IRA</summary>
        [XmlEnum("8")]
        WORKPLACE_TRADITIONAL_IRA = 8,

        /// <summary>Workplace Roth IRA</summary>
        [XmlEnum("9")]
        WORKPLACE_ROTH_IRA = 9,

        /// <summary>Payroll Deduction Non-Qualified</summary>
        [XmlEnum("10")]
        PAYROLL_DEDUCTION_NONQUALIFIED = 10,

        /// <summary>Payroll Deduction Traditional IRA</summary>
        [XmlEnum("11")]
        PAYROLL_DEDUCTION_TRADITIONAL_IRA = 11,

        /// <summary>Payroll Deduction Roth IRA</summary>
        [XmlEnum("12")]
        PAYROLL_DEDUCTION_ROTH_IRA = 12,

        /// <summary>Payroll SEP</summary>
        [XmlEnum("13")]
        PAYROLL_SEP = 13,

        /// <summary>Payroll SIMPLE</summary>
        [XmlEnum("14")]
        PAYROLL_SIMPLE = 14,

        /// <summary>Payroll TSA</summary>
        [XmlEnum("15")]
        PAYROLL_TSA = 15,

        /// <summary>Workplace SEP IRA</summary>
        [XmlEnum("21")]
        WORKPLACE_SEP_IRA = 21,

        /// <summary>Workplace SIMPLE IRA</summary>
        [XmlEnum("22")]
        WORKPLACE_SIMPLE_IRA = 22,

        /// <summary>Workplace TSA</summary>
        [XmlEnum("23")]
        WORKPLACE_TSA = 23,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647
    }
}
