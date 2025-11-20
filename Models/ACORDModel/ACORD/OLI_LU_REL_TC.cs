using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_REL_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Spouse</summary>
        /// <remarks>Reciprocal is OLI_REL_SPOUSE</remarks>
        [XmlEnum("1")]
        OLI_REL_SPOUSE = 1,

        /// <summary>Child</summary>
        /// <remarks>Reciprocal is OLI_REL_PARENT</remarks>
        [XmlEnum("2")]
        OLI_REL_CHILD = 2,

        /// <summary>Parent</summary>
        /// <remarks>Reciprocal is OLI_REL_CHILD</remarks>
        [XmlEnum("3")]
        OLI_REL_PARENT = 3,

        /// <summary>Sibling</summary>
        /// <remarks>Reciprocal is OLI_REL_SIBLING</remarks>
        [XmlEnum("4")]
        OLI_REL_SIBLING = 4,

        /// <summary>Family</summary>
        /// <remarks>Reciprocal is OLI_REL_FAMILY</remarks>
        [XmlEnum("5")]
        OLI_REL_FAMILY = 5,

        /// <summary>Employee</summary>
        /// <remarks>Reciprocal is OLI_REL_EMPLOYER</remarks>
        [XmlEnum("6")]
        OLI_REL_EMPLOYEE = 6,

        /// <summary>Employer</summary>
        /// <remarks>Reciprocal is OLI_REL_RETIRINGEMP *or* OLI_REL_EMPLOYEE</remarks>
        [XmlEnum("7")]
        OLI_REL_EMPLOYER = 7,

        /// <summary>Owner</summary>
        [XmlEnum("8")]
        OLI_REL_OWNER = 8,

        /// <summary>Partner</summary>
        /// <remarks>This is intended to be Business PartnerReciprocal is OLI_REL_PARTNER</remarks>
        [XmlEnum("9")]
        OLI_REL_PARTNER = 9,

        /// <summary>Advisor</summary>
        /// <remarks>Reciprocal is OLI_REL_ADVISEE</remarks>
        [XmlEnum("10")]
        OLI_REL_ADVISOR = 10,

        /// <summary>Agent</summary>
        /// <remarks>This is the Agent for the Policy.  This does not indicate that the related agent is the "writing agent", "servicing agent", or any other specific type of agent.  There are other relation role codes for those situations.</remarks>
        [XmlEnum("11")]
        OLI_REL_AGENT = 11,

        /// <summary>Referral</summary>
        /// <remarks>Reciprocal is OLI_REL_NOMINATOR</remarks>
        [XmlEnum("12")]
        OLI_REL_REFERRAL = 12,

        /// <summary>Nominator</summary>
        /// <remarks>Reciprocal is OLI_REL_REFERRAL</remarks>
        [XmlEnum("13")]
        OLI_REL_NOMINATOR = 13,

        /// <summary>Friend</summary>
        /// <remarks>Reciprocal is OLI_REL_FRIEND</remarks>
        [XmlEnum("14")]
        OLI_REL_FRIEND = 14,

        /// <summary>Domestic Partner</summary>
        /// <remarks>A description of a relationship between two people living in the same abode but are not in a legally recognized union.  Examples would be a same sex couple living together or two people living together that have no current plans to marry.</remarks>
        [XmlEnum("15")]
        OLI_REL_DOMPART = 15,

        /// <summary>Roommate</summary>
        /// <remarks>Reciprocal is OLI_REL_ROOMMATE</remarks>
        [XmlEnum("16")]
        OLI_REL_ROOMMATE = 16,

        /// <summary>Business Contact</summary>
        /// <remarks>Used to identify the source of a business contact.  The reciprocal is OLI_REL_CONTACTWBUS.Traditionally, the RelatedObject of Business Contact would be the "Business" while the RelatedObject of OLI_REL_CONTACTWBUSINESS would be the contact itself.  That is, if an agent has a contact in their contact manager, the agent would be the "Business" and the party in the contact manager would be the "Contact."Thus, since either or both parties could be a "business" the two role codes are essentially redundant.  ACORD recommends coding this relationship with OLI_REL_BUSCONTACT and only optionally providing the reciprocal of OLI_REL_CONTACTWBUSINESS depending on the needs of your trading partner(s).</remarks>
        [XmlEnum("17")]
        OLI_REL_BUSCONTACT = 17,

        /// <summary>Household</summary>
        /// <remarks>Reciprocal is OLI_REL_HOUSEHOLD</remarks>
        [XmlEnum("18")]
        OLI_REL_HOUSEHOLD = 18,

        /// <summary>Advisee</summary>
        /// <remarks>Reciprocal is OLI_REL_ADVISOR</remarks>
        [XmlEnum("20")]
        OLI_REL_ADVISEE = 20,

        /// <summary>Client</summary>
        /// <remarks>Reciprocal is OLI_REL_REGREP</remarks>
        [XmlEnum("21")]
        OLI_REL_CLIENT = 21,

        /// <summary>Contact w/ Business</summary>
        /// <remarks>Used to identify the contact of a business contact.  The reciprocal is OLI_REL_BUSCONTACT.Traditionally, the RelatedObject of Business Contact would be the "Business" while the RelatedObject of OLI_REL_CONTACTWBUSINESS would be the contact itself.  That is, if an agent has a contact in their contact manager, the agent would be the "Business" and the party in the contact manager would be the "Contact."Thus, since either or both parties could be a "business" the two role codes are essentially redundant.  ACORD recommends coding this relationship with OLI_REL_BUSCONTACT and only optionally providing the reciprocal of OLI_REL_CONTACTWBUSINESS depending on the needs of your trading partner(s).</remarks>
        [XmlEnum("22")]
        OLI_REL_CONTACTWBUS = 22,

        /// <summary>Household Head</summary>
        /// <remarks>Reciprocal is OLI_REL_HHHEAD</remarks>
        [XmlEnum("23")]
        OLI_REL_HHHEAD = 23,

        /// <summary>Household Member</summary>
        /// <remarks>Reciprocal is OLI_REL_HHMEMBER</remarks>
        [XmlEnum("24")]
        OLI_REL_HHMEMBER = 24,

        /// <summary>Owned By</summary>
        /// <remarks>Reciprocal is OLI_REL_OWNER</remarks>
        [XmlEnum("25")]
        OLI_REL_OWNEDBY = 25,

        /// <summary>Board Member</summary>
        /// <remarks>Reciprocal is OLI_REL_BOARDMEM</remarks>
        [XmlEnum("26")]
        OLI_REL_BOARDMEM = 26,

        /// <summary>Legal Guardian</summary>
        /// <remarks>A person legally entrusted with the care of, and managing the property and rights of, another person, usually a minor.</remarks>
        [XmlEnum("27")]
        OLI_REL_LEGALGUARD = 27,

        /// <summary>Group</summary>
        /// <remarks>Reciprocal is OLI_REL_GRPMEMBER *or* OLI_REL_GRPCONTACT *or* OLI_REL_MEMBER</remarks>
        [XmlEnum("28")]
        OLI_REL_GROUP = 28,

        /// <summary>Group Contact</summary>
        /// <remarks>Reciprocal is OLI_REL_GROUP</remarks>
        [XmlEnum("29")]
        OLI_REL_GRPCONTACT = 29,

        /// <summary>Group Member</summary>
        /// <remarks>Applies from Grouping to PartyReciprocal is OLI_REL_GROUP</remarks>
        [XmlEnum("30")]
        OLI_REL_GRPMEMBER = 30,

        /// <summary>Payer</summary>
        /// <remarks>One responsible for making payments</remarks>
        [XmlEnum("31")]
        OLI_REL_PAYER = 31,

        /// <summary>Insured</summary>
        /// <remarks>Reciprocal is OLI_REL_INSURED when relation is holding-to-party. Reciprocal is OLI_REL_HLTHINSURER when relationship is party-to-party.</remarks>
        [XmlEnum("32")]
        OLI_REL_INSURED = 32,

        /// <summary>Coverage Insured</summary>
        /// <remarks>Used when a person is insured on an insurance component other than the base plan.  On annuity or long term care policies the coverage insured is the insured life, other than the annuitant, on a feature (Rider or Arrangement). On a life policy, the coverage insured identifies a party as the insured life on coverage other than the base coverage.</remarks>
        [XmlEnum("33")]
        OLI_REL_COVINSURED = 33,

        /// <summary>Primary Beneficiary</summary>
        /// <remarks>When paying proceeds to beneficiaries, the beneficiaries in this role will receive proceeds first.</remarks>
        [XmlEnum("34")]
        OLI_REL_BENEFICIARY = 34,

        /// <summary>Annuitant</summary>
        /// <remarks>The named individual whose lifetime is used as a measuring life in an annuity contract.  Also referred to as "covered person."  Note:  on a contract with two or more annuitants, the first/primary covered person listed on the contract is referred to as the  Annuitant (RelationRoleCode tc=35) and the subsequent covered persons are called Joint Annuitant (see tc =  183).  Do not specify two parties as Annuitant.  See also Descriptions for Contingent Annuitant, Joint Annuitant.</remarks>
        [XmlEnum("35")]
        OLI_REL_ANNUITANT = 35,

        /// <summary>Contingent Beneficiary</summary>
        /// <remarks>When paying proceeds to beneficiaries, if all Primary Beneficiary(ies) dies before the insured, the benefits are paid to the Contingent Beneficiary(ies).  The Contingent Beneficiary could also be known as the Secondary Beneficiary.</remarks>
        [XmlEnum("36")]
        OLI_REL_CONTGNTBENE = 36,

        /// <summary>Primary Writing Agent</summary>
        /// <remarks>This is the Primary Writing Agent for the contract.  For the role of the primary writing agent for a specific coverage (or rider) see role code OLI_REL_COVPRIMAGENT.</remarks>
        [XmlEnum("37")]
        OLI_REL_PRIMAGENT = 37,

        /// <summary>Primary Servicing Agent</summary>
        /// <remarks>This is the Primary Servicing Agent for the contract.  For the role of the primary sevicing agent for a specific coverage (or rider) see role code OLI_REL_COVSERVAGENT.</remarks>
        [XmlEnum("38")]
        OLI_REL_SERVAGENT = 38,

        /// <summary>Assigned Agent</summary>
        /// <remarks>Reciprocal is OLI_REL_ASSIGNAGENT</remarks>
        [XmlEnum("39")]
        OLI_REL_ASSIGNAGENT = 39,

        /// <summary>Dependent</summary>
        /// <remarks>Reciprocal is OLI_REL_LEGALGUARD</remarks>
        [XmlEnum("40")]
        OLI_REL_DEPENDENT = 40,

        /// <summary>Physician</summary>
        /// <remarks>Reciprocal is OLI_REL_PATIENT</remarks>
        [XmlEnum("41")]
        OLI_REL_PHYSICIAN = 41,

        /// <summary>Patient</summary>
        /// <remarks>Reciprocal is OLI_REL_MEDPROVIDER *or* OLI_REL_DENTALPROVIDER *or* OLI_REL_PHYSICIAN *or* OLI_RELPRIMPHYSICIAN</remarks>
        [XmlEnum("42")]
        OLI_REL_PATIENT = 42,

        /// <summary>Originator</summary>
        /// <remarks>One who request an activity be done by a performer or if only a notification is informing the recipient (with no action expected).</remarks>
        [XmlEnum("43")]
        OLI_REL_ORIGINATOR = 43,

        /// <summary>Target</summary>
        /// <remarks>Reciprocal is OLI_REL_TARGET</remarks>
        [XmlEnum("44")]
        OLI_REL_TARGET = 44,

        /// <summary>Performer</summary>
        /// <remarks>The party who is expected to do something is the ‘Performer’.  One requested to do an activity.</remarks>
        [XmlEnum("45")]
        OLI_REL_PERFORMER = 45,

        /// <summary>Superior Agent</summary>
        /// <remarks>Reciprocal is OLI_REL_SUBORDAGENT</remarks>
        [XmlEnum("46")]
        OLI_REL_SUPERIORAGENT = 46,

        /// <summary>Subordinate Agent</summary>
        /// <remarks>Reciprocal is OLI_REL_SUPERIORAGENT</remarks>
        [XmlEnum("47")]
        OLI_REL_SUBORDAGENT = 47,

        /// <summary>General Agent</summary>
        /// <remarks>Can also apply between two Parties, to indicate the General Agent for an Agent. Reciprocal is OLI_REL_REGAGENT when relation is party-to-party. Reciprocal is OLI_REL_GENAGENT when relation is Holding-to-Party</remarks>
        [XmlEnum("48")]
        OLI_REL_GENAGENT = 48,

        /// <summary>Package Holder</summary>
        /// <remarks>Used in group policies and other scenarios where a hierarchy between Holdings must be maintained, like employee benefit or package plans. The reciprocal is a "Package Component" where the Package Holder represents a master contract and the Package Component is an individual Holding.</remarks>
        [XmlEnum("49")]
        OLI_REL_PCKHOLDER = 49,

        /// <summary>Package Component</summary>
        /// <remarks>Used in group policies and other scenarios where a hierarchy between Holdings must be maintained, like employee benefit or package plans. This is the reciprocal of a "Package Holder" relationship. The Package Holder is the master contract while the Package Component is the individual Holding.</remarks>
        [XmlEnum("50")]
        OLI_REL_PCKCOMPONENT = 50,

        /// <summary>Consignee Agent</summary>
        /// <remarks>Reciprocal is OLI_REL_CONSIGNEEAGENT</remarks>
        [XmlEnum("51")]
        OLI_REL_CONSIGNEEAGENT = 51,

        /// <summary>Additional Writing Agent</summary>
        [XmlEnum("52")]
        OLI_REL_ADDWRITINGAGENT = 52,

        /// <summary>Regional Agent</summary>
        /// <remarks>Reciprocal is OLI_REL_GENAGENT</remarks>
        [XmlEnum("53")]
        OLI_REL_REGAGENT = 53,

        /// <summary>Plan Sponsor</summary>
        /// <remarks>Sponsor of a Plan, such as an employer who has established a 401(k) Plan for employee participants.  A Plan Sponsor often (but does not have to) has specific roles and responsibilities as designated in the Plan charter</remarks>
        [XmlEnum("54")]
        OLI_REL_PLANSPONSOR = 54,

        /// <summary>Assignee Beneficiary</summary>
        /// <remarks>Reciprocal is OLI_REL_ASSIGNBENE</remarks>
        [XmlEnum("55")]
        OLI_REL_ASSIGNBENE = 55,

        /// <summary>Tertiary Beneficiary</summary>
        /// <remarks>A beneficiary designated as third in line to receive the proceeds or benefits if the  primary and secondary beneficiaries do not survive the insured.</remarks>
        [XmlEnum("56")]
        OLI_REL_TERTBENE = 56,

        /// <summary>Custodian</summary>
        /// <remarks>A person or organization such as an agent, bank, trust company, or other organization which holds and safeguards an individual's assets for them, such as mutual funds, or investment company's assets.For example, the person or organization responsible for the asset on a UGMA account where the actual owner is a minor.</remarks>
        [XmlEnum("57")]
        OLI_REL_CUSTODIAN = 57,

        /// <summary>Primary Physician</summary>
        /// <remarks>Reciprocal is OLI_REL_PATIENT</remarks>
        [XmlEnum("58")]
        OLI_REL_PRIMPHYSICIAN = 58,

        /// <summary>Trustee of Minor</summary>
        /// <remarks>Reciprocal is OLI_REL_TRUSTEEDMINOR</remarks>
        [XmlEnum("59")]
        OLI_REL_TRUSTEEMINOR = 59,

        /// <summary>Trusteed Minor</summary>
        /// <remarks>Reciprocal is OLI_REL_TRUSTEEMINOR</remarks>
        [XmlEnum("60")]
        OLI_REL_TRUSTEEDMINOR = 60,

        /// <summary>Trustee of Incompetent</summary>
        /// <remarks>Reciprocal is OLI_REL_TRUSTEEDINCOMP</remarks>
        [XmlEnum("61")]
        OLI_REL_TRUSTEEINCOMP = 61,

        /// <summary>Trusteed Incompetent</summary>
        /// <remarks>Reciprocal is OLI_REL_TRUSTEEINCOMP</remarks>
        [XmlEnum("62")]
        OLI_REL_TRUSTEEDINCOMP = 62,

        /// <summary>Replaced</summary>
        /// <remarks>Used to define the relationship between an existing policy and another policy and where the tax status of the existing policy is taxable or unknown. If known to be a nontaxable exchange (for example 1035 Exchange) use Exchanged (67). When there are transfers inside a qualified plan or between qualified plans then use this code  - Replaced (63).</remarks>
        [XmlEnum("63")]
        OLI_REL_REPLACED = 63,

        /// <summary>Replaced by</summary>
        /// <remarks>Used to define the relationship between an existing policy and another policy and where the tax status of the existing policy is taxable or unknown. If known to be a nontaxable exchange (for example 1035 Exchange) use Exchanged (67). When there are transfers inside a qualified plan or between qualified plans then use this code  - Replaced (63).</remarks>
        [XmlEnum("64")]
        OLI_REL_REPLACEDBY = 64,

        /// <summary>Rollover</summary>
        /// <remarks>Reciprocal is OLI_REL_ROLLEDINTO</remarks>
        [XmlEnum("65")]
        OLI_REL_ROLLOVER = 65,

        /// <summary>Rolled into</summary>
        /// <remarks>Reciprocal is OLI_REL_ROLLOVER</remarks>
        [XmlEnum("66")]
        OLI_REL_ROLLEDINTO = 66,

        /// <summary>Exchanged</summary>
        /// <remarks>Used to define the relationship between an existing policy and another policy, where the transfer of the existing policy values from the old contract are funding this new contract without being subject to taxation (for example under the U.S. Internal Revenue Code Section 1035). Replaced (63)/Replaced by (64) should not be used.</remarks>
        [XmlEnum("67")]
        OLI_REL_EXCHANGED = 67,

        /// <summary>Exchanged For (previously named "Exchanged By")</summary>
        /// <remarks>Used to define the relationship between an existing policy and another policy, where the transfer of the existing policy values from the old contract are funding this new contract without being subject to taxation (for example under the U.S. Internal Revenue Code Section 1035). Replaced (63)/Replaced by (64) should not be used.</remarks>
        [XmlEnum("68")]
        OLI_REL_EXCHANGEDBY = 68,

        /// <summary>Trustee</summary>
        /// <remarks>Reciprocal is OLI_REL_TRUSTEE</remarks>
        [XmlEnum("69")]
        OLI_REL_TRUSTEE = 69,

        /// <summary>Curator</summary>
        /// <remarks>Reciprocal is OLI_REL_CURATOR</remarks>
        [XmlEnum("70")]
        OLI_REL_CURATOR = 70,

        /// <summary>Shareholder</summary>
        /// <remarks>Reciprocal is OLI_REL_SHAREHOLDER</remarks>
        [XmlEnum("71")]
        OLI_REL_SHAREHOLDER = 71,

        /// <summary>Security Cession (collateral)</summary>
        /// <remarks>Reciprocal is OLI_REL_ABSCESS</remarks>
        [XmlEnum("72")]
        OLI_REL_SECCESS = 72,

        /// <summary>Absolute Cession (collateral)</summary>
        /// <remarks>Reciprocal is OLI_REL_SECCESS</remarks>
        [XmlEnum("73")]
        OLI_REL_ABSCESS = 73,

        /// <summary>Investor</summary>
        /// <remarks>Reciprocal is OLI_REL_INVESTOR</remarks>
        [XmlEnum("74")]
        OLI_REL_INVESTOR = 74,

        /// <summary>Member</summary>
        /// <remarks>Used for retirement annuities.  Distinction made if 'member of fund'.Reciprocal is OLI_REL_GROUP</remarks>
        [XmlEnum("75")]
        OLI_REL_MEMBER = 75,

        /// <summary>As Applied</summary>
        /// <remarks>Reciprocal is OLI_REL_ASAPPROVED</remarks>
        [XmlEnum("76")]
        OLI_REL_ASAPPLIED = 76,

        /// <summary>As Approved</summary>
        /// <remarks>Reciprocal is OLI_REL_ASAPPLIED</remarks>
        [XmlEnum("77")]
        OLI_REL_ASAPPROVED = 77,

        /// <summary>Successor Owner</summary>
        /// <remarks>Some contracts allow a 'successor owner' provision where, if the primary beneficiary is the surviving spouse, the surviving spouse may elect to continue the contract as the successor owner after the death of the primary beneficiary instead of electing to receive the death benefit from the contract.  At that point, the role of the primary beneficiary includes/becomes successor owner.  The Successor Owner role is not stated/defined when an application is gathered;  it is stated in the event of death and if provision is elected.</remarks>
        [XmlEnum("78")]
        OLI_REL_SUCCESSOR_OWNER = 78,

        /// <summary>Health Insurer</summary>
        /// <remarks>Reciprocal is OLI_REL_INSURED.</remarks>
        [XmlEnum("80")]
        OLI_REL_HLTHINSURER = 80,

        /// <summary>Joint Marketing Agreement</summary>
        /// <remarks>Reciprocal is OLI_REL_JOINTMKTGAGMT</remarks>
        [XmlEnum("81")]
        OLI_REL_JOINTMKTGAGMT = 81,

        /// <summary>Registered Representative</summary>
        /// <remarks>Reciprocal is OLI_REL_CLIENT</remarks>
        [XmlEnum("82")]
        OLI_REL_REGREP = 82,

        /// <summary>Broker/Dealer</summary>
        /// <remarks>Reciprocal is OLI_REL_BROKER when relation is holding-to-party. Reciprocal is OLI_REL_CLIENT when relation is party-to-party.</remarks>
        [XmlEnum("83")]
        OLI_REL_BROKER = 83,

        /// <summary>Paramedical Examiner</summary>
        /// <remarks>Reciprocal is OLI_REL_PMEDCO</remarks>
        [XmlEnum("84")]
        OLI_REL_PMEDEXAMINER = 84,

        /// <summary>Superior Office</summary>
        /// <remarks>Reciprocal is OLI_REL_SUBORDOFC</remarks>
        [XmlEnum("85")]
        OLI_REL_SUPOFC = 85,

        /// <summary>Subordinate Office</summary>
        /// <remarks>Reciprocal is OLI_REL_SUPOFC</remarks>
        [XmlEnum("86")]
        OLI_REL_SUBORDOFC = 86,

        /// <summary>Carrier</summary>
        /// <remarks>The underwriting carrier of a policy is modeled via a direct IDREF (called CarrierPartyID) in the Policy aggregate. The use of the "Carrier" (87) to associate the Holding with the carrier Party is incorrect. That relation role -- which was introduced in version 2.3 by MR#00-541 -- is documented as a Party-to-Party role, and is the reciprocal of the "Holding Company" relation. (It is used to relate Carriers to the Holding Company that owns them.) Thus, it is not appropriate to use this code in a Party-to-Holding relation.</remarks>
        [XmlEnum("87")]
        OLI_REL_CARRIER = 87,

        /// <summary>Holding Company</summary>
        /// <remarks>Party-to-Party relationship used to indicate the holding company of a Carrier.  The reciprocal is "Carrier" (OLI_REL_CARRIER).</remarks>
        [XmlEnum("88")]
        OLI_REL_HOLDINGCO = 88,

        /// <summary>Subsidiary Company</summary>
        /// <remarks>Reciprocal is OLI_REL_HOLDINGCO</remarks>
        [XmlEnum("89")]
        OLI_REL_SUBSIDIARYCO = 89,

        /// <summary>Paramed Company</summary>
        /// <remarks>Reciprocal is OLI_REL_PMEDEXAMINER</remarks>
        [XmlEnum("90")]
        OLI_REL_PMEDCO = 90,

        /// <summary>Requested By</summary>
        /// <remarks>Reciprocal is OLI_REL_REQUESTOR</remarks>
        [XmlEnum("91")]
        OLI_REL_REQUESTEDBY = 91,

        /// <summary>Grandparent</summary>
        /// <remarks>Reciprocal is OLI_REL_GRANDCHILD</remarks>
        [XmlEnum("92")]
        OLI_REL_GRANDPARENT = 92,

        /// <summary>Grandchild</summary>
        /// <remarks>Reciprocal is OLI_REL_GRANDPARENT</remarks>
        [XmlEnum("93")]
        OLI_REL_GRANDCHILD = 93,

        /// <summary>Step-Child</summary>
        /// <remarks>Reciprocal is OLI_REL_STEPPARENT</remarks>
        [XmlEnum("94")]
        OLI_REL_STEPCHILD = 94,

        /// <summary>Counter signing Agent</summary>
        /// <remarks>Reciprocal is OLI_REL_COUNTERAGENT</remarks>
        [XmlEnum("95")]
        OLI_REL_COUNTERAGENT = 95,

        /// <summary>Applicant</summary>
        /// <remarks>Reciprocal is OLI_REL_APPLICANT</remarks>
        [XmlEnum("96")]
        OLI_REL_APPLICANT = 96,

        /// <summary>Requestor</summary>
        /// <remarks>Reciprocal is OLI_REL_REQUESTEDBY</remarks>
        [XmlEnum("97")]
        OLI_REL_REQUESTOR = 97,

        /// <summary>Fulfills</summary>
        /// <remarks>Reciprocal is OLI_REL_FULFILLEDBY</remarks>
        [XmlEnum("99")]
        OLI_REL_FULFILLS = 99,

        /// <summary>Fulfilled By</summary>
        /// <remarks>Reciprocal is OLI_REL_FULFILLS</remarks>
        [XmlEnum("100")]
        OLI_REL_FULFILLEDBY = 100,

        /// <summary>Scenario Participant</summary>
        /// <remarks>Reciprocal is OLI_REL_SCENPART</remarks>
        [XmlEnum("101")]
        OLI_REL_SCENPART = 101,

        /// <summary>Medical Provider</summary>
        /// <remarks>Reciprocal is OLI_REL_PATIENT</remarks>
        [XmlEnum("102")]
        OLI_REL_MEDPROVIDER = 102,

        /// <summary>Nominee Name</summary>
        /// <remarks>Reciprocal is OLI_REL_NOMINATOR</remarks>
        [XmlEnum("103")]
        OLI_REL_NOMINEE = 103,

        /// <summary>Intermediary</summary>
        /// <remarks>Reciprocal is OLI_REL_INTERMEDIARY</remarks>
        [XmlEnum("104")]
        OLI_REL_INTERMEDIARY = 104,

        /// <summary>Form has been attached to another form.</summary>
        /// <remarks>Reciprocal is OLI_REL_ATTACHEDTOFORM</remarks>
        [XmlEnum("105")]
        OLI_REL_ATTACHEDFORM = 105,

        /// <summary>This form has been physically included in another form.</summary>
        /// <remarks>Reciprocal is OLI_REL_ADDTOFORM</remarks>
        [XmlEnum("106")]
        OLI_REL_INCLUDEFORM = 106,

        /// <summary>Indicating which person the form is filled out for, or which holding the form is part of.</summary>
        /// <remarks>Reciprocal is OLI_REL_FORMFOR</remarks>
        [XmlEnum("107")]
        OLI_REL_FORMFOR = 107,

        /// <summary>Signing Officer</summary>
        /// <remarks>Reciprocal is OLI_REL_SIGNINGOFFICER</remarks>
        [XmlEnum("108")]
        OLI_REL_SIGNINGOFFICER = 108,

        /// <summary>Creditor</summary>
        /// <remarks>Reciprocal is OLI_REL_CREDITOROF</remarks>
        [XmlEnum("109")]
        OLI_REL_CREDITOR = 109,

        /// <summary>Creditor Of</summary>
        /// <remarks>Reciprocal is OLI_REL_CREDITOR</remarks>
        [XmlEnum("110")]
        OLI_REL_CREDITOROF = 110,

        /// <summary>Fiancée</summary>
        /// <remarks>Reciprocal is OLI_REL_FIANCEE</remarks>
        [XmlEnum("111")]
        OLI_REL_FIANCEE = 111,

        /// <summary>Underwriter</summary>
        /// <remarks>Reciprocal is OLI_REL_UNDERWRITER</remarks>
        [XmlEnum("112")]
        OLI_REL_UNDERWRITER = 112,

        /// <summary>Power of Attorney</summary>
        /// <remarks>Reciprocal is OLI_REL_POWEROFATTRNYFOR</remarks>
        [XmlEnum("113")]
        OLI_REL_POWEROFATTRNY = 113,

        /// <summary>Power of Attorney For xxx</summary>
        /// <remarks>Reciprocal is OLI_REL_POWEROFATTRNY</remarks>
        [XmlEnum("114")]
        OLI_REL_POWEROFATTRNYFOR = 114,

        /// <summary>Banker</summary>
        /// <remarks>Reciprocal is OLI_REL_BANKEROF</remarks>
        [XmlEnum("115")]
        OLI_REL_BANKER = 115,

        /// <summary>Banker of</summary>
        /// <remarks>Reciprocal is OLI_REL_BANKER</remarks>
        [XmlEnum("116")]
        OLI_REL_BANKEROF = 116,

        /// <summary>Attached To Form</summary>
        /// <remarks>Used in Form AttachmentsReciprocal to OLI_REL_ATTACHEDFORM</remarks>
        [XmlEnum("117")]
        OLI_REL_ATTACHEDTOFORM = 117,

        /// <summary>Add To Form</summary>
        /// <remarks>This is the reciprocal to OLI_REL_INCLUDEFORM.  In this case the related object is being added as part of the originating object's form.Reciprocal is OLI_REL_INCLUDEFORM</remarks>
        [XmlEnum("118")]
        OLI_REL_ADDTOFORM = 118,

        /// <summary>Payee</summary>
        /// <remarks>One who receives payment as disbursement of funds from the holding, typically an insured, owner or beneficiary. This role code is not intended to be used for commission payments.</remarks>
        [XmlEnum("119")]
        OLI_RELPAYEE = 119,

        /// <summary>Agent of Agency</summary>
        /// <remarks>This is a relationship showing the party is an agent of an AgencyReciprocal is OLI_REL_AGENCYOF</remarks>
        [XmlEnum("120")]
        OLI_REL_AGENTOF = 120,

        /// <summary>Agency</summary>
        /// <remarks>This is the Agency a Producer party works for.Reciprocal is OLI_REL_AGENTOF if relation is Party-to-Party. Reciprocal is OLI_REL_AGENCYWRIT if relation is Holding-to-Party.</remarks>
        [XmlEnum("121")]
        OLI_REL_AGENCYOF = 121,

        /// <summary>Original Holding</summary>
        /// <remarks>Reciprocal is OLI_REL_ALTHOLDING</remarks>
        [XmlEnum("122")]
        OLI_REL_ORIGINALHOLDING = 122,

        /// <summary>Alternate Holding</summary>
        /// <remarks>This is used to tie two or more policies together, but all the related policies being submitted to the Carrier will not be issued. The Carrier will issue one or the other.Reciprocal is OLI_REL_ORIGINALHOLDING</remarks>
        [XmlEnum("123")]
        OLI_REL_ALTHOLDING = 123,

        /// <summary>Additional Holding</summary>
        /// <remarks>This is used to tie two or more policies together. In this case, all the related policies are being submitted to the Carrier for issue.  (e.g.. An agent may submit more than one application on the SAME insured, and would like the Carrier to process these at the same time. The agent can then provide the issued policies together to the Client).Reciprocal is OLI_REL_ORIGADDHOLDING</remarks>
        [XmlEnum("124")]
        OLI_REL_ADDHOLDING = 124,

        /// <summary>Original to Additional Holding</summary>
        /// <remarks>Reciprocal is OLI_REL_ADDHOLDING</remarks>
        [XmlEnum("125")]
        OLI_REL_ORIGADDHOLDING = 125,

        /// <summary>Additional Servicing Agent</summary>
        /// <remarks>This is an Additional Servicing Agent</remarks>
        [XmlEnum("126")]
        OLI_REL_ADDSERVAGT = 126,

        /// <summary>Third Party Designee</summary>
        /// <remarks>The 3rd Party Designee is an additional contact for ALL communications (unless further restricted by DeliveryInfo) regarding the policy.  To indicate the recipient of only billing notices, use the RelationRoleCode of BillRecipient.  This is also known as the Party who is the secondary addressee.</remarks>
        [XmlEnum("127")]
        OLI_REL_3RDPARTYDESIGNEE = 127,

        /// <summary>Qualified Adult</summary>
        /// <remarks>A  person  of  the  same  or opposite sex who meets all the criteria listed below.  1) He or she is over the age of 18. 2) He or she has lived with you for at least 12 months. 3) He or she has a serious and committed relationship with you. 4) He or she is not legally married nor a Domestic Partner to anyone else. 5) He or she is financially interdependent with you Financially interdependent means that you and this person are jointly responsible for the cost of food and housingReciprocal is OLI_REL_QUALADLT</remarks>
        [XmlEnum("128")]
        OLI_REL_QUALADLT = 128,

        /// <summary>PVT MetLife Servicer is a call center person</summary>
        [XmlEnum("130")]
        OLI_REL_SERVICER = 130,

        /// <summary>Step Parent</summary>
        /// <remarks>Reciprocal is OLI_REL_STEPCHILD</remarks>
        [XmlEnum("131")]
        OLI_REL_STEPPARENT = 131,

        /// <summary>Great Grandchild</summary>
        /// <remarks>Reciprocal is OLI_REL_GREATGRANDPARENT</remarks>
        [XmlEnum("132")]
        OLI_REL_GREATGRANDCHILD = 132,

        /// <summary>Great Grandparent</summary>
        /// <remarks>Reciprocal is OLI_REL_GREATGRANDCHILD</remarks>
        [XmlEnum("133")]
        OLI_REL_GREATGRANDPARENT = 133,

        /// <summary>Foster Child</summary>
        /// <remarks>Reciprocal is OLI_REL_FOSTERPARENT</remarks>
        [XmlEnum("134")]
        OLI_REL_FOSTERCHILD = 134,

        /// <summary>Foster Parent</summary>
        /// <remarks>Reciprocal is OLI_REL_FOSTERCHILD</remarks>
        [XmlEnum("135")]
        OLI_REL_FOSTERPARENT = 135,

        /// <summary>Foster Sibling</summary>
        /// <remarks>Reciprocal is OLI_REL_FOSTERSIBLING</remarks>
        [XmlEnum("136")]
        OLI_REL_FOSTERSIBLING = 136,

        /// <summary>God Child</summary>
        /// <remarks>Reciprocal is OLI_REL_GODPARENT</remarks>
        [XmlEnum("137")]
        OLI_REL_GODCHILD = 137,

        /// <summary>God Parent</summary>
        /// <remarks>Reciprocal is OLI_REL_GODCHILD</remarks>
        [XmlEnum("138")]
        OLI_REL_GODPARENT = 138,

        /// <summary>Parents-in-law</summary>
        /// <remarks>Reciprocal is OLI_REL_CHILDINLAW</remarks>
        [XmlEnum("139")]
        OLI_REL_PARENTINLAW = 139,

        /// <summary>Ceding Company to Reinsurance Company</summary>
        /// <remarks>Reciprocal is OLI_REL_REINSURERTOCEDE</remarks>
        [XmlEnum("141")]
        OLI_REL_CEDETOREINSURER = 141,

        /// <summary>Reinsurance Company to Retrocessionaire</summary>
        /// <remarks>Reciprocal is OLI_REL_RETROTO REINSURER</remarks>
        [XmlEnum("142")]
        OLI_REL_REINSURERTORETRO = 142,

        /// <summary>Specific Coverage to Reinsurance Carrier</summary>
        /// <remarks>Reciprocal is OLI_REL_COVERTOREINSURER</remarks>
        [XmlEnum("143")]
        OLI_REL_COVERTOREINSURER = 143,

        /// <summary>Primary Holding for a Collection</summary>
        /// <remarks>Primary Holding for a Collection of Applications that will be underwritten together and issued together (Keep Together).</remarks>
        [XmlEnum("144")]
        OLI_REL_PRIMARY = 144,

        /// <summary>Assignee</summary>
        /// <remarks>Reciprocal is OLI_REL_ASSIGNEE</remarks>
        [XmlEnum("145")]
        OLI_REL_ASSIGNEE = 145,

        /// <summary>Business Associate</summary>
        /// <remarks>Reciprocal is OLI_REL_BUSINESSASSOCIATE</remarks>
        [XmlEnum("146")]
        OLI_REL_BUSINESSASSOCIATE = 146,

        /// <summary>Plan Participant</summary>
        /// <remarks>Reciprocal is OLI_REL_PLANSPONSOR</remarks>
        [XmlEnum("148")]
        OLI_REL_PLANPARTICIPANT = 148,

        /// <summary>Depositor</summary>
        /// <remarks>The person within the Payer organization who is responsible for making sure that payments are made.Reciprocal is OLI_REL_DEPOSITOR</remarks>
        [XmlEnum("149")]
        OLI_REL_DEPOSITOR = 149,

        /// <summary>Authorized Person</summary>
        /// <remarks>Reciprocal is OLI_REL_AUTHORIZEDPERSON</remarks>
        [XmlEnum("150")]
        OLI_REL_AUTHORIZEDPERSON = 150,

        /// <summary>PVT Met  Dental Provider</summary>
        /// <remarks>Provider of Dental products and servicesReciprocal is OLI_REL_PATIENT</remarks>
        [XmlEnum("152")]
        OLI_REL_DENTAL_PROVIDER = 152,

        /// <summary>Contingent Annuitant</summary>
        /// <remarks>On a deferred annuity, the Contingent Annuitant is a party who will become a covered person in the event that the primary and joint covered person(s) die before the contract is terminated or annuitized (i.e. during the deferred period).On an immediate annuity or an annuity in the annuitization/payout phase where there is more than one covered person (a joint policy), the Contingent Annuitant identifies which covered person's death identifies the 'contingency' (upon whose death benefits will be reduced), if reductions are applicable to the policy.See also Annuitant and Joint Annuitant Descriptions, BenefitReductionBasedOn.</remarks>
        [XmlEnum("153")]
        OLI_REL_CONTINGENTANNUITANT = 153,

        /// <summary>Servicing Agency</summary>
        /// <remarks>The servicing agency - used for relations between the holding and the agency.Reciprocal is OLI_REL_SERVAGENCY</remarks>
        [XmlEnum("154")]
        OLI_REL_SERVAGENCY = 154,

        /// <summary>Business</summary>
        /// <remarks>Reciprocal is OLI_REL_BUSINESS</remarks>
        [XmlEnum("156")]
        OLI_REL_BUSINESS = 156,

        /// <summary>Romantic Interest of some kind</summary>
        /// <remarks>Reciprocal is OLI_REL_ROMANTICINTEREST</remarks>
        [XmlEnum("158")]
        OLI_REL_ROMANTICINTEREST = 158,

        /// <summary>Non Relative</summary>
        /// <remarks>Reciprocal is OLI_REL_NONRELATIVE</remarks>
        [XmlEnum("160")]
        OLI_REL_NONRELATIVE = 160,

        /// <summary>PVT Met Part of a Multi-Relationship</summary>
        /// <remarks>Similar to "Family" (OLI_REL_FAMILY), only the participants that comprise the "Multi-Relationship" may be a mixture of family members and non-family members.  The non-family member may even represent a trust.  This is mainly used for beneficiaries and ownReciprocal is OLI_REL_MULTREL</remarks>
        [XmlEnum("161")]
        OLI_REL_MULTREL = 161,

        /// <summary>Claim Processor</summary>
        /// <remarks>Describes the role of Claims Processor between a Party and either a Holding or a PolicyProduct indicating that the designated Party has been assigned the responsibility for processing claims on the designated holdings or products.Reciprocal is OLI_REL_CLAIMPROCESSOR</remarks>
        [XmlEnum("162")]
        OLI_REL_CLAIMPROCESSOR = 162,

        /// <summary>Deprecated in release 2.7.90 because the DistributionAgreement object supersedes this functionality.</summary>
        /// <remarks>Reciprocal is OLI_REL_MAYSELL</remarks>
        [XmlEnum("163")]
        OLI_REL_MAYSELL = 163,

        /// <summary>Retiree</summary>
        /// <remarks>Describes a relationship from a person to an organization, in which the person has retired from employment with that organization.</remarks>
        [XmlEnum("164")]
        OLI_REL_RETIREE = 164,

        /// <summary>Pvt Met Multiple Birth Sibling</summary>
        /// <remarks>Describes a relationship from a sibling to a sibling which signifies a multiple birth, such as Twins, Triplets, Quadruplets etc.Reciprocal is OLI_REL_MULTIBIRTHSIBLING</remarks>
        [XmlEnum("165")]
        OLI_REL_MULTIBIRTHSIBLING = 165,

        /// <summary>Converted</summary>
        /// <remarks>Used to define the relationship between an existing policy and a new application, where the conversion of the existing policy is not an Exchange (see tc=67/68) or Replacement (see tc=63/64).  A converted policy is one completed within a carrier, generally from one product to another.</remarks>
        [XmlEnum("166")]
        OLI_REL_CONVERTED = 166,

        /// <summary>Converted To</summary>
        /// <remarks>Used to define the relationship between a new application and an existing policy, where the conversion of the existing policy is not an Exchange (see tc=67/68) or Replacement (see tc=63/64).  A converted policy is one completed within a carrier, generally from one product to another.</remarks>
        [XmlEnum("167")]
        OLI_REL_CONVERTEDTO = 167,

        /// <summary>Self</summary>
        /// <remarks>Used in Product. Also used to describe the relationship between two roles on a contract such as when a producer sells a policy to him(her)self as an insured.</remarks>
        [XmlEnum("168")]
        OLI_REL_SELF = 168,

        /// <summary>All but self</summary>
        /// <remarks>Used in product</remarks>
        [XmlEnum("169")]
        OLI_REL_NOTSELF = 169,

        /// <summary>Half Sibling</summary>
        /// <remarks>Half Sibling - siblings have one parent in common.   For example,  same mother, different fathers.Reciprocal is OLI_REL_HALFSIBLING</remarks>
        [XmlEnum("170")]
        OLI_REL_HALFSIBLING = 170,

        /// <summary>Child-in-Law</summary>
        /// <remarks>Non-gender specific title for a son-in-law and daughter-in law.Reciprocal is OLI_REL_PARENTINLAW</remarks>
        [XmlEnum("171")]
        OLI_REL_CHILDINLAW = 171,

        /// <summary>Step-Sibling</summary>
        /// <remarks>Step-Sibling - siblings have no blood relations, different parents, however parents are married to each other.Reciprocal is OLI_REL_STEPSIBLING</remarks>
        [XmlEnum("172")]
        OLI_REL_STEPSIBLING = 172,

        /// <summary>Common Law Spouse</summary>
        /// <remarks>A partnership relationship that was not created by marriage, but exists as a result of state/local laws governing the establishment of spousal rights by virtue of the amount of time a couple has been living together.Reciprocal is OLI_REL_COMMLAWSPOUSE</remarks>
        [XmlEnum("173")]
        OLI_REL_COMMLAWSPOUSE = 173,

        /// <summary>Former Spouse</summary>
        /// <remarks>Reciprocal is OLI_REL_FORMERSPOUSE</remarks>
        [XmlEnum("174")]
        OLI_REL_FORMERSPOUSE = 174,

        /// <summary>Contingent Owner</summary>
        /// <remarks>Contingent owner(s) assumes the full owner rights upon the death of all Primary Owners, and are typically identified at or after an application is issued, and certainly before the death of the Primary Owner(s).</remarks>
        [XmlEnum("177")]
        OLI_REL_CONTGTOWNER = 177,

        /// <summary>Former Employer due to Retirement</summary>
        /// <remarks>Describes a relationship from an organization to a person, in which the person has retired from this organization.</remarks>
        [XmlEnum("178")]
        OLI_REL_RETIRINGEMP = 178,

        /// <summary>Legal Ward</summary>
        /// <remarks>A person under the guard or supervision of a designated Legal Guardian, and for whom the Legal Guardian typically assumes all parental rights and responsibilities.Reciprocal is OLI_REL_LEGALGUARD</remarks>
        [XmlEnum("179")]
        OLI_REL_LEGALWARD = 179,

        /// <summary>New to Old Address</summary>
        /// <remarks>A relationship to show explicitly the components of an address change and including the old address and new address in the relationship.Reciprocal is OLI_REL_ADDROLDTONEW</remarks>
        [XmlEnum("180")]
        OLI_REL_ADDROLDTONEW = 180,

        /// <summary>PVT Vallue Writing agent</summary>
        [XmlEnum("181")]
        OLI_REL_AGENTWRIT = 181,

        /// <summary>Writing Agency</summary>
        /// <remarks>The Agency of the Producer (Agent) who originally wrote this coverage</remarks>
        [XmlEnum("182")]
        OLI_REL_AGENCYWRIT = 182,

        /// <summary>Joint Annuitant</summary>
        /// <remarks>A named individual whose lifetime is used as a measuring life in an annuity contract.  The term annuitant is also referred to as "covered person."  On a contract with two or more annuitants, the first/primary covered person listed on the contract is referred to as the (Primary) Annuitant (tc=35) and the subsequent persons are Joint Annuitant (see tc =  183).  See also Annuitant and Contingent Annuitant.</remarks>
        [XmlEnum("183")]
        OLI_REL_JOINTANNUITANT = 183,

        /// <summary>Joint Owner</summary>
        /// <remarks>An additional owner on the contract who is NOT the primary owner.Reciprocal is OLI_REL_JOINTOWNER</remarks>
        [XmlEnum("184")]
        OLI_REL_JOINTOWNER = 184,

        /// <summary>Recruitee</summary>
        /// <remarks>This is the prospective employee or agent being recruited by an employer, agency, or agentReciprocal is OLI_REL_RECRUITER</remarks>
        [XmlEnum("185")]
        OLI_REL_RECRUITEE = 185,

        /// <summary>Recruiter</summary>
        /// <remarks>This is the employer, agency, or agent doing the recruitingReciprocal is OLI_REL_RECRUITEE</remarks>
        [XmlEnum("186")]
        OLI_REL_RECRUITER = 186,

        /// <summary>Surrendering administration carrier for exchanged policy</summary>
        /// <remarks>In the case of an external exchange, this identifies that carrier that will be surrendering the policy that is being exchanged.Reciprocal is OLI_REL_SURRCARRIER</remarks>
        [XmlEnum("187")]
        OLI_REL_SURRCARRIER = 187,

        /// <summary>Joint Insured</summary>
        /// <remarks>An additional insured on the contract who is NOT the primary insured.Reciprocal is OLI_REL_JOINTINSURED</remarks>
        [XmlEnum("189")]
        OLI_REL_JOINTINSURED = 189,

        /// <summary>Owner's (or Joint Owner's) Beneficiary</summary>
        /// <remarks>Intended for use with Ownership>AllowedRelationship to indicate that a (primary) Beneficiary may or must be collected for each Owner or Joint Owner.  For example, such as in the case on an Annuitant-Centric fixed, jointly held annuity where there are no rights of survivorship and beneficiary information is collected for each Owner and Joint Owner to ensure benefits and ownership rights are correctly transferred if an owner pre-deceases the annuitant.  This role code does NOT indicate that a Party is both the Owner and a Beneficiary.</remarks>
        [XmlEnum("191")]
        OLI_REL_OWNBENE = 191,

        /// <summary>Owner's (or Joint Owner's) Contingent Beneficiary</summary>
        /// <remarks>Intended for use with Ownership>AllowedRelationship to indicate that a Contingent Beneficiary may or must be collected for each Owner or Joint Owner.  For example, such as in the case on an Annuitant-Centric fixed, jointly held annuity where there are no rights of survivorship and beneficiary information is collected for each Owner and Joint Owner to ensure benefits and ownership rights are correctly transferred if an owner pre-deceases the annuitant.  This role code does NOT indicate that a Party is both the Owner and a Beneficiary.</remarks>
        [XmlEnum("192")]
        OLI_REL_OWNCONTBENE = 192,

        /// <summary>Plan Administrator</summary>
        /// <remarks>A plan administrator is the Party specified as the administrator by the instrument under which the plan is operated.</remarks>
        [XmlEnum("193")]
        OLI_REL_PLANADMIN = 193,

        /// <summary>Settlement info</summary>
        /// <remarks>When Licensing and Appointment fees are settled via a clearinghouse, this relates the producer party with the SettlementInfo aggregate.</remarks>
        [XmlEnum("194")]
        OLI_REL_SETTLEMENT = 194,

        /// <summary>Sibling in Law</summary>
        /// <remarks>Reciprocal is OLI_REL_SIBINLAW</remarks>
        [XmlEnum("196")]
        OLI_REL_SIBINLAW = 196,

        /// <summary>Parents Sibling</summary>
        /// <remarks>Aunt or UncleReciprocal is OLI_REL_SIBLINGSCHILD</remarks>
        [XmlEnum("198")]
        OLI_REL_PARENTSSIBLING = 198,

        /// <summary>Sibling's Child</summary>
        /// <remarks>Nephew or NieceReciprocal is OLI_REL_PARENTSSIBLING</remarks>
        [XmlEnum("199")]
        OLI_REL_SIBLINGSCHILD = 199,

        /// <summary>Co-Mortgagor</summary>
        /// <remarks>A person who, as a beneficiary, has no other relationship to the policy owner other than co-borrower on the mortgage.  Used on term life insurance for mortgage protection.This is to better define a party to party relationship between two people that share a mortgage.</remarks>
        [XmlEnum("203")]
        OLI_REL_COMORTGAGOR = 203,

        /// <summary>National Marketing Organization</summary>
        /// <remarks>A company that markets insurance products for numerous insurance carriers  Also, assists agents affiliated with them in determining the appropriate annuity and life products for agent's clients.</remarks>
        [XmlEnum("204")]
        OLI_REL_NMO = 204,

        /// <summary>Conservator</summary>
        /// <remarks>The Conservator is essentially a legal guardian for an incompetent individual where that designation carries with it different constraints and business implications than the Legal Guardian role.The Originating Party is the Conservator.</remarks>
        [XmlEnum("205")]
        OLI_REL_CONSERVATOR = 205,

        /// <summary>The entities have an affinity relationship with one another.</summary>
        /// <remarks>One use is to indicate if a Producer has a "affiliation with a Financial Institution or Bank" which is asked on licensing and due diligence questionnaires.</remarks>
        [XmlEnum("207")]
        OLI_REL_AFFILENTITY = 207,

        /// <summary>Designated/Responsible Producer</summary>
        /// <remarks>The Producer who is the responsible designated licensee affiliated with the business entity.Required for Licensing with States</remarks>
        [XmlEnum("208")]
        OLI_REL_DESRESPPROD = 208,

        /// <summary>Designated/Responsible Owner/Partner (not Officer/Director)</summary>
        /// <remarks>The Corporate Owner or Partner party affiliated with the business entity.Required for Licensing with States.</remarks>
        [XmlEnum("209")]
        OLI_REL_DESRESPOFF = 209,

        /// <summary>Designated/Responsible Officer/Director (not Owner/Partner)</summary>
        /// <remarks>The Corporate Officer or Director party affiliated with the business entity.</remarks>
        [XmlEnum("210")]
        OLI_REL_DESRESPDIR = 210,

        /// <summary>The child of an aunt or uncle.</summary>
        /// <remarks>Use relation description if male or female differentiation is needed.Reciprocal is OLI_REL_COUSIN</remarks>
        [XmlEnum("211")]
        OLI_REL_COUSIN = 211,

        /// <summary>Regional Office</summary>
        /// <remarks>Remote processing center</remarks>
        [XmlEnum("212")]
        OLI_REL_REGIONALOFFICE = 212,

        /// <summary>Home Office</summary>
        /// <remarks>Corporate Headquarters</remarks>
        [XmlEnum("213")]
        OLI_REL_HOMEOFFICE = 213,

        /// <summary>Reinsurer to Cedent</summary>
        /// <remarks>Reciprocal is OLI_REL_CEDETOREINSURER</remarks>
        [XmlEnum("214")]
        OLI_REL_REINSURERTOCEDE = 214,

        /// <summary>Retrocessionnaire to Reinsurer</summary>
        /// <remarks>Reciprocal is OLI_REL_REINSURETORETRO</remarks>
        [XmlEnum("215")]
        OLI_REL_RETROTOREINSURER = 215,

        /// <summary>Whether the agent's office is remote or not</summary>
        /// <remarks>A detached office is a  physical location which is in a different location than the agent's assigned office. The detached office needs to be associated with the assigned office.The Detached Party is the related Party.</remarks>
        [XmlEnum("216")]
        OLI_REL_DETOFFICE = 216,

        /// <summary>Campaign</summary>
        [XmlEnum("217")]
        OLI_REL_CAMPAIGN = 217,

        /// <summary>Experience Group</summary>
        /// <remarks>The Grouping represents a subdivision of the associated employer organization's employee population used in rating, provisioning, and administering group insurance.</remarks>
        [XmlEnum("218")]
        OLI_REL_EXPGROUP = 218,

        /// <summary>Government Allotter</summary>
        /// <remarks>Government official who administers the government allotment</remarks>
        [XmlEnum("220")]
        OLI_REL_GOVTALLOTTER = 220,

        /// <summary>Payment Receiving Agency</summary>
        /// <remarks>Agency Receiving Payments for the Policy of the Deceased.</remarks>
        [XmlEnum("221")]
        OLI_REL_PAYRECAGENCY = 221,

        /// <summary>Adoptive Parent</summary>
        [XmlEnum("223")]
        OLI_REL_ADOPTPARENT = 223,

        /// <summary>Adopted Child</summary>
        [XmlEnum("224")]
        OLI_REL_ADOPTCHILD = 224,

        /// <summary>Dividend Payee</summary>
        /// <remarks>The Dividend Payee role is the person who has been elected to receive dividend payments.  This role code does not imply or exclude any other insurable interest to the contract.</remarks>
        [XmlEnum("227")]
        OLI_REL_DIVPAY = 227,

        /// <summary>Successor Custodian</summary>
        /// <remarks>A person designated as the successor to the associated Custodian.  This person will assume custodial duties in the event of the designated custodian's death or incapacitation.</remarks>
        [XmlEnum("228")]
        OLI_REL_SUCCESSORCUSTODIAN = 228,

        /// <summary>Assistant</summary>
        /// <remarks>Indicates that a party is the "Administrative Assistant" of another Party.</remarks>
        [XmlEnum("230")]
        OLI_REL_ASSISTANT = 230,

        /// <summary>Assistee</summary>
        /// <remarks>The entity supported by the related Administrative Assistant</remarks>
        [XmlEnum("231")]
        OLI_REL_ASSISTEE = 231,

        /// <summary>Child Not Yet Legally Adopted</summary>
        /// <remarks>For example, used to answer question on application for insurance 'Are the dependent children foster children or children whose legal adoption is not final?'</remarks>
        [XmlEnum("232")]
        OLI_REL_CHILDNOTYETADOPT = 232,

        /// <summary>Prior Client</summary>
        /// <remarks>The client/applicant for this transaction had a relationship with the producer in that a business transaction has previously been completed some time in the past. Note that, if the related Party is also a current client, the Client relationship must also be expressed.</remarks>
        [XmlEnum("234")]
        OLI_REL_PRIORCLIENT = 234,

        /// <summary>Case Manager</summary>
        /// <remarks>Carrier employee who acts as a personal liaison on a Holding or Case. During the new business or claims processes, the case may be overseen from creation through issue. Assignment may vary dependent on customer worth.</remarks>
        [XmlEnum("235")]
        OLI_REL_CASEMANAGER = 235,

        /// <summary>Grantor</summary>
        /// <remarks>The individual who establishes a trust (may also be referred to as the "settler).</remarks>
        [XmlEnum("236")]
        OLI_REL_GRANTOR = 236,

        /// <summary>Language Interpreter</summary>
        /// <remarks>Indicates the Party that acts as a language interpreter for the Originating Party (i.e. Paul is Joe's interpreter;  Joe is the Originating Party).  For example, in instances where the applicant does not speak the language that the carrier received the application in, an interpreter is used by the applicant to fill out the insurance application to be submitted.</remarks>
        [XmlEnum("237")]
        OLI_REL_LNGINTRPRTR = 237,

        /// <summary>Grantee</summary>
        /// <remarks>The individual for whom a trust is established by a grantor.</remarks>
        [XmlEnum("238")]
        OLI_REL_GRANTEE = 238,

        /// <summary>Case Managed By</summary>
        /// <remarks>A holding which is overseen by a Carrier employee who acts as a personal liaison on a case. In the new business or claims processes, the case may be overseen from creation through issue. Assignment may vary dependent on customer worth.</remarks>
        [XmlEnum("239")]
        OLI_REL_CASEMNGBY = 239,

        /// <summary>Task</summary>
        /// <remarks>This is the 'Task’ to associate an Activity to another Activity.  This is commonly used to associate ActivityType of "Correspondence" with activities that have actionable tasks.</remarks>
        [XmlEnum("240")]
        OLI_REL_TASK = 240,

        /// <summary>Recipient</summary>
        /// <remarks>One who is the receiver of activities of type ‘correspondence’</remarks>
        [XmlEnum("241")]
        OLI_REL_RECIPIENT = 241,

        /// <summary>Interpretee</summary>
        /// <remarks>Indicates the Party for whom a language was interpreted. The Party who performs the interpreting is the Originating Party (i.e. Paul interpreted for Joe; Paul is the Originating Party).For example, in instances where the applicant does not speak the language that the carrier received the application in, an interpreter is used by the applicant to fill out the insurance application to be submitted. In this example, the applicant would also be the interpretee.</remarks>
        [XmlEnum("242")]
        OLI_REL_LNGINTRPRTE = 242,

        /// <summary>Case</summary>
        /// <remarks>Documents that a particular Holding is part of an overall Case.</remarks>
        [XmlEnum("243")]
        OLI_REL_CASE = 243,

        /// <summary>Notary Public</summary>
        /// <remarks>Identifies the relationship of a party as Notary Public.</remarks>
        [XmlEnum("244")]
        OLI_REL_NOTARYPUBLIC = 244,

        /// <summary>Physical Therapist</summary>
        /// <remarks>Used to define the MedProviderType of physical therapist for DisabilityHealthProducts</remarks>
        [XmlEnum("245")]
        OLI_REL_PHYSICALTHERAPIST = 245,

        /// <summary>Skilled Nurse</summary>
        /// <remarks>Used to define the MedProviderType of skilled nurse for DisabilityHealthProducts</remarks>
        [XmlEnum("246")]
        OLI_REL_SKILLEDNURSE = 246,

        /// <summary>Succeeding Beneficiary</summary>
        /// <remarks>A "succeeding beneficiary" is a beneficiary which succeeds a specific party or unnamed beneficiaries.  A succeeding beneficiary is not a contingent beneficiary, in that contingent indicates *all* entities of the higher level class must pre-decease the insured, owner or annuitant (in accordance with the rules of the contract).For example, if two "per stirpes" primary beneficiaries are named (A and B), and each primary beneficiary specifically names their "per stirpes issues" (A's beneficiaries are X and Y, and B's beneficiaries are all children of the primary beneficiary).  See also Beneficiary Share Method.</remarks>
        [XmlEnum("247")]
        OLI_REL_SUCCEEDBENE = 247,

        /// <summary>Authorized user</summary>
        /// <remarks>Sometimes a credit card holder will want to give another person (often a spouse, partner, or child) access to the account. A business may have a corporate credit card account, and may give some employees authorized user status, including individual cards, to be used for business expenses. While a co-applicant is equally responsible for paying all charges on the account, regardless of who made them, an authorized user is not legally or contractually responsible for any charges, including those that s/he made. The primary cardholder (the one who actually applied for the card) is considered to be fully liable for all charges on the account, including those made by any authorized users.</remarks>
        [XmlEnum("248")]
        OLI_REL_AUTHUSER = 248,

        /// <summary>Collateral Assignee</summary>
        /// <remarks>The Party playing the role to whom rights to a benefit are assigned.  A life insurance policy is assigned by  the assignor to the assignee as security for a loan.</remarks>
        [XmlEnum("250")]
        OLI_REL_COLLASSIGNEE = 250,

        /// <summary>Coverage Primary Agent</summary>
        /// <remarks>Entity that was the writing agent for an individual insurance coverage/rider not at the contract level.</remarks>
        [XmlEnum("251")]
        OLI_REL_COVPRIMARYAGENT = 251,

        /// <summary>Coverage Servicing Agent</summary>
        /// <remarks>Entity that was the servicing agent for an individual insurance coverage/rider not at the contract level.</remarks>
        [XmlEnum("252")]
        OLI_REL_COVSERVAGENT = 252,

        /// <summary>Ancillary Holding to Primary Holding</summary>
        /// <remarks>This indicates that there is a relationship between the Ancillary Holding (Child) and the Primary Holding (Parent).  The Ancillary Holding/s cannot exist on its own and therefore needs to be linked to a Primary Holding.</remarks>
        [XmlEnum("253")]
        OLI_REL_ANCILLARY = 253,

        /// <summary>Primary Holding for one or more Ancillary Holdings</summary>
        /// <remarks>This indicates that there is a relationship between the Primary Holding (Parent) and the Ancillary Holding/s (Child). A Primary Holding must always exist before an Ancillary Holding can exist.</remarks>
        [XmlEnum("254")]
        OLI_REL_ANCILLARYPARENT = 254,

        /// <summary>Suitability and Compliance Reviewer</summary>
        /// <remarks>Indicates the Party that reviewed the new business application or inforce transaction (such as a subsequent premium or fund transfer) for suitability and compliance purposes.  This role is sometimes referred to the person acting as an OSJ (“Office of Supervisory Jurisdiction");  this role is not an underwriter.</remarks>
        [XmlEnum("255")]
        OLI_REL_REVIEWER = 255,

        /// <summary>Holding is Part of a Structured Settlement Case</summary>
        /// <remarks>This defines that the Holding is under case management because it is part of a Structured Settlement Case.  In the US, the related Holding must fit the Internal Revenue Service definition of a Structured Settlement.</remarks>
        [XmlEnum("256")]
        OLI_REL_SETTLEMENTCASE = 256,

        /// <summary>Registered Investment Advisor</summary>
        /// <remarks>A Registered Investment Adviser ("RIA") is an entity who, for compensation (in any form), engages in the business of advising others, either directly or indirectly, of the value of securities or of the advisability of investing in securities. They receive a management fees and do not receive commissions ("RIAs receive fees, stockbrokers receive commissions").   Incentive fees can be charged if certain conditions are met.</remarks>
        [XmlEnum("257")]
        OLI_REL_RIA = 257,

        /// <summary>Submitter</summary>
        /// <remarks>This is the submitter of the information captured in the holding.</remarks>
        [XmlEnum("258")]
        OLI_REL_SUBMITTER = 258,

        /// <summary>Form Preparer</summary>
        /// <remarks>Preparer of the form</remarks>
        [XmlEnum("259")]
        OLI_REL_FORMPREPARER = 259,

        /// <summary>Primary Contact</summary>
        /// <remarks>This is the primary contact to use for this holding.</remarks>
        [XmlEnum("260")]
        OLI_REL_PRIMCONTACT = 260,

        /// <summary>Marketing Team</summary>
        /// <remarks>The team represents the members who were involved with the sale of the Holding. The individual members of the team may or may not be documented as a participant on the policy. The “team itself” never serves as a documented participant in any specific role (such as writing agent) on the policy.</remarks>
        [XmlEnum("261")]
        OLI_REL_MARKETINGTEAM = 261,

        /// <summary>Response Party</summary>
        /// <remarks>The party that receives responses</remarks>
        [XmlEnum("262")]
        OLI_REL_RESPONSEPARTY = 262,

        /// <summary>Biological Child</summary>
        [XmlEnum("263")]
        OLI_REL_BIOCHILD = 263,

        /// <summary>Unborn Child</summary>
        [XmlEnum("264")]
        OLI_REL_UNBORN = 264,

        /// <summary>Authentication Challenge/Response Questions Party</summary>
        /// <remarks>Associates a FormInstance/FormResponse question/answer challenge/response set of questions for authenticating  or validating a person is who they are. Typically used for eSigning ceremonies, website authentification and other events where you need to challenge a person to see who they are based on a known set of questions.</remarks>
        [XmlEnum("265")]
        OLI_REL_CRFOR = 265,

        /// <summary>Additional Compensation Recipient</summary>
        /// <remarks>A person or organization that receives  compensation on a policy in addition to the primary writing agent.  This is commonly referred to as a "third party payee".  The exact nature of the person or entity is not known.</remarks>
        [XmlEnum("275")]
        OLI_REL_ADDLCOMPRECIPIENT = 275,

        /// <summary>Informant</summary>
        /// <remarks>A person who supplies covert information or exposes unethical practices related to either the Holding or the Party; (i.e. a whistleblower)</remarks>
        [XmlEnum("276")]
        OLI_REL_INFORMANT = 276,

        /// <summary>Funeral Parlour</summary>
        /// <remarks>The Party contracted to finalise the burial of a deceased on the Holding.  This could also be a funeral home.</remarks>
        [XmlEnum("277")]
        OLI_REL_PARLOUR = 277,

        /// <summary>Companion</summary>
        /// <remarks>A description of a relationship between two people where one is a caretaker of the other.</remarks>
        [XmlEnum("278")]
        OLI_REL_COMPANION = 278,

        /// <summary>Mentor</summary>
        /// <remarks>A Party who provides mentoring to another Party</remarks>
        [XmlEnum("279")]
        OLI_REL_MENTOR = 279,

        /// <summary>Mentored By</summary>
        /// <remarks>A Party who is being mentored by another Party</remarks>
        [XmlEnum("280")]
        OLI_REL_MENTOREDBY = 280,

        /// <summary>Attorney's Client</summary>
        /// <remarks>A Party who is the recipient of attorney servicesAn attorney in this sense is 'a professional person or firm authorized to practice law or give legal advice', includes lawyers, legal counsels, counselar-at-law, legal advocates, and legal advisors.  Synonymous with the Canadian and British terms: solicitor and barrister.</remarks>
        [XmlEnum("281")]
        OLI_REL_ATTORNEYCLIENT = 281,

        /// <summary>Managing Office</summary>
        /// <remarks>A Organization that is managing another Organization</remarks>
        [XmlEnum("282")]
        OLI_REL_MANAGINGOFFICE = 282,

        /// <summary>Managed Office</summary>
        /// <remarks>An Organization that is being managed by another Organization</remarks>
        [XmlEnum("283")]
        OLI_REL_MANAGEDOFFICE = 283,

        /// <summary>Associate Member</summary>
        /// <remarks>A Party who is Associate Member of a group or organization.A member of the organization that does not have full membership rights.  Possibly a dues paying member but with a restricted membership.   Other terms:  "Social Member", "Partial Member".Examples of "associate members":  a member of a stock exchange that does not have a seat on the exchange, "friends of the group" that may participate in meetings and events but not hold elected office, and "members-in-training", that is, those members holding all the privileges of full membership while going through a probationary period.</remarks>
        [XmlEnum("284")]
        OLI_REL_ASSOCIATEMEMBER = 284,

        /// <summary>Legal Interest</summary>
        /// <remarks>A Party who has a legal interest in the Holding or Policy</remarks>
        [XmlEnum("285")]
        OLI_REL_LEGALINTEREST = 285,

        /// <summary>Accountant</summary>
        /// <remarks>A Party who is acting in the capacity of an Accountant for another PartyAn accountant is a Party that performs accounting services.  This role is not limited to certified public accountant (CPA) individuals or firms.  May be a public accountant, private accountant, or any party designated to perform accounting services.</remarks>
        [XmlEnum("286")]
        OLI_REL_ACCOUNTANT = 286,

        /// <summary>Attorney</summary>
        /// <remarks>A Party who is acting in the capacity of an Attorney for another Party.This is a Party whose second Party is serving as an attorney.  An attorney in this sense is 'a professional person or firm authorized to practice law or give legal advice', includes lawyers, legal counsels, counselar-at-law, legal advocates, and legal advisors.  Synonymous with the Canadian and British terms: solicitor and barrister.</remarks>
        [XmlEnum("287")]
        OLI_REL_ATTORNEY = 287,

        /// <summary>Accountant's Client</summary>
        /// <remarks>A Party who is the recipient of accounting servicesAn accountant is a Party that performs accounting services.  This role is not limited to certified public accountant (CPA) individuals or firms.  May be a public accountant, private accountant, or any party designated to perform accounting services.</remarks>
        [XmlEnum("288")]
        OLI_REL_ACCOUNTANTCLIENT = 288,

        /// <summary>Reference</summary>
        /// <remarks>This would be used in case of employment to identify the Party that is a reference.</remarks>
        [XmlEnum("289")]
        OLI_REL_REFERENCE = 289,

        /// <summary>Reference for</summary>
        /// <remarks>This would be used in case of employment to identify the Party for whom references are being provided..</remarks>
        [XmlEnum("290")]
        OLI_REL_REFERENCEFOR = 290,

        /// <summary>Collateral For</summary>
        /// <remarks>The Holding playing the role of source of benefits</remarks>
        [XmlEnum("291")]
        OLI_REL_COLLATERALFOR = 291,

        /// <summary>Collateralized by</summary>
        /// <remarks>The Holding playing the role of recipient of benefits</remarks>
        [XmlEnum("292")]
        OLI_REL_COLLATERALIZEDBY = 292,

        /// <summary>Borrower</summary>
        /// <remarks>Party whose role on a holding is to be able to borrow funds</remarks>
        [XmlEnum("293")]
        OLI_REL_BORROWER = 293,

        /// <summary>Existing Holding With</summary>
        /// <remarks>This is a Holding that was reported during the new business and/or underwriting process as existing.  Note that the existing policy has no other explicit relationship with the Holding.  For example, do not use this relation to reference a replaced, exchanged or converted Holding.  Use other, more specific, relations for these cases.</remarks>
        [XmlEnum("294")]
        OLI_REL_EXISTINGWITH = 294,

        /// <summary>Field Wholesaler</summary>
        /// <remarks>The individual or team of Carrier employee(s) who works directly with Agents/Reg Reps in the field.</remarks>
        [XmlEnum("295")]
        OLI_REL_WHOLE_FIELD = 295,

        /// <summary>Internal Wholesaler</summary>
        /// <remarks>The individual or team of Carrier employee(s) supporting the Field Wholesaler and sales force.</remarks>
        [XmlEnum("296")]
        OLI_REL_WHOLE_INTERNAL = 296,

        /// <summary>Regional Sales Manager</summary>
        /// <remarks>The individual or team who manages Field Wholesalers for a Particular Channel and Region.</remarks>
        [XmlEnum("297")]
        OLI_REL_SALES_MANAGER_REG = 297,

        /// <summary>Operations Account Manager</summary>
        /// <remarks>The individual or team of carrier Home Office Operations Support for Top Tier Sales Force Members.</remarks>
        [XmlEnum("298")]
        OLI_REL_ACT_MANAGER_OPS = 298,

        /// <summary>Billing Recipient</summary>
        /// <remarks>Party designated to receive the billing communication (such as billing statements and lapse notices).  Note that it is assumed that the Party designated as the “Payer”  (tc=31) is also a billing recipient.  If a Payer relation for a Party is already modeled, then the Billing Recipient relation is redundant and is not required for the same Party.</remarks>
        [XmlEnum("299")]
        OLI_REL_BILLRECIPIENT = 299,

        /// <summary>Coordinator of Benefits</summary>
        /// <remarks>A Party representing the claimant or beneficiary and coordinates the benefits for this policy to insure that the correct insurance is billed and that duplicate claims are not filed.</remarks>
        [XmlEnum("300")]
        OLI_REL_COB = 300,

        /// <summary>Any Relationship is Acceptable</summary>
        /// <remarks>Should only be used in Product definitions</remarks>
        [XmlEnum("999")]
        OLI_REL_ANY = 999,

        /// <summary>All Relations are acceptable</summary>
        /// <remarks>Should only be used in Product definitions</remarks>
        [XmlEnum("1000")]
        OLI_REL_ALL = 1000,

        /// <summary>Hit</summary>
        /// <remarks>Hit indicates that the party referred to had the identifying attributes that did not conflict with the identifying attributes supplied in the inquiry.  This is commonly used in MIB transactions.</remarks>
        [XmlEnum("1001")]
        OLI_REL_HIT = 1001,

        /// <summary>Try</summary>
        /// <remarks>Try indicates that the party referred to had at least one identifying attribute which conflicted in some way with the corresponding attribute in the match. The degree of similarity, however, was greater than the minimum threshold.This code is commonly used for MIB transactions.</remarks>
        [XmlEnum("1002")]
        OLI_REL_TRY = 1002,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
