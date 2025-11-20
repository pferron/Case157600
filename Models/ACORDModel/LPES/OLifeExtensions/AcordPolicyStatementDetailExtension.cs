using System;
using System.Xml.Serialization;
using WOW.Illustration.Model.ACORD;

namespace WOW.Illustration.Model.LPES.OLifeExtensions
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    public class AcordPolicyStatementDetailExtension : OLifEExtension
    {
        [XmlElement("PDFBalance", Order = 1)]
        public decimal PDFBalance { get; set; }

        [XmlIgnore()]
        public bool PDFBalanceSpecified { get { return true; } }

        [XmlElement("AveragePDFBalance", Order = 2)]
        public decimal AveragePDFBalance { get; set; }

        [XmlIgnore()]
        public bool AveragePDFBalanceSpecified { get { return !AveragePDFBalance.Equals(decimal.Zero); } }

        [XmlElement("AverageLoanBalance", Order = 3)]
        public decimal AverageLoanBalance { get; set; }

        [XmlIgnore()]
        public bool AverageLoanBalanceSpecified { get { return !AverageLoanBalance.Equals(decimal.Zero); } }

        [XmlElement("RefundOnDeposit", Order = 4)]
        public decimal RefundOnDeposit { get; set; }

        [XmlIgnore()]
        public bool RefundOnDepositSpecified { get { return !RefundOnDeposit.Equals(decimal.Zero); } }

        [XmlElement("AverageRefundOnDeposit", Order = 5)]
        public decimal AverageRefundOnDeposit { get; set; }

        [XmlIgnore()]
        public bool AverageRefundOnDepositSpecified { get { return !AverageRefundOnDeposit.Equals(decimal.Zero); } }

        [XmlElement("PUAInsurance", Order = 6)]
        public decimal PUAInsurance { get; set; }

        [XmlIgnore()]
        public bool PUAInsuranceSpecified { get { return !PUAInsurance.Equals(decimal.Zero); } }

        [XmlElement("CCVPUAInsurance", Order = 7)]
        public decimal CCVPUAInsurance { get; set; }

        [XmlIgnore()]
        public bool CCVPUAInsuranceSpecified { get { return !CCVPUAInsurance.Equals(decimal.Zero); } }

        [XmlElement("RefundLastAnniversary", Order = 8)]
        public decimal RefundLastAnniversary { get; set; }

        [XmlIgnore()]
        public bool RefundLastAnniversarySpecified { get { return !RefundLastAnniversary.Equals(decimal.Zero); } }

        [XmlElement("BaseCashValue", Order = 9)]
        public decimal BaseCashValue { get; set; }

        [XmlIgnore()]
        public bool BaseCashValueSpecified { get { return !BaseCashValue.Equals(decimal.Zero); } }

        [XmlElement("LoanBalWithInt", Order = 10)]
        public decimal LoanBalanceWithInterest { get; set; }

        [XmlIgnore()]
        public bool LoanBalanceWithInterestSpecified { get { return !LoanBalanceWithInterest.Equals(decimal.Zero); } }

        [XmlElement("PDFBalWithInt", Order = 11)]
        public decimal PremiumDepositFundWithInterest { get; set; }

        [XmlIgnore()]
        public bool PremiumDepositFundWithInterestSpecified { get { return !PremiumDepositFundWithInterest.Equals(decimal.Zero); } }

        [XmlElement("RefDepWithInt", Order = 12)]
        public decimal RefundOnDepositWithInterest { get; set; }

        [XmlIgnore()]
        public bool RefundOnDepositWithInterestSpecified { get { return !RefundOnDepositWithInterest.Equals(decimal.Zero); } }

        [XmlElement("RefDepIntRate", Order = 13)]
        public decimal RefundOnDepositInterestRate { get; set; }

        [XmlIgnore()]
        public bool RefundOnDepositInterestRateSpecified { get { return !RefundOnDepositInterestRate.Equals(decimal.Zero); } }

        [XmlElement("PDFIntRate", Order = 14)]
        public decimal PremiumDepositFundInterestRate { get; set; }

        [XmlElement("CashValueIndexed", Order = 15)]
        public decimal CashValueIndexed { get; set; }

        [XmlElement("CumulativeNoLapsePremium", Order = 16)]
        public decimal CumulativeNoLapsePremium { get; set; }

        [XmlIgnore()]
        public bool PremiumDepositFundInterestRateSpecified { get { return !PremiumDepositFundInterestRate.Equals(decimal.Zero); } }
    }
}
