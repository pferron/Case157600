using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum TC_ILLUSSECTYPE_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Death Benefit Option - Level</summary>
        [XmlEnum("11")]
        ILL_SEC_DBOPT_LEVEL = 11,

        /// <summary>Death Benefit Option / Increasing</summary>
        [XmlEnum("12")]
        ILL_SEC_DBOPT_INCR = 12,

        /// <summary>Death Benefit Option / Return of premium</summary>
        [XmlEnum("13")]
        ILL_SEC_DBOPT_RETPREM = 13,

        /// <summary>Always specified amount (default)</summary>
        [XmlEnum("20")]
        ILL_SEC_TAXBRACK_SPECAMT = 20,

        /// <summary>Apply transaction amount as specified premium (default)</summary>
        [XmlEnum("30")]
        ILL_SEC_PMTSCHD_SPECPREM = 30,

        /// <summary>Apply minimum premium * transaction amount (required multiple)</summary>
        [XmlEnum("31")]
        ILL_SEC_PMTSCHD_MINPREMXTXN = 31,

        /// <summary>Apply minimum premium + transaction amount (required adjusted)</summary>
        [XmlEnum("32")]
        ILL_SEC_PMTSCHD_PREMPLUSTXN = 32,

        /// <summary>Apply target premium * transaction amount (recommended multiple)</summary>
        [XmlEnum("33")]
        ILL_SEC_PMTSCHD_TRGTPREMXTXN = 33,

        /// <summary>Apply minimum premium</summary>
        [XmlEnum("34")]
        ILL_SEC_PMTSCHD_MPREM = 34,

        /// <summary>Apply Target premium</summary>
        [XmlEnum("35")]
        ILL_SEC_PMTSCHD_TRGTPREM = 35,

        /// <summary>Apply complete premium necessary to satisfy 7 pay (always point in time)</summary>
        [XmlEnum("36")]
        ILL_SEC_PMTSCHD_PREM7PAY = 36,

        /// <summary>Premium to satisfy guaranteed minimum death benefit</summary>
        [XmlEnum("37")]
        ILL_SEC_PMTSCHD_PREMGDB = 37,

        /// <summary>Pay to greater of GSP or GLP</summary>
        [XmlEnum("38")]
        ILL_SEC_PMTSCHD_GSPORGLP = 38,

        /// <summary>Pay to GLP</summary>
        [XmlEnum("39")]
        ILL_SEC_PMTSCHD_GLP = 39,

        /// <summary>Premium as transaction amount</summary>
        [XmlEnum("41")]
        ILL_SEC_NETPMT_PREMTXN = 41,

        /// <summary>Distribution as transaction amount (default)</summary>
        [XmlEnum("50")]
        ILL_SEC_DIST_TXNAMT = 50,

        /// <summary>Max distribution available at that time</summary>
        [XmlEnum("51")]
        ILL_SEC_DIST_MAX = 51,

        /// <summary>Scheduled withdrawals taken from the contract (partial surrender)</summary>
        [XmlEnum("52")]
        ILL_SEC_DIST_SURRPARTIAL = 52,

        /// <summary>Scheduled Loan amounts</summary>
        [XmlEnum("53")]
        ILL_SEC_SCHEDLOANAMT = 53,

        /// <summary>Annuitization</summary>
        [XmlEnum("54")]
        ILL_SEC_ANNUITIZATION = 54,

        /// <summary>Repay transaction amount (default)</summary>
        [XmlEnum("60")]
        ILL_SEC_LOANREPAYTXN = 60,

        /// <summary>Repay total loan</summary>
        [XmlEnum("61")]
        ILL_SEC_LOANREPAYTOTAL = 61,

        /// <summary>Pay accrued loan interest</summary>
        /// <remarks>Pay loan interest beginning with start date, through the end date, for  the mode specified in the Txn detail.</remarks>
        [XmlEnum("62")]
        ILL_SEC_PAY_PAY_LOAN_INT = 62,

        /// <summary>Specified Amount of Coverage Change</summary>
        /// <remarks>This indicates that the Illustration Transaction Amount will contain the amount of "change" for the coverage.A positive amount represents an increase in coverage , a negative amount signifies a reduction in coverage amount</remarks>
        [XmlEnum("70")]
        ILL_SEC_COV_TXNAMT = 70,

        /// <summary>Add coverage / benefit</summary>
        [XmlEnum("71")]
        ILL_SEC_COV_ADD = 71,

        /// <summary>End Coverage / Benefit</summary>
        [XmlEnum("72")]
        ILL_SEC_COV_END = 72,

        /// <summary>Minimum premium face</summary>
        [XmlEnum("73")]
        ILL_SEC_COV_MINPREM = 73,

        /// <summary>Target premium face</summary>
        [XmlEnum("74")]
        ILL_SEC_COV_TRGTPREM = 74,

        /// <summary>7 Pay face</summary>
        [XmlEnum("75")]
        ILL_SEC_COV_7PAY = 75,

        /// <summary>GDB Premium face</summary>
        [XmlEnum("76")]
        ILL_SEC_COV_GDBPREMFACE = 76,

        /// <summary>Lesser of GLP or GSP premium face</summary>
        [XmlEnum("77")]
        ILL_SEC_COV_GLPORGSP = 77,

        /// <summary>GLP premium face</summary>
        [XmlEnum("78")]
        ILL_SEC_COV_GLPPREMFACE = 78,

        /// <summary>Convert Coverage from term to perm</summary>
        [XmlEnum("79")]
        ILL_SEC_COV_CONVERSION = 79,

        /// <summary>Interest rate as transaction amount.  (default)</summary>
        [XmlEnum("80")]
        ILL_SEC_INTRATE_TXNAMT = 80,

        /// <summary>Guaranteed interest rate</summary>
        [XmlEnum("81")]
        ILL_SEC_INTRATE_GTD = 81,

        /// <summary>Current interest rate</summary>
        [XmlEnum("82")]
        ILL_SEC_INTRATE_CURRENT = 82,

        /// <summary>Use historical rates</summary>
        [XmlEnum("83")]
        ILL_SEC_INTRATE_HISTORICAL = 83,

        /// <summary>Use specified rate as a net rate</summary>
        [XmlEnum("84")]
        ILL_SEC_INTRATE_NETRATE = 84,

        /// <summary>Midpoint</summary>
        [XmlEnum("85")]
        ILL_SEC_INTRATE_MIDPOINT = 85,

        /// <summary>Blended percentage (example 0 30 indicates 30% guaranteed and 70% current)</summary>
        [XmlEnum("86")]
        ILL_SEC_INTRATE_BLENDPCT = 86,

        /// <summary>Blended percentage / (example 0 30 indicates 30% guaranteed and 70% current)</summary>
        [XmlEnum("91")]
        ILL_SEC_MORTRATE_BLENDPCT = 91,

        /// <summary>Current Rate (use 100% of current)</summary>
        [XmlEnum("92")]
        ILL_SEC_MORTRATE_CURRENT = 92,

        /// <summary>Guaranteed</summary>
        [XmlEnum("93")]
        ILL_SEC_MORTRATE_GTD = 93,

        /// <summary>Use amount to indicate multiplier of current (e.g. 120 for 120%)</summary>
        [XmlEnum("94")]
        ILL_SEC_MORTRATE_AMTBASED = 94,

        /// <summary>Amount specified (default)</summary>
        [XmlEnum("100")]
        ILL_SEC_TEMPFLATEXTRAAMT_SPEC = 100,

        /// <summary>Gross Accumulation Cash Value</summary>
        /// <remarks>Total accumulation value not reduced by loan balance or surrender charges</remarks>
        [XmlEnum("130")]
        ILL_SEC_CASHVAL_ACCUM = 130,

        /// <summary>Net Accumulation Cash Value</summary>
        /// <remarks>Total accumulation value reduced by loan balance, but not reduced by surrender charges</remarks>
        [XmlEnum("131")]
        ILL_SEC_CASHVAL_ACCUMNET = 131,

        /// <summary>Surrender Value</summary>
        /// <remarks>The total accumulation value reduced by applicable surrender charges</remarks>
        [XmlEnum("132")]
        ILL_SEC_CASHVAL_SURR = 132,

        /// <summary>Net Surrender Value</summary>
        /// <remarks>The Surrender Value reduced by the outstanding loan balance</remarks>
        [XmlEnum("133")]
        ILL_SEC_CASHVAL_SURRNET = 133,

        /// <summary>Net Accumulation Value for Life Income with 20 year Certain</summary>
        /// <remarks>Solve for the Net Accumulation Value that will achieve the specified monthly income for life expectancy and 20 year certainThis is popular with deferred annuities - instead of solving for a premium to achieve a  known amount of cash value - solve for the amount necessary to fund a specified life income</remarks>
        [XmlEnum("134")]
        ILL_SEC_CASHVAL_NETLIFE20INC = 134,

        /// <summary>Net Accumulation Value for Life Income</summary>
        /// <remarks>Solve for the Net Accumulation Value that will achieve the specified monthly income for life expectancyThis is popular with deferred annuities - instead of solving for a premium to achieve a  known amount of cash value - solve for the amount necessary to fund a specified life income</remarks>
        [XmlEnum("135")]
        ILL_SEC_CASHVAL_NETLIFEINC = 135,

        /// <summary>Net Accumulation Value for Life Income with 10 year Certain</summary>
        /// <remarks>Solve for the Net Accumulation Value that will achieve the specified monthly income for life expectancy and 10 year certainThis is popular with deferred annuities - instead of solving for a premium to achieve a  known amount of cash value - solve for the amount necessary to fund a specified life income</remarks>
        [XmlEnum("136")]
        ILL_SEC_CASHVAL_NETLIFE10INC = 136,

        /// <summary>Specified Amount of Total Coverage</summary>
        /// <remarks>This indicates that the Illustration Transaction Amount will contain the desired  amount of total coverage remaining.Because of intervening transactions that can adjust the coverage amount, such as changes to death benefit option or withdrawals this can provide different results than ILL_SEC_COV_TXNAMT  .</remarks>
        [XmlEnum("137")]
        ILL_SEC_COV_TXNAMTTOT = 137,

        /// <summary>Amount Specified / Before Tax</summary>
        [XmlEnum("141")]
        ILL_SEC_INCTAXOUT_BFRTAX = 141,

        /// <summary>Amount Specified / After Tax Gross Up</summary>
        [XmlEnum("142")]
        ILL_SEC_INCTAXOUT_AFRTAX = 142,

        /// <summary>After Tax / Switch to loans</summary>
        [XmlEnum("143")]
        ILL_SEC_INCTAXOUT_AFRTAXGROSS = 143,

        /// <summary>After Tax / Gross up / then loans</summary>
        [XmlEnum("144")]
        ILL_SEC_INCTAXOUT_AFRTAXGULOAN = 144,

        /// <summary>Preferred loans followed by withdrawal to basis followed by regular loan</summary>
        [XmlEnum("145")]
        ILL_SEC_INCTAXOUT_PREFLOAN = 145,

        /// <summary>Table Rating Change</summary>
        [XmlEnum("151")]
        ILL_SEC_UNDCHG_TBLRTNG = 151,

        /// <summary>Smoker Status Change</summary>
        [XmlEnum("152")]
        ILL_SEC_UNDCHG_SMOKERSTAT = 152,

        /// <summary>Paid in cash</summary>
        [XmlEnum("161")]
        ILL_SEC_DIVOPT_CASH = 161,

        /// <summary>Paid-Up Additions</summary>
        [XmlEnum("162")]
        ILL_SEC_DIVOPT_PUA = 162,

        /// <summary>Reduce Premium</summary>
        [XmlEnum("163")]
        ILL_SEC_DIVOPT_RED = 163,

        /// <summary>Accumulate at interest</summary>
        [XmlEnum("164")]
        ILL_SEC_DIVOPT_ACCUM = 164,

        /// <summary>Term Dividend Option (FULL)</summary>
        [XmlEnum("165")]
        ILL_SEC_DIVOPT_OYT = 165,

        /// <summary>Reduce premium, balance in cash</summary>
        /// <remarks>balance in cash"</remarks>
        [XmlEnum("166")]
        ILL_SEC_DIVOPT_REDCASH = 166,

        /// <summary>Reduce premium, balance to PUA</summary>
        /// <remarks>balance to PUA"</remarks>
        [XmlEnum("167")]
        ILL_SEC_DIVOPT_REDPUA = 167,

        /// <summary>Reduce premium, balance to accumulate</summary>
        /// <remarks>balance to accumulate"</remarks>
        [XmlEnum("168")]
        ILL_SEC_DIVOPT_REDACCUM = 168,

        /// <summary>Reduce loan values, balance in cash</summary>
        /// <remarks>balance in cash"</remarks>
        [XmlEnum("169")]
        ILL_SEC_DIVOPT_REDLNCASH = 169,

        /// <summary>Reduce loan values, balance to PUA</summary>
        /// <remarks>balance to PUA"</remarks>
        [XmlEnum("1610")]
        ILL_SEC_DIVOPT_REDLNPUA = 1610,

        /// <summary>Reduce loan values, balance to accumulate</summary>
        /// <remarks>balance to accumulate"</remarks>
        [XmlEnum("1611")]
        ILL_SEC_DIVOPT_REDLNACCUM = 1611,

        /// <summary>Add dividend to cash value (UL)</summary>
        [XmlEnum("1612")]
        ILL_SEC_DIVOPT_CV = 1612,

        /// <summary>Reduce Loan Values</summary>
        [XmlEnum("1613")]
        ILL_SEC_DIVOPT_REDLOAN = 1613,

        /// <summary>Specified amount in cash balance to PUA</summary>
        [XmlEnum("1614")]
        ILL_SEC_DIVOPT_SPECPUA = 1614,

        /// <summary>Economatic</summary>
        /// <remarks>Dividends payable under the Economatic Dividend Type are used to purchase an amount of One Year Term insurance and paid-up additions in such amounts that the total insurance provided continues the original amount of insurance.  This dividend option is available only on specified Economatic policies or on policies which have an Economatic rider attached. These products provide for a decrease in the base policy face amount, usually after three years.  The decreased face amount of the base policy insurance is referred to as the Ultimate Amount of insurance.  After the decrease, the annual dividend is used to purchase a combination of OYT and PUA insurance, the total of which is equivalent to the difference between the original and ultimate amounts of insurance.</remarks>
        [XmlEnum("1615")]
        ILL_SEC_DIVOPT_ECONO = 1615,

        /// <summary>Contract Fund</summary>
        [XmlEnum("1616")]
        ILL_SEC_DIVOPT_CONTRACT = 1616,

        /// <summary>Policy Improvement (improves until lifetime plan)</summary>
        [XmlEnum("1617")]
        ILL_SEC_DIVOPT_POLIMPROVE = 1617,

        /// <summary>Plan enhancement (improves until lifetime then shortens premium duration)</summary>
        [XmlEnum("1618")]
        ILL_SEC_DIVOPT_PLANENHANCE = 1618,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
