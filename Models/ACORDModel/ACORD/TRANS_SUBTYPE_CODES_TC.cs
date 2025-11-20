using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum TRANS_SUBTYPE_CODES_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>All Transactions</summary>
        /// <remarks>This code is NOT a transaction but a value for the AdministrativeTransaction aggregate on PolicyProduct defining which messages a product supports. This code means you support them all.</remarks>
        [XmlEnum("1")]
        OLI_TRANSSUB_ALL = 1,

        /// <summary>Fund Allocation Change (investment or a policy)</summary>
        [XmlEnum("10100")]
        OLI_TRANSSUB_FA = 10100,

        /// <summary>Fund Transfer Only</summary>
        /// <remarks>This TXLife message contains instructions for a Fund Transfer only. No Arrangement Administration is being requested.</remarks>
        [XmlEnum("10200")]
        OLI_TRANSSUB_FUNDXFER = 10200,

        /// <summary>Fund Transfer and Arrangement Administration</summary>
        /// <remarks>This TXLife message contains instructions for both a Fund Transfer and Arrangement Administration.</remarks>
        [XmlEnum("10202")]
        OLI_TRANSSUB_XFERANDAA = 10202,

        /// <summary>New Business Submission for a Policy</summary>
        [XmlEnum("10300")]
        OLI_TRANSSUB_NBSUB = 10300,

        /// <summary>Withdrawal (one time/auto for policy/investment)</summary>
        /// <remarks>Withdrawal (one time or automatic for policy or investment)</remarks>
        [XmlEnum("10500")]
        OLI_TRANSSUB_WITHDR = 10500,

        /// <summary>New Business Policy Number Request</summary>
        [XmlEnum("10600")]
        OLI_TRANSSUB_NBPOLNUM = 10600,

        /// <summary>Arrangement Administration</summary>
        [XmlEnum("10700")]
        OLI_TRANSSUB_UPDARR = 10700,

        /// <summary>InvestProduct Change</summary>
        [XmlEnum("10800")]
        OLI_TRANSSUB_CHGINP = 10800,

        /// <summary>Set Document Delivery Instructions</summary>
        [XmlEnum("11000")]
        OLI_TRANSSUB_DELIVERY = 11000,

        /// <summary>Set doc delivery instructions for Party in general</summary>
        /// <remarks>This establishes document delivery instructions for a party in general and is considered the default document delivery instructions for that party.</remarks>
        [XmlEnum("11001")]
        OLI_SUBTRANS_DELIVERY_PARTY = 11001,

        /// <summary>Set document delivery instructions for a party based on their relation to a holding.</summary>
        /// <remarks>This establishes document delivery instructions for a party based on a relation to a holding and will override any rules established for a party in general.</remarks>
        [XmlEnum("11002")]
        OLI_SUBTRANS_DELIVERY_RELATION = 11002,

        /// <summary>Set document delivery instructions for a party based on their role as a participant on a holding.</summary>
        /// <remarks>This establishes document delivery instructions for a party based on their role as a participant on a holding and will override any rules established for a party in general.</remarks>
        [XmlEnum("11003")]
        OLI_SUBTRANS_DELIVERY_PARTICIPANT = 11003,

        /// <summary>Request Illustration Calculations</summary>
        [XmlEnum("11100")]
        OLI_TRANSSUB_ILLCAL = 11100,

        /// <summary>Submit Invoice</summary>
        [XmlEnum("11800")]
        OLI_TRANSSUB_SUBMITINVOICE = 11800,

        /// <summary>Submit Initial Invoice</summary>
        /// <remarks>Invoice being submitted is an initial invoice</remarks>
        [XmlEnum("11801")]
        OLI_TRANSSUB_INVINIT = 11801,

        /// <summary>Submit Rebill Invoice</summary>
        /// <remarks>Invoice being submitted is a rebill for previously denied charges</remarks>
        [XmlEnum("11802")]
        OLI_TRANSSUB_INVREB = 11802,

        /// <summary>Submit Duplicate Initial Invoice</summary>
        /// <remarks>Invoice being submitted is an exact duplicate of an initial invoice</remarks>
        [XmlEnum("11803")]
        OLI_TRANSSUB_INVDUPINIT = 11803,

        /// <summary>Submit Duplicate Rebill Invoice</summary>
        /// <remarks>Invoice being submitted is an exact duplicate of a rebill for previously denied charges</remarks>
        [XmlEnum("11804")]
        OLI_TRANSSUB_INVDUPREB = 11804,

        /// <summary>Cancel Invoice Submission</summary>
        /// <remarks>Cancel a previously submitted invoice</remarks>
        [XmlEnum("11805")]
        OLI_TRANSSUB_INVCAN = 11805,

        /// <summary>Invoice Status</summary>
        [XmlEnum("11900")]
        OLI_TRANSSUB_INVOICESTATUS = 11900,

        /// <summary>Initial Invoice Status</summary>
        /// <remarks>Status of an initial service provider invoice</remarks>
        [XmlEnum("11901")]
        OLI_TRANSSUB_INVSTAINIT = 11901,

        /// <summary>Rebill Invoice Status</summary>
        /// <remarks>Status of a rebill service provider invoice</remarks>
        [XmlEnum("11902")]
        OLI_TRANSSUB_INVSTAREB = 11902,

        /// <summary>Reject Invoice</summary>
        /// <remarks>Reject an entire invoice</remarks>
        [XmlEnum("11903")]
        OLI_TRANSSUB_INVREJECT = 11903,

        /// <summary>General Requirement Order Request</summary>
        [XmlEnum("12100")]
        OLI_TRANSSUB_GENREQ = 12100,

        /// <summary>Cancel General Requirement</summary>
        /// <remarks>Cancels requirement orders at the requirement level.</remarks>
        [XmlEnum("12101")]
        OLI_TRANSSUB_CANCREQ = 12101,

        /// <summary>General Requirement Results Request</summary>
        [XmlEnum("12200")]
        OLI_TRANSSUB_GENRES = 12200,

        /// <summary>Requirement Inquiry</summary>
        [XmlEnum("12300")]
        OLI_TRANSSUB_INQREQUIREMENT = 12300,

        /// <summary>Case Status Notification</summary>
        /// <remarks>A notification to the Agent or Agency of Record related to the most current status of a case in the New Business or Underwriting process.</remarks>
        [XmlEnum("12500")]
        OLI_TRANSSUB_PENDINGCASE = 12500,

        /// <summary>PreLapse Notification for Distributor and Producer</summary>
        /// <remarks>A notification to the Agent or Agency of Record that a particular In-Force policy has been moved to a Pending Lapse status.</remarks>
        [XmlEnum("12501")]
        OLI_TRANSSUB_PRELAPSENOTICE = 12501,

        /// <summary>Replacement Processing Request</summary>
        [XmlEnum("12700")]
        OLI_TRANSSUB_REPPRO = 12700,

        /// <summary>Replacement Notify</summary>
        /// <remarks>This TransSubType is used during Replacement Processing when the Replacing Carrier is notifying the Delivering Carrier that they have received an application to replace the existing contract.  It is not a request for the Delivering Carrier to surrender the existing contract and release the funds.</remarks>
        [XmlEnum("12701")]
        OLI_TRANSSUB_REPL_NOTIFY = 12701,

        /// <summary>Replacement Request for Surrender</summary>
        /// <remarks>This TransSubType is used during Replacement Processing when the Replacing Carrier is requesting the Delivering Carrier to surrender the existing contract and release the funds.</remarks>
        [XmlEnum("12702")]
        OLI_TRANSSUB_REPL_SURR = 12702,

        /// <summary>Replacement Cancellation</summary>
        /// <remarks>The Receiving Carrier is notifying the Delivery Carrier to cancel the replacement for which a TX#127 was previously sent. This can happen in the case of a life insurance replacement where the receiving carrier has decided not to underwrite the applied-for policy, or in any line of business where the client has decided to withdraw the application with the Receiving Carrier, in or the event of the Owner's death prior to the transfer of the replacement funds.</remarks>
        [XmlEnum("12703")]
        OLI_TRANSSUB_REPL_CNCL = 12703,

        /// <summary>Supplemental Information to Prior Request for Surrender</summary>
        /// <remarks>This TransSubType is used to send subsequent messages from the Receiving Carrier to the Delivering Carrier to provide any outstanding information. In the event where the Delivering Carrier has indicated, via TX #1128 that there are missing forms or other information, the Receiving Carrier should use TX #127 with this SubTransCode to provide the follow-up of missing information/attachments.</remarks>
        [XmlEnum("12704")]
        OLI_TRANSSUB_REPL_SURRSUPP = 12704,

        /// <summary>Replacement Purge Notification</summary>
        /// <remarks>This transaction sub type is used to indicate that a replacement request record is being purged.</remarks>
        [XmlEnum("12705")]
        OLI_TRANSSUB_REPLACEMENTPUR = 12705,

        /// <summary>License Request</summary>
        [XmlEnum("12900")]
        OLI_TRANSSUB_LICENSEREQ = 12900,

        /// <summary>Request Resident License</summary>
        /// <remarks>Request to add a resident license for this producer.</remarks>
        [XmlEnum("12901")]
        OLI_TRANSSUB_LICREQRES = 12901,

        /// <summary>Request Non-Resident License</summary>
        /// <remarks>Request to add non-resident license for this producer</remarks>
        [XmlEnum("12902")]
        OLI_TRANSSUB_LICREQNONRES = 12902,

        /// <summary>Add Resident License Line Of Authority</summary>
        /// <remarks>Request to add a Line Of Authority to an existing Resident License</remarks>
        [XmlEnum("12903")]
        OLI_TRANSSUB_RESLICLOA = 12903,

        /// <summary>Add Non-Resident License Line Of Authority</summary>
        /// <remarks>Request to add a Line Of Authority to a Non-Resident License</remarks>
        [XmlEnum("12904")]
        OLI_TRANSSUB_NONRESLOA = 12904,

        /// <summary>Group Enrollment</summary>
        [XmlEnum("13000")]
        OLI_TRANSSUB_EMPLOY = 13000,

        /// <summary>Settlement</summary>
        [XmlEnum("14000")]
        OLI_TRANSSUB_FINSET = 14000,

        /// <summary>Underwriting Action (Substandard Rating)</summary>
        [XmlEnum("15100")]
        OLI_TRANSSUB_UNDACT = 15100,

        /// <summary>Producer (Re)Assignment</summary>
        [XmlEnum("16100")]
        OLI_TRANSSUB_AGENTREASSGNMT = 16100,

        /// <summary>DistributionAgreement Update</summary>
        [XmlEnum("17000")]
        OLI_TRANSSUB_DISTAGRUPDATE = 17000,

        /// <summary>Address Change Request (Party, Grouping, Holding)</summary>
        [XmlEnum("18100")]
        OLI_TRANSSUB_CHGADR = 18100,

        /// <summary>Address Change</summary>
        [XmlEnum("18101")]
        OLI_TRANSSUB_CHGADDR = 18101,

        /// <summary>Producer Address Change</summary>
        /// <remarks>To be used when changing addresses for Producer Party objects.</remarks>
        [XmlEnum("18110")]
        OLI_TRANSSUB_CHGPRDADDR = 18110,

        /// <summary>Phone Change Request (for Party)</summary>
        [XmlEnum("18200")]
        OLI_TRANSSUB_CHGPHN = 18200,

        /// <summary>E-Mail Address Change Request (for Party)</summary>
        [XmlEnum("18300")]
        OLI_TRANSSUB_CHGEMA = 18300,

        /// <summary>Update Billing Information</summary>
        [XmlEnum("18400")]
        OLI_TRANSSUB_CHGBIL = 18400,

        /// <summary>Update loan billing information</summary>
        /// <remarks>Update billing information for loan repayment.</remarks>
        [XmlEnum("18401")]
        OLI_TRANSSUB_LOANBILLING = 18401,

        /// <summary>Update Financial Activity</summary>
        [XmlEnum("18500")]
        OLI_TRANSSUB_CHGFIN = 18500,

        /// <summary>Premium Payment</summary>
        [XmlEnum("18501")]
        OLI_TRANSSUB_PMTPREM = 18501,

        /// <summary>Loan Payment</summary>
        [XmlEnum("18502")]
        OLI_TRANSSUB_PMTLOAN = 18502,

        /// <summary>Loan Taken</summary>
        [XmlEnum("18503")]
        OLI_TRANSSUB_LOANTAKEN = 18503,

        /// <summary>Claim Payment</summary>
        [XmlEnum("18504")]
        OLI_TRANSSUB_PMTCLAIM = 18504,

        /// <summary>Withdrawal</summary>
        [XmlEnum("18505")]
        OLI_TRANSSUB_WTHDRL = 18505,

        /// <summary>Rollover Premium Payment</summary>
        [XmlEnum("18506")]
        OLI_TRANSSUB_PMTROLLOVER = 18506,

        /// <summary>Payment Reversal</summary>
        [XmlEnum("18507")]
        OLI_TRANSSUB_PMTREVERSE = 18507,

        /// <summary>Reverse all premium payments to issue</summary>
        [XmlEnum("18508")]
        OLI_TRANSSUB_PMTREVERSEALL = 18508,

        /// <summary>Reinstatement Payment</summary>
        [XmlEnum("18509")]
        OLI_TRANSSUB_PMTREINSTATE = 18509,

        /// <summary>Free look premium cancellation</summary>
        [XmlEnum("18510")]
        OLI_TRANSSUB_CANFREELOOK = 18510,

        /// <summary>Surrender Policy</summary>
        [XmlEnum("18511")]
        OLI_TRANSSUB_SURR = 18511,

        /// <summary>Death benefit quote for Death Claim</summary>
        /// <remarks>A new TransTypeSubType within the 185 transaction to indicate that it is being used for Death Claim processing.</remarks>
        [XmlEnum("18512")]
        OLI_TRANSSUB_DEATHCLAIM = 18512,

        /// <summary>Party Update</summary>
        [XmlEnum("18600")]
        OLI_TRANSSUB_CHGPAR = 18600,

        /// <summary>Change Name</summary>
        [XmlEnum("18601")]
        OLI_TRANSSUB_CHGNAME = 18601,

        /// <summary>Party Split</summary>
        /// <remarks>The Party Split sub-transaction of the Party Update transaction instructs the Receiver to perform a split of one Party into two new Parties that have already been identified by the Requestor as separate and distinct Parties.This TransSubType requires the requestor to send the original party to be split with a DataRep of Remove, and the 2 new parties to be created with a DataRep of Full.</remarks>
        [XmlEnum("18602")]
        OLI_TRANSSUB_PARTYSPLIT = 18602,

        /// <summary>Party Collapse</summary>
        /// <remarks>The Party Collapse sub-transaction of the Party Update transaction instructs the Receiver to perform a collapse of two Parties that have already been identified by the Requestor as a single entity, into one new Party .Three parties will be sent in the party collapse request: the two original parties with at least their entity recognition information and a DataRep of Remove, and the new "collapsed" party information to be created with a DataRep of Full.</remarks>
        [XmlEnum("18603")]
        OLI_TRANSSUB_PARTYCOLLAPSE = 18603,

        /// <summary>Producer Name Change</summary>
        /// <remarks>To be used when a name change is needed for Producer Party objects.</remarks>
        [XmlEnum("18604")]
        OLI_TRANSSUB_CHGPRDNAME = 18604,

        /// <summary>Producer Contact Information Change</summary>
        /// <remarks>To be used when a change to contact information is needed for Producer Party objects</remarks>
        [XmlEnum("18605")]
        OLI_TRANSSUB_CHGPRDCONTACT = 18605,

        /// <summary>Activity Aggregate Update</summary>
        [XmlEnum("18700")]
        OLI_TRANSSUB_CHGACT = 18700,

        /// <summary>Add or Update System Messages</summary>
        [XmlEnum("18800")]
        OLI_TRANSSUB_CHGMSG = 18800,

        /// <summary>Set Notifications for a Party in general</summary>
        /// <remarks>This establishes notifications for a party in general and is considered the default notification rules for that party.</remarks>
        [XmlEnum("18900")]
        OLI_TRANSSUB_NOTIFYPARTY = 18900,

        /// <summary>Party notifications for holding/relation role</summary>
        /// <remarks>This establishes notifications for a party based on a relation to a holding and will override any relations established for a party in general.Set Notifications for a party based on their relation to a holding.</remarks>
        [XmlEnum("18901")]
        OLI_TRANSSUB_NOTIFYRELATION = 18901,

        /// <summary>Party notifications for holding/participant role</summary>
        /// <remarks>This establishes notifications for a party based on their role as a participant on a holding and will override any relations established for a party in general.Set Notifications for a party based on their role as a participant on a holding.</remarks>
        [XmlEnum("18902")]
        OLI_TRANSSUB_NOTIFYPARTICIPANT = 18902,

        /// <summary>Bulk Data Transfer</summary>
        [XmlEnum("19100")]
        OLI_TRANSSUB_BLKTRN = 19100,

        /// <summary>Policy Product Inquiry</summary>
        [XmlEnum("20100")]
        OLI_TRANSSUB_INQPRP = 20100,

        /// <summary>Investment Product Inquiry</summary>
        [XmlEnum("20200")]
        OLI_TRANSSUB_INQINP = 20200,

        /// <summary>Holding Inquiry</summary>
        [XmlEnum("20300")]
        OLI_TRANSSUB_INQHLD = 20300,

        /// <summary>Party Inquiry</summary>
        [XmlEnum("20400")]
        OLI_TRANSSUB_INQPAR = 20400,

        /// <summary>Grouping Inquiry</summary>
        [XmlEnum("20500")]
        OLI_TRANSSUBT_INQGRP = 20500,

        /// <summary>Producer Full Commussion Statement</summary>
        /// <remarks>Returns full commission statement(s) that contains criteria.  Criteria used to select statement(s) are inclusive at the statement level.  Meaning that if any detail of an entire statement matches any of the criteria then that criteria item is considered fulfilled.  When all criteria items are contained within a statement, that full statement is returned.</remarks>
        [XmlEnum("20600")]
        OLI_TRANSSUB_COMMFULL = 20600,

        /// <summary>Producer Last Commission Statement</summary>
        /// <remarks>Returns statement of the Last Full Reporting Period.  Criteria includes Producer, and optionally Carrier</remarks>
        [XmlEnum("20601")]
        OLI_TRANSSUB_COMMLAST = 20601,

        /// <summary>Producer Activity Since Last Commission Statement</summary>
        /// <remarks>Returns commission Statement covering the reporting period since the last generated commission statement.</remarks>
        [XmlEnum("20602")]
        OLI_TRANSSUB_COMMACT = 20602,

        /// <summary>Billing Statement Inquiry</summary>
        [XmlEnum("20700")]
        OLI_TRANSSUB_INQBIL = 20700,

        /// <summary>Billing Information Inquiry</summary>
        [XmlEnum("20800")]
        OLI_TRANSSUB_INQBIH = 20800,

        /// <summary>Pvt Met Inquire about Banking Information</summary>
        [XmlEnum("20801")]
        OLI_TRANSSUB_INQBIL_BANK = 20801,

        /// <summary>Inquiry for loan billing</summary>
        /// <remarks>To allow the user to specify loan billing information.  This is especially useful for TSA Loans.</remarks>
        [XmlEnum("20802")]
        OLI_TRANSSUB_INQLOANBILLING = 20802,

        /// <summary>Standardize Address Request</summary>
        [XmlEnum("20900")]
        OLI_TRANSSUB_STNDADDR = 20900,

        /// <summary>Poll for Notification</summary>
        [XmlEnum("21000")]
        OLI_TRANSSUB_INQNOT = 21000,

        /// <summary>Licensing Inquiry</summary>
        [XmlEnum("21100")]
        OLI_TRANSSUB_INQLIC = 21100,

        /// <summary>Values Inquiry</summary>
        [XmlEnum("21200")]
        OLI_TRANSSUB_INQVAL = 21200,

        /// <summary>Death benefit quote for Values Inquiry</summary>
        [XmlEnum("21201")]
        OLI_TRANSSUB_QTEDEATH = 21201,

        /// <summary>Net Surrender value quote</summary>
        [XmlEnum("21202")]
        OLI_TRANSSUB_QTESURR = 21202,

        /// <summary>Maximum Loan Quote</summary>
        [XmlEnum("21203")]
        OLI_TRANSSUB_QTELOAN = 21203,

        /// <summary>Quote Non-Forfeiture Option Values</summary>
        [XmlEnum("21204")]
        OLI_TRANSSUB_QTENFO = 21204,

        /// <summary>Quote Premium Off Set</summary>
        /// <remarks>This is what use to be called "Vanish Premium".</remarks>
        [XmlEnum("21205")]
        OLI_TRANSSUB_QTEPREMOFFSET = 21205,

        /// <summary>Quote for Reinstating a policy</summary>
        /// <remarks>The returning system should return all values need to reinstate the policy.</remarks>
        [XmlEnum("21206")]
        OLI_TRANSSUB_QTEREINSTATEMENT = 21206,

        /// <summary>Subaccount ("Positions") Values</summary>
        /// <remarks>Transmit all of the SubAccount data under Investment, included latest unit values, number of shares, etc.</remarks>
        [XmlEnum("21207")]
        OLI_TRANSSUB_POSITIONS = 21207,

        /// <summary>Partial Withdrawal Quote</summary>
        /// <remarks>Used to request a quote or calculation  be performed to determine the taxes and penalties incurred for a specified partial withdrawal amount.</remarks>
        [XmlEnum("21208")]
        OLI_TRANSSUB_QTEPARWTHDRL = 21208,

        /// <summary>Financial Activity inquiry Transaction</summary>
        [XmlEnum("21300")]
        OLI_TRANSSUB_INQFIN = 21300,

        /// <summary>Request any System Message detail</summary>
        [XmlEnum("21400")]
        OLI_TRANSSUB_INQMSG = 21400,

        /// <summary>Arrangement Inquiry transaction</summary>
        [XmlEnum("21500")]
        OLI_TRANSSUB_INQARRANGEMENT = 21500,

        /// <summary>Requirements Inquiry</summary>
        [XmlEnum("21600")]
        OLI_TRANSSUB_INQREQ = 21600,

        /// <summary>Activity Inquiry</summary>
        [XmlEnum("21700")]
        OLI_TRANSSUB_INQACT = 21700,

        /// <summary>Tabular Data Request</summary>
        [XmlEnum("22100")]
        OLI_TRANSSUB_INQTBL = 22100,

        /// <summary>Accounting Statement Inquiry</summary>
        [XmlEnum("22500")]
        OLI_TRANSSUB_INQACCTNG = 22500,

        /// <summary>Check System Status</summary>
        [XmlEnum("22700")]
        OLI_TRANSSUB_SYSTEMSTATUS = 22700,

        /// <summary>Producer Details - All</summary>
        /// <remarks>Provide all known Producer information including Producer details</remarks>
        [XmlEnum("22800")]
        OLI_TRANSSUB_PRODDETALL = 22800,

        /// <summary>Appointment Only Inquiry</summary>
        /// <remarks>Provide only Producer Appointment Information</remarks>
        [XmlEnum("22801")]
        OLI_TRANSSUB_APPTONLYINQ = 22801,

        /// <summary>License Only Inquiry</summary>
        /// <remarks>Provide only License Information</remarks>
        [XmlEnum("22802")]
        OLI_TRANSSUB_LICONLYINQ = 22802,

        /// <summary>Registration Only Inquiry</summary>
        /// <remarks>Provide just Registration info</remarks>
        [XmlEnum("22803")]
        OLI_TRANSSUB_REGONLYINQ = 22803,

        /// <summary>Appointment and License Inquiry</summary>
        /// <remarks>Provide both Appointment and License Information</remarks>
        [XmlEnum("22804")]
        OLI_TRANSSUB_APPLICINQ = 22804,

        /// <summary>Appointment Termination Only Inquiry</summary>
        /// <remarks>Provide only Producer Appointment Termination Information</remarks>
        [XmlEnum("22805")]
        OLI_TRANSSUB_APPTTERMONLYINQ = 22805,

        /// <summary>What can the producer sell?</summary>
        /// <remarks>This will return a list of products which can be sold by the producer.</remarks>
        [XmlEnum("22808")]
        OLI_TRANSSUB_WHATCANTHEYSELL = 22808,

        /// <summary>Producer Details - Personal</summary>
        /// <remarks>Provide only Producer Personal Details (Name, Address, Phone, Email, URL's)</remarks>
        [XmlEnum("22809")]
        OLI_TRANSSUB_PRODDETPERS = 22809,

        /// <summary>Can Producer Sell</summary>
        /// <remarks>Can this Producer sell given the information provided. Response in ResultInfoCode</remarks>
        [XmlEnum("22810")]
        OLI_TRANSSUB_CANPRODSELL = 22810,

        /// <summary>Is Producer Appointed</summary>
        /// <remarks>Does this Producer have any active appointments with the Carrier Specified</remarks>
        [XmlEnum("22811")]
        OLI_TRANSSUB_ISPRODAPPTD = 22811,

        /// <summary>Is Producer Licensed</summary>
        /// <remarks>Does this Producer have an active license in the Jurisdiction provided</remarks>
        [XmlEnum("22812")]
        OLI_TRANSSUB_ISPRODLICD = 22812,

        /// <summary>Is Producer Registered</summary>
        /// <remarks>Does this Producer have an active Registration</remarks>
        [XmlEnum("22813")]
        OLI_TRANSSUB_ISPRODREGD = 22813,

        /// <summary>Producer Code Change</summary>
        /// <remarks>Transaction subtype indicator to notify the receiving Agent/Producer that the carrier has changed their ProducerCode (agent code).</remarks>
        [XmlEnum("22890")]
        OLI_TRANSSUB_PRODCODECHG = 22890,

        /// <summary>FormInstance Inquiry</summary>
        [XmlEnum("22900")]
        OLI_TRANSSUB_FORMINSTANCEINQ = 22900,

        /// <summary>Bank Routing Inquiry</summary>
        [XmlEnum("23000")]
        OLI_TRANSSUB_INQBANK = 23000,

        /// <summary>Holding Product Inquiry</summary>
        [XmlEnum("23300")]
        OLI_TRANSSUB_HOLDPRODINQ = 23300,

        /// <summary>DistributionAgreement Inquiry</summary>
        [XmlEnum("23400")]
        OLI_TRANSSUB_DISTAGRINQ = 23400,

        /// <summary>Holding Statement Inquiry</summary>
        [XmlEnum("23500")]
        OLI_TRANSSUB_HOLDINGSTMTINQ = 23500,

        /// <summary>General Code List Inquiry</summary>
        /// <remarks>Request an entire code list as it is defined and supported by the Responder</remarks>
        [XmlEnum("23700")]
        OLI_TRANSSUB_GENCODELISTINQ = 23700,

        /// <summary>Validate and Translate Code Definition</summary>
        /// <remarks>Request an individual code as it is defined by the Responder</remarks>
        [XmlEnum("23701")]
        OLI_TRANSSUB_VALCODEDEF = 23701,

        /// <summary>Party Search</summary>
        [XmlEnum("30100")]
        OLI_TRANSSUB_SRCPAR = 30100,

        /// <summary>Lead Party Search</summary>
        /// <remarks>This TransSubType narrows the Party Search target response set to include only those Parties that are Leads, and meet all of the specified criteria.</remarks>
        [XmlEnum("30101")]
        OLI_TRANSSUB_LEADSSEARCH = 30101,

        /// <summary>Holding Search</summary>
        [XmlEnum("30200")]
        OLI_TRANSSUB_SRCHLD = 30200,

        /// <summary>Investment Product Search</summary>
        [XmlEnum("30300")]
        OLI_TRANSSUB_SRCINP = 30300,

        /// <summary>Policy Product Search</summary>
        [XmlEnum("30400")]
        OLI_TRANSSUB_SRCPRP = 30400,

        /// <summary>Activity Search</summary>
        [XmlEnum("30500")]
        OLI_TRANSSUB_SRCACT = 30500,

        /// <summary>Grouping Search</summary>
        [XmlEnum("30600")]
        OLI_TRANSSUB_SRCGRP = 30600,

        /// <summary>FormInstance Search</summary>
        [XmlEnum("31000")]
        OLI_TRANSSUB_FORMINSTANCESEARCH = 31000,

        /// <summary>DistributionAgreement Search</summary>
        [XmlEnum("31100")]
        OLI_TRANSSUB_DISTAGRSEARCH = 31100,

        /// <summary>Tabular Data Search</summary>
        [XmlEnum("32100")]
        OLI_TRANSSUB_SRCTBL = 32100,

        /// <summary>MIB Inquiry</summary>
        [XmlEnum("40100")]
        OLI_TRANSSUB_MIBINQ = 40100,

        /// <summary>MIB Update</summary>
        [XmlEnum("40200")]
        OLI_TRANSSUB_MIBUPT = 40200,

        /// <summary>MIB Follow-up</summary>
        [XmlEnum("40300")]
        OLI_TRANSSUB_MIBFOL = 40300,

        /// <summary>MIB Follow-up Request</summary>
        [XmlEnum("40400")]
        OLI_TRANSSUB_MIBFOLREQ = 40400,

        /// <summary>Appointment Request</summary>
        [XmlEnum("41000")]
        OLI_TRANSSUB_UPDAPPREQ = 41000,

        /// <summary>New Appointment Request</summary>
        /// <remarks>This transaction sub type is used to indicate that an appointment request is for a new appointment. It corresponds to the "New Appointment" checkbox in the Form Purpose on ACORD Form 758 (Producer Appointment Data Sheet).</remarks>
        [XmlEnum("41001")]
        OLI_TRANSSUB_NEWAPPT = 41001,

        /// <summary>Change Existing Appointment (Renewal)</summary>
        /// <remarks>This transaction sub type is used to indicate that an appointment request is for a change to an existing appointment. It corresponds to the "Change" checkbox in the Form Purpose on ACORD Form 758 (Producer Appointment Data Sheet).</remarks>
        [XmlEnum("41002")]
        OLI_TRANSSUB_CHGAPPT = 41002,

        /// <summary>Appointment Renewal Request</summary>
        [XmlEnum("41100")]
        OLI_TRANSSUB_UPDAPPREN = 41100,

        /// <summary>Appointment Non Renewal Request</summary>
        [XmlEnum("41200")]
        OLI_TRANSSUB_UPDAPPNOTE = 41200,

        /// <summary>Appointment Terminate</summary>
        [XmlEnum("41300")]
        OLI_TRANSSUB_UPDAPTERM = 41300,

        /// <summary>Terminate a Line of Authority</summary>
        /// <remarks>This code is used to end a Producer's ability to sell certain kinds of products, such as Variable Life, Long Term Care, etc.</remarks>
        [XmlEnum("41301")]
        OLI_TRANSSUB_LINEOFAUTHTERM = 41301,

        /// <summary>Terminate a State Appointment</summary>
        /// <remarks>This code is used to end a Producer's ability to sell for an identified carrier in a specific state (jurisdiction).</remarks>
        [XmlEnum("41310")]
        OLI_TRANSSUB_APPTTERM = 41310,

        /// <summary>Terminate a Producer</summary>
        /// <remarks>This code is used to end all a Producer's appointments in all states, thereby terminating the Producer from performing legal sales.</remarks>
        [XmlEnum("41320")]
        OLI_TRANSSUB_PROTERM = 41320,

        /// <summary>FormInstance Request</summary>
        [XmlEnum("50000")]
        OLI_TRANSSUB_DOCPREP = 50000,

        /// <summary>PVT CSC Prepare Policy Document - The total policy. If you do not print the whole policy</summary>
        [XmlEnum("50001")]
        OLI_TRANSSUB_DOCPOLICY = 50001,

        /// <summary>Holding Change</summary>
        [XmlEnum("50200")]
        OLI_TRANSSUB_CHGHLD = 50200,

        /// <summary>Error Correction via "Rollback and Reissue"</summary>
        /// <remarks>The policy must be inforce.  Transactions are backed out and reapplied as needed.</remarks>
        [XmlEnum("50201")]
        OLI_TRANSSUB_CHGERR1 = 50201,

        /// <summary>Error Correction via "Patch and Go forward"</summary>
        /// <remarks>The policy must be inforce. No transactions are backed out and reapplied.</remarks>
        [XmlEnum("50202")]
        OLI_TRANSSUB_CHGERR2 = 50202,

        /// <summary>Change Going Forward</summary>
        /// <remarks>The change could be used for  inforce or new business.</remarks>
        [XmlEnum("50203")]
        OLI_TRANSSUB_CHGCONTRACT = 50203,

        /// <summary>Change Existing Holding</summary>
        /// <remarks>A transaction used to make changes to an existing holding, either pending or inforce</remarks>
        [XmlEnum("50204")]
        OLU_TRANSSUB_CHGHOLDING = 50204,

        /// <summary>Decline Risk</summary>
        [XmlEnum("50300")]
        OLI_TRANSSUB_DECRSK = 50300,

        /// <summary>Endorsement Update Request</summary>
        [XmlEnum("50400")]
        OLI_TRANSSUB_CHGEND = 50400,

        /// <summary>Holding Status Change</summary>
        [XmlEnum("50500")]
        OLI_TRANSSUB_CHGSTA = 50500,

        /// <summary>Change Attachment (Note) Request</summary>
        [XmlEnum("50600")]
        OLI_TRANSSUB_UPDATT = 50600,

        /// <summary>Payment Transaction</summary>
        [XmlEnum("50800")]
        OLI_TRANSSUB_PAYMNT = 50800,

        /// <summary>Reinsurance Policy Activity Information (PA)</summary>
        [XmlEnum("55101")]
        OLI_TRANSSUB_REINPA = 55101,

        /// <summary>Reinsurance Policy Status Information (PS)</summary>
        [XmlEnum("55102")]
        OLI_TRANSSUB_REINPS = 55102,

        /// <summary>Reinsurance Policy Activity and Status (PSA)</summary>
        [XmlEnum("55103")]
        OLI_TRANSSUB_REINPSA = 55103,

        /// <summary>Facultative Request for Capacity (Cedent to Reinsurer)</summary>
        [XmlEnum("55201")]
        OLI_SUBTRANS_FRC = 55201,

        /// <summary>Facultative Capacity Offer (Reinsurer to Cedent)</summary>
        [XmlEnum("55202")]
        OLI_SUBTRANS_FCO = 55202,

        /// <summary>Release of Facultative Capacity (Cedent to Reinsurer)</summary>
        [XmlEnum("55203")]
        OLI_SUBTRANS_FLC = 55203,

        /// <summary>Withdrawal of Facultative Capacity (Reinsurer to Cedent)</summary>
        [XmlEnum("55204")]
        OLI_SUBTRANS_FWC = 55204,

        /// <summary>New Facultative Request/Reopen Request (Cedent to Reinsurer)</summary>
        [XmlEnum("55205")]
        OLI_SUBTRANS_FRR = 55205,

        /// <summary>Facultative Offer (Reinsurer to Cedent)</summary>
        [XmlEnum("55206")]
        OLI_SUBTRANS_FOF = 55206,

        /// <summary>Decline of Facultative Request (Reinsurer to Cedent)</summary>
        [XmlEnum("55207")]
        OLI_SUBTRANS_FDO = 55207,

        /// <summary>Facultative Additional Information Request (Reinsurer to Cedent)</summary>
        [XmlEnum("55208")]
        OLI_SUBTRANS_FAI = 55208,

        /// <summary>Facultative Additional Information Response (Cedent to Reinsurer)</summary>
        [XmlEnum("55209")]
        OLI_SUBTRANS_FAR = 55209,

        /// <summary>Facultative Provisional Offer (Reinsurer to Cedent)</summary>
        [XmlEnum("55210")]
        OLI_SUBTRANS_FPO = 55210,

        /// <summary>Facultative Obligatory Request (Cedent to Reinsurer)</summary>
        [XmlEnum("55211")]
        OLI_SUBTRANS_FOR = 55211,

        /// <summary>Available Facultative Obligatory Capacity (Reinsurer to Cedent)</summary>
        [XmlEnum("55212")]
        OLI_SUBTRANS_FAO = 55212,

        /// <summary>Facultative Obligatory Additional Information Request (Reinsurer to Cedent)</summary>
        [XmlEnum("55213")]
        OLI_SUBTRANS_FOA = 55213,

        /// <summary>Facultative Obligatory Additional Information Response (Cedent to Reinsurer)</summary>
        [XmlEnum("55214")]
        OLI_SUBTRANS_FOI = 55214,

        /// <summary>Facultative Response to Offer (Cedent to Reinsurer)</summary>
        [XmlEnum("55215")]
        OLI_SUBTRANS_FRO = 55215,

        /// <summary>Facultative Offer Expired (Reinsurer to Cedent)</summary>
        [XmlEnum("55216")]
        OLI_SUBTRANS_FOE = 55216,

        /// <summary>Billing Data Extract</summary>
        [XmlEnum("180101")]
        OLI_TRANSSUB_BILLINGEXTRACT = 180101,

        /// <summary>Pvt Parties on a holding</summary>
        [XmlEnum("203006")]
        OLI_TRANSSUB_HLDPTY = 203006,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
