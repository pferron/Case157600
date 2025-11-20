using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_COVTYPE_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Whole Life Ordinary</summary>
        [XmlEnum("1")]
        OLI_COVTYPE_WLORDINARY = 1,

        /// <summary>Whole Life Modified</summary>
        [XmlEnum("2")]
        OLI_COVTYPE_WLMODIFIED = 2,

        /// <summary>Whole Life Limited Pay</summary>
        [XmlEnum("3")]
        OLI_COVTYPE_WLLIMITEDPAY = 3,

        /// <summary>Whole Life Graded Premium</summary>
        [XmlEnum("4")]
        OLI_COVTYPE_WLGRADPREM = 4,

        /// <summary>Interest Sensitive Whole Life</summary>
        [XmlEnum("5")]
        OLI_COVTYPE_INTSENSITIVEWL = 5,

        /// <summary>Term Level Death Benefit</summary>
        [XmlEnum("6")]
        OLI_COVTYPE_TERMLEVEL = 6,

        /// <summary>Term Decreasing Death Benefit</summary>
        [XmlEnum("7")]
        OLI_COVTYPE_TERMDECREASE = 7,

        /// <summary>Term Increasing Death Benefit</summary>
        [XmlEnum("8")]
        OLI_COVTYPE_TERMINCREASE = 8,

        /// <summary>Universal Life</summary>
        [XmlEnum("9")]
        OLI_COVTYPE_UNIVLIFE = 9,

        /// <summary>Indexed Universal Life</summary>
        [XmlEnum("10")]
        OLI_COVTYPE_INDXUNIVLIFE = 10,

        /// <summary>Variable Universal Life</summary>
        [XmlEnum("11")]
        OLI_COVTYPE_VARUNIVLIFE = 11,

        /// <summary>Excess Interest Life</summary>
        [XmlEnum("12")]
        OLI_COVTYPE_EXINTLIFE = 12,

        /// <summary>Variable Whole Life</summary>
        [XmlEnum("13")]
        OLI_COVTYPE_VARWLIFE = 13,

        /// <summary>Disability (income protection)</summary>
        [XmlEnum("14")]
        OLI_COVTYPE_DISABILITY = 14,

        /// <summary>Guaranteed Survivor Purchase Option</summary>
        [XmlEnum("15")]
        OLI_COVTYPE_GUARSURVPURCH = 15,

        /// <summary>Long Term Care</summary>
        [XmlEnum("16")]
        OLI_COVTYPE_LTC = 16,

        /// <summary>Dread Disease</summary>
        [XmlEnum("17")]
        OLI_COVTYPE_DREADDISEASE = 17,

        /// <summary>Paid Up Additions Rider</summary>
        [XmlEnum("18")]
        OLI_COVTYPE_PUARIDER = 18,

        /// <summary>Paid Up Additions Dividends</summary>
        [XmlEnum("19")]
        OLI_COVTYPE_PUADIV = 19,

        /// <summary>Annuity Fixed</summary>
        [XmlEnum("20")]
        OLI_COVTYPE_ANNUITY = 20,

        /// <summary>Waiver of scheduled (planned) premiums</summary>
        [XmlEnum("21")]
        OLI_COVTYPE_WAIVSCHED = 21,

        /// <summary>Accumulated Dividend</summary>
        [XmlEnum("22")]
        OLI_COVTYPE_ACCUMDIV = 22,

        /// <summary>Accidental Death Benefit</summary>
        [XmlEnum("23")]
        OLI_COVTYPE_ACCDTHBENE = 23,

        /// <summary>Flexible Additional Insurance</summary>
        [XmlEnum("24")]
        OLI_COVTYPE_FLEXADDON = 24,

        /// <summary>Family Income</summary>
        [XmlEnum("25")]
        OLI_COVTYPE_FAMILYINC = 25,

        /// <summary>Estate Protector Rider</summary>
        [XmlEnum("26")]
        OLI_COVTYPE_ESTATEPROT = 26,

        /// <summary>Overhead Expense</summary>
        [XmlEnum("27")]
        OLI_COVTYPE_OVREXP = 27,

        /// <summary>Funeral Expense</summary>
        [XmlEnum("28")]
        OLI_COVTYPE_FUNEXP = 28,

        /// <summary>Hospital Expense</summary>
        [XmlEnum("29")]
        OLI_COVTYPE_HOSPEXP = 29,

        /// <summary>Medical (health coverage) expense</summary>
        [XmlEnum("30")]
        OLI_COVTYPE_MEDEXP = 30,

        /// <summary>Accidental Disability Benefit</summary>
        [XmlEnum("31")]
        OLI_COVTYPE_ACCDISBENE = 31,

        /// <summary>Lifetime Total Disability</summary>
        [XmlEnum("32")]
        OLI_COVTYPE_LIFTOTDIS = 32,

        /// <summary>Critical Illness</summary>
        /// <remarks>Critical Illness is designed to assist individuals by cover excess expenses (usually beyond what health care or disability insurance would cover) in the event that an individual contracts one of the diseases (usually 5-7 diseases) named in the policy.  It usually pay a lump sump upon proof of claim.</remarks>
        [XmlEnum("33")]
        OLI_COVTYPE_CRITILLNESS = 33,

        /// <summary>Credit Mortgage</summary>
        [XmlEnum("35")]
        OLI_COVTYPE_CREDITMORT = 35,

        /// <summary>PVT WS Loss of Sight or Limb</summary>
        [XmlEnum("37")]
        OLI_COVTYPE_SIGHTLIMB = 37,

        /// <summary>Waiver on Death</summary>
        [XmlEnum("40")]
        OLI_COVTYPE_WAIVERDEATH = 40,

        /// <summary>Waiver on Disability</summary>
        [XmlEnum("41")]
        OLI_COVTYPE_WAIVERDISABILITY = 41,

        /// <summary>Critical illness premium waiver</summary>
        /// <remarks>Covers cost of the policy contributions in the event of the principal insured becoming severely ill.</remarks>
        [XmlEnum("42")]
        OLI_COVTYPE_WPCRIT = 42,

        /// <summary>Medical aid premium waiver</summary>
        /// <remarks>Covers cost of medical aid contributions in the event of the principal insured becoming severely ill, disabled or dies</remarks>
        [XmlEnum("43")]
        OLI_COVTYPE_WPMED = 43,

        /// <summary>Open Investment Option</summary>
        [XmlEnum("50")]
        OLI_COVTYPE_OPENINVESTMENT = 50,

        /// <summary>Open Investment for Retirement</summary>
        [XmlEnum("51")]
        OLI_COVTYPE_OPENINVESTMENTRETIRE = 51,

        /// <summary>Aids</summary>
        [XmlEnum("52")]
        OLI_COVTYPE_AIDS = 52,

        /// <summary>Variable Annuity</summary>
        [XmlEnum("53")]
        OLI_COVTYPE_VARANNUITY = 53,

        /// <summary>Pays in event of Own Occupation Disability</summary>
        /// <remarks>This applies to disability payments in event of Disability to exercise his/her Regular (Own) Occupation as a Stand-alone benefit</remarks>
        [XmlEnum("54")]
        OLI_COVTYPE_DISREGOCC = 54,

        /// <summary>Pays in event of Own and/or Similar Occupation Disability</summary>
        /// <remarks>This applies to disability payments in event of Disability to exercise Regular and/ or Similar Occupation as a Stand-alone benefit</remarks>
        [XmlEnum("55")]
        OLI_COVTYPE_DISSIMOCC = 55,

        /// <summary>Pays in event of functional impairment</summary>
        /// <remarks>This applies to Disability payments in event of Functional impairment - as a Stand-alone benefit</remarks>
        [XmlEnum("56")]
        OLI_COVTYPE_FUNCIMP = 56,

        /// <summary>Pays in event of Comprehensive Dread Diseases during Term</summary>
        /// <remarks>This cover applies to Disability  payments in event of Comprehensive Dread Disease - as a Stand-alone benefit for a specific term.Tic=17 Dread disease - is used for Core Dread disease</remarks>
        [XmlEnum("57")]
        OLI_COVTYPE_TERMDREADCOMP = 57,

        /// <summary>Heart and artery</summary>
        /// <remarks>Covers diseases of the cardiovascular system</remarks>
        [XmlEnum("58")]
        OLI_COVTYPE_HEART = 58,

        /// <summary>Urogenital tract and kidney</summary>
        /// <remarks>Covers disorders of the urogenital tract or kidney, requiring ongoing therapy or major surgery</remarks>
        [XmlEnum("59")]
        OLI_COVTYPE_KIDNEY = 59,

        /// <summary>Child critical illness</summary>
        /// <remarks>Covers a range of critical illnesses, such as cancer, organ transplantation, some severe infections, heart abnormalities</remarks>
        [XmlEnum("60")]
        OLI_COVTYPE_CHILDCRIT = 60,

        /// <summary>Female benefit</summary>
        /// <remarks>Covers female specific critical illness, such as pregnancy complications, female cancers and osteoporosis</remarks>
        [XmlEnum("61")]
        OLI_COVTYPE_FEMCRIT = 61,

        /// <summary>Cancer</summary>
        /// <remarks>Benefits payable from stage 1 cancer, and includes bone marrow disease</remarks>
        [XmlEnum("62")]
        OLI_COVTYPE_CANCER = 62,

        /// <summary>Connective tissue diseases</summary>
        /// <remarks>Covers autoimmune illnesses that cause the body to attack its own joints, vessels or tissues</remarks>
        [XmlEnum("63")]
        OLI_COVTYPE_CTD = 63,

        /// <summary>Hospital and surgical</summary>
        /// <remarks>Covers disease or damage to the brain, nerves, spinal cord arteries that supply nerves and brain, and neuromuscular junctions</remarks>
        [XmlEnum("64")]
        OLI_COVTYPE_HOSPSURG = 64,

        /// <summary>Nervous system disease</summary>
        /// <remarks>Covers disease or damage to the brain, nerves, spinal cord arteries that supply nerves and brain, and neuromuscular junctions</remarks>
        [XmlEnum("65")]
        OLI_COVTYPE_NERV = 65,

        /// <summary>Gastrointestinal disease</summary>
        /// <remarks>Covers diseases of the gastrointestinal tract that results in continuous hospitalization, and terminal changes to these organs</remarks>
        [XmlEnum("66")]
        OLI_COVTYPE_GAST = 66,

        /// <summary>Respiratory disease</summary>
        /// <remarks>Covers impairment of lung function, excluding pulmonary embolus</remarks>
        [XmlEnum("67")]
        OLI_COVTYPE_RESP = 67,

        /// <summary>Global health care cover</summary>
        /// <remarks>Covers the cost of procedures in another country, where the prognosis of recovery is recognized to be better than that in the insured's domicile country</remarks>
        [XmlEnum("68")]
        OLI_COVTYPE_GLOBHLTH = 68,

        /// <summary>Vitality health</summary>
        /// <remarks>Additional benefit that allows for intermittent reduction in  risk rates for proof that the insured pro-actively maintains good health / improves their health</remarks>
        [XmlEnum("69")]
        OLI_COVTYPE_VITALITY = 69,

        /// <summary>Education cover</summary>
        /// <remarks>Covers cost of education in the event of the principal insured becoming severely ill, disabled or dies</remarks>
        [XmlEnum("70")]
        OLI_COVTYPE_EDUCATION = 70,

        /// <summary>Child birth benefit</summary>
        /// <remarks>Covers birth defects for future children</remarks>
        [XmlEnum("71")]
        OLI_COVTYPE_CHILDBRTH = 71,

        /// <summary>Endowment</summary>
        [XmlEnum("100")]
        OLI_COVTYPE_ENDOWMENT = 100,

        /// <summary>Retirement Annuity</summary>
        [XmlEnum("101")]
        OLI_COVTYPE_RETANNUITY = 101,

        /// <summary>Guaranteed Insurability</summary>
        [XmlEnum("102")]
        OLI_COVTYPE_GIB = 102,

        /// <summary>Danish Lump Sum Savings Coverage 125</summary>
        /// <remarks>125 is a Danish Lump Sum Savings Coverage</remarks>
        [XmlEnum("103")]
        OLI_COVTYPE_DENSAVINGS125 = 103,

        /// <summary>Danish Annuity Certain Savings Coverage 175</summary>
        /// <remarks>175 is a Danish Annuity Certain Savings Coverage</remarks>
        [XmlEnum("104")]
        OLI_COVTYPE_DENSAVINGS175 = 104,

        /// <summary>Danish Deferred Life Annuity Savings Coverage 211</summary>
        /// <remarks>211 is a Danish Deferred Life Annuity Savings Coverage</remarks>
        [XmlEnum("105")]
        OLI_COVTYPE_DENDEFLIFE211 = 105,

        /// <summary>Danish Deferred Annuity Savings Coverage 216</summary>
        /// <remarks>216 is a Danish Deferred Annuity Savings Coverage</remarks>
        [XmlEnum("106")]
        OLI_COVTYPE_DENDEFANNUITY216 = 106,

        /// <summary>Danish Guaranteed Life Annuity Coverage 265</summary>
        /// <remarks>265 is a deferred annuity payable on death</remarks>
        [XmlEnum("107")]
        OLI_COVTYPE_DENGUARLIFEANN265 = 107,

        /// <summary>Danish Death Annuity Certain Coverage 165</summary>
        /// <remarks>165 is a death annuity coverage</remarks>
        [XmlEnum("108")]
        OLI_COVTYPE_DENDTHANNUITY165 = 108,

        /// <summary>Danish Death Lump Sum Coverage 115</summary>
        /// <remarks>115 is death Lump sum coverage</remarks>
        [XmlEnum("109")]
        OLI_COVTYPE_DENDTHLUMPSUM115 = 109,

        /// <summary>Waiver on 50% Disability</summary>
        /// <remarks>Full waiver of premium with minimum 50% disability.</remarks>
        [XmlEnum("110")]
        OLI_COVTYPE_DENWVRDISAB50 = 110,

        /// <summary>Waiver on 66% Disability</summary>
        /// <remarks>Half waiver of premium with between 50-66% disability and whole waiver of premium with disability over 66%.</remarks>
        [XmlEnum("111")]
        OLI_COVTYPE_DENWVRDISAB66 = 111,

        /// <summary>Waiver of Monthly Deductions</summary>
        /// <remarks>Pays monthly charges and the charges associated with the no lapse guarantee as long as the individual is considered disabled</remarks>
        [XmlEnum("114")]
        OLI_COVTYPE_WAIVMONTHDEDUCT = 114,

        /// <summary>Enhanced Disability Benefit</summary>
        /// <remarks>Pays the greater of a percentage of the annual target premium OR the monthly charges during the insured's total disability</remarks>
        [XmlEnum("115")]
        OLI_COVTYPE_ENHANCEDISABILITY = 115,

        /// <summary>Child Term Rider</summary>
        /// <remarks>Insurance protection that offers level term premiums, level death benefit, and an option to convert at specified times for eligible children.</remarks>
        [XmlEnum("116")]
        OLI_COVTYPE_CHILDTERM = 116,

        /// <summary>Sickness Benefit</summary>
        /// <remarks>This benefit covers any sickness which prevents the client from working for any given period. The sickness does not have to be critical or permanent in nature.</remarks>
        [XmlEnum("121")]
        OLI_COVTYPE_SICKBEN = 121,

        /// <summary>Dread Disease and Impairment</summary>
        /// <remarks>Cover in the event of either the life assured contracting a dreaded disease or becoming impaired.</remarks>
        [XmlEnum("122")]
        OLI_COVTYPE_DREADIMPAIR = 122,

        /// <summary>Permanent or Partial Incapacity</summary>
        /// <remarks>Permanent or Partial  Combination benefit that covers permanent incapacity and or partial incapacitation. Payments made in respect of this policy can be temporary and/or permanent duration of the incapacity. This benefit can be freestanding (base benefit) or a rider.</remarks>
        [XmlEnum("123")]
        OLI_COVTYPE_PPINC = 123,

        /// <summary>Preservation Pension Fund</summary>
        /// <remarks>At retirement, a member may take up to one third of the capital as a lump sum. The remaining two thirds must be used to provide a pension for life. Tax is deducted at retirement. A member  can make one taxable ad hoc withdrawal from the fund before retirement.</remarks>
        [XmlEnum("124")]
        OLI_COVTYPE_PRES_PENFND = 124,

        /// <summary>Preservation Provident Fund</summary>
        /// <remarks>At retirement, a member may take the full proceeds as a lump sum. Member may purchase a Life Annuity with the proceeds or after tax has been deducted, one may also invest the lump sum. A member  can make one taxable ad hoc withdrawal from the fund before retirement.</remarks>
        [XmlEnum("125")]
        OLI_COVTYPE_PRES_PROVFND = 125,

        /// <summary>Retrenchment Benefit</summary>
        /// <remarks>An income replacement type benefit should the client become retrenched from his job (unemployed).</remarks>
        [XmlEnum("126")]
        OLI_COVTYPE_RETRENCH = 126,

        /// <summary>Accidental Death and/or Disability</summary>
        /// <remarks>Accidental Death and/or Disability Benefit pays out in the event of either one or more events.</remarks>
        [XmlEnum("127")]
        OLI_COVTYPE_ADIB = 127,

        /// <summary>Waiver on Retrench</summary>
        /// <remarks>Premium waiver in the event of someone being Retrenched (losing their job).  Covers cost of the policy contributions in the event of the policy payer losing his/her job (unemployed).</remarks>
        [XmlEnum("128")]
        OLI_COVTYPE_WAIVERRETRENCH = 128,

        /// <summary>Provident Fund</summary>
        /// <remarks>It is a grouped retirement fund opposed to an individual endowment policy. The tax implication for the proceeds of provident fund and a provident owned endowment policy differs from that of an individual endowment policy</remarks>
        [XmlEnum("129")]
        OLI_COVTYPE_PROVIDENT = 129,

        /// <summary>Group Pension</summary>
        /// <remarks>It is a grouped retirement fund opposed to a Retirement Annuity which is an individual retirement fund.</remarks>
        [XmlEnum("130")]
        OLI_COVTYPE_PENSION = 130,

        /// <summary>Life Linked Investment</summary>
        /// <remarks>This is a plan of which the savings element is invested under a LISP (Linked Investment Service Provider) licence in Unit Trusts and Shares that is also subject to Capital Gains Tax in the hands of the investor. However there could also be risk benefits included in this plan that is then sold under the LIFE licence.  It is therefore a combination of LISP savings with LIFE risk benefits that is sold as one product.</remarks>
        [XmlEnum("131")]
        OLI_COVTYPE_LISP = 131,

        /// <summary>Family Trauma Benefit</summary>
        /// <remarks>Accidental, non self-inflicted injury to any area of the body.  Family is defined as the principal life, spouse or companion, and children as defined by carrier rule.</remarks>
        [XmlEnum("132")]
        OLI_COVTYPE_FAMILYTRAUMA = 132,

        /// <summary>Accidental Death and Dismemberment</summary>
        [XmlEnum("133")]
        OLI_COVTYPE_ADD = 133,

        /// <summary>Combined Risk Benefit</summary>
        /// <remarks>A single benefit that covers multiple risks. This may also be known as a "combined benefit."  Typically, this will be used to represent different permutations of combined benefits, eg  disability and/or dread disease covered in a single benefit.</remarks>
        [XmlEnum("134")]
        OLI_COVTYPE_COMBI = 134,

        /// <summary>Future Premium Waiver</summary>
        /// <remarks>This benefit provides for the premiums to cease at a future date (usually at age 65), while all benefits remain active and in force for the balance of the policy term. It is effectively a way to insure future benefits after retirement.</remarks>
        [XmlEnum("135")]
        OLI_COVTYPE_PAIDUP = 135,

        /// <summary>Premium Lock In Benefit</summary>
        /// <remarks>This benefit allows for all premium increases and benefit increases to cease at a future date (usually at age 65). It locks the premium and Benefits at that future date.</remarks>
        [XmlEnum("136")]
        OLI_COVTYPE_LOCK = 136,

        /// <summary>Global Linkage Benefit Guarantee</summary>
        /// <remarks>The Global Linkage Benefit Guarantee links the amount of risk coverage provided by other coverages on the contract to the performance of the global market. This is a type of benefit guarantee (or Death Benefit Guarantee) where the guaranteed amount is determined by the global market’s growth.  At the time of a claim, the amount of risk coverage will be determined by the GREATER of the Global Linkage Benefit Guarantee” amount (i.e. the CurrentAmt of the Coverage with the LifeCovTypeCode of "Global Linkage Benefit Guarantee") OR the benefit amount of the individual Coverage (i.e. the CurrentAmt of the Coverage paying the claim).  The coverages that receive this benefit guarantee are not selectable.  Rather, the benefit guarantee applies to other coverages on the Policy as defined by the product (i.e. it typically applies to all other coverages on the contract.</remarks>
        [XmlEnum("137")]
        OLI_COVTYPE_GLOBALLINKAGEBENEFIT = 137,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
