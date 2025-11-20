using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_COVINDCODE_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Base</summary>
        [XmlEnum("1")]
        OLI_COVIND_BASE = 1,

        /// <summary>Rider</summary>
        [XmlEnum("2")]
        OLI_COVIND_RIDER = 2,

        /// <summary>Base Increase</summary>
        [XmlEnum("3")]
        OLI_COVIND_BASEINCR = 3,

        /// <summary>Integrated Rider</summary>
        /// <remarks>A rider that is integrated with the base coverage and possibly additional coverages to achieve an optimal blend of coverages.For Universal Life type products, this is normally a term rider with an amount of coverage that decreases as the Universal Life death benefit increases to result in a level "target" death benefit amount.  For level death benefit option, this decrease in term coverage is triggered by a increase Universal Life death benefit due to DEFRA or product-defined corridors.  For increasing death benefit option, this decrease in term coverage is equal to the increasing cash value of the base policy.For traditional products, there are several possible components of "blended insurance".One is where the dividend purchases a combination of one year term and paid up additions so that the total death benefit is equal to the "target" death benefit.  If the term component and/or the paid up additions component are modeled as separate coverages, the coverage indicator code should be "integrated".Another is where the additional term death benefit and paid up addition death benefit are funded by a separate premium.  Again the coverage indicator code should be integrated.  The sum of the base death benefit, term insurance and paid up additions is equal to the "target" death benefit.  If the base policy is participating, the base dividends can also purchase paid up additions which can be factored into the calculation of the rider premium split between term and paid-up additions.  An additional paid up addition rider coverage can also contribute to this blended insurance and  should use the indicator code of "integrated", if its death benefit is included as part of the level target death benefit.  It should use the indicator code of "rider", if its death benefit is in addition to the level target death benefit.For all of these scenarios, the "integrated" term coverage should use a coverage type of "level term" because the term premium decreases as the term coverage and death benefit decreases.  Decreasing term coverage type normally assumes a level premium, along with a decreasing death benefit that is determined using a pre-defined decreasing death benefit pattern.</remarks>
        [XmlEnum("4")]
        OLI_COVIND_INTEGRATED = 4,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
