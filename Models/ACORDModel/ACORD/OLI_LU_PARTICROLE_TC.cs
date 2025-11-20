using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_PARTICROLE_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Primary Insured</summary>
        [XmlEnum("1")]
        OLI_PARTICROLE_PRIMARY = 1,

        /// <summary>Other Insured</summary>
        [XmlEnum("2")]
        OLI_PARTICROLE_OTHINSURED = 2,

        /// <summary>Insured Child</summary>
        [XmlEnum("3")]
        OLI_PARTICROLE_CHILD = 3,

        /// <summary>Insured Dependent</summary>
        [XmlEnum("4")]
        OLI_PARTICROLE_DEP = 4,

        /// <summary>Insured Spouse</summary>
        [XmlEnum("5")]
        OLI_PARTICROLE_SPOUSE = 5,

        /// <summary>Joint Insured</summary>
        [XmlEnum("6")]
        OLI_PARTICROLE_JOINT = 6,

        /// <summary>Beneficiary - Primary</summary>
        /// <remarks>When paying proceeds to beneficiaries, the beneficiaries in this role will receive proceeds first.</remarks>
        [XmlEnum("7")]
        OLI_PARTICROLE_BENE = 7,

        /// <summary>Business Partner</summary>
        [XmlEnum("8")]
        OLI_PARTICROLE_BUSPARTNER = 8,

        /// <summary>Beneficiary - Contingent</summary>
        [XmlEnum("9")]
        OLI_PARTICROLE_BENECONT = 9,

        /// <summary>Beneficiary - Tertiary</summary>
        /// <remarks>A beneficiary designated as third in line to receive the proceeds or benefits if the  primary and secondary beneficiaries do not survive the insured.</remarks>
        [XmlEnum("10")]
        OLI_PARTICROLE_BENETERT = 10,

        /// <summary>Beneficiary - Assignee</summary>
        [XmlEnum("11")]
        OLI_PARTICROLE_BENEASSIGNEE = 11,

        /// <summary>Payor</summary>
        [XmlEnum("12")]
        OLI_PARTICROLE_PAYOR = 12,

        /// <summary>Payee</summary>
        [XmlEnum("13")]
        OLI_PARTICROLE_PAYEE = 13,

        /// <summary>Correspondence Recipient</summary>
        [XmlEnum("14")]
        OLI_PARTICROLE_CORRESPONDENCE = 14,

        /// <summary>Primary Agent</summary>
        [XmlEnum("15")]
        OLI_PARTICROLE_PRIMAGENT = 15,

        /// <summary>Additional Agent</summary>
        [XmlEnum("16")]
        OLI_PARTICROLE_ADDAGENT = 16,

        /// <summary>Witness</summary>
        [XmlEnum("17")]
        OLI_PARTICROLE_WITNESS = 17,

        /// <summary>Owner</summary>
        [XmlEnum("18")]
        OLI_PARTICROLE_OWNER = 18,

        /// <summary>Trustee</summary>
        [XmlEnum("19")]
        OLI_PARTICROLE_TRUSTEE = 19,

        /// <summary>Parent or Guardian signing for minor or incompetent person.</summary>
        [XmlEnum("20")]
        OLI_PARTICROLE_PARENTGUARDIAN = 20,

        /// <summary>Counter Signing Agent</summary>
        [XmlEnum("21")]
        OLI_PARTICROLE_CTRSIGNAGENT = 21,

        /// <summary>Applicant</summary>
        /// <remarks>This relationship denotes the party applying for the policy.</remarks>
        [XmlEnum("22")]
        OLI_PARTICROLE_APPLICANT = 22,

        /// <summary>Grantor</summary>
        [XmlEnum("23")]
        OLI_PARTICROLE_GRANTOR = 23,

        /// <summary>Custodian</summary>
        /// <remarks>A person or organization such as an agent, bank, trust company, or other organization which holds and safeguards an individual's assets for them, such as mutual funds, or investment company's assets.For example, the person or organization responsible for the asset on a UGMA account where the actual owner is a minor.</remarks>
        [XmlEnum("24")]
        OLI_PARTICROLE_CUSTODIAN = 24,

        /// <summary>Plan Administrator</summary>
        [XmlEnum("25")]
        OLI_PARTICROLE_PLANADMIN = 25,

        /// <summary>Other Billing Notice Recipient</summary>
        [XmlEnum("26")]
        OLI_PARTICROLE_OTHBILLREC = 26,

        /// <summary>Annuitant</summary>
        /// <remarks>The named individual whose lifetime is used as a measuring life in an annuity contract.  Also referred to as "covered person."  Note:  on a contract with two or more annuitants, the first/primary covered person listed on the contract is referred to as the  Annuitant (RelationRoleCode tc=35) and the subsequent covered persons are called Joint Annuitant (see tc =  183).  Do not specify two parties as Annuitant.  See also Descriptions for Contingent Annuitant, Joint Annuitant.</remarks>
        [XmlEnum("27")]
        OLI_PARTICROLE_ANNUITANT = 27,

        /// <summary>Joint Annuitant</summary>
        /// <remarks>A named individual whose lifetime is used as a measuring life in an annuity contract.  The term annuitant is also referred to as "covered person."  On a contract with two or more annuitants, the first/primary covered person listed on the contract is referred to as the (Primary) Annuitant (tc=35) and the subsequent persons are Joint Annuitant (see tc =  183).  See also Annuitant and Contingent Annuitant.</remarks>
        [XmlEnum("28")]
        OLI_PARTICROLE_JNTANNUITANT = 28,

        /// <summary>Contingent Owner</summary>
        [XmlEnum("29")]
        OLI_PARTICROLE_OWNERCONT = 29,

        /// <summary>Servicing Agent</summary>
        [XmlEnum("30")]
        OLI_PARTICROLE_SERVAGENT = 30,

        /// <summary>Third Party Recipient</summary>
        [XmlEnum("31")]
        OLI_PARTICROLE_3RDPARTYRECIP = 31,

        /// <summary>Statement Recipient</summary>
        [XmlEnum("32")]
        OLI_PARTICROLE_STMTRECIP = 32,

        /// <summary>Power of Attorney</summary>
        [XmlEnum("33")]
        OLI_PARTICROLE_POWATTY = 33,

        /// <summary>Collateral Assignee</summary>
        [XmlEnum("34")]
        OLI_PARTICROLE_ASSIGNEE = 34,

        /// <summary>PVT Met Dental Provider</summary>
        /// <remarks>Provider of Dental products and services for this Policy, Plan, or Claim.</remarks>
        [XmlEnum("35")]
        OLI_PARTICROLE_DENTAL_PROVIDER = 35,

        /// <summary>Both Annuitant and Owner</summary>
        /// <remarks>When used to select a party, this indicates the collection of primary owner and primary annuitant</remarks>
        [XmlEnum("36")]
        OLI_PARTICROLE_OWNERANNUITANT = 36,

        /// <summary>Enrollee</summary>
        /// <remarks>The eligible person who elected to take the group coverage. This person is not necessarily the insured.</remarks>
        [XmlEnum("37")]
        OLI_PARTICROLE_ENROLLEE = 37,

        /// <summary>Contingent Annuitant</summary>
        /// <remarks>On a deferred annuity, the Contingent Annuitant is a party who will become a covered person in the event that the primary and joint covered person(s) die before the contract is terminated or annuitized (i.e. during the deferred period).On an immediate annuity or an annuity in the annuitization/payout phase where there is more than one covered person (a joint policy), the Contingent Annuitant identifies which covered person's death identifies the 'contingency' (upon whose death benefits will be reduced), if reductions are applicable to the policy.See also Annuitant and Joint Annuitant Descriptions, BenefitReductionBasedOn.</remarks>
        [XmlEnum("38")]
        OLI_PARTICROLE_ANNUITANTCONTINGENT = 38,

        /// <summary>Plan Sponsor</summary>
        /// <remarks>The Party, generally an organization or company, that is the sponsor or provider of the participating product or plan to the individual participants.</remarks>
        [XmlEnum("39")]
        OLI_PARTICROLE_PLANSPONSOR = 39,

        /// <summary>Underwriter</summary>
        /// <remarks>The underwriter associated with the Holding</remarks>
        [XmlEnum("40")]
        OLI_PARTICROLE_UNDERWRITER = 40,

        /// <summary>Client Relationship Unit Associate</summary>
        /// <remarks>The CRU associate who either created the Holding, or is responsible for administration of the associated Holding</remarks>
        [XmlEnum("41")]
        OLI_PARTICROLE_CRUASSOC = 41,

        /// <summary>Owner if Person</summary>
        /// <remarks>Indicates that the Owner (age) is to be used for product rules if the Owner is a Person. If not then use the Annuitant.</remarks>
        [XmlEnum("42")]
        OLI_PARTICROLE_PERSONOWN = 42,

        /// <summary>Joint Contingent Owner</summary>
        /// <remarks>The owner will jointly own the policy if the current owner dies.</remarks>
        [XmlEnum("43")]
        OLI_PARTICROLE_JOINTCONT = 43,

        /// <summary>Annuitant's Spouse</summary>
        /// <remarks>This is different from Insured Spouse because the Spouse may or may not have an insurable role in policy but is needed as a participant because their information (e.g. age) may be used for calculation purposes.</remarks>
        [XmlEnum("44")]
        OLI_PARTICROLE_ANNSPOUSE = 44,

        /// <summary>Co-Annuitant</summary>
        /// <remarks>Co-Annuitant is not the same as Joint-Annuitant. The only acceptable relationship for a co-annuitant is spouse of the owner/annuitant. Co-Annuitant must be named the sole beneficiary on the contract. The only annuitant on the contract is the owner.</remarks>
        [XmlEnum("45")]
        OLI_PARTICROL_COANNUITANT = 45,

        /// <summary>Joint Owner</summary>
        /// <remarks>This code indicates that a party is a joint owner of a holding.</remarks>
        [XmlEnum("50")]
        OLI_PARTICROLE_JOINTOWNER = 50,

        /// <summary>Conservator</summary>
        /// <remarks>The Conservator is essentially a legal guardian for an incompetent individual where that designation carries with it different constraints and business implications than the Legal Guardian role.</remarks>
        [XmlEnum("51")]
        OLI_PARTICROLE_CONSERVATOR = 51,

        /// <summary>Unborn child of insured</summary>
        [XmlEnum("52")]
        OLI_PARTICROLE_UNBORNCHILD = 52,

        /// <summary>Assignee</summary>
        /// <remarks>The assignee is the one that is assigned benefits under absolute or collateral assignments.  This is used specifically in the case where it is unknown whether the assignee is collateral or absolute.</remarks>
        [XmlEnum("53")]
        OLI_PARTICROLE_UNKNOWNASSIGNEE = 53,

        /// <summary>Investigator</summary>
        /// <remarks>Person who investigates.</remarks>
        [XmlEnum("56")]
        OLI_PARTICROLE_INVESTIGATOR = 56,

        /// <summary>Physician</summary>
        /// <remarks>A person who practices medicine.</remarks>
        [XmlEnum("57")]
        OLI_PARTICROLE_ATTENDPHYSICIAN = 57,

        /// <summary>Medical Examiner</summary>
        /// <remarks>Describes the role of the Medical Professional who is authorized to perform medical examinations and/or health assessments for the insured, to satisfy one or more information requirements.</remarks>
        [XmlEnum("58")]
        OLI_PARTICROLE_MEDEXAMINER = 58,

        /// <summary>Loss First Notifier</summary>
        /// <remarks>Describes the particular Party who provides first notification concerning the possibility of an insured loss. This is often the first step in the creation of a claim against a holding, policy, contract, etc.</remarks>
        [XmlEnum("59")]
        OLI_PARTICROLE_FIRSTNOTIFIER = 59,

        /// <summary>Claimant Proxy</summary>
        /// <remarks>Party that represents claimant in the claims process by means of a signed proxy.</remarks>
        [XmlEnum("60")]
        OLI_PARTICROLE_CLAIMPROXY = 60,

        /// <summary>Mortgagee</summary>
        /// <remarks>Mortgagee would be the bank or whoever holds the mortgage on the property (not the homeowner). The person to whom property is mortgaged; the lender who takes a mortgage as collateral for a loan or other extension of credit. If a home policy cancels for nonpayment but the mortgagee has paid at least 85% of the homeowner premium, some insurance companies are required to cover the mortgagee interest for the remainder of the policy term.  A Mortgagee can be a person or an organization.</remarks>
        [XmlEnum("62")]
        OLI_PARTICROLE_MORTGAGEE = 62,

        /// <summary>Loss Payee</summary>
        /// <remarks>The person named in a loss payable clause to whom insurance proceeds are to be paid in the event of damage to property. The loss payee must have an insurable interest. Loss payees include automobile lienholders and property mortgagees.</remarks>
        [XmlEnum("63")]
        OLI_PARTICROLE_LOSSPAYEE = 63,

        /// <summary>Driver</summary>
        /// <remarks>The operator of a motor vehicle.</remarks>
        [XmlEnum("64")]
        OLI_PARTICROLE_DRIVER = 64,

        /// <summary>Excluded Driver</summary>
        /// <remarks>Someone specifically mentioned as not being covered by the policy.
        /// When a driver is excluded, the policy is eliminated while the named person drives or operates the automobile(s) named on the policy, including any temporary substitute automobile as defined in the policy.</remarks>
        [XmlEnum("65")]
        OLI_PARTICROLE_EXCLUDEDDRIVER = 65,

        /// <summary>Lessor</summary>
        /// <remarks>The grantor of a lease.</remarks>
        [XmlEnum("66")]
        OLI_PARTICROLE_LESSOR = 66,

        /// <summary>Other Interested Party</summary>
        /// <remarks>Another person or company who may be liable for an accident involving an insured or an insured vehicle and who has been named as an Additional Interest party under the policy.</remarks>
        [XmlEnum("67")]
        OLI_PARTICROLE_OTHRINTERESTED = 67,

        /// <summary>Other Resident</summary>
        /// <remarks>A person or organization who resides in a particular place permanently or for an extended period of time.</remarks>
        [XmlEnum("68")]
        OLI_PARTICROLE_OTRRESIDENT = 68,

        /// <summary>Successor Custodian</summary>
        /// <remarks>A person designated as the successor to the associated Custodian.  This person will assume custodial duties in the event of the designated custodian's death or incapacitation.</remarks>
        [XmlEnum("69")]
        OLI_PARTICROLE_SUCCESSORCUSTOD = 69,

        /// <summary>Renter</summary>
        /// <remarks>The person renting a house or apartment where they live.</remarks>
        [XmlEnum("70")]
        OLI_PARTICROLE_RENTER = 70,

        /// <summary>Resident</summary>
        /// <remarks>A party who resides in a specific place permanently or for an extended period.</remarks>
        [XmlEnum("71")]
        OLI_PARTICROLE_RESIDENT = 71,

        /// <summary>Lienholder</summary>
        /// <remarks>Lienholder is whoever holds a lien on the property (e.g. vehicle, boat).</remarks>
        [XmlEnum("72")]
        OLI_PARTICROLE_LIENHOLDER = 72,

        /// <summary>Joint Applicant</summary>
        /// <remarks>This relationship reflects a second party applying jointly for a policy with another party.</remarks>
        [XmlEnum("73")]
        OLI_PARTICROLE_COAPPLICANT = 73,

        /// <summary>Claim Processor</summary>
        /// <remarks>Describes the role of a Claims Processor indicating that the designated participant has been assigned the responsibility for processing claims on the designated holdings or products.</remarks>
        [XmlEnum("74")]
        OLI_PARTICROLE_CLAIMPROCESSOR = 74,

        /// <summary>Claims Manager</summary>
        /// <remarks>Describes an employee of an insurer whose responsibilities are to provide managerial services to a Claim Department.</remarks>
        [XmlEnum("75")]
        OLI_PARTICROLE_CLAIMSMANAGER = 75,

        /// <summary>Claims Clerk</summary>
        /// <remarks>Describes an employee of an insurer or third party administrator whose responsibilities are to provide administrative clerical support to a Claim Department.</remarks>
        [XmlEnum("76")]
        OLI_PARTICROLE_CLAIMSCLERK = 76,

        /// <summary>Claim Approver</summary>
        /// <remarks>Reviews the status of the claim or a portion of the claim and ensures that all required information is present and correct. Checks any benefit and payment calculations, then determines the disposition of the payment (approved, rejected, referred, etc.).</remarks>
        [XmlEnum("77")]
        OLI_PARTICROLE_CLAIMAPPR = 77,

        /// <summary>Succeeding Beneficiary</summary>
        /// <remarks>A "succeeding beneficiary" is a beneficiary which succeeds a specific party or unnamed beneficiaries.  A succeeding beneficiary is not a contingent beneficiary, in that contingent indicates *all* entities of the higher level class must pre-decease the insured, owner or annuitant (in accordance with the rules of the contract).For example, if two "per stirpes" primary beneficiaries are named (A and B), and each primary beneficiary specifically names their "per stirpes issues" (A's beneficiaries are X and Y, and B's beneficiaries are all children of the primary beneficiary).  See also Beneficiary Share Method.</remarks>
        [XmlEnum("78")]
        OLI_PARTICROLE_SUCCEEDBENE = 78,

        /// <summary>Borrower</summary>
        /// <remarks>Indicates who is the borrower of funds</remarks>
        [XmlEnum("79")]
        OLI_PARTICROLE_BORROWER = 79,

        /// <summary>Coordinator of Benefits</summary>
        /// <remarks>A Party representing the claimant or beneficiary and coordinates the benefits for this policy to insure that the correct insurance is billed and that duplicate claims are not filed.</remarks>
        [XmlEnum("80")]
        OLI_PARTICROLE_COB = 80,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
