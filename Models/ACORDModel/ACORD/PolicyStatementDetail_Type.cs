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
    [XmlRoot("PolicyStatementDetail", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class PolicyStatementDetail_Type
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string PolicyStatementDetailName { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 1)]
        public System.DateTime StartDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool StartDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 2)]
        public System.DateTime EndDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EndDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public decimal TotalGrossPremAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool TotalGrossPremAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public decimal TotalNetPremAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool TotalNetPremAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public decimal TotalAmtWthdrwn { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool TotalAmtWthdrwnSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public decimal LoanBalance { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool LoanBalanceSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public decimal TotalLoanAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool TotalLoanAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public decimal TotalLoanPaymentAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool TotalLoanPaymentAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 9)]
        public decimal TotalLoanIntAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool TotalLoanIntAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 10)]
        public decimal TotalAdjustmentAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool TotalAdjustmentAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 11)]
        public decimal PolicyValueAtStartDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool PolicyValueAtStartDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 12)]
        public decimal PolicyValueAtEndDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool PolicyValueAtEndDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 13)]
        public decimal GuarCashValue { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool GuarCashValueSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 14)]
        public decimal FaceAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool FaceAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 15)]
        public decimal DeathBenefitAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool DeathBenefitAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 16)]
        public decimal SurrenderChargeAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool SurrenderChargeAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 17)]
        public decimal CashSurrValue { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool CashSurrValueSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 18)]
        public decimal NetSurrValueAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool NetSurrValueAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 19)]
        public decimal TermDivAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool TermDivAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 20)]
        public decimal TotCumPremAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool TotCumPremAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", typeof(AcordPolicyStatementDetailExtension), Order = 21)]
        public OLifEExtension[] OLifEExtension { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }
    }
}
