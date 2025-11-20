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
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    [XmlRoot("Annuity", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class Annuity_Type
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public OLI_LU_ANNPREM PremType { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public OLI_LU_ANNPAYOUT PayoutType { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public OLI_LU_QUALPLAN QualPlanType { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public decimal InitDepositAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool InitDepositAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public decimal TotalDepositITD { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool TotalDepositITDSpecified { get; set; }

        /// <remarks/>
        [XmlElement("Payout", Order = 5)]
        public Payout_Type[] Payout { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", typeof(AcordAnnuityExtension), Order = 6)]
        public OLifEExtension[] OLifEExtension { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }
    }
}
