using log4net;
using System;
using System.Linq;
using System.Collections.Generic;
using WOW.Illustration.Model.Enums;
using WOW.Illustration.Model.Generation.Request;
using WOW.Illustration.Model.Generation.Response;
using WOW.MobileRaterService.Builders;
using WOW.MobileRaterService.Models;
using WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Requests;
using WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Responses;
using WOW.MobileRaterService.Exceptions;
using WOW.MobileRaterService.Data;
using WOW.MobileRaterService.Properties;

namespace WOW.MobileRaterService.Code
{
    internal static class LifeRateProcessor
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(LifeRateProcessor));

        internal static List<RateResponse> CreateLifeRateResponse(LifeRateInput lrInput, int headerCode = 0, DateTime? rateDeterminationDate = null)
        {
            // First, log the request
            var requestId = StatsHandler.LogRequest(lrInput);

            List<RateResponse> rateResponses = new List<RateResponse>();
            List<SupportedPlan> supportedPlans;

            if (headerCode == 0)
            {
                supportedPlans = MobileRaterServiceConfiguration.Plans.Where(p => p.Rater == "LR").ToList();
            }
            else
            {
                supportedPlans = MobileRaterServiceConfiguration.Plans.Where(p => p.Rater == "LR" && p.HeaderCode == headerCode).ToList();
            }            

            var sortedSupportedPlans = supportedPlans.OrderBy(b => b.HeaderCode);

            foreach (var plan in sortedSupportedPlans)
            {
                // Build query model to be used for validating input values
                ValidationInput validationInput = ServiceInputValidator.BuildCheckInputs(lrInput, plan);

                // See if there are any validation results for the input values
                var validations = ServiceInputValidator.ValidateInput(validationInput);

                // Validate the input model
                // If valid then convert each header code into a WOW Illustration request
                foreach (var validation in validations)
                {
                    // Convert input model to WOW Illustration request
                    var policy = BuildPolicy(lrInput, plan);

                    if (rateDeterminationDate != null)
                    {
                        policy.IssueDate = rateDeterminationDate.Value;
                        policy.SceneModifyDate = rateDeterminationDate.Value;
                    }

                    if (logger.IsDebugEnabled) logger.Debug($"Converted Generation Request {policy}");

                    WoodmenIllustrationResponse wisResponse = null;

                    // Create RateResponse for each WOW Illustration response; parse rate value
                    if (policy is WholeLifePolicy)
                    {
                        // Add additional criteria based upon the returned validation values
                        policy = EnhanceWholeLifePolicy(policy as WholeLifePolicy, validation, lrInput);

                    }
                    else if (policy is TermLifePolicy)
                    {
                        // Add additional criteria based upon the returned validation values
                        policy = EnhanceTermLifePolicy(policy as TermLifePolicy, validation, lrInput);
                    }
                    else if (policy is NoLapseGuaranteedUniversalLifePolicy)
                    {
                        // Need additional age check for NLG80, NLG100, NLG120
                        //Age + 20 >= duration
                        if(policy.IssueAge + 20 >= plan.Duration)
                        {
                            if(logger.IsDebugEnabled) { logger.Debug($"Skipping NLG request due to age. RequestID: {policy.RequestId}, IssueAge: {policy.IssueAge}, PlanID: {plan.PlanId}, Duration: {plan.Duration}"); }

                            continue;
                        }

                        // Add additional criteria based upon the returned validation values
                        policy = EnhanceNoLapsePolicy(policy as NoLapseGuaranteedUniversalLifePolicy, validation, lrInput, plan.PlanId);
                    }
                    else if (policy is AccumulationUniversalLifePolicy)
                    {
                        // Add additional criteria based upon the returned validation values
                        policy = EnhanceAULPolicy(policy as AccumulationUniversalLifePolicy, validation, lrInput, plan.PlanId);
                    }
                    else if (policy is IndexedUniversalLifePolicy)
                    {
                        policy = EnhanceIULPolicy(policy as IndexedUniversalLifePolicy, validation, lrInput, plan.PlanId);
                    }

                    // Send WOW Illustration request to WIS
                    wisResponse = CommonProcessor.PostRequest(policy);

                    var rateResponse = new RateResponse();
                    rateResponse = SetRiderFlags(rateResponse, validation);

                    // Add RateResponse to list collection
                    rateResponse.FaceAmount = lrInput.FaceAmount;
                    rateResponse.ProductName = (String.IsNullOrEmpty(plan.DisplayName)) ? plan.PlanId : plan.DisplayName;
                    rateResponse.HasEmbeddedDues = plan.HasEmbeddedDues;

                    if (wisResponse == null)
                    {
                        rateResponse.HasError = true;
                    }
                    else
                    {
                        if (Settings.Default.GeneratePDF && policy.GeneratePdf)
                        {
                            CommonProcessor.SavePDF(wisResponse, plan.PlanId);
                        }

                        rateResponse.Rate = CommonProcessor.ProcessIllustrationResponse(wisResponse);

                        // Add dues to rate for UL unless no rate was returned from LPA
                        if ((policy is AccumulationUniversalLifePolicy || policy is NoLapseGuaranteedUniversalLifePolicy || policy is IndexedUniversalLifePolicy) && rateResponse.Rate > 0M)
                        {
                            rateResponse.Rate = AddDuesToRate(rateResponse.Rate, CommonProcessor.ConvertPaymentMode(lrInput.PaymentMode), policy.FraternalDues);
                        }
                    }

                    if (rateResponse.Rate > 0M)
                    {
                        rateResponses.Add(rateResponse);
                    }
                }
            }

            // Add request GUID to responses to make the appointment button work
            foreach (RateResponse response in rateResponses)
            {
                response.recordID = requestId;
            }

            return rateResponses;
        }

        private static decimal AddDuesToRate(decimal rate, string billMode, decimal fraternalDues)
        {
            if (rate == 0)
            {
                return rate;
            }
            else
            {
                decimal divByMonths = 0M;

                switch (billMode.ToUpperInvariant())
                {
                    case "M":
                        divByMonths = 12;
                        break;
                    case "Q":
                        divByMonths = 4;
                        break;
                    case "S":
                        divByMonths = 2;
                        break;
                    case "A":
                        divByMonths = 1;
                        break;
                    default:
                        throw new InvalidModeException("Unexpected billimg mode encountered");

                }

                var newRate = rate + (fraternalDues / divByMonths);

                if(logger.IsDebugEnabled) { logger.DebugFormat("AddDuesToRate: Rate: {0:C}, Dues: {1:C}, NewRate: {2:C}", rate, fraternalDues, newRate); }

                return newRate;
            }
        }

        // Build and return a specific policy type for a specific product type
        internal static Policy BuildPolicy(LifeRateInput lrInput, SupportedPlan plan)
        {
            if (logger.IsDebugEnabled) logger.Debug($"BuildPolicy called with LifeRateInput: {lrInput.ToString()} HeaderCode: {plan.HeaderCode}.");

            Policy policy;

            PolicyBuilders builder = new PolicyBuilders();

            switch (plan.InsuranceType.ToUpper())
            {
                case "NLGUL":
                    policy = builder.BuildNLGULPolicy(lrInput, plan.HeaderCode);
                    break;
                case "AUL":
                    policy = builder.BuildAULPolicy(lrInput, plan.HeaderCode);
                    break;
                case "WL":
                    policy = builder.BuildWholeLifePolicy(lrInput, plan);
                    break;
                case "TERM":
                    policy = builder.BuildTermPolicy(lrInput, plan.HeaderCode);
                    break;
                case "IUL":
                    policy = builder.BuildIULPolicy(lrInput, plan.HeaderCode);
                    break;
                default:
                    throw new InvalidOperationException($"Unexpected Insurance Type: '{plan.InsuranceType}'");
            }

            return policy;
        }

        private static WholeLifePolicy EnhanceWholeLifePolicy(WholeLifePolicy wlPolicy, Validation validation, LifeRateInput lrInput)
        {
            PolicyBuilders builder = new PolicyBuilders();

            if (validation.AccidentalDeathRating > 0)
            {
                Rider wlADB = new Rider();
                wlADB = builder.BuildWlADBRider(wlPolicy, lrInput);
                wlPolicy.Riders.Add(wlADB);
            }
            if (validation.WaiverPremiumRating > 0)
            {
                Rider wlWP = new Rider();
                wlWP = builder.BuildWLWPRider(wlPolicy, lrInput);
                wlPolicy.Riders.Add(wlWP);
            }
            if (validation.IsAIO == true)
            {
                Rider wlAIO = new Rider();
                wlAIO = builder.BuildWLAIORider(wlPolicy, lrInput);
                wlPolicy.Riders.Add(wlAIO);
            }
            if (validation.ApplicantWaiverRating > 0)
            {
                Rider wlAppWaiver = new Rider();
                wlAppWaiver = builder.BuildwlAppWaiverRider(wlPolicy, lrInput);
                wlPolicy.Riders.Add(wlAppWaiver);
            }

            wlPolicy.NonLevelData.Add(CommonProcessor.SetWholeLifeNonLevelData());

            return wlPolicy;

        }

        private static TermLifePolicy EnhanceTermLifePolicy(TermLifePolicy termPolicy, Validation validation, LifeRateInput lrInput)
        {
            PolicyBuilders builder = new PolicyBuilders();

            if (validation.AccidentalDeathRating > 0)
            {
                Rider wlADB = new Rider();
                wlADB = builder.BuildTermADBRider(termPolicy, lrInput);
                termPolicy.Riders.Add(wlADB);
            }
            if (validation.WaiverPremiumRating > 0)
            {
                Rider wlWP = new Rider();
                wlWP = builder.BuildTermWPRider(termPolicy, lrInput);
                termPolicy.Riders.Add(wlWP);
            }
            if (validation.IsAIO == true)
            {
                Rider wlAIO = new Rider();
                wlAIO = builder.BuildTermAIORider(termPolicy, lrInput);
                termPolicy.Riders.Add(wlAIO);
            }
            if (validation.ApplicantWaiverRating > 0)
            {
                Rider wlAppWaiver = new Rider();
                wlAppWaiver = builder.BuildTermAppWaiverRider(termPolicy, lrInput);
                termPolicy.Riders.Add(wlAppWaiver);
            }

            termPolicy.NonLevelData.Add(CommonProcessor.SetTermNonLevelData());

            return termPolicy;
        }

        internal static RateResponse SetRiderFlags(RateResponse tradResponse, Validation validation)
        {
            if (logger.IsDebugEnabled) logger.Debug($"SetRiderFlags called with headercode: {validation.HeaderCode}");

            if (validation.AccidentalDeathRating > 0)
            {
                tradResponse.HasAccidentalDeath = true;
            }
            if (validation.WaiverPremiumRating > 0)
            {
                tradResponse.HasWaiverPremium = true;
            }
            if (validation.ApplicantWaiverRating > 0)
            {
                tradResponse.HasApplicantWaiver = true;
            }
            if (validation.IsAIO)
            {
                tradResponse.HasAioGir = true;
            }
            if (validation.WaiverMonthlyDeductionRating > 0)
            {
                tradResponse.HasWaiverDeduction = true;
            }

            return tradResponse;
        }

        private static NoLapseGuaranteedUniversalLifePolicy EnhanceNoLapsePolicy(NoLapseGuaranteedUniversalLifePolicy nlgulPolicy, Validation validation, LifeRateInput lrInput, string planID)
        {
            PolicyBuilders builder = new PolicyBuilders();

            if (validation.AccidentalDeathRating > 0)
            {
                Rider wlADB = new Rider();
                wlADB = builder.BuildNlgulADBRider(nlgulPolicy, lrInput);
                nlgulPolicy.Riders.Add(wlADB);
            }
            if (validation.WaiverMonthlyDeductionRating > 0)
            {
                Rider wlWP = new Rider();
                wlWP = builder.BuildNlgulWMDRider(nlgulPolicy, lrInput);
                nlgulPolicy.Riders.Add(wlWP);
            }
            nlgulPolicy = CommonProcessor.SetNLGULNonLevelData(lrInput, planID, nlgulPolicy);
            return nlgulPolicy;
        }

        private static AccumulationUniversalLifePolicy EnhanceAULPolicy(AccumulationUniversalLifePolicy aulPolicy, Validation validation, LifeRateInput lrInput, string planID)
        {
            PolicyBuilders builder = new PolicyBuilders();

            if (validation.AccidentalDeathRating.HasValue)
            {
                if (validation.AccidentalDeathRating.Value > 0)
                {
                    Rider aulADB = new Rider();
                    aulADB = builder.BuildAulADBRider(aulPolicy, lrInput);
                    aulPolicy.Riders.Add(aulADB);
                }
            }
            if (validation.WaiverMonthlyDeductionRating.HasValue )
            {
                if (validation.WaiverMonthlyDeductionRating.Value > 0)
                {
                    Rider aulWMD = new Rider();
                    aulWMD = builder.BuildAulWMDRider(aulPolicy, lrInput);
                    aulPolicy.Riders.Add(aulWMD);
                }
            }
            if (validation.IsAIO == true)
            {
                Rider aulAIO = new Rider();
                aulAIO = builder.BuildAulGIRRider(aulPolicy, lrInput);
                aulPolicy.Riders.Add(aulAIO);
            }
            if (validation.ApplicantWaiverRating.HasValue)
            {   if (validation.ApplicantWaiverRating.Value > 0)
                {
                    Rider aulAppWaiver = new Rider();
                    aulAppWaiver = builder.BuildAulAppWaiverRider(aulPolicy, lrInput);
                    aulPolicy.Riders.Add(aulAppWaiver);
                }
            }
            aulPolicy = CommonProcessor.SetAULNonLevelData(lrInput, planID, aulPolicy);

            return aulPolicy;
        }

        private static IndexedUniversalLifePolicy EnhanceIULPolicy(IndexedUniversalLifePolicy iulPolicy, Validation validation, LifeRateInput lrInput, string planID)
        {
            PolicyBuilders builder = new PolicyBuilders();

            if (validation.AccidentalDeathRating.HasValue)
            {
                if (validation.AccidentalDeathRating.Value > 0)
                {
                    Rider aulADB = new Rider();
                    aulADB = builder.BuildIulADBRider(iulPolicy, lrInput);
                    iulPolicy.Riders.Add(aulADB);
                }
            }
            if (validation.WaiverMonthlyDeductionRating.HasValue)
            {
                if (validation.WaiverMonthlyDeductionRating.Value > 0)
                {
                    Rider aulWMD = new Rider();
                    aulWMD = builder.BuildIulWMDRider(iulPolicy, lrInput);
                    iulPolicy.Riders.Add(aulWMD);
                }
            }
            if (validation.IsAIO == true)
            {
                Rider aulAIO = new Rider();
                aulAIO = builder.BuildIulGIRRider(iulPolicy, lrInput);
                iulPolicy.Riders.Add(aulAIO);
            }
            if (validation.ApplicantWaiverRating.HasValue)
            {
                if (validation.ApplicantWaiverRating.Value > 0)
                {
                    Rider aulAppWaiver = new Rider();
                    aulAppWaiver = builder.BuildIulAppWaiverRider(iulPolicy, lrInput);
                    iulPolicy.Riders.Add(aulAppWaiver);
                }
            }
            iulPolicy = CommonProcessor.SetIULNonLevelData(lrInput, planID, iulPolicy);

            // We must define the two fund accounts
            SubAccount subAccount1 = new SubAccount();
            subAccount1.ProductCode = "100";
            subAccount1.AllocPercent = 50.0M;
            iulPolicy.SubAccounts.Add(subAccount1);

            SubAccount subAccount2 = new SubAccount();
            subAccount2.ProductCode = "200";
            subAccount2.AllocPercent = 50.0M;
            iulPolicy.SubAccounts.Add(subAccount2);

            return iulPolicy;
        }

    }
}