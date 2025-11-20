using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_OPTTYPE_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Accelerated Benefit</summary>
        [XmlEnum("1")]
        OLI_OPTTYPE_ABE = 1,

        /// <summary>Accidental Death Benefit</summary>
        [XmlEnum("2")]
        OLI_OPTTYPE_ADB = 2,

        /// <summary>Accidental Death and Dismemberment</summary>
        [XmlEnum("3")]
        OLI_OPTTYPE_ADD = 3,

        /// <summary>Automatic Increase Option</summary>
        /// <remarks>Provides for an automatic increase in coverage amount with the OptionPct or OptionAmt specifying the amount.</remarks>
        [XmlEnum("4")]
        OLI_OPTTYPE_AUTOINC = 4,

        /// <summary>Cost of Living Increase or inflation guard</summary>
        /// <remarks>Provides for an automatic increase in coverage amount with the OptionPct containing the current Cost of Living Increase percent applied.</remarks>
        [XmlEnum("5")]
        OLI_OPTTYPE_COLI = 5,

        /// <summary>Children's Term Benefit</summary>
        [XmlEnum("6")]
        OLI_OPTTYPE_CTB = 6,

        /// <summary>Disability Benefit</summary>
        [XmlEnum("7")]
        OLI_OPTTYPE_DIB = 7,

        /// <summary>Exchange Provision</summary>
        [XmlEnum("8")]
        OLI_OPTTYPE_EXCHANGE = 8,

        /// <summary>No Lapse Guarantee Option</summary>
        /// <remarks>The option guarantees the policy will not lapse even if the net surrender value is not sufficient to cover the monthly deduction on a monthly date as long as the cumulative premium requirement is met.</remarks>
        [XmlEnum("9")]
        OLI_OPTTYPE_NOLAPSE = 9,

        /// <summary>Option to Purchase Additional Insurance</summary>
        [XmlEnum("10")]
        OLI_OPTTYPE_OPAI = 10,

        /// <summary>Payor Death Benefit</summary>
        [XmlEnum("11")]
        OLI_OPTTYPE_PAYORDB = 11,

        /// <summary>Payor Disability</summary>
        [XmlEnum("12")]
        OLI_OPTTYPE_PAYORDI = 12,

        /// <summary>Persistency Bonus Option</summary>
        [XmlEnum("13")]
        OLI_OPTTYPE_PERSIST = 13,

        /// <summary>Premium Guarantee Option</summary>
        [XmlEnum("14")]
        OLI_OPTTYPE_PGO = 14,

        /// <summary>Policy Split Option</summary>
        [XmlEnum("15")]
        OLI_OPTTYPE_SPLIT = 15,

        /// <summary>Waiver of Monthly Deductions</summary>
        [XmlEnum("16")]
        OLI_OPTTYPE_WMD = 16,

        /// <summary>Waiver of Premium</summary>
        [XmlEnum("17")]
        OLI_OPTTYPE_WP = 17,

        /// <summary>Double/Triple Indemnity</summary>
        [XmlEnum("18")]
        OLI_OPTTYPE_DBLINDEM = 18,

        /// <summary>Beneficiary Insurance</summary>
        [XmlEnum("19")]
        OLI_OPTTYPE_BENEINSUR = 19,

        /// <summary>Living Needs Benefit</summary>
        [XmlEnum("20")]
        OLI_OPTTYPE_LIVNEEDS = 20,

        /// <summary>Cost Recovery</summary>
        [XmlEnum("21")]
        OLI_OPTTYPE_COSTREC = 21,

        /// <summary>Estate Protection</summary>
        [XmlEnum("22")]
        OLI_OPTTYPE_ESTATEPROT = 22,

        /// <summary>Charge to Earnings Elimination</summary>
        [XmlEnum("23")]
        OLI_OPTTYPE_CHGEARNELIM = 23,

        /// <summary>Relaxation of Minimum Premium</summary>
        [XmlEnum("24")]
        OLI_OPTTYPE_RELAXMINPREM = 24,

        /// <summary>Business Value Increase</summary>
        [XmlEnum("25")]
        OLI_OPTTYPE_BUSVALUEINC = 25,

        /// <summary>Change of Insured</summary>
        [XmlEnum("26")]
        OLI_OPTTYPE_CHGINS = 26,

        /// <summary>Salary Increase</summary>
        [XmlEnum("27")]
        OLI_OPTTYPE_SALINCREASE = 27,

        /// <summary>Extended Maturity</summary>
        [XmlEnum("28")]
        OLI_OPTTYPE_EXTMATURITY = 28,

        /// <summary>Money Back Guarantee</summary>
        [XmlEnum("29")]
        OLI_OPTTYPE_MBGUAR = 29,

        /// <summary>Long Term Care Accelerated Benefit Option</summary>
        [XmlEnum("30")]
        OLI_OPTTYPE_LTCABO = 30,

        /// <summary>Extension of Benefit Option</summary>
        [XmlEnum("31")]
        OLI_OPTTYPE_EXTBO = 31,

        /// <summary>Benefit Increase Provision</summary>
        [XmlEnum("32")]
        OLI_OPTTYPE_BINCPROV = 32,

        /// <summary>Default Premium Payment Option</summary>
        [XmlEnum("33")]
        OLI_OPTTYPE_DEFPAYMNT = 33,

        /// <summary>Option to Purchase Paid-Up Additions</summary>
        [XmlEnum("34")]
        OLI_OPTTYPE_OPPUA = 34,

        /// <summary>Accidental Death Benefit w/ extra benefit for accident on a common carrier (i.e. an airline, taxi, etc.)).</summary>
        [XmlEnum("35")]
        OLI_OPTTYPE_ADC = 35,

        /// <summary>Option to Purchase Additional Insurance , but some underwriting is still required. If accepted, the increased coverage will be issued at the original issue age, not the current attained age</summary>
        [XmlEnum("36")]
        OLI_OPTTYPE_FTO = 36,

        /// <summary>Accelerated benefit rider which pays a portion of death benefit while living, but only in the case of HIV illness</summary>
        [XmlEnum("37")]
        OLI_OPTTYPE_HIV = 37,

        /// <summary>Enhanced Cash Value Option</summary>
        /// <remarks>Provides an enhanced first year cash surrender value if certain premium requirements are met.</remarks>
        [XmlEnum("38")]
        OLI_OPTTYPE_ENHANCEDCV = 38,

        /// <summary>Cash Value Transfer Option</summary>
        /// <remarks>This is a conversion option to transfer funds from one account to another.</remarks>
        [XmlEnum("39")]
        OLI_OPTTYPE_CVTRANSFER = 39,

        /// <summary>Childhood Disease</summary>
        /// <remarks>None Provided</remarks>
        [XmlEnum("40")]
        OLI_OPTTYPE_CHILDDISEASE = 40,

        /// <summary>Maternity</summary>
        /// <remarks>None Provided</remarks>
        [XmlEnum("41")]
        OLI_OPTTYPE_MATERNITY = 41,

        /// <summary>Long Term Care Non-forfeiture</summary>
        /// <remarks>None Provided</remarks>
        [XmlEnum("42")]
        OLI_OPTTYPE_LTCNONFOR = 42,

        /// <summary>Accidental Death Benefit - Joint Insured Only</summary>
        /// <remarks>None Provided</remarks>
        [XmlEnum("43")]
        OLI_OPTTYPE_ADBJOINT = 43,

        /// <summary>Premium Waiver - Joint Insured Only</summary>
        /// <remarks>None Provided</remarks>
        [XmlEnum("44")]
        OLI_OPTTYPE_WPJOINT = 44,

        /// <summary>PVT Met Values Plus Option</summary>
        /// <remarks>Values Plus is an option that can be added to a Life Policy to ensure that another carrier's policy's cash values can be "rolled into" this Life Policy</remarks>
        [XmlEnum("45")]
        OLI_OPTTYPE_VALUESPLUS = 45,

        /// <summary>Medical aid premium waiver</summary>
        /// <remarks>Covers cost of medical aid contributions in the event of the principal insured becoming severely ill, disabled or dies</remarks>
        [XmlEnum("46")]
        OLI_OPTTYPE_WPMED = 46,

        /// <summary>AIDS</summary>
        /// <remarks>This benefit adds the coverage of AIDS and AIDS related diseases to a coverage</remarks>
        [XmlEnum("47")]
        OLI_OPTTYPE_AIDS = 47,

        /// <summary>Death Benefit</summary>
        /// <remarks>Payment of the Coverage Sum Assured will happen in the event of death</remarks>
        [XmlEnum("48")]
        OLI_OPTTYPE_DB = 48,

        /// <summary>Disability or Critical Illness</summary>
        /// <remarks>Payment of the Coverage Sum Assured will happen in the event of death</remarks>
        [XmlEnum("49")]
        OLI_OPTTYPE_DISCRITILL = 49,

        /// <summary>Death, Disability or Critical Illness</summary>
        /// <remarks>Payment of the Coverage Sum Assured will happen in the event of Death, Disability or Critical Illness</remarks>
        [XmlEnum("50")]
        OLI_OPTTYPE_DBDISCRITILL = 50,

        /// <summary>Automatic Index Linked Premium Increase</summary>
        /// <remarks>A contractually agreed increase on the premium payable. This increase is not fixed, but linked to a specified index, i.e. CPI, Stock Exchange indices</remarks>
        [XmlEnum("51")]
        OLI_OPTTYPE_AILPREMINC = 51,

        /// <summary>Automatic Fixed Percentage Premium Increase</summary>
        /// <remarks>A contractually agreed increase on the premium payable. This increase percentage if fixed for the period of the contract</remarks>
        [XmlEnum("52")]
        OLI_OPTTYPE_AFPPREMINC = 52,

        /// <summary>Pre-Pay Discount</summary>
        /// <remarks>Provides a discount if some portion of future premiums are pre-paid along with the initial premium.</remarks>
        [XmlEnum("53")]
        OLI_DISCOUNT_PREPAY = 53,

        /// <summary>Select Health Discount</summary>
        /// <remarks>Provides a discount if the applicant qualifies for the carriers definition of select or good health.</remarks>
        [XmlEnum("54")]
        OLI_OPTTYPE_SELECTHEALTH = 54,

        /// <summary>Affiliation Discount</summary>
        /// <remarks>Provides a discount if the applicant is affiliated or otherwise is eligible for a insurer discount.</remarks>
        [XmlEnum("55")]
        OLI_OPTTYPE_AFFILIATION = 55,

        /// <summary>Spousal Discount</summary>
        /// <remarks>Provides a discount if a couple applies together for policies.</remarks>
        [XmlEnum("56")]
        OLI_OPTTYPE_SPOUSAL = 56,

        /// <summary>Critical illness premium waiver</summary>
        /// <remarks>Covers cost of the policy contributions in the event of the principal insured becoming severely ill.</remarks>
        [XmlEnum("57")]
        OLI_OPTTYPE_WPCRIT = 57,

        /// <summary>Qualified Adult Discount</summary>
        /// <remarks>Provides a discount if a "qualified adults" apply  together for policies.  Qualified Adult is a  person  of  the  same  or opposite sex who meets all the criteria listed below.1) He or she is over the age of 18.2) He or she has lived with you for at least 12 months.3) He or she has a serious and committed relationship with you.4) He or she is not legally married nor a Domestic Partner to anyone else.5)    He or she is financially interdependent with you  Financially interdependent means that you and this person are jointly responsible for the cost of food and housing</remarks>
        [XmlEnum("58")]
        OLI_OPTTYPE_QUALADLT = 58,

        /// <summary>Adjustable Survivorship Life</summary>
        /// <remarks>Survivorship life coverage that is adjustable</remarks>
        [XmlEnum("61")]
        OLI_OPTTYPE_ADJSURVL = 61,

        /// <summary>Designate Second Life</summary>
        /// <remarks>Benefit that allows owner to designate a second life on the policy</remarks>
        [XmlEnum("64")]
        OLI_OPTTYPE_DSL = 64,

        /// <summary>Exchange of Insured Option</summary>
        /// <remarks>Option to exchange the insured on the policy</remarks>
        [XmlEnum("65")]
        OLI_OPTTYPE_EXCIO = 65,

        /// <summary>Guaranteed Insurance Option</summary>
        /// <remarks>Additional life insurance purchased that has been issued on a guaranteed basis</remarks>
        [XmlEnum("66")]
        OLI_OPTTYPE_GUARIR = 66,

        /// <summary>Survivorship Additional Benefit</summary>
        /// <remarks>Retirement income benefit of survivor of an insured individual</remarks>
        [XmlEnum("67")]
        OLI_OPTTYPE_SURVAB = 67,

        /// <summary>Survivorship Insurance Rider</summary>
        /// <remarks>Death benefit paid after all insureds dieFor reinsurance messages, the LREACT mappings treat the base coverage as the policy with all riders being sent as options on the base coverage.  Thus, certain codes that are traditionally riders are needed as options.</remarks>
        [XmlEnum("68")]
        OLI_OPTTYPE_SURVIR = 68,

        /// <summary>Aviation Exclusion Rider</summary>
        /// <remarks>An Aviation Exclusion Rider is an addendum that basically makes a policy void should the insured die in an aviation-related accident other than as a fare-paying passenger on a scheduled airline.</remarks>
        [XmlEnum("70")]
        OLI_OPTTYPE_AVIATION = 70,

        /// <summary>Additional Coverage Scheduled Option</summary>
        /// <remarks>A Rider or Option that allows the policyholder to add additional coverage or buy an additional policy within a scheduled period of time.  The exercise of the Rider/Option may or may not require special underwriting business rules based upon the carrier's process.</remarks>
        [XmlEnum("74")]
        OLI_OPTTYPE_ADDSCHED = 74,

        /// <summary>Guaranteed Issue Option due to Marriage</summary>
        /// <remarks>A Rider or Option that allows the policyholder to add additional coverage or buy an additional policy in the event that the policyholder gets married.  The exercise of the Rider/Option may or may not require special underwriting business rules based upon the carrier's process.</remarks>
        [XmlEnum("75")]
        OLI_OPTTYPE_ADDMARR = 75,

        /// <summary>Guaranteed Issue Option due to Birth or Adoption</summary>
        /// <remarks>A Rider or Option that allows the policyholder to add additional coverage or buy an additional policy in the event that the policyholder's family increases by birth or adoption of a child or children.  The exercise of the Rider/Option may or may not require special underwriting business rules based upon the carrier's process.</remarks>
        [XmlEnum("76")]
        OLI_OPTTYPE_ADDCHILD = 76,

        /// <summary>Extra Protection Option</summary>
        /// <remarks>A Rider or Option on a Coverage which is available until the insured reaches an age specified in the policy documentation. This Option allows the policyholder to add additional coverage or buy an additional policy until he/she reaches the agreed upon age.  The exercise of the Rider/Option may or may not require special underwriting business rules based upon the carrier's process.</remarks>
        [XmlEnum("77")]
        OLI_OPTTYPE_EXPEXTRA = 77,

        /// <summary>Children's Conversion Option</summary>
        /// <remarks>The Children's Conversion rider/option allows the policyholder to buy an additional policy for the insured child when the insured child attains the age where they are no longer considered a child (and therefore covered) on the existing policy.</remarks>
        [XmlEnum("78")]
        OLI_OPTTYPE_EXPCHILD = 78,

        /// <summary>Surviving Insured Conversion</summary>
        /// <remarks>The Surviving Insured Conversion rider/option allows the surviving insured on a joint policy to convert that policy to an individual policy after the death of the other joint insured.</remarks>
        [XmlEnum("79")]
        OLI_OPTTYPE_SURJTTERM = 79,

        /// <summary>Suicide Clause</summary>
        /// <remarks>Death attributed to suicide is not covered by some policies for a certain period of time</remarks>
        [XmlEnum("80")]
        OLI_OPTTYPE_SUICIDECLAUSE = 80,

        /// <summary>Permanent or Partial Incapacity</summary>
        /// <remarks>Combination benefit that covers permanent and or partial incapacitation.</remarks>
        [XmlEnum("81")]
        OLI_OPTTYPE_PPINC = 81,

        /// <summary>Hospital Benefit</summary>
        /// <remarks>Covers in the event of the insured being hospitalized, but is linked to the insured amount, not to the amount of hospitalization expenses incurred by the insured</remarks>
        [XmlEnum("82")]
        OLI_OPTTYPE_HOSP = 82,

        /// <summary>Occupation Specific Disability  Benefit (Permanent Incapacity)</summary>
        /// <remarks>Pays in event of Own  Occupation DisabilityThis applies to disability payments in event of being unable to exercise own Occupation</remarks>
        [XmlEnum("83")]
        OLI_OPTTYPE_DISSIMOCC = 83,

        /// <summary>Female Add-On Benefit</summary>
        /// <remarks>Covers specific female dread diseases or impairments.  It will pay out if diagnosed with one of those diseases or impairments in a lump sum.</remarks>
        [XmlEnum("84")]
        OLI_OPTTYPE_FEMDRDDISEASE = 84,

        /// <summary>Hospice Care</summary>
        /// <remarks>A rider available for care that is intended to provide comfort for the terminal patient and support for their family.</remarks>
        [XmlEnum("87")]
        OLI_OPTTYPE_HOSPICECARE = 87,

        /// <summary>Presumptive Disability for a Specific Loss</summary>
        /// <remarks>An option available which indicates that the parent rider or coverage, which covers a specific loss, provides a presumption of disability even if the covered individual is still working after the loss. The presumption of disability option causes the claim to be paid if the loss is suffered regardless of actual disability.</remarks>
        [XmlEnum("88")]
        OLI_OPTTYPE_PRESUMPTDISABLE = 88,

        /// <summary>Funeral Benefit</summary>
        /// <remarks>The specified Funeral Benefit amount forms part of the death benefit available to a beneficiary who has been nominated by the policyholder.</remarks>
        [XmlEnum("100")]
        OLI_OPTTYPE_FUNERAL = 100,

        /// <summary>Dread Disease</summary>
        /// <remarks>A defined percentage of the coverage amount is paid as a lump sum if the life insured is diagnosed with any of a range of defined diseases or medical conditions.</remarks>
        [XmlEnum("101")]
        OLI_OPTTYPE_DRDISEASE = 101,

        /// <summary>Seatbelt Benefit</summary>
        /// <remarks>An additional benefit is provided if a seatbelt was used for the covered person during the accident.</remarks>
        [XmlEnum("102")]
        OLI_OPTTYPE_SEATBELT = 102,

        /// <summary>Airbag Benefit</summary>
        /// <remarks>An additional benefit is provided if an air bag is deployed for the covered person during the accident.</remarks>
        [XmlEnum("103")]
        OLI_OPTTYPE_AIRBAG = 103,

        /// <summary>Travel Assistance Program</summary>
        [XmlEnum("104")]
        OLI_OPTTYPE_TRAVEL = 104,

        /// <summary>Disappearance</summary>
        /// <remarks>Benefits are provided in the event that person is declared legally dead following a disappearance.</remarks>
        [XmlEnum("105")]
        OLI_OPTTYPE_DISAPP = 105,

        /// <summary>Worksite modification</summary>
        [XmlEnum("106")]
        OLI_OPTTYPE_WORKSITE = 106,

        /// <summary>Repatriation of Remains</summary>
        /// <remarks>Covers the costs of logistics of preparing and returning your remains to desired location</remarks>
        [XmlEnum("107")]
        OLI_OPTTYPE_REMAINS = 107,

        /// <summary>Childcare Benefit</summary>
        [XmlEnum("108")]
        OLI_OPTTYPE_CHILDCARE = 108,

        /// <summary>Group to Individual Policy Conversion</summary>
        /// <remarks>A group policy benefit can be converted to an individual policy</remarks>
        [XmlEnum("109")]
        OLI_OPTTYPE_LIFECONV = 109,

        /// <summary>Portability of Health Coverage</summary>
        /// <remarks>Complies with requirements of HIPAA.  The Health Insurance Portability and Accountability Act (HIPAA) provides rights and protections for participants and beneficiaries in group health plans. HIPAA includes protections for coverage under group health plans that limit exclusions for preexisting conditions; prohibit discrimination against employees and dependents based on their health status; and allow a special opportunity to enroll in a new plan to individuals in certain circumstances. HIPAA may also give you a right to purchase individual coverage if you have no group health plan coverage available, and have exhausted COBRA or other continuation coverage.</remarks>
        [XmlEnum("110")]
        OLI_OPTTYPE_PORT = 110,

        /// <summary>Suicide</summary>
        /// <remarks>Benefits provided in the event of suicide.</remarks>
        [XmlEnum("111")]
        OLI_OPTTYPE_SUICIDE = 111,

        /// <summary>War Risk</summary>
        [XmlEnum("112")]
        OLI_OPTTYPE_WAR = 112,

        /// <summary>Terrorism Benefit</summary>
        [XmlEnum("113")]
        OLI_OPTTYPE_TERROR = 113,

        /// <summary>Known and Unknown</summary>
        /// <remarks>Covers all known and unknown, serious and permanent medical or physical conditions (lump sum benefit)</remarks>
        [XmlEnum("114")]
        OLI_OPTTYPE_CATCHALL = 114,

        /// <summary>Physical Impairment</summary>
        /// <remarks>Provides cover for physical impairments in the event of diagnosis or occurrence of such impairments, and subject to any applicable waiting period.</remarks>
        [XmlEnum("115")]
        OLI_OPTTYPE_PHYSIMP = 115,

        /// <summary>Functional Impairment</summary>
        /// <remarks>Pays in the event of specified functional impairments.</remarks>
        [XmlEnum("116")]
        OLI_OPTTYPE_FUNCIMP = 116,

        /// <summary>Military Aviation</summary>
        /// <remarks>Used to identify whether or not an aviation extra is charged for coverage as the result of the insured`s military flying.</remarks>
        [XmlEnum("117")]
        OLI_OPTTYPE_MILITARYAVIATION = 117,

        /// <summary>Return of Premium Term</summary>
        /// <remarks>Offers insurance protection while providing a guaranteed return of out-of-pocket policy premiums.</remarks>
        [XmlEnum("118")]
        OLI_OPTTYPE_ROPT = 118,

        /// <summary>Marital Discount</summary>
        /// <remarks>This discount applies because the individual is married.  This is different then Spousal Discount which applies because both spouses are applying together.</remarks>
        [XmlEnum("119")]
        OLI_OPTTYPE_MARITAL = 119,

        /// <summary>Small Business Discount</summary>
        [XmlEnum("120")]
        OLI_OPTTYPE_SMALLBUS = 120,

        /// <summary>Loyalty Discount</summary>
        [XmlEnum("121")]
        OLI_OPTTYPE_LOYALTY = 121,

        /// <summary>Overloan Protection Rider</summary>
        /// <remarks>The Overloan Protection Rider offers a level of protection to policyholders against lapsing their policy due to excess policy debt.  The benefit is specifically designed for clients who take substantial loans.  May also be referred to as "Overload Protection Rider."</remarks>
        [XmlEnum("122")]
        OLI_OPTTYPE_OPR = 122,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
