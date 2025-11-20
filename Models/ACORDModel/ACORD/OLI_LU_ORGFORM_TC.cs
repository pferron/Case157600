using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_ORGFORM_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Sole Proprietorship</summary>
        /// <remarks>A sole proprietorship is an unincorporated business that is owned by one individual. It is the simplest form of business organization to start and maintain. The business has no existence apart from the owner. Its liabilities are the owner's personal liabilities. He undertakes the risks of the business for all assets owned, whether used in the business or personally owned, and includes the income and expenses of the business on his tax return.</remarks>
        [XmlEnum("1")]
        OLI_ORG_SOLEP = 1,

        /// <summary>Partnership</summary>
        /// <remarks>A partnership is the relationship existing between two or more persons who join to carry on a trade or business. Each person contributes money, property, labor, or skill, and expects to share equally in the profits and losses or liabilities of the business.  The partnership itself does not pay income taxes, but each partner has to report their share of business profits or losses on their individual tax return.</remarks>
        [XmlEnum("2")]
        OLI_ORG_PARTNER = 2,

        /// <summary>Limited Partnership</summary>
        /// <remarks>A business organization with one or more general partners, who manage the business and assume legal debts and obligations, and one or more limited partners, who are liable only to the extent of their investments. Limited partners also enjoy rights to the partnership's cash flow, but are not liable for company obligations.</remarks>
        [XmlEnum("3")]
        OLI_ORG_LTDPART = 3,

        /// <summary>Private Corporation</summary>
        /// <remarks>A company whose shares are not traded on the open market. opposite of public company.  Often referred to as Privately Held.</remarks>
        [XmlEnum("4")]
        OLI_ORG_PRVCORP = 4,

        /// <summary>Public Corporation</summary>
        /// <remarks>A company which has issued securities through an offering, and which are now traded on the open market. also called publicly held or publicly traded.  Opposite of private company.</remarks>
        [XmlEnum("5")]
        OLI_ORG_PUBCORP = 5,

        /// <summary>‘S’ Corporation</summary>
        /// <remarks>A form of corporation, allowed by the IRS for most companies with 75 or fewer shareholders, which enables the company to enjoy the benefits of incorporation but be taxed as if it were a partnership. also called Subchapter S Corporation.</remarks>
        [XmlEnum("6")]
        OLI_ORG_STP = 6,

        /// <summary>Professional Corporation</summary>
        /// <remarks>Corporation which is organized for the purpose of engaging in a learned profession such as law, medicine or architecture. Professional Corporations must file articles of incorporation with the state which meet the state's requirements for professional corporations.</remarks>
        [XmlEnum("7")]
        OLI_ORG_PROCORP = 7,

        /// <summary>Personal Services Corp.</summary>
        /// <remarks>A business whose principal activity is the performance of personal services. The fields of health, law, engineering, architecture, accounting, actuarial sciences, performing arts, and consulting are examples of personal service activities.</remarks>
        [XmlEnum("8")]
        OLI_ORG_PERSERV = 8,

        /// <summary>Government Agency</summary>
        /// <remarks>An administrative unit of government.  Examples include "the Central Intelligence Agency"; "the Census Bureau"; "Office of  Management and Budget"; "Tennessee Valley Authority".</remarks>
        [XmlEnum("9")]
        OLI_ORG_GOVERN = 9,

        /// <summary>Association</summary>
        /// <remarks>A group of individuals who meet for a common purpose.</remarks>
        [XmlEnum("10")]
        OLI_ORG_ASSOC = 10,

        /// <summary>Charitable Organization</summary>
        /// <remarks>A tax-exempt organization recognized by the IRS as a charity.</remarks>
        [XmlEnum("11")]
        OLI_ORG_CHARIT = 11,

        /// <summary>Nonprofit Organization</summary>
        /// <remarks>An incorporated organization which exists for educational or charitable reasons, and from which its shareholders or trustees do not benefit financially. also called not-for-profit organization.</remarks>
        [XmlEnum("12")]
        OLI_ORG_NONPROF = 12,

        /// <summary>‘C’ Corporation</summary>
        /// <remarks>A business which is a completely separate entity from its owners, unlike a partnership.</remarks>
        [XmlEnum("13")]
        OLI_ORG_CTP = 13,

        /// <summary>Limited Liability</summary>
        /// <remarks>LLC (Limited Liability Company). A type of company whose owners and managers receive the limited liability and (usually) tax benefits of an S Corporation without having to conform to the S corporation restrictions.</remarks>
        [XmlEnum("14")]
        OLI_ORG_LTDLIAB = 14,

        /// <summary>Franchise</summary>
        /// <remarks>A form of business organization in which a firm which already has a successful product or service (the franchisor) enters into a continuing contractual relationship with other businesses (franchisees) operating under the franchisor's trade name and usually with the franchisor's guidance, in exchange for a fee.</remarks>
        [XmlEnum("15")]
        OLI_ORG_FRANCHISE = 15,

        /// <summary>Trust</summary>
        /// <remarks>Organization which acts as a fiduciary, trustee or agent for individuals and businesses in the administration of trust funds, estates and custodial arrangements.</remarks>
        [XmlEnum("16")]
        OLI_ORG_TRUST = 16,

        /// <summary>Plan</summary>
        /// <remarks>A Plan is a unique type of legal organization which is similar to (but *is not* the same as) a Trust.  A Plan has specific requirements with regard to the charter and provisions, based on the reason for incorporation (the type of pension plan for which the Plan entity is being established).</remarks>
        [XmlEnum("17")]
        OLI_LU_ORGPLAN = 17,

        /// <summary>Mutual Company</summary>
        /// <remarks>A company whose profits are distributed in proportion to the amount of business each participant does with the company. Examples include federal savings and loan associations, state-chartered mutual savings banks, and mutual insurance companies.</remarks>
        [XmlEnum("18")]
        OLI_ORG_MUTCO = 18,

        /// <summary>Closed Corporation</summary>
        /// <remarks>A corporation in which all of the voting stock is held by a few shareholders, such as management or family members. also called private company.</remarks>
        [XmlEnum("19")]
        OLI_ORG_CLOSECORP = 19,

        /// <summary>Pty. Ltd.</summary>
        [XmlEnum("20")]
        OLI_ORG_PTYLTD = 20,

        /// <summary>Superannuation Fund</summary>
        /// <remarks>A concessionally taxed investment fund for superannuation monies. These funds can accept both ETPs and other contributions. Generally balances cannot be withdrawn until age 55 and fully retired. These can be run by an employer as a company fund, a fund manager as a personal fund or can be self managed by an individual.</remarks>
        [XmlEnum("21")]
        OLI_ORG_SUPERANN = 21,

        /// <summary>Internal</summary>
        [XmlEnum("22")]
        OLI_ORG_INTERNAL = 22,

        /// <summary>Corporation (general)</summary>
        /// <remarks>This is used when nothing is known about the form of corporation, otherwise the correct type should be used</remarks>
        [XmlEnum("23")]
        OLI_ORG_CORPORATION = 23,

        /// <summary>Estate</summary>
        [XmlEnum("24")]
        OLI_ORG_ESTATE = 24,

        /// <summary>Plan Administrator</summary>
        /// <remarks>A plan administrator is the entity or group of entities specified as the administrator by the instrument under which the plan is operated.</remarks>
        [XmlEnum("25")]
        OLI_LU_ORGPLANADM = 25,

        /// <summary>Religious Organization</summary>
        /// <remarks>IRC 501(d) As defined by the Internal Revenue Service, an organization which was organized for the purpose of operating a communal religious community.</remarks>
        [XmlEnum("26")]
        OLI_ORG_RELIGIOUSORG = 26,

        /// <summary>Credit Union</summary>
        [XmlEnum("27")]
        OLI_ORG_CREDITUNION = 27,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
