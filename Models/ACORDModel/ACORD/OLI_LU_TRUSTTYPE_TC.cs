using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_TRUSTTYPE_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>A Trust</summary>
        [XmlEnum("1")]
        OLI_TRUST_A = 1,

        /// <summary>B Trust</summary>
        [XmlEnum("2")]
        OLI_TRUST_B = 2,

        /// <summary>Alaska Trust</summary>
        [XmlEnum("3")]
        OLI_TRUST_ALASKA = 3,

        /// <summary>Applicable Credit Amount Trust</summary>
        [XmlEnum("4")]
        OLI_TRUST_APPCREDIT = 4,

        /// <summary>Blind Trust</summary>
        [XmlEnum("5")]
        OLI_TRUST_BLIND = 5,

        /// <summary>Bypass Trust</summary>
        [XmlEnum("6")]
        OLI_TRUST_BYPASS = 6,

        /// <summary>Cemetery Trust</summary>
        [XmlEnum("7")]
        OLI_TRUST_CEMETARY = 7,

        /// <summary>CLAT (Charitable Lead Annuity Trust)</summary>
        [XmlEnum("8")]
        OLI_TRUST_CLAT = 8,

        /// <summary>Clifford Trust</summary>
        [XmlEnum("9")]
        OLI_TRUST_CLIFFORD = 9,

        /// <summary>CLUT (Charitable Lead Unit Trust)</summary>
        [XmlEnum("10")]
        OLI_TRUST_CLUT = 10,

        /// <summary>Constructive Trust</summary>
        [XmlEnum("11")]
        OLI_TRUST_CONSTRUCTIVE = 11,

        /// <summary>Contingent Trust</summary>
        [XmlEnum("12")]
        OLI_TRUST_CONTINGENT = 12,

        /// <summary>CRAT (Charitable Remainder Annuity Trust)</summary>
        [XmlEnum("13")]
        OLI_TRUST_CRAT = 13,

        /// <summary>Credit Shelter Trust (Unified Credit Trust)</summary>
        [XmlEnum("14")]
        OLI_TRUST_CREDSHELTER = 14,

        /// <summary>Crummey Trust</summary>
        [XmlEnum("15")]
        OLI_TRUST_CRUMMEY = 15,

        /// <summary>CRUT (Charitable Remainder Unit Trust)</summary>
        [XmlEnum("16")]
        OLI_TRUST_CRUT = 16,

        /// <summary>Defective Grantor Trust (IDIT/Intentionally Defective Irrevocable Trust)</summary>
        [XmlEnum("17")]
        OLI_TRUST_DEFGRANTOR = 17,

        /// <summary>Delaware Business Trust</summary>
        [XmlEnum("18")]
        OLI_TRUST_DELAWAREBUS = 18,

        /// <summary>Disclaimer Trust</summary>
        [XmlEnum("19")]
        OLI_TRUST_DISCLAIMER = 19,

        /// <summary>Discretionary Trust</summary>
        [XmlEnum("20")]
        OLI_TRUST_DISCRETIONARY = 20,

        /// <summary>Dry Trust</summary>
        [XmlEnum("21")]
        OLI_TRUST_DRY = 21,

        /// <summary>Dynasty Trust</summary>
        [XmlEnum("22")]
        OLI_TRUST_DYNASTY = 22,

        /// <summary>Educational Trust (Section 2503(C) Trust)</summary>
        [XmlEnum("23")]
        OLI_TRUST_EDUCATION = 23,

        /// <summary>Estate Trust</summary>
        [XmlEnum("24")]
        OLI_TRUST_ESTATE = 24,

        /// <summary>Generation-Skipping Trust (GST Trust)</summary>
        [XmlEnum("25")]
        OLI_TRUST_GENERATION = 25,

        /// <summary>Grantor Trust</summary>
        [XmlEnum("26")]
        OLI_TRUST_GRANTOR = 26,

        /// <summary>GRAT (Grantor Retained Annuity Trust)</summary>
        [XmlEnum("27")]
        OLI_TRUST_GRAT = 27,

        /// <summary>GRIT (Granter Retained Income Trust)</summary>
        [XmlEnum("28")]
        OLI_TRUST_GRIT = 28,

        /// <summary>GRUT (Granter Retained Unit Trust)</summary>
        [XmlEnum("29")]
        OLI_TRUST_GRUT = 29,

        /// <summary>Illinois Land Trust</summary>
        [XmlEnum("30")]
        OLI_TRUST_ILLINOISLAND = 30,

        /// <summary>Insurance Trust</summary>
        [XmlEnum("31")]
        OLI_TRUST_INSURANCE = 31,

        /// <summary>IRA QTIP</summary>
        [XmlEnum("32")]
        OLI_TRUST_IRAQTIP = 32,

        /// <summary>Living Trust (same as Loving Trust)</summary>
        [XmlEnum("33")]
        OLI_TRUST_LIVING = 33,

        /// <summary>Marital Deduction Trust</summary>
        [XmlEnum("34")]
        OLI_TRUST_MARITAL = 34,

        /// <summary>Massachusetts Trust</summary>
        [XmlEnum("35")]
        OLI_TRUST_MASSACHUSETTS = 35,

        /// <summary>Medicaid Trust</summary>
        [XmlEnum("36")]
        OLI_TRUST_MEDICATE = 36,

        /// <summary>Minority Trust</summary>
        [XmlEnum("37")]
        OLI_TRUST_MINORITY = 37,

        /// <summary>Net Income Makeup Charitable Remainder Unit Trust (NIMCRUT)</summary>
        [XmlEnum("38")]
        OLI_TRUST_NIMCRUT = 38,

        /// <summary>Non-marital Trust</summary>
        [XmlEnum("39")]
        OLI_TRUST_NONMARITAL = 39,

        /// <summary>Offshore Trust</summary>
        [XmlEnum("40")]
        OLI_TRUST_OFFSHORE = 40,

        /// <summary>Pour-Over Trust (Spill-Over Trust)</summary>
        [XmlEnum("41")]
        OLI_TRUST_POUROVER = 41,

        /// <summary>QDOT (Qualified Domestic Trust)</summary>
        [XmlEnum("42")]
        OLI_TRUST_QDOT = 42,

        /// <summary>QPRT (Qualified Personal Residence Trust)</summary>
        [XmlEnum("43")]
        OLI_TRUST_QPRT = 43,

        /// <summary>QTIP Trust (Qualified Terminable Interest Trust)</summary>
        [XmlEnum("44")]
        OLI_TRUST_QTIP = 44,

        /// <summary>Rabbi Trust</summary>
        [XmlEnum("45")]
        OLI_TRUST_RABBI = 45,

        /// <summary>Residuary Trust</summary>
        [XmlEnum("46")]
        OLI_TRUST_RESIDUARY = 46,

        /// <summary>Second-to-Die Insurance Trust</summary>
        [XmlEnum("47")]
        OLI_TRUST_SECONDTODIE = 47,

        /// <summary>SNT (Supplemental Needs Trust / Special Needs Trust / Escher Trust)</summary>
        [XmlEnum("48")]
        OLI_TRUST_SNT = 48,

        /// <summary>Sprinkling Trust (Spray Trust)</summary>
        [XmlEnum("49")]
        OLI_TRUST_SPRINKLING = 49,

        /// <summary>Standby Trust</summary>
        [XmlEnum("50")]
        OLI_TRUST_STANDBY = 50,

        /// <summary>Testamentary Trust (by a will)</summary>
        /// <remarks>This is a trust established by a will</remarks>
        [XmlEnum("51")]
        OLI_TRUST_TESTAMENTARY = 51,

        /// <summary>Totten Trust</summary>
        [XmlEnum("52")]
        OLI_TRUST_TOTTEN = 52,

        /// <summary>Voting Trust</summary>
        [XmlEnum("53")]
        OLI_TRUST_VOTING = 53,

        /// <summary>Wealth Replacement Trust</summary>
        [XmlEnum("54")]
        OLI_TRUST_WEALTHREP = 54,

        /// <summary>Qualified Plan Trust</summary>
        [XmlEnum("55")]
        OLI_TRUST_QUALPLAN = 55,

        /// <summary>VEBA/501(c)(9) Trust</summary>
        [XmlEnum("56")]
        OLI_TRUST_VEBATRUST = 56,

        /// <summary>Welfare Benefit Trust</summary>
        /// <remarks>Trust set up under IRC 419A(f)(6), multiemployer trust, or IRC 419(e), single employer trust.  The purpose of the Trust is to provide certain Welfare Benefits to the participants named in the Trust</remarks>
        [XmlEnum("57")]
        OLI_TRUST_WELFAREBENEFIT = 57,

        /// <summary>Charity Trust</summary>
        /// <remarks>Charity Trust, not otherwise specified</remarks>
        [XmlEnum("58")]
        OLI_TRUST_CHARITY = 58,

        /// <summary>Employer-Sponsored Trust</summary>
        /// <remarks>Employer-Sponsored Trust, not otherwise specified</remarks>
        [XmlEnum("59")]
        OLI_TRUST_EMPSPON = 59,

        /// <summary>Juristic Person Beneficiary</summary>
        [XmlEnum("101")]
        OLI_TRUST_JURISTICBENE = 101,

        /// <summary>Individual Person Beneficiary</summary>
        [XmlEnum("102")]
        OLI_TRUST_INDBENE = 102,

        /// <summary>Non-Grantor Trust</summary>
        /// <remarks>Non-Grantor Trust owners for annuities, use the tax identification number (TIN) of the trust. All tax reporting goes to the Non Grantor trust using the trust TIN. If the trust does not meet the requirements for tax deferral, an IRS Form 1099-INT is issues</remarks>
        [XmlEnum("103")]
        OLI_TRUST_NONGRANTOR = 103,

        /// <summary>Informal Trust</summary>
        /// <remarks>Informal Trust</remarks>
        [XmlEnum("105")]
        OLI_TRUST_INFORMAL = 105,

        /// <summary>Intervivos Trust</summary>
        /// <remarks>Intervivos Trust</remarks>
        [XmlEnum("109")]
        OLI_TRUST_INTERVIVOS = 109,

        /// <summary>Individual Trust</summary>
        /// <remarks>Individual Trust</remarks>
        [XmlEnum("110")]
        OLI_TRUST_INDIVIDUAL = 110,

        /// <summary>Family Trust</summary>
        /// <remarks>A trust established for the purpose of passing assets to children or other heirs rather than to a surviving spouse.</remarks>
        [XmlEnum("111")]
        OLI_TRUST_FAMILY = 111,

        /// <summary>Buy-Sell Trust</summary>
        /// <remarks>Buy-Sell Trust</remarks>
        [XmlEnum("112")]
        OLI_TRUST_BUYSELL = 112,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
