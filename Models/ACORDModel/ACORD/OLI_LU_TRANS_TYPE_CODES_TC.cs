using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_TRANS_TYPE_CODES_TC
    {
        /// <summary>Fund Allocation Change (investment or a policy)</summary>
        [XmlEnum("101")]
        OLI_TRANS_FA = 101,

        /// <summary>Fund Transfer (one time or automatic for  investment or policy)</summary>
        [XmlEnum("102")]
        OLI_TRANS_FT = 102,

        /// <summary>New Business Submission for a Policy</summary>
        [XmlEnum("103")]
        OLI_TRANS_NBSUB = 103,

        /// <summary>Paramed Report Order Request</summary>
        [XmlEnum("104")]
        OLI_TRANS_PARORD = 104,

        /// <summary>Withdrawal (one time or automatic for policy or investment)</summary>
        [XmlEnum("105")]
        OLI_TRANS_WITHDR = 105,

        /// <summary>New Business Policy Number Request</summary>
        /// <remarks>For systems that may not use a tracking ID to process a New Business application and that require a policy number be defined in the New Business application, this message can be used to acquire the policy number.</remarks>
        [XmlEnum("106")]
        OLI_TRANS_NBPOLNUM = 106,

        /// <summary>Arrangement Administration</summary>
        /// <remarks>The purpose of this transaction is to Setup/Update/Delete/Cease/Suspend/Restart an Arrangement (Automatic Scheduled Financial Activity).</remarks>
        [XmlEnum("107")]
        OLI_TRANS_UPDARR = 107,

        /// <summary>InvestProduct Change</summary>
        /// <remarks>Change an investment product</remarks>
        [XmlEnum("108")]
        OLI_TRANS_CHGINP = 108,

        /// <summary>PVT CSC New Business Changes</summary>
        [XmlEnum("109")]
        OLI_TRANS_XXXXXX = 109,

        /// <summary>Set document delivery instructions</summary>
        /// <remarks>This will set document delivery instructions for a party.  The associated TransSubType indicates whether it's for the party in general or based on their relationship to a holding.</remarks>
        [XmlEnum("110")]
        OLI_TRANS_DELIVERY = 110,

        /// <summary>Request Illustration Calculations</summary>
        [XmlEnum("111")]
        OLI_TRANS_ILLCAL = 111,

        /// <summary>Submit Invoice</summary>
        [XmlEnum("118")]
        OLI_TRANS_INVOICESUBMIT = 118,

        /// <summary>General Requirement Order Request</summary>
        [XmlEnum("121")]
        OLI_TRANS_GENREQ = 121,

        /// <summary>General Requirement Results Request</summary>
        [XmlEnum("122")]
        OLI_TRANS_GENRES = 122,

        /// <summary>Requirement Inquiry</summary>
        [XmlEnum("123")]
        OLI_TRANS_INQREQUIREMENT = 123,

        /// <summary>Paramed Requirements Results Request</summary>
        [XmlEnum("124")]
        OLI_TRANS_PARNOT = 124,

        /// <summary>Case Status Notification Request</summary>
        [XmlEnum("125")]
        OLI_TRANS_STANOT = 125,

        /// <summary>Replacement Notification Request</summary>
        [XmlEnum("126")]
        OLI_TRANS_REPNOT = 126,

        /// <summary>Replacement Processing Request</summary>
        [XmlEnum("127")]
        OLI_TRANS_REPPRO = 127,

        /// <summary>PVT_WG Replacement Processing Inquiry</summary>
        /// <remarks>This transaction does not appear in the TXLife Specification Guide and therefore is an undocumented part of the standard. Consistent implementation of this transaction is unlikely without TXLife documentation. It is expected that the original submitter (WG or member) will be adding TXLife documentation in a forthcoming MR.Last update: 2003/12/16 Last update version: 2.09.00 Last update MR: 03-1.01.RP01</remarks>
        [XmlEnum("128")]
        OLI_TRANS_INQREPLACE = 128,

        /// <summary>License Request</summary>
        [XmlEnum("129")]
        OLI_TRANS_LICENSEREQ = 129,

        /// <summary>Group Enrollment</summary>
        [XmlEnum("130")]
        OLI_TRANS_EMPLOY = 130,

        /// <summary>Settlement</summary>
        /// <remarks>Provide for financial settlements between trading partners</remarks>
        [XmlEnum("140")]
        OLI_TRANS_FINSET = 140,

        /// <summary>Underwriting Action (Substandard Rating)</summary>
        [XmlEnum("151")]
        OLI_TRANS_UNDACT = 151,

        /// <summary>Producer (Re)Assignment</summary>
        /// <remarks>This transaction will support the assignment or reassignment of an agent or servicing representative (Producer) to a particular holding.</remarks>
        [XmlEnum("161")]
        OLI_TRANS_AGENTREASSGNMT = 161,

        /// <summary>DistributionAgreement Update</summary>
        /// <remarks>This transaction allows the sender to request an update of information relating to a specific DistributionAgreement in the receiver's system.</remarks>
        [XmlEnum("170")]
        OLI_TRANS_DISTAGRUPDATE = 170,

        /// <summary>Address Change Request (Party, Grouping, Holding)</summary>
        [XmlEnum("181")]
        OLI_TRANS_CHGADR = 181,

        /// <summary>Phone Change Request (for Party)</summary>
        [XmlEnum("182")]
        OLI_TRANS_CHGPHN = 182,

        /// <summary>E-Mail Address Change Request (for Party)</summary>
        [XmlEnum("183")]
        OLI_TRANS_CHGEMA = 183,

        /// <summary>Update Billing Information</summary>
        [XmlEnum("184")]
        OLI_TRANS_CHGBIL = 184,

        /// <summary>Update Financial Activity</summary>
        [XmlEnum("185")]
        OLI_TRANS_CHGFIN = 185,

        /// <summary>Party Update</summary>
        [XmlEnum("186")]
        OLI_TRANS_CHGPAR = 186,

        /// <summary>Activity Aggregate Update</summary>
        [XmlEnum("187")]
        OLI_TRANS_CHGACT = 187,

        /// <summary>Add or Update System Messages</summary>
        [XmlEnum("188")]
        OLI_TRANS_CHGMSG = 188,

        /// <summary>Set Notifications</summary>
        /// <remarks>This will set notifications for a party.  The associated TransSubType indicates whether it's for the party in general or based on their relationship to a holding.</remarks>
        [XmlEnum("189")]
        OLI_TRANS_NOTIFICATION = 189,

        /// <summary>Bulk Data Transfer</summary>
        [XmlEnum("191")]
        OLI_TRANS_BLKTRN = 191,

        /// <summary>Policy Product Inquiry</summary>
        /// <remarks>Used to request an inquiry for specific detailed product information for a policy product.</remarks>
        [XmlEnum("201")]
        OLI_TRANS_INQPRP = 201,

        /// <summary>Investment Product Inquiry</summary>
        /// <remarks>Used to request detailed product information for an investment product.</remarks>
        [XmlEnum("202")]
        OLI_TRANS_INQINP = 202,

        /// <summary>Holding Inquiry</summary>
        [XmlEnum("203")]
        OLI_TRANS_INQHLD = 203,

        /// <summary>Party Inquiry</summary>
        [XmlEnum("204")]
        OLI_TRANS_INQPAR = 204,

        /// <summary>Grouping Inquiry</summary>
        /// <remarks>Used to inquire and receive detailed Grouping information.</remarks>
        [XmlEnum("205")]
        OLI_TRANST_INQGRP = 205,

        /// <summary>Commission Statement Inquiry</summary>
        [XmlEnum("206")]
        OLI_TRANS_INQCOM = 206,

        /// <summary>Billing Statement Inquiry</summary>
        [XmlEnum("207")]
        OLI_TRANS_INQBIL = 207,

        /// <summary>Billing Information Inquiry</summary>
        [XmlEnum("208")]
        OLI_TRANS_INQBIH = 208,

        /// <summary>Standardize Address Request</summary>
        /// <remarks>This message is used to standardize an address based on the rules of the message recipient.</remarks>
        [XmlEnum("209")]
        OLI_TRANS_STNDADDR = 209,

        /// <summary>Poll for Notification</summary>
        [XmlEnum("210")]
        OLI_TRANS_INQNOT = 210,

        /// <summary>Licensing Inquiry</summary>
        [XmlEnum("211")]
        OLI_TRANS_INQLIC = 211,

        /// <summary>Values Inquiry</summary>
        /// <remarks>When used in conjunction with TransSubTypeCode 21207 (OLI_TRANSSUB_POSITIONS), it can be used to implement a "positions inquiry" message.</remarks>
        [XmlEnum("212")]
        OLI_TRANS_INQVAL = 212,

        /// <summary>Financial Activity inquiry Transaction</summary>
        [XmlEnum("213")]
        OLI_TRANS_INQFIN = 213,

        /// <summary>Request any System Message detail</summary>
        [XmlEnum("214")]
        OLI_TRANS_INQMSG = 214,

        /// <summary>Arrangement Inquiry transaction</summary>
        [XmlEnum("215")]
        OLI_TRANS_INQARRANGEMENT = 215,

        /// <summary>Requirements Inquiry</summary>
        [XmlEnum("216")]
        OLI_TRANS_INQREQ = 216,

        /// <summary>Activity Inquiry</summary>
        [XmlEnum("217")]
        OLI_TRANS_INQACT = 217,

        /// <summary>PVT 05</summary>
        [XmlEnum("218")]
        OLI_TRANS_INQPVT05 = 218,

        /// <summary>PVT INFORCE WG Search for Available Reports</summary>
        [XmlEnum("219")]
        OLI_TRANS_INQDOC = 219,

        /// <summary>Tabular Data Request</summary>
        [XmlEnum("221")]
        OLI_TRANS_INQTBL = 221,

        /// <summary>PVT Inforce WG Inquiry for Archived Document</summary>
        [XmlEnum("222")]
        OLI_TRANS_INQARCDOC = 222,

        /// <summary>PVT_WG Appointment Inquiry (Status)</summary>
        /// <remarks>This transaction does not appear in the TXLife Specification Guide and therefore is an undocumented part of the standard. Consistent implementation of this transaction is unlikely without TXLife documentation. It is expected that the original submitter (WG or member) will be adding TXLife documentation in a forthcoming MR.Last update: 2003-06-03 Last update version: 2.7.92 Last update MR: 02-2.01.LA1</remarks>
        [XmlEnum("223")]
        OLI_TRANS_INQAPP = 223,

        /// <summary>Accounting Statement Inquiry</summary>
        [XmlEnum("225")]
        OLI_TRANS_INQACCTNG = 225,

        /// <summary>PVT_CSC Financial Statement Request</summary>
        /// <remarks>This transaction does not appear in the TXLife Specification Guide and therefore is an undocumented part of the standard. Consistent implementation of this transaction is unlikely without TXLife documentation. It is expected that the original submitter (WG or member) will be adding TXLife documentation in a forthcoming MR.Last update: 2003/12/16 Last update version: 2.09.00 Last update MR: 03-1.05.07</remarks>
        [XmlEnum("226")]
        OLI_TRANS_FINSTMTREQ = 226,

        /// <summary>Check System Status</summary>
        /// <remarks>Use this transaction to check for operation of the transaction processor in a B2B environment.</remarks>
        [XmlEnum("227")]
        OLI_TRANS_SYSTEMSTATUS = 227,

        /// <summary>Producer Inquiry</summary>
        [XmlEnum("228")]
        OLI_TRANS_PRODINQ = 228,

        /// <summary>FormInstance Inquiry</summary>
        /// <remarks>Used to retrieve detailed FormInstance information.</remarks>
        [XmlEnum("229")]
        OLI_TRANS_FORMINSTANCEINQ = 229,

        /// <summary>Bank Routing Inquiry</summary>
        [XmlEnum("230")]
        OLI_TRANS_INQBANK = 230,

        /// <summary>Holding Product Inquiry</summary>
        /// <remarks>Holding Product Inquiry supports the retrieval of detailed Product Information such as that returned in a PolicyProduct Inquiry or an InvestProduct Inquiry, but identifies the information by it's relationship to a particular Holding. This Transaction differs from the existing Product Inquiry transactions in that it allows the request to contain Holding information, and it will use that information to identify and return the detailed Product information.</remarks>
        [XmlEnum("233")]
        OLI_TRANS_HOLDPRODINQ = 233,

        /// <summary>DistributionAgreement Inquiry</summary>
        /// <remarks>This transaction allows the sender to request that information relating to a specific DistributionAgreement be returned.</remarks>
        [XmlEnum("234")]
        OLI_TRANS_DISTAGRINQ = 234,

        /// <summary>Holding Statement Inquiry</summary>
        [XmlEnum("235")]
        OLI_TRANS_HOLDINGSTMTINQ = 235,

        /// <summary>Code List Inquiry</summary>
        [XmlEnum("237")]
        OLI_TRANS_CODELISTINQ = 237,

        /// <summary>Party Search</summary>
        [XmlEnum("301")]
        OLI_TRANS_SRCPAR = 301,

        /// <summary>Holding Search</summary>
        [XmlEnum("302")]
        OLI_TRANS_SRCHLD = 302,

        /// <summary>Investment Product Search</summary>
        [XmlEnum("303")]
        OLI_TRANS_SRCINP = 303,

        /// <summary>Policy Product Search</summary>
        [XmlEnum("304")]
        OLI_TRANS_SRCPRP = 304,

        /// <summary>Activity Search</summary>
        [XmlEnum("305")]
        OLI_TRANS_SRCACT = 305,

        /// <summary>Grouping Search</summary>
        [XmlEnum("306")]
        OLI_TRANS_SRCGRP = 306,

        /// <summary>PVT Inforce Search of Archived Document</summary>
        [XmlEnum("309")]
        OLI_TRANS_SRCARCDOC = 309,

        /// <summary>FormInstance Search</summary>
        /// <remarks>Allow for search of objects and elements related to the FormInstance object.</remarks>
        [XmlEnum("310")]
        OLI_TRANS_FORMINSTANCESEARCH = 310,

        /// <summary>DistributionAgreement Search</summary>
        /// <remarks>This transaction allows the sender to request that information relating to a list of DistributionAgreements be returned based upon the criteria specified.</remarks>
        [XmlEnum("311")]
        OLI_TRANS_DISTAGRSEARCH = 311,

        /// <summary>Tabular Data Search</summary>
        [XmlEnum("321")]
        OLI_TRANS_SRCTBL = 321,

        /// <summary>MIB Inquiry</summary>
        [XmlEnum("401")]
        OLI_TRANS_MIBINQ = 401,

        /// <summary>MIB Update</summary>
        [XmlEnum("402")]
        OLI_TRANS_MIBUPT = 402,

        /// <summary>MIB Follow-up</summary>
        [XmlEnum("403")]
        OLI_TRANS_MIBFOL = 403,

        /// <summary>MIB Follow-up Request</summary>
        /// <remarks>Used to request any Follow-up data that MIB has for that company.This is not used to request Follow-up information on a specific person.  It requests whatever Follow-up data MIB has on any person of interest to the requesting company</remarks>
        [XmlEnum("404")]
        OLI_TRANS_MIBFOLREQ = 404,

        /// <summary>Appointment Request</summary>
        /// <remarks>A producer's appointment request. See Licensing and Appointment Implementation Guide for additional information.</remarks>
        [XmlEnum("410")]
        OLI_TRANS_UPDAPPREQ = 410,

        /// <summary>Appointment Renewal Request</summary>
        /// <remarks>A producer's request for renewal of an appointment. See Licensing and Appointment Implementation Guide for additional information.</remarks>
        [XmlEnum("411")]
        OLI_TRANS_UPDAPPREN = 411,

        /// <summary>Appointment Non Renewal Request</summary>
        /// <remarks>A report from a carrier or distributor identifying producers for whom they are not renewing appointments See Licensing and Appointment Implementation Guide for additional information.</remarks>
        [XmlEnum("412")]
        OLI_TRANS_UPDAPPNOTE = 412,

        /// <summary>Appointment Terminate</summary>
        /// <remarks>A producer's request to have their appointment terminated. See Licensing and Appointment Implementation Guide for additional information.</remarks>
        [XmlEnum("413")]
        OLI_TRANS_UPDAPTERM = 413,

        /// <summary>FormInstance Request</summary>
        /// <remarks>To request copies of a physical document (not just the FormInstance information)</remarks>
        [XmlEnum("500")]
        OLI_TRANS_DOCPREP = 500,

        /// <summary>Pvt CSC</summary>
        [XmlEnum("501")]
        OLI_TRANS_CHGMSC = 501,

        /// <summary>Holding Change</summary>
        [XmlEnum("502")]
        OLI_TRANS_CHGHLD = 502,

        /// <summary>Decline Risk</summary>
        [XmlEnum("503")]
        OLI_TRANS_DECRSK = 503,

        /// <summary>Endorsement Update Request</summary>
        [XmlEnum("504")]
        OLI_TRANS_CHGEND = 504,

        /// <summary>Holding Status Change</summary>
        [XmlEnum("505")]
        OLI_TRANS_CHGSTA = 505,

        /// <summary>Change Attachment (Note) Request</summary>
        [XmlEnum("506")]
        OLI_TRANS_UPDATT = 506,

        /// <summary>Pvt CSC</summary>
        [XmlEnum("507")]
        OLI_TRANS_CSC507 = 507,

        /// <summary>Payment Transaction</summary>
        [XmlEnum("508")]
        OLI_TRANS_PAYMNT = 508,

        /// <summary>Loan Processing</summary>
        [XmlEnum("509")]
        OLI_TRANS_LOANPROC = 509,

        /// <summary>FormInstance Update</summary>
        /// <remarks>Allow for the updating, addition, or deletion of objects and elements within the FormInstance object.</remarks>
        [XmlEnum("510")]
        OLI_TRANS_UPDFORMINSTANCE = 510,

        /// <summary>Life Reinsurance Activity Reporting Transaction (LREACT)</summary>
        [XmlEnum("551")]
        OLI_TRANS_LREACT = 551,

        /// <summary>Life Reinsurance Facultative Transaction</summary>
        [XmlEnum("552")]
        OLI_TRANS_LREFAC = 552,

        /// <summary>PVT_WG Pre-arranged Non-Financial Transactions</summary>
        /// <remarks>This transaction does not appear in the TXLife Specification Guide and therefore is an undocumented part of the standard. Consistent implementation of this transaction is unlikely without TXLife documentation. It is expected that the original submitter (WG or member) will be adding TXLife documentation in a forthcoming MR.Last update: 2003/12/16 Last update version: 2.09.00 Last update MR: 03-1.01.AN10</remarks>
        [XmlEnum("561")]
        OLI_TRANS_PREARRNONFIN = 561,

        /// <summary>Pharmaceutical Profile Request</summary>
        [XmlEnum("601")]
        OLI_TRANS_PHARMP = 601,

        /// <summary>Commission Calculation Extract</summary>
        [XmlEnum("701")]
        OLI_TRANS_COMMCALC = 701,

        /// <summary>First Notice of Loss</summary>
        /// <remarks>This message provides the Receiver with a notification that the Requestor has been contacted regarding an event that has occurred relating to an insured entity, which may result in a Claim being filed under one or more Holdings.  It does not create the Claim, but merely functions as the notification of the possibility of a Claim.  Actions that result from the receipt of this notification are expected to vary by product and carrier.</remarks>
        [XmlEnum("810")]
        OLI_TRANS_FIRSTNOTICE = 810,

        /// <summary>Discrepancy Transmittal</summary>
        /// <remarks>This transmittal is used to relay data discrepancies. It is not intended to systematically change the affected data, only to notify interested parties that differences have been detected and may need to be resolved.</remarks>
        [XmlEnum("1112")]
        OLI_TRANS_DISCREPANCY = 1112,

        /// <summary>Invoice Status Transmittal</summary>
        [XmlEnum("1119")]
        OLI_TRANS_TRNINVOICESTATUS = 1119,

        /// <summary>General Requirements Result Transmittal</summary>
        [XmlEnum("1122")]
        OLI_TRANS_TRNREQRUESULT = 1122,

        /// <summary>Requirements Transmittal</summary>
        [XmlEnum("1123")]
        OLI_TRANS_TRNREQ = 1123,

        /// <summary>Paramed Requirements Results Transmittal</summary>
        [XmlEnum("1124")]
        OLI_TRANS_TRNPARAMED = 1124,

        /// <summary>Case Status Notification Transmittal</summary>
        [XmlEnum("1125")]
        OLI_TRANS_TRNCAS = 1125,

        /// <summary>Transmittal for Replacement Update</summary>
        /// <remarks>This would be sent by the Delivering Carrier to the Receiving Carrier anytime the status on a Replacement is updated</remarks>
        [XmlEnum("1128")]
        OLI_TRANS_TRNREPLACE = 1128,

        /// <summary>Policy Product Transmittal</summary>
        /// <remarks>This transaction pushes the policy product information out. Used to transmit policy product information. This is not in response to an inquiry but rather a distribution of information so that receiver can update stored policy product information.</remarks>
        [XmlEnum("1201")]
        OLI_TRANS_TRNPOLPRD = 1201,

        /// <summary>Investment Product Transmittal</summary>
        /// <remarks>This transaction pushes the invest product information out. Used to transmit invest product information. This is not in response to an inquiry but rather a distribution of information so that receiver can update stored invest product information.</remarks>
        [XmlEnum("1202")]
        OLI_TRANS_TRNINVPRD = 1202,

        /// <summary>Holding Inquiry Transmittal</summary>
        [XmlEnum("1203")]
        OLI_TRANS_TRNHLD = 1203,

        /// <summary>Party Inquiry Transmittal</summary>
        [XmlEnum("1204")]
        OLI_TRANS_TRNPARTY = 1204,

        /// <summary>Grouping Transmittal</summary>
        /// <remarks>Used to transmit detailed Grouping information.</remarks>
        [XmlEnum("1205")]
        OLI_TRANST_TRNGRP = 1205,

        /// <summary>Commission Statement Transmittal</summary>
        [XmlEnum("1206")]
        OLI_TRANS_TRNCOM = 1206,

        /// <summary>Values Transmittal</summary>
        /// <remarks>Push version of the values inquiry (tx# 212) message</remarks>
        [XmlEnum("1212")]
        OLI_TRANS_TRNVAL = 1212,

        /// <summary>Financial Activity Transmittal</summary>
        /// <remarks>Transmittal version of the TXLife financial activity inquiry (TX # 213)</remarks>
        [XmlEnum("1213")]
        OLI_TRANS_TRNFIN = 1213,

        /// <summary>Activity Transmittal</summary>
        /// <remarks>The business needs to be able the push activities to one or more “Parties”, this is to cover the typical activity which is assigning a task to a producer. The need to “push” an Activity to one or more “Parties”.   For purposes of this message the Activity can be one of the following flavors:1. Basic Activity, which is normally sent to a servicing agent, in this Activity the agent, would be expected to perform an action based on the Activity Type included within the Activity object. This will usually be related to a Holding.2. Correspondence Activity to one or more recipients (Activity Type Correspondence). This may be related to a Holding, Product, Campaign or any other object.3. Compound Activity, which would be made up of a Correspondence Activity with a second, Activity linked to the first using a Relation Role Code “Task”. The Correspondence Activity Type can be sent to any number of recipients. The Task would be sent to the Party assigned to perform the task (normally the agent).4. Any Activity Transmittal needs one or more “Parties”.</remarks>
        [XmlEnum("1217")]
        OLI_TRANS_TRNACTIVITY = 1217,

        /// <summary>Tabular Data Transmittal</summary>
        /// <remarks>Used to transmit (download) tabular data.</remarks>
        [XmlEnum("1221")]
        OLI_TRANS_TRNTBL = 1221,

        /// <summary>PVT_WG Appointment Status Transmittal</summary>
        /// <remarks>This transaction does not appear in the TXLife Specification Guide and therefore is an undocumented part of the standard. Consistent implementation of this transaction is unlikely without TXLife documentation. It is expected that the original submitter (WG or member) will be adding TXLife documentation in a forthcoming MR.Last update: 2003-06-03 Last update version: 2.7.92 Last update MR: 02-2.01.LA1</remarks>
        [XmlEnum("1223")]
        OLI_TRANS_TRNAPP = 1223,

        /// <summary>Accounting Statement Transmittal</summary>
        [XmlEnum("1225")]
        OLI_TRANS_TRNACCTNG = 1225,

        /// <summary>Producer Transmittal</summary>
        /// <remarks>Provides a method of transmitting a variety of Producer inquiry messages.</remarks>
        [XmlEnum("1228")]
        OLI_TRANS_TRNPRODINQ = 1228,

        /// <summary>Distribution Agreement Transmittal</summary>
        /// <remarks>This transaction allows the sender to distribute the information relating to a specific distribution agreement.</remarks>
        [XmlEnum("1234")]
        OLI_TRANS_TRNDISTAGR = 1234,

        /// <summary>Holding Statement Transmittal</summary>
        [XmlEnum("1235")]
        OLI_TRANS_HOLDINGSTMTTRNS = 1235,

        /// <summary>Pharmaceutical Information Transmittal</summary>
        /// <remarks>Used to transmit pharmaceutical information.</remarks>
        [XmlEnum("1601")]
        OLI_TRANS_TRNPHARM = 1601,

        /// <summary>Billing Extract Transmittal</summary>
        /// <remarks>To interface between a billing engine and billing processing system.</remarks>
        [XmlEnum("1801")]
        OLI_TRANS_BILLTRNSMTL = 1801,

        /// <summary>Any company wishing to obtain specific transaction codes for company specific transactions should contact ACORD directly to have those assigned. This will avoid collisions in a connected environment.</summary>
        /// <remarks>This transaction does not appear in the TXLife Specification Guide and therefore is an undocumented part of the standard. Consistent implementation of this transaction is unlikely without TXLife documentation. It is expected that the original submitter (WG or member) will be adding TXLife documentation in a forthcoming MR.Last update: 2002-08-15 Last update version: 2.2 Last update MR: 02-1304</remarks>
        [XmlEnum("9000")]
        OLI_TRANS_RES = 9000,

        /// <summary>Any Authorized or Supported Transaction</summary>
        /// <remarks>Used to indicate when any transaction may be used. In Authorization/AdministrativeTransaction used to indicate all supported transaction may be used.  This value is allowed ONLY for AdministrativeTransaction.</remarks>
        [XmlEnum("9999")]
        OLI_TRANS_ANY = 9999,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
