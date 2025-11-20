using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_HOLDTYPE_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Asset/Liability</summary>
        /// <remarks>Represents an asset or liability that is other than an Investment, Policy, or Banking. For example, this could be used to show a yacht as an asset.</remarks>
        [XmlEnum("1")]
        OLI_HOLDTYPE_ASSETLIAB = 1,

        /// <summary>Policy</summary>
        /// <remarks>The Holding contains all of the policy properties that are generic across insurance policy types. A HoldingType can be either a policy or an investment, not both.  If the holding is a policy with investment options, both the policy and investment objects can exist, but the HoldingType will = Policy.</remarks>
        [XmlEnum("2")]
        OLI_HOLDTYPE_POLICY = 2,

        /// <summary>Investment</summary>
        /// <remarks>The Holding contains all of the properties relating to an investment. A HoldingType is typically either a policy or an investment, not both.   If the holding is primarily an investment with optional policy components, both the policy and investment objects can exist and the HoldingType will = Investment.  If the holding is a policy with investment options, both the policy and investment objects can exist, but the HoldingType will = Policy.</remarks>
        [XmlEnum("3")]
        OLI_HOLDTYPE_INVESTMENT = 3,

        /// <summary>Package</summary>
        /// <remarks>A Package Holding is the Holding the unifies all of a single employee's individual insurance coverages, and carries all (generally summary level) information that is consistent across all of the Component Holdings such as Payee, status dates, and relationships to the employer, etc.</remarks>
        [XmlEnum("4")]
        OLI_HOLDTYPE_PACKAGE = 4,

        /// <summary>A policy that contains or is supported by investments i.e. Variable Life</summary>
        [XmlEnum("5")]
        OLI_HOLDTYPE_POLICYINVESTMENT = 5,

        /// <summary>Group Master Contract</summary>
        /// <remarks>The Group Master Contract represents the high level contract between a Carrier and an employer which serves as the basis or context for the set of coverages and products that are available to all of the associated employees.  The Group Master Contract does not define a specific employee's benefits directly, but provides the ability to capture the agreement and the summary level properties of the agreement between the Employer and the Carrier.</remarks>
        [XmlEnum("6")]
        OLI_HOLDTYPE_GROUPMASTER = 6,

        /// <summary>Banking</summary>
        /// <remarks>The Holding contains the banking information (account numbers, account types, pointer to the Party containing the Financial Institution, etc.). For example a CD, Credit Card, or Savings Account.</remarks>
        [XmlEnum("7")]
        OLI_HOLDTYPE_BANKING = 7,

        /// <summary>Mortgage</summary>
        /// <remarks>A loan used to cover the purchase of a property, secured by the property.</remarks>
        [XmlEnum("8")]
        OLI_HOLDTYPE_MORTGAGE = 8,

        /// <summary>Sponsored Benefit Plan Master</summary>
        /// <remarks>The Benefit Sponsor Master contract is a means of identifying Holdings that part of a sponsored plan such as a Single Employer Welfare Benefit Plan. The Master contract is typically a sparsely populated Holding that contains the Plan information. There is usually no product definition for the overall Plan; instead, the product definitions are tied to the individual Holdings that make up the Plan.Benefit Sponsor plans differ from Group plans in that the component Holdings are individually filed and defined. It differs from a Package Holding by virtue of the fact that more than a single employee's Holdings are included in the component Holdings.</remarks>
        [XmlEnum("9")]
        OLI_HOLDTYPE_BENEMASTER = 9,

        /// <summary>Business Loan</summary>
        /// <remarks>A loan taken for business purposes</remarks>
        [XmlEnum("10")]
        OLI_HOLDTYPE_BUSLOAN = 10,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
