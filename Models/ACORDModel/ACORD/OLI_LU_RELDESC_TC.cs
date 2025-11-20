using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_RELDESC_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        ///// <summary>Spouse</summary>
        ///// <remarks>Spouse</remarks>
        //[XmlEnum("0")]
        //OLI_UNKNOWN = 0,

        ///// <summary>Previous Owner</summary>
        ///// <remarks>Previous Owner</remarks>
        //[XmlEnum("0")]
        //OLI_UNKNOWN = 0,

        ///// <summary>Partner</summary>
        ///// <remarks>Partner</remarks>
        //[XmlEnum("0")]
        //OLI_UNKNOWN = 0,

        ///// <summary>Parent</summary>
        ///// <remarks>Parent</remarks>
        //[XmlEnum("0")]
        //OLI_UNKNOWN = 0,

        ///// <summary>Non-Natural Entity - No Exception</summary>
        ///// <remarks>Non-Natural Entity - No Exception</remarks>
        //[XmlEnum("0")]
        //OLI_UNKNOWN = 0,

        ///// <summary>Non-Natural Entity</summary>
        ///// <remarks>Non-Natural Entity</remarks>
        //[XmlEnum("0")]
        //OLI_UNKNOWN = 0,

        ///// <summary>Mother</summary>
        ///// <remarks>Mother</remarks>
        //[XmlEnum("0")]
        //OLI_UNKNOWN = 0,

        ///// <summary>Mother</summary>
        ///// <remarks>Mother</remarks>
        //[XmlEnum("0")]
        //OLI_UNKNOWN = 0,

        ///// <summary>Legal Guardian</summary>
        ///// <remarks>Legal Guardian</remarks>
        //[XmlEnum("0")]
        //OLI_UNKNOWN = 0,

        ///// <summary>Insured's Company</summary>
        ///// <remarks>Insured's Company</remarks>
        //[XmlEnum("0")]
        //OLI_UNKNOWN = 0,

        ///// <summary>Friend</summary>
        ///// <remarks>Friend</remarks>
        //[XmlEnum("0")]
        //OLI_UNKNOWN = 0,

        ///// <summary>Father</summary>
        ///// <remarks>Father</remarks>
        //[XmlEnum("0")]
        //OLI_UNKNOWN = 0,

        ///// <summary>Estate</summary>
        ///// <remarks>Estate</remarks>
        //[XmlEnum("0")]
        //OLI_UNKNOWN = 0,

        ///// <summary>Employer (Key Man)</summary>
        ///// <remarks>Employer (Key Man)</remarks>
        //[XmlEnum("0")]
        //OLI_UNKNOWN = 0,

        ///// <summary>Child</summary>
        ///// <remarks>Child</remarks>
        //[XmlEnum("0")]
        //OLI_UNKNOWN = 0,

        /// <summary>Husband</summary>
        [XmlEnum("1")]
        OLI_RELDESC_HUSBAND = 1,

        /// <summary>Wife</summary>
        [XmlEnum("2")]
        OLI_RELDESC_WIFE = 2,

        /// <summary>Father</summary>
        [XmlEnum("3")]
        OLI_RELDESC_FATHER = 3,

        /// <summary>Mother</summary>
        [XmlEnum("4")]
        OLI_RELDESC_MOTHER = 4,

        /// <summary>Son</summary>
        [XmlEnum("5")]
        OLI_RELDESC_SON = 5,

        /// <summary>Daughter</summary>
        [XmlEnum("6")]
        OLI_RELDESC_DAUGHTER = 6,

        /// <summary>Brother</summary>
        [XmlEnum("7")]
        OLI_RELDESC_BROTHER = 7,

        /// <summary>Sister</summary>
        [XmlEnum("8")]
        OLI_RELDESC_SISTER = 8,

        /// <summary>Ex-husband</summary>
        [XmlEnum("9")]
        OLI_RELDESC_EXHUSBAND = 9,

        /// <summary>Ex-wife</summary>
        [XmlEnum("10")]
        OLI_RELDESC_EXWIFE = 10,

        /// <summary>Step Mother</summary>
        [XmlEnum("11")]
        OLI_RELDESC_STEPMOTHER = 11,

        /// <summary>Step Father</summary>
        [XmlEnum("12")]
        OLI_RELDESC_STEPFATHER = 12,

        /// <summary>Step Son - has no blood relations, however parents are married to each other</summary>
        [XmlEnum("13")]
        OLI_RELDESC_STEPSON = 13,

        /// <summary>Step Daughter - has no blood relations, however parents are married to each other</summary>
        [XmlEnum("14")]
        OLI_RELDESC_STEPDAUGH = 14,

        /// <summary>Step Brother - have no blood relations, different parents, however parents are married to each other.</summary>
        [XmlEnum("15")]
        OLI_RELDESC_STEPBROTH = 15,

        /// <summary>Step Sister - have no blood relations, different parents, however parents are married to each other.</summary>
        [XmlEnum("16")]
        OLI_RELDESC_STEPSIST = 16,

        /// <summary>Grandfather</summary>
        [XmlEnum("17")]
        OLI_RELDESC_GRANDFATH = 17,

        /// <summary>Grandmother</summary>
        [XmlEnum("18")]
        OLI_RELDESC_GRANDMOTH = 18,

        /// <summary>Grandson</summary>
        [XmlEnum("19")]
        OLI_RELDESC_GRANDSON = 19,

        /// <summary>Granddaughter</summary>
        [XmlEnum("20")]
        OLI_RELDESC_GRANDDAUGH = 20,

        /// <summary>Father-in-law</summary>
        [XmlEnum("21")]
        OLI_RELDESC_FATHINLW = 21,

        /// <summary>Mother-in-law</summary>
        [XmlEnum("22")]
        OLI_RELDESC_MOTHINLW = 22,

        /// <summary>Son-in-law</summary>
        [XmlEnum("23")]
        OLI_RELDESC_SONINLW = 23,

        /// <summary>Daughter-in-law</summary>
        [XmlEnum("24")]
        OLI_RELDESC_DAUGHINLW = 24,

        /// <summary>Brother-in-law</summary>
        [XmlEnum("25")]
        OLI_RELDESC_BROTHINLW = 25,

        /// <summary>Sister-in-law</summary>
        [XmlEnum("26")]
        OLI_RELDESC_SISTINLW = 26,

        /// <summary>Half Brother - have one parent in common.   For example,  same mother, different fathers.</summary>
        [XmlEnum("27")]
        OLI_RELDESC_HALF_BROTHER = 27,

        /// <summary>Half Sister - have one parent in common.   For example,  same mother, different fathers.</summary>
        [XmlEnum("28")]
        OLI_RELDESC_HALF_SISTER = 28,

        /// <summary>Cousin (Male cousin - non English)</summary>
        /// <remarks>When used in non-English language context, this implies a male cousin. In English speaking context, no gender is implied. The gender applies to the related object.</remarks>
        [XmlEnum("29")]
        OLI_RELDESC_COUSIN = 29,

        /// <summary>Uncle</summary>
        [XmlEnum("30")]
        OLI_RELDESC_UNCLE = 30,

        /// <summary>Aunt</summary>
        [XmlEnum("31")]
        OLI_RELDESC_AUNT = 31,

        /// <summary>Nephew</summary>
        [XmlEnum("32")]
        OLI_RELDESC_NEPHEW = 32,

        /// <summary>Niece</summary>
        [XmlEnum("33")]
        OLI_RELDESC_NIECE = 33,

        /// <summary>God Father</summary>
        [XmlEnum("34")]
        OLI_RELDESC_GODFATHER = 34,

        /// <summary>God Mother</summary>
        [XmlEnum("35")]
        OLI_RELDESC_GODMOTHER = 35,

        /// <summary>Secretary</summary>
        [XmlEnum("37")]
        OLI_RELDESC_SECRETARY = 37,

        /// <summary>General Manager</summary>
        [XmlEnum("38")]
        OLI_RELDESC_GENMANAGER = 38,

        /// <summary>President</summary>
        [XmlEnum("39")]
        OLI_RELDESC_PRESIDENT = 39,

        /// <summary>Vice President</summary>
        [XmlEnum("40")]
        OLI_RELDESC_VICEPRES = 40,

        /// <summary>Executive</summary>
        [XmlEnum("41")]
        OLI_RELDESC_EXECUTIVE = 41,

        /// <summary>Attorney</summary>
        [XmlEnum("42")]
        OLI_RELDESC_ATTORNEY = 42,

        /// <summary>Auditor</summary>
        [XmlEnum("43")]
        OLI_RELDESC_AUDITOR = 43,

        /// <summary>Bookkeeper</summary>
        [XmlEnum("44")]
        OLI_RELDESC_BOOKKEEPER = 44,

        /// <summary>Consultant</summary>
        [XmlEnum("45")]
        OLI_RELDESC_CONSULTANT = 45,

        /// <summary>Chairman of the Board</summary>
        [XmlEnum("46")]
        OLI_RELDESC_COB = 46,

        /// <summary>Chief Executive Officer</summary>
        [XmlEnum("47")]
        OLI_RELDESC_CEO = 47,

        /// <summary>Chief Financial Officer</summary>
        [XmlEnum("48")]
        OLI_RELDESC_CFO = 48,

        /// <summary>Chief Operating Officer</summary>
        [XmlEnum("49")]
        OLI_RELDESC_COO = 49,

        /// <summary>Chief Information Officer</summary>
        [XmlEnum("50")]
        OLI_RELDESC_CIO = 50,

        /// <summary>Tax Agent</summary>
        [XmlEnum("52")]
        OLI_RELDESC_TAXAGENT = 52,

        /// <summary>Estate Agent</summary>
        [XmlEnum("53")]
        OLI_RELDESC_ESTATEAGENT = 53,

        /// <summary>Legal Agent</summary>
        [XmlEnum("54")]
        OLI_RELDESC_LEGALAGENT = 54,

        /// <summary>God Son</summary>
        [XmlEnum("55")]
        OLI_RELDESC_GODSON = 55,

        /// <summary>God Daughter</summary>
        [XmlEnum("56")]
        OLI_RELDESC_GODDAUGHTER = 56,

        /// <summary>Owner of Cash Value</summary>
        [XmlEnum("57")]
        OLI_RELDESC_OWNERCV = 57,

        /// <summary>Owner of Death Benefit</summary>
        [XmlEnum("58")]
        OLI_RELDESC_OWNERDB = 58,

        /// <summary>Owner of cash value and death benefit</summary>
        [XmlEnum("59")]
        OLI_RELDESC_OWNERCVDB = 59,

        /// <summary>Fiancé (male)</summary>
        [XmlEnum("60")]
        OLI_RELDESC_FIANCE = 60,

        /// <summary>Common Law Wife</summary>
        [XmlEnum("61")]
        OLI_RELDESC_COMMLAWWIFE = 61,

        /// <summary>Common Law Husband</summary>
        [XmlEnum("62")]
        OLI_RELDESC_COMMLAWHUSB = 62,

        /// <summary>Great Aunt (Grandaunt)</summary>
        [XmlEnum("63")]
        OLI_RELDESC_GREATAUNT = 63,

        /// <summary>Great Uncle (Granduncle)</summary>
        [XmlEnum("64")]
        OLI_RELDESC_GREATUNCLE = 64,

        /// <summary>Grand Nephew</summary>
        [XmlEnum("65")]
        OLI_RELDESC_GRANDNEPH = 65,

        /// <summary>Grand Niece</summary>
        [XmlEnum("66")]
        OLI_RELDESC_GRANDNIECE = 66,

        /// <summary>Great Grandson</summary>
        [XmlEnum("67")]
        OLI_RELDESC_GREATGRANDSON = 67,

        /// <summary>Great Granddaughter</summary>
        [XmlEnum("68")]
        OLI_RELDESC_GREATGRANDDAUGH = 68,

        /// <summary>Great Grandfather</summary>
        [XmlEnum("69")]
        OLI_RELDESC_GREATGRANDFATH = 69,

        /// <summary>Great Grandmother</summary>
        [XmlEnum("70")]
        OLI_RELDESC_GREATGRANDMOTH = 70,

        /// <summary>Foster Son</summary>
        [XmlEnum("71")]
        OLI_RELDESC_FOSTERSON = 71,

        /// <summary>Foster Daughter</summary>
        [XmlEnum("72")]
        OLI_RELDESC_FOSTERDAUGH = 72,

        /// <summary>Foster Father</summary>
        [XmlEnum("73")]
        OLI_RELDESC_FOSTERFATHER = 73,

        /// <summary>Foster Mother</summary>
        [XmlEnum("74")]
        OLI_RELDESC_FOSTERMOTHER = 74,

        /// <summary>Foster Brother</summary>
        [XmlEnum("75")]
        OLI_RELDESC_FOSTERBROTHER = 75,

        /// <summary>Foster Sister</summary>
        [XmlEnum("76")]
        OLI_RELDESC_FOSTERSISTER = 76,

        /// <summary>Accountant</summary>
        [XmlEnum("77")]
        OLI_RELDESC_ACCOUNTANT = 77,

        /// <summary>CPA</summary>
        [XmlEnum("78")]
        OLI_RELDESC_CPA = 78,

        /// <summary>Financial Advisor</summary>
        [XmlEnum("79")]
        OLI_RELDESC_FINANADVISOR = 79,

        /// <summary>Stockbroker</summary>
        [XmlEnum("80")]
        OLI_RELDESC_STOCKBRKR = 80,

        /// <summary>Estate Planner</summary>
        [XmlEnum("81")]
        OLI_RELDESC_ESTATEPLANNER = 81,

        /// <summary>Charitable Advisor</summary>
        [XmlEnum("82")]
        OLI_RELDESC_CHARITABLEADVISOR = 82,

        /// <summary>Business Insurance Advisor</summary>
        [XmlEnum("83")]
        OLI_RELDESC_BUSINSADVISOR = 83,

        /// <summary>Business Accountant</summary>
        [XmlEnum("84")]
        OLI_RELDESC_BUSACCOUNTANT = 84,

        /// <summary>Business CPA</summary>
        [XmlEnum("85")]
        OLI_RELDESC_BUSCPA = 85,

        /// <summary>Business Attorney</summary>
        [XmlEnum("86")]
        OLI_RELDESC_BUSATTORNEY = 86,

        /// <summary>Valuation Analyst</summary>
        [XmlEnum("87")]
        OLI_RELDESC_VALUATIONANALYST = 87,

        /// <summary>Boy Friend</summary>
        [XmlEnum("88")]
        OLI_RELDESC_BOYFRIEND = 88,

        /// <summary>Girl Friend</summary>
        [XmlEnum("89")]
        OLI_RELDESC_GIRLFRIEND = 89,

        /// <summary>Fiancée (engaged female)</summary>
        [XmlEnum("90")]
        OLI_RELDESC_FIANCEE = 90,

        /// <summary>Self</summary>
        /// <remarks>Self.  Identifies that information relates back to Party.  An example is gathering household insurance information for RISK for the proposed insured, since RISK links back to PARTY.</remarks>
        [XmlEnum("91")]
        OLI_RELDESC_SELF = 91,

        /// <summary>Custodian</summary>
        [XmlEnum("92")]
        OLI_RELDESC_CUSTODIAN = 92,

        /// <summary>Cousin - Female cousin</summary>
        /// <remarks>The gender applies to the related object.</remarks>
        [XmlEnum("95")]
        OLI_RELDESC_FEMCOUSIN = 95,

        /// <summary>Day-to-day Contact</summary>
        /// <remarks>Day-to-day Contact is the group insurance customer's representative designated as the individual to be contacted for any questions or normal activity requirements around the management of the relationship between the carrier and the customer.  The group insurance customer is the employer organization or company, and the Day-to-day contact is generally an individual rather than an organization, but exceptions to that do exist.</remarks>
        [XmlEnum("96")]
        OLI_RELDESC_DAYCONTACT = 96,

        /// <summary>Benefits Administrator</summary>
        /// <remarks>Benefits Administrator is the group insurance customer's representative designated as the individual or organization who administers the benefit plan being purchased from the carrier and offered to the employee population.</remarks>
        [XmlEnum("97")]
        OLI_RELDESC_BENADMIN = 97,

        /// <summary>Account Specialist</summary>
        /// <remarks>Account Specialist is the carrier employee responsible for administering the group insurance customer's case information.  The group insurance customer is the employer organization or company, and their case information includes such items as contacts, situs information, and Experience Groupings.</remarks>
        [XmlEnum("98")]
        OLI_RELDESC_ACCTSPEC = 98,

        /// <summary>Administrative Unit</summary>
        /// <remarks>An organization responsible for the administration of a particular product or some other aspect of a customer relationship.</remarks>
        [XmlEnum("99")]
        OLI_RELDESC_ADMINUNIT = 99,

        /// <summary>Special Care Agency</summary>
        /// <remarks>Agency assigned to work with the contact(s) of the deceased client and provide an additional level of service or care.</remarks>
        [XmlEnum("100")]
        OLI_RELDESC_SPECCAREAGENCY = 100,

        /// <summary>Special Care Agent</summary>
        /// <remarks>Agent assigned to work with the contact(s) of the deceased client and provide an additional level of service or care.</remarks>
        [XmlEnum("101")]
        OLI_RELDESC_SPECCAREAGENT = 101,

        /// <summary>Adopted Daughter</summary>
        [XmlEnum("102")]
        OLI_RELDESC_ADOPTDAUGHTER = 102,

        /// <summary>Adopted Son</summary>
        [XmlEnum("103")]
        OLI_RELDESC_ADOPTSON = 103,

        /// <summary>Adoptive Mother</summary>
        [XmlEnum("104")]
        OLI_RELDESC_ADOPTMOTHER = 104,

        /// <summary>Adoptive Father</summary>
        [XmlEnum("105")]
        OLI_RELDESC_ADOPTFATHER = 105,

        /// <summary>Internal Replacement</summary>
        /// <remarks>This is the general term for an Internal Replacement.</remarks>
        [XmlEnum("106")]
        OLI_RELDESC_INTERNAL = 106,

        /// <summary>External Replacement</summary>
        /// <remarks>This is the general term for an External Replacement.</remarks>
        [XmlEnum("107")]
        OLI_RELDESC_EXTERNAL = 107,

        /// <summary>Finance Purchase</summary>
        /// <remarks>The policy is being replaced as a result of a Finance Purchase.</remarks>
        [XmlEnum("108")]
        OLI_RELDESC_FINPURCH = 108,

        /// <summary>Term Conversion</summary>
        /// <remarks>The policy is being replaced as a result of a Term Conversion.</remarks>
        [XmlEnum("109")]
        OLI_RELDESC_TERMCONV = 109,

        /// <summary>Guaranteed Purchase Option</summary>
        /// <remarks>The policy is being replaced as a result of a Guaranteed Purchase Option.</remarks>
        [XmlEnum("110")]
        OLI_RELDESC_GPO = 110,

        /// <summary>Group Conversion</summary>
        /// <remarks>The replaced policy is from a group conversion.</remarks>
        [XmlEnum("111")]
        OLI_RELDESC_GROUPCONV = 111,

        /// <summary>Replaced in Same Statutory Company</summary>
        /// <remarks>The policy being replaced was issued by the same statutory company.</remarks>
        [XmlEnum("112")]
        OLI_RELDESC_SAMECO = 112,

        /// <summary>Replaced Between Statutory Companies</summary>
        /// <remarks>The policy is being replaced between statutory companies.</remarks>
        [XmlEnum("113")]
        OLI_RELDESC_DIFFCO = 113,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
