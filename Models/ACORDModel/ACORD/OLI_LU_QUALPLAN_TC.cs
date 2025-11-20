using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_QUALPLAN_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Non-Qualified</summary>
        /// <remarks>An individual taxpayer is allowed to contribute after tax contributions (referred to as their cost basis) into a deferred annuity contract.  Any gain/earning on these contributions remain tax deferred until a distribution is taken.  Depending on when the contract was established determines whether cost basis or gain/earnings (ordinary income) is distributed first.  Any distributions taken prior to age 59 1/2 maybe subject to a 10% premature distribution unless an exception under 72(q) is met.</remarks>
        [XmlEnum("1")]
        OLI_QUALPLN_NONE = 1,

        /// <summary>401(k)</summary>
        /// <remarks>An employer sponsored Qualified retirement plan which allows employees to designate a certain percentage of their paycheck to be invested into a deferred annuity contract.  These contributions are reduced from their compensation prior to tax withholding (pre-tax) and remain excludible from taxable income until a distribution is made.  In addition to pre-tax contributions, some plans may allow after tax contributions as well.</remarks>
        [XmlEnum("2")]
        OLI_QUALPLN_401K = 2,

        /// <summary>403(b) - Tax Sheltered Annuity</summary>
        /// <remarks>Referred to as Tax Sheltered Annuities (TSAs) or Tax Deferred Annuities (TDAs).  In order to be eligible for a 403(b) plan the organization must be a tax exempt entity under 501(c) (3) which includes hospitals, social service agencies and public schools.  403(b) allows employees to designate a certain percentage of their paycheck to be invested into a deferred annuity contract.  These contributions are reduced from their compensation prior to tax withholding (pre-tax) and remain excludible from taxable income until a distribution is made.</remarks>
        [XmlEnum("3")]
        OLI_QUALPLN_403B = 3,

        /// <summary>457 Deferred Compensation Plan</summary>
        /// <remarks>457 Deferred Compensation plans, including 457(b) and 457(f) plans</remarks>
        [XmlEnum("4")]
        OLI_QUALPLN_457 = 4,

        /// <summary>IRA - Traditional (408(b))</summary>
        /// <remarks>A tax-deferred retirement account for an individual that permits individuals to set aside up to a pre-determined amount per year, with earnings tax-deferred.    Any amount of the contribution which qualifies as a deductible contribution can be used to reduce some of an individual's taxable income in the year the contribution is made.  If an individual participates in a qualified retirement plan, their annual income will determine the amount of the contribution which can be deemed as a deductible contribution.  The difference between maximum amount allowed by law and the deductible contribution would be deemed a nondeductible contribution.</remarks>
        [XmlEnum("5")]
        OLI_QUALPLN_IRA = 5,

        /// <summary>IRA - Roth</summary>
        /// <remarks>A Roth IRA is an individual retirement account or annuity.  It differs from traditional IRAs in that contributions are after-tax dollars.  The amount of the contribution may be reduced or eliminated depending on the individual's earned income.  If assets remain in the ROTH IRA for five or more years and a qualified distribution is taken the entire amount will not be taxed as ordinary income.</remarks>
        [XmlEnum("6")]
        OLI_QUALPLN_ROTHIRA = 6,

        /// <summary>IRA - Education</summary>
        [XmlEnum("7")]
        OLI_QUALPLN_EDIRA = 7,

        /// <summary>408(k) - SEP</summary>
        /// <remarks>Simplified Employee Pension plan.  Established to make retirement plans more available to employees of small businesses (self employed individuals can also use SEPs).  The employee establishes a retirement account or annuity into which the employer will deposit contributions for the employee.   Employers may establish a SEP because they are easy to administer and reduce the paperwork normally associated with other qualified plans.</remarks>
        [XmlEnum("8")]
        OLI_QUALPLN_SEP = 8,

        /// <summary>RESP (Registered Education Savings Plan)</summary>
        [XmlEnum("9")]
        OLI_QUALPLN_RESP = 9,

        /// <summary>RRSP (Registered Retirement Savings Plan)</summary>
        [XmlEnum("10")]
        OLI_QUALPLN_RRSP = 10,

        /// <summary>RRIF (Registered Retirement Income Fund)</summary>
        [XmlEnum("11")]
        OLI_QUALPLN_RRIF = 11,

        /// <summary>ESOP (Employee Stock Ownership Plan)</summary>
        [XmlEnum("12")]
        OLI_QUALPLN_ESOP = 12,

        /// <summary>H.R. 10</summary>
        [XmlEnum("13")]
        OLI_QUALPLN_HR10 = 13,

        /// <summary>Conforming to State President Regulation</summary>
        [XmlEnum("14")]
        OLI_QUALPLN_CONFPRESREG = 14,

        /// <summary>Nonconforming to State President Regulation</summary>
        [XmlEnum("15")]
        OLI_QUALPLN_NONCONFPRESREG = 15,

        /// <summary>Preservation Fund - Pension</summary>
        [XmlEnum("16")]
        OLI_QUALPLN_FUNDPENSION = 16,

        /// <summary>Preservation Fund - Provident</summary>
        [XmlEnum("17")]
        OLI_QUALPLN_FUNDPROVIDENT = 17,

        /// <summary>Preferred Compensation</summary>
        [XmlEnum("18")]
        OLI_QUALPLN_PREFCOMP = 18,

        /// <summary>Spousal RRSP</summary>
        [XmlEnum("20")]
        OLI_QUALPLN_SPOUSALRRSP = 20,

        /// <summary>LIF - Life Income Fund</summary>
        [XmlEnum("21")]
        OLI_QUALPLN_LIF = 21,

        /// <summary>Spousal RRIF</summary>
        [XmlEnum("22")]
        OLI_QUALPLN_SPOUSALRRIF = 22,

        /// <summary>RRTF</summary>
        /// <remarks>REER Rente a Terme Fixe / Retirement Savings Fixed Term.)</remarks>
        [XmlEnum("23")]
        OLI_QUALPLN_RRTF = 23,

        /// <summary>Registered Home Ownership Savings Plan</summary>
        [XmlEnum("24")]
        OLI_QUALPLN_RHOSP = 24,

        /// <summary>Deferred Profit Sharing Plan</summary>
        [XmlEnum("25")]
        OLI_QUALPLN_DPSP = 25,

        /// <summary>Group Registered Savings Plan</summary>
        [XmlEnum("26")]
        OLI_QUALPLN_GRSP = 26,

        /// <summary>Spousal Group Registered Savings Plan</summary>
        [XmlEnum("27")]
        OLI_QUALPLN_SPOUSALGRSP = 27,

        /// <summary>RESP Family Plan</summary>
        [XmlEnum("28")]
        OLI_QUALPLN_RESPFAMILY = 28,

        /// <summary>IRA - Roth Conversion</summary>
        [XmlEnum("29")]
        OLI_QUALPLN_ROTHCONVIRA = 29,

        /// <summary>S.I.M.P.L.E. Qualified Plan - 408(b)</summary>
        /// <remarks>A qualified IRA Savings Incentive Match Plan for Employees (SIMPLE) whereby employees may save for retirement by deferring salary on a pre-tax basis up to a specified limit based on compensation -- IRS Section 415 Limit is the lesser of 100% of compensation or a specified amount based on tax year, excluding EE deferrals.  Mandatory employer match is 1% to 3% of salary for match or 2% for all.  Loans are not allowed, Hardship Withdrawals are allowed only under special purpose distribution provisions.</remarks>
        [XmlEnum("30")]
        OLI_QUALPLAN_SIMPLE = 30,

        /// <summary>Pension Trust Plan</summary>
        /// <remarks>A Pension Trust allows a trustee (business owner) purchases one contract for each participant. Trustee is listed as owner and beneficiary. We do not do any tax reporting or record keeping for the plan. Only the owner (Trustee) has authorization for changes and information.</remarks>
        [XmlEnum("31")]
        OLI_QUALPLN_PENSTRST = 31,

        /// <summary>VEBA/501(c)(9) Trust</summary>
        /// <remarks>IRC Section 501(c)(3) describes charitable organizations, including churches and religious organizations, which qualify for exemption from Federal income tax and generally are eligible to receive tax-deductible contributions. This section provides that: "An organization must be organized and operated exclusively for religious or other charitable "Net earnings may not inure to the benefit of any private individual or shareholder, "No substantial part of its activity may be attempting to influence legislation, "The organization may not intervene in political campaigns, and "No part of the organization's purposes or activities may be illegal or violate fundamental public policy</remarks>
        [XmlEnum("32")]
        OLI_QUALPLN_VEBATRUST = 32,

        /// <summary>IRA - Spousal</summary>
        /// <remarks>IRA Spousal is an IRA funded by a married taxpayer in the name of his or her spouse who has less than $250 in annual compensation. The couple must file a joint tax return for the year of contribution. The working spouse may contribute up to a specified amount per year to the Spousal IRA and up to a specified amount per year to his or her own IRA.</remarks>
        [XmlEnum("33")]
        OLI_QUALPLN_IRASPOUSAL = 33,

        /// <summary>Defined Contribution</summary>
        /// <remarks>This plan type may also be known as a Cash Balance, Defined Contribution plan.</remarks>
        [XmlEnum("34")]
        OLI_QUALPLN_CASHDEFCONT = 34,

        /// <summary>Defined Benefit</summary>
        /// <remarks>This plan type may also be known as a Cash Balance, Defined Benefit plan.</remarks>
        [XmlEnum("35")]
        OLI_QUALPLN_CASHDEFBEN = 35,

        /// <summary>Target Benefit Plan</summary>
        /// <remarks>A target benefit plan is a cross between a defined benefit plan and a money purchase pension plan. It is similar to a defined benefit plan in that the annual contribution is determined by the amount needed each year to fund the "targeted" benefit at retirement. It is similar to a defined contribution plan in that employer contributions and any investment gains or losses either increase or decrease the benefits allocated to individual participant accounts. The benefit at retirement is based upon the value of the participant's account.</remarks>
        [XmlEnum("36")]
        OLI_QUALPLN_TARGETBEN = 36,

        /// <summary>Foreign National</summary>
        [XmlEnum("37")]
        OLI_QUALPLN_FOREIGN = 37,

        /// <summary>Profit Sharing Plan</summary>
        /// <remarks>This is a type of a defined contribution plan.  The employer makes contributions on behalf of employees based on profits earned or a predetermined amount depending on how the plan is structured.</remarks>
        [XmlEnum("38")]
        OLI_QUALPLN_PROFITSHARING = 38,

        /// <summary>Money Purchase</summary>
        /// <remarks>This is a type of a defined contribution plan.  IRS provides guidelines as to contribution limits and allowable distributions from the plan.  These are employer contribution type of plans.</remarks>
        [XmlEnum("39")]
        OLI_QUALPLN_MONEYPURCH = 39,

        /// <summary>408(k) - SARSEP</summary>
        /// <remarks>408(k) - Salary Reduction Simplified Employee Pension plan is a SEP set up before 1997 that includes a salary reduction arrangement.  Instead of establishing a separate retirement plan, in a SARSEP employers make contributions to their own Individual Retirement Account (IRA) and the IRAs of their employees, subject to certain percentages of pay and dollar limits. An arrangement under which an employer makes contributions to an employee's individual retirement account (IRA), or a self-employed person contributes to his own plan.</remarks>
        [XmlEnum("40")]
        OLI_QUALPLN_SARSEP = 40,

        /// <summary>Texas ORP - Optional Retirement Program</summary>
        /// <remarks>The Optional Retirement Program was created for new full-time Faculty, Professional Librarians and certain Administrators (Code 1000) as an alternative to the Teacher Retirement System of Texas. This program is subject to all applicable provisions of sections 403(b) and 415 of the U.S. Internal Revenue Service Code of 1986 as amended. If you are eligible for this program for the first time you have 90 calendar days from your date of eligibility (usually the date of employment) to enroll in the Optional Retirement Program in lieu of the Teacher Retirement System of Texas. This option to enroll is a one-time, permanent decision, which remains in effect throughout your working career in public education in the State of Texas. If you fail to enroll in the Optional Retirement Program before the expiration of the 90-day enrollment period, you will be automatically and permanently enrolled in the Teacher Retirement System of Texas. Under the Optional Retirement Program you select a company authorized by the University of Texas System. The University reduces your monthly salary by 6.65% before taxes. The State of Texas contributes an amount equivalent to 6.0% of your monthly salary. These funds are deposited into your account with the selected company.</remarks>
        [XmlEnum("41")]
        OLI_QUALPLN_TXORP = 41,

        /// <summary>403(a) - Qualified Employee Annuity Plan</summary>
        /// <remarks>403a A qualified employee annuity plan (section 403(a) plan)</remarks>
        [XmlEnum("42")]
        OLI_QUALPLN_EMPANN = 42,

        /// <summary>Non-transferable Qualified Annuity</summary>
        /// <remarks>A non-transferable annuity, owned by a qualified plan trust. Avoids surrender charges that would be incurred by going to an IRA.</remarks>
        [XmlEnum("43")]
        OLI_QUALPLN_401G = 43,

        /// <summary>401(a)</summary>
        /// <remarks>Type of Qualified plan set up by an employer that meets the conditions of section 401(a) of the IRC.</remarks>
        [XmlEnum("44")]
        OLI_QUALPLN_401A = 44,

        /// <summary>Qualified, type unspecified</summary>
        /// <remarks>The product is qualified, but the plan type is unknown.</remarks>
        [XmlEnum("45")]
        OLI_QUALPLAN_QUAL = 45,

        /// <summary>Governmental</summary>
        /// <remarks>Governmental</remarks>
        [XmlEnum("46")]
        OLI_QUALPLN_GOV = 46,

        /// <summary>501(c)</summary>
        /// <remarks>Non-Profit Tax Deferred Annuity.  Section of the IRC that defines tax exempt organizations.</remarks>
        [XmlEnum("48")]
        OLI_QUALPLN_501 = 48,

        /// <summary>415M</summary>
        /// <remarks>Qualified government excess benefit</remarks>
        [XmlEnum("49")]
        OLI_QUALPLN_415M = 49,

        /// <summary>Keogh / HR10</summary>
        /// <remarks>Keogh plans are tax-deferred retirement savings for people who are self-employed. Also called a HR10.</remarks>
        [XmlEnum("50")]
        OLI_QUALPLN_KEO = 50,

        /// <summary>Prescribed Registered Retirement Income Fund</summary>
        /// <remarks>The contract was sold as a Prescribed Registered Retirement Income Fund in Saskatchewan, Canada.</remarks>
        [XmlEnum("52")]
        OLI_QUALPLN_CANPRIF = 52,

        /// <summary>IRA - Stretch</summary>
        /// <remarks>A "Stretch IRA" is not a plan or a product, it is a method of distributing death benefit proceeds of a qualified IRA.  The concept is that once a contract owner dies, the beneficiary is allowed to continue to defer, "stretch", the death benefit proceeds over a longer period of time rather than having to distribute the entire death benefit proceeds immediately.  This also allows them to spread out any taxable income over a number of years.  There is a minimum amount that a beneficiary must distribute each year in order to avoid a 50% penalty tax.</remarks>
        [XmlEnum("53")]
        OLI_QUALPLN_IRASTR = 53,

        /// <summary>PVT</summary>
        [XmlEnum("54")]
        OLI_LU_QUALPLAN_54 = 54,

        /// <summary>104(a) - Structured Settlement, Subsection Unspecified</summary>
        /// <remarks>A structured settlement complying with the regulations of provision 104(a) of the Internal Revenue Code.</remarks>
        [XmlEnum("61")]
        OLI_QUALPLN_STRUCSTL = 61,

        /// <summary>414(h)</summary>
        /// <remarks>Type of Qualified plan set up by an employer for public employees that meets the conditions of section 414(h) of the IRC.</remarks>
        [XmlEnum("67")]
        OLI_QUALPLN_414H = 67,

        /// <summary>S.I.M.P.L.E. Qualified Plan - 401(k)</summary>
        /// <remarks>A qualified 401(k) Savings Incentive Match Plan for Employees (SIMPLE) whereby employees may save for retirement by deferring salary on a pre-tax basis up to a specified limit based on compensation -- IRS Section 415 Limit is the lesser of 100% of compensation or a specified amount based on tax year. Mandatory employer match is 1% to 3% of salary for match or 2% for all. Loans are allowed; Hardship Withdrawals are allowed.</remarks>
        [XmlEnum("68")]
        OLI_QUALPLAN_SIM401k = 68,

        /// <summary>412(i) Plan</summary>
        /// <remarks>Type of Qualified plan that meets the conditions of section 412(i) of the IRC.</remarks>
        [XmlEnum("69")]
        OLI_QUALPLN_412I = 69,

        /// <summary>419 - Welfare Benefit Plan</summary>
        /// <remarks>Welfare benefit trust (WBT) plans fall under the Voluntary Employee Benefit Association (VEBA) category as covered under Internal Revenue Code Section 501(c)(9). Typically, Section 419A plans are marketed as a severance plan, a death benefit only (DBO) plan, or sometimes both.</remarks>
        [XmlEnum("70")]
        OLI_QUALPLN_419 = 70,

        /// <summary>Roth 401 (k)</summary>
        /// <remarks>Roth 401 (k) combines the features of a Roth individual retirement account with some of the attributes of a traditional 401(k) plan.  Contributions to a Roth-k are made with after-tax dollars and submitted through payroll deduction.  The money in the account grows tax-free and all withdrawals after age 59 ½ are tax-free as long as the account has been open for 5 years. Unlike Roth IRAs, designated Roth contributions are not subject to gross income limitations on being able to make contributions.</remarks>
        [XmlEnum("77")]
        OLI_QUALPLN_ROTH401K = 77,

        /// <summary>Roth 403 (b)</summary>
        /// <remarks>Roth 403 (b) combines the features of a Roth individual retirement account with some of the attributes of a traditional 403(b) plan.  Contributions to a Roth-b are made with after-tax dollars and submitted through payroll deduction.  The money in the account grows tax-free and all withdrawals after age 59 ½ are tax-free as long as the account has been open for 5 years. Unlike Roth IRAs, designated Roth contributions are not subject to gross income limitations on being able to make contributions.</remarks>
        [XmlEnum("78")]
        OLI_QUALPLN_ROTH403B = 78,

        /// <summary>TFSA (Tax Free Savings Account)</summary>
        /// <remarks>TFSA, or CELI in French, is a flexible, registered general-purpose savings vehicle available since January 1st, 2009 that allows Canadians to earn tax-free investment income</remarks>
        [XmlEnum("79")]
        OLI_QUALPLN_TFSA = 79,

        /// <summary>Untaxed policyholder fund</summary>
        /// <remarks>SA specific. Untaxed policyholder fund, in terms of section 29A of the South African Income Tax Act (Four Fund approach)</remarks>
        [XmlEnum("100")]
        OLI_QUALPLN_UNTAXED = 100,

        /// <summary>Individual policyholder fund</summary>
        /// <remarks>SA specific. Individual policyholder fund, in terms of section 29A of the South African Income Tax Act (Four Fund approach)</remarks>
        [XmlEnum("101")]
        OLI_QUALPLN_INDIVIDUAL = 101,

        /// <summary>Company Owned policyholder fund</summary>
        /// <remarks>SA specific. Company policyholder fund, in terms of section 29A of the South African Income Tax Act (Four Fund approach)</remarks>
        [XmlEnum("102")]
        OLI_QUALPLN_CMPOWNED = 102,

        /// <summary>Endowment</summary>
        /// <remarks>An endowment policy is a life insurance contract designed to pay a lump sum after a specified term (on its 'maturity') or on earlier death. There is no tax payable on maturity.</remarks>
        [XmlEnum("105")]
        OLI_QUALPLN_ENDOWMENT = 105,

        /// <summary>Pension Fund</summary>
        /// <remarks>A pension fund is a pool of assets forming an independent legal entity that are bought with the contributions to a pension plan for the exclusive purpose of financing pension plan benefits.</remarks>
        [XmlEnum("106")]
        OLI_QUALPLN_PENSION = 106,

        /// <summary>Provident Fund</summary>
        /// <remarks>A fund for employees to increase their retirement capital with tax advantages for both the employer and employee.</remarks>
        [XmlEnum("107")]
        OLI_QUALPLN_PROVIDENT = 107,

        /// <summary>Variable Retirement Income Fund</summary>
        /// <remarks>Income fund where the amount of income is a percentage of the value of the Fund. This percentage can be varied from 1 year to the next</remarks>
        [XmlEnum("108")]
        OLI_QUALPLN_VARINCOME = 108,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
