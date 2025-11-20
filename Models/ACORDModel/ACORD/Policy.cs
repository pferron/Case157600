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
    public partial class Policy
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string PolNumber { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public OLI_LU_LINEBUS LineOfBusiness { get; set; }

        /// <remarks/>
        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "integer", Order = 2)]
        public string PolicyValue { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public OLI_LU_POLPROD ProductType { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public string ProductCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public string CarrierCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public string PlanName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public string ShortName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public OLI_LU_POLSTAT PolicyStatus { get; set; }

        /// <remarks/>
        [XmlElement(Order = 9)]
        public OLI_LU_NATION IssueNation { get; set; }

        /// <remarks/>
        [XmlElement(Order = 10)]
        public OLI_LU_POLISSUE IssueType { get; set; }

        /// <remarks/>
        [XmlElement(Order = 11)]
        public OLI_LU_STATE Jurisdiction { get; set; }

        /// <remarks/>
        [XmlElement(Order = 12)]
        public OLI_LU_TAXSTAT TaxStatus { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 13)]
        public System.DateTime EffDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EffDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 14)]
        public System.DateTime IssueDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool IssueDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 15)]
        public OLI_LU_PAYMODE PaymentMode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 16)]
        public decimal PaymentAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool PaymentAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 17)]
        public OLI_LU_PAYMETHOD PaymentMethod { get; set; }

        /// <remarks/>
        [XmlElement(Order = 18)]
        public string AccountNumber { get; set; }

        /// <remarks/>
        [XmlElement(Order = 19)]
        public string RoutingNumber { get; set; }

        /// <remarks/>
        [XmlElement(Order = 20)]
        public string AcctHolderName { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "gYearMonth", Order = 21)]
        public string CreditCardExpDate { get; set; }

        /// <remarks/>
        [XmlElement(Order = 22)]
        public OLI_LU_CREDCARDTYPE CreditCardType { get; set; }

        /// <remarks/>
        [XmlElement(Order = 23)]
        public OLI_LU_BANKACCTTYPE BankAcctType { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "integer", Order = 24)]
        public string PaymentDraftDay { get; set; }

        /// <remarks/>
        [XmlElement(Order = 25)]
        public string BankName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 26)]
        public decimal MinPremiumInitialAmt { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool MinPremiumInitialAmtSpecified { get; set; }

        /// <remarks/>
        [XmlElement("Annuity", typeof(Annuity_Type), Order = 27)]
        [XmlElement("DisabilityHealth", typeof(DisabilityHealth), Order = 27)]
        [XmlElement("Life", typeof(Life), Order = 27)]
        public object Item { get; set; }

        /// <remarks/>
        [XmlElement(Order = 28)]
        public ApplicationInfo ApplicationInfo { get; set; }

        /// <remarks/>
        [XmlArray(Order = 29)]
        [XmlArrayItem("Payment", typeof(Payment_Type), IsNullable = false)]
        public Payment_Type[] FinancialActivity { get; set; }

        /// <remarks/>
        [XmlElement("KeyedValue", Order = 30)]
        public KeyedValue_Type[] KeyedValue { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", typeof(AcordPolicyExtension), Order = 31)]
        public OLifEExtension[] OLifEExtension { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "IDREF")]
        public string BankID { get; set; }
    }
}
