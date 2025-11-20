using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_POLPROD_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Whole Life</summary>
        [XmlEnum("1")]
        OLI_PRODTYPE_WL = 1,

        /// <summary>Term</summary>
        [XmlEnum("2")]
        OLI_PRODTYPE_TERM = 2,

        /// <summary>Universal Life</summary>
        [XmlEnum("3")]
        OLI_PRODTYPE_UL = 3,

        /// <summary>Variable Universal Life</summary>
        [XmlEnum("4")]
        OLI_PRODTYPE_VUL = 4,

        /// <summary>Indexed Universal Life</summary>
        [XmlEnum("5")]
        OLI_PRODTYPE_INDXUL = 5,

        /// <summary>Interest Sensitive Whole Life</summary>
        [XmlEnum("6")]
        OLI_PRODTYPE_INTWL = 6,

        /// <summary>Excess Interest Life</summary>
        [XmlEnum("7")]
        OLI_PRODTYPE_EXINTL = 7,

        /// <summary>Variable Whole Life</summary>
        [XmlEnum("8")]
        OLI_PRODTYPE_VWL = 8,

        /// <summary>Fixed Annuity</summary>
        [XmlEnum("9")]
        OLI_PRODTYPE_ANN = 9,

        /// <summary>Variable Annuity</summary>
        [XmlEnum("10")]
        OLI_PRODTYPE_VAR = 10,

        /// <summary>Indexed Annuity</summary>
        [XmlEnum("11")]
        OLI_PRODTYPE_INDX = 11,

        /// <summary>Income Replacement Duration Unspecified</summary>
        [XmlEnum("12")]
        OLI_PRODTYPE_INCREPLC = 12,

        /// <summary>Major Medical</summary>
        [XmlEnum("13")]
        OLI_PRODTYPE_MAJORMED = 13,

        /// <summary>Hospital Indemnity</summary>
        [XmlEnum("14")]
        OLI_PRODTYPE_HOSPINDEM = 14,

        /// <summary>Medicare Supplement</summary>
        [XmlEnum("15")]
        OLI_PRODTYPE_MEDCARE = 15,

        /// <summary>Dread Disease</summary>
        [XmlEnum("16")]
        OLI_PRODTYPE_DISEASE = 16,

        /// <summary>Long Term Care</summary>
        [XmlEnum("17")]
        OLI_PRODTYPE_LTC = 17,

        /// <summary>Nursing Home</summary>
        [XmlEnum("18")]
        OLI_PRODTYPE_NURSE = 18,

        /// <summary>Hospital/Surgical</summary>
        [XmlEnum("19")]
        OLI_PRODTYPE_HOSPSURG = 19,

        /// <summary>Medical Expense</summary>
        [XmlEnum("20")]
        OLI_PRODTYPE_MEDEXP = 20,

        /// <summary>Cancer</summary>
        [XmlEnum("21")]
        OLI_PRODTYPE_CANCER = 21,

        /// <summary>Travel Accident</summary>
        [XmlEnum("22")]
        OLI_PRODTYPE_TRAVACC = 22,

        /// <summary>Overhead Expense</summary>
        [XmlEnum("23")]
        OLI_PRODTYPE_OVREXP = 23,

        /// <summary>Buyout</summary>
        [XmlEnum("24")]
        OLI_PRODTYPE_BUYOUT = 24,

        /// <summary>Accident and Health</summary>
        [XmlEnum("25")]
        OLI_PRODTYPE_ACCHEALTH = 25,

        /// <summary>Term with Cash Value</summary>
        [XmlEnum("26")]
        OLI_PRODTYPE_TERMCV = 26,

        /// <summary>Critical Illness</summary>
        /// <remarks>Critical Illness is designed to assist individuals by cover excess expenses (usually beyond what health care or disability insurance would cover) in the event that an individual contracts one of the diseases (usually 5-7 diseases) named in the policy.  It usually pay a lump sump upon proof of claim.</remarks>
        [XmlEnum("30")]
        OLI_PRODTYPE_CRITICALILL = 30,

        /// <summary>Credit Mortgage</summary>
        [XmlEnum("32")]
        OLI_PRODTYPE_CREDITMORT = 32,

        /// <summary>Open Ended Investment</summary>
        [XmlEnum("33")]
        OLI_PRODTYPE_OPENINVEST = 33,

        /// <summary>Funeral Policy</summary>
        [XmlEnum("35")]
        OLI_PRODTYPE_FUNERAL = 35,

        /// <summary>Guaranteed Insurability Policy</summary>
        [XmlEnum("37")]
        OLI_PRODTYPE_GUARANTEEDINSUABILITY = 37,

        /// <summary>Open ended investment policy for Retirement</summary>
        [XmlEnum("39")]
        OLI_PRODTYPE_OPENDEDRETIREINVESTMENT = 39,

        /// <summary>Errors and Omission Coverage</summary>
        [XmlEnum("40")]
        OLI_PRODTYPE_PC_EO = 40,

        /// <summary>Indeterminate Premium</summary>
        /// <remarks>A type of nonparticipating whole life policy that specifies two premium rates, both a maximum guaranteed premium and a lower premium rate. The insurer charges the lower rate when the policy is purchased and guarantees that rate for at least a stated period of time such as one year, two years, five years, or ten years.</remarks>
        [XmlEnum("41")]
        OLI_PRODTYPE_INDETERPREM = 41,

        /// <summary>Auto</summary>
        /// <remarks>This product type is Automobile insurance.  Which covers insuring a vehicle for loss or repairs after an accident.</remarks>
        [XmlEnum("42")]
        OLI_POLPROD_PC_AUTO = 42,

        /// <summary>Home</summary>
        /// <remarks>A basic home policy covers perils, which are specifically named risks such as lightning, theft, fire, smoke, wind and explosion.</remarks>
        [XmlEnum("43")]
        OLI_POLPROD_PC_HOME = 43,

        /// <summary>Boat</summary>
        /// <remarks>Boat coverage will provide shelter to your boat and protection for you and your passengers.</remarks>
        [XmlEnum("44")]
        OLI_POLPROD_PC_BOAT = 44,

        /// <summary>PELP</summary>
        /// <remarks>Personal Excess Liability Policy, which is an Umbrella coverage policy protecting your assets against lawsuits by providing additional liability coverage.</remarks>
        [XmlEnum("45")]
        OLI_POLPROD_PC_PELP = 45,

        /// <summary>Combo</summary>
        /// <remarks>A combination of various Property and Casualty insurance policies, for example a Home and Auto policy combined into one, or an Auto and Boat, where a partied would share roles on the same policy, for example the driver of the boat and driver of the auto.</remarks>
        [XmlEnum("46")]
        OLI_POLPROD_PC_COMBO = 46,

        /// <summary>Home Health Care</summary>
        /// <remarks>Pays for Long Term Care services of the chronically ill due to incapacitation or cognitive impairment.  Could include: payments for visits by a nurse, aide or therapist; payments for Prescriptions and 
        /// medical supplies and rental of needed items like a wheelchair or hospital bed; payments for personal care services.  May include respite care and adult day care.</remarks>
        [XmlEnum("47")]
        OLI_PRODTYPE_HHC = 47,

        /// <summary>Heart/Stroke</summary>
        /// <remarks>Pays for the treatment of myocardial infarction, stroke, cancer, kidney failure, angioplasty, bypass and organ transplant based on selected amount and is reduced by a set percentage at carrier specified age.</remarks>
        [XmlEnum("48")]
        OLI_PRODTYPE_HEARTSTROKE = 48,

        /// <summary>Intensive Care</summary>
        /// <remarks>Pays a selected dollar amount for Intensive Care Unit (ICU) stays.  This would be a supplement to other insurance providing the same type of benefit.</remarks>
        [XmlEnum("49")]
        OLI_PRODTYPE_INTENSIVECARE = 49,

        /// <summary>Short Term Care</summary>
        /// <remarks>Limited Benefit convalescent care with a maximum lifetime benefit set in the policy.  Could include: payments for Facility Care including a bed reservation; payments for home
        /// care visits by a nurse, aide or therapist; payments for supplies such as a wheelchair or hospital bed and could pay for hospice care and adult day care.</remarks>
        [XmlEnum("50")]
        OLI_PRODTYPE_STC = 50,

        /// <summary>Package - (note: This type code should only be used for the policy object that represents the package details and not the individual policies that make up the package).</summary>
        [XmlEnum("101")]
        OLI_PRODTYPE_PACKAGE = 101,

        /// <summary>Group Superannuation</summary>
        [XmlEnum("201")]
        OLI_PRODTYPE_GRPSUPER = 201,

        /// <summary>Individual Superannuation</summary>
        [XmlEnum("202")]
        OLI_PRODTYPE_INDSUPER = 202,

        /// <summary>Retirement Annuity</summary>
        [XmlEnum("301")]
        OLI_PRODTYPE_RETANN = 301,

        /// <summary>Endowment</summary>
        /// <remarks>Endowment insurance has elements of both term and permanent insurance. Like term insurance, it provides a death benefit if the insured dies within a specified term. Like whole life insurance, it provides a savings element (cash value). An additional feature is that it provides a policy benefit if the insured lives to the end of the endowment period.</remarks>
        [XmlEnum("302")]
        OLI_PRODTYPE_ENDOWMENT = 302,

        /// <summary>Policy pays out an income stream instead of lump sum</summary>
        [XmlEnum("303")]
        OLI_PRODTYPE_INCOMEDEATH = 303,

        /// <summary>Disability Policy that pays only a lump sum</summary>
        [XmlEnum("304")]
        OLI_PRODTYPE_DISABILITYLUMPSUM = 304,

        /// <summary>Accidental death or disability policy</summary>
        [XmlEnum("305")]
        OLI_PRODTYPE_ACCDEATHORDISABILITY = 305,

        /// <summary>Dread Disease and Impairment</summary>
        /// <remarks>This is a base policy that covers the life assured in the event of either contracting a dreaded disease or becoming impaired.</remarks>
        [XmlEnum("306")]
        OLI_PRODTYPE_DREADIMPAIR = 306,

        /// <summary>Preservation Pension Fund</summary>
        /// <remarks>At retirement, a member may take up to one third of the capital as a lump sum. The remaining two thirds must be used to provide a pension for life. Tax is deducted at retirement. A member  can make one taxable ad hoc withdrawal from the fund before retirement.</remarks>
        [XmlEnum("307")]
        OLI_PRODTYPE_PRES_PENFND = 307,

        /// <summary>Preservation Provident Fund</summary>
        /// <remarks>At retirement, a member may take the full proceeds as a lump sum. Member may purchase a Life Annuity with the proceeds or after tax has been deducted, one may also invest the lump sum. A member  can make one taxable ad hoc withdrawal from the fund before retirement.</remarks>
        [XmlEnum("308")]
        OLI_PRODTYPE_PRES_PROVFND = 308,

        /// <summary>Group Master Contract</summary>
        [XmlEnum("400")]
        OLI_PRODTYPE_GROUP_MASTER = 400,

        /// <summary>Experience Group Plan</summary>
        /// <remarks>This is a designation for a group plan covering a specific group of people that Gets rates and benefits based on the experience of the group</remarks>
        [XmlEnum("402")]
        OLI_PRODTYPE_EXPGROUP = 402,

        /// <summary>Disability Income Replacement Short Term</summary>
        [XmlEnum("408")]
        OLI_PRODTYPE_DISINCMREPLST = 408,

        /// <summary>Disability Income Replacement Long Term</summary>
        [XmlEnum("410")]
        OLI_PRODTYPE_DISINCMREPLLT = 410,

        /// <summary>Retrenchment Benefit</summary>
        /// <remarks>An income replacement type benefit should the client become retrenched from his job (unemployed).</remarks>
        [XmlEnum("411")]
        OLI_PRODTYPE_RETRENCH = 411,

        /// <summary>The Sickness and Permanent Incapacity</summary>
        /// <remarks>Sickness: shall mean any disability resulting from disease, injury, accident or other cause or condition, that necessitates medical or dental treatment.“Permanent Incapacity” shall mean that the Policyholder is significantly prevented, due to Sickness, from carrying out his professional duties or other such professional duties as his professional qualifications and experience enable him to carry out and there is little likelihood of him again being fully able to carry out such professional duties and he shall be deemed either totally or partially Permanently Incapacitated accordingly.</remarks>
        [XmlEnum("412")]
        OLI_PRODTYPE_SICKIMPAIR = 412,

        /// <summary>Provident Fund</summary>
        /// <remarks>It is a grouped retirement fund opposed to an individual endowment policy. The tax implication for the proceeds of provident fund and a provident owned endowment policy differs from that of an individual endowment policy</remarks>
        [XmlEnum("413")]
        OLI_PRODTYPE_PROVIDENT = 413,

        /// <summary>Group Pension</summary>
        /// <remarks>It is a grouped retirement fund opposed to a Retirement Annuity which is an individual fund.</remarks>
        [XmlEnum("414")]
        OLI_PRODTYPE_PENSION = 414,

        /// <summary>Life Linked Investment</summary>
        /// <remarks>This is a plan of which the savings element is invested under a LISP (Linked Investment Service Provider) licence in Unit Trusts and Shares that is also subject to Capital Gains Tax in the hands of the investor. However there could also be risk benefits included in this plan that is then sold under the LIFE licence.  It is therefore a combination of LISP savings with LIFE risk benefits that is sold as one product.</remarks>
        [XmlEnum("415")]
        OLI_PRODTYPE_LISP = 415,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
