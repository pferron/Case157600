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

namespace WOW.WoodmenIllustrationService.Builders
{
    public class AnnuityAcordFactory : BaseAcordFactory
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(AnnuityAcordFactory));

        internal AnnuityAcordFactory()
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
            var annuityPolicy = (AnnuityPolicy)policy;

            var dataItem = annuityPolicy.NonLevelData.FirstOrDefault(d => d.DataTypeCode == DataType.PaymentSchedule);

            if (dataItem != null)
            {
                holding.Policy.PaymentMode = AcordLookupBuilder.BuildFromWowString<OLI_LU_PAYMODE>(dataItem.Codes[1].ToString(CultureInfo.InvariantCulture));
                holding.Policy.PaymentMethod = AcordLookupBuilder.BuildFromTC<OLI_LU_PAYMETHOD>((int)OLI_LU_PAYMETHOD_TC.OLI_PAYMETH_REGBILL);
                holding.Policy.PaymentAmt = (dataItem != null) ? dataItem.Amounts[0] : 0M;
                holding.Policy.PaymentAmtSpecified = (dataItem.Amounts[0] > 0M);
                holding.Policy.Item = HydrateAnnuityData(annuityPolicy);
            }

            holding.Policy.OLifEExtension = HydratePolicyExtensionData(annuityPolicy);

            return holdings.ToArray();
        }

        private Annuity_Type HydrateAnnuityData(AnnuityPolicy policy)
        {
            var annuity = new Annuity_Type();

            annuity.id = "AnnuityCoverage1";
            annuity.PremType = AcordLookupBuilder.BuildFromWowString<OLI_LU_ANNPREM>(policy.HeaderCode.ToString(CultureInfo.InvariantCulture));
            annuity.PayoutType = AcordLookupBuilder.BuildFromWowString<OLI_LU_ANNPAYOUT>(policy.HeaderCode.ToString(CultureInfo.InvariantCulture));
            annuity.QualPlanType = AcordLookupBuilder.BuildFromWowString<OLI_LU_QUALPLAN>(policy.ClassType.ToString(CultureInfo.InvariantCulture));
            annuity.InitDepositAmt = policy.InitialPremium;
            annuity.InitDepositAmtSpecified = (policy.InitialPremium > 0M);
            // StoneRiver indicated that this does not map to anything on the FIP side
            //data.TotalDepositITD = 0M;

            var extensions = new List<OLifEExtension>();
            var fipExt = new AcordAnnuityExtension() { SystemCode = "Woodmen Illustration Service", VendorCode = "FISERV" };
            extensions.Add(fipExt);

            if (policy.InitialGuaranteePeriod.HasValue)
            {
                fipExt.InitialGuaranteeIntPeriod = AcordLookupBuilder.BuildFromWowString<INIT_GUAR_INT_PERIOD_TYPE>(policy.InitialGuaranteePeriod.Value.ToString(CultureInfo.InvariantCulture));
            }

            fipExt.AnnuityRateCode = AcordLookupBuilder.BuildFromWowString<ANNUITY_RATE_CODE_TYPE>(policy.AnnuityRateCode.ToString(CultureInfo.InvariantCulture));

            if (fipExt.AnnuityRateCode.tc == 0)
            {
                fipExt.AnnuityRateCode = null;
            }

            fipExt.DeferAnnuityCertificateYear = AcordLookupBuilder.BuildFromWowString<DEFER_ANNUITY_CERT_YEAR_TYPE>(policy.DeferredAnnuityCertainYear.ToString(CultureInfo.InvariantCulture));
            fipExt.SurvivorPercentage = policy.PrimaryPercent;

            if (annuity.QualPlanType.tc == OLI_LU_QUALPLAN_TC.OLI_OTHER)
            {
                fipExt.QualifiedPlanType = AcordLookupBuilder.BuildFromWowString<FIP_QUAL_PLAN_TYPE>(policy.ClassType.ToString(CultureInfo.InvariantCulture));
            }

            if (policy.HeaderBandRates.Count > 0)
            {
                fipExt.InitialGuaranteeRate = policy.HeaderBandRates[0];
            }

            fipExt.SecondaryGuaranteedRate = policy.SecondaryGuaranteeRate;
            fipExt.BonusRate = policy.BonusRate;
            fipExt.MinimumGuaranteedRate = policy.MinimumGuaranteeRate;

            annuity.OLifEExtension = extensions.ToArray();

            annuity.Payout = HydratePayoutData(policy);

            // Now that the Coverage has been added, we need to populate the related Txns
            illustrationRequest.IllustrationTxn = HydrateIllustrationTxns(policy, annuity.id);

            return annuity;
        }

        private Payout_Type[] HydratePayoutData(AnnuityPolicy policy)
        {
            // Create lists for arrays of data
            var payouts = new List<Payout_Type>();
            var participants = new List<Participant>();
            var periodCertainItems = new List<PeriodCertainCC_Type>();

            // Create single payout object
            var payout = new Payout_Type();
            payouts.Add(payout);

            // Select relevant non-level data
            //var nlData = policy.NonLevelData.FirstOrDefault(d => d.DataTypeCode == 2);

            // We don't do SPIA now, but I coded for it.
            //payout.PayoutAmt = policy.SinglePremiumImmediateAnnuityIncome;
            //payout.PayoutMode = (nlData != null) ? AcordLookupBuilder.BuildFromWowString<OLI_LU_PAYMODE>(nlData.Codes[1].ToString(CultureInfo.InvariantCulture)) : AcordLookupBuilder.BuildFromTC<OLI_LU_PAYMODE>((int)OLI_LU_PAYMODE_TC.OLI_OTHER);
            payout.PayoutAge = policy.SettlementAge.ToString(CultureInfo.InvariantCulture);
            //payout.PayoutAmtSpecified = (policy.SinglePremiumImmediateAnnuityIncome > 0);

            // Build participants
            // Writing agent
            var agent = new Participant();
            agent.PartyID = agentId;
            agent.ParticipantRoleCode = AcordLookupBuilder.BuildFromTC<OLI_LU_PARTICROLE>((int)OLI_LU_PARTICROLE_TC.OLI_PARTICROLE_PRIMAGENT);

            participants.Add(agent);

            // Member/Client/Party
            var party = new Participant();
            party.PartyID = primaryInsuredId;
            party.ParticipantRoleCode = AcordLookupBuilder.BuildFromTC<OLI_LU_PARTICROLE>((int)OLI_LU_PARTICROLE_TC.OLI_PARTICROLE_ANNUITANT);

            participants.Add(party);

            // Do we need to add support for joint annuitants?
            // Per Patty: I checked with the Annuity department and found that we do not sell a product that has a Joint Annuitant.
            // (The one I was talking about is actually a Joint Owner) I was told we have not sold that product for years and they do not see us selling it in the future.
            // I would say we do not need to code for it.

            // PeriodCertain data
            var periodCertainData = new PeriodCertainCC_Type();
            periodCertainData.PeriodCertainMode = AcordLookupBuilder.BuildFromTC<OLI_LU_PAYMODE>((int)OLI_LU_PAYMODE_TC.OLI_PAYMODE_MNTHLY);
            periodCertainData.PeriodCertainPeriods = policy.CertainYear.ToString(CultureInfo.InvariantCulture);
            periodCertainItems.Add(periodCertainData);

            // Convert lists to arrays
            payout.Participant = participants.ToArray();
            payout.PeriodCertainCC = periodCertainItems.ToArray();

            return payouts.ToArray();
        }

        private OLifEExtension[] HydratePolicyExtensionData(AnnuityPolicy policy)
        {
            // Create custom extension object
            var fipExt = new AcordPolicyExtension() { SystemCode = "Woodmen Illustration Service", VendorCode = "FISERV" };

            //<FIP:TemplateID>
            fipExt.TemplateId = templateIds.Single(t => t.IsInforce == policy.IsInforce && t.HeaderCode == policy.HeaderCode).TemplateId;

            //<FIP:NbrOwners>
            fipExt.NumberOfOwners = policy.NumberOfOwners;

            // Required for batch mode
            fipExt.SceneModifyDate = policy.SceneModifyDate;

            return new OLifEExtension[] { fipExt };
        }

        protected override IllustrationTxn_Type[] HydrateIllustrationTxns(WOW.Illustration.Model.Generation.Request.Policy policy, string coverageId)
        {
            if (log.IsInfoEnabled) { log.Info($"HydrateIllustrationTxns called."); }

            var annuityPolicy = (AnnuityPolicy)policy;

            // Create list for IllustrationTxn objects
            var illustrationTxns = new List<IllustrationTxn_Type>();

            // Coverages are indicated in the NonLevelData section of FIP.
            // Payment Schedule and Distribution are expected values
            illustrationTxns.AddRange(HydratePaymentSchedules(annuityPolicy, coverageId));

            illustrationTxns.AddRange(HydrateDistributions(annuityPolicy, coverageId));

            return illustrationTxns.ToArray();
        }

        private static IList<IllustrationTxn_Type> HydrateDistributions(AnnuityPolicy annuityPolicy, string coverageId)
        {
            var distributionItems = new List<IllustrationTxn_Type>();

            // If there's a second distribution, we need this date from the previous nldata item
            var previousDistributionEndDate = DateTime.MinValue;

            // Check for Distributions
            // There can be many distributions
            // The levels are important, so I ordered by them.
            foreach (var nonLevelDataItem in annuityPolicy.NonLevelData.Where(d => d.DataTypeCode == DataType.PartialSurrender).OrderBy(d => d.Level))
            {
                // Add Distribution
                var distribution = new IllustrationTxn_Type();
                distribution.CoverageID = coverageId;
                distribution.IllusTxnPrimaryType = AcordLookupBuilder.BuildFromTC<TC_ILLUSPRIMTYPE>((int)TC_ILLUSPRIMTYPE_TC.ILL_PRI_DIST);
                distribution.IllusTxnSecondaryType = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_DIST_SURRPARTIAL);
                distribution.IllusTxnAmt = nonLevelDataItem.Amounts[0];
                distribution.IllusTxnAmtSpecified = true;


                if (previousDistributionEndDate == DateTime.MinValue)
                {
                    // We're adding the first distribution
                    distribution.StartDate = (annuityPolicy.IssueDate > DateTime.MinValue) ? annuityPolicy.IssueDate : annuityPolicy.SceneModifyDate;
                }
                else
                {
                    // We're adding an additional distribution
                    distribution.StartDate = previousDistributionEndDate;
                }

                distribution.StartDateSpecified = true;
                distribution.EndDate = annuityPolicy.IssueDate.AddYears(nonLevelDataItem.Age - annuityPolicy.IssueAge);
                distribution.EndDateSpecified = true;

                // Set end date for next pass
                previousDistributionEndDate = distribution.EndDate;

                // Add to list
                distributionItems.Add(distribution);
            }

            return distributionItems;
        }

        private static IList<IllustrationTxn_Type> HydratePaymentSchedules(AnnuityPolicy annuityPolicy, string coverageId)
        {
            // Payment schedule
            // DataTypeCode 2 can appear multiple times with different levels and ages.
            var txns = new List<IllustrationTxn_Type>();

            // If there's a second payment schedule, we need this date from the previous nldata item
            var previousPaymentScheduleEndDate = DateTime.MinValue;

            foreach (var nonLevelDataItem in annuityPolicy.NonLevelData.Where(d => d.DataTypeCode == DataType.PaymentSchedule))
            {
                var paymentSchedule = new IllustrationTxn_Type();

                paymentSchedule.CoverageID = coverageId;
                paymentSchedule.IllusTxnPrimaryType = AcordLookupBuilder.BuildFromTC<TC_ILLUSPRIMTYPE>((int)TC_ILLUSPRIMTYPE_TC.ILL_PRI_PMTSCHD); //3

                if (nonLevelDataItem.Codes.Any())
                {
                    // Can't use WOW mapping here because of overlap with the NLCode number with other DataTypeCodes
                    switch (nonLevelDataItem.Codes[0])
                    {
                        case 1:
                            paymentSchedule.IllusTxnSecondaryType = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_PMTSCHD_SPECPREM); //30
                            break;
                        case 2:
                            paymentSchedule.IllusTxnSecondaryType = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_PMTSCHD_GLP); //39
                            break;
                        case 3:
                            paymentSchedule.IllusTxnSecondaryType = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_PMTSCHD_MPREM); //34
                            break;
                        case 4:
                            paymentSchedule.IllusTxnSecondaryType = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_PMTSCHD_TRGTPREM); //35
                            break;
                        case 6:
                            paymentSchedule.IllusTxnSecondaryType = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.ILL_SEC_PMTSCHD_PREM7PAY); //36
                            break;
                        default:
                            paymentSchedule.IllusTxnSecondaryType = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)TC_ILLUSSECTYPE_TC.OLI_OTHER);
                            break;
                    }

                    paymentSchedule.IllusTxnMode = AcordLookupBuilder.BuildFromWowString<OLI_LU_PAYMODE>(nonLevelDataItem.Codes[1].ToString(CultureInfo.InvariantCulture));

                    if (paymentSchedule.IllusTxnSecondaryType.tc == TC_ILLUSSECTYPE_TC.OLI_OTHER)
                    {
                        // Add vendor extension
                        //FIP:FIPIllusTxnSecondaryType		NLCode_1
                        var fipExt = new AcordIllustrationTxnExtension() { SystemCode = "Woodmen Illustration Service", VendorCode = "FISERV" };

                        fipExt.IllustrationTxnSecondaryType = AcordLookupBuilder.BuildFromWowString<FIP_ILLUS_TXN_SECONDARY_TYPE>(nonLevelDataItem.Codes[0].ToString());

                        // The mapping here is for a SearchData section of the FIP file. That section is used during the sales process, per Rudy.
                        // The policy objects don't have a search data collection on them. Skipping for now, per Rudy.
                        //8 - IRS RMD (Cash flow option)			Test Case 111-SPDA2008-2.xml
                        //for [NonlevelData]/DataType=3 if  if [SearchData]/SearchType    = 8
                        //ext.IllustrationTxnTertiaryType = AcordLookupBuilder.BuildFromTC<FIP_ILLUS_TXN_TERTIARY_TYPE>((int)FIP_ILLUS_TXN_TERTIARY_TYPE_TC.RequiredMinimumDistribution);

                        paymentSchedule.OLifEExtension = new OLifEExtension[] { fipExt };
                    }
                }
                else
                {
                    throw new AcordRequestFactoryException(string.Format(CultureInfo.InvariantCulture, "NonLevelData Codes list is empty. Cannot create IllustrationTxn element. Certificate: {0}", annuityPolicy.PolicyNumber));
                }

                if (nonLevelDataItem.Amounts.Any())
                {
                    paymentSchedule.IllusTxnAmt = nonLevelDataItem.Amounts[0];
                    paymentSchedule.IllusTxnAmtSpecified = true;
                }
                else
                {
                    throw new AcordRequestFactoryException(string.Format(CultureInfo.InvariantCulture, "NonLevelData Amounts list is empty. Cannot create IllustrationTxn element. Certificate: {0}", annuityPolicy.PolicyNumber));
                }

                DateTime startDate;
                if (previousPaymentScheduleEndDate == DateTime.MinValue)
                {
                    // We're adding the first paymentSchedule
                    startDate = (annuityPolicy.IsInforce) ? annuityPolicy.IssueDate : annuityPolicy.SceneModifyDate;
                }
                else
                {
                    // We're adding an additional paymentSchedule
                    startDate = previousPaymentScheduleEndDate;
                }
                paymentSchedule.StartDate = startDate;
                paymentSchedule.StartDateSpecified = true;

                int baseAge;

                if (annuityPolicy.IsInforce)
                {
                    baseAge = annuityPolicy.IssueAge;
                }
                else
                {
                    baseAge = annuityPolicy.Client.Age;
                }

                paymentSchedule.EndDate = paymentSchedule.StartDate.AddYears(nonLevelDataItem.Age - baseAge);
                paymentSchedule.EndDateSpecified = true;

                // Set end date for next pass
                previousPaymentScheduleEndDate = paymentSchedule.EndDate;

                // Add to list
                txns.Add(paymentSchedule);
            }

            return txns;
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