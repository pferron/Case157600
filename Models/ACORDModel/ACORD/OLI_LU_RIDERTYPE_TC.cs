using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_RIDERTYPE_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Cost of Living Adjustment Rider (COLA)</summary>
        /// <remarks>Rider that provides an increase in the disability benefit amount to correlate with the increase in the cost of living while a covered insured is totally disabled.</remarks>
        [XmlEnum("1")]
        OLI_RIDER_COLA = 1,

        /// <summary>Exclusion</summary>
        [XmlEnum("2")]
        OLI_DIRIDER_EXCLU = 2,

        /// <summary>FIO (future income option)</summary>
        [XmlEnum("3")]
        OLI_DIRIDER_FIO = 3,

        /// <summary>GIR (Guaranteed insurance rider)</summary>
        [XmlEnum("4")]
        OLI_DIRIDER_GIR = 4,

        /// <summary>GMR (Guaranteed Medical Rider)</summary>
        [XmlEnum("5")]
        OLI_DIRIDER_GMR = 5,

        /// <summary>GMI (Guaranteed Medical Ins)</summary>
        [XmlEnum("6")]
        OLI_DIRIDER_GMI = 6,

        /// <summary>Maternity</summary>
        [XmlEnum("7")]
        OLI_DIRIDER_MATERN = 7,

        /// <summary>Hospital Indemnity</summary>
        [XmlEnum("8")]
        OLI_DIRIDER_HOSPINDEM = 8,

        /// <summary>Surgical</summary>
        [XmlEnum("9")]
        OLI_DIRIDER_SURG = 9,

        /// <summary>Social Insurance Supplement</summary>
        [XmlEnum("10")]
        OLI_DIRIDER_SOCINSSUP = 10,

        /// <summary>Automatic Income Benefit</summary>
        [XmlEnum("11")]
        OLI_DIRIDER_AUTOINC = 11,

        /// <summary>Option to Purchase Additional Insurance Rider</summary>
        /// <remarks>Rider that provides a way to periodically purchase additional coverage without evidence of insurability.  May also be known as a Guaranteed Purchase Option (GPO), Future Purchase Option (FPO), Benefit Increase Offer (BIO) or OPAI.  May be subject to limitations, for example attained age, benefit caps or if insured is on claim.</remarks>
        [XmlEnum("12")]
        OLI_RIDER_OPAI = 12,

        /// <summary>Physicians</summary>
        [XmlEnum("13")]
        OLI_DIRIDER_PHYSN = 13,

        /// <summary>Vision</summary>
        /// <remarks>Vision is a type of specified expense coverage that provides benefits for expenses that the insured incurs in obtaining eye examinations and corrective lenses.</remarks>
        [XmlEnum("14")]
        OLI_DIRIDER_VISION = 14,

        /// <summary>Dental</summary>
        /// <remarks>Dental provides expenses related to routine dental care</remarks>
        [XmlEnum("15")]
        OLI_DIRIDER_DENT = 15,

        /// <summary>Prescription.</summary>
        /// <remarks>Prescription is a type of specified expense coverage that provides benefits for the purchase of drugs and medicines prescribed by a physician.On Long Term Care, the optionally selected Prescription Drug provision will pay the cost of prescription drugs when the insured is in a skilled nursing facility.</remarks>
        [XmlEnum("16")]
        OLI_DIRIDER_PRESCRIPT = 16,

        /// <summary>Long term care</summary>
        [XmlEnum("17")]
        OLI_DIRIDER_LTC = 17,

        /// <summary>Hospital/surgical</summary>
        [XmlEnum("18")]
        OLI_DIRIDER_HOSPSURG = 18,

        /// <summary>Long Term Facility Care / Service</summary>
        /// <remarks>Facility Care / Services - nursing care, assisted living and similar services provided facilities (outside) of the home.</remarks>
        [XmlEnum("19")]
        OLI_DIRIDER_NURSE = 19,

        /// <summary>Medicare supplement</summary>
        [XmlEnum("20")]
        OLI_DIRIDER_MEDSUPP = 20,

        /// <summary>Dread Disease</summary>
        /// <remarks>A type of specified expense coverage that provides benefits for only those medical expenses incurred by an insured who has contracted a specified disease.</remarks>
        [XmlEnum("21")]
        OLI_DIRIDER_DISEASE = 21,

        /// <summary>Income Protection</summary>
        /// <remarks>Provides income protection that can apply to accident OR sickness which prevents policyholder from working for a given period of time.</remarks>
        [XmlEnum("22")]
        OLI_DIRIDER_INCPROT = 22,

        /// <summary>Medical expense (coverage available for family members)</summary>
        /// <remarks>Health insurance coverage that provides benefits for the expenses incurred in treating illnesses and injuries for the family members.</remarks>
        [XmlEnum("23")]
        OLI_DIRIDER_MEDEXPFAM = 23,

        /// <summary>Medical expense (insured only)</summary>
        /// <remarks>Health insurance coverage that provides benefits for the expenses incurred in treating illnesses and injuries for the insured only.</remarks>
        [XmlEnum("24")]
        OLI_DIRIDER_MEDEXPINDIV = 24,

        /// <summary>Accidental death and dismemberment</summary>
        [XmlEnum("25")]
        OLI_DIRIDER_ACCDTHDIS = 25,

        /// <summary>Commercial loss of time (includes franchise).</summary>
        [XmlEnum("26")]
        OLI_DIRIDER_COMMLOSS = 26,

        /// <summary>Non-cancelable income disability</summary>
        [XmlEnum("27")]
        OLI_DIRIDER_INCDIS = 27,

        /// <summary>Miscellaneous Room & Board</summary>
        [XmlEnum("28")]
        OLI_DIRIDER_MISCRNB = 28,

        /// <summary>Private Nursing</summary>
        [XmlEnum("29")]
        OLI_DIRIDER_PRIVNURS = 29,

        /// <summary>Medical Surgical Expense</summary>
        [XmlEnum("30")]
        OLI_DIRIDER_MEDSURG = 30,

        /// <summary>Private Duty Nursing</summary>
        [XmlEnum("31")]
        OLI_DIRIDER_DUTYNURS = 31,

        /// <summary>Intensive Care Unit</summary>
        [XmlEnum("32")]
        OLI_DIRIDER_ICU = 32,

        /// <summary>Medical Services and Supplies</summary>
        [XmlEnum("33")]
        OLI_DIRIDER_MEDSERV = 33,

        /// <summary>Deductible buy down</summary>
        [XmlEnum("34")]
        OLI_DIRIDER_DCTBYDWN = 34,

        /// <summary>Extra Hospital Miscellaneous Expenses</summary>
        [XmlEnum("35")]
        OLI_DIRIDER_EXTRAHOSP = 35,

        /// <summary>Well Child Care</summary>
        [XmlEnum("36")]
        OLI_DIRIDER_WELLCARE = 36,

        /// <summary>Convalescent Income</summary>
        [XmlEnum("37")]
        OLI_DIRIDER_CONVINC = 37,

        /// <summary>Medicare Extended</summary>
        [XmlEnum("38")]
        OLI_DIRIDER_MEDCAREEXT = 38,

        /// <summary>Monthly Hospital Confinement</summary>
        [XmlEnum("39")]
        OLI_DIRIDER_HOSPCONF = 39,

        /// <summary>Long Term Care and Community Based Care / Service</summary>
        /// <remarks>Home health care and communities services care and similar services provided residential (inside) the home.</remarks>
        [XmlEnum("40")]
        OLI_DIRIDER_HHLTH = 40,

        /// <summary>Waiver of Elimination Period (known as Waiver of Qualifying Period in Australia)</summary>
        [XmlEnum("41")]
        OLI_DIRIDER_WAIVELIM = 41,

        /// <summary>Ambulance Coverage</summary>
        /// <remarks>On a Long Term Care policy, the optionally selected Ambulance coverage provides ambulance transportation subject to carrier rules. May be limited to transportation to/from nursing home/hospital.</remarks>
        [XmlEnum("42")]
        OLI_DIRIDER_AMBULANCE = 42,

        /// <summary>Private Hospital Room</summary>
        [XmlEnum("43")]
        OLI_DIRIDER_PRIVHOSP = 43,

        /// <summary>Loss/Speech and Hearing</summary>
        [XmlEnum("44")]
        OLI_DIRIDER_LOSSSPEECH = 44,

        /// <summary>Blood Plasma and Transfusions</summary>
        [XmlEnum("45")]
        OLI_DIRIDER_BLOOD = 45,

        /// <summary>Alcoholism & Drug Addiction</summary>
        [XmlEnum("46")]
        OLI_DIRIDER_ALCOHOL = 46,

        /// <summary>Mental Illness</summary>
        [XmlEnum("47")]
        OLI_DIRIDER_METALILL = 47,

        /// <summary>Accident Injury</summary>
        [XmlEnum("48")]
        OLI_DIRIDER_ACCINJ = 48,

        /// <summary>Future Increase Option</summary>
        [XmlEnum("49")]
        OLI_DIRIDER_INCROPT = 49,

        /// <summary>Medicare Hospital Indemnity</summary>
        [XmlEnum("50")]
        OLI_DIRIDER_MEDHOSPIND = 50,

        /// <summary>Partial Disability</summary>
        [XmlEnum("51")]
        OLI_DIRIDER_PARTDI = 51,

        /// <summary>Workmen's Compensation Offset</summary>
        [XmlEnum("52")]
        OLI_DIRIDER_WORKCOMP = 52,

        /// <summary>Additional Monthly Indemnity</summary>
        [XmlEnum("53")]
        OLI_DIRIDER_ADDLMNINDM = 53,

        /// <summary>Aggregate Increase Protection</summary>
        [XmlEnum("54")]
        OLI_DIRIDER_INCRPRO = 54,

        /// <summary>Capital Account</summary>
        [XmlEnum("55")]
        OLI_DIRIDER_CAPACCT = 55,

        /// <summary>Cost of Living, CPI Inflation Option</summary>
        /// <remarks>Inflation option that provides automatic periodic increases of benefits, calculated based on compounding the Consumer Price Index.  The increased benefit does not impact premium.</remarks>
        [XmlEnum("56")]
        OLI_DIRIDER_COLCPI = 56,

        /// <summary>Cost of Living, Guar</summary>
        [XmlEnum("57")]
        OLI_DIRIDER_GUARCOL = 57,

        /// <summary>Family Income</summary>
        [XmlEnum("58")]
        OLI_DIRIDER_FAMINC = 58,

        /// <summary>Fixed Income</summary>
        [XmlEnum("59")]
        OLI_DIRIDER_FIXINC = 59,

        /// <summary>Homemaker</summary>
        [XmlEnum("60")]
        OLI_DIRIDER_HOME = 60,

        /// <summary>Hospital Income</summary>
        [XmlEnum("61")]
        OLI_DIRIDER_HOSPINC = 61,

        /// <summary>Installment Schedule</summary>
        [XmlEnum("62")]
        OLI_DIRIDER_INSTSCH = 62,

        /// <summary>Lifetime Accident</summary>
        [XmlEnum("63")]
        OLI_DIRIDER_LFACC = 63,

        /// <summary>Lifetime Total Disability (known as Total and Permanent Disability in Australia)</summary>
        [XmlEnum("64")]
        OLI_DIRIDER_LFTOTDI = 64,

        /// <summary>Cash Benefit / Lump Sump Payout</summary>
        /// <remarks>Provides a fixed stated dollar amount payout in the event death or disability.</remarks>
        [XmlEnum("65")]
        OLI_DIRIDER_LUMPSUM = 65,

        /// <summary>Non-Occupation AMI</summary>
        [XmlEnum("66")]
        OLI_DIRIDER_NONOCCAMI = 66,

        /// <summary>Option to Purchase Residual Benefit</summary>
        [XmlEnum("67")]
        OLI_DIRIDER_OPRESBENE = 67,

        /// <summary>Optional Residual Benefit</summary>
        [XmlEnum("68")]
        OLI_DIRIDER_RESBENE = 68,

        /// <summary>Return of Premium / Non-Forfeiture - Full Death</summary>
        /// <remarks>Provides that upon death of the insured the policy will return all premiums paid. Also known as Premium Refund.</remarks>
        [XmlEnum("69")]
        OLI_DIRIDER_PREMREFUND = 69,

        /// <summary>Principal Sum</summary>
        [XmlEnum("70")]
        OLI_DIRIDER_PRICSUM = 70,

        /// <summary>Red Elim Hosp Conf</summary>
        [XmlEnum("71")]
        OLI_DIRIDER_ELIMHOSP = 71,

        /// <summary>Replacement Expense</summary>
        [XmlEnum("72")]
        OLI_DIRIDER_REPLCEXP = 72,

        /// <summary>Residual Disability</summary>
        [XmlEnum("73")]
        OLI_DIRIDER_RESDI = 73,

        /// <summary>Residual Long Term</summary>
        [XmlEnum("74")]
        OLI_DIRIDER_RESLTC = 74,

        /// <summary>Residual Short Term</summary>
        [XmlEnum("75")]
        OLI_DIRIDER_RESSTC = 75,

        /// <summary>Salary Replacement</summary>
        [XmlEnum("76")]
        OLI_DIRIDER_SALREP = 76,

        /// <summary>Social Security Income</summary>
        [XmlEnum("77")]
        OLI_DIRIDER_SSINC = 77,

        /// <summary>Supplemental Income</summary>
        [XmlEnum("78")]
        OLI_DIRIDER_SUPPINC = 78,

        /// <summary>TD Your Occupation</summary>
        [XmlEnum("79")]
        OLI_DIRIDER_TDOCCUP = 79,

        /// <summary>AIDS - Conditional</summary>
        [XmlEnum("80")]
        OLI_DIRIDER_AIDSCOND = 80,

        /// <summary>AIDS - Unconditional (full coverage, no conditions on contraction of illness).</summary>
        [XmlEnum("81")]
        OLI_DIRIDER_AIDSUNCOND = 81,

        /// <summary>Employment in firm</summary>
        [XmlEnum("82")]
        OLI_DIRIDER_EMPFIRM = 82,

        /// <summary>Automatic benefit increase</summary>
        [XmlEnum("83")]
        OLI_DIRIDER_AUTOBENEINC = 83,

        /// <summary>Benefit update agreement</summary>
        [XmlEnum("84")]
        OLI_DIRIDER_BENEUPDATEAGMT = 84,

        /// <summary>Return to work (still covered if you return to work but not in same level position).</summary>
        [XmlEnum("85")]
        OLI_DIRIDER_RETTOWORK = 85,

        /// <summary>Regular Occupation (still covered if you return to work but in different occupation).</summary>
        [XmlEnum("86")]
        OLI_DIRIDER_REGOCCUP = 86,

        /// <summary>Waiver of premium upon disability</summary>
        [XmlEnum("87")]
        OLI_DIRIDER_WP = 87,

        /// <summary>Overhead expense</summary>
        [XmlEnum("88")]
        OLI_DIRIDER_OVREXP = 88,

        /// <summary>Funeral expense</summary>
        [XmlEnum("89")]
        OLI_DIRIDER_FUNEXP = 89,

        /// <summary>Additional Claim Benefit</summary>
        [XmlEnum("90")]
        OLI_DIRIDER_ADDLCLAIM = 90,

        /// <summary>Select Occupation Premium Discount</summary>
        [XmlEnum("91")]
        OLI_DIRIDER_SELOCCDISC = 91,

        /// <summary>Tax Return Premium Discount</summary>
        [XmlEnum("92")]
        OLI_DIRIDER_TAXRETDISC = 92,

        /// <summary>Employer Premium Discount</summary>
        [XmlEnum("93")]
        OLI_DIRIDER_EMPDISC = 93,

        /// <summary>Association Premium Discount</summary>
        [XmlEnum("94")]
        OLI_DIRIDER_ASSOCDISC = 94,

        /// <summary>Multiple Policy Discount</summary>
        [XmlEnum("95")]
        OLI_DIRIDER_MULTIDISC = 95,

        /// <summary>Premium Enhancement</summary>
        /// <remarks>A percentage of the premium payment which is added to the policy value at the time of premium payment. It is not an additional interest rate. The Premium Enhancement is not considered a premium payment; it is earnings on the product. (Also referred to as Extra Value Rider)</remarks>
        [XmlEnum("96")]
        OLI_RIDER_PE = 96,

        /// <summary>Accident Extended Wait</summary>
        [XmlEnum("101")]
        OLI_DIRIDER_EA = 101,

        /// <summary>Accident Sickness Extended Wait</summary>
        [XmlEnum("102")]
        OLI_DIRIDER_EAS = 102,

        /// <summary>Accident 1st Day Coverage</summary>
        [XmlEnum("103")]
        OLI_DIRIDER_FDA = 103,

        /// <summary>Extended Elimination Period</summary>
        [XmlEnum("104")]
        OLI_DIRIDER_EXTELIMPD = 104,

        /// <summary>Non-Smoker Discount Rider</summary>
        /// <remarks>When attached to a policy this rider applies a percentage discount to the policy premium if the applicant is a non-smoker.</remarks>
        [XmlEnum("105")]
        OLI_RIDER_NONSMOKER = 105,

        /// <summary>Foreign Travel Rider</summary>
        /// <remarks>When present, this rider pays up to a set percentage of billed charges for Medicare eligible expenses for Medically necessary emergency hospital, doctor and medical care received in a foreign country if the care would have been covered by Medicare</remarks>
        [XmlEnum("106")]
        OLI_RIDER_FOREIGNTRAVEL = 106,

        /// <summary>Return of Premium Term</summary>
        /// <remarks>Offers insurance protection while providing a guaranteed return of out-of-pocket policy premiums.</remarks>
        [XmlEnum("107")]
        OLI_RIDER_ROPT = 107,

        /// <summary>Annual Enhanced Death Benefit</summary>
        [XmlEnum("201")]
        OLI_ANNRIDER_ANNENHDB = 201,

        /// <summary>Surrender Charge Waiver</summary>
        /// <remarks>A waiver of the normal surrender charges under specific circumstances.</remarks>
        [XmlEnum("202")]
        OLI_ANNRIDER_SURRCHGWAIVER = 202,

        /// <summary>Terminal Illness Rider</summary>
        /// <remarks>Provision that allows for contract penalty free withdrawals or return of premium  from an annuity contract. To qualify, the contract owner must provide proof of a terminal condition</remarks>
        [XmlEnum("203")]
        OLI_RIDER_TIR = 203,

        /// <summary>Guaranteed Minimum Income Benefit (GMIB)</summary>
        /// <remarks>Guarantees that when a contract is annuitized – i.e., converted into retirement income payments – the income payments will be based on the greater of the actual contract value or a minimum payout base, which typically is equal to the amount invested credited with a competitive rate of interest (five percent is common). If the contract value grows, monthly income payments may be higher, but never lower, than the guaranteed minimum amount.  Allows for optional annual step-up.</remarks>
        [XmlEnum("204")]
        OLI_RIDER_GIB = 204,

        /// <summary>Enhanced Earnings Benefit</summary>
        /// <remarks>Rider that pays an extra death benefit to an individual (beneficiary) at the time of a death. The beneficiary can use the potential extra benefit to help pay income taxes owed on a policy. Sometimes referred to as Beneficiary Protector Rider)</remarks>
        [XmlEnum("205")]
        OLI_RIDER_EEB = 205,

        /// <summary>Death Benefit</summary>
        /// <remarks>Benefit payable upon the death of the contract owner or annuitant</remarks>
        [XmlEnum("206")]
        OLI_RIDER_DB = 206,

        /// <summary>Surrender Charges</summary>
        /// <remarks>The cost to a contract owner for (partial or full) withdrawals from the contract before the end of the surrender charge period.</remarks>
        [XmlEnum("207")]
        OLI_RIDER_CDS = 207,

        /// <summary>Earnings Max Rider</summary>
        /// <remarks>The election of this rider pays an additional amount over and above the death benefit at the time of the Owner's death. A charge is assessed for this rider in the form of a decreased interest rate.</remarks>
        [XmlEnum("208")]
        OLI_RIDER_EARNINGSMAX = 208,

        /// <summary>Pre-Selected Death Benefit Option</summary>
        /// <remarks>Before the Income Date, the Owner may designate a death benefit option. Only the Owner can revoke or change this election. After the death of the Owner, the Beneficiary may not revoke or modify the death benefit option elected, subject to the requirements of the Internal Revenue Code. However, at the time of the Owner's death, we may modify the death benefit option if the death benefit elected exceeds the life expectancy of the Beneficiary.</remarks>
        [XmlEnum("209")]
        OLI_RIDER_DBPREOPT = 209,

        /// <summary>Extended Guarantee Period</summary>
        /// <remarks>If this rider is elected, the interest rate initially in effect for each Premium, excluding any interest rate bonus, will remain in effect at least as long as the Extended Guarantee Period.</remarks>
        [XmlEnum("210")]
        OLI_RIDER_EXTGUARPER = 210,

        /// <summary>Guaranteed Minimum Accumulation Benefit By Years</summary>
        /// <remarks>A guarantee that ensures that the value of a variable annuity contract will be at least equal to a certain minimum amount after a specified number of years.</remarks>
        [XmlEnum("211")]
        OLI_RIDER_SECUREPRINCIPAL = 211,

        /// <summary>Bonus</summary>
        /// <remarks>The offer of bonuses or credits on purchase payments. By purchasing this feature, the purchaser receives a credit to his/her account equal to a percentage of the purchase payment.</remarks>
        [XmlEnum("212")]
        OLI_RIDER_BONUS = 212,

        /// <summary>Health Insurance Rider</summary>
        /// <remarks>A general classification of annuity riders that have health based benefits.</remarks>
        [XmlEnum("213")]
        OLI_RIDER_HEALTH = 213,

        /// <summary>Administrative Rider</summary>
        /// <remarks>A general classification of annuity riders that are administrative in nature.</remarks>
        [XmlEnum("214")]
        OLI_RIDER_ADMIN = 214,

        /// <summary>Guaranteed Min Withdrawal for Life Benefit (GWLB)</summary>
        /// <remarks>A guarantee that promises that a certain percentage of the guaranteed benefit base (often paid premiums) can be withdrawn each year for the life of the contract holder, regardless of market performance or the actual account balance.</remarks>
        [XmlEnum("215")]
        OLI_RIDER_GWLB = 215,

        /// <summary>Interest Rate Options</summary>
        /// <remarks>Contract provisions which offer an adjustment to the interest rate crediting amount or method.</remarks>
        [XmlEnum("217")]
        OLI_RIDER_INTRATEOPT = 217,

        /// <summary>Purchase Payment Credit</summary>
        /// <remarks>This rider applies a percentage credit to purchase payments received during the first contract year.  The credit is then allocated according to your current purchase payment allocation.  The credit is subject to contract surrender charges and cannot be cancelled after elected.  It is considered earnings under the contract and if you exercise your right to cancel during the free-look period the credit will not be returned to the contract owner.</remarks>
        [XmlEnum("300")]
        OLI_RIDER_PURPAYCRT = 300,

        /// <summary>Benefit Period Enhancement Rider</summary>
        /// <remarks>Converts and expands a periodic benefit into a benefit with a different frequency. For example can convert a $100 daily benefit into a $700 weekly benefit.  Conversions are not limited to this combination of periods/frequencies.</remarks>
        [XmlEnum("301")]
        OLI_LTCRIDER_BENPERENHANCE = 301,

        /// <summary>Unemployment Rider</summary>
        /// <remarks>Waives payment of the premium in the event of unemployment.</remarks>
        [XmlEnum("302")]
        OLI_RIDER_UNEMP = 302,

        /// <summary>Long Term Comprehensive Care</summary>
        /// <remarks>Combines Facility Care and Home Care Services</remarks>
        [XmlEnum("303")]
        OLI_DIRIDER_COMPCARE = 303,

        /// <summary>Return of Premium</summary>
        /// <remarks>Provides that, subject to carrier rules, part or all of premiums paid will be returned.  Rider Sub Types with a Sublist of 304 further define the nature of the benefit.Coverage may be inherent non-forfeiture option or an optionally selected rider.  When it is inherent, Rider Category Type  must be Benefit (TC=3).  When it is an optional rider, Rider Category Type must be Rider (TC=2).</remarks>
        [XmlEnum("304")]
        OLI_DIRIDER_NONFOR_LTF = 304,

        /// <summary>Non-Forfeiture - Restoration Of Benefits</summary>
        /// <remarks>Provides that if policy lapses future benefits are still available. Does not provide a Death benefit returning premiums paid.</remarks>
        [XmlEnum("305")]
        OLI_DIRIDER_NONFOR_LTD = 305,

        /// <summary>Paid up Survivor Benefit</summary>
        /// <remarks>Provides that if premium is paid for a stated contractual time period, if one of the insureds dies the survivor does not have to pay any additional premiums. Available  with Joint Coverage.  May be subject to carrier rules regarding insured`s claim  history.Coverage may be an inherent non-forfeiture option or an optionally selected rider.  When it is inherent, Rider Category Type must be Benefit (TC=3).  When it is an optional rider, Rider Category Type must be Rider (TC=2).</remarks>
        [XmlEnum("306")]
        OLI_LTCRIDER_NONFOR_SURVIVE = 306,

        /// <summary>Indemnity - Facility</summary>
        /// <remarks>Provides a periodic, stated fixed dollar benefit provided from the contract`s health care facility benefit.</remarks>
        [XmlEnum("307")]
        OLI_LTCRIDER_INDEMFAC = 307,

        /// <summary>Indemnity - Home and Community Based Care: Percentage of facility daily benefit</summary>
        /// <remarks>Provides a periodic, stated fixed dollar amount provided out of the home or community based health care provider. The benefit is stated as a percentage of the facility daily benefit.</remarks>
        [XmlEnum("308")]
        OLI_LTCRIDER_INDEMBOTH = 308,

        /// <summary>Pre-Pay Discount</summary>
        /// <remarks>Provides a discount if some portion of future premiums are pre-paid along with the initial premium.</remarks>
        [XmlEnum("309")]
        OLI_DIRIDER_PREPAY = 309,

        /// <summary>Family Care Giver Reimbursement</summary>
        /// <remarks>Provides a periodic, stated fixed dollar amount for a family care giver's expenses reimbursement. Must be a family member not living with the insured.</remarks>
        [XmlEnum("310")]
        OLI_LTCRIDER_FAMCARE = 310,

        /// <summary>Care Giver Reimbursement</summary>
        /// <remarks>Provides a periodic, stated fixed dollar amount for a any care giver's expenses reimbursement. May be anyone.</remarks>
        [XmlEnum("311")]
        OLI_LTCRIDER_CAREGIVE = 311,

        /// <summary>Restoration of Benefits</summary>
        /// <remarks>Provides a restoration of benefits after a contractually stated elapsed period of time. For example after 6 months.</remarks>
        [XmlEnum("312")]
        OLI_LTCRIDER_RESTOREBEN = 312,

        /// <summary>Waiver of Premium - Spousal</summary>
        /// <remarks>Provides that premiums are waived upon the disability of the insured's spouse.</remarks>
        [XmlEnum("313")]
        OLI_LTCRIDER_WPSPOUSE = 313,

        /// <summary>Cost of Living - Compound</summary>
        /// <remarks>Provides a fixed (non-indexed), compounding Cost of Living Benefit. The compounding of each periodic increase includes previous increases.  The increased benefit does not impact premium.</remarks>
        [XmlEnum("314")]
        OLI_LTCRIDER_COL_COMP = 314,

        /// <summary>Cost of Living - Simple</summary>
        /// <remarks>Provides a fixed (non-indexed) simple interest Cost of Living benefit. Each periodic increase is a stated simple percentage.  The increased benefit does not impact premium.</remarks>
        [XmlEnum("315")]
        OLI_LTCRIDER_COL_SMPL = 315,

        /// <summary>Spousal Discount</summary>
        /// <remarks>Provides a discount if a couple applies together for policies.</remarks>
        [XmlEnum("316")]
        OLI_DIRIDER_SPOUSAL = 316,

        /// <summary>Affiliation Discount</summary>
        /// <remarks>Provides a discount if the applicant is affiliated or otherwise is eligible for a insurer discount.</remarks>
        [XmlEnum("317")]
        OLI_DIRIDER_AFFILIATION = 317,

        /// <summary>Select Health Discount</summary>
        /// <remarks>Provides a discount if the applicant qualifies for the carriers definition of select or good health.</remarks>
        [XmlEnum("318")]
        OLI_DIRIDER_SELECTHEALTH = 318,

        /// <summary>Indemnity - Home and Community Based Care: $ Amt</summary>
        /// <remarks>Indemnity - Home and Community Based Care: Dollar Amount.Provides a periodic, stated fixed dollar benefit when home or community based care is being received in lieu of reimbursement of actual expenses.</remarks>
        [XmlEnum("319")]
        OLI_LTCRIDER_INDEMHOME = 319,

        /// <summary>Capital Preservation provides the most flexibility in how the benefit is to be received by the contract owner since it does not force the owner to receive distributions, annuitize the contract, or prevent full access to guarantee amount at the conclusion of the guarantee period.  It is revocable.</summary>
        /// <remarks>The annuity contract owner is guaranteed that the combined value of the GTO and variable accounts at the end of the rider term will be no less than the contract value when the rider was elected.</remarks>
        [XmlEnum("320")]
        OLI_RIDER_SEF = 320,

        /// <summary>Qualified Adult Discount</summary>
        /// <remarks>Provides a discount if a "qualified adults" apply  together for policies.  Qualified Adult is a  person  of  the  same  or opposite sex who meets all the criteria listed below.1) He or she is over the age of 18.2) He or she has lived with you for at least 12 months.3) He or she has a serious and committed relationship with you.4) He or she is not legally married nor a Domestic Partner to anyone else.5) He or she is financially interdependent with you  Financially interdependent means that you and this person are jointly responsible for the cost of food and housing.</remarks>
        [XmlEnum("321")]
        OLI_DIRIDER_QUALADLT = 321,

        /// <summary>Hardship Rider</summary>
        /// <remarks>In the case of "hardship" (as defined by the contract language of the rider), withdrawals are permitted and not subject to surrender charges.</remarks>
        [XmlEnum("326")]
        OLI_RIDER_HARDSHIP = 326,

        /// <summary>Living Benefit Rider</summary>
        /// <remarks>Guarantees the return of contract value as of the market close the date the rider was added in the form of withdrawals until their entire contract value when the rider was added has been returned, regardless of their contract value at the time of withdraw</remarks>
        [XmlEnum("327")]
        OLI_RIDER_LIVINGBENEFIT = 327,

        /// <summary>Shared Benefit Rider</summary>
        /// <remarks>Rider that provides an extension of the duration of benefits if both spouses have coverage and allows either spouse to draw from the other's coverage if their own benefits are exhausted.</remarks>
        [XmlEnum("328")]
        OLI_RIDER_SHARED = 328,

        /// <summary>Inflation Calculation Rider</summary>
        /// <remarks>Rider that provides for increases in benefit levels over time to help pay expected inflation in the costs of Long Term Care Service.  The increase in benefit is not automatic, requiring specific action on the part of the owner.  If the benefit is increased, premium will be increased appropriately.</remarks>
        [XmlEnum("329")]
        OLI_RIDER_INFLATE = 329,

        /// <summary>Waiver of Premium Rider</summary>
        /// <remarks>Rider providing that, after a designated period, a benefit to waive any premium becoming due until the disability ends.</remarks>
        [XmlEnum("330")]
        OLI_RIDER_PREMWAIVE = 330,

        /// <summary>Residual Disability Benefit Rider</summary>
        /// <remarks>Rider that provides a proportional benefit for disability while the insured is partially disabled.</remarks>
        [XmlEnum("331")]
        OLI_RIDER_PROPORT = 331,

        /// <summary>Automatic Increase Rider</summary>
        /// <remarks>Rider that provides for an automatic increase in the disability monthly income benefit.</remarks>
        [XmlEnum("332")]
        OLI_RIDER_AIO = 332,

        /// <summary>Social Insurance Substitute Benefits Rider</summary>
        /// <remarks>Rider that will provide additional income if the insured is totally disabled and receiving limited or no social insurance benefits.</remarks>
        [XmlEnum("333")]
        OLI_RIDER_SSISUB = 333,

        /// <summary>Activities of Daily Living Income Benefit Rider</summary>
        /// <remarks>Rider that provides additional benefits when the insured is ADL disabled.</remarks>
        [XmlEnum("334")]
        OLI_RIDER_ADL = 334,

        /// <summary>Restoration of Benefits Rider</summary>
        /// <remarks>Provides for a restoration of full policy benefits if only partial benefits are paid, the insured recovers and does not use the benefits for a specified period of time.</remarks>
        [XmlEnum("335")]
        OLI_RIDER_RESTORE = 335,

        /// <summary>Guaranteed Minimum Withdrawal Benefit (GMWB)</summary>
        /// <remarks>This withdrawal benefit guarantees that cumulative withdrawals (or payments to an Annuity Option) will be greater than or equal to the principal invested.</remarks>
        [XmlEnum("336")]
        OLI_RIDER_GWB = 336,

        /// <summary>Guaranteed Min Accumulation Benefit By Maturity Dt</summary>
        /// <remarks>Guarantees a particular return at some maturity date. If the account value is below the guaranteed minimum on the maturity date, then the carrier adds money to the account reach the guaranteed minimum.</remarks>
        [XmlEnum("338")]
        OLI_RIDER_GMAB = 338,

        /// <summary>Assisted Living Care</summary>
        /// <remarks>A rider available for personal care and health services provided for the Activities of Daily Living in an Assisted Living Facility.</remarks>
        [XmlEnum("339")]
        OLI_LTCRIDER_ASSISTCARE = 339,

        /// <summary>Bed Reservation</summary>
        /// <remarks>A rider which provides a daily benefit available for the cost of reserving a nursing home or assisted living facility bed while the covered individual leaves the facility.  This essentially provides the ability to reserve the space in the facility even though it is not being used.</remarks>
        [XmlEnum("340")]
        OLI_LTCRIDER_BEDRES = 340,

        /// <summary>Physical Therapy</summary>
        /// <remarks>A rider available for the services provided by a licensed professional for physical therapy.</remarks>
        [XmlEnum("341")]
        OLI_LTCRIDER_PHYSTHERAPY = 341,

        /// <summary>Speech Therapy</summary>
        /// <remarks>A rider available for the services provided by a licensed professional for speech therapy.</remarks>
        [XmlEnum("342")]
        OLI_LTCRIDER_SPEECHTHERAPY = 342,

        /// <summary>Occupational Therapy</summary>
        /// <remarks>A rider available for services provided by a licensed professional for occupational therapy.</remarks>
        [XmlEnum("343")]
        OLI_LTCRIDER_OCCUPTHERAPY = 343,

        /// <summary>Day Care</summary>
        /// <remarks>A rider available for care during the day for a covered individual, for adults, usually at senior or community centers, for children, at a licensed child-care facility.</remarks>
        [XmlEnum("344")]
        OLI_LTCRIDER_DAYCARE = 344,

        /// <summary>Adult Foster Care</summary>
        /// <remarks>A rider available for of an adult in a foster care situation.</remarks>
        [XmlEnum("345")]
        OLI_LTCRIDER_ADULTFOSTERCARE = 345,

        /// <summary>Respite Care</summary>
        /// <remarks>A rider available for care that is provided to long-term care patients, at home, by professionals or volunteers for a few hours a few days while allowing caregivers some time away from providing primary care.</remarks>
        [XmlEnum("346")]
        OLI_LTCRIDER_RESPITCARE = 346,

        /// <summary>Hospice Care</summary>
        /// <remarks>A rider available for care that is intended to provide comfort for the terminal patient and support for their family.</remarks>
        [XmlEnum("347")]
        OLI_LTCRIDER_HOSPICECARE = 347,

        /// <summary>Alternate Plan of Care</summary>
        /// <remarks>A rider available for special arrangements or services to allow the insured to receive benefits for services outside the coverages of a long term care policy (e.g. in-home safety devices, home delivered meals, stays in special types of facilities, additional equipment benefits).</remarks>
        [XmlEnum("348")]
        OLI_LTCRIDER_ALTCARE = 348,

        /// <summary>Rehabilitation</summary>
        /// <remarks>A rider which specifies a reduced benefit available for disability while the insured participates in occupational therapy.</remarks>
        [XmlEnum("350")]
        OLI_DIRIDER_REHAB = 350,

        /// <summary>Surgical Transplant Donor</summary>
        /// <remarks>A rider available for disability resulting from the transplant of part of the body of the insured to the body of another person.</remarks>
        [XmlEnum("353")]
        OLI_DIRIDER_TRANSPLANTDONOR = 353,

        /// <summary>Non-Disabling Injury</summary>
        /// <remarks>A rider that provides for expenses incurred for medical treatment prescribed by a physician for a non-disabling injury.</remarks>
        [XmlEnum("354")]
        OLI_LTCRIDER_INJURY = 354,

        /// <summary>Disability Buy-Out</summary>
        /// <remarks>A rider for jointly owned businesses that disburses funds for one partner, on the business' disabled partner's share of the business.</remarks>
        [XmlEnum("355")]
        OLI_DIRIDER_DISBUYOUT = 355,

        /// <summary>Sickness Disability Income</summary>
        /// <remarks>Disability Income covers any sickness which prevents policyholder from working for a given period of time</remarks>
        [XmlEnum("356")]
        OLI_DIRIDER_DISABILITYINC = 356,

        /// <summary>Accident Disability Income</summary>
        /// <remarks>Accident Disability Income covers any accident which prevents policyholder from working for a given period of time.</remarks>
        [XmlEnum("357")]
        OLI_DIRIDER_ACCDIABILITYINC = 357,

        /// <summary>Basic Hospital</summary>
        /// <remarks>Basic Hospital provides hospital care expenses.  DisabilityHealthOption may be defined for hospital room, nursing services, and other regular daily services and supplies .</remarks>
        [XmlEnum("358")]
        OLI_DIRIDER_BASICHOSPITAL = 358,

        /// <summary>Dental Plus Orthodontia</summary>
        /// <remarks>Dental provides expenses related to routine dental care plus orthodontia.</remarks>
        [XmlEnum("359")]
        OLI_DIRIDER_DENTALPLUSORTHO = 359,

        /// <summary>Dread Disease and Impairment</summary>
        /// <remarks>Coverage in the event of either the policyholder contracts a dreaded disease or becomes impaired.</remarks>
        [XmlEnum("360")]
        OLI_DIRIDER_DREADDISIMPAIR = 360,

        /// <summary>Small Business Discount</summary>
        [XmlEnum("361")]
        OLI_RIDER_SMALLBUS = 361,

        /// <summary>Loyalty Discount</summary>
        /// <remarks>Used when a discount applies for the length of time as a customer.</remarks>
        [XmlEnum("362")]
        OLI_RIDER_LOYALTY = 362,

        /// <summary>Premium Rate Guarantee</summary>
        /// <remarks>Guarantees that the premium rate at inception will continue to be in effect for a specific period of time or until a certain attained age for this policy, regardless of subsequent rate increases to the block of business.Coverage may be inherent or an optionally selected rider.  When it is inherent, Rider Category Type must be Benefit (TC=3).  When it is an optional rider, Rider Category Type must be Rider (TC=2).</remarks>
        [XmlEnum("363")]
        OLI_RIDER_PREMRATEGUARANTEE = 363,

        /// <summary>Family Care Rider</summary>
        /// <remarks>Optionally selected coverage provides a pooled amount on the policy which can be shared by a Primary Insured and any of their named insured family members.  Carrier specific restrictions may apply.</remarks>
        [XmlEnum("364")]
        OLI_RIDER_FAMILYCARE = 364,

        /// <summary>Non-professional Services</summary>
        /// <remarks>Provides for the hiring of a resource to provide non-professional services to assist in performing ADL’s or homemaker services.  This person  would perform services such as laundry, meal prep, and simple cleaning. This benefit may also provide additional funds for home modifications and installation of other home safety equipment.Coverage may be inherent or an optionally selected rider.  When it is inherent, Rider Category Type must be Benefit (TC=3).  When it is an optional rider, Rider Category Type must be Rider (TC=2).</remarks>
        [XmlEnum("365")]
        OLI_RIDER_NONPROFESSIONALSERVICE = 365,

        /// <summary>Restoration of Benefits</summary>
        /// <remarks>Optionally selected rider which provides that if carrier-specific rules have been satisfied, the contract benefits can be restored in full or in part after claim benefits have been paid on a policy</remarks>
        [XmlEnum("366")]
        OLI_RIDER_RESTOREBENEFITS = 366,

        /// <summary>Return of Premium - Long Term Care</summary>
        /// <remarks>Optionally selected coverage which provides that after a stated period of time in which the contract has been maintained in good order, some of the premiums paid to date will be returned.</remarks>
        [XmlEnum("367")]
        OLI_RIDER_ROPLTC = 367,

        /// <summary>Cancellation</summary>
        /// <remarks>Optionally selected coverage which provides that if the insured dies or cancellation of coverage at the request of the owner occurs, some portion of the premium paid to date is returned.  The amount returned is calculated based on carrier specific rules.</remarks>
        [XmlEnum("368")]
        OLI_RIDER_CANCELLATION = 368,

        /// <summary>Paid Up</summary>
        /// <remarks>On a Long Term Care policy, this coverage provides that should the payment of premium be discontinued, the amount paid to date can be used to fund either a reduced benefit amount or a shortened benefit period.Coverage may be an inherent non-forfeiture option or an optionally selected rider.  When it is inherent, Rider Category Type  must be Benefit (TC=3).  When it is an optional rider, Rider Category Type must be Rider (TC=2).</remarks>
        [XmlEnum("369")]
        OLI_RIDER_PAIDUP = 369,

        /// <summary>High Limit Residential Care</summary>
        /// <remarks>This optionally selected rider increases the coverage for Residential (Home or Assisted Living) Care from 70% to 100% of the daily benefit. This rider is specific to the CA Partnership.</remarks>
        [XmlEnum("370")]
        OLI_RIDER_HIGHLIMITRESCARE = 370,

        /// <summary>Assisted Living - Room Charge</summary>
        /// <remarks>Optionally selected benefit which provides for the reimbursement of Room charges that are not covered elsewhere while the insured resides in an Assisted Living Facility.</remarks>
        [XmlEnum("371")]
        OLI_LTCRIDER_ASSISTLIVROOMCHARGE = 371,

        /// <summary>Marital Discount</summary>
        [XmlEnum("372")]
        OLI_RIDER_MARITAL = 372,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
