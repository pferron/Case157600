using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_POLSTAT_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Active (inforce).</summary>
        /// <remarks>A Policy Status of 'Active' only indicates that at least one, but possibly more, coverage's or components of this contract are active. You must look at each individual coverage to determine the status of each specific component. If Any coverage is active the contract is active.</remarks>
        [XmlEnum("1")]
        OLI_POLSTAT_ACTIVE = 1,

        /// <summary>Inactive</summary>
        [XmlEnum("2")]
        OLI_POLSTAT_INACTIVE = 2,

        /// <summary>Paid-Up</summary>
        /// <remarks>The life insurance contract has reached the end of its contractually defined premium-paying period.  No further premiums are due, but the contract and its benefits are still in effect.  For example:  a 20-Pay Whole Life contract -- premiums are paid-up over a 20-year period and at the end of that period, the cash value continues to accumulate and the death benefit remains in effect until contract maturity or a claim is incurred.</remarks>
        [XmlEnum("3")]
        OLI_POLSTAT_PAIDUP = 3,

        /// <summary>Lapsed</summary>
        [XmlEnum("4")]
        OLI_POLSTAT_LAPSED = 4,

        /// <summary>Lapse Pending.</summary>
        [XmlEnum("5")]
        OLI_POLSTAT_LAPSEPEND = 5,

        /// <summary>Surrendered</summary>
        [XmlEnum("6")]
        OLI_POLSTAT_SURR = 6,

        /// <summary>Not Taken.</summary>
        [XmlEnum("7")]
        OLI_POLSTAT_NOTAKE = 7,

        /// <summary>Pending</summary>
        /// <remarks>Request accepted for processing and under review by carrier.</remarks>
        [XmlEnum("8")]
        OLI_POLSTAT_PENDING = 8,

        /// <summary>Waiver</summary>
        [XmlEnum("9")]
        OLI_POLSTAT_WAIVER = 9,

        /// <summary>Death Claim Pending.</summary>
        [XmlEnum("10")]
        OLI_POLSTAT_DTHPEND = 10,

        /// <summary>Death Claim Paid.</summary>
        [XmlEnum("11")]
        OLI_POLSTAT_DEATH = 11,

        /// <summary>Proposed</summary>
        /// <remarks>Not yet submitted to carrier for consideration.</remarks>
        [XmlEnum("12")]
        OLI_POLSTAT_PROPOSED = 12,

        /// <summary>Home Office Cancellation</summary>
        [XmlEnum("13")]
        OLI_POLSTAT_HOCANCEL = 13,

        /// <summary>Terminated</summary>
        [XmlEnum("14")]
        OLI_POLSTAT_TERMINATE = 14,

        /// <summary>Under Disability</summary>
        [XmlEnum("15")]
        OLI_POLSTAT_DI = 15,

        /// <summary>Cash Value Paid.</summary>
        [XmlEnum("16")]
        OLI_POLSTAT_CVPAID = 16,

        /// <summary>Expired</summary>
        [XmlEnum("17")]
        OLI_POLSTAT_EXPIRED = 17,

        /// <summary>Extended Term</summary>
        [XmlEnum("18")]
        OLI_POLSTAT_EXTTERM = 18,

        /// <summary>Reissue</summary>
        [XmlEnum("19")]
        OLI_POLSTAT_REISSUE = 19,

        /// <summary>Reduced Paid Up</summary>
        [XmlEnum("20")]
        OLI_POLSTAT_REDUCEDPAIDUP = 20,

        /// <summary>Applied For</summary>
        /// <remarks>From the perspective of the sender, the transmission of formal app is successful.  This is only used for a formal application. Broker/vendor has sent the policy to the carrier. It does not reflect a carrier status.</remarks>
        [XmlEnum("21")]
        OLI_POLSTAT_APPLIEDFOR = 21,

        /// <summary>Pending Transmission (application completed and ready to be sent but transmission has not taken place).</summary>
        [XmlEnum("22")]
        OLI_POLSTAT_PENDINGTRANS = 22,

        /// <summary>Incomplete (application was incomplete).</summary>
        [XmlEnum("23")]
        OLI_POLSTAT_INCOMPLETE = 23,

        /// <summary>Approved</summary>
        /// <remarks>Approved for issue (may or may not have outstanding requirements).</remarks>
        [XmlEnum("24")]
        OLI_POLSTAT_APPROVED = 24,

        /// <summary>Issued</summary>
        /// <remarks>Issued:All requirements were satisfiedCan be used with StatusReason to reflect it is not paid.Could also indicate all requirements satisfied but effective date not yet reached.</remarks>
        [XmlEnum("25")]
        OLI_POLSTAT_ISSUED = 25,

        /// <summary>Counter offer - made by HO</summary>
        /// <remarks>Issued other than applied for. Must include at least one material change(s), may additionally include nonmaterial change(s)</remarks>
        [XmlEnum("26")]
        OLI_POLSTAT_COUNTEROFFER = 26,

        /// <summary>Carrier declined to issue</summary>
        [XmlEnum("27")]
        OLI_POLSTAT_DECISSUE = 27,

        /// <summary>Carrier decline to reinstate</summary>
        [XmlEnum("28")]
        OLI_POLSTAT_DECREINSTATE = 28,

        /// <summary>Carrier deferred (e.g. carrier is deferring coverage until certain conditions are met).</summary>
        [XmlEnum("29")]
        OLI_POLSTAT_DEFERRED = 29,

        /// <summary>Conversion with a new number</summary>
        /// <remarks>Conversion implies that a previous policy exists. While considered old business, a conversion usually has a new effective date.  This status is intended for use on the new policy/system not the original.</remarks>
        [XmlEnum("30")]
        OLI_POLSTAT_CONVERTED = 30,

        /// <summary>Contractual change pending.</summary>
        [XmlEnum("31")]
        OLI_POLSTAT_CTRCTCHANGE = 31,

        /// <summary>Back Billed</summary>
        /// <remarks>Not paid up to where you've been billed to.</remarks>
        [XmlEnum("32")]
        OLI_POLSTAT_BACKBILL = 32,

        /// <summary>Illustration declined</summary>
        /// <remarks>Illustration System wants to return coverage to indicate it was declined.</remarks>
        [XmlEnum("33")]
        OLI_POLSTAT_ILLUSDEC = 33,

        /// <summary>Eligible, Issue Pending</summary>
        [XmlEnum("34")]
        OLI_POLSTAT_ELIGISSPEND = 34,

        /// <summary>Declined Not Eligible</summary>
        [XmlEnum("35")]
        OLI_POLSTAT_DECNOTELIG = 35,

        /// <summary>Annuitized</summary>
        [XmlEnum("36")]
        OLI_POLSTAT_ANNUITIZED = 36,

        /// <summary>Reinstated</summary>
        /// <remarks>Subtle short period between pending and active-  awaiting policy exhibit</remarks>
        [XmlEnum("37")]
        OLI_POLSTAT_REINSTATED = 37,

        /// <summary>Pending Reinstatement</summary>
        [XmlEnum("38")]
        OLI_POLSTAT_PENDREINST = 38,

        /// <summary>Canceled</summary>
        /// <remarks>Customer is withdrawing application</remarks>
        [XmlEnum("39")]
        OLI_POLSTAT_CANCELLED = 39,

        /// <summary>Matured</summary>
        [XmlEnum("40")]
        OLI_POLSTAT_MATURED = 40,

        /// <summary>Conversion Pending</summary>
        /// <remarks>This status is intended for use on the new policy/system not the original.</remarks>
        [XmlEnum("41")]
        OLI_POLSTAT_CONVPEND = 41,

        /// <summary>Grace Period</summary>
        /// <remarks>The policy has lapsed due to non payment of premiums and is in its contractual grace period prior to final termination</remarks>
        [XmlEnum("42")]
        OLI_POLSTAT_GRACEPD = 42,

        /// <summary>Policy was issued with changes</summary>
        /// <remarks>Policy was issued with non-material change(s).</remarks>
        [XmlEnum("43")]
        OLI_POLSTAT_CHANGEISS = 43,

        /// <summary>Issued with Requirements</summary>
        /// <remarks>Issued with outstanding requirements.</remarks>
        [XmlEnum("44")]
        OLI_POLSTAT_ISSUEDWREQUIREMENTS = 44,

        /// <summary>Invalid</summary>
        [XmlEnum("45")]
        OLI_POLSTAT_INVALID = 45,

        /// <summary>Pending Replacement</summary>
        [XmlEnum("46")]
        OLI_POLSTAT_PENDREPLACEMENT = 46,

        /// <summary>Fully Paid-Up</summary>
        /// <remarks>Fully Paid-Up insurance (FPU) is in effect following the election by the policy owner of the conversion option that allows the policy owner to stop paying premiums prior to the end of the normal premium-paying period, and receive a paid up policy for the full current face amount.  FPU is a combination of the reduced paid-up and premium reduction non-forfeiture options.Fully Paid Up -- Fully Paid-Up insurance (FPU) is a type of non-forfeiture option available on life insurance contracts (class code 1) where the policy owner may optionally elect to cease paying premiums prior to the end of the normal premium paying period as defined in the contract, and use the total cash value of the contract as a Net Single Premium to purchase a fully paid-up policy for the full face amount of the original contract.  The total cost for conversion to a fully paid-up contract is based on the net single premium for the full original face amount plus the cost to retain certain supplemental benefit riders.  The total cash value of the contract needs to be sufficient to cover the NSP cost -- Total CV includes the guaranteed cash value, the cash surrender value of any PUA's and OYT Additions and any dividends on deposit.  If the total cash value required to cover the NSP is less than the cost to convert to fully paid-up, the policy owner may pay the amount to cover the shortage of the NSP; if the total cash value exceeds the cost, any unneeded amount over the NSP will be refunded in cash.</remarks>
        [XmlEnum("47")]
        OLI_POLSTAT_FULLPAIDUP = 47,

        /// <summary>Active - Preliminary Term</summary>
        /// <remarks>Both the Preliminary Term coverage and the basic policy have been approved and the premium for the Preliminary Term period has been paid, but the basic policy effective date has not been reached (Preliminary Term period still is in effect) nor has billing occurred for the initial premium, which has not been paid..</remarks>
        [XmlEnum("48")]
        OLI_POLSTAT_PRETERM = 48,

        /// <summary>Free Look</summary>
        /// <remarks>Policy owner exercised the free look provision to terminate this policy. In the UK, this is the Cooling Off period.</remarks>
        [XmlEnum("50")]
        OLI_POLSTAT_FREELOOK = 50,

        /// <summary>Policy was not placed</summary>
        /// <remarks>Carrier did not place the policy.</remarks>
        [XmlEnum("51")]
        OLI_POLSTAT_NOTPLACED = 51,

        /// <summary>Coverage is "active" but one (or more) of insureds have died</summary>
        [XmlEnum("52")]
        OLI_POLSTAT_SOMEDEAD = 52,

        /// <summary>Conditional Approval</summary>
        [XmlEnum("53")]
        OLI_POLSTAT_APPROVCOND = 53,

        /// <summary>Submitted to Underwriting</summary>
        /// <remarks>The proposed policy is a completed application and is submitted to Underwriting. All initial information/requirements required to put the policy in Underwriting have been accepted.</remarks>
        [XmlEnum("54")]
        OLI_POLSTAT_SUBMITTEDTOUW = 54,

        /// <summary>Suspend</summary>
        /// <remarks>Suspend indicates whether financial activity is suspended on a Policy or not.  Some reasons for freezing a Policy could be because of the death of the insured, an internal processing problem, etc.</remarks>
        [XmlEnum("55")]
        OLI_POLSTAT_SUSPEND = 55,

        /// <summary>Re-entry pending</summary>
        /// <remarks>Policy owner has elected to re-qualify for a premium rate comparable to a new issue premium rate for someone of the same age.</remarks>
        [XmlEnum("56")]
        OLI_POLSTAT_REENTRYPENDING = 56,

        /// <summary>Quoted</summary>
        /// <remarks>A request for a rate quote or an informal application  (AKA trial application) was received by the carrier.  If the carrier was able to satisfy the request the status is  quoted.</remarks>
        [XmlEnum("57")]
        OLI_POLSTAT_QUOTED = 57,

        /// <summary>Approved Tentative Offer</summary>
        /// <remarks>Has been approved with tentative offer – as opposed to final offer. This is only used for a formal application.</remarks>
        [XmlEnum("58")]
        OLI_POLSTAT_APPROVEDTENTOFFER = 58,

        /// <summary>HO Withdrew</summary>
        /// <remarks>Status of coverage for an inquiry or formal application that the HO withdrew</remarks>
        [XmlEnum("59")]
        OLI_POLSTAT_WITHDRAWNHO = 59,

        /// <summary>Producer Withdrew</summary>
        /// <remarks>Status of coverage for an inquiry or formal application that the Producer (Agent) withdrew (changed mind, etc.)</remarks>
        [XmlEnum("60")]
        OLI_POLSTAT_WITHDRAWNFLD = 60,

        /// <summary>Lapsing on a daily cost basis</summary>
        [XmlEnum("61")]
        OLI_POLSTAT_LAPSINGDAILY = 61,

        /// <summary>Postponed</summary>
        /// <remarks>Used when a case needs to be re-opened from an issued status.  Deprecated in favor of Policy Status "OLI_POLSTAT_DEFERRED".</remarks>
        [XmlEnum("62")]
        OLI_POLSTAT_POSTPONED = 62,

        /// <summary>Block Conversion</summary>
        /// <remarks>Used when the issue system is used as a conversion vehicle for moving multiple policies from another administration system.  This status is intended for use on the new policy/system not the original.</remarks>
        [XmlEnum("63")]
        OLI_POLSTAT_CONVERTEDBLOCK = 63,

        /// <summary>Conversion with the same number</summary>
        /// <remarks>Conversion implies that a previous policy exists.  The inforce policy with the same number must be terminated and carry exit code conversion out.</remarks>
        [XmlEnum("64")]
        OLI_POLSTAT_CONVERTEDSAME = 64,

        /// <summary>Not Taken Out</summary>
        /// <remarks>The Not Taken Out status indicates that the contract was declined before issue.  The party declining the contract may be the contract owner or insurance company itself.</remarks>
        [XmlEnum("65")]
        OLI_POLSTAT_NOTTAKENOUT = 65,

        /// <summary>Terminated - Reserves Released</summary>
        [XmlEnum("89")]
        OLI_POLSTAT_TERMRESRELEASD = 89,

        /// <summary>Active Rider Terminated - Policy Converted to NFO (non forfeiture options)</summary>
        /// <remarks>Original rider coverage is modified to reflect new non-forfeiture paid-up conditions</remarks>
        [XmlEnum("90")]
        OLI_POLSTAT_RDRTERMNFO = 90,

        /// <summary>Paid-Up Rider Terminated - Policy Converted to NFO (non forfeiture options)</summary>
        /// <remarks>Original paid-up rider coverage is modified to reflect NFO Conditions</remarks>
        [XmlEnum("91")]
        OLI_POLSTAT_PDUPRDRTERMNFO = 91,

        /// <summary>Status of 'member left'</summary>
        /// <remarks>A member has left employment</remarks>
        [XmlEnum("92")]
        OLI_POLSTAT_MEMBERLEAVES = 92,

        /// <summary>Status of 'Departure Extension'</summary>
        /// <remarks>A member is on departure extension</remarks>
        [XmlEnum("93")]
        OLI_POLSTAT_DEPARTUREEXTENSION = 93,

        /// <summary>Inforce- Attained Age Conversion</summary>
        /// <remarks>Attained age of insured being reached resulted in a conversion, but policy remains inforce</remarks>
        [XmlEnum("94")]
        OLI_POLSTAT_INFAGECONF = 94,

        /// <summary>Disability claim pending without policy termination</summary>
        /// <remarks>A disability claim against the policy, which does not lead to the termination of the policy, is pendingThis is a disability claim on a Life coverage.</remarks>
        [XmlEnum("95")]
        OLI_POLSTAT_DISCLAIM = 95,

        /// <summary>Reconsider and Approve</summary>
        /// <remarks>Final action procedure done on a case which has gotten Further Information Unobtainable (FIU) rejected and subsequently received the Money and/or pre-issue forms within the 45 day grace period.</remarks>
        [XmlEnum("97")]
        OLI_POLSTATUS_RECONSIDER = 97,

        /// <summary>Further Information Unobtainable Rejection</summary>
        /// <remarks>A case may be FIU rejected for insufficient money or outstanding pre issue forms. A case pending in new business has a grace period of 45 days for money and the pre issue forms, if these details are unobtainable for any reason, the underwriter FIU rejects the case.</remarks>
        [XmlEnum("98")]
        OLI_POLSTATUS_FIUREJECT = 98,

        /// <summary>Exercised</summary>
        /// <remarks>A status which indicates that the associated Option or Rider has been exercised.</remarks>
        [XmlEnum("99")]
        OLI_POLSTAT_EXERCISED = 99,

        /// <summary>Claim pending without policy termination</summary>
        /// <remarks>A claim against the policy, which does not lead to the termination of the policy, is pending</remarks>
        [XmlEnum("100")]
        OLI_POLSTAT_PENDCLAIMNOTERM = 100,

        /// <summary>Approve - Issue Hold</summary>
        /// <remarks>To have the case status 'Case is approved but issue process is on hold'. Case will not be issued until this hold is removed</remarks>
        [XmlEnum("103")]
        OLI_POLSTAT_ISSUEHOLD = 103,

        /// <summary>Underwriting complete, policy paid</summary>
        /// <remarks>This accounts for the fact that some companies will not issue the policy until something has been paid towards it.</remarks>
        [XmlEnum("106")]
        OLI_POLSTAT_NOTPAID = 106,

        /// <summary>Underwriting incomplete; policy paid</summary>
        [XmlEnum("107")]
        OLI_POLSTAT_PAIDUNDINC = 107,

        /// <summary>Under Retrenchment (Unemployment)</summary>
        /// <remarks>Under Retrenchment (Unemployment) status indicates that the insured is receiving a retrenchment benefit from this policy.</remarks>
        [XmlEnum("108")]
        OLI_POLSTAT_RETRENCH = 108,

        /// <summary>Request Refused</summary>
        /// <remarks>The submission of a request for a quote, trial/informal or formal application cannot be processed</remarks>
        [XmlEnum("109")]
        OLI_POLSTAT_REQREFUSE = 109,

        /// <summary>Risk Not Acceptable</summary>
        /// <remarks>Has gone through an underwriting process for an informal application and determined that the risk was not acceptable to the carrier</remarks>
        [XmlEnum("110")]
        OLI_POLSTAT_RISKNOTACCEPT = 110,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
