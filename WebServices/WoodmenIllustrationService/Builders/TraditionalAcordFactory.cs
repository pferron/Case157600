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
    public class TraditionalAcordFactory : BaseAcordFactory
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(TraditionalAcordFactory));

        private const int TermBaseLevelYouthWithAcceleratedDeathBenefit = 790;      // (hard) magic Number

        internal TraditionalAcordFactory()         
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

            // Set payment mode and method from policy object.
            var tradLifePolicy = (TraditionalLifePolicy)policy;

            holding.Policy.PaymentMode = AcordLookupBuilder.BuildFromWowString<OLI_LU_PAYMODE>(tradLifePolicy.PremiumMode.ToString(CultureInfo.InvariantCulture));
            holding.Policy.PaymentMethod = AcordLookupBuilder.BuildFromWowString<OLI_LU_PAYMETHOD>(tradLifePolicy.BillType.ToString(CultureInfo.InvariantCulture));
            holding.Policy.PaymentAmt = tradLifePolicy.PremiumAmount;
            holding.Policy.PaymentAmtSpecified = (tradLifePolicy.PremiumAmount > 0M);
            holding.Policy.Item = HydrateLifeData(tradLifePolicy);
            holding.Policy.OLifEExtension = HydratePolicyExtensionData(tradLifePolicy);

            // Check for inforce and add additional holding
            if (policy.IsInforce)
            {
                // Create inforce holding object
                var inforceHolding = InitializeInforceHolding(policy);
                inforceHolding.Policy.Item = HydrateInforceLifeData(tradLifePolicy);
                inforceHolding.Policy.OLifEExtension = HydrateInforcePolicyExtensionData(tradLifePolicy);

                // Add to list
                holdings.Add(inforceHolding);
            }
            else
            {
                holding.Policy.EffDate = tradLifePolicy.CertificateDate;
                holding.Policy.EffDateSpecified = holding.Policy.EffDate > DateTime.MinValue;
            }

            return holdings.ToArray();
        }

        private Life HydrateLifeData(TraditionalLifePolicy policy)
        {
            var life = new Life();

            life.InitDepositAmt = policy.InitialPremium;
            life.InitDepositAmtSpecified = (policy.InitialPremium > 0M);
            life.InitialPremAmt = (policy.FaceCode == 2) ? policy.PremiumAmount : 0M;
            life.InitialPremAmtSpecified = (policy.FaceCode == 2);
            life.Coverage = HydrateCoverageData(policy);
            life.LifeUSA = HydrateLifeUsaData(policy);

            return life;
        }

        private Life HydrateInforceLifeData(TraditionalLifePolicy policy)
        {
            var life = new Life();

            life.Coverage = HydrateInforceCoverageData(policy);
            life.LifeUSA = HydrateInforceLifeUsaData(policy);

            return life;
        }

        private Coverage[] HydrateCoverageData(TraditionalLifePolicy policy)
        {
            var coverages = new List<Coverage>();

            // Create base coverage for policy
            var baseCoverage = new Coverage();

            // Add coverage to list
            coverages.Add(baseCoverage);

            // Set Coverage ID to 1 since it is base
            baseCoverage.id = "TraditionalCoverage1";

            if (policy.HeaderCode == 0)
            {
                throw new AcordRequestFactoryException("HeaderCode of zero is not expected.");
            }

            // Lookup LifeCovTypeCode in DB
            baseCoverage.LifeCovTypeCode = AcordLookupBuilder.BuildFromWowString<OLI_LU_COVTYPE>(policy.HeaderCode.ToString(CultureInfo.InvariantCulture));

            // Set IndicatorCode to base
            baseCoverage.IndicatorCode = AcordLookupBuilder.BuildFromTC<OLI_LU_COVINDCODE>((int)OLI_LU_COVINDCODE_TC.OLI_COVIND_BASE);

            // Set coverage or premium amount, depending on face code
            baseCoverage.InitCovAmt = (policy.FaceCode == 1) ? policy.FaceAmount : 0M;
            baseCoverage.InitCovAmtSpecified = baseCoverage.InitCovAmt > 0M;
            baseCoverage.ModalPremAmt = (policy.FaceCode == 2) ? policy.PremiumAmount : 0M;
            baseCoverage.ModalPremAmtSpecified = baseCoverage.ModalPremAmt > 0M;

            DateTime baseDate;
            if (policy.IsInforce)
            {
                baseDate = policy.IssueDate;
            }
            else
            {
                baseDate = policy.CertificateDate;
                baseCoverage.EffDate = baseDate;
                baseCoverage.EffDateSpecified = baseDate > DateTime.MinValue;
            }

            baseCoverage.LifeParticipant = HydrateBaseLifeParticipantData(policy, baseDate);

            // Now that the base coverage is added, we need to generate the related Txns
            illustrationRequest.IllustrationTxn = HydrateIllustrationTxns(policy, baseCoverage.id);

            coverages.AddRange(BuildRiderCoverages(policy));

            return coverages.ToArray();
        }

        private Coverage[] BuildRiderCoverages(TraditionalLifePolicy policy)
        {
            var coverages = new List<Coverage>();
            // Used for Coverage object ID
            int riderCoverageId = 0;
            bool adbAdded = false;

            foreach (var rider in policy.Riders)
            {
                riderCoverageId++;
                var riderCoverage = BuildRiderCoverage(policy, riderCoverageId, rider);
                if (riderCoverage.LifeCovTypeCode.tc == OLI_LU_COVTYPE_TC.OLI_COVTYPE_ACCDTHBENE)
                {
                    adbAdded = true;
                }
                coverages.Add(riderCoverage);
            }

            //Per Rudy, Youth Term has ADB built in, but LPA doesn't recognize it
            //so if ADB hasn't already been added, do so now.
            if (policy.HeaderCode == TermBaseLevelYouthWithAcceleratedDeathBenefit && !adbAdded)
            {
                var adbCoverage = BuildAccidentalDeathBenefitCoverage(policy, riderCoverageId++);
                coverages.Add(adbCoverage);
            }

            return coverages.ToArray();
        }

        private Coverage BuildAccidentalDeathBenefitCoverage(TraditionalLifePolicy policy, int riderCoverageId)
        {
            var riderCoverage = new Coverage();

            riderCoverage.id = string.Format(CultureInfo.InvariantCulture, "RiderCoverage{0}", riderCoverageId);
            riderCoverage.LifeCovTypeCode = AcordLookupBuilder.BuildFromTC<OLI_LU_COVTYPE>((int)OLI_LU_COVTYPE_TC.OLI_COVTYPE_ACCDTHBENE);
            riderCoverage.IndicatorCode = AcordLookupBuilder.BuildFromTC<OLI_LU_COVINDCODE>((int)OLI_LU_COVINDCODE_TC.OLI_COVIND_RIDER);
            riderCoverage.LifeParticipant = BuildAccidentalDeathBenefitLifeParticipant();
            riderCoverage.InitCovAmt = policy.FaceAmount;
            riderCoverage.InitCovAmtSpecified = (policy.FaceAmount > 0M);

            if (policy.IsInforce)
            {
                riderCoverage.EffDate = policy.IssueDate;
                riderCoverage.EffDateSpecified = riderCoverage.EffDate > DateTime.MinValue;
            }

            return riderCoverage;
        }

        private LifeParticipant[] BuildAccidentalDeathBenefitLifeParticipant()
        {

            // Create object list
            var lifeParticipants = new List<LifeParticipant>();

            // Create primary insured object
            var insured = new LifeParticipant();
            // Add insured object to list
            lifeParticipants.Add(insured);

            // Set party ID and role
            insured.PartyID = primaryInsuredId;
            insured.LifeParticipantRoleCode = AcordLookupBuilder.BuildFromTC<OLI_LU_PARTICROLE>((int)OLI_LU_PARTICROLE_TC.OLI_PARTICROLE_PRIMARY);

            return lifeParticipants.ToArray();
        }

        private Coverage BuildRiderCoverage(TraditionalLifePolicy policy, int riderCoverageId, Illustration.Model.Generation.Request.Rider rider)
        {
            // ACORD supported values from doc
            //tc 21 = Waiver of Specified Premium
            //tc 23 = Accidental Death Benefit
            //tc 102 = Guaranteed Purchase Option
            //tc 114 = Waiver of Month Deductions
            //tc 2147483647 = Other

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
            }
            else
            {
                riderStartDate = policy.CertificateDate;
            }

            riderCoverage.LifeParticipant = HydrateRiderLifeParticipantData(rider, riderStartDate, policy);
            riderCoverage.InitCovAmt = rider.Amount;
            riderCoverage.InitCovAmtSpecified = (rider.Amount > 0M);

            // Add extension for LifeCovTypeCode 21 (Waiver of Premium)
            if (riderCoverage.LifeCovTypeCode.tc == OLI_LU_COVTYPE_TC.OLI_COVTYPE_WAIVSCHED && policy.WaiverDate > DateTime.MinValue)
            {
                var fipExt = new AcordCoverageExtension() { SystemCode = "Woodmen Illustration Service", VendorCode = "FISERV" };
                extensions.Add(fipExt);

                fipExt.RiderDate = policy.WaiverDate;
            }

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
                fipExt.RiderType = AcordLookupBuilder.BuildFromWowString<AWD_LU_RIDERTYPE>(rider.RiderType.ToString(CultureInfo.InvariantCulture));
            }

            if (extensions.Any())
            {
                riderCoverage.OLifEExtension = extensions.ToArray();
            }
            return riderCoverage;
        }

        private Coverage[] HydrateInforceCoverageData(TraditionalLifePolicy policy)
        {
            var coverages = new List<Coverage>();

            // Create base coverage for policy
            var baseCoverage = new Coverage();

            // Add coverage to list
            coverages.Add(baseCoverage);

            // Set Coverage ID to 1 since it is base
            baseCoverage.id = "InforceTraditionalCoverage1";

            // Set IndicatorCode to base
            baseCoverage.IndicatorCode = AcordLookupBuilder.BuildFromTC<OLI_LU_COVINDCODE>((int)OLI_LU_COVINDCODE_TC.OLI_COVIND_BASE);

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

        private OLifEExtension[] HydratePolicyExtensionData(TraditionalLifePolicy policy)
        {
            // Create custom extension object
            var fipExt = new AcordPolicyExtension() { SystemCode = "Woodmen Illustration Service", VendorCode = "FISERV" };

            //<FIP:TemplateID>
            fipExt.TemplateId = templateIds.Single(t => t.IsInforce == policy.IsInforce && t.HeaderCode == policy.HeaderCode).TemplateId;

            //FIP:CostBenefitReport
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

            //<FIP:Refunds>
            //1 – Cash
            //2 – Paid Up Insurance/Add'l Ins after max
            //3 – Left with Woodmen at Interest/Accum at Int after max
            //4 – Reduce Premiums
            //6 - Cash after max
            //fipExt.Refunds = AcordLookupBuilder.BuildFromWowString<REFUNDS_TYPE>(policy.PrimaryDiv1.ToString(CultureInfo.InvariantCulture));

            //DataTypeCode 9
            //NLCode_1
            //107 - Left to accum on dep
            //103 - reduce prem
            //111 - reduce loan
            //104 - paid in cash
            //101 - Buy PUA
            //102 - Left to accum on dep Term
            //104 - other?

            var nlItem = policy.NonLevelData.SingleOrDefault(n => n.DataTypeCode == DataType.PaymentScheduleTraditional && n.Level == 1);

            if (nlItem != null && nlItem.Codes.Any())
            {
                fipExt.Refunds = AcordLookupBuilder.BuildFromWowString<REFUNDS_TYPE>(nlItem.Codes[0].ToString());
            }

            fipExt.ChapterNumber = string.IsNullOrWhiteSpace(policy.LodgeNumber) ? null : policy.LodgeNumber;
            fipExt.ChapterState = string.IsNullOrWhiteSpace(policy.LodgeState) ? null : policy.LodgeState;

            //<FIP:RateDeterminationDate>
            //FIP does not support this feature per Connie. Not implementing at this time.
            if (Settings.Default.Term2016HeaderCodes.Contains(policy.HeaderCode.ToString()))   // Livio
            {
                fipExt.RateDeterminationDate = policy.SceneModifyDate;
            }

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

            return new OLifEExtension[] { fipExt };
        }

        
        protected override OLifEExtension[] HydrateInforcePolicyExtensionData(WOW.Illustration.Model.Generation.Request.Policy policy)
        {
            if (log.IsInfoEnabled) { log.Info($"HydrateInforcePolicyExtensionData called."); }

            var extArray = base.HydrateInforcePolicyExtensionData(policy);

            AcordPolicyExtension ext;

            // Check to see if base array is null. If so, create the object and the containing array.
            if (extArray == null)
            {
                ext = new AcordPolicyExtension();
                extArray = new OLifEExtension[] { ext };
            }
            else
            {
                // Otherwise, get reference to object in array.
                ext = (AcordPolicyExtension)extArray.First();
            }

            var traditionalLife = (TraditionalLifePolicy)policy;

            // Add value to extension
            ext.ModalLoanRepay = traditionalLife.ModalizedLoanRepayment;

            // We need to check all properties so we don't suppress the object incorrectly.
            if (ext.ModalLoanRepaySpecified ||
                ext.StatKindSpecified ||
                ext.RefundsOnDepositSpecified ||
                ext.NLGLoadTargetSpecified ||
                ext.NLGAccountValueSpecified)
            {
                return extArray;
            }
            else
            {
                return null;
            }
        }

        
        protected override IllustrationTxn_Type[] HydrateIllustrationTxns(WOW.Illustration.Model.Generation.Request.Policy policy, string coverageId)
        {
            if (log.IsInfoEnabled) { log.Info($"HydrateIllustrationTxns called."); }

            if (policy == null)
            {
                throw new ArgumentNullException("policy", "Cannot create illustration Txns for a null policy object.");
            }

            if (string.IsNullOrEmpty(coverageId))
            {
                throw new ArgumentNullException("coverageId", "Cannot create illustration Txns without a valid coverage ID.");
            }

            var tradPolicy = (TraditionalLifePolicy)policy;

            // Per Rudy, Trad Life has Coverage Benefit, Payment Schedule and Dividend Option at a minimum.
            // Lump Sum Payment depends on NonLevelData items.
            // Create list for IllustrationTxn objects
            var illustrationTxns = new List<IllustrationTxn_Type>();

            // Traditional Life requests always include a Coverage Benefit Txn
            var coverageBenefit = new IllustrationTxn_Type();
            coverageBenefit.CoverageID = coverageId;
            coverageBenefit.IllusTxnPrimaryType = AcordLookupBuilder.BuildFromTC<TC_ILLUSPRIMTYPE>((int)TC_ILLUSPRIMTYPE_TC.ILL_PRI_COV);
            coverageBenefit.IllusTxnSecondaryType = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_COV_TXNAMT);
            coverageBenefit.IllusTxnAmt = (tradPolicy.FaceCode == 1) ? tradPolicy.FaceAmount : 0;
            coverageBenefit.IllusTxnAmtSpecified = true;

            setDateRange(coverageBenefit, tradPolicy);

            // Add to list
            illustrationTxns.Add(coverageBenefit);

            // Traditional Life requests always include a Payment Schedule Txn
            var paymentSchedule = new IllustrationTxn_Type();
            paymentSchedule.CoverageID = coverageId;
            paymentSchedule.IllusTxnPrimaryType = AcordLookupBuilder.BuildFromTC<TC_ILLUSPRIMTYPE>((int)TC_ILLUSPRIMTYPE_TC.ILL_PRI_PMTSCHD);
            paymentSchedule.IllusTxnSecondaryType = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_PMTSCHD_SPECPREM);
            paymentSchedule.IllusTxnAmt = (tradPolicy.FaceCode == 2) ? tradPolicy.PremiumAmount : 0M;
            paymentSchedule.IllusTxnAmtSpecified = true;
            paymentSchedule.IllusTxnMode = AcordLookupBuilder.BuildFromWowString<OLI_LU_PAYMODE>(tradPolicy.PremiumMode.ToString(CultureInfo.InvariantCulture));

            setDateRange(paymentSchedule, tradPolicy);

            // Add to list
            illustrationTxns.Add(paymentSchedule);

            // Per Mark, he's not sure if a base policy can have more than one refund option.
            // Leaving as FirstOrDefault for now; might need to convert to loop later.
            // Per Patty, only one refund option is allowed
            var dataItem = tradPolicy.NonLevelData.FirstOrDefault(d => d.DataTypeCode == DataType.PaymentScheduleTraditional && d.Level == 1);

            // Check for values in NonLevelData to see what else we need to add.
            if (dataItem != null)
            {
                // Add Dividend Option
                var dividendOption = new IllustrationTxn_Type();
                dividendOption.CoverageID = coverageId;
                dividendOption.IllusTxnPrimaryType = AcordLookupBuilder.BuildFromTC<TC_ILLUSPRIMTYPE>((int)TC_ILLUSPRIMTYPE_TC.ILL_PRI_DIVOPT); //16

                var code = dataItem.Codes[0];
                switch (code)       // magic numbers
                {
                    case 101:
                        dividendOption.IllusTxnSecondaryType = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_DIVOPT_PUA); //162
                        break;
                    case 102:
                        dividendOption.IllusTxnSecondaryType = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_DIVOPT_ACCUM); //164
                        break;
                    case 103:
                        dividendOption.IllusTxnSecondaryType = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_DIVOPT_RED); //163
                        break;
                    case 104:
                        dividendOption.IllusTxnSecondaryType = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_DIVOPT_CASH); //161
                        break;
                    default:
                        dividendOption.IllusTxnSecondaryType = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.OLI_OTHER);
                        break;
                }

                // Add extension for 107 - Left With Woodmen at Interest
                if (dividendOption.IllusTxnSecondaryType.tc == TC_ILLUSSECTYPE_TC.OLI_OTHER && code > 0)
                {
                    var fipExt = new AcordIllustrationTxnExtension() { SystemCode = "Woodmen Illustration Service", VendorCode = "FISERV" };

                    fipExt.IllustrationTxnSecondaryType = AcordLookupBuilder.BuildFromWowString<FIP_ILLUS_TXN_SECONDARY_TYPE>(code.ToString());
                    dividendOption.OLifEExtension = new OLifEExtension[] { fipExt };
                }

                dividendOption.IllusTxnAmt = (dataItem.Amounts.Any()) ? dataItem.Amounts[0] : 0M;
                dividendOption.IllusTxnAmtSpecified = true;

                setDateRange(dividendOption, tradPolicy);

                // Add to list
                illustrationTxns.Add(dividendOption);
            }

            return illustrationTxns.ToArray();
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

            if (policy == null)
            {
                throw new ArgumentNullException("policy", "Cannot create inforce illustration Txns for a null policy object.");
            }

            if (string.IsNullOrEmpty(coverageId))
            {
                throw new ArgumentNullException("coverageId", "Cannot create inforce illustration Txns without a valid coverage ID.");
            }

            // Create list for IllustrationTxn objects
            var illustrationTxns = new List<IllustrationTxn_Type>();

            IllustrationTxn_Type previousLevel = null;

            // For each level in this section, we need a Cost Benefit Txn
            foreach (var nlPolicyData in policy.NonLevelPolicyData)
            {
                // Traditional Life requests always include a Coverage Benefit Txn for inforce
                var coverageBenefit = new IllustrationTxn_Type();
                coverageBenefit.CoverageID = coverageId;
                coverageBenefit.IllusTxnPrimaryType = AcordLookupBuilder.BuildFromTC<TC_ILLUSPRIMTYPE>((int)TC_ILLUSPRIMTYPE_TC.ILL_PRI_COV);
                coverageBenefit.IllusTxnSecondaryType = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_COV_TXNAMT);
                coverageBenefit.IllusTxnAmt = nlPolicyData.NonLevelAmounts[0];
                coverageBenefit.IllusTxnAmtSpecified = true;

                // If there was a level before this one, set its end date to this levels effective date.
                if (previousLevel != null)
                {
                    coverageBenefit.StartDate = nlPolicyData.EffectiveDate;
                    previousLevel.EndDate = coverageBenefit.StartDate;
                }
                else
                {
                    coverageBenefit.StartDate = policy.IssueDate;
                }

                coverageBenefit.StartDateSpecified = true;
                coverageBenefit.EndDateSpecified = true;

                // Add to list
                illustrationTxns.Add(coverageBenefit);

                // Reassign the previousLevel to the current level
                previousLevel = coverageBenefit;
            }

            // Outside the foreach, the previousLevel represents the final level. Set the EndDate.
            previousLevel.EndDate = policy.DataDate;

            return illustrationTxns.ToArray();
        }

        private void setDateRange(IllustrationTxn_Type txn, TraditionalLifePolicy tradPolicy)
        {
            int maturityYears = tradPolicy.YearsToMaturity;

            if (tradPolicy.IsInforce)
            {
                txn.StartDate = tradPolicy.DataDate;
                txn.EndDate = tradPolicy.IssueDate.AddYears(maturityYears - tradPolicy.IssueAge - 1);
            }
            else
            {
                txn.StartDate = tradPolicy.SceneModifyDate;
                txn.EndDate = tradPolicy.SceneModifyDate.AddYears(maturityYears - tradPolicy.Client.Age - 1);
            }

            txn.StartDateSpecified = true;
            txn.EndDateSpecified = true;
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

            //
            // Whole life specific logic...
            //

            var wholeLifePolicy = policy as WholeLifePolicy;

            if(wholeLifePolicy != null)
            {
                if (wholeLifePolicy.Is20Pay)
                {
                    return baseDate.AddYears(20);
                }

                if (wholeLifePolicy.Is10Pay)
                {
                    return baseDate.AddYears(10);
                }

                if (wholeLifePolicy.Is2017CsoWholeLifePaidUpAt65)
                {
                    modifier = 65 - baseAge;

                    return baseDate.AddYears(modifier);
                }
            }
            
            //
            // For all other traditional products...
            //

            var durationMaxAge = baseAge + 20;
            
            if (durationMaxAge < 65)
            {
                durationMaxAge = 65;
            }

            modifier = durationMaxAge - baseAge; // find the number of years to add to the base date

            return baseDate.AddYears(modifier);
        }

        
        protected override DateTime CalculateRiderTableRatingEndDate(Illustration.Model.Generation.Request.Policy policy, 
                                                                     DateTime riderDate, 
                                                                     int riderAge)
        {
            if (log.IsInfoEnabled) { log.Info($"CalculateRiderTableRatingEndDate called."); }

            // NOTE: riderAge may be the insured's age or the other insured's age, if Family Term
            // Livio:   this method applies only to Waiver Of Premium and Accidental Death Benefit and are
            //          reserved to the following Whole Life plans:
            //
            //            220	Whole Life Paid Up at 100 (LP100)
            //            221	Whole Life Paid Up at Age 65 (LP65)
            //            222	20 Pay Whole Life (20PL)
            //            223	Single Premium Whole Life (SPWL)
            //            228	Conversion Whole Life Paid UP at 100 (Conv LP 100)
            //            230	Workplace Whole Life Paid Up at 100 (ULP100)
            //            238	Workplace Conversion Whole Life Paid UP at 100 (Conv LP 100)
            //            
            //            280	Whole Life Paid Up at 100 (2017)
            //            281	Whole Life Paid Up at 65 (2017)
            //            282   20 Pay Whole Life (2017)
            //            283	10 Pay Whole Life (2017)
            //            284	Workplace Whole Life Paid Up at 100 (2017)
            //            295	Conversion Whole Life Paid Up at 100 (2017)
            //            296	Workplace Conversion WL Paid Up at 100 (2017)
            //
            //          The WP is issued until age 45 and is paid until age 65.
            //          The ADB is issued until age 55 and is paid until age 70 or for 20 years.

            var modifier = 0;

            //
            // Whole life specific logic...
            //

            var wholeLifePolicy = policy as WholeLifePolicy;

            if (wholeLifePolicy != null)
            {
                // If this is whole life, the other insured rider does not apply
                var baseAge = 0;

                if (policy.IsInforce)
                {
                    baseAge = policy.IssueAge;
                }
                else
                {
                    baseAge = policy.Client.Age;   
                }

                if (wholeLifePolicy.Is20Pay)
                {
                    // This modifier really only applies to inforce requests because
                    // the rider age and the applicant age should be the same for new business illustrations

                    // If the rider age is older than the issue age, account for that when calculating the table rating end date
                    modifier = 20 - (riderAge - baseAge);       // magic number here & around   
                    return riderDate.AddYears(modifier);
                }

                if (wholeLifePolicy.Is10Pay)
                {
                    // This modifier really only applies to inforce requests because
                    // the rider age and the applicant age should be the same for new business illustrations

                    // If the rider age is older than the issue age, account for that when calculating the table rating end date
                    modifier = 10 - (riderAge - baseAge);

                    return riderDate.AddYears(modifier);
                }

                if (wholeLifePolicy.Is2017CsoWholeLifePaidUpAt65)  
                {
                    // A table rating should not be requested on a rider that is added after the paid up age per Patty P.
                    // If it is, an exception will be thrown
                    modifier = 65 - riderAge;

                    if(modifier < 0)
                    {
                        throw new AcordRequestFactoryException($"Error calculating the end date of a rider tabling rating. Rider age '{riderAge}' exceeds 65 for certificate '{wholeLifePolicy.PolicyNumber}'. This is an unexpected condition.");
                    }

                    return riderDate.AddYears(modifier);
                }
            }

            //
            // For all other traditional products...
            //
            
            var durationMaxAge = riderAge + 20;

            if (durationMaxAge < 65)
            {
                durationMaxAge = 65;
            }
            //Livio:
            else
            {
                if (durationMaxAge > 70)
                    //  this happens only with Whole Life Table Rated Accidental Death Rider, because
                    //  of the Max Issue Age (45) of the WP.
                    durationMaxAge = 70;
            }
            //--------------------------
            modifier = durationMaxAge - riderAge; // find the number of years to add to the base date

            return riderDate.AddYears(modifier);
        }

    }
}