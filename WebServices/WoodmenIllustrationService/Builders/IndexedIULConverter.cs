using System;
using WoodmenLife.Enterprise.Illustration.Models.Titanium;
using log4net;
using WOW.Illustration.Model.Enums;
using WOW.Illustration.Model.Generation.Request;
using WOW.WoodmenIllustrationService.Code;
using WOW.WoodmenIllustrationService.Exceptions;
using WOW.WoodmenIllustrationService.LookupBuilders;

namespace WOW.WoodmenIllustrationService.Builders
{
	public class IndexedUniversalLifePolicyConverter : CommonPolicyConverter
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(IndexedUniversalLifePolicyConverter));

		private IndexedUniversalLifePolicy _policy;

		private TiPolicyDetail _request;

		private IULLookups _iULLookups = new IULLookups();

		private const string DEATH_BENEFIT_OPTION_LEVEL_DB_FACE = "Level (DB = Face)";
		private const string DEATH_BENEFIT_OPTION_INCREASING_DB_FACE_CASH = "Increasing (DB = Face + Cash)";

		public IndexedUniversalLifePolicyConverter(TiPolicyDetail request)
		{
			_request = request;
			base.Request = request;

			_policy = new IndexedUniversalLifePolicy();
			base.Policy = _policy;
		}

		public static IndexedUniversalLifePolicyConverter CreateConverter(TiPolicyDetail request)
		{
			if (log.IsInfoEnabled)
				log.Info($"CreateConverter called.");

			try
			{
				IndexedUniversalLifePolicyConverter iulConverter = new IndexedUniversalLifePolicyConverter(request);
				return iulConverter;
			}
			catch (Exception ex) when (!(ex is PolicyConverterException))
			{
				throw new PolicyConverterException("Exception while creating the Index UniversalLify Policy Converter", ex);
			}
		}

		protected override void HydratePolicySpecificData()
		{
			if (log.IsInfoEnabled)
				log.Info("HydratePolicySpecificData called.");

			FundHelper fundHelper = new FundHelper();

			switch (_request.PlanId.ToUpper())
			{
			case "TUINDEXC":
			case "TUINDEXN":
			case "TUINDEXT":
			case "TUINDEXP":
			case "TUINDEXR":
			case "TUINDEXU":
				_policy.HeaderCode = 123;
				break;
			default:
				throw new PolicyConverterException($"Invalid PlanId: {_request.PlanId} for ProductTypeCode: {_request.ProductType.Code}.");
			}

			_policy.CategoryCode = 3; // UniversalLife = 3
			_policy.ConceptCode = 5; // (1 means New Business, 5 means Inforce)

			// ClassCode is not used by the WIS
			_policy.ClassType = _iULLookups.ConvertClass(Request.PlanId);

			if (!string.IsNullOrEmpty(Request.ProposedChanges?.ProposedBillingChange?.BillingModeCode))
			{
				_policy.OldBillType = _iULLookups.ConvertBillType(Request.Billing.Method?.Code);
				_policy.BillType = _iULLookups.ConvertBillType(Request.ProposedChanges.ProposedBillingChange.BillingMethodCode);
			}
			else
			{
				_policy.BillType = _iULLookups.ConvertBillType(Request.Billing.Method?.Code);
			}

			_policy.SurrenderCharge = _request.SurrenderChargeAmount;

			_policy.CumulativePremium = _request.PremiumReceivedItdAmount;

			_policy.CumulativeNoLapsePremium = _request.CumulativeMinimumPremiumAmount ?? 0;

			var max7PayAmountAvailable = PolicyDetailsHelper.GetMax7PayAmountAvailable(_request);
			var remainingPlannedPremiumBeforeNextAnniversary = PolicyDetailsHelper.GetRemainingPlannedPremiumBeforeNextAnniversary(_request, _request.ProposedChanges?.ProposedBillingChange?.AdditionalPremiumAmount ?? 0);

			var isRemainingPremiumWithinMecLimit = remainingPlannedPremiumBeforeNextAnniversary <= max7PayAmountAvailable;

			//var isModifiedEndowmentContract = _request.MecIndicator || (_request.MecAllowedIndicator && !_request.MecIndicator && isRemainingPremiumWithinMecLimit);

			var isModifiedEndowmentContract = _request.MecIndicator;

			_policy.IsModifiedEndowmentContract = isModifiedEndowmentContract;			

			_policy.IsTAMRAApplicable = _request.PremiumDepositFundAmount > 0;

			_policy.Guideline7Pay = Request.SevenPayPremiumAmount;

			_policy.Guideline7PayPremium = (isModifiedEndowmentContract) ? 0 : Request.PremiumReceivedItdAmount - Request.Exchange1035Amount;

			_policy.BaseCashValue = _request.CashValueAmount;

			_policy.IndexedAccountValue = fundHelper.GetIndexedFund(_request.Investment).FundValueAmount;

			_policy.FixedAccountValue = fundHelper.GetFixedFund(_request.Investment).FundValueAmount;

			_policy.WLPDFB = _request.PremiumDepositFundAmount;

			_policy.PremiumDepositFundBalanceWithInterest = _request.PremiumDepositFundAmount + _request.PremiumDepositFundInterestAmount;

			_policy.PremiumDepositFundInterestRate = _request.PremiumDepositFundInterestRate;

		}

		protected virtual void HydrateNonLevelData()
		{
			if (log.IsInfoEnabled)
				log.Info($"HydrateNonLevelData called.");

			CoverageHelper coverageHelper = new CoverageHelper();
			Coverage baseCoverage = coverageHelper.GetBaseCoverage(Request.Coverages);
			CommonLookups commonLookups = new CommonLookups();
			ClientHelper clientHelper = new ClientHelper();

			Client primaryClient = clientHelper.GetPrimaryClient(Request.PolicyClients, Request.Clients);

			int currentAge = commonLookups.CalculateAge(primaryClient.BirthDate ?? DateTime.Now, DateTime.Today);
			int attainedAge = commonLookups.CalculateAttainedAge(primaryClient.BirthDate ?? DateTime.Now, Request.IssueDate ?? DateTime.Now, baseCoverage.IssueAge);

			// FaceAmount
			var nld1 = new NonLevelData
			{
				DataTypeCode = DataType.CoverageBenefit,
				Level = 1
			};
			nld1.Codes.Add(1);
			nld1.Codes.Add(0);
			nld1.Codes.Add(0);
			nld1.Codes.Add(0);

			if (Request.ProposedChanges?.ProposedFaceAmountChange != null)
			{
				if (Request.ProposedChanges.ProposedFaceAmountChange.StartAge > currentAge)
				{
					nld1.Amounts.Add(Request.FaceAmount);
					nld1.Amounts.Add(0);
					nld1.Age = Request.ProposedChanges.ProposedFaceAmountChange.StartAge ?? 0;
				}
				else
				{
					nld1.Amounts.Add(Request.FaceAmount + Request.ProposedChanges.ProposedFaceAmountChange.DeltaFaceAmount ?? 0);
					nld1.Amounts.Add(0);
					nld1.Age = 121;
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

					//If issued as Youth policy and changes proposed past youth age change the class to Standard Non - Tobacco
					if (_policy.IssueAge <= 17 && Request.ProposedChanges.ProposedFaceAmountChange.StartAge > 17 && _request.PlanId.ToUpper().Equals("TUINDEXC"))
					{
						_policy.NewClassType = _iULLookups.ConvertClass("TUINDEXN");
					}
				}
			}
			else
			{
				nld1.Amounts.Add(Request.FaceAmount);
				nld1.Amounts.Add(0);
				nld1.Age = 121; // 121 for UL
			}

			_policy.NonLevelData.Add(nld1);

			if (Request.ProposedChanges?.ProposedFaceAmountChange != null)
			{
				if (Request.ProposedChanges.ProposedFaceAmountChange.StartAge > currentAge)
				{
					nld1 = new NonLevelData
					{
						DataTypeCode = DataType.CoverageBenefit,
						Level = 2
					};
					nld1.Codes.Add(1);
					nld1.Codes.Add(0);
					nld1.Codes.Add(0);
					nld1.Codes.Add(0);
					// NLRates in the FIP were not implemented in WIM
					nld1.Amounts.Add(Request.FaceAmount + Request.ProposedChanges.ProposedFaceAmountChange.DeltaFaceAmount ?? 0);
					nld1.Amounts.Add(0);
					// NLGradePct in the FIP was not implemented in WIM
					nld1.Age = 121; // 121 for UL
					_policy.NonLevelData.Add(nld1);
				}
			}

			// BillingModeCode
			var nld2 = new NonLevelData
			{
				DataTypeCode = DataType.PaymentSchedule,
				Level = 1
			};
			nld2.Codes.Add(1);

			if (!string.IsNullOrEmpty(Request.ProposedChanges?.ProposedBillingChange?.BillingModeCode))
			{
				_policy.OldPremiumMode = _iULLookups.ConvertBillingMode(Request.Billing.Mode.Code);
				nld2.Codes.Add(_iULLookups.ConvertBillingMode(Request.ProposedChanges.ProposedBillingChange.BillingModeCode));

				if (nld2.Age != Request.ProposedChanges.ProposedBillingChange.ThroughAge)
				{ nld2.Age = (int)Request.ProposedChanges.ProposedBillingChange.ThroughAge; }
			}
			else
			{
				nld2.Codes.Add(_iULLookups.ConvertBillingMode(Request.Billing.Mode.Code));
				nld2.Age = 121; // 121 for UL
			}
			nld2.Codes.Add(0);
			nld2.Codes.Add(0);
			// NLRates in the FIP were not implemented in WIM

			_policy.ModalPremium = Request.Billing.Amount;
			if (Request.ProposedChanges?.ProposedBillingChange != null && Request.ProposedChanges?.ProposedBillingChange.BillingAmount != null)
			{
				nld2.Amounts.Add((decimal)Request.ProposedChanges.ProposedBillingChange.BillingAmount);
				if (nld2.Age != Request.ProposedChanges.ProposedBillingChange.ThroughAge)
				{ nld2.Age = (int)Request.ProposedChanges.ProposedBillingChange.ThroughAge; }
			}
			else
			{
				nld2.Amounts.Add(Request.Billing.Amount);
				nld2.Age = 121; // 121 for UL
			}
			nld2.Amounts.Add(0);
			int maturationAge = nld2.Age;
			// NLGradePct in the FIP was not implemented in WIM

			_policy.NonLevelData.Add(nld2);

			nld2 = new NonLevelData
			{
				DataTypeCode = DataType.PaymentSchedule,
				Level = 2
			};

			nld2.Codes.Add(1);
			nld2.Codes.Add(1);
			nld2.Codes.Add(0);
			nld2.Codes.Add(0);
			// NLRates in the FIP were not implemented in WIM
			nld2.Amounts.Add(0);
			nld2.Amounts.Add(0);
			// NLGradePct in the FIP was not implemented in WIM
			nld2.Age = 121; // 121 for UL
			if (nld2.Age != maturationAge)
			{ nld2.Age = maturationAge; }

			_policy.NonLevelData.Add(nld2);

			if (Request.ProposedChanges?.ProposedPartialSurrenders != null)
			{
				var surrenderLevel = 0;
				foreach (var surrender in Request.ProposedChanges.ProposedPartialSurrenders)
				{
					var nldSurrenderFrom = new NonLevelData();
					nldSurrenderFrom.DataTypeCode = DataType.PartialSurrender;
					nldSurrenderFrom.Level = ++surrenderLevel;
					nldSurrenderFrom.Codes.Add(1);
					nldSurrenderFrom.Codes.Add(0);
					nldSurrenderFrom.Codes.Add(0);
					nldSurrenderFrom.Codes.Add(0);
					nldSurrenderFrom.Amounts.Add(0);
					nldSurrenderFrom.Amounts.Add(0);
					nldSurrenderFrom.Age = surrender.StartAge ?? 0;

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
					DataTypeCode = DataType.PartialSurrender,
					Level = ++surrenderLevel
				};

				nldSurrenderMax.Codes.Add(1);
				nldSurrenderMax.Codes.Add(0);
				nldSurrenderMax.Codes.Add(0);
				nldSurrenderMax.Codes.Add(0);
				nldSurrenderMax.Amounts.Add(0);
				nldSurrenderMax.Amounts.Add(0);
				nldSurrenderMax.Age = 121;

				_policy.NonLevelData.Add(nldSurrenderMax);
			}

			if (!string.IsNullOrEmpty(baseCoverage.DeathBenefitOption.Code))
			{
				// DeathBenefitOptionCode
				var nld6 = new NonLevelData
				{
					DataTypeCode = DataType.DeathBenefit,
					Level = 1
				};

				// Map LEVEL to 1 (includes) and INCR to 2 (excludes)
				nld6.Codes.Add(baseCoverage.DeathBenefitOption.Code.Equals("LEVEL", StringComparison.InvariantCultureIgnoreCase) ? 1 : 2);
				nld6.Codes.Add(0);
				nld6.Codes.Add(0);
				nld6.Codes.Add(0);
				// NLRates in the FIP were not implemented in WIM
				nld6.Amounts.Add(0);
				nld6.Amounts.Add(0);
				// NLGradePct in the FIP was not implemented in WIM
				nld6.Age = 121; // 121 for UL
				_policy.NonLevelData.Add(nld6);
			}

			if (Request.ProposedChanges?.ProposedBillingChange != null && Request.ProposedChanges?.ProposedBillingChange?.AdditionalPremiumAmount != 0)
			{
				// Request.InitialPremium  NLD #8
				var nld8level1 = new NonLevelData
				{
					DataTypeCode = DataType.LumpSum,
					Level = 1
				};

				nld8level1.Codes.Add(1);
				nld8level1.Codes.Add(0);
				nld8level1.Codes.Add(0);
				nld8level1.Codes.Add(0);
				// NLRates in the FIP were not implemented in WIM
				nld8level1.Amounts.Add((decimal)Request.ProposedChanges.ProposedBillingChange.AdditionalPremiumAmount);
				nld8level1.Amounts.Add(0);
				// NLGradePct in the FIP was not implemented in WIM
				nld8level1.Age = attainedAge + 1;
				_policy.NonLevelData.Add(nld8level1);

				var nld8level2 = new NonLevelData
				{
					DataTypeCode = DataType.LumpSum,
					Level = 2
				};

				nld8level2.Codes.Add(1);
				nld8level2.Codes.Add(0);
				nld8level2.Codes.Add(0);
				nld8level2.Codes.Add(0);
				// NLRates in the FIP were not implemented in WIM
				nld8level2.Amounts.Add(0);
				nld8level2.Amounts.Add(0);
				// NLGradePct in the FIP was not implemented in WIM
				nld8level2.Age = 121;
				_policy.NonLevelData.Add(nld8level2);
			}
		}

		protected void HydrateFundData()
		{
			if (_request.Investment.SubAccounts.Count != 2)
			{
				throw new PolicyConverterException("IUL request requires 2 Fund Accounts.");
			}

			foreach (var fund in _request.Investment.SubAccounts)
			{
				var subAccount = new Illustration.Model.Generation.Request.SubAccount();

				subAccount.ProductCode = _iULLookups.ConvertFundAccount(fund.FundAccountId);
				subAccount.AllocPercent = fund.FundAllocationPercent;

				_policy.SubAccounts.Add(subAccount);
			}

		}

		protected virtual void HydrateReportData()
		{
			if (log.IsInfoEnabled)
				log.Info("HydrateReportData called.");

			// Level and includeGraph were not implemented in the WIM
			var report = new Report
			{
				Code = ReportType.NarrativeSummaryBase,
				InterestRate = 0,
				SalesCharge = 0,
				TermRates = 0
			};
			_policy.Reports.Add(report);

			if (_policy.SignedState.ToUpper() == "TX")
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
			if (log.IsInfoEnabled)
				log.Info("HydrateNonLevelPolicyData called.");

			CommonLookups commonLookups = new CommonLookups();
			ClientHelper clientHelper = new ClientHelper();

			Client primaryClient = clientHelper.GetPrimaryClient(Request.PolicyClients, Request.Clients);

			int currentAge = commonLookups.CalculateAge(primaryClient.BirthDate ?? DateTime.Now, DateTime.Today);
			decimal amountAccumulator = 0;
			int deathBenefitOption = 0;
			
			foreach (var coverage in Request.Coverages)
			{
				if (coverage.CoverageDecreases != null && coverage.CoverageDecreases.Count > 0)
				{
					amountAccumulator = coverage.FaceAmount;

					foreach (var decrease in coverage.CoverageDecreases)
					{
						amountAccumulator += decrease.CoverageDecreaseAmount.Value;
					}

					deathBenefitOption = (coverage.DeathBenefitOption?.Description ?? DEATH_BENEFIT_OPTION_LEVEL_DB_FACE) == DEATH_BENEFIT_OPTION_LEVEL_DB_FACE ? 1 : 2;

					var nlpd = new NonLevelPolicyData
					{
						EffectiveDate = coverage.EffectiveDate ?? coverage.IssueDate.Value
					};

					nlpd.NonLevelAmounts.Add(amountAccumulator);
					nlpd.NonLevelAmounts.Add(deathBenefitOption);

					nlpd.NonLevelAmounts.Add(0);
					nlpd.NonLevelAmounts.Add(0);
					nlpd.NonLevelAmounts.Add(0);
					nlpd.NonLevelAmounts.Add(0);

					_policy.NonLevelPolicyData.Add(nlpd);					

					foreach (var decrease in coverage.CoverageDecreases)
					{
						deathBenefitOption = (coverage.DeathBenefitOption?.Description ?? DEATH_BENEFIT_OPTION_LEVEL_DB_FACE) == DEATH_BENEFIT_OPTION_LEVEL_DB_FACE ? 1 : 2;
												
						nlpd = new NonLevelPolicyData
						{
							EffectiveDate = decrease.CoverageDecreaseDate.Value
						};

						amountAccumulator -= decrease.CoverageDecreaseAmount.Value;

						nlpd.NonLevelAmounts.Add(amountAccumulator);	
						nlpd.NonLevelAmounts.Add(deathBenefitOption);

						nlpd.NonLevelAmounts.Add(0);
						nlpd.NonLevelAmounts.Add(0);
						nlpd.NonLevelAmounts.Add(0);
						nlpd.NonLevelAmounts.Add(0);

						_policy.NonLevelPolicyData.Add(nlpd);
					}
				}
				else
				{
					amountAccumulator += coverage.FaceAmount;

					deathBenefitOption = (coverage.DeathBenefitOption?.Description ?? DEATH_BENEFIT_OPTION_LEVEL_DB_FACE) == DEATH_BENEFIT_OPTION_LEVEL_DB_FACE ? 1 : 2;

					var nlpd = new NonLevelPolicyData
					{
						EffectiveDate = coverage.EffectiveDate ?? coverage.IssueDate.Value
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
		}

		public new Policy HydratePolicyData()
		{
			if (log.IsInfoEnabled)
				log.Info("HydratePolicyData called.");

			base.HydratePolicyData();
			HydratePolicySpecificData();
			HydrateNonLevelData();
			HydrateNonLevelPolicyData();
			HydrateFundData();
			HydrateReportData();
			return Policy;
		}

	}
}