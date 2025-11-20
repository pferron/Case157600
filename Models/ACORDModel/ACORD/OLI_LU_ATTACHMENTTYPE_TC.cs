using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_ATTACHMENTTYPE_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Document</summary>
        [XmlEnum("1")]
        OLI_ATTACH_DOC = 1,

        /// <summary>Comment/Remark</summary>
        /// <remarks>Use for Comments or Form Remarks sections</remarks>
        [XmlEnum("2")]
        OLI_ATTACH_COMMENT = 2,

        /// <summary>Letter</summary>
        [XmlEnum("3")]
        OLI_ATTACH_LETTER = 3,

        /// <summary>E-Mail</summary>
        [XmlEnum("4")]
        OLI_ATTACH_EMAIL = 4,

        /// <summary>Form</summary>
        [XmlEnum("5")]
        OLI_ATTACH_FORM = 5,

        /// <summary>Pre-Candidate Illustration</summary>
        [XmlEnum("6")]
        OLI_ATTACH_PRECAND = 6,

        /// <summary>As Originally Sold Illustration</summary>
        [XmlEnum("7")]
        OLI_ATTACH_ASORIGSOLDILLUS = 7,

        /// <summary>Reproposal</summary>
        [XmlEnum("8")]
        OLI_ATTACH_REPROPOSAL = 8,

        /// <summary>Revised Illustration</summary>
        [XmlEnum("9")]
        OLI_ATTACH_REVISEDILLUS = 9,

        /// <summary>Original Application</summary>
        [XmlEnum("10")]
        OLI_ATTACH_ORIGINALAPP = 10,

        /// <summary>Revised Application</summary>
        [XmlEnum("11")]
        OLI_ATTACH_REVISEDAPP = 11,

        /// <summary>Underwriting Note</summary>
        /// <remarks>General underwriting note when the intended recipient is not specified.</remarks>
        [XmlEnum("12")]
        OLI_ATTACH_UNDRWRTNOTE = 12,

        /// <summary>Wet signature image</summary>
        [XmlEnum("13")]
        OLI_ATTACH_WETSIGN = 13,

        /// <summary>General Note</summary>
        [XmlEnum("14")]
        OLI_ATTACH_GENERALNOTE = 14,

        /// <summary>Exception Note</summary>
        [XmlEnum("15")]
        OLI_ATTACH_EXCEPTIONNOTE = 15,

        /// <summary>MIB Search data returned in the MIB Service Request format</summary>
        /// <remarks>Data associated with this attachment contain the results of an MIB Search</remarks>
        [XmlEnum("19")]
        OLI_ATTACH_MIB_SERVRESP = 19,

        /// <summary>Motor vehicle report information</summary>
        /// <remarks>Data associated with this attachment contain the results of an MVR request</remarks>
        [XmlEnum("20")]
        OLI_ATTACH_MVR = 20,

        /// <summary>IAI data</summary>
        /// <remarks>Data associated with this attachment contain the results of an IAI Search</remarks>
        [XmlEnum("21")]
        OLI_ATTACH_IAIDATA = 21,

        /// <summary>Prescription data</summary>
        /// <remarks>Data associated with this attachment contain the results of a Prescription Profile</remarks>
        [XmlEnum("22")]
        OLI_ATTACH_PRESCRIPTION_PROFILE = 22,

        /// <summary>Lab data</summary>
        /// <remarks>Data associated with this attachment contain the results of Lab work</remarks>
        [XmlEnum("23")]
        OLI_ATTACH_LABREPORT = 23,

        /// <summary>Inspection</summary>
        /// <remarks>Data associated with this attachment contain the results of an Inspection</remarks>
        [XmlEnum("24")]
        OLI_ATTACH_INSPECTION = 24,

        /// <summary>ACORD 701 - Life Application Part 1 Form</summary>
        [XmlEnum("54")]
        OLI_ATTACH_ACORD701 = 54,

        /// <summary>ACORD 702 - Life Application Part 2 Form</summary>
        [XmlEnum("55")]
        OLI_ATTACH_ACORD702 = 55,

        /// <summary>ACORD 703 - Medical Examiner's Report Form</summary>
        [XmlEnum("56")]
        OLI_ATTACH_ACORD703 = 56,

        /// <summary>ACORD 751 - Authorization to Obtain and Disclose Information Form</summary>
        [XmlEnum("57")]
        OLI_ATTACH_ACORD751 = 57,

        /// <summary>ACORD 752 - Certificate of Non-Illustration Form</summary>
        [XmlEnum("58")]
        OLI_ATTACH_ACORD752 = 58,

        /// <summary>ACORD 753 - Pre-Notice Form</summary>
        [XmlEnum("59")]
        OLI_ATTACH_ACORD753 = 59,

        /// <summary>ACORD 754 - Additional Other Proposed Insured Form</summary>
        [XmlEnum("60")]
        OLI_ATTACH_ACORD754 = 60,

        /// <summary>ACORD 755 - Additional Owners Form</summary>
        [XmlEnum("61")]
        OLI_ATTACH_ACORD755 = 61,

        /// <summary>ACORD 756 - Additional Beneficiaries Form</summary>
        [XmlEnum("62")]
        OLI_ATTACH_ACORD756 = 62,

        /// <summary>ACORD 757 - HIV Antibody / Antigen Consent and Testing Form</summary>
        [XmlEnum("63")]
        OLI_ATTACH_ACORD757 = 63,

        /// <summary>ACORD 758 - Producer Appointment Sheet Form</summary>
        [XmlEnum("64")]
        OLI_ATTACH_ACORD758 = 64,

        /// <summary>ACORD 759 - Important Notice Regarding Replacement Form</summary>
        [XmlEnum("65")]
        OLI_ATTACH_ACORD759 = 65,

        /// <summary>ACORD 761 - Policy Effective Date Supplement - Date of Policy Application Form</summary>
        [XmlEnum("66")]
        OLI_ATTACH_ACORD761 = 66,

        /// <summary>ACORD 762 - Policy Effective Date Supplement - Date of Policy Delivery Form</summary>
        [XmlEnum("67")]
        OLI_ATTACH_ACORD762 = 67,

        /// <summary>ACORD 763 - Policy Effective Date Supplement - Date Policy Issued Form</summary>
        [XmlEnum("68")]
        OLI_ATTACH_ACORD763 = 68,

        /// <summary>ACORD 764 - Fair Credit Reporting Act Disclosure Form</summary>
        [XmlEnum("69")]
        OLI_ATTACH_ACORD764 = 69,

        /// <summary>ACORD 765 - Agent's Report Form</summary>
        [XmlEnum("70")]
        OLI_ATTACH_ACORD765 = 70,

        /// <summary>ACORD 766 - Product Comparison Form</summary>
        [XmlEnum("71")]
        OLI_ATTACH_ACORD766 = 71,

        /// <summary>ACORD 767 - Temporary Insurance Agreement Form</summary>
        [XmlEnum("72")]
        OLI_ATTACH_ACORD767 = 72,

        /// <summary>ACORD 951 - 1035 Exchange / Rollover / Transfer Form</summary>
        [XmlEnum("73")]
        OLI_ATTACH_ACORD951 = 73,

        /// <summary>Footnote</summary>
        /// <remarks>Additional variable information applicable to correspondence. This is a specific part of a document.</remarks>
        [XmlEnum("78")]
        OLI_ATTACH_FOOTNOTE = 78,

        /// <summary>Producer Card (a.k.a. Agent Card)</summary>
        /// <remarks>Agent cards provide pertinent information about a policy for use in manual files.</remarks>
        [XmlEnum("79")]
        OLI_ATTACH_AGENTCARD = 79,

        /// <summary>Underwriter Work Sheet</summary>
        /// <remarks>The worksheet, sometimes called a data sheet, is a printout of all available information about the proposed insured and, in some companies pertinent information about the agent who submitted the application.</remarks>
        [XmlEnum("80")]
        OLI_ATTACH_UNDRWRTWKSHT = 80,

        /// <summary>Policy Summary</summary>
        /// <remarks>The policy summary is a document, that contains certain legally required data regarding the specific policy being considered by the applicant.  Such data includes premiums payable, benefits provided, cash values, and cost indexes.</remarks>
        [XmlEnum("81")]
        OLI_ATTACH_POLSUMMARY = 81,

        /// <summary>Specification Page</summary>
        /// <remarks>The specification page is a document that contains which contains high level information regarding the policy such as the plan name, amount of insurance, name and address of the primary insured.</remarks>
        [XmlEnum("82")]
        OLI_ATTACH_SPECIFICATIONPAGE = 82,

        /// <summary>Values Page</summary>
        /// <remarks>The Values page is specific to the type of policy and contains information regarding coverages, benefits, extra ratings, cash value, etc.</remarks>
        [XmlEnum("83")]
        OLI_ATTACH_VALUEPAGE = 83,

        /// <summary>Worksheet</summary>
        /// <remarks>Document providing  supporting details for another form, data element or calculation</remarks>
        [XmlEnum("97")]
        OLI_ATTACH_WRKSHT = 97,

        /// <summary>Conditional Receipt</summary>
        /// <remarks>A receipt given when a payment accompanies an application for insurance. It provides that the coverage will be in force from the date of application, provided the insurer would have issued the coverage on the basis of the facts revealed on the application, medical examination and other usual sources of underwriting.</remarks>
        [XmlEnum("98")]
        OLI_ATTACH_CONDRCPT = 98,

        /// <summary>Interim Conditional Receipt</summary>
        /// <remarks>A receipt given when a payment accompanies an application for insurance. It provides that the coverage will be in force from the date of application, provided the insurer would have issued the coverage on the basis of the facts revealed on the application, medical examination and other usual sources of underwriting.</remarks>
        [XmlEnum("99")]
        OLI_ATTACH_CONDRECPTINT = 99,

        /// <summary>Limited Insurance Agreement</summary>
        /// <remarks>An agreement providing that if all qualifications are met, coverage will be in force from the date of application, provided the insurer would have issued the coverage on the basis of the facts revealed on the application, medical examination and other usual sources of underwriting.</remarks>
        [XmlEnum("100")]
        OLI_ATTACH_LIA = 100,

        /// <summary>Non-Medical Exam</summary>
        /// <remarks>Document which captures results of examination performed by a paramedical examiner.</remarks>
        [XmlEnum("101")]
        OLI_ATTACH_NONMED = 101,

        /// <summary>Non-Medical Declaration</summary>
        /// <remarks>Statement of personal health, used in lieu of physical examination</remarks>
        [XmlEnum("102")]
        OLI_ATTACH_NONMEDDEC = 102,

        /// <summary>Paramed Exam</summary>
        /// <remarks>Document which captures results of examination performed by a paramedical examiner.</remarks>
        [XmlEnum("103")]
        OLI_ATTACH_PARAMED = 103,

        /// <summary>Signed Tele-med</summary>
        /// <remarks>Part B examination completed by tele-interviewer, signed</remarks>
        [XmlEnum("104")]
        OLI_ATTACH_TELMEDSGND = 104,

        /// <summary>Unsigned Tele-med</summary>
        /// <remarks>Part B examination completed by tele-interviewer, unsigned</remarks>
        [XmlEnum("105")]
        OLI_ATTACH_TELMEDUNSGND = 105,

        /// <summary>Other Exam Form</summary>
        /// <remarks>Carrier specific form used to capture results of an examination.</remarks>
        [XmlEnum("106")]
        OLI_ATTACH_EXAMFORM = 106,

        /// <summary>Replacement Form</summary>
        /// <remarks>State specific replacement form, which informs the applicant about the implications of using the policy being applied for to replace existing insurance.</remarks>
        [XmlEnum("107")]
        OLI_ATTACH_REPLF = 107,

        /// <summary>Disclosure</summary>
        /// <remarks>State specific form, which provides the applicant with specific insurance information that is required by the state.</remarks>
        [XmlEnum("108")]
        OLI_ATTACH_DISCLOSURE = 108,

        /// <summary>Transmittal</summary>
        /// <remarks>Coversheet attached to the insurance application, used as a tool to communicate information from the producer to the carrier.</remarks>
        [XmlEnum("109")]
        OLI_ATTACH_TRANSMITTAL = 109,

        /// <summary>Correspondence from General Agency</summary>
        /// <remarks>Document, other than a standardized form, used to communicate information from the General Agency to the Carrier.</remarks>
        [XmlEnum("110")]
        OLI_ATTACH_CORRFRMGA = 110,

        /// <summary>Correspondence from Agent</summary>
        /// <remarks>Document, other than a standardized form, used to communicate information from the Agent to the Carrier.</remarks>
        [XmlEnum("111")]
        OLI_ATTACH_CORRFRMAGT = 111,

        /// <summary>Correspondence to General Agency</summary>
        /// <remarks>Document sent by the Carrier to the General Agency.  Could be a form, form letter, custom business letter or ad hoc communication.</remarks>
        [XmlEnum("112")]
        OLI_ATTACH_CORRTOGA = 112,

        /// <summary>Correspondence to Agent</summary>
        /// <remarks>Document sent by the Carrier to the Agent.  Could be a form, form letter, custom business letter or ad hoc communication.</remarks>
        [XmlEnum("113")]
        OLI_ATTACH_CORRTOAGT = 113,

        /// <summary>Correspondence from Provider</summary>
        /// <remarks>Document sent by an insurance service provider to the Carrier.</remarks>
        [XmlEnum("114")]
        OLI_ATTACH_CORRFRMPROV = 114,

        /// <summary>Correspondence from Proposed Insured</summary>
        /// <remarks>Document sent by the Proposed Insured to the Carrier.</remarks>
        [XmlEnum("115")]
        OLI_ATTACH_CORRFRMPI = 115,

        /// <summary>Pre-Authorized Check (PAC) Correspondence</summary>
        /// <remarks>Document communicating information related to the authorization to withdraw funds.</remarks>
        [XmlEnum("116")]
        OLI_ATTACH_CORRPAC = 116,

        /// <summary>Resident Alien Card</summary>
        /// <remarks>Documentation that applicant is not a citizen but does have resident alien status</remarks>
        [XmlEnum("117")]
        OLI_ATTACH_RESALIENCD = 117,

        /// <summary>Remittance Log</summary>
        /// <remarks>Document, which accompanies one or more checks/financial records, used to list and describe the individual items</remarks>
        [XmlEnum("118")]
        OLI_ATTACH_REMITLOG = 118,

        /// <summary>Returned Check</summary>
        /// <remarks>Check that is being returned because it could not be accepted and/or processed</remarks>
        [XmlEnum("119")]
        OLI_ATTACH_RETURNCHK = 119,

        /// <summary>Pre-Authorized Check (PAC) Authorization</summary>
        /// <remarks>Authorization to withdraw funds from an account, which also provides the account detail.</remarks>
        [XmlEnum("120")]
        OLI_ATTACH_PACAUTH = 120,

        /// <summary>Pre-Authorized Check (PAC) Authorization/Voided Check</summary>
        /// <remarks>Authorization to withdraw funds from an account, which also provides the account detail.  Voided check for the account is attached to the authorization.</remarks>
        [XmlEnum("121")]
        OLI_ATTACH_PACAUTHVOID = 121,

        /// <summary>Premium Check - Initial Premium (COD)</summary>
        /// <remarks>Check providing for payment of on-going premium</remarks>
        [XmlEnum("122")]
        OLI_ATTACH_PREMCHK = 122,

        /// <summary>Electronic Funds Transfer (EFT) Form</summary>
        /// <remarks>Authorization to draft or deposit funds to an account electronically.</remarks>
        [XmlEnum("123")]
        OLI_ATTACH_EFTFORM = 123,

        /// <summary>Government Allotment</summary>
        /// <remarks>Document providing details for the use of funds taken from a government salary to pay premium</remarks>
        [XmlEnum("124")]
        OLI_ATTACH_GOVTALLOT = 124,

        /// <summary>Delivery Coversheet</summary>
        /// <remarks>Coversheet used as a tool to communicate information from the producer to the carrier, that is attached to a delivery requirement.</remarks>
        [XmlEnum("125")]
        OLI_ATTACH_DELVRYCOVER = 125,

        /// <summary>Policy Delivery Receipt</summary>
        /// <remarks>Document signed by policyowner indicating that they have received the policy contract.  Can also be signed by the agent.</remarks>
        [XmlEnum("126")]
        OLI_ATTACH_POLDELVRCPT = 126,

        /// <summary>Backdate Notice</summary>
        /// <remarks>Request that policy effective date be changed to an earlier date.  Primarily used to Save Age</remarks>
        [XmlEnum("127")]
        OLI_ATTACH_BACKDATE = 127,

        /// <summary>Returned Original Policy</summary>
        /// <remarks>Original policy contract that is being returned to the carrier.</remarks>
        [XmlEnum("128")]
        OLI_ATTACH_RETORIGPOL = 128,

        /// <summary>Health Statement</summary>
        /// <remarks>Document attesting to the continuing good health of the applicant.  Used either in lieu of a physical exam or when it has been a while since the original application was received.  Time interval is carrier specific.</remarks>
        [XmlEnum("129")]
        OLI_ATTACH_HLTHSTMNT = 129,

        /// <summary>Amendment</summary>
        /// <remarks>Document which amends the original terms of the application.</remarks>
        [XmlEnum("130")]
        OLI_ATTACH_AMEND = 130,

        /// <summary>Coronary Artery Disease Questionnaire/Supplement</summary>
        /// <remarks>Document used to gather more detailed information about applicant's coronary artery disease reported in the application</remarks>
        [XmlEnum("131")]
        OLI_ATTACH_QCORONARY = 131,

        /// <summary>Applicant Chest Pain Questionnaire/Supplement</summary>
        /// <remarks>Document used to gather more detailed information about applicant's chest pain reported in the application</remarks>
        [XmlEnum("132")]
        OLI_ATTACH_QCHESTPAIN = 132,

        /// <summary>Seizure Disorder Questionnaire/Supplement</summary>
        /// <remarks>Document used to gather more detailed information about applicant's seizure disorder reported in the application</remarks>
        [XmlEnum("133")]
        OLI_ATTACH_QSEIZURE = 133,

        /// <summary>Applicant Diabetic Questionnaire/Supplement</summary>
        /// <remarks>Document used to gather more detailed information about applicant's diabetes reported in the application</remarks>
        [XmlEnum("134")]
        OLI_ATTACH_QDIABETIC = 134,

        /// <summary>Alcohol Abuse Questionnaire/Supplement</summary>
        /// <remarks>Document used to gather more detailed information about applicant's use of alcohol reported in the application</remarks>
        [XmlEnum("135")]
        OLI_ATTACH_QALCOHOL = 135,

        /// <summary>Aviation Questionnaire/Supplement</summary>
        /// <remarks>Document used to gather more detailed information about applicant's participation in aviation reported in the application</remarks>
        [XmlEnum("136")]
        OLI_ATTACH_QAVIATION = 136,

        /// <summary>Tobacco Use Questionnaire/Supplement</summary>
        /// <remarks>Document used to gather more detailed information about applicant's use of tobacco reported in the application</remarks>
        [XmlEnum("137")]
        OLI_ATTACH_QTOBACCOUSE = 137,

        /// <summary>Underwater/Sky Sports Questionnaire/Supplement</summary>
        /// <remarks>Document used to gather more detailed information about applicant's participation in underwater or sky sports reported in the application</remarks>
        [XmlEnum("138")]
        OLI_ATTACH_QDIVESKYSPORT = 138,

        /// <summary>Racing Questionnaire/Supplement</summary>
        /// <remarks>Document used to gather more detailed information about applicant's racing experience reported in the application</remarks>
        [XmlEnum("139")]
        OLI_ATTACH_QRACING = 139,

        /// <summary>Business Insurance Questionnaire/Supplement</summary>
        /// <remarks>Document used to gather more detailed information when the insurance being applied for will be used for business purposes.</remarks>
        [XmlEnum("140")]
        OLI_ATTACH_QBUSINS = 140,

        /// <summary>Foreign Resident/Travel Questionnaire/Supplement</summary>
        /// <remarks>Document used to gather more detailed information about the applicant's non-citizen status and/or their intent to travel outside the US</remarks>
        [XmlEnum("141")]
        OLI_ATTACH_QFORTRAV = 141,

        /// <summary>Mountain/Rock/Ice Climbing Questionnaire/Supplement</summary>
        /// <remarks>Document used to gather more detailed information about applicant's participation in mountain, rock, or ice climbing activities reported in the application</remarks>
        [XmlEnum("142")]
        OLI_ATTACH_QCLIMB = 142,

        /// <summary>Resident Alien Questionnaire/Supplement</summary>
        /// <remarks>Document used to gather more detailed information about applicant's resident alien status.</remarks>
        [XmlEnum("143")]
        OLI_ATTACH_QRESALIEN = 143,

        /// <summary>Drug Use Questionnaire/Supplement</summary>
        /// <remarks>Document used to gather more detailed information about applicant's use of drugs reported in the application</remarks>
        [XmlEnum("144")]
        OLI_ATTACH_QDRUGUSE = 144,

        /// <summary>Lifestyle Questionnaire/Supplement</summary>
        /// <remarks>Document used to gather more detailed information about applicant's lifestyle</remarks>
        [XmlEnum("145")]
        OLI_ATTACH_QLIFESTYLE = 145,

        /// <summary>Financial Questionnaire</summary>
        /// <remarks>Document used to gather more information about the applicant's financial situation.</remarks>
        [XmlEnum("146")]
        OLI_ATTACH_QFINANCIAL = 146,

        /// <summary>Trust Agreement</summary>
        /// <remarks>Document provided details about trust agreement.</remarks>
        [XmlEnum("147")]
        OLI_ATTACH_TRUSTAGRMNT = 147,

        /// <summary>Income Statement</summary>
        /// <remarks>Personal or corporate income statement, used to determine relationship between applicant's financial situation and amount of insurance requested.</remarks>
        [XmlEnum("148")]
        OLI_ATTACH_INCSTMNT = 148,

        /// <summary>Financial Report - Personal</summary>
        /// <remarks>Personal financial report, used to determine relationship between applicant's financial situation and amount of insurance requested.</remarks>
        [XmlEnum("149")]
        OLI_ATTACH_FINRPTPERS = 149,

        /// <summary>Financial Report - Business</summary>
        /// <remarks>Personal or corporate income statement, used to determine relationship between applicant's financial situation and amount of insurance requested.</remarks>
        [XmlEnum("150")]
        OLI_ATTACH_FINRPTBUS = 150,

        /// <summary>1035 Paperwork</summary>
        /// <remarks>1035 Exchange Form, providing details of a replacement involving a transfer of funds between carriers.</remarks>
        [XmlEnum("151")]
        OLI_ATTACH_1035PAPERWK = 151,

        /// <summary>1035 Cost Basis</summary>
        [XmlEnum("152")]
        OLI_ATTACH_COSTBASIS = 152,

        /// <summary>1035 Exchange Memorandums</summary>
        [XmlEnum("153")]
        OLI_ATTACH_1035EXCHMEMO = 153,

        /// <summary>1035 Loan Transfer</summary>
        [XmlEnum("154")]
        OLI_ATTACH_1035RESQ = 154,

        /// <summary>1035 Minimum Deposit ResQ Worksheet</summary>
        [XmlEnum("155")]
        OLI_ATTACH_1035LOANTRAN = 155,

        /// <summary>1035 Letter/Check</summary>
        [XmlEnum("156")]
        OLI_ATTACH_1035LETTERCHK = 156,

        /// <summary>1035 Tax Advantage</summary>
        [XmlEnum("157")]
        OLI_ATTACH_1035TAXADV = 157,

        /// <summary>1099R</summary>
        /// <remarks>Tax Form</remarks>
        [XmlEnum("158")]
        OLI_ATTACH_TAX1099R = 158,

        /// <summary>5498</summary>
        /// <remarks>Tax Form</remarks>
        [XmlEnum("159")]
        OLI_ATTACH_TAX5498 = 159,

        /// <summary>W9</summary>
        /// <remarks>Tax Form</remarks>
        [XmlEnum("160")]
        OLI_ATTACH_TAXW9 = 160,

        /// <summary>Supplementary application - Child</summary>
        /// <remarks>Document providing application detail for a child applying for coverage as an Other Insured</remarks>
        [XmlEnum("161")]
        OLI_ATTACH_SUPPAPPCHLD = 161,

        /// <summary>Supplementary Application - Spouse</summary>
        /// <remarks>Document providing application detail for a spouse applying for coverage as an Other Insured</remarks>
        [XmlEnum("162")]
        OLI_ATTACH_SUPPAPPSPSE = 162,

        /// <summary>Attending Physician Statement</summary>
        /// <remarks>Details of an applicant's medical history, provided by a physician</remarks>
        [XmlEnum("163")]
        OLI_ATTACH_APSMD = 163,

        /// <summary>Pulmonary Function Tests</summary>
        /// <remarks>Results of tests performed to ascertain applicant's respiratory health.</remarks>
        [XmlEnum("164")]
        OLI_ATTACH_APSPULMONARY = 164,

        /// <summary>Blood Pressure Recheck</summary>
        /// <remarks>Additional blood pressure readings used to determine if abnormal results reflect a pattern or were an aberration</remarks>
        [XmlEnum("165")]
        OLI_ATTACH_APSBLDPRESS = 165,

        /// <summary>Agent Reimbursement for APS</summary>
        /// <remarks>Documents related to reimbursing an agent who has paid for an Attending Physician Statement</remarks>
        [XmlEnum("166")]
        OLI_ATTACH_APSAGTREIM = 166,

        /// <summary>Reports, Office and Hospital Records</summary>
        /// <remarks>Details of an applicant's medical history, provided by a health care provider other than a physician</remarks>
        [XmlEnum("167")]
        OLI_ATTACH_APSREPORT = 167,

        /// <summary>Blood & Urine Test Results, Electronic</summary>
        /// <remarks>Electronic results of tests performed on blood and urine specimens to ascertain the applicant's health.</remarks>
        [XmlEnum("168")]
        OLI_ATTACH_LABSBLDURINE = 168,

        /// <summary>Blood Test Results - Paper</summary>
        /// <remarks>Results of tests performed on a blood specimen to ascertain the applicant's health.</remarks>
        [XmlEnum("169")]
        OLI_ATTACH_LABSBLD = 169,

        /// <summary>Urine Test Results - Paper</summary>
        /// <remarks>Results of tests performed on a urine specimen to ascertain the applicant's health.</remarks>
        [XmlEnum("170")]
        OLI_ATTACH_LABSURINE = 170,

        /// <summary>EKG Tracing</summary>
        /// <remarks>Graphic results of electrocardiogram test performed to ascertain applicant's cardiac health</remarks>
        [XmlEnum("171")]
        OLI_ATTACH_EKGTRACE = 171,

        /// <summary>EKG Interpretation</summary>
        /// <remarks>Analysis of the results of electrocardiogram test performed to ascertain applicant's cardiac health</remarks>
        [XmlEnum("172")]
        OLI_ATTACH_EKGINTERP = 172,

        /// <summary>EKG Holter</summary>
        /// <remarks>Results of special portable electrocardiogram test performed to ascertain applicant's cardiac health</remarks>
        [XmlEnum("173")]
        OLI_ATTACH_EKGHOLTER = 173,

        /// <summary>X-ray Copy</summary>
        /// <remarks>Copy of x-ray film</remarks>
        [XmlEnum("174")]
        OLI_ATTACH_XCOPY = 174,

        /// <summary>X-ray Interpretation</summary>
        /// <remarks>Analysis of x-ray film</remarks>
        [XmlEnum("175")]
        OLI_ATTACH_XREPORT = 175,

        /// <summary>Driving Report</summary>
        [XmlEnum("176")]
        OLI_ATTACH_DRIVERPT = 176,

        /// <summary>Inspection Report - Personal</summary>
        [XmlEnum("177")]
        OLI_ATTACH_INSPPERS = 177,

        /// <summary>Inspection Report - Credit</summary>
        [XmlEnum("178")]
        OLI_ATTACH_INSPCREDIT = 178,

        /// <summary>Inspection Report - Business Beneficiary</summary>
        [XmlEnum("179")]
        OLI_ATTACH_INSPBUSBENE = 179,

        /// <summary>Cash with App</summary>
        [XmlEnum("180")]
        OLI_ATTACH_MONEYCWA = 180,

        /// <summary>Cash on Delivery Check</summary>
        [XmlEnum("181")]
        OLI_ATTACH_MONEYCOD = 181,

        /// <summary>Premium Check - Ongoing Premiums</summary>
        [XmlEnum("182")]
        OLI_ATTACH_MONEYPREMCHK = 182,

        /// <summary>Void Check</summary>
        [XmlEnum("183")]
        OLI_ATTACH_MONEYVOID = 183,

        /// <summary>Bank Correspondence</summary>
        [XmlEnum("184")]
        OLI_ATTACH_MONEYBANK = 184,

        /// <summary>In-Force Non-Financial Transaction</summary>
        [XmlEnum("185")]
        OLI_ATTACH_POSNONFIN = 185,

        /// <summary>In-Force Non-Financial Change</summary>
        [XmlEnum("186")]
        OLI_ATTACH_POSNONFINCHNG = 186,

        /// <summary>In-Force Servicing Agent Change</summary>
        [XmlEnum("187")]
        OLI_ATTACH_POSSERVAGTCHNG = 187,

        /// <summary>In-Force Owner Change</summary>
        [XmlEnum("188")]
        OLI_ATTACH_POSOWNCHNG = 188,

        /// <summary>In-Force Beneficiary Change</summary>
        [XmlEnum("189")]
        OLI_ATTACH_POSBENECHNG = 189,

        /// <summary>In-Force Name Change</summary>
        [XmlEnum("190")]
        OLI_ATTACH_POSNAMECHNG = 190,

        /// <summary>In-Force Premium Change</summary>
        [XmlEnum("191")]
        OLI_ATTACH_POSPREMCHNG = 191,

        /// <summary>In-Force Audit Request</summary>
        [XmlEnum("192")]
        OLI_ATTACH_POSAUDREQ = 192,

        /// <summary>In-Force Complex Transaction</summary>
        [XmlEnum("193")]
        OLI_ATTACH_POSCOMLPEXTRAN = 193,

        /// <summary>In-Force Duplicate Policy Request</summary>
        [XmlEnum("194")]
        OLI_ATTACH_POSDUPPOL = 194,

        /// <summary>In-Force Reissue</summary>
        [XmlEnum("195")]
        OLI_ATTACH_POSREISS = 195,

        /// <summary>In-Force Conversion</summary>
        [XmlEnum("196")]
        OLI_ATTACH_POSCONVERT = 196,

        /// <summary>In-Force Face Amount Change</summary>
        [XmlEnum("197")]
        OLI_ATTACH_POSFACECHNG = 197,

        /// <summary>In-Force Amendment</summary>
        [XmlEnum("198")]
        OLI_ATTACH_POSAMEND = 198,

        /// <summary>In-Force Rate Reduction</summary>
        [XmlEnum("199")]
        OLI_ATTACH_POSRATERED = 199,

        /// <summary>In-Force Rider Change</summary>
        [XmlEnum("200")]
        OLI_ATTACH_POSRIDERCHNG = 200,

        /// <summary>In-Force Address Change</summary>
        [XmlEnum("201")]
        OLI_ATTACH_POSADDRCHNG = 201,

        /// <summary>In-Force Reinstatement Request</summary>
        [XmlEnum("202")]
        OLI_ATTACH_POSREINSTATE = 202,

        /// <summary>Disbursement - Surrender</summary>
        [XmlEnum("203")]
        OLI_ATTACH_DISBSURR = 203,

        /// <summary>Disbursement - Withdrawal</summary>
        [XmlEnum("204")]
        OLI_ATTACH_DISBWITHDRAW = 204,

        /// <summary>Disbursement Forms</summary>
        [XmlEnum("205")]
        OLI_ATTACH_DISBDISB = 205,

        /// <summary>Disbursement - PUA Surrender</summary>
        [XmlEnum("206")]
        OLI_ATTACH_DISBPUASURR = 206,

        /// <summary>Disbursement - Loan</summary>
        [XmlEnum("207")]
        OLI_ATTACH_DISBLOAN = 207,

        /// <summary>Dividend Forms</summary>
        [XmlEnum("208")]
        OLI_ATTACH_DISBDIV = 208,

        /// <summary>Death Claim</summary>
        [XmlEnum("209")]
        OLI_ATTACH_DISBDEATHCLAIM = 209,

        /// <summary>Cancellation</summary>
        [XmlEnum("210")]
        OLI_ATTACH_DISBCANCEL = 210,

        /// <summary>1035 Surrender</summary>
        [XmlEnum("211")]
        OLI_ATTACH_DISB1035SURR = 211,

        /// <summary>Not Taken Option</summary>
        [XmlEnum("212")]
        OLI_ATTACH_DISBNTO = 212,

        /// <summary>Appointment Copy in non pre-appointment states</summary>
        [XmlEnum("213")]
        OLI_ATTACH_APPTLICENSE = 213,

        /// <summary>Appointment - Broker Authorization</summary>
        [XmlEnum("214")]
        OLI_ATTACH_APPTBROKER = 214,

        /// <summary>Appointment - Authorization to Disclose</summary>
        [XmlEnum("215")]
        OLI_ATTACH_APPTDISCLOSE = 215,

        /// <summary>Appointment - Producer Information Form</summary>
        [XmlEnum("216")]
        OLI_ATTACH_APPTPRODUCER = 216,

        /// <summary>Appointment - General Correspondence</summary>
        [XmlEnum("217")]
        OLI_ATTACH_APPTGENCORR = 217,

        /// <summary>Appointment Documents for pre-appointment states</summary>
        [XmlEnum("218")]
        OLI_ATTACH_APPTPREAPPT = 218,

        /// <summary>Appointment E & O</summary>
        [XmlEnum("219")]
        OLI_ATTACH_APPTEO = 219,

        /// <summary>License Copy in non pre-appointment states</summary>
        [XmlEnum("220")]
        OLI_ATTACH_LICLICENSE = 220,

        /// <summary>Broker Authorization</summary>
        /// <remarks>Broker's authorization to the carrier, indicating their approval to proceed with the Licensing & Appointing process</remarks>
        [XmlEnum("221")]
        OLI_ATTACH_LICBRKERAUTH = 221,

        /// <summary>Licensing Broker Authorization</summary>
        [XmlEnum("222")]
        OLI_ATTACH_LICDISCAUTH = 222,

        /// <summary>Licensing Authorization to Disclose</summary>
        [XmlEnum("223")]
        OLI_ATTACH_LICPRODUCER = 223,

        /// <summary>Licensing - General Correspondence</summary>
        [XmlEnum("224")]
        OLI_ATTACH_LICGENCORR = 224,

        /// <summary>Licensing - Documents for pre-appointment states</summary>
        [XmlEnum("225")]
        OLI_ATTACH_LICPREAPPT = 225,

        /// <summary>Assignment - absolute</summary>
        [XmlEnum("226")]
        OLI_ATTACH_ASSIGNABS = 226,

        /// <summary>Assignment - Release</summary>
        [XmlEnum("227")]
        OLI_ATTACH_ASSIGNREL = 227,

        /// <summary>Assignment - Collateral</summary>
        [XmlEnum("228")]
        OLI_ATTACH_ASSIGNCOLL = 228,

        /// <summary>Assignment of Commissions</summary>
        [XmlEnum("229")]
        OLI_ATTACH_COMMASSIGN = 229,

        /// <summary>Release of Commission Assignment</summary>
        [XmlEnum("230")]
        OLI_ATTACH_COMMREL = 230,

        /// <summary>Commission Split</summary>
        [XmlEnum("231")]
        OLI_ATTACH_COMMSPLIT = 231,

        /// <summary>Commission Agreement - NAILBA</summary>
        [XmlEnum("232")]
        OLI_ATTACH_COMMAGREEMNT = 232,

        /// <summary>Commission Schedule</summary>
        [XmlEnum("233")]
        OLI_ATTACH_COMMSCHED = 233,

        /// <summary>Commission, Single Case Agreement</summary>
        [XmlEnum("234")]
        OLI_ATTACH_COMMSCA = 234,

        /// <summary>Commission Statement</summary>
        [XmlEnum("235")]
        OLI_ATTACH_COMMSTATEMNT = 235,

        /// <summary>Agency/Agent Contract Maintenance</summary>
        [XmlEnum("236")]
        OLI_ATTACH_AGCONTMAINT = 236,

        /// <summary>Agency/Agent Termination</summary>
        [XmlEnum("237")]
        OLI_ATTACH_AGTERM = 237,

        /// <summary>AgencyAgent License Maintenance</summary>
        [XmlEnum("238")]
        OLI_ATTACH_AGLICMAINT = 238,

        /// <summary>Authorization</summary>
        /// <remarks>When electronically ordering certain types of reports, a signed authorization form is required (in order to allow the service provider to obtain the requested information from the health care provider or similar source).  There is a need to be able to attach an image of a signed authorization form to a 121 General Requirement Order transaction when ordering services that require such an authorization.</remarks>
        [XmlEnum("239")]
        OLI_ATTACH_AUTH = 239,

        /// <summary>Investigator Report</summary>
        /// <remarks>Provides additional details about a claimant if the claimant is under investigation which can influence the outcome of a case.</remarks>
        [XmlEnum("240")]
        OLI_ATTACH_INVESTIGATOR = 240,

        /// <summary>Independent Medical Examiner Report</summary>
        /// <remarks>A report that is completed by a Medical Examiner, by the request of the insurance carrier.  The Medical Examiner has no prior relationship with the insured.  The insurance company .Report requested by the insurance company of an independent medical examiner for a claim.  This document that contains information regarding a specified disability or condition with regards to a claim.  This is a common requested report for claims that are long term or life long disabilities.</remarks>
        [XmlEnum("241")]
        OLI_ATTACH_INDEPDENTMEDEXAMNER = 241,

        /// <summary>Claim Financial Investigation</summary>
        /// <remarks>This contains additional financial details that were required for the case.  This document is used to verify the financial loss (Income Loss)  to a disabled insured.</remarks>
        [XmlEnum("242")]
        OLI_ATTACH_FINANCIALINVESTIG = 242,

        /// <summary>Autopsy Report</summary>
        /// <remarks>A report which includes the details of the post-mortem examination.  This report includes cause of death and factors related to the cause of death.  It is used in claim processing when there are unusual circumstances surrounding the insured's death; additional death benefits such as accidental death benefits may be payable; \or when the death of the insured occurs during the policy contestable period.</remarks>
        [XmlEnum("243")]
        OLI_ATTACH_AUTOPSY = 243,

        /// <summary>MIB Update Data</summary>
        /// <remarks>Data associated with this attachment contain the results of an MIB Update</remarks>
        [XmlEnum("244")]
        OLI_ATTACH_MIB402 = 244,

        /// <summary>Requirements Request</summary>
        /// <remarks>Data associated with this attachment contain the information  of an Requirement request</remarks>
        [XmlEnum("245")]
        OLI_ATTACH_REQUIREREQUEST = 245,

        /// <summary>Requirement Result.</summary>
        /// <remarks>Data associated with this attachment contain the results of a Requirement Result.</remarks>
        [XmlEnum("246")]
        OLI_ATTACH_REQUIRERESULTS = 246,

        /// <summary>Itemized Bill</summary>
        /// <remarks>The attachment contains an itemized bill.</remarks>
        [XmlEnum("248")]
        OLI_ATTACH_ITEMBILL = 248,

        /// <summary>Internal Communication</summary>
        /// <remarks>Communications and information for use by carrier and distributor staff including agents, but not customers/clients.</remarks>
        [XmlEnum("249")]
        OLI_ATTACH_INTERNAL = 249,

        /// <summary>Instructions/Reminders</summary>
        /// <remarks>Instructions such as those relating to a product or benefit.   Example: "Provide a cancelled check not a deposit slip." Typically the "how" information.</remarks>
        [XmlEnum("250")]
        OLI_ATTACH_INSTREMIND = 250,

        /// <summary>Publicly Disclosable Information</summary>
        /// <remarks>Information such as that relating to product features, benefits, constraints and costs. Example: "This spousal protection rider provides continued benefits after the death of the primary annuitant."  Typically “why and what” information.  This information may be printed/viewed/displayed to a customer.</remarks>
        [XmlEnum("251")]
        OLI_ATTACH_INFO = 251,

        /// <summary>Preliminary Application</summary>
        /// <remarks>A means of collecting basic information about the client and the policy being applied for, allowing the producer to initiate the new business process.  The full application is completed after the new business process has begun.</remarks>
        [XmlEnum("252")]
        OLI_ATTACH_PRELIMAPP = 252,

        /// <summary>Carrier Specific Application</summary>
        /// <remarks>Application that is specific to a carrier who is not using the ACORD generic application</remarks>
        [XmlEnum("253")]
        OLI_ATTACH_CARRIERAPP = 253,

        /// <summary>Mini Mental State Exam Form</summary>
        /// <remarks>A form that is completed by a trained clinician in evaluating a patient and providing such information as orientation, immediate recall, attention, delayed verbal recall, naming, stage command, reading, writing and sentence language.</remarks>
        [XmlEnum("254")]
        OLI_ATTACH_MMNTALSTEX = 254,

        /// <summary>Short Portable Mental Status Questionnaire</summary>
        /// <remarks>A short portable mental status questionnaire for the assessment of organic brain deficit in elderly patients. This is commonly known as SPMSQ.</remarks>
        [XmlEnum("255")]
        OLI_ATTACH_SPMSQ = 255,

        /// <summary>Lost Policy Affidavid</summary>
        /// <remarks>An attestation that client has lost the original policy for the contract being surrendered for a replacement.</remarks>
        [XmlEnum("256")]
        OLI_ATTACH_LOSTPOL = 256,

        /// <summary>New York Reg 60 Form Appendix 10A</summary>
        /// <remarks>A replacement  form necessary to comply with New York Reg 60</remarks>
        [XmlEnum("257")]
        OLI_ATTACH_APPEN10A = 257,

        /// <summary>New York Reg 60 Form Appendix 10B</summary>
        /// <remarks>A replacement  form necessary to comply with New York Reg 60</remarks>
        [XmlEnum("258")]
        OLI_ATTACH_APPEN10B = 258,

        /// <summary>New York Reg 60 Form Appendix 10C</summary>
        /// <remarks>A replacement  form necessary to comply with New York Reg 60</remarks>
        [XmlEnum("259")]
        OLI_ATTACH_APPEN10C = 259,

        /// <summary>Inspection Reason</summary>
        /// <remarks>Attachment contains information derived from an inspection report that might be used as reasons for modifying or rejecting a policy. This information is typically used for Fair Credit letters.</remarks>
        [XmlEnum("260")]
        OLI_ATTACH_INSPREASON = 260,

        /// <summary>Non-Inspection Reason</summary>
        /// <remarks>Attachment contains information derived from sources other than an inspection report that might be used as reasons for modifying or rejecting a policy. This information is typically used for Fair Credit letters.</remarks>
        [XmlEnum("261")]
        OLI_ATTACH_NONINSPREASON = 261,

        /// <summary>SEC N-4 Sec Registration Narrative Explanation</summary>
        /// <remarks>Footnote or other explanatory narrative further describing an element's context, meaning or use.</remarks>
        [XmlEnum("262")]
        OLI_ATTACH_SECN_4 = 262,

        /// <summary>Marketing Objective</summary>
        [XmlEnum("263")]
        OLI_ATTACH_MKTGOBJECTIVE = 263,

        /// <summary>General description</summary>
        [XmlEnum("264")]
        OLI_ATTACH_GENDESC = 264,

        /// <summary>Assumptions</summary>
        [XmlEnum("265")]
        OLI_ATTACH_ASSUMPTIONS = 265,

        /// <summary>Benchmarking/Survey Results</summary>
        [XmlEnum("266")]
        OLI_ATTACH_BENCHMARK = 266,

        /// <summary>Benefit Summary/SPD</summary>
        /// <remarks>Benefit Summary or Summary Plan Description (SPD)</remarks>
        [XmlEnum("267")]
        OLI_ATTACH_BENESUMM = 267,

        /// <summary>Broker of Record Letter</summary>
        [XmlEnum("268")]
        OLI_ATTACH_BROKER = 268,

        /// <summary>Budget Information</summary>
        [XmlEnum("269")]
        OLI_ATTACH_BUDGET = 269,

        /// <summary>Carrier Contact Information</summary>
        [XmlEnum("270")]
        OLI_ATTACH_CARRIERCONT = 270,

        /// <summary>Carrier Form</summary>
        [XmlEnum("271")]
        OLI_ATTACH_CARRIERFORM = 271,

        /// <summary>Carrier Invoice</summary>
        [XmlEnum("272")]
        OLI_ATTACH_CARRIERINV = 272,

        /// <summary>Census</summary>
        [XmlEnum("273")]
        OLI_ATTACH_CENSUS = 273,

        /// <summary>Census - Ancillary</summary>
        [XmlEnum("274")]
        OLI_ATTACH_CENSUSANC = 274,

        /// <summary>Census - Medical</summary>
        [XmlEnum("275")]
        OLI_ATTACH_CENSUSMED = 275,

        /// <summary>Claims</summary>
        [XmlEnum("276")]
        OLI_ATTACH_CLAIMS = 276,

        /// <summary>Commission Agreement - ACORD 785</summary>
        [XmlEnum("277")]
        OLI_ATTACH_COMMAGREE = 277,

        /// <summary>Compliance</summary>
        [XmlEnum("278")]
        OLI_ATTACH_COMPLIANCE = 278,

        /// <summary>Completed Census Data</summary>
        [XmlEnum("279")]
        OLI_ATTACH_CENSUSDATA = 279,

        /// <summary>Completed Proposal Form</summary>
        [XmlEnum("280")]
        OLI_ATTACH_PROPOSAL = 280,

        /// <summary>Confirmation of Agreements</summary>
        [XmlEnum("281")]
        OLI_ATTACH_CONFAGREE = 281,

        /// <summary>Confirmation Statement</summary>
        [XmlEnum("282")]
        OLI_ATTACH_CONFSTATE = 282,

        /// <summary>Consulting Agreement</summary>
        [XmlEnum("283")]
        OLI_ATTACH_CONSULAGREE = 283,

        /// <summary>Contract</summary>
        [XmlEnum("284")]
        OLI_ATTACH_CONTRACT = 284,

        /// <summary>Contributions/Pricing</summary>
        [XmlEnum("285")]
        OLI_ATTACH_CONTRIBUT = 285,

        /// <summary>Correspondence</summary>
        /// <remarks>This is a general attachment for generic correspondence where no further specificity is known.</remarks>
        [XmlEnum("286")]
        OLI_ATTACH_CORRESP = 286,

        /// <summary>Disruption Report for Current Carrier</summary>
        [XmlEnum("287")]
        OLI_ATTACH_DISRUPTRP = 287,

        /// <summary>Due Diligence</summary>
        [XmlEnum("288")]
        OLI_ATTACH_DUEDIL = 288,

        /// <summary>Eligibility</summary>
        [XmlEnum("289")]
        OLI_ATTACH_ELIGIBL = 289,

        /// <summary>Employee Communication Materials</summary>
        [XmlEnum("290")]
        OLI_ATTACH_EMPLOCOM = 290,

        /// <summary>Executive Report</summary>
        [XmlEnum("291")]
        OLI_ATTACH_EXECRP = 291,

        /// <summary>Experience Information</summary>
        [XmlEnum("292")]
        OLI_ATTACH_EXPINFO = 292,

        /// <summary>Experience/Plan Utilization</summary>
        [XmlEnum("293")]
        OLI_ATTACH_EXPPLAN = 293,

        /// <summary>FASB Study</summary>
        /// <remarks>Financial Accounting Standards Board (FASB)</remarks>
        [XmlEnum("294")]
        OLI_ATTACH_FASB = 294,

        /// <summary>Form 5500</summary>
        /// <remarks>Form 5500 Annual Return/Report of Employee Benefit Plan - jointly developed by the Department of Labor, Internal Revenue Service, and the Pension Benefit Guaranty Corporation.</remarks>
        [XmlEnum("295")]
        OLI_ATTACH_F5500 = 295,

        /// <summary>Implementation</summary>
        [XmlEnum("296")]
        OLI_ATTACH_IMPLEM = 296,

        /// <summary>Issue Log</summary>
        [XmlEnum("297")]
        OLI_ATTACH_ISSUELOG = 297,

        /// <summary>Letter of Authorization</summary>
        [XmlEnum("298")]
        OLI_ATTACH_LTRAUTH = 298,

        /// <summary>Marketing Materials</summary>
        [XmlEnum("299")]
        OLI_ATTACH_MARKMAT = 299,

        /// <summary>Marketing Strategy Letter</summary>
        [XmlEnum("300")]
        OLI_ATTACH_MARKSTRAT = 300,

        /// <summary>Meeting/Call Notes</summary>
        [XmlEnum("301")]
        OLI_ATTACH_CALLNOTES = 301,

        /// <summary>Open Enrollment</summary>
        [XmlEnum("302")]
        OLI_ATTACH_OPENENROLL = 302,

        /// <summary>Plan History</summary>
        [XmlEnum("303")]
        OLI_ATTACH_PLANHIST = 303,

        /// <summary>Premium Report</summary>
        [XmlEnum("304")]
        OLI_ATTACH_PREMIUM = 304,

        /// <summary>Presentation</summary>
        [XmlEnum("305")]
        OLI_ATTACH_PRESENT = 305,

        /// <summary>Product Criteria Form</summary>
        [XmlEnum("306")]
        OLI_ATTACH_PRODUCT = 306,

        /// <summary>Proposal Information</summary>
        [XmlEnum("307")]
        OLI_ATTACH_PROPOSAL_INFO = 307,

        /// <summary>Provider/Network Information</summary>
        [XmlEnum("308")]
        OLI_ATTACH_PROVIDER = 308,

        /// <summary>Questionnaire</summary>
        [XmlEnum("309")]
        OLI_ATTACH_QUEST = 309,

        /// <summary>Rate History</summary>
        [XmlEnum("310")]
        OLI_ATTACH_RATEHIST = 310,

        /// <summary>Rate/Financial Information</summary>
        [XmlEnum("311")]
        OLI_ATTACH_RATEINFO = 311,

        /// <summary>Renewal Notification</summary>
        [XmlEnum("312")]
        OLI_ATTACH_RENEWAL = 312,

        /// <summary>RFP Instructions</summary>
        /// <remarks>Request for Proposal Instructions</remarks>
        [XmlEnum("313")]
        OLI_ATTACH_RFP = 313,

        /// <summary>Service Level Agreement</summary>
        [XmlEnum("314")]
        OLI_ATTACH_SERVICELVL = 314,

        /// <summary>Strategic Planning</summary>
        [XmlEnum("315")]
        OLI_ATTACH_STRATIGIC = 315,

        /// <summary>Summary Plan Description</summary>
        [XmlEnum("316")]
        OLI_ATTACH_SUMMPLAN = 316,

        /// <summary>Transparency Disclosure Form</summary>
        [XmlEnum("317")]
        OLI_ATTACH_TRNASDISC = 317,

        /// <summary>Union Contract/Agreement</summary>
        [XmlEnum("318")]
        OLI_ATTACH_UNIONCON = 318,

        /// <summary>Workflow</summary>
        [XmlEnum("319")]
        OLI_ATTACH_WORKFLOW = 319,

        /// <summary>Applications/Enrollment Form</summary>
        [XmlEnum("320")]
        OLI_ATTACH_APPENROLL = 320,

        /// <summary>Instruction in Event of Deviation from RFP</summary>
        /// <remarks>Instruction in Event of Deviation from Request for Proposal</remarks>
        [XmlEnum("321")]
        OLI_ATTACH_DEVIATERFP = 321,

        /// <summary>Conditions</summary>
        [XmlEnum("322")]
        OLI_ATTACH_CONDITIONS = 322,

        /// <summary>Qualifications</summary>
        [XmlEnum("323")]
        OLI_ATTACH_QUALIF = 323,

        /// <summary>Pre-Tax Section 125 / Other Tax Considerations</summary>
        /// <remarks>IRC - Section 125 plans your employees are able to pay for eligible fringe benefits with "pre-tax" income</remarks>
        [XmlEnum("324")]
        OLI_ATTACH_TAX125 = 324,

        /// <summary>Examiner Note</summary>
        /// <remarks>Note with instructions or additional information for the medical examiner.</remarks>
        [XmlEnum("325")]
        OLI_ATTACH_EXAMINERNOTE = 325,

        /// <summary>Teleinterview Note</summary>
        /// <remarks>Note with instructions or additional information for the teleinterviewer.</remarks>
        [XmlEnum("326")]
        OLI_ATTACH_TELEINTERVIEWNOTE = 326,

        /// <summary>Personal History Interview</summary>
        /// <remarks>The Attachment is the result of a request for the results of the Personal History Interview</remarks>
        [XmlEnum("327")]
        OLI_ATTACH_PERSHISTINTERVIEW = 327,

        /// <summary>Face to Face Assessment</summary>
        /// <remarks>The Attachment is the result of a request for the results of the Face to Face Assessment</remarks>
        [XmlEnum("328")]
        OLI_ATTACH_FACETOFACE = 328,

        /// <summary>Home Office Specimen</summary>
        /// <remarks>The Attachment is the result of a request for the analytic results of the Home Office Specimen</remarks>
        [XmlEnum("329")]
        OLI_ATTACH_HOS = 329,

        /// <summary>Instructions - Underwriting</summary>
        [XmlEnum("330")]
        OLI_ATTACH_ISSINSTUND = 330,

        /// <summary>Instructions - Settlement Options</summary>
        [XmlEnum("331")]
        OLI_ATTACH_ISSINSTSETTL = 331,

        /// <summary>Instructions - Term Conversion</summary>
        [XmlEnum("332")]
        OLI_ATTACH_ISSINSTTERMCV = 332,

        /// <summary>Insurance Verification Letter</summary>
        /// <remarks>This attachmentthat is a form sent by the carrier to a requesting entity which verifies that the party or parties who requested this letter are covered by an insurance policy issued by the carrier</remarks>
        [XmlEnum("333")]
        OLI_ATTACH_INSVER = 333,

        /// <summary>Application - Alternate Life Insurance Plan</summary>
        [XmlEnum("334")]
        OLI_ATTACH_ALTLIFEAPP = 334,

        /// <summary>Application - Credit / Loan</summary>
        [XmlEnum("335")]
        OLI_ATTACH_CREDITAPP = 335,

        /// <summary>Application - Group</summary>
        [XmlEnum("336")]
        OLI_ATTACH_GROUPAPP = 336,

        /// <summary>Application - Health Coverage</summary>
        [XmlEnum("337")]
        OLI_ATTACH_HEALTHAPP = 337,

        /// <summary>Application - Nominee Account</summary>
        [XmlEnum("338")]
        OLI_ATTACH_NAAPP = 338,

        /// <summary>Application - Payout Annuity</summary>
        [XmlEnum("339")]
        OLI_ATTACH_PAYANNUAPP = 339,

        /// <summary>Application - Policy Change</summary>
        [XmlEnum("340")]
        OLI_ATTACH_POLCHGAPP = 340,

        /// <summary>Application - Signature Page</summary>
        [XmlEnum("341")]
        OLI_ATTACH_SIGNATUREAPP = 341,

        /// <summary>Application - Social Insurance Number (SIN)</summary>
        [XmlEnum("342")]
        OLI_ATTACH_SINAPP = 342,

        /// <summary>Authorization - Credit Card</summary>
        [XmlEnum("343")]
        OLI_ATTACH_CREDCARDAUTH = 343,

        /// <summary>Authorization - Motor Vehicle Report</summary>
        [XmlEnum("344")]
        OLI_ATTACH_MOTORVEHREP = 344,

        /// <summary>Authorization - Obtain / Release Information</summary>
        [XmlEnum("345")]
        OLI_ATTACH_RELINFO = 345,

        /// <summary>Authorization for Non-Resident Tax Exemption</summary>
        [XmlEnum("346")]
        OLI_ATTACH_NRTAXA = 346,

        /// <summary>Claim - Additional Claimants</summary>
        [XmlEnum("347")]
        OLI_ATTACH_ADDCLS = 347,

        /// <summary>Claim - Claimant Statement</summary>
        [XmlEnum("348")]
        OLI_ATTACH_CLAIMSTAT = 348,

        /// <summary>Claim - Critical Illness</summary>
        [XmlEnum("349")]
        OLI_ATTACH_CRITICALILLNESS = 349,

        /// <summary>Claim - Declaration / Proof of Death</summary>
        [XmlEnum("350")]
        OLI_ATTACH_DEATHDEC = 350,

        /// <summary>Claim - Drug Employee Reimbursement</summary>
        [XmlEnum("351")]
        OLI_ATTACH_DRUGEMPLCL = 351,

        /// <summary>Claim - Foreign</summary>
        [XmlEnum("352")]
        OLI_ATTACH_FORIEGNCL = 352,

        /// <summary>Claim - Healthcare Expenses</summary>
        [XmlEnum("353")]
        OLI_ATTACH_HEALTHCARE = 353,

        /// <summary>Claim - Requirements</summary>
        [XmlEnum("354")]
        OLI_ATTACH_REQUIREMENTS = 354,

        /// <summary>Client Identification - Birth Certificate</summary>
        [XmlEnum("355")]
        OLI_ATTACH_BIRTHCERT = 355,

        /// <summary>Client Identification - Driver's License</summary>
        [XmlEnum("356")]
        OLI_ATTACH_DRIVERSLIC = 356,

        /// <summary>Client Identification - Passport</summary>
        [XmlEnum("357")]
        OLI_ATTACH_PASSPORT = 357,

        /// <summary>Client Identification - Work Permit</summary>
        [XmlEnum("358")]
        OLI_ATTACH_WORKPERMIT = 358,

        /// <summary>Contracting - Application</summary>
        [XmlEnum("359")]
        OLI_ATTACH_CONTRAPP = 359,

        /// <summary>Contracting - Bonus</summary>
        [XmlEnum("360")]
        OLI_ATTACH_BONUS = 360,

        /// <summary>Contracting - Broker is a Business Entity</summary>
        [XmlEnum("361")]
        OLI_ATTACH_CORPENTITY = 361,

        /// <summary>Contracting - Cancellation / Termination</summary>
        [XmlEnum("362")]
        OLI_ATTACH_TERMINATION = 362,

        /// <summary>Contracting - Code of Conduct</summary>
        [XmlEnum("363")]
        OLI_ATTACH_CODEOFCOND = 363,

        /// <summary>Contracting - E&O Certificate</summary>
        [XmlEnum("364")]
        OLI_ATTACH_EOCERT = 364,

        /// <summary>Education Savings - Grant (CESG)</summary>
        [XmlEnum("365")]
        OLI_ATTACH_CESG = 365,

        /// <summary>Education Savings - Investment Application</summary>
        [XmlEnum("366")]
        OLI_ATTACH_INVESTMENTAPP = 366,

        /// <summary>Education Savings - Tax</summary>
        [XmlEnum("367")]
        OLI_ATTACH_TAXEDUSAV = 367,

        /// <summary>Financial - Bank Estate</summary>
        [XmlEnum("368")]
        OLI_ATTACH_BANKESTATE = 368,

        /// <summary>Financial - Business Coverage</summary>
        [XmlEnum("369")]
        OLI_ATTACH_BUSCOV = 369,

        /// <summary>Financial - Business Entity</summary>
        [XmlEnum("370")]
        OLI_ATTACH_BUSINESSENTITY = 370,

        /// <summary>Financial - Buy/Sell Agreement Request/Requirement</summary>
        /// <remarks>Financial - Buy / Sell Agreement Request / Requirements</remarks>
        [XmlEnum("371")]
        OLI_ATTACH_BSR = 371,

        /// <summary>Financial - Confidential Business Questionnaire</summary>
        [XmlEnum("372")]
        OLI_ATTACH_CONFIDENTIALQ = 372,

        /// <summary>Financial - Divorce / Separation Agreement</summary>
        [XmlEnum("373")]
        OLI_ATTACH_DIVORCEAGR = 373,

        /// <summary>Financial - Estate Planning</summary>
        [XmlEnum("374")]
        OLI_ATTACH_ESTATEPLANF = 374,

        /// <summary>Financial - Gifted Property</summary>
        [XmlEnum("375")]
        OLI_ATTACH_GIFTEDPROP = 375,

        /// <summary>Financial - Hardship</summary>
        [XmlEnum("376")]
        OLI_ATTACH_HARDSHIP = 376,

        /// <summary>Financial - Personal Statement</summary>
        [XmlEnum("377")]
        OLI_ATTACH_PERSONALSTAT = 377,

        /// <summary>Financial - Proposed Insured</summary>
        [XmlEnum("378")]
        OLI_ATTACH_PROPOSEDINS = 378,

        /// <summary>Financial - Trust for a Minor</summary>
        [XmlEnum("379")]
        OLI_ATTACH_TRUSTMINOR = 379,

        /// <summary>Financial - Will</summary>
        [XmlEnum("380")]
        OLI_ATTACH_WILL = 380,

        /// <summary>Group - Employee Data Listing</summary>
        [XmlEnum("381")]
        OLI_ATTACH_EMPDATLIST = 381,

        /// <summary>Group - Forfeiture of Benefits</summary>
        [XmlEnum("382")]
        OLI_ATTACH_FORFEITURE = 382,

        /// <summary>Guaranteed Insurability Election Admin Rules</summary>
        /// <remarks>Guaranteed Insurability Election Administrative Rules</remarks>
        [XmlEnum("383")]
        OLI_ATTACH_ELETIONADRULES = 383,

        /// <summary>Information - Product Page</summary>
        [XmlEnum("384")]
        OLI_ATTACH_PRODUCTOPAGE = 384,

        /// <summary>Legal</summary>
        [XmlEnum("385")]
        OLI_ATTACH_LEGAL = 385,

        /// <summary>Letter - Apology</summary>
        [XmlEnum("386")]
        OLI_ATTACH_APOLOGY = 386,

        /// <summary>Letter - Commitment</summary>
        [XmlEnum("387")]
        OLI_ATTACH_LETOFCOMMIT = 387,

        /// <summary>Letter - Decision</summary>
        [XmlEnum("388")]
        OLI_ATTACH_DECISION = 388,

        /// <summary>Letter - Receipt for Premiums Collected</summary>
        [XmlEnum("389")]
        OLI_ATTACH_RECEIPT = 389,

        /// <summary>Letter - To Physician</summary>
        [XmlEnum("390")]
        OLI_ATTACH_PHYSICIANLET = 390,

        /// <summary>Mail Log</summary>
        [XmlEnum("391")]
        OLI_ATTACH_MAILLOG = 391,

        /// <summary>Marketing - Fund Code Chart</summary>
        [XmlEnum("392")]
        OLI_ATTACH_FUNDCODE = 392,

        /// <summary>Marketing - Quotation Request</summary>
        [XmlEnum("393")]
        OLI_ATTACH_QUOTEREQ = 393,

        /// <summary>Marketing - Underwriting Requirements Chart</summary>
        [XmlEnum("394")]
        OLI_ATTACH_UNDERWRITREQ = 394,

        /// <summary>Needs Analysis /  Screening - Critical Illness</summary>
        [XmlEnum("395")]
        OLI_ATTACH_CRITICALSCREEN = 395,

        /// <summary>Needs Analysis /  Screening - Disability</summary>
        [XmlEnum("396")]
        OLI_ATTACH_DISABSCREEN = 396,

        /// <summary>Needs Analysis /  Screening - Insurance</summary>
        [XmlEnum("397")]
        OLI_ATTACH_INSSCREEN = 397,

        /// <summary>Needs Analysis /  Screening - Investment</summary>
        [XmlEnum("398")]
        OLI_ATTACH_INVESTSCREEN = 398,

        /// <summary>Policy Delivery - Evaluation Guide</summary>
        [XmlEnum("399")]
        OLI_ATTACH_EVALGUIDE = 399,

        /// <summary>Questionnaire - Activities of Daily Living</summary>
        [XmlEnum("400")]
        OLI_ATTACH_DAILYLIVQ = 400,

        /// <summary>Questionnaire - Alcohol or Drug Use</summary>
        [XmlEnum("401")]
        OLI_ATTACH_ALCOHOLQ = 401,

        /// <summary>Questionnaire - Arthritis</summary>
        [XmlEnum("402")]
        OLI_ATTACH_ARTHRITISQ = 402,

        /// <summary>Questionnaire - Assessment</summary>
        [XmlEnum("403")]
        OLI_ATTACH_ASSESSQ = 403,

        /// <summary>Questionnaire - Avocation</summary>
        [XmlEnum("404")]
        OLI_ATTACH_AVOCATIONQ = 404,

        /// <summary>Questionnaire - Back Pain</summary>
        [XmlEnum("405")]
        OLI_ATTACH_BACKPAINQ = 405,

        /// <summary>Questionnaire - Beneficial Ownership</summary>
        [XmlEnum("406")]
        OLI_ATTACH_BENEFICIALQ = 406,

        /// <summary>Questionnaire - Blood Pressure</summary>
        [XmlEnum("407")]
        OLI_ATTACH_BLOODPRESQ = 407,

        /// <summary>Questionnaire - Client Information</summary>
        [XmlEnum("408")]
        OLI_ATTACH_CLIENTIINFOQ = 408,

        /// <summary>Questionnaire - Climbing</summary>
        [XmlEnum("409")]
        OLI_ATTACH_CLIMBQ = 409,

        /// <summary>Questionnaire - Colitis</summary>
        [XmlEnum("410")]
        OLI_ATTACH_COLITISQ = 410,

        /// <summary>Questionnaire - Coronary and Angina</summary>
        [XmlEnum("411")]
        OLI_ATTACH_CORONARYQ = 411,

        /// <summary>Questionnaire - Digestive / Bowel Disorder</summary>
        [XmlEnum("412")]
        OLI_ATTACH_DIGESTIVEQ = 412,

        /// <summary>Questionnaire - Driving History</summary>
        [XmlEnum("413")]
        OLI_ATTACH_DRIVHISTQ = 413,

        /// <summary>Questionnaire - Emotional Health</summary>
        [XmlEnum("414")]
        OLI_ATTACH_EMOTHEALQ = 414,

        /// <summary>Questionnaire - Fainting</summary>
        [XmlEnum("415")]
        OLI_ATTACH_FAINTINGQ = 415,

        /// <summary>Questionnaire - Family History</summary>
        [XmlEnum("416")]
        OLI_ATTACH_FAMILYQ = 416,

        /// <summary>Questionnaire - Gastro-Intestinal</summary>
        [XmlEnum("417")]
        OLI_ATTACH_GASTROIN = 417,

        /// <summary>Questionnaire - Gynaecological</summary>
        [XmlEnum("418")]
        OLI_ATTACH_GYNQ = 418,

        /// <summary>Questionnaire - Headache</summary>
        [XmlEnum("419")]
        OLI_ATTACH_HEADACHE = 419,

        /// <summary>Questionnaire - Kidney</summary>
        [XmlEnum("420")]
        OLI_ATTACH_KIDNEYQ = 420,

        /// <summary>Questionnaire - Liver</summary>
        [XmlEnum("421")]
        OLI_ATTACH_LIVERQ = 421,

        /// <summary>Questionnaire - Mature Age</summary>
        [XmlEnum("422")]
        OLI_ATTACH_MATUREQ = 422,

        /// <summary>Questionnaire - Military</summary>
        [XmlEnum("423")]
        OLI_ATTACH_MILITARYQ = 423,

        /// <summary>Questionnaire - Motor Sport</summary>
        [XmlEnum("424")]
        OLI_ATTACH_MOTORSPORTSQ = 424,

        /// <summary>Questionnaire - Motorcycle</summary>
        [XmlEnum("425")]
        OLI_ATTACH_MOTORCYCLE = 425,

        /// <summary>Questionnaire - Neurological</summary>
        [XmlEnum("426")]
        OLI_ATTACH_NEUROLOQ = 426,

        /// <summary>Questionnaire - Nicotine</summary>
        [XmlEnum("427")]
        OLI_ATTACH_NICOTINEQ = 427,

        /// <summary>Questionnaire - Occupation</summary>
        [XmlEnum("428")]
        OLI_ATTACH_OCCUPATIONQ = 428,

        /// <summary>Questionnaire - Part 2 (Paramedical / Medical)</summary>
        [XmlEnum("429")]
        OLI_ATTACH_MEDICALP2 = 429,

        /// <summary>Questionnaire - Physical Demands</summary>
        [XmlEnum("430")]
        OLI_ATTACH_PHYSICALDEMAQ = 430,

        /// <summary>Questionnaire - Physiotherapy Report</summary>
        [XmlEnum("431")]
        OLI_ATTACH_PHYSIOTHERYQ = 431,

        /// <summary>Questionnaire - Power Boat Racing</summary>
        [XmlEnum("432")]
        OLI_ATTACH_POWERBOATQ = 432,

        /// <summary>Questionnaire - Psychiatric</summary>
        [XmlEnum("433")]
        OLI_ATTACH_PSYCHIATRICQ = 433,

        /// <summary>Questionnaire - Respiratory</summary>
        [XmlEnum("434")]
        OLI_ATTACH_RESPIRATORYQ = 434,

        /// <summary>Questionnaire - Scuba Diving</summary>
        [XmlEnum("435")]
        OLI_ATTACH_SCUBAQ = 435,

        /// <summary>Questionnaire - Skydiving, Parachuting</summary>
        [XmlEnum("436")]
        OLI_ATTACH_SKYDIVINGQ = 436,

        /// <summary>Questionnaire - Snowmobiling</summary>
        [XmlEnum("437")]
        OLI_ATTACH_SNOWMOBILEQ = 437,

        /// <summary>Questionnaire - Temporary Insurance Agreement</summary>
        [XmlEnum("438")]
        OLI_ATTACH_TEMPAGREE = 438,

        /// <summary>Questionnaire - Tumour</summary>
        [XmlEnum("439")]
        OLI_ATTACH_TUMORQ = 439,

        /// <summary>Request - Disclosure of Reasons for UW Decision</summary>
        /// <remarks>Request - Disclosure of Reasons for Underwriting Decision</remarks>
        [XmlEnum("440")]
        OLI_ATTACH_DISCLOSUREREA = 440,

        /// <summary>Request - Duplicate Policy</summary>
        [XmlEnum("441")]
        OLI_ATTACH_DUPLICATERQ = 441,

        /// <summary>Request - Supplies (Group)</summary>
        [XmlEnum("442")]
        OLI_ATTACH_SUPPLIESGR = 442,

        /// <summary>Request - Supplies (Insurance)</summary>
        [XmlEnum("443")]
        OLI_ATTACH_SUPPLIESINS = 443,

        /// <summary>Request - Supplies (Investment)</summary>
        [XmlEnum("444")]
        OLI_ATTACH_SUPPLIESINV = 444,

        /// <summary>Segregated Funds - Reset</summary>
        [XmlEnum("445")]
        OLI_ATTACH_RESETSEGRFUNDS = 445,

        /// <summary>Service - Banking / Premium Payment</summary>
        [XmlEnum("446")]
        OLI_ATTACH_BANKPREMPAY = 446,

        /// <summary>Service - Bene, Owner, Trustee, Assignment, Name</summary>
        /// <remarks>Service - Beneficiary, Owner, Trustee, Assignment, Name</remarks>
        [XmlEnum("447")]
        OLI_ATTACH_BENENAMECORR = 447,

        /// <summary>Service - Cancellation / Termination</summary>
        [XmlEnum("448")]
        OLI_ATTACH_CANCELLSERV = 448,

        /// <summary>Service - Creditor Request</summary>
        [XmlEnum("449")]
        OLI_ATTACH_CREIDTORREQSERV = 449,

        /// <summary>Service - Deposit Notice</summary>
        [XmlEnum("450")]
        OLI_ATTACH_DEPOSITNOTESERV = 450,

        /// <summary>Service - Loan Repayment</summary>
        [XmlEnum("451")]
        OLI_ATTACH_LOANREPAYSERV = 451,

        /// <summary>Service - Non-Financial Update</summary>
        [XmlEnum("452")]
        OLI_ATTACH_NONFINUPDATE = 452,

        /// <summary>Service - Ownership or Beneficiary</summary>
        [XmlEnum("453")]
        OLI_ATTACH_OWNERSERV = 453,

        /// <summary>Service - Payee</summary>
        [XmlEnum("454")]
        OLI_ATTACH_PAYEESERV = 454,

        /// <summary>Service - Phone Restriction</summary>
        [XmlEnum("455")]
        OLI_ATTACH_PHONESERV = 455,

        /// <summary>Service - Policy</summary>
        [XmlEnum("456")]
        OLI_ATTACH_POLICYSERV = 456,

        /// <summary>Service - Registered Investment Transfer</summary>
        [XmlEnum("457")]
        OLI_ATTACH_TRANSFERSERV = 457,

        /// <summary>Service - Release of Beneficiary's Interest</summary>
        [XmlEnum("458")]
        OLI_ATTACH_RELBENEINT = 458,

        /// <summary>Service - Release of Collateral Assignment</summary>
        [XmlEnum("459")]
        OLI_ATTACH_RELCOLLASS = 459,

        /// <summary>Service - Rider Election / Addition of Coverage</summary>
        [XmlEnum("460")]
        OLI_ATTACH_RIDERELEC = 460,

        /// <summary>Service - Servicing Representative Change</summary>
        [XmlEnum("461")]
        OLI_ATTACH_SERVREPCHG = 461,

        /// <summary>Service - Status Change</summary>
        [XmlEnum("462")]
        OLI_ATTACH_STATUSCHG = 462,

        /// <summary>Statement - Acceptance</summary>
        [XmlEnum("463")]
        OLI_ATTACH_ACCEPTANCE = 463,

        /// <summary>Statement - Amounts held in Federal plans</summary>
        [XmlEnum("464")]
        OLI_ATTACH_AMOUNTSTAT = 464,

        /// <summary>Statement - Certificate of Discharge</summary>
        [XmlEnum("465")]
        OLI_ATTACH_CERTOFDISCH = 465,

        /// <summary>Statement - Certificate of Existence</summary>
        [XmlEnum("466")]
        OLI_ATTACH_CERTOFEXIST = 466,

        /// <summary>Statement - Child Health</summary>
        [XmlEnum("467")]
        OLI_ATTACH_CLDHEALTH = 467,

        /// <summary>Statement - Client Disclosure</summary>
        [XmlEnum("468")]
        OLI_ATTACH_CLTDISCLO = 468,

        /// <summary>Statement - Compensation (Group)</summary>
        [XmlEnum("469")]
        OLI_ATTACH_COMPENSATIONGR = 469,

        /// <summary>Statement - Date of Birth</summary>
        [XmlEnum("470")]
        OLI_ATTACH_DOBSTATEMENT = 470,

        /// <summary>Statement - Insurability / Good Health</summary>
        [XmlEnum("471")]
        OLI_ATTACH_INSURABILITYSTAT = 471,

        /// <summary>Statement - Interest Rate Guarantee</summary>
        [XmlEnum("472")]
        OLI_ATTACH_INTRATEGUARSTAT = 472,

        /// <summary>Statement - Interpreter</summary>
        [XmlEnum("473")]
        OLI_ATTACH_INTERPRETER = 473,

        /// <summary>Statement - Letter of Direction</summary>
        [XmlEnum("474")]
        OLI_ATTACH_LETDIRECTION = 474,

        /// <summary>Statement - Locked-In Pension Funds</summary>
        [XmlEnum("475")]
        OLI_ATTACH_LOCKINPENSION = 475,

        /// <summary>Statement - Major Cash Deposit</summary>
        [XmlEnum("476")]
        OLI_ATTACH_MAJORCASHDEP = 476,

        /// <summary>Statement - Marital Status</summary>
        [XmlEnum("477")]
        OLI_ATTACH_MARITALSTATUS = 477,

        /// <summary>Statement - Notary Public  Certificate</summary>
        [XmlEnum("478")]
        OLI_ATTACH_NOTARY = 478,

        /// <summary>Statement - Refusal of Coverage</summary>
        [XmlEnum("479")]
        OLI_ATTACH_REFUSAL = 479,

        /// <summary>Statement - Representative Declaration</summary>
        [XmlEnum("480")]
        OLI_ATTACH_REPDECLARATION = 480,

        /// <summary>Statement - Spousal Consent / Waiver</summary>
        [XmlEnum("481")]
        OLI_ATTACH_SPOUSALCONS = 481,

        /// <summary>Statement - Third Party Declaration</summary>
        [XmlEnum("482")]
        OLI_ATTACH_THRIDPARTY = 482,

        /// <summary>Tax - Canada Revenue Agency (CCRA)</summary>
        [XmlEnum("483")]
        OLI_ATTACH_CCRA = 483,

        /// <summary>Tax - Request to Reduce Tax Deductions at Source</summary>
        [XmlEnum("484")]
        OLI_ATTACH_REDUCETAXDED = 484,

        /// <summary>Note from Seller</summary>
        /// <remarks>Contains comments or notes from the seller to the buyer in an invoicing context.</remarks>
        [XmlEnum("485")]
        OLI_ATTACH_SELLERNOTE = 485,

        /// <summary>Note from Buyer</summary>
        /// <remarks>Contains comments or notes from the buyer to the seller in an invoicing context.</remarks>
        [XmlEnum("486")]
        OLI_ATTACH_BUYERNOTE = 486,

        /// <summary>Account Opening Form</summary>
        [XmlEnum("2550010")]
        OLI_ATTACH_ACCTOPEN = 2550010,

        /// <summary>Electronic Consent Form - Carrier</summary>
        [XmlEnum("2550020")]
        OLI_ATTACH_CARRCONSENT = 2550020,

        /// <summary>Electronic Consent Form - Distributor</summary>
        [XmlEnum("2550030")]
        OLI_ATTACH_DISTCONSENT = 2550030,

        /// <summary>Electronic Consent Form - Joint</summary>
        [XmlEnum("2550035")]
        OLI_ATTACH_JNTCONSENT = 2550035,

        /// <summary>Variable Annuity Contract Prospectus</summary>
        [XmlEnum("2550040")]
        OLI_ATTACH_CONTRACTPROSP = 2550040,

        /// <summary>Registered Fixed Annuity Prospectus (MVA and EIA)</summary>
        /// <remarks>Registered Fixed Annuity Prospectus (including MVA and EIA)</remarks>
        [XmlEnum("2550042")]
        OLI_ATTACH_FIXEDPROSP = 2550042,

        /// <summary>Fund Prospectus</summary>
        [XmlEnum("2550050")]
        OLI_ATTACH_FUNDPROSP = 2550050,

        /// <summary>Variable Annuity Profile</summary>
        [XmlEnum("2550060")]
        OLI_ATTACH_VAP = 2550060,

        /// <summary>Fixed Annuity Profile</summary>
        [XmlEnum("2550070")]
        OLI_ATTACH_FAP = 2550070,

        /// <summary>Indexed Annuity profile</summary>
        [XmlEnum("2550080")]
        OLI_ATTACH_IAP = 2550080,

        /// <summary>Risk Tolerance Questionnaire</summary>
        [XmlEnum("2550090")]
        OLI_ATTACH_RISKTOL = 2550090,

        /// <summary>Privacy Notice</summary>
        [XmlEnum("2550100")]
        OLI_ATTACH_PRIVACYNOTE = 2550100,

        /// <summary>General VA Disclosure (Rule 2821)</summary>
        [XmlEnum("2550110")]
        OLI_ATTACH_VADISCLOSURE = 2550110,

        /// <summary>Compensation Disclosure</summary>
        [XmlEnum("2550120")]
        OLI_ATTACH_COMDISCLOSURE = 2550120,

        /// <summary>Conflicts of Interest Disclosure</summary>
        [XmlEnum("2550130")]
        OLI_ATTACH_CONFLICTS = 2550130,

        /// <summary>Sales Summary Disclosure</summary>
        [XmlEnum("2550140")]
        OLI_ATTACH_SALESDISCOSURE = 2550140,

        /// <summary>NAIC Buyers Guide - Fixed</summary>
        [XmlEnum("2550150")]
        OLI_ATTACH_NAICBUYGUIDEFIXED = 2550150,

        /// <summary>NAIC Buyers Guide - Variable</summary>
        [XmlEnum("2550160")]
        OLI_ATTACH_NAICBUYGUIDEVAR = 2550160,

        /// <summary>NAIC Buyers Guide - EIA</summary>
        [XmlEnum("2550170")]
        OLI_ATTACH_NAICBUYGUIDEEIA = 2550170,

        /// <summary>Non- NAIC SPDA Disclosure Form</summary>
        [XmlEnum("2550175")]
        OLI_ATTACH_NONNAICSPDA = 2550175,

        /// <summary>NAIC Disclosure - Fixed and EIA</summary>
        [XmlEnum("2550180")]
        OLI_ATTACH_NAICDISCFIXEIA = 2550180,

        /// <summary>Annuity Application - IRI Compliant</summary>
        /// <remarks>Formerly named "Annuity Application - NAVA Compliant"</remarks>
        [XmlEnum("2550190")]
        OLI_ATTACH_ANNUITY_APPNAVACOMP = 2550190,

        /// <summary>Annuity Application - Non IRI Compliant</summary>
        /// <remarks>Formerly named "Annuity Application - Non NAVA Compliant"</remarks>
        [XmlEnum("2550200")]
        OLI_ATTACH_ANNUITY_APP_NONNAVACOMP = 2550200,

        /// <summary>Trust Document Certificate</summary>
        [XmlEnum("2550210")]
        OLI_ATTACH_TRUST = 2550210,

        /// <summary>Ownership Disclosure - Non-Natural or Corp Owned</summary>
        /// <remarks>Ownership Disclosure - Non-Natural or  Corporate Owned Form</remarks>
        [XmlEnum("2550212")]
        OLI_ATTACH_OWNDISCNNCO = 2550212,

        /// <summary>Ownership Disclosure - Notice for Active Duty USAF</summary>
        /// <remarks>Ownership Disclosure - Important notice for Active Duty Members of the United States Armed Forces</remarks>
        [XmlEnum("2550214")]
        OLI_ATTACH_OWNDISCMIL = 2550214,

        /// <summary>Early Withdrawals on Annuity Proceeds Disclosure</summary>
        /// <remarks>Early Withdrawals on Annuity Proceeds Disclosure Statement</remarks>
        [XmlEnum("2550216")]
        OLI_ATTACH_EARLYWITH = 2550216,

        /// <summary>Systematic Withdrawal Form</summary>
        [XmlEnum("2550220")]
        OLI_ATTACH_SYSWITH = 2550220,

        /// <summary>Telephone/ Electronic Transaction Auth Form</summary>
        [XmlEnum("2550230")]
        OLI_ATTACH_TELE = 2550230,

        /// <summary>Payment - Pre-Authorized Investment Form (PAC)</summary>
        [XmlEnum("2550232")]
        OLI_ATTACH_PAYPAC = 2550232,

        /// <summary>Credit Enhancement Disclosure Form</summary>
        [XmlEnum("2550233")]
        OLI_ATTACH_CREDITENH = 2550233,

        /// <summary>Payment - Acceptable forms of Payment Notice</summary>
        /// <remarks>Payment - Acceptable forms of Payment Notice (Disclosure)</remarks>
        [XmlEnum("2550234")]
        OLI_ATTACH_PAYFORM = 2550234,

        /// <summary>Jumbo Case Review Form</summary>
        [XmlEnum("2550240")]
        OLI_ATTACH_JUMBOREVIEW = 2550240,

        /// <summary>Tax Disclosure Form - W8</summary>
        [XmlEnum("2550250")]
        OLI_ATTACH_TAXW8 = 2550250,

        /// <summary>Tax Disclosure Form - W4P</summary>
        [XmlEnum("2550260")]
        OLI_ATTACH_TAXW4P = 2550260,

        /// <summary>Power Of Attorney Affidavit</summary>
        [XmlEnum("2550270")]
        OLI_ATTACH_POA = 2550270,

        /// <summary>Rider Reset Authorization Form</summary>
        [XmlEnum("2550280")]
        OLI_ATTACH_RIDERRESET = 2550280,

        /// <summary>Annuitization Authorization Form</summary>
        [XmlEnum("2550290")]
        OLI_ATTACH_ANNUITIZE = 2550290,

        /// <summary>Interest Sweep Form</summary>
        [XmlEnum("2550300")]
        OLI_ATTACH_INTSWEEP = 2550300,

        /// <summary>Asset Rebalancing Form</summary>
        [XmlEnum("2550310")]
        OLI_ATTACH_ASSETREBAL = 2550310,

        /// <summary>Dollar Cost Averaging (DCA) Form</summary>
        [XmlEnum("2550320")]
        OLI_ATTACH_DCAREQ = 2550320,

        /// <summary>NAIC Model Reg Replacement Form</summary>
        [XmlEnum("2550330")]
        OLI_ATTACH_NAICMODELREGDISC = 2550330,

        /// <summary>Non-NAIC Model Replacement Form</summary>
        [XmlEnum("2550340")]
        OLI_ATTACH_NONNAICREPLACEMENT = 2550340,

        /// <summary>New York Regulation 60 Disclosure Form</summary>
        [XmlEnum("2550350")]
        OLI_ATTACH_REG60 = 2550350,

        /// <summary>Exchange/Rollover Transfer Form</summary>
        [XmlEnum("2550360")]
        OLI_ATTACH_EXCHANGE = 2550360,

        /// <summary>Suitability Determination Form</summary>
        [XmlEnum("2550370")]
        OLI_ATTACH_SUITABILITY = 2550370,

        /// <summary>Customer Confirmation Form</summary>
        [XmlEnum("2550380")]
        OLI_ATTACH_CUSTOMERCONFIRM = 2550380,

        /// <summary>Welcome Letter</summary>
        [XmlEnum("2550390")]
        OLI_ATTACH_WELCOMELTR = 2550390,

        /// <summary>Annuity Policy Contract</summary>
        [XmlEnum("2550400")]
        OLI_ATTACH_ANNUITYCONTRACT = 2550400,

        /// <summary>Proof of Delivery Statement</summary>
        [XmlEnum("2550410")]
        OLI_ATTACH_PROOFOFDEL = 2550410,

        /// <summary>Guaranty Association Notices</summary>
        [XmlEnum("2550420")]
        OLI_ATTACH_GUARANTYNOTICE = 2550420,

        /// <summary>Qualified Plan Disclosures</summary>
        [XmlEnum("2550430")]
        OLI_ATTACH_QUALPLANDISC = 2550430,

        /// <summary>Qualified Plan Disclosure - Simple IRA Employer Form</summary>
        /// <remarks>Qualified Plan Disclosure - Simple IRA Employer Information Form</remarks>
        [XmlEnum("2550432")]
        OLI_ATTACH_QUALSIMPLE = 2550432,

        /// <summary>Qualified Plan Disclosure - Tax Sheltered Annuity</summary>
        /// <remarks>Qualified Plan Disclosure - Tax Sheltered Annuity Certification Form</remarks>
        [XmlEnum("2550434")]
        OLI_ATTACH_QUALTSA = 2550434,

        /// <summary>Service Forms</summary>
        [XmlEnum("2550440")]
        OLI_ATTACH_SERVICEFORM = 2550440,

        /// <summary>Buyers Guide (Non-NAIC)</summary>
        [XmlEnum("2550450")]
        OLI_ATTACH_BUYERS_GUIDE = 2550450,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
