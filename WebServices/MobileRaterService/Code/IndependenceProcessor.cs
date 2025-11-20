using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using WOW.Illustration.Model.Enums;
using WOW.Illustration.Model.Generation.Request;
using WOW.Illustration.Model.Generation.Response;
using WOW.MobileRaterService.Builders;
using WOW.MobileRaterService.Data;
using WOW.MobileRaterService.Models;
using WOW.MobileRaterService.Properties;
using WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Requests;
using WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Responses;

namespace WOW.MobileRaterService.Code
{
    internal static class IndependenceProcessor
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(IndependenceProcessor));

        internal static List<RateResponse> CreateIndependenceResponse(IndependenceRateInput indInput)
        {
            if (logger.IsDebugEnabled) logger.Debug($"{nameof(CreateIndependenceResponse)} called with input: {indInput}.");

            // First, log the request
            var requestId = StatsHandler.LogRequest(indInput);

            List<RateResponse> rateResponses = new List<RateResponse>();

            var independencePlans = MobileRaterServiceConfiguration.Plans.Where(p => p.Rater == "IND").ToList();

            foreach(var plan in independencePlans)
            {
                ValidationInput validationInput = ServiceInputValidator.BuildCheckInputs(indInput, plan);

                bool isGDB = (plan.PlanId.IndexOf("GDB", StringComparison.InvariantCultureIgnoreCase) >= 0);
                bool isRatingRed = (indInput.RatingClass.IndexOf("RED", StringComparison.InvariantCultureIgnoreCase) >= 0);

                if (isGDB && !isRatingRed)
                {
                    continue;
                }

                if (!isGDB && isRatingRed)
                {
                    continue;
                }

                // See if there are any validation results for the input values
                var validations = ServiceInputValidator.ValidateInput(validationInput);

                foreach (var validation in validations)
                {
                    // Convert input model to WOW Illustration request
                    Policy policy = BuildPolicy(indInput, plan);

                    if (logger.IsDebugEnabled) logger.Debug($"Converted Generation Request: {policy}");

                    // Create RateResponse for each WOW Illustration response; parse rate value
                    RateResponse rateResponse = new RateResponse();
                    policy.NonLevelData.Add(CommonProcessor.SetWholeLifeNonLevelData());

                    int adRating = 0;

                    if (indInput.HasAccidentalDeathRider)
                    {
                        adRating = CommonProcessor.ConvertIndependenceADRating(indInput);

                        if(adRating > 0)
                        {
                            policy.Riders.Add(CommonProcessor.AddWLADRider(policy as WholeLifePolicy, validationInput));
                        }
                    }

                    // Send WOW Illustration request to WIS
                    WoodmenIllustrationResponse wisResponse = CommonProcessor.PostRequest(policy);

                    // Add RateResponse to list collection

                    rateResponse.FaceAmount = indInput.FaceAmount;
                    rateResponse.ProductName = (String.IsNullOrWhiteSpace(plan.DisplayName)) ? plan.PlanId : plan.DisplayName;
                    rateResponse.HasEmbeddedDues = plan.HasEmbeddedDues;

                    if (wisResponse == null)
                    {
                        rateResponse.HasError = true;
                    }
                    else
                    {
                        rateResponse.Rate = CommonProcessor.ProcessIllustrationResponse(wisResponse);

                        if (logger.IsDebugEnabled)
                        {
                            if (Settings.Default.GeneratePDF && policy.GeneratePdf)
                            {
                                CommonProcessor.SavePDF(wisResponse, plan.PlanId);
                            }
                        }

                        rateResponse.HasAccidentalDeath = indInput.HasAccidentalDeathRider;

                        // Need to suppress successful LPA responses with zero rates in case product table is incorrect or LPA changes
                        if (rateResponse.Rate > 0M)
                        {
                            rateResponses.Add(rateResponse);
                        }
                    }
                }
            }

            foreach (RateResponse response in rateResponses)
            {
                response.recordID = requestId;
            }

            return rateResponses;
        }

        // Build and return a specific policy type for a specific product type
        internal static Policy BuildPolicy(IndependenceRateInput indInput, SupportedPlan plan)
        {
            if (logger.IsDebugEnabled) logger.Debug($"BuildPolicy called with IndependenceRateInput: {indInput.ToString()} HeaderCode: {plan.HeaderCode}.");

            Policy policy;

            PolicyBuilders builder = new PolicyBuilders();

            policy = builder.BuildWholeLifePolicy(indInput, plan);
            
            return policy;
        }

        private static void EnhanceWholeLifePolicy(WholeLifePolicy wlPolicy, Validation validation)
        {
            // Placeholder method for adding additional information needed for Whole Life submission
        }
    }
}