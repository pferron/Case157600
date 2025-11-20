using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using WOW.Illustration.Model.LPES.OLifeExtensions;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://ACORD.org/Standards/Life/2")]
    [XmlRoot(Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class LifeParticipant
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public OLI_LU_PARTICROLE LifeParticipantRoleCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public double ParticipationPct { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool ParticipationPctSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public OLI_LU_GENDER IssueGender { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public OLI_LU_TOBPREMBASIS TobaccoPremiumBasis { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public OLI_LU_UNWRITECLASS UnderwritingClass { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "integer", Order = 5)]
        public string BeneficiarySeqNum { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public double BeneficiaryPercentDistribution { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool BeneficiaryPercentDistributionSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public OLI_LU_BOOLEAN IrrevokableInd { get; set; }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public OLI_LU_BENEDESIGNATION BeneficiaryDesignation { get; set; }

        /// <remarks/>
        [XmlElement(Order = 9)]
        public OLI_LU_REL BeneficiaryRoleCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 10)]
        public OLI_LU_RELDESC BeneficiaryRoleCodeDesc { get; set; }

        /// <remarks/>
        [XmlElement("SubstandardRating", Order = 11)]
        public SubstandardRating_Type[] SubstandardRating { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", typeof(AcordLifeParticipantExtension), Order = 12)]
        public OLifEExtension[] OLifEExtension { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "IDREF")]
        public string PartyID { get; set; }
    }
}
