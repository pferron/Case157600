using System;
using log4net;
using System.Collections.Generic;
using WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Requests;
using WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Responses;
using WOW.MobileRaterService.Properties;
using WOW.Illustration.Model.Generation.Request;
using WOW.MobileRaterService.Data;
using WOW.Illustration.Model.Enums;
using WOW.Illustration.Model.Generation.Response;
using System.Linq;
using System.Text;
using WOW.MobileRaterService.ValuesFileParser;
using WOW.MobileRaterService.Models;
using WOW.MobileRaterService.Code;

namespace WOW.MobileRaterService.Builders
{
    public static class PatriotProcessor
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(PatriotProcessor));

        internal static List<RateResponse> CreatePatriotResponse(PatriotInput patriotInput)
        {
            if (logger.IsDebugEnabled) logger.Debug($"{nameof(CreatePatriotResponse)} called with input: {patriotInput}.");

            // First, log the request
            var requestId = StatsHandler.LogRequest(patriotInput);

            List<RateResponse> rateResponses = new List<RateResponse>();

            // Currently selects four plans, two header codes with different face amounts
            var patriotPlans = MobileRaterServiceConfiguration.Plans.Where(p => p.Rater == "PAT").ToList();

            foreach (var plan in patriotPlans)
            {
                // Build query model to be used for validating input values
                ValidationInput validationInput = ServiceInputValidator.BuildCheckInputs(patriotInput, plan);

                // See if there are any validation results for the input values
                var validations = ServiceInputValidator.ValidateInput(validationInput);

                // Validate the input model
                // If valid then convert each header code into a WOW Illustration request
                if (validations.Any())
                {
                    // Convert base input model to WOW Illustration request
                    var policy = BuildPolicy(patriotInput, plan.HeaderCode);

                    if (logger.IsDebugEnabled) logger.Debug($"Converted Generation Request {policy}");

                    // Create RateResponse for each WOW Illustration response; parse rate value
                    RateResponse rateResponse = new RateResponse();

                    // NOTE: We know we need to submit for 10k and 25k
                    policy.FaceAmount = plan.FaceAmount;
                    policy.NonLevelData.Add(CommonProcessor.SetWholeLifeNonLevelData());
                        
                    // Send WOW Illustration request to WIS
                    WoodmenIllustrationResponse wisResponse = CommonProcessor.PostRequest(policy);
                    rateResponse.FaceAmount = plan.FaceAmount;
                    rateResponse.ProductName = (String.IsNullOrWhiteSpace(plan.DisplayName)) ? plan.PlanId : plan.DisplayName;

                    if (wisResponse == null)
                    {
                        rateResponse.HasError = true;
                    }
                    else
                    {
                        // Add RateResponse to list collection
                        rateResponse.Rate = CommonProcessor.ProcessIllustrationResponse(wisResponse);
                        if (logger.IsDebugEnabled)
                        {
                            if (Settings.Default.GeneratePDF && policy.GeneratePdf)
                            {
                                CommonProcessor.SavePDF(wisResponse, plan.PlanId);
                            }
                        }

                        // Need to suppress successful LPA responses with zero rates in case product table is incorrect or LPA changes
                        if (rateResponse.Rate > 0M)
                        {
                            rateResponses.Add(rateResponse);
                        }
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

        // Build and return a specific policy type for a specific product type
        internal static WholeLifePolicy BuildPolicy(PatriotInput patriotInput, int headerCode)
        {
            if (logger.IsDebugEnabled) logger.Debug($"BuildPolicy called with PatriotInput: {patriotInput.ToString()} HeaderCode: {headerCode}.");

            WholeLifePolicy policy;

            PolicyBuilders builder = new PolicyBuilders();

            policy = builder.BuildWholeLifePolicy(patriotInput, headerCode);
            
            return policy;
        }
    }
}