using log4net;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using WOW.Illustration.Model.ACORD;
using WOW.Illustration.Model.Generation.Request;
using WOW.Illustration.Model.LPES.Base;
using WOW.Illustration.Model.LPES.OLifeExtensions;
using WOW.WoodmenIllustrationService.Code;
using WOW.WoodmenIllustrationService.Properties;

namespace WOW.WoodmenIllustrationService.Builders
{
    public class UniversalAcordFactory : BaseAcordFactory
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(UniversalAcordFactory));

        internal UniversalAcordFactory()
        {
            //Used to hide the default constructor.
        }

        // There's only one policy in the request
        protected override HOLDING_TYPE[] HydrateHoldingData(WOW.Illustration.Model.Generation.Request.Policy policy)
        {
            if (log.IsInfoEnabled) { log.Info($"HydrateHoldingData called."); }

            // Create list of holdings to satisfy array
            var holdings = new List<HOLDING_TYPE>();

            // Create holding object
            var holding = InitializeHolding(policy);

            // Add to list
            holdings.Add(holding);

            // Set payment mode and method from non-level data item.
            var universalPolicy = (UniversalLifePolicy)policy;

            var dataItem = universalPolicy.NonLevelData.FirstOrDefault(d => d.DataTypeCode == DataType.PaymentSchedule);
            if (dataItem != null)
            {
                holding.Policy.PaymentMode = AcordLookupBuilder.BuildFromWowString<OLI_LU_PAYMODE>(dataItem.Codes[1].ToString(CultureInfo.InvariantCulture));
                holding.Policy.PaymentMethod = AcordLookupBuilder.BuildFromWowString<OLI_LU_PAYMETHOD>(universalPolicy.BillType.ToString(CultureInfo.InvariantCulture));
                holding.Policy.PaymentAmt = (dataItem.Amounts.Any()) ? dataItem.Amounts[0] : 0M;
                holding.Policy.PaymentAmtSpecified = (dataItem.Amounts[0] > 0M);
                holding.Policy.Item = HydrateLifeData(universalPolicy);
            }

            holding.Policy.OLifEExtension = HydratePolicyExtensionData(universalPolicy);

            // Check for inforce and add additional holding
            if (policy.IsInforce)
            {
                // Create inforce holding object
                var inforceHolding = InitializeInforceHolding(policy);
                inforceHolding.Policy.Item = HydrateInforceLifeData(universalPolicy);

                var aulPolicy = universalPolicy as AccumulationUniversalLifePolicy;
                var iulPolicy = universalPolicy as IndexedUniversalLifePolicy;
                var alflPolicy = universalPolicy as AdjustableLifeFlexibleLifePolicy;

                var oldPremiumMode = 0;
                var oldBillType = 0;

                if (aulPolicy != null)
                {
                    //For AUL changes try to use the old codes
                    oldPremiumMode = aulPolicy.OldPremiumMode;
                    oldBillType = aulPolicy.OldBillType;
                }

                if (iulPolicy != null)
                {
                    //For IUL changes try to use the old codes
                    oldPremiumMode = iulPolicy.OldPremiumMode;
                    oldBillType = iulPolicy.OldBillType;
                }

                if (alflPolicy != null)
                {
                    //For IUL changes try to use the old codes
                    oldPremiumMode = alflPolicy.OldPremiumMode;
                    oldBillType = alflPolicy.OldBillType;
                }

                // If not AUL or the old codes not present, then use the current values.  
                if (dataItem != null)
                {
                    if (oldPremiumMode == 0) oldPremiumMode = dataItem.Codes[1];
                }
                else
                {
                    oldPremiumMode = 0;
                }

                if (oldBillType == 0) oldBillType = universalPolicy.BillType;

                inforceHolding.Policy.PaymentMode = AcordLookupBuilder.BuildFromWowString<OLI_LU_PAYMODE>(oldPremiumMode.ToString(CultureInfo.InvariantCulture));
                inforceHolding.Policy.PaymentMethod = AcordLookupBuilder.BuildFromWowString<OLI_LU_PAYMETHOD>(oldBillType.ToString(CultureInfo.InvariantCulture));

                if (alflPolicy != null)
                {
                    inforceHolding.Policy.OLifEExtension = HydrateInforcePolicyRefundExtensionData(universalPolicy);
                }
                else
                {
                    inforceHolding.Policy.OLifEExtension = HydrateInforcePolicyExtensionData(universalPolicy);
                }

                // Add to list
                holdings.Add(inforceHolding);
            }
            else
            {
                holding.Policy.EffDate = policy.SceneModifyDate;
                holding.Policy.EffDateSpecified = holding.Policy.EffDate > DateTime.MinValue;
            }

            if (policy is IndexedUniversalLifePolicy)
            {
                holding.Investment = new Investment_Type();

                var iulPolicy = (IndexedUniversalLifePolicy)policy;

                holding.Investment.SubAccount = HydrateInvestment(iulPolicy);
            }

            return holdings.ToArray();
        }

        private SubAccount_Type[] HydrateInvestment(IndexedUniversalLifePolicy iulPolicy)
        {
            var subAccounts = new List<SubAccount_Type>();

            //For IUL, we know there should be only two account and they must total 100%.
            //We also know that the allocation has to be whole numbers. the vendor and ACORD allow a decimal, but we shouldn't have any fractions

            foreach (var subAccountRqst in iulPolicy.SubAccounts)
            {
                // Since Stone River does not include TC codes we are just going to keep it simple
                // Counter-point, the WIM is tightly coupled to the vendor, so lets use Sapien codes - DAD
                var subAccountType = new SubAccount_Type();

                subAccountType.id = "SubAcct-" + Guid.NewGuid().ToString("N");
                subAccountType.ProductCode = subAccountRqst.ProductCode;
                //subAccountType.ProductFullName = "WoodmenLife IUL - Fixed Account"; not needed
                subAccountType.AllocPercent = subAccountRqst.AllocPercent.ToString("0.0");
                subAccounts.Add(subAccountType);
            }

            return subAccounts.ToArray();
        }

        private Life HydrateLifeData(UniversalLifePolicy policy)
        {
            var life = new Life();

            var dataItem = policy.NonLevelData.FirstOrDefault(d => d.DataTypeCode == DataType.CoverageBenefit);

            if (dataItem == null)
            {
                return null;
            }

            life.InitDepositAmt = policy.InitialPremium;
            life.InitDepositAmtSpecified = (policy.InitialPremium > 0M);
            life.InitialPremAmt = (dataItem != null) ? dataItem.Amounts[0] : 0M;
            life.InitialPremAmtSpecified = (dataItem != null);
            life.Coverage = HydrateCoverageData(policy);
            life.LifeUSA = HydrateLifeUsaData(policy);

            return life;
        }

        private Life HydrateInforceLifeData(UniversalLifePolicy policy)
        {
            var life = new Life();

            life.Coverage = HydrateInforceCoverageData(policy);
            life.LifeUSA = HydrateInforceLifeUsaData(policy);

            return life;
        }

        private Coverage[] HydrateInforceCoverageData(UniversalLifePolicy policy)
        {
            var coverages = new List<Coverage>();

            // Create base coverage for policy
            var baseCoverage = new Coverage();

            // Add coverage to list
            coverages.Add(baseCoverage);

            // Set Coverage ID to 1 since it is base
            baseCoverage.id = "InforceUniversalCoverage1";

            // Set IndicatorCode to base
            baseCoverage.IndicatorCode = AcordLookupBuilder.BuildFromTC<OLI_LU_COVINDCODE>((int)OLI_LU_COVINDCODE_TC.OLI_COVIND_BASE);

            var aulPolicy = policy as AccumulationUniversalLifePolicy;
            if (aulPolicy != null)
            {
                if (aulPolicy.ModalPremium == 0M)
                {
                    //This may not be necessary, but I didn't want to change more than I had to.
                    var dataItem = policy.NonLevelData.FirstOrDefault(d => d.DataTypeCode == DataType.PaymentSchedule);
                    baseCoverage.ModalPremAmt = (dataItem != null) ? dataItem.Amounts[0] : 0M;
                }
                else
                {
                    baseCoverage.ModalPremAmt = aulPolicy.ModalPremium;
                }
            }

            var iulPolicy = policy as IndexedUniversalLifePolicy;
            if (iulPolicy != null)
            {
                if (iulPolicy.ModalPremium == 0M)
                {
                    //This may not be necessary, but I didn't want to change more than I had to.
                    var dataItem = policy.NonLevelData.FirstOrDefault(d => d.DataTypeCode == DataType.PaymentSchedule);
                    baseCoverage.ModalPremAmt = (dataItem != null) ? dataItem.Amounts[0] : 0M;

                    if (iulPolicy.ModalPremium != baseCoverage.ModalPremAmt)
                    {
                        baseCoverage.ModalPremAmt = iulPolicy.ModalPremium;
                    }
                }
                else
                {
                    baseCoverage.ModalPremAmt = iulPolicy.ModalPremium;
                }
            }

            var alflPolicy = policy as AdjustableLifeFlexibleLifePolicy;
            if (alflPolicy != null)
            {
                if (alflPolicy.ModalPremium == 0M)
                {
                    //This may not be necessary, but I didn't want to change more than I had to.
                    var dataItem = policy.NonLevelData.FirstOrDefault(d => d.DataTypeCode == DataType.PaymentSchedule);
                    baseCoverage.ModalPremAmt = (dataItem != null) ? dataItem.Amounts[0] : 0M;

                    if (alflPolicy.ModalPremium != baseCoverage.ModalPremAmt)
                    {
                        baseCoverage.ModalPremAmt = alflPolicy.ModalPremium;
                    }
                }
                else
                {
                    baseCoverage.ModalPremAmt = alflPolicy.ModalPremium;
                }
            }

            baseCoverage.ModalPremAmtSpecified = policy is IndexedUniversalLifePolicy && policy.IsInforce
                ? true
                : (baseCoverage.ModalPremAmt > 0M);

            baseCoverage.ModalPremAmtSpecified = policy is AdjustableLifeFlexibleLifePolicy && policy.IsInforce
                ? true
                : (baseCoverage.ModalPremAmt > 0M);

            baseCoverage.LifeParticipant = HydrateInforceBaseLifeParticipantData(policy);

            // Now that the base coverage is added, we need to generate the related Txns
            if (illustrationRequest.IllustrationTxn == null)
            {
                illustrationRequest.IllustrationTxn = HydrateInforceIllustrationTxns(policy, baseCoverage.id);
            }
            else
            {
                illustrationRequest.IllustrationTxn = illustrationRequest.IllustrationTxn.Concat(HydrateInforceIllustrationTxns(policy, baseCoverage.id)).ToArray();
            }

            return coverages.ToArray();
        }

        private Coverage[] HydrateCoverageData(UniversalLifePolicy policy)
        {
            var coverages = new List<Coverage>();

            // Create base coverage for policy
            var baseCoverage = new Coverage();

            // Add coverage to list
            coverages.Add(baseCoverage);

            // Set Coverage ID to 1 since it is base
            baseCoverage.id = "UniversalCoverage1";

            if (policy.HeaderCode == 0)
            {
                throw new AcordRequestFactoryException(string.Format(CultureInfo.InvariantCulture, "HeaderCode of zero is not expected. Certificate: {0}", policy.PolicyNumber));
            }

            // Lookup LifeCovTypeCode in DB
            baseCoverage.LifeCovTypeCode = AcordLookupBuilder.BuildFromWowString<OLI_LU_COVTYPE>(policy.HeaderCode.ToString(CultureInfo.InvariantCulture));

            // Set IndicatorCode to base
            baseCoverage.IndicatorCode = AcordLookupBuilder.BuildFromTC<OLI_LU_COVINDCODE>((int)OLI_LU_COVINDCODE_TC.OLI_COVIND_BASE);

            // Set coverage or premium amount, depending on face code
            var dataItem1 = policy.NonLevelData.FirstOrDefault(d => d.DataTypeCode == DataType.CoverageBenefit);
            var dataItem2 = policy.NonLevelData.FirstOrDefault(d => d.DataTypeCode == DataType.PaymentSchedule);

            baseCoverage.InitCovAmt = (dataItem1 != null) ? dataItem1.Amounts[0] : 0M;
            baseCoverage.InitCovAmtSpecified = (baseCoverage.InitCovAmt > 0M);

            baseCoverage.ModalPremAmt = (dataItem2 != null) ? dataItem2.Amounts[0] : 0M;
            baseCoverage.ModalPremAmtSpecified = (baseCoverage.ModalPremAmt > 0M);

            DateTime baseDate;
            if (policy.IsInforce)
            {
                baseDate = policy.IssueDate;
            }
            else
            {
                baseDate = policy.SceneModifyDate;
                baseCoverage.EffDate = baseDate;
                baseCoverage.EffDateSpecified = baseDate > DateTime.MinValue;
            }
            baseCoverage.LifeParticipant = HydrateBaseLifeParticipantData(policy, baseDate);

            // Now that the base coverage has been added, we need to populate the Txns
            illustrationRequest.IllustrationTxn = HydrateIllustrationTxns(policy, baseCoverage.id);

            // Used for Coverage object ID
            int riderCoverageId = 0;

            foreach (var rider in policy.Riders)
            {
                riderCoverageId++;
                var riderCoverage = BuildRiderCoverage(policy, riderCoverageId, rider);
                coverages.Add(riderCoverage);
            }

            return coverages.ToArray();
        }

        private Coverage BuildRiderCoverage(UniversalLifePolicy policy, int riderCoverageId, Illustration.Model.Generation.Request.Rider rider)
        {
            // ACORD supported values from doc
            //tc 21 = Waiver of Specified Premium
            //tc 23 = Accidental Death Benefit
            //tc 102 = Guaranteed Purchase Option
            //tc 114 = Waiver of Month Deductions
            //tc 2147483647 = Other

            // We don’t specify rating class for most riders so TobaccoPremiumBasis and UnderwritingClass are not needed. - Elaine @ StoneRiver
            // Per Mark, we rate more riders than not. 102 - Guaranteed Insurability, 103 - Premium Deposit Fund and 105 - Accelerated Benefit are NOT rated. The rest are.

            var riderCoverage = new Coverage();

            var extensions = new List<OLifEExtension>();

            if (rider.RiderType == 0)
            {
                throw new AcordRequestFactoryException(string.Format(CultureInfo.InvariantCulture, "Rider Type of zero is not expected for certificate '{0}'.", policy.PolicyNumber));
            }

            riderCoverage.id = string.Format(CultureInfo.InvariantCulture, "RiderCoverage{0}", riderCoverageId);
            riderCoverage.LifeCovTypeCode = AcordLookupBuilder.BuildFromWowString<OLI_LU_COVTYPE>(rider.RiderType.ToString(CultureInfo.InvariantCulture));
            riderCoverage.IndicatorCode = AcordLookupBuilder.BuildFromTC<OLI_LU_COVINDCODE>((int)OLI_LU_COVINDCODE_TC.OLI_COVIND_RIDER);
            // When hydrating LifeParticipantData, this coverage may be an Other Insured coverage.
            DateTime riderStartDate;
            if (policy.IsInforce)
            {
                //baseDate = policy.IssueDate; TODO: this seems incorrect. need to verify.

                var modifier = rider.IssueAge - policy.IssueAge;

                riderStartDate = policy.IssueDate.AddYears(modifier);
                riderCoverage.EffDate = riderStartDate;
                riderCoverage.EffDateSpecified = riderCoverage.EffDate > DateTime.MinValue;

				if (rider.RiderType == 11 && policy is AdjustableLifeFlexibleLifePolicy)
				{
					// Sapiens decided to do something different for AL/FL Waiver of Premium riders.
					riderCoverage.LifeCovTypeCode.Value = "Waiver of Premium";
					riderCoverage.LifeCovTypeCode.tc = OLI_LU_COVTYPE_TC.OLI_OTHER;
				}

				if (rider.RiderType == 5 && policy is AdjustableLifeFlexibleLifePolicy)
				{
					// Sapiens decided to do something different for AL/FL COLA riders.
					riderCoverage.LifeCovTypeCode.Value = "Cost of Living";
					riderCoverage.LifeCovTypeCode.tc = OLI_LU_COVTYPE_TC.OLI_OTHER;
				}
			}
            else
            {
                riderStartDate = policy.SceneModifyDate;
            }

            riderCoverage.LifeParticipant = HydrateRiderLifeParticipantData(rider, riderStartDate, policy);
            riderCoverage.InitCovAmt = rider.Amount;
            riderCoverage.InitCovAmtSpecified = (rider.Amount > 0M);

            // Rider type is not suported by ACORD, use vendor extension
            if (riderCoverage.LifeCovTypeCode.tc == OLI_LU_COVTYPE_TC.OLI_OTHER)
            {
                var fipExt = new AcordCoverageExtension() { SystemCode = "Woodmen Illustration Service", VendorCode = "FISERV" };
                extensions.Add(fipExt);

                //// Expected values per doc
                ////8 	Other Insured Rider
                ////12    Applicant Waiver / Payor Benefit
                ////105	Accelerated Benefit
                ////103	Premium Deposit Fund
                ////101 2X WMD
                fipExt.RiderType = AcordLookupBuilder.BuildFromWowString<AWD_LU_RIDERTYPE>(rider.RiderType.ToString(CultureInfo.InvariantCulture));

				if (rider.RiderType == 11 && policy is AdjustableLifeFlexibleLifePolicy)
				{
					// Sapiens decided to do something different for AL/FL Waiver of Premium riders.					
					fipExt.RiderType.tc = AWD_LU_RIDERTYPE_TC.Item11; // Waiver of Premium						
				}

				if (rider.RiderType == 5 && policy is AdjustableLifeFlexibleLifePolicy)
				{
					// Sapiens decided to do something different for AL/FL COLA riders.					
					fipExt.RiderType.tc = AWD_LU_RIDERTYPE_TC.Item5; // Cost of Living					
				}
			}

            if (extensions.Any())
            {
                riderCoverage.OLifEExtension = extensions.ToArray();
            }
            return riderCoverage;
        }

        private OLifEExtension[] HydratePolicyExtensionData(UniversalLifePolicy policy)
        {
            // Create custom extension object
            var fipExt = new AcordPolicyExtension() { SystemCode = "Woodmen Illustration Service", VendorCode = "FISERV" };

            //<FIP:TemplateID>
            fipExt.TemplateId = templateIds.Single(t => t.IsInforce == policy.IsInforce && t.HeaderCode == policy.HeaderCode).TemplateId;

            if (policy.NeedsCostBenefit)
            {
                fipExt.CostBenefitReport = AcordLookupBuilder.BuildFromTC<COST_BENEFIT_REPORT_TYPE>((int)COST_BENEFIT_REPORT_TYPE_TC.True);
            }
            else
            {
                fipExt.CostBenefitReport = AcordLookupBuilder.BuildFromTC<COST_BENEFIT_REPORT_TYPE>((int)COST_BENEFIT_REPORT_TYPE_TC.False);
            }

            //<FIP:NbrOwners>
            fipExt.NumberOfOwners = policy.NumberOfOwners;

            //<FIP:AnnualFraternalDues>
            if (RequiredFraternalDues.ContainsKey(policy.HeaderCode))
            {
                fipExt.AnnualFraternalDues = RequiredFraternalDues[policy.HeaderCode];
            }
            else
            {
                fipExt.AnnualFraternalDues = policy.FraternalDues;
            }

            if (policy.ReduceFaceAmount == true)
            {
                fipExt.ReducedFaceAmountOpt = 1;
                fipExt.ReducedFaceAmountOptSpecified = true;
            }

            if (policy.PartialSurrenderToClearDebt)
            {
                fipExt.PartialSurrenderToClearDebt = 1;
                fipExt.PartialSurrenderToClearDebtSpecified = true;
            }

            //<FIP:Refunds>
            //1 – Cash
            //2 – Paid Up Insurance/Add'l Ins after max
            //3 – Left with Woodmen at Interest/Accum at Int after max
            //4 – Reduce Premiums
            //6 - Cash after max
            fipExt.Refunds = AcordLookupBuilder.BuildFromWowString<REFUNDS_TYPE>(policy.RefundOption.ToString(CultureInfo.InvariantCulture));

            //<FIP:LumpSumPaymentOption>
            // Zero doesn't map to ACORD. Assuming zero is a default value. There is no unknown value with this ACORD TC class.
            // 9/15/2015: LumpSumUsage is not a good indicator for LumpSum. Switching to DataTypeCode = 8, NLAmt_1 > 0 or whether Lump1035Amount > 0

            var nlDataItem = policy.NonLevelData.SingleOrDefault(n => n.DataTypeCode == DataType.LumpSum && n.Level == 1);

            if ((nlDataItem != null && nlDataItem.Amounts.Any() && nlDataItem.Amounts[0] > 0) || policy.Lump1035Amount > 0)
            {
                fipExt.LumpSumPaymentOption = AcordLookupBuilder.BuildFromTC<LumpSumPaymentOptionType>((int)LumpSumPaymentOptionType_TC.InLieuOfPremium);
                //fipExt.LumpSumPaymentOption = AcordLookupBuilder.BuildFromTC<LumpSumPaymentOptionType>((int)LumpSumPaymentOptionType_TC.AddToPremium);
            }

            //<FIP:ConformTAMRA>
            fipExt.ConformTAMRA = AcordLookupBuilder.BuildBoolean(policy.IsTAMRAApplicable);

            //<FIP:RevisedIllustration>
            fipExt.RevisedIllustration = AcordLookupBuilder.BuildBoolean(policy.IsRevisedIllustration);

            fipExt.SceneModifyDate = policy.SceneModifyDate;

            //<FIP:RateDeterminationDate>
            if (Settings.Default.BackDateHeaderCodes.Contains(policy.HeaderCode.ToString()))   // BTG
            {
                if (policy.IssueDate == DateTime.MinValue)
                {
                    policy.IssueDate = policy.SceneModifyDate;
                }

                fipExt.RateDeterminationDate = policy.IssueDate;
            }

            fipExt.BelowMinimumPremium = policy.BelowMinimumPremium;

            fipExt.NLGInterest = policy.NoLapseGuaranteedInterest;

            var aulPolicy = policy as AccumulationUniversalLifePolicy;
            if (aulPolicy != null)
            {
                fipExt.PrintAsTobacco = aulPolicy.PrintAsTobacco ? 1 : 0; // FIP value is int, so I'm converting from bool here.
            }

            return new OLifEExtension[] { fipExt };
        }

        protected override OLifEExtension[] HydrateInforcePolicyExtensionData(WOW.Illustration.Model.Generation.Request.Policy policy)
        {
            if (log.IsInfoEnabled) { log.Info($"HydrateInforcePolicyExtensionData called."); }

            var extArray = base.HydrateInforcePolicyExtensionData(policy);

            AcordPolicyExtension fipExt;

            // Check to see if base array is null. If so, create the object and the containing array.
            if (extArray == null)
            {
                fipExt = new AcordPolicyExtension();
                extArray = new OLifEExtension[] { fipExt };
            }
            else
            {
                // Otherwise, get reference to object in array.
                fipExt = (AcordPolicyExtension)extArray.First();
            }

            var universalLife = (UniversalLifePolicy)policy;

            // Add values to extension for UL request
            fipExt.ModalLoanRepay = universalLife.ModalizedLoanRepayment;
            fipExt.RefundsOnDeposit = universalLife.AdditionalInsuranceOnDeposit;
            fipExt.APFBalance = universalLife.WLPDFB;

            var aulPolicy = policy as AccumulationUniversalLifePolicy;
            if (aulPolicy != null)
            {
                fipExt.PrintAsTobacco = aulPolicy.PrintAsTobacco ? 1 : 0; // FIP value is int, so I'm converting from bool here.
            }

            // We need to check all properties so we don't suppress the object incorrectly.
            if (fipExt.ModalLoanRepaySpecified ||
                fipExt.RefundsOnDepositSpecified ||
                fipExt.APFBalanceSpecified ||
                fipExt.PrintAsTobaccoSpecified ||
                fipExt.StatKindSpecified ||
                fipExt.RefundsOnDepositSpecified ||
                fipExt.NLGLoadTargetSpecified ||
                fipExt.NLGAccountValueSpecified)
            {
                return extArray;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Creates array of IllustrationTxn objects.
        /// </summary>
        /// <remarks>
        /// I considered trying to make this more dynamic and just looping, but I couldn't be sure about what values I would get and some of the Txns have different properities getting set.
        /// </remarks>
        /// <param name="universalLife">UniversalLifePolicy object</param>
        /// <returns>Array of IllustrationTxns (related to Coverages)</returns>
        protected override IllustrationTxn_Type[] HydrateIllustrationTxns(WOW.Illustration.Model.Generation.Request.Policy policy, string coverageId)
        {
            if (log.IsInfoEnabled) { log.Info($"HydrateIllustrationTxns called."); }

            var lifePolicy = (LifePolicy)policy;

            var txns = new List<IllustrationTxn_Type>();
            var nonLevel = lifePolicy.NonLevelData;

            // Generate Txn objects for each nonlevel data type
            txns.AddRange(GenerateTxns(nonLevel, lifePolicy, coverageId, DataType.CoverageBenefit));
            txns.AddRange(GenerateTxns(nonLevel, lifePolicy, coverageId, DataType.PaymentSchedule));
            txns.AddRange(GenerateTxns(nonLevel, lifePolicy, coverageId, DataType.DeathBenefit));
            txns.AddRange(GenerateTxns(nonLevel, lifePolicy, coverageId, DataType.PartialSurrender));
            txns.AddRange(GenerateTxns(nonLevel, lifePolicy, coverageId, DataType.Loan));
            txns.AddRange(GenerateTxns(nonLevel, lifePolicy, coverageId, DataType.Repayment));
            txns.AddRange(GenerateTxns(nonLevel, lifePolicy, coverageId, DataType.LumpSum));

            return txns.ToArray();
        }

        private static IEnumerable<IllustrationTxn_Type> GenerateTxns(IEnumerable<NonLevelData> nonLevelData, LifePolicy policy, string coverageId, DataType dataType)
        {
            var txns = new List<IllustrationTxn_Type>();
            bool firstPass = true;
            var alflPolicy = policy as AdjustableLifeFlexibleLifePolicy;
            bool futureALFLPremium = false;

            // Declare out here to hold the previous level's end date
            DateTime endDate = DateTime.MinValue;

            // Gather up my Lump Sum Payments
            var items = nonLevelData.Where(d => d.DataTypeCode == dataType).OrderBy(d => d.Level).ToList();

            foreach (var item in items)
            {
                DateTime startDate;

                // Don't bother adding empty levels for Lump Sums.
                if (alflPolicy != null)
                {
                    if (dataType == DataType.PaymentSchedule && alflPolicy.HasFuturePremiumChange)
                    {
                        futureALFLPremium = true;
                    }
                }
                else
                {
                    if (dataType == DataType.LumpSum && (item.Amounts.Count == 0 || item.Amounts[0] == 0)) continue;
                }

                if (endDate == DateTime.MinValue)
                {
                    // This is the first pass. Calculate first level dates.
                    if (policy.IsInforce)
                    {
                        startDate = policy.DataDate;
                        endDate = policy.IssueDate.AddYears(item.Age - policy.IssueAge);

                        if (dataType == DataType.LumpSum && (policy is AdjustableLifeFlexibleLifePolicy || policy is IndexedUniversalLifePolicy))
                        {
                            if (!policy.HasFaceIncreaseToMaxOut.GetValueOrDefault())
                            {
                                startDate = startDate.AddYears(-1);
                            }                                              
                            endDate = DateUtilities.GetNextAnniversary(policy.IssueDate, DateTime.Today).GetValueOrDefault(endDate);
                        }

                        if (dataType == DataType.DeathBenefit && policy is AdjustableLifeFlexibleLifePolicy)
                        {
                            if (policy.DeathBenefitStartDates != null)
                            {
                                if (policy.DeathBenefitStartDates.Values.ElementAt(0) != DateTime.MinValue)
                                {
                                    endDate = policy.DeathBenefitStartDates.Values.ElementAt(0);
                                }
                            }
                        }
                    }
                    else
                    {
                        startDate = policy.SceneModifyDate;
                        endDate = startDate.AddYears(item.Age - policy.Client.Age);
                    }
                }
                else
                {
                    firstPass = false;

                    if ((dataType == DataType.LumpSum && policy.HasFutureLumpSum.GetValueOrDefault(false)) || (dataType == DataType.PaymentSchedule && futureALFLPremium))
                    {
                        if (item.Amounts[0] == 0)
                        {
                            startDate = endDate;
                            endDate = startDate.AddYears(1);
                        }
                        else
                        {
                            startDate = policy.IssueDate.AddYears(item.Age - policy.IssueAge);
                            if (futureALFLPremium)
                            {
                                endDate = policy.IssueDate.AddYears(item.ToAge - policy.IssueAge);
                            }
                            else
                            {
                                endDate = startDate.AddYears(1);
                            }
                        }
                    }
                    else
                    {
                        // This is the n pass.
                        // StartDate will be the last pass' EndDate
                        // EndDate will be from DOB to new toAge amount
                        if (dataType == DataType.DeathBenefit && policy is AdjustableLifeFlexibleLifePolicy && policy.DeathBenefitStartDates != null)
                        {
                            startDate = endDate;

                            if (startDate == policy.DeathBenefitStartDates.Values.Last())
                            {
                                endDate = policy.IssueDate.AddYears(item.Age - policy.IssueAge);
                            }
                            else
                            {
                                if (!policy.DeathBenefitStartDates.TryGetValue(item.Level + 1, out endDate))
                                {
                                    endDate = policy.IssueDate.AddYears(item.Age - policy.IssueAge);
                                }
                            }
                        }
                        else
                        {
                            startDate = endDate;
                            if (policy.IsInforce)
                            {
                                endDate = policy.IssueDate.AddYears(item.Age - policy.IssueAge);
                            }
                            else
                            {
                                endDate = policy.SceneModifyDate.AddYears(item.Age - policy.Client.Age);
                            }
                        }
                    }
                }

                // Only build the TXN if the range is valid.
                if (startDate == endDate) continue;

                // Add Lump Sum Payment
                var txn = new IllustrationTxn_Type();
                txns.Add(txn);

                txn.CoverageID = coverageId;
                var code = (item.Codes.Any()) ? item.Codes[0] : 0;

                var type = GetTxnType(dataType, code);

                txn.IllusTxnPrimaryType = type.Item1;
                txn.IllusTxnSecondaryType = type.Item2;
                txn.IllusTxnTertiaryType = type.Item3;

                txn.IllusTxnAmt = (item.Amounts.Any()) ? item.Amounts[0] : 0M;
                txn.IllusTxnAmtSpecified = true;
                txn.StartDate = startDate;
                txn.EndDate = endDate;
                txn.StartDateSpecified = true;
                txn.EndDateSpecified = true;

                if (dataType == DataType.PaymentSchedule)
                {
                    txn.IllusTxnMode = AcordLookupBuilder.BuildFromWowString<OLI_LU_PAYMODE>(item.Codes[1].ToString(CultureInfo.InvariantCulture));
                }

                if (txn.IllusTxnSecondaryType != null && txn.IllusTxnSecondaryType.tc == TC_ILLUSSECTYPE_TC.OLI_OTHER && code > 0)
                {
                    var fipExt = new AcordIllustrationTxnExtension() { SystemCode = "Woodmen Illustration Service", VendorCode = "FISERV" };

                    fipExt.IllustrationTxnSecondaryType = AcordLookupBuilder.BuildFromWowString<FIP_ILLUS_TXN_SECONDARY_TYPE>(code.ToString());
                    txn.OLifEExtension = new OLifEExtension[] { fipExt };
                }

                if (dataType == DataType.CoverageBenefit)
                {
                    int? newRatingAmount = null;
                    var iulPolicy = policy as IndexedUniversalLifePolicy;

                    var fipExt = new AcordIllustrationTxnExtension() { SystemCode = "Woodmen Illustration Service", VendorCode = "FISERV" };

                    if (firstPass && iulPolicy != null || firstPass && alflPolicy != null)
                    {
                        if (policy.ReduceFaceAmount == true || policy.FaceIncreaseToMaxOut == true)
                        {
                            fipExt.IllustrationTxnSecondaryType = AcordLookupBuilder.BuildFromWowString<FIP_ILLUS_TXN_SECONDARY_TYPE>(code.ToString());
                            fipExt.IllustrationTxnSecondaryType.Value = "Max-out at Issue";
                        }
                        else
                        {
							if (policy is AdjustableLifeFlexibleLifePolicy && policy.HasFaceIncreaseToMaxOut == true)
							{
								fipExt.PermTableRating = AcordLookupBuilder.BuildFromWowString<OLI_LU_RATINGS>(policy.RatingAmount.ToString());
							}
							else
							{
								fipExt.TempTableRating = AcordLookupBuilder.BuildFromWowString<OLI_LU_RATINGS>(policy.RatingAmount.ToString());
							}								
                        }

                        txn.OLifEExtension = new OLifEExtension[] { fipExt };
                    }
                    else
                    {

                        if (iulPolicy != null || alflPolicy != null)
                        {
                            newRatingAmount = (iulPolicy?.NewRatingAmount == null) ? alflPolicy?.NewRatingAmount : iulPolicy?.NewRatingAmount;

                            if (newRatingAmount != null)
                            {
								if (policy is AdjustableLifeFlexibleLifePolicy && policy.HasFaceIncreaseToMaxOut == true)
								{
									fipExt.PermTableRating = AcordLookupBuilder.BuildFromWowString<OLI_LU_RATINGS>(newRatingAmount.ToString());
								}
								else
								{
									fipExt.TempTableRating = AcordLookupBuilder.BuildFromWowString<OLI_LU_RATINGS>(newRatingAmount.ToString());
								}								
                            }
                            else
                            {
								if (policy is AdjustableLifeFlexibleLifePolicy && policy.HasFaceIncreaseToMaxOut == true)
								{
									fipExt.PermTableRating = AcordLookupBuilder.BuildFromWowString<OLI_LU_RATINGS>(policy.RatingAmount.ToString());
								}
								else
								{
									fipExt.TempTableRating = AcordLookupBuilder.BuildFromWowString<OLI_LU_RATINGS>(policy.RatingAmount.ToString());
								}
							}

                            txn.OLifEExtension = new OLifEExtension[] { fipExt };
                        }
                    }
                }
            }

            return txns.ToList();
        }

        private static Tuple<TC_ILLUSPRIMTYPE, TC_ILLUSSECTYPE, TC_ILLUSTERTTYPE> GetTxnType(DataType txnType, int code)
        {
            Tuple<TC_ILLUSPRIMTYPE, TC_ILLUSSECTYPE, TC_ILLUSTERTTYPE> tuple = null;
            TC_ILLUSPRIMTYPE primary = null;
            TC_ILLUSSECTYPE secondary = null;
            TC_ILLUSTERTTYPE tertiary = null;

            switch (txnType)
            {
                case DataType.CoverageBenefit:
                    primary = AcordLookupBuilder.BuildFromTC<TC_ILLUSPRIMTYPE>((int)TC_ILLUSPRIMTYPE_TC.ILL_PRI_COV);
                    switch (code)
                    {
                        case 1:
                            secondary = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_COV_TXNAMT); //70
                            break;
                        case 2:
                            secondary = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_COV_GDBPREMFACE); //76
                            break;
                        case 3:
                            secondary = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_COV_MINPREM); //73
                            break;
                        case 4:
                            secondary = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_COV_TRGTPREM); //74
                            break;
                        case 6:
                            secondary = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_COV_7PAY); //75
                            break;
                        default:
                            secondary = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.OLI_OTHER);
                            break;
                    }
                    tertiary = null;
                    break;
                case DataType.PaymentSchedule:
                    primary = AcordLookupBuilder.BuildFromTC<TC_ILLUSPRIMTYPE>((int)TC_ILLUSPRIMTYPE_TC.ILL_PRI_PMTSCHD); //3

                    switch (code)
                    {
                        case 1:
                            secondary = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_PMTSCHD_SPECPREM); //30
                            break;
                        case 2:
                            secondary = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_PMTSCHD_GLP); //39
                            break;
                        case 3:
                            secondary = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_PMTSCHD_MPREM); //34
                            break;
                        case 4:
                            secondary = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_PMTSCHD_TRGTPREM); //35
                            break;
                        case 6:
                            secondary = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_PMTSCHD_PREM7PAY); //36
                            break;
                        default:
                            secondary = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.OLI_OTHER);
                            break;
                    }
                    tertiary = null;
                    break;
                case DataType.DeathBenefit:
                    primary = AcordLookupBuilder.BuildFromTC<TC_ILLUSPRIMTYPE>((int)TC_ILLUSPRIMTYPE_TC.ILL_PRI_DBOPT);
                    switch (code)
                    {
                        case 1:
                            secondary = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_DBOPT_LEVEL);
                            break;
                        case 2:
                            secondary = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_DBOPT_INCR);
                            break;
                        default:
                            secondary = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.OLI_OTHER);
                            break;
                    }
                    tertiary = null;
                    break;
                case DataType.PartialSurrender:
                    primary = AcordLookupBuilder.BuildFromTC<TC_ILLUSPRIMTYPE>((int)TC_ILLUSPRIMTYPE_TC.ILL_PRI_DIST);
                    secondary = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_DIST_SURRPARTIAL);
                    tertiary = null;
                    break;
                case DataType.Loan:
                    primary = AcordLookupBuilder.BuildFromTC<TC_ILLUSPRIMTYPE>((int)TC_ILLUSPRIMTYPE_TC.ILL_PRI_DIST);
                    secondary = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_SCHEDLOANAMT);
                    tertiary = null;
                    break;
                case DataType.Repayment:
                    primary = AcordLookupBuilder.BuildFromTC<TC_ILLUSPRIMTYPE>((int)TC_ILLUSPRIMTYPE_TC.ILL_PRI_DIST);
                    secondary = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_LOANREPAYTXN);
                    tertiary = null;
                    break;
                case DataType.LumpSum:
                    primary = AcordLookupBuilder.BuildFromTC<TC_ILLUSPRIMTYPE>((int)TC_ILLUSPRIMTYPE_TC.ILL_PRI_NETPMT);
                    secondary = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_NETPMT_PREMTXN);
                    tertiary = null;
                    break;
                default:
                    break;
            }

            tuple = new Tuple<TC_ILLUSPRIMTYPE, TC_ILLUSSECTYPE, TC_ILLUSTERTTYPE>(primary, secondary, tertiary);

            return tuple;
        }

        /// <summary>
        /// Traditional policies only need Coverage Benefit Txns for inforce policies.
        /// </summary>
        /// <param name="policy">WOW Policy Model</param>
        /// <param name="coverageId">ID of Coverage element to associate the Txns with</param>
        /// <returns>Array of Txn objects</returns>
        protected static IllustrationTxn_Type[] HydrateInforceIllustrationTxns(WOW.Illustration.Model.Generation.Request.Policy policy, string coverageId)
        {
            if (log.IsInfoEnabled) { log.Info($"HydrateInforceIllustrationTxns called."); }

            int? newRatingAmount = null;

            if (policy == null)
            {
                throw new ArgumentNullException("policy", "Cannot create inforce illustration Txns for a null policy object.");
            }

            if (string.IsNullOrEmpty(coverageId))
            {
                throw new ArgumentNullException("coverageId", "Cannot create inforce illustration Txns without a valid coverage ID.");
            }

            var iulPolicy = policy as IndexedUniversalLifePolicy;
            var alflPolicy = policy as AdjustableLifeFlexibleLifePolicy;

            // Create list for IllustrationTxn objects
            var illustrationTxns = new List<IllustrationTxn_Type>();

            IllustrationTxn_Type previousCoverageBenefit = null;
            IllustrationTxn_Type previousDeathBenefitOption = null;

            // For each level in this section, we need a Cost Benefit Txn and a DB Option
            foreach (var nlPolicyData in policy.NonLevelPolicyData)
            {
                // Universal Life requests always include a Coverage Benefit Txn for inforce
                var coverageBenefit = new IllustrationTxn_Type();
                coverageBenefit.CoverageID = coverageId;
                coverageBenefit.IllusTxnPrimaryType = AcordLookupBuilder.BuildFromTC<TC_ILLUSPRIMTYPE>((int)TC_ILLUSPRIMTYPE_TC.ILL_PRI_COV);
                coverageBenefit.IllusTxnSecondaryType = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_COV_TXNAMT);
                coverageBenefit.IllusTxnAmt = nlPolicyData.NonLevelAmounts[0];
                coverageBenefit.IllusTxnAmtSpecified = true;
                // If previous is null, this is the first level. Use effective date.
                if (previousCoverageBenefit == null)
                {
                    coverageBenefit.StartDate = policy.IssueDate;
                }
                else
                {
                    coverageBenefit.StartDate = nlPolicyData.EffectiveDate;
                }

                coverageBenefit.StartDateSpecified = true;
                coverageBenefit.EndDateSpecified = true;

                if (coverageId == "InforceUniversalCoverage1")
                {
                    if (iulPolicy != null)
                    {
                        newRatingAmount = iulPolicy.NewRatingAmount;

                        var extensions = new List<OLifEExtension>();
                        // Create custom extension object
                        var fipExt = new AcordIllustrationTxnExtension() { SystemCode = "Woodmen Illustration Service", VendorCode = "FISERV" };
                        fipExt.TempTableRating = AcordLookupBuilder.BuildFromWowString<OLI_LU_RATINGS>(iulPolicy.RatingAmount.ToString());

                        extensions.Add(fipExt);

                        coverageBenefit.OLifEExtension = extensions.ToArray();
                    }

                    if (alflPolicy != null)
                    {
                        newRatingAmount = alflPolicy.NewRatingAmount;

                        var extensions = new List<OLifEExtension>();
                        // Create custom extension object
                        var fipExt = new AcordIllustrationTxnExtension() { SystemCode = "Woodmen Illustration Service", VendorCode = "FISERV" }; 
						
						if (alflPolicy.HasFaceIncreaseToMaxOut == true)
						{
							fipExt.PermTableRating = AcordLookupBuilder.BuildFromWowString<OLI_LU_RATINGS>(alflPolicy.RatingAmount.ToString());
						}
						else
						{
							fipExt.TempTableRating = AcordLookupBuilder.BuildFromWowString<OLI_LU_RATINGS>(alflPolicy.RatingAmount.ToString());
						}							

                        extensions.Add(fipExt);

                        coverageBenefit.OLifEExtension = extensions.ToArray();
                    }
                }

                // Death Benefit Option
                var deathBenefitOption = new IllustrationTxn_Type();

                deathBenefitOption.CoverageID = coverageId;
                deathBenefitOption.IllusTxnPrimaryType = AcordLookupBuilder.BuildFromTC<TC_ILLUSPRIMTYPE>((int)TC_ILLUSPRIMTYPE_TC.ILL_PRI_DBOPT);

                switch ((int)nlPolicyData.NonLevelAmounts[1])
                {
                    case 1:
                        deathBenefitOption.IllusTxnSecondaryType = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_DBOPT_LEVEL); //11
                        break;
                    case 2:
                        deathBenefitOption.IllusTxnSecondaryType = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_DBOPT_INCR); //12
                        break;
                    default:
                        deathBenefitOption.IllusTxnSecondaryType = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.OLI_OTHER);
                        break;
                }

                // If previous is null, this is the first level. Use effective date.
                if (previousDeathBenefitOption == null)
                {
                    deathBenefitOption.StartDate = policy.IssueDate;
                }
                else
                {
                    deathBenefitOption.StartDate = nlPolicyData.EffectiveDate;
                }

                deathBenefitOption.StartDateSpecified = true;
                deathBenefitOption.EndDateSpecified = true;

                // If there was a level before this one, set its end date to this levels effective date.
                if (previousCoverageBenefit != null)
                {
                    previousCoverageBenefit.EndDate = nlPolicyData.EffectiveDate;
                }

                if (previousDeathBenefitOption != null)
                {
                    previousDeathBenefitOption.EndDate = nlPolicyData.EffectiveDate;
                }

                // Add to list
                illustrationTxns.Add(coverageBenefit);
                illustrationTxns.Add(deathBenefitOption);

                // Reassign the previousLevel to the current level
                previousCoverageBenefit = coverageBenefit;
                previousDeathBenefitOption = deathBenefitOption;
            }

            // Outside the foreach, the previousLevel represents the final level. Set the EndDate.
            previousCoverageBenefit.EndDate = policy.DataDate;
            previousDeathBenefitOption.EndDate = policy.DataDate;

            return illustrationTxns.ToArray();
        }

        protected override DateTime CalculateTableRatingEndDate(Illustration.Model.Generation.Request.Policy policy, DateTime baseDate)
        {
            if (log.IsInfoEnabled) { log.Info($"CalculateTableRatingEndDate called."); }

            var baseAge = 0;
            var modifier = 0;

            if (policy.IsInforce)
            {
                baseAge = policy.IssueAge;
            }
            else
            {
                baseAge = policy.Client.Age;
            }

            var durationMaxAge = baseAge + 20;

            if (durationMaxAge < 65)
            {
                durationMaxAge = 65;
            }

            modifier = durationMaxAge - baseAge; // find the number of years to add to the base date

            return baseDate.AddYears(modifier);
        }

        protected override DateTime CalculateRiderTableRatingEndDate(Illustration.Model.Generation.Request.Policy policy, DateTime riderDate, int riderAge)
        {
            if (log.IsInfoEnabled) { log.Info($"CalculateRiderTableRatingEndDate called."); }

            var modifier = 0;

            var durationMaxAge = riderAge + 20;

            if (durationMaxAge < 65)
            {
                durationMaxAge = 65;
            }

            modifier = durationMaxAge - riderAge; // find the number of years to add to the base date

            return riderDate.AddYears(modifier);
        }

    }
}