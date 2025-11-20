using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WOW.Illustration.Model.Generation.Request
{
    /// <summary>
    /// Base class for all Policy Illustration objects
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public abstract class Policy
    {
        public string RequestId { get; set; }

        public int CategoryCode { get; set; }

        public int ConceptCode { get; set; }

        public int HeaderCode { get; set; }

        public int ClassType { get; set; }

        public bool IsRevisedIllustration { get; set; }

        public bool NeedsCostBenefit { get; set; }

        public DateTime SceneModifyDate { get; set; }

        /// <summary>FIP:WOWState, integer value representing the state. Converted to two character abbreviation from FIP data.</summary>
        public string SignedState { get; set; }

        /// <summary>FIP:RtgAmt</summary>
        public int RatingAmount { get; set; }

        /// <summary>FIP:RtgExtra_1</summary>
        public decimal RatingExtra1 { get; set; }

        /// <summary>FIP:RtgExtraToAge_1</summary>
        public int RatingExtraToAge1 { get; set; }

        /// <summary>FIP:Lump1035Amt. For inforce requests, set to 0.</summary>
        public decimal Lump1035Amount { get; set; }

        public int SettlementAge { get; set; }

        public string PolicyNumber { get; set; }

        /// <summary>FIP:belowMinPrem</summary>
        public bool BelowMinimumPremium { get; set; }

        public int NumberOfOwners { get; set; }

        public DateTime IssueDate { get; set; }

        public int IssueAge { get; set; }

        public DateTime DataDate { get; set; }

        public Dictionary<int, DateTime> DeathBenefitStartDates { get; set; }

        /// <summary>For UL inforce illustrations, set to Ending Cash Value. Otherwise, set to 0.</summary>
        public decimal AccountValue { get; set; }

        public decimal SurrenderCharge { get; set; }

        public decimal CumulativePremium { get; set; }

        public decimal CumulativeNoLapsePremium { get;set; }

        public decimal StandardLoanBalance { get; set; }

        public bool IsModifiedEndowmentContract { get; set; }

        public decimal LoanInterestAmount { get; set; }

        public decimal Guideline7Pay { get; set; }

        public decimal Guideline7PayPremium { get; set; }

        public decimal AccumulatedDividends { get; set; }

        /// <summary>Typically set to 0.</summary>
        public decimal AdditionalInsuranceOnDeposit { get; set; }

        public decimal PaidUpAdditionsInsurance { get; set; }

        /// <summary>Typically set to empty string in FIP file. Only present for Legacy illustrations</summary>
        public int StatKind { get; set; }

        public decimal WLPDFB { get; set; }

        /// <summary>Typically set to 0.</summary>
        public decimal RefundAtLastAnniversary { get; set; }

        public decimal AverageLoanBalance { get; set; }

        public decimal AveragePremiumDepositFundBalance { get; set; }

        public decimal AverageRefundsOnDepositBalance { get; set; }

        public decimal CurrentCashValueOfPaidUpInsurance { get; set; }

        /// <summary>For UL, set to ending cash value. Otherwise, set to 0.</summary>
        public decimal BaseCashValue { get; set; }

        public decimal IndexedAccountValue { get; set; }

        public decimal FixedAccountValue { get; set; }

        public decimal LoanBalanceWithInterest { get; set; }

        public decimal PremiumDepositFundBalanceWithInterest { get; set; }

        public decimal RefundsOnDepositWithInterest { get; set; }

        public decimal RefundsOnDepositInterestRate { get; set; }

        public decimal YTDAccumulatedRefunds { get; set; }

        public decimal PremiumDepositFundInterestRate { get; set; }

        // Comes through as 1 or a money amount. Not sure if the 1 is $1.00 or something else.
        public decimal NoLapseGuaranteeAccount { get; set; }

        public decimal TargetPremium { get; set; }

        // Migrated from the annuity level
        /// <summary>FIP:MoneyWithApp for AnData section. Useful for capturing money with all applications.</summary>
        public decimal InitialPremium { get; set; }

        // Migrated from UlData, WlData as it applies to all products
        /// <summary>FIP:FrDues, annualized fraternal dues</summary>
        public decimal FraternalDues { get; set; }

        // Inforce AUL field, if moved down to a more derived class, BaseAcordFactory will need to be adjusted
        public decimal FreeWithdrawal { get; set; }

        public decimal FaceAmountInforceFromRefunds { get; set; }

        public decimal Tamra7PayPremium { get; set; }

        public decimal PostDEFRAMXCV { get; set; }

        public decimal AdditionalPremiumAmount { get; set; }

        public bool? LumpSumToMaxOut { get; set; }

        public bool? HasFutureLumpSum { get;set; }

        public bool? HasFaceIncreaseToMaxOut { get; set; }

        public bool? MinimumPremiumToEndow { get; set; }

        public bool? ReduceFaceAmount { get; set; }

        public bool? FaceIncreaseToMaxOut { get; set; }

        public bool PolicyOnWaiver { get; set; }

        public bool PartialSurrenderToClearDebt { get; set; }

        public DateTime? SevenPayPremStartDate { get; set; }

        public IList<Rider> Riders { get; private set; }

        public IList<NonLevelData> NonLevelData { get; private set; }

        public IList<Report> Reports { get; private set; }

        // Should use 'GeneratePDF = Reports.Count > 0' since PDF generation is determined by whether there are any Report Request elements
        // in the ACORD, but it seemed weird to manually set Generate Values, but not Generate PDF.
        public bool GeneratePdf { get; set; }

        public bool GenerateValuesTextFile { get; set; }

        public AgentPerson Agent { get; set; }

        public ClientPerson Client { get; set; }

        public IList<NonLevelPolicyData> NonLevelPolicyData { get; set; }

        public bool IsInforce { get { return ConceptCode == 5; } }

        protected Policy()
        {
            NonLevelData = new List<NonLevelData>();
            NonLevelPolicyData = new List<NonLevelPolicyData>();
            Reports = new List<Report>();
            Riders = new List<Rider>();
            RequestId = Guid.NewGuid().ToString("D");
        }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };

            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
