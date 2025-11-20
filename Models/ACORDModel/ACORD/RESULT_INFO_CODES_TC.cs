using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum RESULT_INFO_CODES_TC
    {
        /// <summary>General Error</summary>
        [XmlEnum("1")]
        RESULTINFO_TBD = 1,

        /// <summary>General Error</summary>
        [XmlEnum("100")]
        RESULTINFO_GENERAL = 100,

        /// <summary>Status Information</summary>
        /// <remarks>Use this result info code description to return status information about the receiving system</remarks>
        [XmlEnum("101")]
        RESULTINFO_STATUS_INFO = 101,

        /// <summary>Document format is not valid</summary>
        [XmlEnum("102")]
        RESULTINFO_INVALIDDOCFORMAT = 102,

        /// <summary>The type code used does not pass MIME TYPE checks</summary>
        /// <remarks>An intemediary receiver of this transaction may have specific type code usage requirments and if the type code used does not meet those requirements the transaction will fail with an Invalid Mime Type. For example, in FormInstance, the intermediary may restict use to type code '11' or '17'. If a type code is passed that is not one of the two expected values the transaction will fail validation.</remarks>
        [XmlEnum("103")]
        RESULTINFO_INVALIDMIMETYPE = 103,

        /// <summary>The type code does not pass ATTACHMENT TYPE checks</summary>
        /// <remarks>An intemediary receiver of this transaction may have specific type code usage requirments and if the type code used does not meet those requirements the transaction will fail with an Invalid Attachment Type. For example, in Attachment, the intermediary may restict use to a subset of type codes. If a type code is passed that is not one of the expected values the transaction will fail validation.</remarks>
        [XmlEnum("104")]
        RESULTINFO_INVALIDATTACHTYPE = 104,

        /// <summary>Unable to decode the transaction.</summary>
        [XmlEnum("105")]
        RESULTINFO_UNABLETODECODE = 105,

        /// <summary>Type code doesn't pass ATTACHMENT PROCESS checks</summary>
        /// <remarks>The AttachmentType code passes validation check performed by the intermediary passing the transaction. However, the receiver does not support the type code used. For example, in Attachment, the intermediary allows type codes '259'. However, the receiver does not support '259' and the transaction fails because it cannot be processed by the receiver.</remarks>
        [XmlEnum("106")]
        RESULTINFO_NOPROCATTTYP = 106,

        /// <summary>The type code does not pass MIME PROCESS checks</summary>
        /// <remarks>The MimeType type code passes validation check performed by the intermediary passing the transaction. However, the final destination receiver does not support the type code used. For example, in FormInstance, the intermediary allows type codes '11' or '17'. However, the receiver does not support '17' and the transaction fails because it cannot be processed by the receiver.</remarks>
        [XmlEnum("107")]
        RESULTINFO_NOPROCMIMETYP = 107,

        /// <summary>Original transaction not found.</summary>
        /// <remarks>Sender's reference to the OriginatingTransactionType on FormInstance is not found by Receiver.</remarks>
        [XmlEnum("108")]
        RESULTINFO_MESSAGENOTFOUND = 108,

        /// <summary>Document not signed.</summary>
        /// <remarks>Sender sent a document in FormInstance that was not signed by the participant.</remarks>
        [XmlEnum("109")]
        RESULTINFO_DOCUMENTNOTSIGNED = 109,

        /// <summary>Document is incomplete.</summary>
        /// <remarks>Sendor sent a document in FormInstance that was not completed in its entirity.</remarks>
        [XmlEnum("110")]
        RESULTINFO_INCOMPLETEDOC = 110,

        /// <summary>Contract is inactive.</summary>
        /// <remarks>Sendor sends a document in FormInstance associated with a contract that is not active.  Documents are not accepted by the reciever because they cannot process.</remarks>
        [XmlEnum("111")]
        RESULTINFO_CONTRACTINACTIVE = 111,

        /// <summary>Contract owner is deceased.</summary>
        /// <remarks>Sendor sends a document in FormInstance where the contract owner is deceased.  Documents are not accepted by the receiver because they cannot process.</remarks>
        [XmlEnum("112")]
        RESULTINFO_OWNERDEC = 112,

        /// <summary>Document is not expected.</summary>
        /// <remarks>Sendor sent a document that is not expected by Receiver.</remarks>
        [XmlEnum("113")]
        RESULTINFO_WRONGRECIPIENT = 113,

        /// <summary>Electronic Documents not accepted.</summary>
        /// <remarks>Receiver of the transaction does not accept documents sent electronically in FormInstance.</remarks>
        [XmlEnum("114")]
        RESULTINFO_NOELECTDOCS = 114,

        /// <summary>Secure Hash Algorithm Mismatch</summary>
        /// <remarks>Hash included in the file does not match HashType on AttachmentHashAlgorithm.</remarks>
        [XmlEnum("115")]
        RESULTINFO_HASHMISMATCH = 115,

        /// <summary>General Data Error</summary>
        [XmlEnum("200")]
        RESULTINFO_DATA = 200,

        /// <summary>XML Parser Error</summary>
        /// <remarks>The system encountered an error parsing the XML message.</remarks>
        [XmlEnum("201")]
        RESULTINFO_XMLPARSE = 201,

        /// <summary>Database Constraint Violation</summary>
        /// <remarks>A database constraint was violated while processing the request.  This could be a column constraint or foreign key constraint.</remarks>
        [XmlEnum("202")]
        RESULTINFO_DBCONSTRAINT = 202,

        /// <summary>Invalid TransactionContext</summary>
        /// <remarks>The request contained a value for <TransactionContext> that is not supported or has expired. This usually occurs in the context of a Search transaction with a large ResultSet.</remarks>
        [XmlEnum("203")]
        RESULTINFO_INVALIDTRANSCONTEXT = 203,

        /// <summary>System Not Available</summary>
        [XmlEnum("300")]
        RESULTINFO_NOTAVAILSYS = 300,

        /// <summary>Function Not Available</summary>
        [XmlEnum("400")]
        RESULTINFO_NOTAVAILFUNCTION = 400,

        /// <summary>Unsupported Service</summary>
        [XmlEnum("500")]
        RESULTINFO_UNSUPPORTED = 500,

        /// <summary>Unable to Process Transaction at This Time</summary>
        [XmlEnum("600")]
        RESULTINFO_UNABLEATTHISTIME = 600,

        /// <summary>Supported Transactions</summary>
        /// <remarks>Use this result info code description to return which transactions are supported, separated by semicolons.</remarks>
        [XmlEnum("601")]
        RESULTINFO_SUPPORTED_TRANS = 601,

        /// <summary>Maximum Number of Errors Exceeded</summary>
        [XmlEnum("700")]
        RESULTINFO_MAXERRSEXCEED = 700,

        /// <summary>Maximum Records exceeded</summary>
        /// <remarks>Used with back-end processing to indicate more data or that search criteria are not specific enough.</remarks>
        [XmlEnum("710")]
        RESULTINFO_MAXRECSEXCEED = 710,

        /// <summary>Table Read Error</summary>
        /// <remarks>A system error has occurred in attempting to read a typecode table</remarks>
        [XmlEnum("720")]
        RESULTINFO_TABLEREADERROR = 720,

        /// <summary>Insufficient Information - See details</summary>
        /// <remarks>See details in Result Info Description</remarks>
        [XmlEnum("730")]
        RESULTINFO_INSSUFFICIENTINFO = 730,

        /// <summary>URL Reference</summary>
        /// <remarks>URL Provided for path to site for Agent/Financial Advisor review. This provides the link to see the results of the transaction in ResultInfoDesc, for example the signed documents after and Esignature Request.</remarks>
        [XmlEnum("800")]
        RESULTINFO_URLREF = 800,

        /// <summary>Unknown reason</summary>
        /// <remarks>Failed for unknown reason</remarks>
        [XmlEnum("999")]
        RESULTINFO_UNKNOWN = 999,

        /// <summary>Transaction/Order cancelled. No longer interested.</summary>
        /// <remarks>Transaction/Order cancelled. Applicant/owner no longer interested.</remarks>
        [XmlEnum("1000")]
        RESULTINFO_ORDERCANCEL = 1000,

        /// <summary>Invalid User</summary>
        [XmlEnum("1420")]
        RESULTINFO_INVALIDUSER = 1420,

        /// <summary>Unsupported Vendor</summary>
        [XmlEnum("1430")]
        RESULTINFO_UNSUPPORTEDVENDOR = 1430,

        /// <summary>Unsupported Proxy Vendor</summary>
        [XmlEnum("1440")]
        RESULTINFO_UNSUPPORTEDPROXY = 1440,

        /// <summary>Invalid UserSessionKey</summary>
        [XmlEnum("1450")]
        RESULTINFO_INVALIDUSERSESSIONKEY = 1450,

        /// <summary>UserSessionKey Expired</summary>
        [XmlEnum("1460")]
        RESULTINFO_EXPIREDUSERSESSIONKEY = 1460,

        /// <summary>Password encryption type not valid</summary>
        [XmlEnum("1600")]
        RESULTINFO_PSWDENCRIPTTYPEINVALID = 1600,

        /// <summary>Security Violation</summary>
        [XmlEnum("1700")]
        RESULTINFO_SECURITYVIOLATION = 1700,

        /// <summary>Invalid Password</summary>
        [XmlEnum("1740")]
        RESULTINFO_INVALIDPSWD = 1740,

        /// <summary>Customer Session Already In Progress</summary>
        [XmlEnum("1820")]
        RESULTINFO_SESSIONINPROGRESS = 1820,

        /// <summary>No Customer Session in Progress</summary>
        [XmlEnum("1840")]
        RESULTINFO_NOSESSIONINPROGRESS = 1840,

        /// <summary>Customer Locked Out</summary>
        [XmlEnum("1880")]
        RESULTINFO_LOCKEDOUT = 1880,

        /// <summary>Must Change Password</summary>
        [XmlEnum("1910")]
        RESULTINFO_CHANGEPSWD = 1910,

        /// <summary>Unsupported application</summary>
        [XmlEnum("1980")]
        RESULTINFO_APPLICATIONUNSUPPORTED = 1980,

        /// <summary>Object Not Found</summary>
        /// <remarks>Object being referenced is not found.  It may not exist or there could be an error in matching criteria.</remarks>
        [XmlEnum("2001")]
        RESULTINFO_OBJECTNOTFOUND = 2001,

        /// <summary>Duplicate Object Found</summary>
        /// <remarks>When doing an inquiry or a change request;  more than one object was found that met your criteria (e.g. two policies with the same number).</remarks>
        [XmlEnum("2002")]
        RESULTINFO_DUPLICATEOBJECT = 2002,

        /// <summary>Required Element Missing</summary>
        [XmlEnum("2003")]
        RESULTINFO_ELEMENTMISSING = 2003,

        /// <summary>Required Element Invalid</summary>
        [XmlEnum("2004")]
        RESULTINFO_ELEMENTINVALID = 2004,

        /// <summary>Required Element Below Range</summary>
        [XmlEnum("2005")]
        RESULTINFO_ELEMENTBELOWRANGE = 2005,

        /// <summary>Required Element Above Range</summary>
        [XmlEnum("2006")]
        RESULTINFO_ELEMENTABOVERANGE = 2006,

        /// <summary>Transaction not allowed for this particular entity.</summary>
        /// <remarks>This transaction cannot be processed because an entity (person or organization) is not authorized to perform that action or activity.</remarks>
        [XmlEnum("2007")]
        RESULTINFO_NOTALLOWED = 2007,

        /// <summary>URL Not Available</summary>
        /// <remarks>When URL redirection is requested</remarks>
        [XmlEnum("2008")]
        RESULTINFO_URLNOTAVAILABLE = 2008,

        /// <summary>URL request Denied</summary>
        /// <remarks>When URL redirection is requested</remarks>
        [XmlEnum("2009")]
        RESULTINFO_URLREQUESTDENIED = 2009,

        /// <summary>Fund not found</summary>
        [XmlEnum("2011")]
        RESULTINFO_FUNDNOTFOUND = 2011,

        /// <summary>Fund Allocation percent out of range</summary>
        [XmlEnum("2012")]
        RESULTINFO_FUNDALLOCATIONPCTOUTRANGE = 2012,

        /// <summary>Fund closed for new money</summary>
        [XmlEnum("2013")]
        RESULTINFO_FUNDCLOSEDTONEWMONEY = 2013,

        /// <summary>Allocation/Distribution does not total 100%</summary>
        [XmlEnum("2014")]
        RESULTINFO_ALLOCATIONNOT100 = 2014,

        /// <summary>Duplicate or contradictory allocation for same fund</summary>
        [XmlEnum("2015")]
        RESULTINFO_DUPALLOCATION = 2015,

        /// <summary>Daily Unit Value is not available</summary>
        [XmlEnum("2016")]
        RESULTINFO_UNITVALUENOTAVAILABLE = 2016,

        /// <summary>Fund Allocation defaulted to pro-rata amount.</summary>
        [XmlEnum("2017")]
        RESULTINFO_DEFAULTEDTOPRORATA = 2017,

        /// <summary>Calculated Unit Value is Unequal to Input Value.</summary>
        [XmlEnum("2018")]
        RESULTINFO_UNITVALUENOTEQUAL = 2018,

        /// <summary>Item Not Active</summary>
        [XmlEnum("2019")]
        RESULTINFO_NOTACTIVE = 2019,

        /// <summary>Below Minimum Number of Days needed between Changes</summary>
        [XmlEnum("2020")]
        RESULTINFO_BELOWMINIMUMDAYS = 2020,

        /// <summary>Amount adjusted to specified minimum.</summary>
        [XmlEnum("2021")]
        RESULTINFO_AMTADJUSTEDTOMIN = 2021,

        /// <summary>Request Exceeds the Maximum allowed</summary>
        /// <remarks>e.g. number of fund transfers or withdrawals permitted for the year.</remarks>
        [XmlEnum("2022")]
        RESULTINFO_EXCEEDSMAX = 2022,

        /// <summary>Unable to release funds - Contract Annuitized</summary>
        [XmlEnum("2023")]
        RESULTINFO_NORELEASE_ANNUITIZED = 2023,

        /// <summary>Unable to release funds - Policy Collaterally Assigned</summary>
        [XmlEnum("2024")]
        RESULTINFO_NORELEASE_POLICYASSIGNED = 2024,

        /// <summary>Contract in Death Claim Pending Status</summary>
        /// <remarks>The transaction cannot be processed because a death claim is pending on this policy.</remarks>
        [XmlEnum("2025")]
        RESULTINFO_DTHCLMPEND = 2025,

        /// <summary>Contract has a Pending 1035 or Transfer</summary>
        /// <remarks>The transaction cannot be processed because a 1035 Exchange or Qualified Transfer is pending on this contract.</remarks>
        [XmlEnum("2026")]
        RESULTINFO_PEND1035 = 2026,

        /// <summary>Contract is Restricted</summary>
        /// <remarks>The transaction cannot be processed because the policy is restricted which prevents the requested transaction from being processed.</remarks>
        [XmlEnum("2027")]
        RESULTINFO_RESTRICT = 2027,

        /// <summary>Owner GovtID does not match Carrier's records</summary>
        /// <remarks>The transaction cannot be processed because the Owner’s GovtID provided does not match Carrier's records.</remarks>
        [XmlEnum("2028")]
        RESULTINFO_OWNGOVTIDNOMATCH = 2028,

        /// <summary>Annuitant GovtID does not match Carrier's records</summary>
        /// <remarks>The transaction cannot be processed because the Annuitant’s GovtID provided does not match Carrier's records.</remarks>
        [XmlEnum("2029")]
        RESULTINFO_ANNGOVTIDNOMATCH = 2029,

        /// <summary>Product Type Prevents Transaction</summary>
        /// <remarks>The transaction cannot be processed because the product type prevents this type of transaction.</remarks>
        [XmlEnum("2030")]
        RESULTINFO_PRODTYPE = 2030,

        /// <summary>Multiple Transactions Not Permitted</summary>
        /// <remarks>Only one transaction of this type is allowed on a contract during a particular time period (e. g. day).</remarks>
        [XmlEnum("2031")]
        RESULTINFO_MULTTRANS = 2031,

        /// <summary>Minimum balance requirements violated</summary>
        /// <remarks>The requested transaction violates the requirements of the remaining fund balance.</remarks>
        [XmlEnum("2032")]
        RESULTINFO_MINBALVIOL = 2032,

        /// <summary>Minimum transaction amount requirement not met</summary>
        /// <remarks>The requested transaction violates the requirements of the minimum transaction amount.</remarks>
        [XmlEnum("2033")]
        RESULTINFO_MINAMTNOMET = 2033,

        /// <summary>Compenent Restriction</summary>
        /// <remarks>The requested transaction violates the requirements of one or multiple insurance components (riders, coverages, options, etc.) on the contract.</remarks>
        [XmlEnum("2034")]
        RESULTINFO_COMPRESTRICT = 2034,

        /// <summary>Arrangement Prevents This Transaction</summary>
        /// <remarks>The requested transaction violates the requirements of one or multiple service programs (Arrangements) on the contract.</remarks>
        [XmlEnum("2035")]
        RESULTINFO_ARRRESTRIC = 2035,

        /// <summary>Fund restriction - maturity date</summary>
        /// <remarks>The requested transaction cannot be processed because the source fund is restricted until maturity date or window period is reached.</remarks>
        [XmlEnum("2036")]
        RESULTINFO_FUNDRESTRICT = 2036,

        /// <summary>Amount requested below minimum</summary>
        /// <remarks>The requested transaction cannot be processed because the minimum transaction amount for this fund was not met.</remarks>
        [XmlEnum("2037")]
        RESULTINFO_AMTBELOWMIN = 2037,

        /// <summary>Requested amount exceeds limit</summary>
        /// <remarks>The requested transaction cannot be processed because the amount from the fund is in excess of the allowed amount.</remarks>
        [XmlEnum("2038")]
        RESULTINFO_EXCDSLIMIT = 2038,

        /// <summary>Number of source funds exceeds number allowed</summary>
        /// <remarks>The requested transaction cannot be processed because there are more source funds requested than are allowed.</remarks>
        [XmlEnum("2039")]
        RESULTINFO_ONESRCEALLOWED = 2039,

        /// <summary>Received After Cutoff Time</summary>
        /// <remarks>Transaction requested to be processed today cannot be processed due to cutoff time.</remarks>
        [XmlEnum("2040")]
        RESULTINFO_CUTOFFTIME = 2040,

        /// <summary>Number of destination funds exceeds number allowed</summary>
        /// <remarks>The requested transaction cannot be processed because there are more destination funds requested than are allowed.</remarks>
        [XmlEnum("2041")]
        RESULTINFO_DESTBELOWMI = 2041,

        /// <summary>Original transaction was not found</summary>
        /// <remarks>This transaction intended to affect an original transaction but the original transaction was not found.</remarks>
        [XmlEnum("2042")]
        RESULTINFO_ORIGNOTFND = 2042,

        /// <summary>Original transaction already processed</summary>
        /// <remarks>This transaction intended to cancel an original transaction;  this transaction cannot be processed because the original transaction was already processed.</remarks>
        [XmlEnum("2043")]
        RESULTINFO_ORIGNOTOPN = 2043,

        /// <summary>Duplicate of a previous transaction</summary>
        /// <remarks>This transaction, such as a cancellation or a reversal, was already requested.  Therefore, there is no action to be performed.</remarks>
        [XmlEnum("2044")]
        RESULTINFO_DUPL = 2044,

        /// <summary>Specified range not exact match. Available information provided.</summary>
        [XmlEnum("2101")]
        RESULTINFO_RANGENOTMATCHED = 2101,

        /// <summary>Nothing available</summary>
        [XmlEnum("2102")]
        RESULTINFO_NOTAVAILABLE = 2102,

        /// <summary>Conflict In Pending Transactions</summary>
        /// <remarks>Existing transaction conflicts with transaction being attempted.</remarks>
        [XmlEnum("2103")]
        RESULTINFO_CONFLICT = 2103,

        /// <summary>Excessive Trading Restriction</summary>
        /// <remarks>Carrier has restricted contract for excessive trading.  Transaction cannot be processed.</remarks>
        [XmlEnum("2104")]
        RESULTINFO_EXCESSIVE = 2104,

        /// <summary>Cancelled by Owner</summary>
        /// <remarks>Transaction was processed via automated system.  Owner subsequently ordered a cancel of that transaction outside of automated system.  This code would be used in a Day 2 confirm</remarks>
        [XmlEnum("2105")]
        RESULTINFO_CANCELOWNER = 2105,

        /// <summary>Cancelled by Agent</summary>
        /// <remarks>Transaction was processed via automated system.  Agent subsequently ordered a cancel of that transaction outside of automated system.  This code would be used in a Day 2 confirm</remarks>
        [XmlEnum("2106")]
        RESULTINFO_CANCELAGENT = 2106,

        /// <summary>Cancelled by Interested Party</summary>
        /// <remarks>Transaction was processed via automated system.  Interest Party, other than owner or agent subsequently ordered a cancel of that transaction outside of automated system.  This code would be used in a Day 2 confirm</remarks>
        [XmlEnum("2107")]
        RESULTINFO_CANCELINTPART = 2107,

        /// <summary>Agent does not match policy record (mismatch)</summary>
        /// <remarks>Agent submitted on transaction does not match what Carrier has on its own records.</remarks>
        [XmlEnum("2108")]
        RESULTINFO_AGENTMISMATCH = 2108,

        /// <summary>Distributor does not match policy record</summary>
        /// <remarks>Distributor submitted on transaction does not match what Carrier has on its own records.</remarks>
        [XmlEnum("2109")]
        RESULTINFO_DISTMISMATCH = 2109,

        /// <summary>Exceeds limit on fixed fund</summary>
        /// <remarks>Fixed funds has already exceeded the number of allowable trades for the period determined by the Carrier.</remarks>
        [XmlEnum("2110")]
        RESULTINFO_FIXFUNDEXCEEDED = 2110,

        /// <summary>Missing Arrangement</summary>
        /// <remarks>The requested transaction did not have the required arrangement information needed to make the transaction in good order.</remarks>
        [XmlEnum("2111")]
        RESULTINFO_MISSINGARR = 2111,

        /// <summary>Requested Arrangement Not Found</summary>
        /// <remarks>An arrangement update was received, but the requested arrangement was not found.</remarks>
        [XmlEnum("2112")]
        RESULTINFO_ARRNOTFOUND = 2112,

        /// <summary>SEC 22c-2 Restriction</summary>
        /// <remarks>Rejected due to SEC 22c2 violations</remarks>
        [XmlEnum("2113")]
        RESULTINFO_SEC22C2REST = 2113,

        /// <summary>Agent Status Change Warning</summary>
        /// <remarks>Agent is currently in a warning status.  Transaction may place agent in restricted status.</remarks>
        [XmlEnum("2114")]
        RESULTINFO_AGENTWARNING = 2114,

        /// <summary>Arrangement Problem Only</summary>
        /// <remarks>Fund Transfer 102 message failed due to a problem with the arrangement not the actual fund transfer.</remarks>
        [XmlEnum("2115")]
        RESULTINFO_ARRANGEPROBLEM = 2115,

        /// <summary>Contract Status Change Warning</summary>
        /// <remarks>Contract is currently in a warning status.  Transaction may place contract in restricted status.</remarks>
        [XmlEnum("2116")]
        RESULTINFO_CONTRACTWARNING = 2116,

        /// <summary>Fund Transfer Problem Only</summary>
        /// <remarks>Fund Transfer 102 message failed due to a problem with the Fund Transfer, not the arrangement update.</remarks>
        [XmlEnum("2117")]
        RESULTINFO_FTPROBLEM = 2117,

        /// <summary>MVA Warning</summary>
        /// <remarks>Market value adjustment may apply to this transaction. An MVA may decrease, increase or have no effect on your contract.</remarks>
        [XmlEnum("2118")]
        RESULTINFO_MVA = 2118,

        /// <summary>Pending Fund Transfer Override</summary>
        /// <remarks>A pending fund transfer already exists for this contract today.  By executing this fund transfer, any previous fund transfer transactions submitted today will be deleted.</remarks>
        [XmlEnum("2119")]
        RESULTINFO_PENDOVERIDE = 2119,

        /// <summary>Rider Violation Warning</summary>
        /// <remarks>Requested transaction is in violation of Rider specific allocation rules.  This transaction may be automatically allocated back to rules set by rider.</remarks>
        [XmlEnum("2120")]
        RESULTINFO_RIDERWARNING = 2120,

        /// <summary>Market Condition Warning</summary>
        /// <remarks>Change of Fund Market Value at close of business may impact ability to process transaction.</remarks>
        [XmlEnum("2121")]
        RESULTINFO_SOFTCLOSE = 2121,

        /// <summary>Special Fund Warning</summary>
        /// <remarks>This portfolio is deemed "Special Funds".  Amounts invested in and/or out of these funds could impact a contract feature, such as death benefit, living benefit riders or guaranteed features.</remarks>
        [XmlEnum("2122")]
        RESULTINFO_SPECIALFUNDS = 2122,

        /// <summary>Ineligible for coverage</summary>
        [XmlEnum("2201")]
        RESULTINFO_INELLIGFORCOV = 2201,

        /// <summary>Eligible for coverage in the future</summary>
        [XmlEnum("2202")]
        RESULTINFO_ELIGIBLEINFUTURE = 2202,

        /// <summary>Invalid Address</summary>
        [XmlEnum("2300")]
        RESULTINFO_INVALIDADDRESS = 2300,

        /// <summary>Invalid Phone</summary>
        [XmlEnum("2301")]
        RESULTINFO_INVALIDPHONE = 2301,

        /// <summary>Invalid Email Address</summary>
        [XmlEnum("2302")]
        RESULTINFO_INVALIDEMAIL = 2302,

        /// <summary>The premium has been increased.</summary>
        [XmlEnum("3001")]
        RESULTINFO_PREMINCREASED = 3001,

        /// <summary>The premium has been reduced.</summary>
        [XmlEnum("3002")]
        RESULTINFO_PREMREDUCED = 3002,

        /// <summary>The loan repayment has been reduced.</summary>
        [XmlEnum("3003")]
        RESULTINFO_LOANREPAYREDUCED = 3003,

        /// <summary>The specified loan has been reduced.</summary>
        [XmlEnum("3004")]
        RESULTINFO_LOANREQREDUCED = 3004,

        /// <summary>The specified withdrawal has been reduced.</summary>
        [XmlEnum("3005")]
        RESULTINFO_WITHDRWLREDUCED = 3005,

        /// <summary>The initial coverage amount has been increased.</summary>
        [XmlEnum("3006")]
        RESULTINFO_COVAMTINCREASED = 3006,

        /// <summary>The coverage amount adjustment was not processed.</summary>
        [XmlEnum("3007")]
        RESULTINFO_COVAMTCHGREJ = 3007,

        /// <summary>The coverage amount adjustment was increased to meet minimum.</summary>
        [XmlEnum("3008")]
        RESULTINFO_COVAMTCHGINCMIN = 3008,

        /// <summary>The coverage amount adjustment was reduced to meet maximum.</summary>
        [XmlEnum("3009")]
        RESULTINFO_COVAMTCHGREDMAX = 3009,

        /// <summary>The coverage amount adjustment was increased.</summary>
        [XmlEnum("3010")]
        RESULTINFO_COVAMTCHGINC = 3010,

        /// <summary>The coverage amount adjustment was reduced.</summary>
        [XmlEnum("3011")]
        RESULTINFO_COVAMTCHGRED = 3011,

        /// <summary>The death benefit guarantee was cancelled.</summary>
        [XmlEnum("3012")]
        RESULTINFO_GDBREDUCED = 3012,

        /// <summary>The requested transaction was not processed.</summary>
        [XmlEnum("3013")]
        RESULTINFO_NOTPROCESSED = 3013,

        /// <summary>The requested illustration result vector is not available on This product.</summary>
        [XmlEnum("3014")]
        RESULTINFO_VECTORNOTAVAIL = 3014,

        /// <summary>The requested transaction violates product rules.</summary>
        [XmlEnum("3015")]
        RESULTINFO_VIOLATESRULES = 3015,

        /// <summary>A modification was made to the specified coverage due to product rules.</summary>
        [XmlEnum("3016")]
        RESULTINFO_COVMODRULES = 3016,

        /// <summary>The requested coverage is not available due to product rules.</summary>
        [XmlEnum("3017")]
        RESULTINFO_COVNOTAVAILRULES = 3017,

        /// <summary>Policy has lapsed due to product rules.</summary>
        [XmlEnum("3018")]
        RESULTINFO_LAPSED = 3018,

        /// <summary>Timing option requested is not supported for This vector.</summary>
        [XmlEnum("3019")]
        RESULTINFO_TIMENOTSUPPORTED = 3019,

        /// <summary>Contract not eligible for surrender</summary>
        /// <remarks>Details explained in ResultInfoDesc</remarks>
        [XmlEnum("3020")]
        RESULTINFO_NOTELIGIBLETOSURR = 3020,

        /// <summary>No Active Policy - Contract terminated outside of Statutory Period</summary>
        [XmlEnum("3021")]
        RESULTINFO_TERMINATEDGTSTATUTORY = 3021,

        /// <summary>No Active Policy - Contract terminated within Statutory Period</summary>
        [XmlEnum("3022")]
        RESULTINFO_TERMINATELTSTATUTORY = 3022,

        /// <summary>No Cash Value</summary>
        [XmlEnum("3023")]
        RESULTINFO_NOCV = 3023,

        /// <summary>Forms Not in Good Order</summary>
        [XmlEnum("3024")]
        RESULTINFO_FORMNOTGOOD = 3024,

        /// <summary>Missing Required Forms</summary>
        [XmlEnum("3025")]
        RESULTINFO_MISSINGFORM = 3025,

        /// <summary>No or Unknown Policy Number</summary>
        /// <remarks>Policy number provided is unrecognizable or was not found by the receiving system</remarks>
        [XmlEnum("3026")]
        RESULTINFO_UNKNOWNPOLNUM = 3026,

        /// <summary>Unknown Insured</summary>
        [XmlEnum("3027")]
        RESULTINFO_UNKNOWNINSURE = 3027,

        /// <summary>Auto Policy Number Assigned</summary>
        /// <remarks>As a result of a TXLife103 - AppSubmit - the receiving system has assigned a Policy Number and returned the resulting number in the 103 response</remarks>
        [XmlEnum("3028")]
        RESULTINFO_AUTOPOLNUMBER = 3028,

        /// <summary>Agent Inactive/Terminated</summary>
        [XmlEnum("3032")]
        RESULTINFO_AGENTINACTIVE = 3032,

        /// <summary>Date of Birth Incorrect</summary>
        [XmlEnum("3033")]
        RESULTINFO_INCORRECTDOB = 3033,

        /// <summary>Firm Request</summary>
        [XmlEnum("3034")]
        RESULTINFO_FIRMREQUEST = 3034,

        /// <summary>Home State Certification Not Received</summary>
        [XmlEnum("3035")]
        RESULTINFO_HOMESTCERTNOTRECD = 3035,

        /// <summary>Incorrect Fee</summary>
        [XmlEnum("3036")]
        RESULTINFO_INCORRECTFEE = 3036,

        /// <summary>Legal entity name missing</summary>
        [XmlEnum("3037")]
        RESULTINFO_LEGENTNAMEMISSING = 3037,

        /// <summary>Merger</summary>
        [XmlEnum("3038")]
        RESULTINFO_MERGER = 3038,

        /// <summary>Original paperwork not received</summary>
        [XmlEnum("3039")]
        RESULTINFO_ORIGPAPERNOTRECD = 3039,

        /// <summary>Products not available in state</summary>
        [XmlEnum("3040")]
        RESULTINFO_PRODNOTAVAIL = 3040,

        /// <summary>Residence state difference</summary>
        [XmlEnum("3041")]
        RESULTINFO_RESSTATEDIFF = 3041,

        /// <summary>State rejected appointment</summary>
        [XmlEnum("3042")]
        RESULTINFO_STATEREJAPPT = 3042,

        /// <summary>Producer Tax Id Invalid</summary>
        [XmlEnum("3043")]
        RESULTINFO_PRODTAXIDINVALID = 3043,

        /// <summary>Zip Code Invalid</summary>
        [XmlEnum("3044")]
        RESULTINFO_ZIPCODEINVALID = 3044,

        /// <summary>Valid Routing Number</summary>
        /// <remarks>The routing number is a valid ABA number.</remarks>
        [XmlEnum("3045")]
        RESULTINFO_VALIDNUM = 3045,

        /// <summary>Invalid Routing Number</summary>
        /// <remarks>The routing number is an invalid ABA number.</remarks>
        [XmlEnum("3046")]
        RESULTINFO_INVALIDNUM = 3046,

        /// <summary>Producer Can Sell</summary>
        /// <remarks>Active License and Appointment with correct LinesOfAuthority for Jurisdiction and LinesOfBusiness provided</remarks>
        [XmlEnum("4000")]
        RESULTINFO_PROCANSELL = 4000,

        /// <summary>Producer May Sell</summary>
        /// <remarks>Active License and Appointment but not enough info to determine if proper LinesOfAuthority or Jurisdiction</remarks>
        [XmlEnum("4001")]
        RESULTINFO_PROMAYSELL = 4001,

        /// <summary>Producer Cannot Sell</summary>
        /// <remarks>The producer failed the "can sell" verification rules for unspecified reason(s).  Additional detail can be provided in ResultInfoDesc.</remarks>
        [XmlEnum("4002")]
        RESULTINFO_PROCANTSELL = 4002,

        /// <summary>No Carrier Appointment Found</summary>
        [XmlEnum("4060")]
        RESULTINFO_NOCARRAPPTFND = 4060,

        /// <summary>Appointed - Active Appointment Found</summary>
        [XmlEnum("4061")]
        RESULTINFO_APPOINTED = 4061,

        /// <summary>Appointment Pending - See ResultInfoDesc for details</summary>
        [XmlEnum("4067")]
        RESULTINFO_APPTPEND = 4067,

        /// <summary>Appointment Suspended - See ResultInfoDesc for details</summary>
        [XmlEnum("4068")]
        RESULTINFO_APPTSUSP = 4068,

        /// <summary>Appointment Terminated - See ResultInfoDesc for details</summary>
        [XmlEnum("4069")]
        RESULTINFO_APPTTERM = 4069,

        /// <summary>No License Found</summary>
        [XmlEnum("4070")]
        RESULTINFO_NOLICFND = 4070,

        /// <summary>Licensed - Active License Found</summary>
        [XmlEnum("4071")]
        RESULTINFO_ACTIVELIC = 4071,

        /// <summary>License Pending - See ResultInfoDesc for details</summary>
        [XmlEnum("4077")]
        RESULTINFO_LICPEND = 4077,

        /// <summary>License Suspended - See ResultInfoDesc for details</summary>
        [XmlEnum("4078")]
        RESULTINFO_LICSUSP = 4078,

        /// <summary>License Terminated - See ResultInfoDesc for details</summary>
        [XmlEnum("4079")]
        RESULTINFO_LICTERM = 4079,

        /// <summary>No Registration Found</summary>
        [XmlEnum("4080")]
        RESULTINFO_NOREGFND = 4080,

        /// <summary>Registered - Active Registration Found</summary>
        [XmlEnum("4081")]
        RESULTINFO_REGISTERED = 4081,

        /// <summary>Registration Pending - See ResultInfoDesc for details</summary>
        [XmlEnum("4087")]
        RESULTINFO_REGISPEND = 4087,

        /// <summary>Registration Suspended - See ResultInfoDesc for details</summary>
        [XmlEnum("4088")]
        RESULTINFO_REGISSUSP = 4088,

        /// <summary>Registration Terminated - See ResultInfoDesc for details</summary>
        [XmlEnum("4089")]
        RESULTINFO_REGISTERM = 4089,

        /// <summary>Deceased</summary>
        /// <remarks>Dead, no longer exists</remarks>
        [XmlEnum("4100")]
        OLI_RESULTINFO_DE = 4100,

        /// <summary>Insurance company decision</summary>
        [XmlEnum("4101")]
        OLI_RESULTINFO_CD = 4101,

        /// <summary>For Cause</summary>
        /// <remarks>Example, producer was terminated for cause.</remarks>
        [XmlEnum("4102")]
        OLI_RESULTINFO_FC = 4102,

        /// <summary>Inadequate sales production</summary>
        /// <remarks>The producer did not produce the minimum level of sales volume required to remain appointed. Therefore, they were terminated.</remarks>
        [XmlEnum("4103")]
        OLI_RESULTINFO_IP = 4103,

        /// <summary>Producer Moved</summary>
        [XmlEnum("4104")]
        OLI_RESULTINFO_MV = 4104,

        /// <summary>Voluntary Termination</summary>
        [XmlEnum("4105")]
        OLI_RESULTINFO_VT = 4105,

        /// <summary>Team Member Invalid/Missing</summary>
        [XmlEnum("4106")]
        OLI_RESULTINFO_TR = 4106,

        /// <summary>Requested view not supported. Full view returned.</summary>
        [XmlEnum("5000")]
        RESULTINFO_VIEWNOTSUPP = 5000,

        /// <summary>Requested view not found. Full view returned.</summary>
        [XmlEnum("5001")]
        RESULTINFO_VIEWNOTFOUND = 5001,

        /// <summary>Requested view expired. Full view returned.</summary>
        [XmlEnum("5002")]
        RESULTINFO_VIEWEXPIRED = 5002,

        /// <summary>Invalid combination selected. Full view returned.</summary>
        [XmlEnum("5003")]
        RESULTINFO_VIEWCOMBOINV = 5003,

        /// <summary>Subset combination not supported. Full view returned.</summary>
        [XmlEnum("5004")]
        RESULTINFO_SUBSETNOTSUPP = 5004,

        /// <summary>Requestor created views are not a supported feature. Full view returned.</summary>
        [XmlEnum("5005")]
        RESULTINFO_REQVIEWNOTSUPP = 5005,

        /// <summary>Requestor created view cannot be permanently persisted.</summary>
        [XmlEnum("5006")]
        RESULTINFO_REQVIEWNOTPERMPERS = 5006,

        /// <summary>Requestor created view cannot be used later in session.</summary>
        [XmlEnum("5007")]
        RESULTINFO_REQVIEWNOTSESSPERS = 5007,
    }
}
