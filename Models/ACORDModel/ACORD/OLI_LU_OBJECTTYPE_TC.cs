using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_OBJECTTYPE_TC
    {
        /// <summary>Client</summary>
        [XmlEnum("1")]
        OLI_CLIENT = 1,

        /// <summary>Address</summary>
        [XmlEnum("2")]
        OLI_ADDRESS = 2,

        /// <summary>Phone</summary>
        [XmlEnum("3")]
        OLI_PHONE = 3,

        /// <summary>Holding</summary>
        [XmlEnum("4")]
        OLI_HOLDING = 4,

        /// <summary>ExpenseNeed</summary>
        [XmlEnum("5")]
        OLI_EXPENSENEED = 5,

        /// <summary>Party</summary>
        [XmlEnum("6")]
        OLI_PARTY = 6,

        /// <summary>Activity</summary>
        [XmlEnum("7")]
        OLI_ACTIVITY = 7,

        /// <summary>Relation</summary>
        [XmlEnum("8")]
        OLI_RELATION = 8,

        /// <summary>Attachment</summary>
        [XmlEnum("9")]
        OLI_ATTACHMENT = 9,

        /// <summary>License</summary>
        [XmlEnum("10")]
        OLI_LICENSE = 10,

        /// <summary>CarrierAppointment</summary>
        [XmlEnum("11")]
        OLI_CARRIERAPPOINTMENT = 11,

        /// <summary>Security</summary>
        [XmlEnum("12")]
        OLI_SECURITY = 12,

        /// <summary>Producer</summary>
        [XmlEnum("13")]
        OLI_PRODUCER = 13,

        /// <summary>AuthorInfo</summary>
        [XmlEnum("14")]
        OLI_AUTHORINFO = 14,

        /// <summary>BusinessRuleInfo</summary>
        [XmlEnum("15")]
        OLI_BUSINESSRULEINFO = 15,

        /// <summary>Grouping</summary>
        [XmlEnum("16")]
        OLI_GROUPING = 16,

        /// <summary>Household</summary>
        [XmlEnum("17")]
        OLI_HOUSEHOLD = 17,

        /// <summary>Policy</summary>
        [XmlEnum("18")]
        OLI_POLICY = 18,

        /// <summary>Life</summary>
        [XmlEnum("19")]
        OLI_LIFE = 19,

        /// <summary>LifeCoverage</summary>
        [XmlEnum("20")]
        OLI_LIFECOVERAGE = 20,

        /// <summary>Coverage Option</summary>
        [XmlEnum("21")]
        OLI_COVOPTION = 21,

        /// <summary>LifeParticipant</summary>
        [XmlEnum("22")]
        OLI_LIFEPARTICIPANT = 22,

        /// <summary>KeyedValue</summary>
        [XmlEnum("23")]
        OLI_KEYEDVALUE = 23,

        /// <summary>LifeUSA</summary>
        [XmlEnum("24")]
        OLI_LIFEUSA = 24,

        /// <summary>Annuity</summary>
        [XmlEnum("25")]
        OLI_ANNUITY = 25,

        /// <summary>Payout</summary>
        [XmlEnum("26")]
        OLI_PAYOUT = 26,

        /// <summary>PayoutParticipant</summary>
        [XmlEnum("27")]
        OLI_PAYOUTPARTICIPANT = 27,

        /// <summary>DHParticipant</summary>
        [XmlEnum("28")]
        OLI_DHPARTICIPANT = 28,

        /// <summary>DisabilityHealth</summary>
        [XmlEnum("29")]
        OLI_DISABILITYHEALTH = 29,

        /// <summary>DHRider</summary>
        [XmlEnum("30")]
        OLI_DHRIDER = 30,

        /// <summary>Investment</summary>
        [XmlEnum("31")]
        OLI_INVESTMENT = 31,

        /// <summary>SubAccount</summary>
        [XmlEnum("32")]
        OLI_SUBACCOUNT = 32,

        /// <summary>InvestProduct</summary>
        [XmlEnum("33")]
        OLI_INVESTPRODUCT = 33,

        /// <summary>InvestPortfolio</summary>
        [XmlEnum("34")]
        OLI_INVESTPORTFOLIO = 34,

        /// <summary>PolicyProduct</summary>
        [XmlEnum("35")]
        OLI_POLICYPRODUCT = 35,

        /// <summary>Carrier</summary>
        [XmlEnum("36")]
        OLI_CARRIER = 36,

        /// <summary>ResultSet</summary>
        [XmlEnum("37")]
        OLI_RESULTSET = 37,

        /// <summary>RSField</summary>
        [XmlEnum("38")]
        OLI_RSFIELD = 38,

        /// <summary>RSFields</summary>
        [XmlEnum("39")]
        OLI_RSFIELDS = 39,

        /// <summary>Criteria</summary>
        [XmlEnum("40")]
        OLI_CRITERIA = 40,

        /// <summary>LinkManager</summary>
        [XmlEnum("41")]
        OLI_LINKMANAGER = 41,

        /// <summary>Errors</summary>
        [XmlEnum("42")]
        OLI_ERRORS = 42,

        /// <summary>RecordOwner</summary>
        [XmlEnum("43")]
        OLI_RECORDOWNER = 43,

        /// <summary>ObjCollection</summary>
        [XmlEnum("44")]
        OLI_OBJCOLLECTION = 44,

        /// <summary>Server</summary>
        [XmlEnum("45")]
        OLI_SERVER = 45,

        /// <summary>SelectPartyDialog</summary>
        [XmlEnum("46")]
        COMMON_SELECTPARTYDIALOG = 46,

        /// <summary>SelectHoldingDialog</summary>
        [XmlEnum("47")]
        COMMON_SELECTHOLDINGDIALOG = 47,

        /// <summary>SelectActivityDialog</summary>
        [XmlEnum("48")]
        COMMON_SELECTACTIVITYDIALOG = 48,

        /// <summary>LogonInfoDialog</summary>
        [XmlEnum("49")]
        COMMON_LOGONINFODIALOG = 49,

        /// <summary>BusinessRuleInfo</summary>
        [XmlEnum("50")]
        OLI_BUSINESRULEINFOS = 50,

        /// <summary>ExtensionContext</summary>
        [XmlEnum("51")]
        OLI_EXTENSIONCONTEXT = 51,

        /// <summary>BusinessRuleContext</summary>
        [XmlEnum("52")]
        OLI_BUSINESSRULECONTEXT = 52,

        /// <summary>LinkInfo</summary>
        [XmlEnum("53")]
        OLI_LINKINFO = 53,

        /// <summary>Error</summary>
        [XmlEnum("54")]
        OLI_ERROR = 54,

        /// <summary>PriorName</summary>
        [XmlEnum("55")]
        OLI_PRIORNAME = 55,

        /// <summary>EmailAddress</summary>
        [XmlEnum("56")]
        OLI_EMAILADDRESS = 56,

        /// <summary>RequirementInfo</summary>
        [XmlEnum("57")]
        OLI_REQUIREMENTINFO = 57,

        /// <summary>ApplicationInfo</summary>
        [XmlEnum("58")]
        OLI_APPLICATIONINFO = 58,

        /// <summary>Risk</summary>
        [XmlEnum("59")]
        OLI_RISK = 59,

        /// <summary>SubstanceUsage</summary>
        [XmlEnum("60")]
        OLI_SUBSTANCEUSAGE = 60,

        /// <summary>MedCondition</summary>
        [XmlEnum("61")]
        OLI_MEDCONDITION = 61,

        /// <summary>MedTreatment</summary>
        [XmlEnum("62")]
        OLI_MEDTREATMENT = 62,

        /// <summary>MedPrevention</summary>
        [XmlEnum("63")]
        OLI_MEDPREVENTION = 63,

        /// <summary>FamIllness</summary>
        [XmlEnum("64")]
        OLI_FAMILLNESS = 64,

        /// <summary>Violation</summary>
        [XmlEnum("65")]
        OLI_VIOLATION = 65,

        /// <summary>CrimConviction</summary>
        [XmlEnum("66")]
        OLI_CRIMCONVICTION = 66,

        /// <summary>MilitaryExp</summary>
        [XmlEnum("67")]
        OLI_MILITARYEXP = 67,

        /// <summary>HHFamilyIns</summary>
        [XmlEnum("68")]
        OLI_HHFAMILYINS = 68,

        /// <summary>LifestyleActivity</summary>
        [XmlEnum("69")]
        OLI_LIFESTYLEACTIVITY = 69,

        /// <summary>UnderwaterDivingExp</summary>
        [XmlEnum("70")]
        OLI_UNDERWATERDIVINGEXP = 70,

        /// <summary>DivePurpose</summary>
        [XmlEnum("71")]
        OLI_DIVEPURPOSE = 71,

        /// <summary>RacingExp</summary>
        [XmlEnum("72")]
        OLI_RACINGEXP = 72,

        /// <summary>CompetitionDetail</summary>
        [XmlEnum("73")]
        OLI_COMPETITIONDETAIL = 73,

        /// <summary>AirSportsExp</summary>
        [XmlEnum("74")]
        OLI_AIRSPORTSEXP = 74,

        /// <summary>BallooningExp</summary>
        [XmlEnum("75")]
        OLI_BALLOONINGEXP = 75,

        /// <summary>HangglidingExp</summary>
        [XmlEnum("76")]
        OLI_HANGGLIDINGEXP = 76,

        /// <summary>UltraliteExp</summary>
        [XmlEnum("77")]
        OLI_ULTRALITEEXP = 77,

        /// <summary>ParachutingExp</summary>
        [XmlEnum("78")]
        OLI_PARACHUTINGEXP = 78,

        /// <summary>ClimbingExp</summary>
        [XmlEnum("79")]
        OLI_CLIMBINGEXP = 79,

        /// <summary>ForeignTravel</summary>
        [XmlEnum("80")]
        OLI_FOREIGNTRAVEL = 80,

        /// <summary>AviationExp</summary>
        [XmlEnum("81")]
        OLI_AVIATIONEXP = 81,

        /// <summary>Currency</summary>
        [XmlEnum("82")]
        OLI_CURRENCY = 82,

        /// <summary>ExchangeRate</summary>
        [XmlEnum("83")]
        OLI_EXCHANGERATE = 83,

        /// <summary>InvestProductInfo</summary>
        [XmlEnum("84")]
        OLI_INVESTPRODUCTINFO = 84,

        /// <summary>CompensationPayment</summary>
        [XmlEnum("85")]
        OLI_COMPENSATIONPAYMENT = 85,

        /// <summary>AnnRider</summary>
        [XmlEnum("86")]
        OLI_ANNRIDER = 86,

        /// <summary>Currencies</summary>
        [XmlEnum("87")]
        OLI_CURRENCIES = 87,

        /// <summary>Annuity USA</summary>
        [XmlEnum("88")]
        OLI_ANNUITYUSA = 88,

        /// <summary>Arrangement</summary>
        [XmlEnum("89")]
        OLI_ARRANGEMENT = 89,

        /// <summary>Arrangement Source</summary>
        [XmlEnum("90")]
        OLI_ARRSOURCE = 90,

        /// <summary>Arrangement Destination</summary>
        [XmlEnum("91")]
        OLI_ARRDESTINATION = 91,

        /// <summary>Financial Activity</summary>
        [XmlEnum("92")]
        OLI_FINACTIVITY = 92,

        /// <summary>Financial Statement</summary>
        [XmlEnum("93")]
        OLI_FINSTMT = 93,

        /// <summary>Commission Statement</summary>
        [XmlEnum("94")]
        OLI_COMMSTMT = 94,

        /// <summary>Commission Detail</summary>
        [XmlEnum("95")]
        OLI_COMMDETAIL = 95,

        /// <summary>Billing Statement</summary>
        [XmlEnum("96")]
        OLI_BILLSTMT = 96,

        /// <summary>Billing Detail</summary>
        [XmlEnum("97")]
        OLI_BILLDETAIL = 97,

        /// <summary>Scenario</summary>
        [XmlEnum("98")]
        OLI_SCENARIO = 98,

        /// <summary>Scenario Participant</summary>
        [XmlEnum("99")]
        OLI_SCENARIOPART = 99,

        /// <summary>Medical Exam</summary>
        [XmlEnum("100")]
        OLI_MEDEXAM = 100,

        /// <summary>Form Instance</summary>
        [XmlEnum("101")]
        OLI_FORMINSTANCE = 101,

        /// <summary>Signature Information</summary>
        [XmlEnum("102")]
        OLI_SIGNATUREINFO = 102,

        /// <summary>Form Response</summary>
        [XmlEnum("103")]
        OLI_FORMRESPONSE = 103,

        /// <summary>Associated Response Data</summary>
        [XmlEnum("104")]
        OLI_ASSOCRESPONSEDATA = 104,

        /// <summary>Claim</summary>
        [XmlEnum("105")]
        OLI_CLAIM = 105,

        /// <summary>Loan</summary>
        [XmlEnum("106")]
        OLI_LOAN = 106,

        /// <summary>Alternate Premium Mode</summary>
        [XmlEnum("107")]
        OLI_ALTPREMMODE = 107,

        /// <summary>Investment Product Translation</summary>
        [XmlEnum("108")]
        OLI_INVESTPRODUCTXLAT = 108,

        /// <summary>Holding Translation</summary>
        [XmlEnum("109")]
        OLI_HOLDINGXLAT = 109,

        /// <summary>Coverage Option Translation</summary>
        [XmlEnum("110")]
        OLI_COVOPTIONXLAT = 110,

        /// <summary>Coverage Translation</summary>
        [XmlEnum("111")]
        OLI_COVERAGEXLAT = 111,

        /// <summary>Policy Product Translation</summary>
        [XmlEnum("112")]
        OLI_POLICYPRODUCTXLAT = 112,

        /// <summary>Investment Portfolio Translation</summary>
        [XmlEnum("113")]
        OLI_INVESTPORTFOLIOXLAT = 113,

        /// <summary>Party Translation</summary>
        [XmlEnum("114")]
        OLI_PARTYXLAT = 114,

        /// <summary>Person</summary>
        [XmlEnum("115")]
        OLI_PERSON = 115,

        /// <summary>Organization</summary>
        [XmlEnum("116")]
        OLI_ORGANIZATION = 116,

        /// <summary>Coverage Product</summary>
        [XmlEnum("117")]
        OLI_COVERAGEPRODUCT = 117,

        /// <summary>Coverage Product Translation</summary>
        [XmlEnum("118")]
        OLI_COVERAGEPRODUCTXLAT = 118,

        /// <summary>Intent</summary>
        [XmlEnum("119")]
        OLI_INTENT = 119,

        /// <summary>StatusEvent</summary>
        [XmlEnum("120")]
        OLI_STATUSEVENT = 120,

        /// <summary>AbdomenMeasure</summary>
        [XmlEnum("121")]
        OLI_ABDOMENMEASURE = 121,

        /// <summary>AccountingStatement</summary>
        [XmlEnum("122")]
        OLI_ACCOUNTINGSTATEMENT = 122,

        /// <summary>AllowedRelationship</summary>
        [XmlEnum("123")]
        OLI_ALLOWEDRELATIONSHIP = 123,

        /// <summary>AnnuityProductExclude</summary>
        [XmlEnum("124")]
        OLI_ANNUITYPRODUCTEXCLUDE = 124,

        /// <summary>XTbML Content Classification</summary>
        [XmlEnum("125")]
        XTBML_CONTENTCLASSIFICATION = 125,

        /// <summary>XTbML MetaData</summary>
        [XmlEnum("126")]
        XTBML_METADATA = 126,

        /// <summary>KeyDef</summary>
        [XmlEnum("127")]
        XTBML_KEYDEF = 127,

        /// <summary>XTbML AxisDef</summary>
        [XmlEnum("128")]
        XTBML_AXISDEF = 128,

        /// <summary>AuthorizationTransaction</summary>
        [XmlEnum("130")]
        OLI_AUTHORIZATIONTRANSACTION = 130,

        /// <summary>ChargePctSchedule</summary>
        [XmlEnum("131")]
        OLI_CHARGEPCTSCHEDULE = 131,

        /// <summary>XTbML aggregate defined by XTbML schema</summary>
        [XmlEnum("132")]
        OLI_XTBML = 132,

        /// <summary>Exam</summary>
        [XmlEnum("133")]
        OLI_EXAM = 133,

        /// <summary>Department</summary>
        [XmlEnum("134")]
        LOI_DEPARTMENT = 134,

        /// <summary>Employment</summary>
        [XmlEnum("136")]
        OLI_EMPLOYMENT = 136,

        /// <summary>Financial Experience</summary>
        [XmlEnum("138")]
        OLI_FINANCIALEXPERIENCE = 138,

        /// <summary>Policy Product Info</summary>
        [XmlEnum("140")]
        OLI_POLICYPRODUCTINFO = 140,

        /// <summary>Payment Mode Method</summary>
        [XmlEnum("141")]
        OLI_PAYMENTMETHOD = 141,

        /// <summary>Cov Option Product</summary>
        [XmlEnum("154")]
        OLI_COVOPTIONPRODUCT = 154,

        /// <summary>UnderwritingClassProduct</summary>
        [XmlEnum("156")]
        OLI_UNDERWRITINGCLASSPRODUCT = 156,

        /// <summary>Life Product</summary>
        [XmlEnum("162")]
        OLI_LIFEPRODUCT = 162,

        /// <summary>Payment</summary>
        [XmlEnum("163")]
        OLI_PAYMENT = 163,

        /// <summary>Accounting Activity</summary>
        [XmlEnum("164")]
        OLI_ACCOUNTINGACTIVITY = 164,

        /// <summary>Reinsurance Info</summary>
        [XmlEnum("165")]
        OLI_REINSURANCEINFO = 165,

        /// <summary>Benefit Limit</summary>
        [XmlEnum("166")]
        OLI_BENEFITLIMIT = 166,

        /// <summary>PriorLTC</summary>
        [XmlEnum("167")]
        OLI_PRIORLTC = 167,

        /// <summary>Pharmacy</summary>
        [XmlEnum("168")]
        OLI_PHARMACY = 168,

        /// <summary>Physician</summary>
        [XmlEnum("169")]
        OLI_PHYSICIAN = 169,

        /// <summary>PhysicianInfo</summary>
        [XmlEnum("170")]
        OLI_PHYSICIANINFO = 170,

        /// <summary>PrescriptionDrug</summary>
        [XmlEnum("171")]
        OLI_PRESCRIPTIONDRUG = 171,

        /// <summary>PrescriptionFill</summary>
        [XmlEnum("172")]
        OLI_PRESCRIPTIONFILL = 172,

        /// <summary>OrganizationFinancialData</summary>
        [XmlEnum("173")]
        OLI_ORGANIZATIONFINANCIALDATA = 173,

        /// <summary>ChestForcedMeasure</summary>
        [XmlEnum("174")]
        OLI_CHESTFORCEDMEASURE = 174,

        /// <summary>ChestFullMeasure</summary>
        [XmlEnum("175")]
        OLI_CHESTFULLMEASURE = 175,

        /// <summary>CommOptionAvailable</summary>
        [XmlEnum("176")]
        OLI_COMMOPTIONAVAILABLE = 176,

        /// <summary>CovOptionProductXLat</summary>
        [XmlEnum("177")]
        OLI_COVOPTIONPRODUCTXLAT = 177,

        /// <summary>TaxWithholding</summary>
        [XmlEnum("178")]
        OLI_TAXWITHHOLDING = 178,

        /// <summary>SystemMessage</summary>
        [XmlEnum("179")]
        OLI_SYSTEMMESSAGE = 179,

        /// <summary>Endorsement</summary>
        [XmlEnum("180")]
        OLI_ENDORSEMENT = 180,

        /// <summary>Exclusion</summary>
        [XmlEnum("181")]
        OLI_EXCLUSION = 181,

        /// <summary>SubstandardRating</summary>
        [XmlEnum("182")]
        OLI_SUBSTANDARDRATING = 182,

        /// <summary>SettlementInfo</summary>
        [XmlEnum("183")]
        OLI_SETTLEMENTINFO = 183,

        /// <summary>SettlementDetail</summary>
        [XmlEnum("184")]
        OLI_SETTLEMENTDETAIL = 184,

        /// <summary>AnnuityProduct</summary>
        [XmlEnum("185")]
        OLI_ANNUITYPRODUCT = 185,

        /// <summary>Breakpoint</summary>
        [XmlEnum("186")]
        OLI_BREAKPOINT = 186,

        /// <summary>Fee</summary>
        [XmlEnum("187")]
        OLI_FEE = 187,

        /// <summary>Authorization</summary>
        [XmlEnum("188")]
        OLI_AUTHORIZATION = 188,

        /// <summary>Ownership</summary>
        [XmlEnum("189")]
        OLI_OWNERSHIP = 189,

        /// <summary>BusinessProcessAllowed</summary>
        [XmlEnum("190")]
        OLI_BUSINESSPROCESSALLOWED = 190,

        /// <summary>FeatureProduct</summary>
        [XmlEnum("191")]
        OLI_FEATUREPRODUCT = 191,

        /// <summary>IncomePayoutProductOption</summary>
        [XmlEnum("192")]
        OLI_INCOMEPAYOUTPRODUCTOPTION = 192,

        /// <summary>InvestProductRateVariation</summary>
        [XmlEnum("193")]
        OLI_INVESTPRODUCTRATEVARIATION = 193,

        /// <summary>InvestProductRateVariationByDuration</summary>
        [XmlEnum("194")]
        OLI_INVESTPRODUCTRATEVARIATIONBYDURATION = 194,

        /// <summary>InvestProductRateVariationByVolume</summary>
        [XmlEnum("195")]
        OLI_INVESTPRODUCTRATEVARIATIONBYVOLUME = 195,

        /// <summary>Allocation</summary>
        [XmlEnum("196")]
        OLI_ALLOCATION = 196,

        /// <summary>ProductRequisite</summary>
        [XmlEnum("197")]
        OLI_PRODUCTREQUISITE = 197,

        /// <summary>ProductConflict</summary>
        [XmlEnum("198")]
        OLI_PRODUCTCONFLICT = 198,

        /// <summary>SourceInfo</summary>
        [XmlEnum("199")]
        OLI_SOURCEINFO = 199,

        /// <summary>Commission Calc Activity</summary>
        [XmlEnum("200")]
        OLI_COMMISSIONCALCACTIVITY = 200,

        /// <summary>CommissionCalcDetail</summary>
        [XmlEnum("201")]
        OLI_COMMISSIONCALCDETAIL = 201,

        /// <summary>CommissionCalcInfo</summary>
        [XmlEnum("202")]
        OLI_COMMISSIONCALCINFO = 202,

        /// <summary>CommissionProduct</summary>
        [XmlEnum("203")]
        OLI_COMMISSIONPRODUCT = 203,

        /// <summary>CommissionStatement</summary>
        [XmlEnum("204")]
        OLI_COMMISSIONSTATEMENT = 204,

        /// <summary>RestrictionInfo</summary>
        [XmlEnum("205")]
        OLI_RESTRICTIONINFO = 205,

        /// <summary>FreelookInvestRuleProduct</summary>
        [XmlEnum("206")]
        OLI_FREELOOKINVESTRULEPRODUCT = 206,

        /// <summary>InvestRuleProduct</summary>
        [XmlEnum("207")]
        OLI_INVESTRULEPRODUCT = 207,

        /// <summary>NumInvestProduct</summary>
        [XmlEnum("208")]
        OLI_NUMINVESTPRODUCT = 208,

        /// <summary>LoanProvision</summary>
        [XmlEnum("209")]
        OLI_LOANPROVISION = 209,

        /// <summary>MinBalanceCalcRule</summary>
        [XmlEnum("210")]
        OLI_MINBALANCECALCRULE = 210,

        /// <summary>Dividend</summary>
        [XmlEnum("211")]
        OLI_DIVIDEND = 211,

        /// <summary>LapseProvision</summary>
        [XmlEnum("212")]
        OLI_LAPSEPROVISION = 212,

        /// <summary>NonForProvision</summary>
        [XmlEnum("213")]
        OLI_NONFORPROVISION = 213,

        /// <summary>Reward</summary>
        [XmlEnum("214")]
        OLI_REWARD = 214,

        /// <summary>AllowedSubstandard</summary>
        [XmlEnum("215")]
        OLI_ALLOWEDSUBSTANDARD = 215,

        /// <summary>RatingAgencyInfo</summary>
        [XmlEnum("216")]
        OLI_RATINGAGENCYINFO = 216,

        /// <summary>AmountProduct</summary>
        [XmlEnum("217")]
        OLI_AMOUNTPRODUCT = 217,

        /// <summary>FeatureOptProduct</summary>
        [XmlEnum("218")]
        OLI_FEATUREOPTPRODUCT = 218,

        /// <summary>FeatureRequisite</summary>
        [XmlEnum("219")]
        OLI_FEATUREREQUISITE = 219,

        /// <summary>FeatureConflict</summary>
        [XmlEnum("220")]
        OLI_FEATURECONFLICT = 220,

        /// <summary>Banking</summary>
        [XmlEnum("221")]
        OLI_BANKING = 221,

        /// <summary>AuthorizedSignatory</summary>
        [XmlEnum("222")]
        OLI_AUTHORIZEDSIGNATORY = 222,

        /// <summary>IllustrationReportRequest</summary>
        [XmlEnum("223")]
        OLI_ILLUSTRATIONREPORTREQUEST = 223,

        /// <summary>PreferredReqFulfiller</summary>
        [XmlEnum("224")]
        OLI_PREFERREDREQFULFILLER = 224,

        /// <summary>TrackingInfo</summary>
        [XmlEnum("225")]
        OLI_TRACKINGINFO = 225,

        /// <summary>LabTesting</summary>
        [XmlEnum("226")]
        OLI_LABTESTING = 226,

        /// <summary>LabTestResult</summary>
        [XmlEnum("227")]
        OLI_LABTESTRESULT = 227,

        /// <summary>LabTestRemark</summary>
        [XmlEnum("228")]
        OLI_LABTESTREMARK = 228,

        /// <summary>QualitativeResult</summary>
        [XmlEnum("229")]
        OLI_QUALITATIVERESULT = 229,

        /// <summary>QuantitativeResult</summary>
        [XmlEnum("230")]
        OLI_QUANTITATIVERESULT = 230,

        /// <summary>ReferenceRange</summary>
        [XmlEnum("231")]
        OLI_REFERENCERANGE = 231,

        /// <summary>SpecialTestOrdered</summary>
        [XmlEnum("232")]
        OLI_SPECIALTESTORDERED = 232,

        /// <summary>UrineTemperature</summary>
        [XmlEnum("233")]
        OLI_URINETEMPERATURE = 233,

        /// <summary>Kit</summary>
        [XmlEnum("234")]
        OLI_KIT = 234,

        /// <summary>Campaign</summary>
        [XmlEnum("235")]
        OLI_CAMPAIGN = 235,

        /// <summary>DestInvestProduct</summary>
        [XmlEnum("236")]
        OLI_DESTINVESTPRODUCT = 236,

        /// <summary>DistributionChannelInfo</summary>
        [XmlEnum("237")]
        OLI_DISTRIBUTIONCHANNELINFO = 237,

        /// <summary>EntityType</summary>
        [XmlEnum("238")]
        OLI_ENTITYTYPE = 238,

        /// <summary>Event</summary>
        [XmlEnum("239")]
        OLI_EVENT = 239,

        /// <summary>ExclusionInvestProduct</summary>
        [XmlEnum("240")]
        OLI_EXCLUSIONINVESTPRODUCT = 240,

        /// <summary>ExtendOrCall</summary>
        [XmlEnum("241")]
        OLI_EXTENDORCALL = 241,

        /// <summary>FinancialActivityInfo</summary>
        [XmlEnum("242")]
        OLI_FINANCIALACTIVITYINFO = 242,

        /// <summary>GovtIDInfo</summary>
        [XmlEnum("243")]
        OLI_GOVTIDINFO = 243,

        /// <summary>Height2</summary>
        [XmlEnum("244")]
        OLI_HEIGHT2 = 244,

        /// <summary>IncomeOptConflict</summary>
        [XmlEnum("245")]
        OLI_INCOMEOPTCONFLICT = 245,

        /// <summary>IncomeOptionInfo</summary>
        [XmlEnum("246")]
        OLI_INCOMEOPTINFO = 246,

        /// <summary>IncomeOptRequisite</summary>
        [XmlEnum("247")]
        OLI_INCOMEOPTREQUISITE = 247,

        /// <summary>InformationService</summary>
        [XmlEnum("248")]
        OLI_INFORMATIONSERVICE = 248,

        /// <summary>InvestmentSubTotalInfo</summary>
        [XmlEnum("249")]
        OLI_INVESTSUBTOTALINFO = 249,

        /// <summary>InvestProductInfoXLat</summary>
        [XmlEnum("250")]
        OLI_INVESTPRODUCTINFOXLAT = 250,

        /// <summary>JurisdictionApproval</summary>
        [XmlEnum("251")]
        OLI_JURISDICTIONAPPROVAL = 251,

        /// <summary>OLifEExtension</summary>
        [XmlEnum("252")]
        OLI_OLIFEEXTENSION = 252,

        /// <summary>PeriodicBalanceYTDInfo</summary>
        [XmlEnum("253")]
        OLI_PERIODICBALANCEYTDINFO = 253,

        /// <summary>PolicyActivityList</summary>
        [XmlEnum("254")]
        OLI_POLICYACTIVITYLIST = 254,

        /// <summary>ProducerAgreement</summary>
        [XmlEnum("255")]
        OLI_PRODUCERAGREEMENT = 255,

        /// <summary>QualifiedPlanEntity</summary>
        [XmlEnum("256")]
        OLI_QUALIFIEDPLANENTITY = 256,

        /// <summary>RegistrationJurisdiction</summary>
        [XmlEnum("257")]
        OLI_REGISTRATIONJURISDICTION = 257,

        /// <summary>ResultsReceiverParty</summary>
        [XmlEnum("258")]
        OLI_RESULTSRECEIVERPARTY = 258,

        /// <summary>SourceInvestProduct</summary>
        [XmlEnum("259")]
        OLI_SOURCEINVESTPRODUCT = 259,

        /// <summary>Superannuation</summary>
        [XmlEnum("260")]
        OLI_SUPERANNUATION = 260,

        /// <summary>SurrenderChargeSchedule</summary>
        [XmlEnum("261")]
        OLI_SURRENDERCHARGESCHEDULE = 261,

        /// <summary>Education</summary>
        [XmlEnum("263")]
        OLI_EDUCATION = 263,

        /// <summary>Registration</summary>
        [XmlEnum("264")]
        OLI_REGISTRATION = 264,

        /// <summary>UnderwritingClassProductXLat</summary>
        [XmlEnum("265")]
        OLI_UNDERWRITINGCLASSPRODUCTXLAT = 265,

        /// <summary>LineOfAuthority</summary>
        [XmlEnum("266")]
        OLI_LINEOFAUTHORITY = 266,

        /// <summary>Values</summary>
        [XmlEnum("267")]
        OLI_VALUES = 267,

        /// <summary>PropertyandCasualty</summary>
        [XmlEnum("268")]
        OLI_PROPERTYANDCASUALTY = 268,

        /// <summary>Weight2</summary>
        [XmlEnum("269")]
        OLI_WEIGHT2 = 269,

        /// <summary>Unknown object 270</summary>
        [XmlEnum("270")]
        OLI_OBJ_270 = 270,

        /// <summary>DistributionAgreement</summary>
        [XmlEnum("271")]
        OLI_DISTRIBUTATIONAGREEMENT = 271,

        /// <summary>CommRemittance</summary>
        [XmlEnum("272")]
        OLI_COMMREMITTANCE = 272,

        /// <summary>Unknown object 273</summary>
        [XmlEnum("273")]
        OLI_OBJ_273 = 273,

        /// <summary>CommSchedule</summary>
        [XmlEnum("274")]
        OLI_COMMSCHEDULE = 274,

        /// <summary>CommFormula</summary>
        [XmlEnum("275")]
        OLI_COMMFORMULA = 275,

        /// <summary>DistributionAgreementInfo</summary>
        [XmlEnum("276")]
        OLI_DISTRIBUTIONAGREEMENTINFO = 276,

        /// <summary>FundingSourceMethodsAllowed</summary>
        [XmlEnum("277")]
        OLI_FUNDINGSOURCEMETHODSALLOWED = 277,

        /// <summary>Unknown object 278</summary>
        [XmlEnum("278")]
        OLI_OBJ_278 = 278,

        /// <summary>Unknown object 279</summary>
        [XmlEnum("279")]
        OLI_OBJ_279 = 279,

        /// <summary>Unknown object 280</summary>
        [XmlEnum("280")]
        OLI_OBJ_280 = 280,

        /// <summary>ScheduledChange</summary>
        [XmlEnum("281")]
        OLI_SCHEDULEDCHANGE = 281,

        /// <summary>MedicalEquipment</summary>
        [XmlEnum("282")]
        OLI_MEDICALEQUIPMENT = 282,

        /// <summary>CardiacMurmur</summary>
        [XmlEnum("283")]
        OLI_CARDIACMURMER = 283,

        /// <summary>Unknown object 284</summary>
        [XmlEnum("284")]
        OLI_OBJ_284 = 284,

        /// <summary>Unknown object 285</summary>
        [XmlEnum("285")]
        OLI_OBJ_285 = 285,

        /// <summary>Unknown object 286</summary>
        [XmlEnum("286")]
        OLI_OBJ_286 = 286,

        /// <summary>Unknown object 287</summary>
        [XmlEnum("287")]
        OLI_OBJ_287 = 287,

        /// <summary>Unknown object 288</summary>
        [XmlEnum("288")]
        OLI_OBJ_288 = 288,

        /// <summary>Unknown object 289</summary>
        [XmlEnum("289")]
        OLI_OBJ_289 = 289,

        /// <summary>URL</summary>
        [XmlEnum("290")]
        OLI_URL = 290,

        /// <summary>DistributionLevel</summary>
        [XmlEnum("291")]
        OLI_DISTRIBUTIONLEVEL = 291,

        /// <summary>Unknown object 292</summary>
        [XmlEnum("292")]
        OLI_OBJ_292 = 292,

        /// <summary>Unknown object 293</summary>
        [XmlEnum("293")]
        OLI_OBJ_293 = 293,

        /// <summary>Unknown object 294</summary>
        [XmlEnum("294")]
        OLI_OBJ_294 = 294,

        /// <summary>Unknown object 295</summary>
        [XmlEnum("295")]
        OLI_OBJ_295 = 295,

        /// <summary>Unknown object 296</summary>
        [XmlEnum("296")]
        OLI_OBJ_296 = 296,

        /// <summary>Unknown object 297</summary>
        [XmlEnum("297")]
        OLI_OBJ_297 = 297,

        /// <summary>Unknown object 298</summary>
        [XmlEnum("298")]
        OLI_OBJ_298 = 298,

        /// <summary>Unknown object 299</summary>
        [XmlEnum("299")]
        OLI_OBJ_299 = 299,

        /// <summary>TableRef</summary>
        [XmlEnum("300")]
        OLI_TABLEREF = 300,

        /// <summary>IdentityVerification</summary>
        [XmlEnum("301")]
        OLI_IDENTITYVERIFICATION = 301,

        /// <summary>Identification</summary>
        [XmlEnum("302")]
        OLI_IDENTIFICATION = 302,

        /// <summary>VerifierParticipant</summary>
        [XmlEnum("303")]
        OLI_VERIFIERPARTICIPANT = 303,

        /// <summary>LifeUSAProduct</summary>
        [XmlEnum("304")]
        OLI_LIFEUSAPRODUCT = 304,

        /// <summary>IRSPremCalcMethod</summary>
        [XmlEnum("305")]
        OLI_IRSPREMCALCMETHOD = 305,

        /// <summary>Market</summary>
        [XmlEnum("306")]
        OLI_MARKET = 306,

        /// <summary>FeatureTransactionProduct</summary>
        [XmlEnum("307")]
        OLI_FEATURETRANSACTIONPRODUCT = 307,

        /// <summary>FeatureProductInfo</summary>
        [XmlEnum("308")]
        OLI_FEATUREPRODUCTINFO = 308,

        /// <summary>AdminTransactionProduct</summary>
        [XmlEnum("309")]
        OLI_ADMINTRANSACTIONPRODUCT = 309,

        /// <summary>PolicyStatusCC</summary>
        [XmlEnum("310")]
        OLI_POLICYSTATUSCC = 310,

        /// <summary>ClaimEstimate</summary>
        [XmlEnum("311")]
        OLI_CLAIMESTIMATE = 311,

        /// <summary>AdditionalInterestRateInfo</summary>
        [XmlEnum("312")]
        OLI_ADDITIONALINTERESTRATEINFO = 312,

        /// <summary>SitusInfo</summary>
        [XmlEnum("313")]
        OLI_SITUSINFO = 313,

        /// <summary>RegulatoryDistAgreement</summary>
        [XmlEnum("314")]
        OLI_REGULATORYDISTAGREEMENT = 314,

        /// <summary>ProductTypeInfo</summary>
        [XmlEnum("315")]
        OLI_PRODUCTTYPEINFO = 315,

        /// <summary>DistinguishedObject</summary>
        [XmlEnum("316")]
        OLI_DISTINGUISHEDOBJECT = 316,

        /// <summary>PremiumRate</summary>
        [XmlEnum("317")]
        OLI_PREMIUMRATE = 317,

        /// <summary>DividendRate</summary>
        [XmlEnum("318")]
        OLI_DIVIDENDRATE = 318,

        /// <summary>CashValueRate</summary>
        [XmlEnum("319")]
        OLI_CASHVALUERATE = 319,

        /// <summary>COIRate</summary>
        [XmlEnum("320")]
        OLI_COIRATE = 320,

        /// <summary>CauseOfDeath</summary>
        [XmlEnum("321")]
        OLI_CAUSEOFDEATH = 321,

        /// <summary>AccountDesignationCC</summary>
        [XmlEnum("323")]
        OLI_ACCOUNTDESIGNATIONCC = 323,

        /// <summary>AllocTypeProduct</summary>
        [XmlEnum("326")]
        OLI_ALLOCTYPEPRODUCT = 326,

        /// <summary>AllowedDayCC</summary>
        [XmlEnum("327")]
        OLI_ALLOWEDDAYCC = 327,

        /// <summary>ApptCounty</summary>
        [XmlEnum("332")]
        OLI_APPTCOUNTY = 332,

        /// <summary>AssociatedResponseData</summary>
        [XmlEnum("335")]
        OLI_ASSOCIATEDRESPONSEDATA = 335,

        /// <summary>AssumedInterestRateCC</summary>
        [XmlEnum("336")]
        OLI_ASSUMEDINTERESTRATECC = 336,

        /// <summary>AuthorizationEntityCC</summary>
        [XmlEnum("337")]
        OLI_AUTHORIZATIONENTITYCC = 337,

        /// <summary>Axis</summary>
        [XmlEnum("340")]
        OLI_AXIS = 340,

        /// <summary>AxisDef</summary>
        [XmlEnum("341")]
        OLI_AXISDEF = 341,

        /// <summary>BestDayToCallCC</summary>
        [XmlEnum("343")]
        OLI_BESTDAYTOCALLCC = 343,

        /// <summary>BillingDetail</summary>
        [XmlEnum("344")]
        OLI_BILLINGDETAIL = 344,

        /// <summary>BillingStatement</summary>
        [XmlEnum("345")]
        OLI_BILLINGSTATEMENT = 345,

        /// <summary>BusinessMethodCC</summary>
        [XmlEnum("346")]
        OLI_BUSINESSMETHODCC = 346,

        /// <summary>BusinessProcessCC</summary>
        [XmlEnum("347")]
        OLI_BUSINESSPROCESSCC = 347,

        /// <summary>ChangeSubType</summary>
        [XmlEnum("348")]
        OLI_CHANGESUBTYPE = 348,

        /// <summary>COLIndexCapCC</summary>
        [XmlEnum("352")]
        OLI_COLINDEXCAPCC = 352,

        /// <summary>COLIndexCC</summary>
        [XmlEnum("353")]
        OLI_COLINDEXCC = 353,

        /// <summary>CommissionDetail</summary>
        [XmlEnum("355")]
        OLI_COMMISSIONDETAIL = 355,

        /// <summary>CommissionLinkCC</summary>
        [XmlEnum("356")]
        OLI_COMMISSIONLINKCC = 356,

        /// <summary>ContentClassification</summary>
        [XmlEnum("358")]
        OLI_CONTENTCLASSIFICATION = 358,

        /// <summary>ContingentJointCC</summary>
        [XmlEnum("359")]
        OLI_CONTINGENTJOINTCC = 359,

        /// <summary>Coverage</summary>
        [XmlEnum("360")]
        OLI_COVERAGE = 360,

        /// <summary>CriminalConviction</summary>
        [XmlEnum("368")]
        OLI_CRIMINALCONVICTION = 368,

        /// <summary>CriteriaExpression</summary>
        [XmlEnum("369")]
        OLI_CRITERIAEXPRESSION = 369,

        /// <summary>DataTransmittalSubType</summary>
        [XmlEnum("370")]
        OLI_DATATRANSMITTALSUBTYPE = 370,

        /// <summary>DeathBenefitOptCC</summary>
        [XmlEnum("371")]
        OLI_DEATHBENEFITOPTCC = 371,

        /// <summary>DefLifeInsMethodCC</summary>
        [XmlEnum("372")]
        OLI_DEFLIFEINSMETHODCC = 372,

        /// <summary>DistributionChannelCC</summary>
        [XmlEnum("374")]
        OLI_DISTRIBUTIONCHANNELCC = 374,

        /// <summary>Extension</summary>
        [XmlEnum("379")]
        OLI_EXTENSION = 379,

        /// <summary>FamilyIllness</summary>
        [XmlEnum("380")]
        OLI_FAMILYILLNESS = 380,

        /// <summary>FeatureOptConflict</summary>
        [XmlEnum("381")]
        OLI_FEATUREOPTCONFLICT = 381,

        /// <summary>FeatureOptRequisite</summary>
        [XmlEnum("382")]
        OLI_FEATUREOPTREQUISITE = 382,

        /// <summary>FinActivityTypeCC</summary>
        [XmlEnum("383")]
        OLI_FINACTIVITYTYPECC = 383,

        /// <summary>FinancialActivity</summary>
        [XmlEnum("384")]
        OLI_FINANCIALACTIVITY = 384,

        /// <summary>FinancialStatement</summary>
        [XmlEnum("387")]
        OLI_FINANCIALSTATEMENT = 387,

        /// <summary>FormInstanceDestination</summary>
        [XmlEnum("389")]
        OLI_FORMINSTANCEDESTINATION = 389,

        /// <summary>FormInstanceRequest</summary>
        [XmlEnum("390")]
        OLI_FORMINSTANCEREQUEST = 390,

        /// <summary>HHFamilyInsurance</summary>
        [XmlEnum("394")]
        OLI_HHFAMILYINSURANCE = 394,

        /// <summary>IllustrationRequest</summary>
        [XmlEnum("396")]
        OLI_ILLUSTRATIONREQUEST = 396,

        /// <summary>IllustrationResult</summary>
        [XmlEnum("397")]
        OLI_ILLUSTRATIONRESULT = 397,

        /// <summary>IllustrationTxn</summary>
        [XmlEnum("398")]
        OLI_ILLUSTRATIONTXN = 398,

        /// <summary>IncomeOptionCC</summary>
        [XmlEnum("400")]
        OLI_INCOMEOPTIONCC = 400,

        /// <summary>IncomeOptionInfo</summary>
        [XmlEnum("401")]
        OLI_INCOMEOPTIONINFO = 401,

        /// <summary>InvestmentSubTotalInfo</summary>
        [XmlEnum("404")]
        OLI_INVESTMENTSUBTOTALINFO = 404,

        /// <summary>IssueGenderCC</summary>
        [XmlEnum("408")]
        OLI_ISSUEGENDERCC = 408,

        /// <summary>JurisdictionCC</summary>
        [XmlEnum("410")]
        OLI_JURISDICTIONCC = 410,

        /// <summary>Key</summary>
        [XmlEnum("411")]
        OLI_KEY = 411,

        /// <summary>KeyDef</summary>
        [XmlEnum("412")]
        OLI_KEYDEF = 412,

        /// <summary>LevelizationOptionCC</summary>
        [XmlEnum("413")]
        OLI_LEVELIZATIONOPTIONCC = 413,

        /// <summary>LineOfAuthorityCC</summary>
        [XmlEnum("415")]
        OLI_LINEOFAUTHORITYCC = 415,

        /// <summary>LoanIntMethodCC</summary>
        [XmlEnum("416")]
        OLI_LOANINTMETHODCC = 416,

        /// <summary>MedicalCondition</summary>
        [XmlEnum("417")]
        OLI_MEDICALCONDITION = 417,

        /// <summary>MedicalExam</summary>
        [XmlEnum("418")]
        OLI_MEDICALEXAM = 418,

        /// <summary>MedicalPrevention</summary>
        [XmlEnum("419")]
        OLI_MEDICALPREVENTION = 419,

        /// <summary>MedicalTreatment</summary>
        [XmlEnum("420")]
        OLI_MEDICALTREATMENT = 420,

        /// <summary>MetaData</summary>
        [XmlEnum("421")]
        OLI_METADATA = 421,

        /// <summary>MIBRequest</summary>
        [XmlEnum("422")]
        OLI_MIBREQUEST = 422,

        /// <summary>MIBServiceDescriptor</summary>
        [XmlEnum("423")]
        OLI_MIBSERVICEDESCRIPTOR = 423,

        /// <summary>MIBServiceOptions</summary>
        [XmlEnum("424")]
        OLI_MIBSERVICEOPTIONS = 424,

        /// <summary>ObjectTypeCC</summary>
        [XmlEnum("425")]
        OLI_OBJECTTYPECC = 425,

        /// <summary>OLifE</summary>
        [XmlEnum("426")]
        OLI_OLIFE = 426,

        /// <summary>Participant</summary>
        [XmlEnum("428")]
        OLI_PARTICIPANT = 428,

        /// <summary>PaymentFormCC</summary>
        [XmlEnum("430")]
        OLI_PAYMENTFORMCC = 430,

        /// <summary>PaymentModeMethProduct</summary>
        [XmlEnum("431")]
        OLI_PAYMENTMODEMETHPRODUCT = 431,

        /// <summary>PaymentSourceCC</summary>
        [XmlEnum("432")]
        OLI_PAYMENTSOURCECC = 432,

        /// <summary>PeriodCertainCC</summary>
        [XmlEnum("433")]
        OLI_PERIODCERTAINCC = 433,

        /// <summary>PolicyIssueTypeCC</summary>
        [XmlEnum("436")]
        OLI_POLICYISSUETYPECC = 436,

        /// <summary>ProxyVendor</summary>
        [XmlEnum("440")]
        OLI_PROXYVENDOR = 440,

        /// <summary>QualifiedPlanCC</summary>
        [XmlEnum("441")]
        OLI_QUALIFIEDPLANCC = 441,

        /// <summary>RateVariation</summary>
        [XmlEnum("443")]
        OLI_RATEVARIATION = 443,

        /// <summary>RateVariationByDuration</summary>
        [XmlEnum("444")]
        OLI_RATEVARIATIONBYDURATION = 444,

        /// <summary>RateVariationByVolume</summary>
        [XmlEnum("445")]
        OLI_RATEVARIATIONBYVOLUME = 445,

        /// <summary>ReinsuranceRequest</summary>
        [XmlEnum("448")]
        OLI_REINSURANCEREQUEST = 448,

        /// <summary>RelationshipCC</summary>
        [XmlEnum("449")]
        OLI_RELATIONSHIPCC = 449,

        /// <summary>RequestBasis</summary>
        [XmlEnum("450")]
        OLI_REQUESTBASIS = 450,

        /// <summary>ResultBasis</summary>
        [XmlEnum("451")]
        OLI_RESULTBASIS = 451,

        /// <summary>ResultInfo</summary>
        [XmlEnum("452")]
        OLI_RESULTINFO = 452,

        /// <summary>Rider</summary>
        [XmlEnum("454")]
        OLI_RIDER = 454,

        /// <summary>ScenarioParticipant</summary>
        [XmlEnum("455")]
        OLI_SCENARIOPARTICIPANT = 455,

        /// <summary>ScheduledPaymentCC</summary>
        [XmlEnum("456")]
        OLI_SCHEDULEDPAYMENTCC = 456,

        /// <summary>SourceOfFundsCC</summary>
        [XmlEnum("460")]
        OLI_SOURCEOFFUNDSCC = 460,

        /// <summary>SplitPctIncrementsCC</summary>
        [XmlEnum("461")]
        OLI_SPLITPCTINCREMENTSCC = 461,

        /// <summary>StatusReceiverParty</summary>
        [XmlEnum("462")]
        OLI_STATUSRECEIVERPARTY = 462,

        /// <summary>Superannuation</summary>
        [XmlEnum("463")]
        OLI_SUPERANNUATION1 = 463,

        /// <summary>Table</summary>
        [XmlEnum("465")]
        OLI_TABLE = 465,

        /// <summary>TargetURL</summary>
        [XmlEnum("466")]
        OLI_TARGETURL = 466,

        /// <summary>TransResult</summary>
        [XmlEnum("467")]
        OLI_TRANSRESULT = 467,

        /// <summary>TrustTypeCC</summary>
        [XmlEnum("468")]
        OLI_TRUSTTYPECC = 468,

        /// <summary>TXLife</summary>
        [XmlEnum("469")]
        OLI_TXLIFE = 469,

        /// <summary>TXLifeNotify</summary>
        [XmlEnum("470")]
        OLI_TXLIFENOTIFY = 470,

        /// <summary>TXLifeRequest</summary>
        [XmlEnum("471")]
        OLI_TXLIFEREQUEST = 471,

        /// <summary>TXLifeResponse</summary>
        [XmlEnum("472")]
        OLI_TXLIFERESPONSE = 472,

        /// <summary>UserAuthRequest</summary>
        [XmlEnum("474")]
        OLI_USERAUTHREQUEST = 474,

        /// <summary>UserAuthResponse</summary>
        [XmlEnum("475")]
        OLI_USERAUTHRESPONSE = 475,

        /// <summary>UserPswd</summary>
        [XmlEnum("476")]
        OLI_USERPSWD = 476,

        /// <summary>Vector</summary>
        [XmlEnum("478")]
        OLI_VECTOR = 478,

        /// <summary>VectorItem</summary>
        [XmlEnum("479")]
        OLI_VECTORITEM = 479,

        /// <summary>VectorRequest</summary>
        [XmlEnum("480")]
        OLI_VECTORREQUEST = 480,

        /// <summary>VendorApp</summary>
        [XmlEnum("481")]
        OLI_VENDORAPP = 481,

        /// <summary>RateOfReturnInfo</summary>
        [XmlEnum("484")]
        OLI_RATEOFRETURNINFO = 484,

        /// <summary>PayoutChange</summary>
        [XmlEnum("485")]
        OLI_PAYOUTCHANGE = 485,

        /// <summary>LogicalExpression</summary>
        [XmlEnum("486")]
        OLI_LOGICALEXPRESSION = 486,

        /// <summary>LogicalCriteria</summary>
        [XmlEnum("487")]
        OLI_LOGICALCRITERIA = 487,

        /// <summary>LifeStyleViolation</summary>
        [XmlEnum("488")]
        OLI_LIFESTYLEVIOLATION = 488,

        /// <summary>DateCollection</summary>
        [XmlEnum("489")]
        OLI_DATECOLLECTION = 489,

        /// <summary>ClaimMedConditionInfo</summary>
        [XmlEnum("490")]
        OLI_CLAIMMEDCONDITIONINFO = 490,

        /// <summary>ContingencyBenefitChange</summary>
        [XmlEnum("491")]
        OLI_CONTINGENCYBENEFITCHANGE = 491,

        /// <summary>AllowedChange</summary>
        [XmlEnum("492")]
        OLI_ALLOWEDCHANGE = 492,

        /// <summary>AllowedPercent</summary>
        [XmlEnum("493")]
        OLI_ALLOWEDPERCENT = 493,

        /// <summary>PolicyValues</summary>
        [XmlEnum("494")]
        OLI_POLICYVALUES = 494,

        /// <summary>LostCapability</summary>
        [XmlEnum("495")]
        OLI_LOSTCAPABILITY = 495,

        /// <summary>ComplexContentDescriptor</summary>
        [XmlEnum("496")]
        OLI_COMPLEXCONTENTDESCRIPTOR = 496,

        /// <summary>ClaimMedTreatmentInfo</summary>
        [XmlEnum("497")]
        OLI_CLAIMMEDTREATMENTINFO = 497,

        /// <summary>RequisiteInvestProduct</summary>
        [XmlEnum("498")]
        OLI_REQUISITEINVESTPRODUCT = 498,

        /// <summary>ClaimReview</summary>
        [XmlEnum("499")]
        OLI_CLAIMREVIEW = 499,

        /// <summary>InquiryView</summary>
        [XmlEnum("500")]
        OLI_INQUIRYVIEW = 500,

        /// <summary>ObjectTypeInfo</summary>
        [XmlEnum("501")]
        OLI_OBJECTTYPEINFO = 501,

        /// <summary>RelationRoleCodeCC</summary>
        [XmlEnum("502")]
        OLI_RELATIONROLECODECC = 502,

        /// <summary>ParticipantRoleCodeCC</summary>
        [XmlEnum("503")]
        OLI_PARTICIPANTROLECODECC = 503,

        /// <summary>AssociatedObjectInfo</summary>
        [XmlEnum("504")]
        OLI_ASSOCIATEDOBJECTINFO = 504,

        /// <summary>AssocParticipantObjectInfo</summary>
        [XmlEnum("505")]
        OLI_ASSOCPARTICIPANTOBJECTINFO = 505,

        /// <summary>LoanActivity</summary>
        [XmlEnum("506")]
        OLI_LOANACTIVITY = 506,

        /// <summary>PolicyStatement</summary>
        [XmlEnum("507")]
        OLI_POLICYSTATEMENT = 507,

        /// <summary>PolicyStatementDetail</summary>
        [XmlEnum("508")]
        OLI_POLICYSTATEMENTDETAIL = 508,

        /// <summary>Case</summary>
        [XmlEnum("509")]
        OLI_CASE = 509,

        /// <summary>InvestmentStatement</summary>
        [XmlEnum("510")]
        OLI_INVESTMENTSTATEMENT = 510,

        /// <summary>SubAccountStatement</summary>
        [XmlEnum("511")]
        OLI_SUBACCOUNTSTATEMENT = 511,

        /// <summary>SubAccountStatementDetail</summary>
        [XmlEnum("512")]
        OLI_SUBACCOUNTSTATEMENTDETAIL = 512,

        /// <summary>InvestmentStatementDetail</summary>
        [XmlEnum("513")]
        OLI_INVESTMENTSTATEMENTDETAIL = 513,

        /// <summary>DisabilityHealthProduct</summary>
        [XmlEnum("514")]
        OLI_DISABILITYHEALTHPRODUCT = 514,

        /// <summary>RiderProduct</summary>
        [XmlEnum("515")]
        OLI_RIDERPRODUCT = 515,

        /// <summary>DisabilityHealthProvisions</summary>
        [XmlEnum("516")]
        OLI_DISABILITYHEALTHPROVISIONS = 516,

        /// <summary>ElimPeriodAccOption</summary>
        [XmlEnum("517")]
        OLI_ELIMPERIODACCOPTION = 517,

        /// <summary>ElimPeriodSickOption</summary>
        [XmlEnum("518")]
        OLI_ELIMPERIODSICKOPTION = 518,

        /// <summary>BenePeriodAccOption</summary>
        [XmlEnum("519")]
        OLI_BENEPERIODACCOPTION = 519,

        /// <summary>BenePeriodSickOption</summary>
        [XmlEnum("520")]
        OLI_BENEPERIODSICKOPTION = 520,

        /// <summary>EmploymentClassOption</summary>
        [XmlEnum("521")]
        OLI_EMPLOYMENTCLASSOPTION = 521,

        /// <summary>OccupClassOption</summary>
        [XmlEnum("522")]
        OLI_OCCUPCLASSOPTION = 522,

        /// <summary>HealthServiceOption</summary>
        [XmlEnum("523")]
        OLI_HEALTHSERVICEOPTION = 523,

        /// <summary>NatureSubCategoryOption</summary>
        [XmlEnum("524")]
        OLI_NATURESUBCATEGORYOPTION = 524,

        /// <summary>MedProviderOption</summary>
        [XmlEnum("525")]
        OLI_MEDPROVIDEROPTION = 525,

        /// <summary>ProviderClassOption</summary>
        [XmlEnum("526")]
        OLI_PROVIDERCLASSOPTION = 526,

        /// <summary>ConditionTypeOption</summary>
        [XmlEnum("527")]
        OLI_CONDITIONTYPEOPTION = 527,

        /// <summary>MannerOfLossOption</summary>
        [XmlEnum("528")]
        OLI_MANNEROFLOSSOPTION = 528,

        /// <summary>DeductionOption</summary>
        [XmlEnum("529")]
        OLI_DEDUCTIONOPTION = 529,

        /// <summary>BenefitLimitOption</summary>
        [XmlEnum("530")]
        OLI_BENEFITLIMITOPTION = 530,

        /// <summary>ManagedCareOption</summary>
        [XmlEnum("531")]
        OLI_MANAGEDCAREOPTION = 531,

        /// <summary>AdditionalRiderClassification</summary>
        [XmlEnum("532")]
        OLI_ADDITIONALRIDERCLASSIFICATION = 532,

        /// <summary>DeathBenefitOptionInfo</summary>
        [XmlEnum("533")]
        OLI_DEATHBENEFITOPTIONINFO = 533,

        /// <summary>ArrangementProduct</summary>
        [XmlEnum("534")]
        OLI_ARRANGEMENTPRODUCT = 534,

        /// <summary>ArrangementOptProduct</summary>
        [XmlEnum("535")]
        OLI_ARRANGEMENTOPTPRODUCT = 535,

        /// <summary>ConflictObjectInfo</summary>
        [XmlEnum("536")]
        OLI_CONFLICTOBJECTINFO = 536,

        /// <summary>RequisiteObjectInfo</summary>
        [XmlEnum("537")]
        OLI_REQUISITEOBJECTINFO = 537,

        /// <summary>LifeCanada</summary>
        [XmlEnum("538")]
        OLI_LIFECANADA = 538,

        /// <summary>AdditionalArrClassification</summary>
        [XmlEnum("539")]
        OLI_ADDITIONALARRCLASSIFICATION = 539,

        /// <summary>PolicyOptionInfo</summary>
        [XmlEnum("540")]
        OLI_POLICYOPTIONINFO = 540,

        /// <summary>OccurrenceLimitInfo</summary>
        [XmlEnum("541")]
        OLI_OCCURRENCELIMITINFO = 541,

        /// <summary>OccurrenceTier</summary>
        [XmlEnum("542")]
        OLI_OCCURRENCETIER = 542,

        /// <summary>ParticipantProduct</summary>
        [XmlEnum("543")]
        OLI_PARTICIPANTPRODUCT = 543,

        /// <summary>RelatedParticipantProductInfo</summary>
        [XmlEnum("544")]
        OLI_RELATEDPARTICIPANTPRODUCTINFO = 544,

        /// <summary>RelationshipInfo</summary>
        [XmlEnum("545")]
        OLI_RELATIONSHIPINFO = 545,

        /// <summary>AgeAmtProduct</summary>
        [XmlEnum("546")]
        OLI_AGEAMTPRODUCT = 546,

        /// <summary>TaxWithholdingProduct</summary>
        [XmlEnum("547")]
        OLI_TAXWITHHOLDINGPRODUCT = 547,

        /// <summary>UnderwritingReview</summary>
        [XmlEnum("548")]
        OLI_UNDERWRITINGREVIEW = 548,

        /// <summary>UserAuthentication</summary>
        [XmlEnum("549")]
        OLI_USERAUTHENTICATION = 549,

        /// <summary>UnderwritingResult</summary>
        [XmlEnum("550")]
        OLI_UNDERWRITINGRESULT = 550,

        /// <summary>AllowedDistributionAgreement</summary>
        [XmlEnum("551")]
        OLI_ALLOWEDDISTRIBUTIONAGREEMENT = 551,

        /// <summary>NotificationInfo</summary>
        [XmlEnum("552")]
        OLI_NOTIFICATIONINFO = 552,

        /// <summary>NotificationDestination</summary>
        [XmlEnum("553")]
        OLI_NOTIFICATIONDESTINATION = 553,

        /// <summary>QualifiedPlanOption</summary>
        [XmlEnum("554")]
        OLI_QUALIFIEDPLANOPTION = 554,

        /// <summary>UnionInvolvementInfo</summary>
        [XmlEnum("555")]
        OLI_UNIONINVOLVEMENTINFO = 555,

        /// <summary>GroupPolicy</summary>
        [XmlEnum("556")]
        OLI_GROUPPOLICY = 556,

        /// <summary>EligibleDependents</summary>
        [XmlEnum("557")]
        OLI_ELIGIBLEDEPENDENTS = 557,

        /// <summary>LevelizationProductOption</summary>
        [XmlEnum("558")]
        OLI_LEVELIZATIONPRODUCTOPTION = 558,

        /// <summary>InheritedTimingAllowed</summary>
        [XmlEnum("559")]
        OLI_INHERITEDTIMINGALLOWED = 559,

        /// <summary>InvoiceDetail</summary>
        [XmlEnum("560")]
        OLI_INVOICEDETAIL = 560,

        /// <summary>LimitVariation</summary>
        [XmlEnum("561")]
        OLI_LIMITVARIATION = 561,

        /// <summary>ScheduledBonus</summary>
        [XmlEnum("562")]
        OLI_SCHEDULEDBONUS = 562,

        /// <summary>AllowedTransType</summary>
        [XmlEnum("563")]
        OLI_ALLOWEDTRANSTYPE = 563,

        /// <summary>GroupCoverage</summary>
        [XmlEnum("564")]
        OLI_GROUPCOVERAGE = 564,

        /// <summary>GroupCovOption</summary>
        [XmlEnum("565")]
        OLI_GROUPCOVOPTION = 565,

        /// <summary>ReductionScheduleInfo</summary>
        [XmlEnum("566")]
        OLI_REDUCTIONSCHEDULEINFO = 566,

        /// <summary>DeliveryInfo</summary>
        [XmlEnum("567")]
        OLI_DELIVERYINFO = 567,

        /// <summary>DeliveryDestination</summary>
        [XmlEnum("568")]
        OLI_DELIVERYDESTINATION = 568,

        /// <summary>InvoiceRequirementInfo</summary>
        [XmlEnum("569")]
        OLI_INVOICEREQUIREMENTINFO = 569,

        /// <summary>ExchangeReason</summary>
        [XmlEnum("570")]
        OLI_EXCHANGEREASON = 570,

        /// <summary>RateInfo</summary>
        [XmlEnum("571")]
        OLI_RATEINFO = 571,

        /// <summary>SpeedDial</summary>
        [XmlEnum("572")]
        OLI_SPEEDDIAL = 572,

        /// <summary>DesignationInfo</summary>
        [XmlEnum("573")]
        OLI_DESIGNATIONINFO = 573,

        /// <summary>ProcessingInstruction</summary>
        [XmlEnum("574")]
        OLI_PROCESSINGINSTRUCTION = 574,

        /// <summary>ReturnOfPremium</summary>
        [XmlEnum("575")]
        OLI_RETURNOFPREMIUM = 575,

        /// <summary>NationApproval</summary>
        [XmlEnum("576")]
        OLI_NATIONAPPROVAL = 576,

        /// <summary>AnnualIndexOption</summary>
        [XmlEnum("577")]
        OLI_ANNUALINDEXOPTION = 577,

        /// <summary>ReconciliationSummary</summary>
        [XmlEnum("579")]
        OLI_RECONCILIATIONSUMMARY = 579,

        /// <summary>ReconciliationDetail</summary>
        [XmlEnum("580")]
        OLI_RECONCILIATIONDETAIL = 580,

        /// <summary>AllowedFeatureTransaction</summary>
        [XmlEnum("581")]
        OLI_ALLOWEDFEATURETRANSACTION = 581,

        /// <summary>MedicalCertClass</summary>
        [XmlEnum("582")]
        OLI_MEDICALCERTCLASS = 582,

        /// <summary>AirmanCertClass</summary>
        [XmlEnum("583")]
        OLI_AIRMANCERTCLASS = 583,

        /// <summary>Aircraft</summary>
        [XmlEnum("584")]
        OLI_AIRCRAFT = 584,

        /// <summary>LifeStyleActivityPeril</summary>
        [XmlEnum("585")]
        OLI_LIFESTYLEACTIVITYPERIL = 585,

        /// <summary>GeographicRegion</summary>
        [XmlEnum("586")]
        OLI_GEOGRAPHICREGION = 586,

        /// <summary>Terrain</summary>
        [XmlEnum("587")]
        OLI_TERRAIN = 587,

        /// <summary>Season</summary>
        [XmlEnum("588")]
        OLI_SEASON = 588,

        /// <summary>RacingTrackInfo</summary>
        [XmlEnum("589")]
        OLI_RACINGTRACKINFO = 589,

        /// <summary>DiveDetailInfo</summary>
        [XmlEnum("590")]
        OLI_DIVEDETAILINFO = 590,

        /// <summary>DiveLocationInfo</summary>
        [XmlEnum("591")]
        OLI_DIVELOCATIONINFO = 591,

        /// <summary>SafetyEquipment</summary>
        [XmlEnum("592")]
        OLI_SAFETYEQUIPMENT = 592,

        /// <summary>BeneficiaryIncomeOptionInfo</summary>
        [XmlEnum("593")]
        OLI_BENEFICIARYINCOMEOPTIONINFO = 593,

        /// <summary>BusinessInsPurposeInfo</summary>
        [XmlEnum("594")]
        OLI_BUSINESSINSPURPOSEINFO = 594,

        /// <summary>AnswerChoice</summary>
        [XmlEnum("595")]
        OLI_ANSWERCHOICE = 595,

        /// <summary>SubAccountInfo</summary>
        [XmlEnum("596")]
        OLI_SUBACCOUNTINFO = 596,

        /// <summary>Bankruptcy</summary>
        [XmlEnum("597")]
        OLI_BANKRUPTCY = 597,

        /// <summary>WeightHistory</summary>
        [XmlEnum("598")]
        OLI_WEIGHTHISTORY = 598,

        /// <summary>MedicalCertRestriction</summary>
        [XmlEnum("599")]
        OLI_MEDICALCERTRESTRICTION = 599,

        /// <summary>CertificateCraftType</summary>
        [XmlEnum("600")]
        OLI_CERTIFICATECRAFTTYPE = 600,

        /// <summary>RaceTrack</summary>
        [XmlEnum("601")]
        OLI_RACETRACK = 601,

        /// <summary>DiveDetail</summary>
        [XmlEnum("602")]
        OLI_DIVEDETAIL = 602,

        /// <summary>DiveLocation</summary>
        [XmlEnum("603")]
        OLI_DIVELOCATION = 603,

        /// <summary>CreditCardTypeCC</summary>
        [XmlEnum("604")]
        OLI_CREDITCARDTYPECC = 604,

        /// <summary>PrescriptionDrugInfo</summary>
        [XmlEnum("605")]
        OLI_PRESCRIPTIONDRUGINFO = 605,

        /// <summary>TempTableRatingCC</summary>
        [XmlEnum("606")]
        OLI_TEMPTABLERATINGCC = 606,

        /// <summary>PermTableRatingCC</summary>
        [XmlEnum("607")]
        OLI_PERMTABLERATINGCC = 607,

        /// <summary>TravelEvent</summary>
        [XmlEnum("608")]
        OLI_TRAVELEVENT = 608,

        /// <summary>TravelPurposeInfo</summary>
        [XmlEnum("609")]
        OLI_TRAVELPURPOSEINFO = 609,

        /// <summary>VerificationRequirement</summary>
        [XmlEnum("610")]
        OLI_VERIFICATIONREQUIREMENT = 610,

        /// <summary>RelatedRoleDataCollection</summary>
        [XmlEnum("611")]
        OLI_RELATEDROLEDATACOLLECTION = 611,

        /// <summary>DenialInfo</summary>
        [XmlEnum("612")]
        OLI_DENIALINFO = 612,

        /// <summary>SourceOfFundsInfo</summary>
        [XmlEnum("613")]
        OLI_SOURCEOFFUNDSINFO = 613,

        /// <summary>RiskNotification</summary>
        [XmlEnum("614")]
        OLI_RISKNOTIFICATION = 614,

        /// <summary>CodeList</summary>
        [XmlEnum("615")]
        OLI_CODELIST = 615,

        /// <summary>CodeDefinition</summary>
        [XmlEnum("616")]
        OLI_CODEDEFINITION = 616,

        /// <summary>WorkLocation</summary>
        [XmlEnum("617")]
        OLI_WORKLOCATION = 617,

        /// <summary>Unknown object 1001</summary>
        [XmlEnum("1001")]
        OLI_OBJ_1001 = 1001,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
