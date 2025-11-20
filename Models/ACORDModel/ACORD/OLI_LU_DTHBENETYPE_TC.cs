using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_DTHBENETYPE_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Level (DB = Face)</summary>
        [XmlEnum("1")]
        OLI_DBOPT_LEVEL = 1,

        /// <summary>Increasing (DB = Face + Cash)</summary>
        [XmlEnum("2")]
        OLI_DBOPT_INCR = 2,

        /// <summary>Increasing (DB = Face + Return of Cumulative Premiums)</summary>
        [XmlEnum("3")]
        OLI_DBOPT_RETPREM = 3,

        /// <summary>Increasing (Face + Simple Percent)</summary>
        /// <remarks>Increasing Death Benefit Option that combines face value with a defined simple percent. The percent increase can be define using the DeathBenefitPctInc property of the coverage object</remarks>
        [XmlEnum("4")]
        OLI_DBOPT_SIMPPCT = 4,

        /// <summary>Increasing (Face + Compound Percent)</summary>
        /// <remarks>Increasing Death Benefit Option that combines face value with a defined compound percent. The percent increase can be define using the DeathBenefitPctInc property of the coverage object</remarks>
        [XmlEnum("5")]
        OLI_DBOPT_COMPPCT = 5,

        /// <summary>Increasing (DB = Return of Cumulative Premiums)</summary>
        [XmlEnum("6")]
        OLI_DBOPT_RETPREMONLY = 6,

        /// <summary>Increasing (Face + Sum of Deposits with Interest)</summary>
        /// <remarks>Increasing Death Benefit (DB) where DB = Face + Sum of All Deposits with Interest.</remarks>
        [XmlEnum("7")]
        OLI_DBOPT_RETDEP = 7,

        /// <summary>Increasing DB based on client specified schedule.</summary>
        /// <remarks>Schedule is Holding-specific, determined by the client at time of issue and retained on file with the policy pages for the contract.  Special handling is required for these cases.</remarks>
        [XmlEnum("8")]
        OLI_DBOPT_INCSPEC = 8,

        /// <summary>Decreasing DB based on client specified schedule.</summary>
        /// <remarks>Schedule is Holding-specific,  determined by the client at time of issue and retained on file with the policy pages for the contract.  Special handling is required for these cases.</remarks>
        [XmlEnum("9")]
        OLI_DBOPT_DECSPEC = 9,

        /// <summary>Decreasing based on a commuted value</summary>
        [XmlEnum("10")]
        OLI_DBOPT_DECCOMMUTED = 10,

        /// <summary>Level Choice (DB=greater of Face or Investment AV)</summary>
        /// <remarks>The beneficiary will receive the greater of the sum insured and the investment account value.</remarks>
        [XmlEnum("11")]
        OLI_DBOPT_GTFACEORINV = 11,

        /// <summary>Increasing by Greater of Invest AV or Net Deposits</summary>
        /// <remarks>The beneficiary will receive the sum insured plus the greater of the investment account value and the sum of all deposits to the investment accounts, without interest.  (i,e. DB = Face amount + greater of Investment Account Value and sum of all Deposits without interest, less any withdrawals and associated charges)</remarks>
        [XmlEnum("12")]
        OLI_DBOPT_FACEANDINVORDEP = 12,

        /// <summary>Increasing Choice (Greater of sum insured and FV)</summary>
        /// <remarks>Compound index factor chosen by the client, within carrier's allowed boundaries. These increases are subject to a maximum represented by the initial sum insured multiplied by a factor determined by the carrier (e.g. 4 times the initial sum insured). The beneficiary receives the greater of the sum insured and the investment fund value (FV).  (i.e. DB = Greater of Face + compound and Investment Account Value)</remarks>
        [XmlEnum("13")]
        OLI_DBOPT_FACECOMPORINV = 13,

        /// <summary>Adjustable</summary>
        /// <remarks>Adjustable based on a pricing matrix that is reviewed periodically and adjusted based on certain market conditions.</remarks>
        [XmlEnum("14")]
        OLI_DBOPT_ADJ = 14,

        /// <summary>Increasing (DB = Face Amount + interest percent)</summary>
        /// <remarks>The beneficiary will receive the sum insured increased based on an interest rate.</remarks>
        [XmlEnum("15")]
        OLI_DBOPT_FACECPI = 15,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
