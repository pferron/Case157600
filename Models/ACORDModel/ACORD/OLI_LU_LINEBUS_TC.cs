using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_LINEBUS_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Life</summary>
        /// <remarks>When on policy, implies Life object will be used for additional data.</remarks>
        [XmlEnum("1")]
        OLI_LINEBUS_LIFE = 1,

        /// <summary>Annuity</summary>
        /// <remarks>When on policy, implies Annuity object will be used for additional data.</remarks>
        [XmlEnum("2")]
        OLI_LINEBUS_ANNUITY = 2,

        /// <summary>Disability Insurance</summary>
        /// <remarks>When on policy, implies DisabilityHealth object will be used for additional data.</remarks>
        [XmlEnum("3")]
        OLI_LINEBUS_DI = 3,

        /// <summary>Health Insurance</summary>
        /// <remarks>When on policy, implies DisabilityHealth object will be used for additional data.</remarks>
        [XmlEnum("4")]
        OLI_LINEBUS_HEALTH = 4,

        /// <summary>Long Term Care</summary>
        /// <remarks>When on policy, implies DisabilityHealth object will be used for additional data.</remarks>
        [XmlEnum("5")]
        OLI_LINEBUS_LTC = 5,

        /// <summary>Superannuation</summary>
        /// <remarks>When on Policy, implies Life sub-object will be used for additional data.</remarks>
        [XmlEnum("6")]
        OLI_LINEBUS_SUPER = 6,

        /// <summary>Critical Illness</summary>
        /// <remarks>Critical Illness is designed to assist individuals by cover excess expenses (usually beyond what health care or disability insurance would cover) in the event that an individual contracts one of the diseases (usually 5-7 diseases) named in the policy. It usually pays a lump sump upon proof of claim.</remarks>
        [XmlEnum("7")]
        OLI_LINEBUS_CRITICALILL = 7,

        /// <summary>Property and Casualty</summary>
        /// <remarks>Property and Casualty Products - implies PropertyCasualty objectWhen on Policy, implies PropertyCasualty object will be used for additional data</remarks>
        [XmlEnum("8")]
        OLI_LINEBUS_PC = 8,

        /// <summary>Medicare Supplement</summary>
        /// <remarks>When on policy, implies DisabilityHealth object will be used for additional data.</remarks>
        [XmlEnum("9")]
        OLI_LINEBUSS_MEDICARESUPP = 9,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
