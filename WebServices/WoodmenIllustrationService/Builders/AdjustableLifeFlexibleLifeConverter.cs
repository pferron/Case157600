using System;
using System.Collections.Generic;
using System.Linq;
using WoodmenLife.Enterprise.Illustration.Models.Titanium;
using log4net;
using WOW.Illustration.Model.Enums;
using WOW.Illustration.Model.Generation.Request;
using WOW.WoodmenIllustrationService.Code;
using WOW.WoodmenIllustrationService.Exceptions;
using WOW.WoodmenIllustrationService.LookupBuilders;
using WoodmenLife.Enterprise.Illustration.Models.Enums;
using Microsoft.Ajax.Utilities;

namespace WOW.WoodmenIllustrationService.Builders
{
    public class AdjustableLifeFlexibleLifePolicyConverter : CommonPolicyConverter
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(AdjustableLifeFlexibleLifePolicyConverter));

        private readonly AdjustableLifeFlexibleLifePolicy _policy;

        private readonly TiPolicyDetail _request;

        private readonly ALFLLookups _lookups = new ALFLLookups();

        private const string DEATH_BENEFIT_OPTION_LEVEL_DB_FACE = "Level (DB = Face)";

        private const string DEATH_BENEFIT_OPTION_INCREASING_DB_FACE_CASH = "Increasing (DB = Face + Cash)";

        public AdjustableLifeFlexibleLifePolicyConverter(TiPolicyDetail request)
        {
            _request = request;

            Request = request;

            _policy = new AdjustableLifeFlexibleLifePolicy();

            Policy = _policy;
        }

        public static AdjustableLifeFlexibleLifePolicyConverter CreateConverter(TiPolicyDetail request)
        {
            if (log.IsInfoEnabled) log.Info($"CreateConverter called.");

            try
            {
                AdjustableLifeFlexibleLifePolicyConverter iulConverter = new AdjustableLifeFlexibleLifePolicyConverter(request);

                return iulConverter;
            }
            catch (Exception ex) when (!(ex is PolicyConverterException))
            {
                throw new PolicyConverterException("Exception while creating the Adjustable Life Flexible Life Policy Converter", ex);
            }
        }

        protected override void HydratePolicySpecificData()
        {
            if (log.IsInfoEnabled) log.Info("HydratePolicySpecificData called.");

            FundHelper fundHelper = new FundHelper();
            CoverageHelper coverageHelper = new CoverageHelper();
            CommonLookups commonLookups = new CommonLookups();
            ClientHelper clientHelper = new ClientHelper();
            Client primaryClient = clientHelper.GetPrimaryClient(Request.PolicyClients, Request.Clients);

            switch (_request.PlanId.ToUpper())
            {
                case string x when x.StartsWith("LUAL622"):
                    _policy.HeaderCode = 104;
                    break;
                case string x when x.StartsWith("LUFL626"):
                    _policy.HeaderCode = 105;
                    break;
                case string x when x.StartsWith("LU58AL1"):
                    _policy.HeaderCode = 103;
                    break;
                case string x when x.StartsWith("LU58AL2"):
                    _policy.HeaderCode = 103;
                    break;
                case string x when x.StartsWith("LUAL640"):
                    _policy.HeaderCode = 101;
                    break;
                case string x when x.StartsWith("LUFL630"):
                    _policy.HeaderCode = 102;
                    break;
                case string x when x.StartsWith("LUAL660"):
                    _policy.HeaderCode = 108;
                    break;
                case string x when x.StartsWith("LUFL670"):
                    _policy.HeaderCode = 109;
                    break;
                case string x when x.StartsWith("LUUNIFL"):
                    _policy.HeaderCode = 112;
                    break;
                case string x when x.StartsWith("LRFL630"):
                    _policy.HeaderCode = 106;
                    break;
                case string x when x.StartsWith("LRFL626"):
                    _policy.HeaderCode = 107;
                    break;
                case string x when x.StartsWith("LRFL670"):
                    _policy.HeaderCode = 110;
                    break;
                case string x when x.StartsWith("LRUNIFL"):
                    _policy.HeaderCode = 113;
                    break;
                default:
                    throw new PolicyConverterException($"Invalid PlanId: {_request.PlanId} for ProductTypeCode: {_request.ProductType.Code}.");
            }

            _policy.CategoryCode = 3; // UniversalLife = 3
            _policy.ConceptCode = 5; // (1 means New Business, 5 means Inforce)

            int currentAge = commonLookups.CalculateAge(primaryClient.BirthDate ?? DateTime.Now, DateTime.Today);

            // ClassCode is not used by the WIS            
            if (currentAge < 20 && _policy.IssueAge < 20)
            {
                _policy.NewClassType = 12; //force Other
                _policy.ClassType = _lookups.ConvertClass("N"); //force non-tobacco
            }
            else
            {
                _policy.ClassType = _lookups.ConvertClass(Request.PlanId);
            }

            if (!string.IsNullOrEmpty(Request.ProposedChanges?.ProposedBillingChange?.BillingModeCode))
            {
                _policy.OldBillType = _lookups.ConvertBillType(Request.Billing.Method?.Code);

                _policy.BillType = _lookups.ConvertBillType(Request.ProposedChanges.ProposedBillingChange.BillingMethodCode);
            }
            else
            {
                _policy.BillType = _lookups.ConvertBillType(Request.Billing.Method?.Code);
            }

            if (_request.IssueDate == null)
            {
                _request.IssueDate = _request.EffectiveDate;
            }

            _policy.SurrenderCharge = _request.SurrenderChargeAmount;

            _policy.CumulativePremium = _request.PremiumReceivedItdAmount;

            var max7PayAmountAvailable = PolicyDetailsHelper.GetMax7PayAmountAvailable(_request);

            var remainingPlannedPremiumBeforeNextAnniversary = PolicyDetailsHelper.GetRemainingPlannedPremiumBeforeNextAnniversary(_request, _request.ProposedChanges?.ProposedBillingChange?.AdditionalPremiumAmount ?? 0);

            var isRemainingPremiumWithinMecLimit = remainingPlannedPremiumBeforeNextAnniversary <= max7PayAmountAvailable;

			//var isModifiedEndowmentContract = _request.MecIndicator || (_request.MecAllowedIndicator && !_request.MecIndicator && isRemainingPremiumWithinMecLimit);

			var isModifiedEndowmentContract = _request.MecIndicator;

			_policy.IsModifiedEndowmentContract = isModifiedEndowmentContract;

            _policy.IsTAMRAApplicable = _request.PremiumDepositFundAmount > 0;

            _policy.SevenPayPremStartDate = Request.SevenPayPremiumStartDate;

            _policy.Guideline7Pay = Request.SevenPayPremiumAmount;

            _policy.Guideline7PayPremium = (isModifiedEndowmentContract) ? 0 : Request.PremiumReceivedItdAmount - Request.Exchange1035Amount;

            _policy.BaseCashValue = _request.CashValueAmount;

            //_policy.IndexedAccountValue = fundHelper.GetIndexedFund(_request.Investment).FundValueAmount;

            //_policy.FixedAccountValue = fundHelper.GetFixedFund(_request.Investment).FundValueAmount;

            _policy.WLPDFB = _request.PremiumDepositFundAmount;

            _policy.PremiumDepositFundBalanceWithInterest = _request.PremiumDepositFundAmount + _request.PremiumDepositFundInterestAmount;

            _policy.PremiumDepositFundInterestRate = _request.PremiumDepositFundInterestRate;

            if (!string.IsNullOrEmpty(_request.DividendType.Code))
            {
                _policy.RefundOption = _lookups.GetRefundOption(_request.DividendType.Code);
                _policy.InforceRefundOption = _policy.RefundOption;
                _policy.RefundsOnDepositWithInterest = _request.DividendsOnDepositAmount;

                IEnumerable<DividendHistory> sortedDividendHistory = _request.DividendHistory.OrderByDescending(d => d.DividendDate);
                _policy.RefundAtLastAnniversary = sortedDividendHistory.ToList()[0].DividendAmount;

                if (_policy.RefundOption == 2)
                {
                    decimal paidUpFaceAmount = coverageHelper.GetFaceAmountFromPaidUpAddition(Request.Coverages);
                    if (paidUpFaceAmount != 0)
                    {
                        _policy.FaceAmountInforceFromRefunds = paidUpFaceAmount;
                    }
                    _policy.Tamra7PayPremium = _request.SevenPayPremiumAmount;
                }
            }

            _policy.AdditionalPremiumAmount = _request.ProposedChanges?.ProposedBillingChange?.AdditionalPremiumAmount ?? 0;

            if (_request.ProposedChanges?.ProposedBillingChange?.AdditionalPremiumType == "LumpSumToMaxOut")
            {
                _policy.LumpSumToMaxOut = true;
            }

            if (_request.ProposedChanges?.ProposedBillingChange?.AdditionalPremiumType == "MinimumToEndow")
            {
                _policy.MinimumPremiumToEndow = true;
            }

            if (_request.ProposedChanges?.ProposedRefundOptionChange != null)
            {
                _policy.InforceRefundOption = _policy.RefundOption;
                _policy.RefundOption = _lookups.GetRefundOption(_request.ProposedChanges?.ProposedRefundOptionChange.RefundOptionType.ToString());
            }

            if (_request.ProposedChanges?.ProposedFaceAmountChange?.ReduceFaceAmount == true)
            {
                _policy.ReduceFaceAmount = true;

                //Sets the Premium Outlay to $0.00
                _policy.LumpSumToMaxOut = true;

                //Adds the Adds the Partial Surrender to Clear Debt
                if (_request.LoanBalanceAmount > 0)
                {
                    _policy.PartialSurrenderToClearDebt = true;
                }


                //Set the base coverage AAA DBO code to LEVEL to flip to Includes
                Coverage baseCoverage = coverageHelper.GetBaseCoverage(Request.Coverages);
                baseCoverage.DeathBenefitOption.Code = "LEVEL";
            }

            _policy.PostDEFRAMXCV = _policy.HeaderCode == 103 && //58CSO Only
                                    _request.IssueDate >= new DateTime(1985, 1, 1) &&
                                    _request.Coverages.Any(c => c.DeathBenefitOption?.Code == "INCR") //INCR = Excludes
                ? 1
                : 0;

            if (_request.Status.Code.ToLower() == "waiver")
            {
                _policy.PolicyOnWaiver = true;
            }

            _policy.YTDAccumulatedRefunds = _request.DividendAccumulatedAmount;

            if (_request.ProposedChanges?.ProposedLoanPayoffChange?.LoanPayoffOption == LoanPayoffOptions.DisregardLoanBalance)
            {
                _policy.StandardLoanBalance = 0;

                _policy.LoanInterestAmount = 0;
            }
            else
            {
                _policy.StandardLoanBalance = (decimal)_request.LoanBalanceAmount;

                _policy.LoanInterestAmount = (decimal)_request.LoanInterestDueAmount;
            }

            if (_request.ProposedChanges?.ProposedLoanPayoffChange?.LoanPayoffOption == LoanPayoffOptions.PartialSurrenderToClearDebt)
            {
                _policy.PartialSurrenderToClearDebt = true;
            }


            if (_request.ProposedChanges?.ProposedLoanPayoffChange != null)
            {
                ALFLLookups aLFLookups = new ALFLLookups();
                _policy.ModalizedLoanRepayment = aLFLookups.GetModalLoanPayment(_request);
            }
        }

        protected virtual void HydrateNonLevelData()
        {
            if (log.IsInfoEnabled) log.Info($"HydrateNonLevelData called.");

            CoverageHelper coverageHelper = new CoverageHelper();

            Coverage baseCoverage = coverageHelper.GetBaseCoverage(Request.Coverages);

            CommonLookups commonLookups = new CommonLookups();

            ClientHelper clientHelper = new ClientHelper();

            Client primaryClient = clientHelper.GetPrimaryClient(Request.PolicyClients, Request.Clients);

            ALFLLookups aLFLLookups = new ALFLLookups();

            int currentAge = commonLookups.CalculateAge(primaryClient.BirthDate ?? DateTime.Now, DateTime.Today);
            int attainedAge = commonLookups.CalculateAttainedAge(primaryClient.BirthDate ?? DateTime.Now, Request.IssueDate ?? DateTime.Now, baseCoverage.IssueAge);
            int maturationAge = aLFLLookups.GetMaturationAge(Request.PlanId);
            decimal paidUpFaceAmount = coverageHelper.GetFaceAmountFromPaidUpAddition(Request.Coverages);
            decimal faceAmount = 0;

            _policy.SettlementAge = maturationAge;

            // FaceAmount
            var nld1 = new NonLevelData
            {
                Age = maturationAge,
                DataTypeCode = DataType.CoverageBenefit,
                Level = 1
            };

            if ((_policy.ReduceFaceAmount == true) || (Request.ProposedChanges?.ProposedFaceAmountChange != null && Request.ProposedChanges?.ProposedFaceAmountChange?.LumpSumAmount.GetValueOrDefault() != 0))
            {
                nld1.Codes.Add(10);
            }
            else
            {
                nld1.Codes.Add(1);
            }

            nld1.Codes.Add(0);
            nld1.Codes.Add(0);
            nld1.Codes.Add(0);

            if (Request.ProposedChanges?.ProposedFaceAmountChange != null && Request.ProposedChanges?.ProposedFaceAmountChange?.LumpSumAmount.GetValueOrDefault() != 0)
            {
                faceAmount = 0;
            }
            else
            {
                faceAmount = Request.FaceAmount; //- paidUpFaceAmount;
            }            

            if (Request.ProposedChanges?.ProposedFaceAmountChange != null)
            {
                if (Request.ProposedChanges.ProposedFaceAmountChange.StartAge > currentAge)
                {
                    nld1.Amounts.Add(faceAmount);

                    nld1.Amounts.Add(0);

                    nld1.Age = Request.ProposedChanges.ProposedFaceAmountChange.StartAge ?? 0;
                }
                else
                {
                    nld1.Amounts.Add(faceAmount + Request.ProposedChanges.ProposedFaceAmountChange.DeltaFaceAmount ?? 0);

                    nld1.Amounts.Add(0);
                }

                if (Request.ProposedChanges.ProposedFaceAmountChange.DeltaFaceAmount > 0)
                {
                    if (Request.ProposedChanges.ProposedFaceAmountChange.PermanentTableRatingCode != baseCoverage.PermanentTableRating?.Code)
                    {
                        if (!string.IsNullOrEmpty(Request.ProposedChanges.ProposedFaceAmountChange.PermanentTableRatingCode))
                        {
                            _policy.NewRatingAmount = commonLookups.ConvertRating(Request.ProposedChanges.ProposedFaceAmountChange.PermanentTableRatingCode);
                        }
                        else
                        {
                            _policy.NewRatingAmount = null;
                        }
                    }
                }
            }
            else
            {
                nld1.Amounts.Add(faceAmount);

                nld1.Amounts.Add(0);
            }

            _policy.NonLevelData.Add(nld1);

            if (Request.ProposedChanges?.ProposedFaceAmountChange != null && Request.ProposedChanges.ProposedFaceAmountChange.StartAge > currentAge)
            {
                nld1 = new NonLevelData
                {
                    Age = maturationAge,
                    DataTypeCode = DataType.CoverageBenefit,
                    Level = 2
                };

                nld1.Codes.Add(1);

                nld1.Codes.Add(0);

                nld1.Codes.Add(0);

                nld1.Codes.Add(0);
                // NLRates in the FIP were not implemented in WIM
                nld1.Amounts.Add(faceAmount + Request.ProposedChanges.ProposedFaceAmountChange.DeltaFaceAmount ?? 0);

                nld1.Amounts.Add(0);
                // NLGradePct in the FIP was not implemented in WIM

                _policy.NonLevelData.Add(nld1);
            }

            // BillingModeCode
            var nld2 = new NonLevelData
            {
                Age = (Request.ProposedChanges?.ProposedFutureBillingChange?.FuturePremiumType == FuturePremiumTypes.NewPremium ? (int)Request.ProposedChanges?.ProposedFutureBillingChange.StartAge : maturationAge),
                DataTypeCode = DataType.PaymentSchedule,
                Level = 1
            };

            if (_policy.MinimumPremiumToEndow == true)
            {
                nld2.Codes.Add(5);
            }
            else
            {
                if (_policy.LumpSumToMaxOut == true)
                {
                    nld2.Codes.Add(10);
                }
                else
                {
                    nld2.Codes.Add(1);
                }
            }

            if (!string.IsNullOrEmpty(Request.ProposedChanges?.ProposedBillingChange?.BillingModeCode))
            {
                _policy.OldPremiumMode = _lookups.ConvertBillingMode(Request.Billing.Mode.Code);

                nld2.Codes.Add(_lookups.ConvertBillingMode(Request.ProposedChanges.ProposedBillingChange.BillingModeCode));

                if (Request.ProposedChanges.ProposedBillingChange.ThroughAge != null)
                {
                    if (nld2.Age != Request.ProposedChanges.ProposedBillingChange.ThroughAge) { nld2.Age = (int)Request.ProposedChanges.ProposedBillingChange.ThroughAge; }
                }
            }
            else
            {
                nld2.Codes.Add(_lookups.ConvertBillingMode(Request.Billing.Mode.Code));
            }

            nld2.Codes.Add(0);
            nld2.Codes.Add(0);
            // NLRates in the FIP were not implemented in WIM

            _policy.ModalPremium = Request.Billing.Amount;

            if (Request.ProposedChanges?.ProposedBillingChange != null && Request.ProposedChanges?.ProposedBillingChange.BillingAmount != null)
            {
                nld2.Amounts.Add((decimal)Request.ProposedChanges.ProposedBillingChange.BillingAmount);

                if (Request.ProposedChanges.ProposedBillingChange.ThroughAge != null)
                {
                    if (nld2.Age != Request.ProposedChanges.ProposedBillingChange.ThroughAge) { nld2.Age = (int)Request.ProposedChanges.ProposedBillingChange.ThroughAge; }
                }
            }
            else
            {
                if (Request.ProposedChanges?.ProposedFaceAmountChange != null && Request.ProposedChanges?.ProposedFaceAmountChange?.LumpSumAmount.GetValueOrDefault() != 0)
                {
                    _policy.HasFaceIncreaseToMaxOut = true;
                    nld2.Amounts.Add(0);
                }
                else
                {
                    nld2.Amounts.Add(Request.Billing.Amount);
                }                    
            }

            //if (_policy.LumpSumToMaxOut == true)
            //{
            //    nld2.Age = currentAge + 1;
            //}

            int billingMaturationAge = nld2.Age;
            nld2.Amounts.Add(0);
            // NLGradePct in the FIP was not implemented in WIM

            _policy.NonLevelData.Add(nld2);

            if (Request.ProposedChanges?.ProposedFutureBillingChange?.FuturePremiumType == FuturePremiumTypes.NewPremium)
            {
                billingMaturationAge = maturationAge;
                _policy.HasFuturePremiumChange = true;

                nld2 = new NonLevelData
                {
                    Age = (int)Request.ProposedChanges.ProposedFutureBillingChange.StartAge,
                    ToAge = maturationAge,
                    DataTypeCode = DataType.PaymentSchedule,
                    Level = 2
                };

                if (_policy.LumpSumToMaxOut == true || _policy.MinimumPremiumToEndow == true)
                {
                    nld2.Codes.Add(5);
                }
                else
                {
                    nld2.Codes.Add(1);
                }

                if (!string.IsNullOrEmpty(Request.ProposedChanges?.ProposedBillingChange?.BillingModeCode))
                {
                    nld2.Codes.Add(_lookups.ConvertBillingMode(Request.ProposedChanges.ProposedBillingChange.BillingModeCode));
                }
                else
                {
                    nld2.Codes.Add(_lookups.ConvertBillingMode(Request.Billing.Mode.Code));
                }

                nld2.Codes.Add(0);
                nld2.Codes.Add(0);

                // NLRates in the FIP were not implemented in WIM
                nld2.Amounts.Add((decimal)Request.ProposedChanges.ProposedFutureBillingChange.PremiumAmount);
                nld2.Amounts.Add(0);

                // NLGradePct in the FIP was not implemented in WIM

                _policy.NonLevelData.Add(nld2);
            }
            else
            {
                nld2 = new NonLevelData
                {
                    Age = billingMaturationAge,
                    DataTypeCode = DataType.PaymentSchedule,
                    Level = 2
                };

                if (nld2.Age != billingMaturationAge) { nld2.Age = billingMaturationAge; }

                if (_policy.LumpSumToMaxOut == true || _policy.MinimumPremiumToEndow == true)
                {
                    nld2.Codes.Add(5);
                }
                else
                {
                    nld2.Codes.Add(1);
                }
                nld2.Codes.Add(1);
                nld2.Codes.Add(0);
                nld2.Codes.Add(0);

                // NLRates in the FIP were not implemented in WIM
                nld2.Amounts.Add(0);
                nld2.Amounts.Add(0);

                // NLGradePct in the FIP was not implemented in WIM

                _policy.NonLevelData.Add(nld2);
            }

            if (Request.ProposedChanges?.ProposedPartialSurrenders != null)
            {
                var surrenderLevel = 0;

                foreach (var surrender in Request.ProposedChanges.ProposedPartialSurrenders)
                {
                    var nldSurrenderFrom = new NonLevelData
                    {
                        Age = surrender.StartAge ?? 0,
                        DataTypeCode = DataType.PartialSurrender,
                        Level = ++surrenderLevel
                    };

                    nldSurrenderFrom.Codes.Add(1);
                    nldSurrenderFrom.Codes.Add(0);
                    nldSurrenderFrom.Codes.Add(0);
                    nldSurrenderFrom.Codes.Add(0);
                    nldSurrenderFrom.Amounts.Add(0);
                    nldSurrenderFrom.Amounts.Add(0);

                    var nldSurrenderThrough = new NonLevelData
                    {
                        DataTypeCode = DataType.PartialSurrender,
                        Level = ++surrenderLevel
                    };

                    nldSurrenderThrough.Codes.Add(1);
                    nldSurrenderThrough.Codes.Add(0);
                    nldSurrenderThrough.Codes.Add(0);
                    nldSurrenderThrough.Codes.Add(0);
                    nldSurrenderThrough.Amounts.Add(surrender.GrossWithdrawalAmount ?? 0);
                    nldSurrenderThrough.Amounts.Add(0);

                    nldSurrenderThrough.Age = surrender.ChangeModeCode.Equals("ANNUAL", StringComparison.InvariantCultureIgnoreCase)
                        ? surrender.ThroughAge ?? 0
                        : (surrender.StartAge ?? 0) + 1;

                    _policy.NonLevelData.Add(nldSurrenderFrom);

                    _policy.NonLevelData.Add(nldSurrenderThrough);
                }

                var nldSurrenderMax = new NonLevelData
                {
                    Age = maturationAge,
                    DataTypeCode = DataType.PartialSurrender,
                    Level = ++surrenderLevel
                };

                nldSurrenderMax.Codes.Add(1);
                nldSurrenderMax.Codes.Add(0);
                nldSurrenderMax.Codes.Add(0);
                nldSurrenderMax.Codes.Add(0);
                nldSurrenderMax.Amounts.Add(0);
                nldSurrenderMax.Amounts.Add(0);

                _policy.NonLevelData.Add(nldSurrenderMax);
            }

            if (!string.IsNullOrEmpty(baseCoverage.DeathBenefitOption.Code))
            {
                // DeathBenefitOptionCode
                var nld6 = new NonLevelData
                {
                    Age = maturationAge,
                    DataTypeCode = DataType.DeathBenefit,
                    Level = 1
                };

                // Map LEVEL to 1 (includes) and INCR to 2 (excludes)
                if (Request.ProposedChanges?.ProposedFaceAmountChange != null && Request.ProposedChanges?.ProposedFaceAmountChange?.LumpSumAmount.GetValueOrDefault() != 0)
                {
                    nld6.Codes.Add(1); // Force Level DBO when Face Increase to Max Out
                }
                else
                {
                    nld6.Codes.Add(baseCoverage.DeathBenefitOption.Code.Equals("LEVEL", StringComparison.InvariantCultureIgnoreCase) ? 1 : 2);
                }                    

                nld6.Codes.Add(0);
                nld6.Codes.Add(0);
                nld6.Codes.Add(0);
                // NLRates in the FIP were not implemented in WIM
                nld6.Amounts.Add(0);
                nld6.Amounts.Add(0);
                // NLGradePct in the FIP was not implemented in WIM

                _policy.NonLevelData.Add(nld6);

                if (Request.ProposedChanges?.ProposedDeathBenefitOptionChanges?.Count > 0)
                {
                    _policy.DeathBenefitStartDates = new Dictionary<int, DateTime>();
                    int dboLevel = 2;
                    foreach (var dboChange in Request.ProposedChanges?.ProposedDeathBenefitOptionChanges)
                    {
                        // DeathBenefitOptionCode
                        nld6 = new NonLevelData
                        {
                            Age = maturationAge,
                            DataTypeCode = DataType.DeathBenefit,
                            Level = dboLevel
                        };

                        if (dboChange.StartAge.Value <= currentAge)
                        {							
							dboChange.StartAge = currentAge;														
                        }						

						_policy.DeathBenefitStartDates.Add(dboLevel, _policy.DataDate.AddYears(dboChange.StartAge.Value - currentAge));
                        nld6.Codes.Add(dboChange.DeathBenefitOptionCode.Equals("LEVEL", StringComparison.InvariantCultureIgnoreCase) ? 1 : 2);

                        nld6.Codes.Add(0);
                        nld6.Codes.Add(0);
                        nld6.Codes.Add(0);
                        // NLRates in the FIP were not implemented in WIM
                        nld6.Amounts.Add(0);
                        nld6.Amounts.Add(0);
                        // NLGradePct in the FIP was not implemented in WIM

                        _policy.NonLevelData.Add(nld6);
                        dboLevel++;
                    }
                }

                if ((Request.ProposedChanges?.ProposedBillingChange != null && Request.ProposedChanges?.ProposedBillingChange?.AdditionalPremiumAmount != 0) ||
                    (Request.ProposedChanges?.ProposedFutureBillingChange != null && Request.ProposedChanges?.ProposedFutureBillingChange?.FuturePremiumType == FuturePremiumTypes.AdditionalAmount) ||
                    (Request.ProposedChanges?.ProposedFaceAmountChange!= null && Request.ProposedChanges?.ProposedFaceAmountChange?.LumpSumAmount.GetValueOrDefault() != 0))
                {
                    decimal lumpSumAmount = 0;

                    if (Request.ProposedChanges?.ProposedFaceAmountChange != null && Request.ProposedChanges?.ProposedFaceAmountChange?.LumpSumAmount.GetValueOrDefault() != 0)
                    {
                        lumpSumAmount = (decimal)Request.ProposedChanges.ProposedFaceAmountChange.LumpSumAmount;
                        _policy.FaceIncreaseToMaxOut = true;

                        if (Request.ProposedChanges.ProposedFaceAmountChange.PermanentTableRatingCode != baseCoverage.PermanentTableRating?.Code)
                        {
                            if (!string.IsNullOrEmpty(Request.ProposedChanges.ProposedFaceAmountChange.PermanentTableRatingCode))
                            {
                                _policy.NewRatingAmount = commonLookups.ConvertRating(Request.ProposedChanges.ProposedFaceAmountChange.PermanentTableRatingCode);
                            }                            
                        }
                    }
                    else
                    {
                        lumpSumAmount = (decimal)Request.ProposedChanges.ProposedBillingChange?.AdditionalPremiumAmount;
                    }

                    // Request.InitialPremium  NLD #8
                    var nld8level1 = new NonLevelData
                    {
                        Age = attainedAge + 1,
                        DataTypeCode = DataType.LumpSum,
                        Level = 1
                    };

                    nld8level1.Codes.Add(1);
                    nld8level1.Codes.Add(0);
                    nld8level1.Codes.Add(0);
                    nld8level1.Codes.Add(0);
                    // NLRates in the FIP were not implemented in WIM
                    nld8level1.Amounts.Add(lumpSumAmount);
                    nld8level1.Amounts.Add(0);
                    // NLGradePct in the FIP was not implemented in WIM

                    _policy.NonLevelData.Add(nld8level1);

                    int levelLumpSum = 2;

                    if (Request.ProposedChanges?.ProposedFutureBillingChange != null && Request.ProposedChanges?.ProposedFutureBillingChange?.FuturePremiumType == FuturePremiumTypes.AdditionalAmount)
                    {
                        _policy.HasFutureLumpSum = true;

                        var nld8level2 = new NonLevelData
                        {
                            Age = (int)Request.ProposedChanges.ProposedFutureBillingChange.StartAge,
                            DataTypeCode = DataType.LumpSum,
                            Level = levelLumpSum
                        };

                        nld8level2.Codes.Add(1);
                        nld8level2.Codes.Add(0);
                        nld8level2.Codes.Add(0);
                        nld8level2.Codes.Add(0);
                        // NLRates in the FIP were not implemented in WIM
                        nld8level2.Amounts.Add((decimal)Request.ProposedChanges.ProposedFutureBillingChange.PremiumAmount);
                        nld8level2.Amounts.Add(0);
                        // NLGradePct in the FIP was not implemented in WIM

                        _policy.NonLevelData.Add(nld8level2);

                        levelLumpSum += 1;
                    }

                    var nld8levelMaturation = new NonLevelData
                    {
                        Age = maturationAge,
                        DataTypeCode = DataType.LumpSum,
                        Level = levelLumpSum
                    };

                    nld8levelMaturation.Codes.Add(1);
                    nld8levelMaturation.Codes.Add(0);
                    nld8levelMaturation.Codes.Add(0);
                    nld8levelMaturation.Codes.Add(0);
                    // NLRates in the FIP were not implemented in WIM
                    nld8levelMaturation.Amounts.Add(0);
                    nld8levelMaturation.Amounts.Add(0);
                    // NLGradePct in the FIP was not implemented in WIM

                    _policy.NonLevelData.Add(nld8levelMaturation);
                }
            }
        }

        protected virtual void HydrateReportData()
        {
            if (log.IsInfoEnabled) log.Info("HydrateReportData called.");

            // Level and includeGraph were not implemented in the WIM
            var report = new Report
            {
                Code = ReportType.NarrativeSummaryBase,
                InterestRate = 0,
                SalesCharge = 0,
                TermRates = 0
            };

            _policy.Reports.Add(report);

            if (string.Equals(_policy.SignedState, "TX", StringComparison.OrdinalIgnoreCase))
            {
                report = new Report
                {
                    Code = ReportType.NumericSummaryUL,
                    InterestRate = 0,
                    SalesCharge = 0,
                    TermRates = 0
                };

                _policy.Reports.Add(report);
            }

            report = new Report
            {
                Code = ReportType.TabularDetailUL,
                InterestRate = 0,
                SalesCharge = 0,
                TermRates = 0
            };

            _policy.Reports.Add(report);
        }

        protected virtual void HydrateNonLevelPolicyData()
        {
            if (log.IsInfoEnabled) log.Info("HydrateNonLevelPolicyData called.");

            CoverageHelper coverageHelper = new CoverageHelper();

            CommonLookups commonLookups = new CommonLookups();

            ClientHelper clientHelper = new ClientHelper();

            Client primaryClient = clientHelper.GetPrimaryClient(Request.PolicyClients, Request.Clients);

            int currentAge = commonLookups.CalculateAge(primaryClient.BirthDate ?? DateTime.Now, DateTime.Today);

            decimal paidUpFaceAmount = coverageHelper.GetFaceAmountFromPaidUpAddition(Request.Coverages);

            decimal amountAccumulator = paidUpFaceAmount;

            int deathBenefitOption = 0;

            foreach (var coverage in Request.Coverages)
            {
                if (coverage.CoverageIncreaseClassification?.Code != "PUA")
                {
                    amountAccumulator += coverage.FaceAmount;
                    deathBenefitOption = (coverage.DeathBenefitOption?.Description ?? DEATH_BENEFIT_OPTION_LEVEL_DB_FACE) == DEATH_BENEFIT_OPTION_LEVEL_DB_FACE ? 1 : 2;

                    var nlpd = new NonLevelPolicyData
                    {
                        EffectiveDate = coverage.EffectiveDate ?? coverage.IssueDate.GetValueOrDefault()
                    };

                    nlpd.NonLevelAmounts.Add(amountAccumulator);
                    nlpd.NonLevelAmounts.Add(deathBenefitOption);

                    nlpd.NonLevelAmounts.Add(0);
                    nlpd.NonLevelAmounts.Add(0);
                    nlpd.NonLevelAmounts.Add(0);
                    nlpd.NonLevelAmounts.Add(0);

                    _policy.NonLevelPolicyData.Add(nlpd);
                }
            }

            //if (Request.ProposedChanges?.ProposedFaceAmountChange != null)
            //{
            //    if (Request.ProposedChanges.ProposedFaceAmountChange.StartAge <= currentAge)
            //    {
            //        var nlpd = new NonLevelPolicyData();
            //        nlpd.EffectiveDate = _policy.DataDate; //_policy.IssueDate.AddYears(Request.ProposedChanges.ProposedFaceAmountChange.StartAge - _policy.IssueAge);

            //        nlpd.NonLevelAmounts.Add(amountAccumulator + Request.ProposedChanges.ProposedFaceAmountChange.DeltaFaceAmount);
            //        nlpd.NonLevelAmounts.Add(deathBenefitOption);

            //        nlpd.NonLevelAmounts.Add(0);
            //        nlpd.NonLevelAmounts.Add(0);
            //        nlpd.NonLevelAmounts.Add(0);
            //        nlpd.NonLevelAmounts.Add(0);

            //        _policy.NonLevelPolicyData.Add(nlpd);
            //    }
            //}
        }

        public new Policy HydratePolicyData()
        {
            if (log.IsInfoEnabled) log.Info("HydratePolicyData called.");

            base.HydratePolicyData();

            HydratePolicySpecificData();

            HydrateNonLevelData();

            HydrateNonLevelPolicyData();

            HydrateReportData();

            return Policy;
        }
    }
}