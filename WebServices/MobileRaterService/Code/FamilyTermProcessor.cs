using System;
using log4net;
using System.Collections.Generic;
using WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Requests;
using WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Responses;
using WOW.MobileRaterService.Properties;
using WOW.Illustration.Model.Generation.Request;
using System.Globalization;
using WOW.MobileRaterService.Builders;
using WOW.Illustration.Model.Generation.Response;
using WOW.Illustration.Model.Enums;
using WOW.MobileRaterService.Data;
using System.Linq;

namespace WOW.MobileRaterService.Code
{
    internal static class FamilyTermProcessor
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(FamilyTermProcessor));

        internal static List<RateResponse> CreateFamilyTermRateResponse(FamilyTermRateInput ftInput)
        {
            if (logger.IsDebugEnabled) logger.Debug($"{nameof(CreateFamilyTermRateResponse)} called with input: {ftInput}.");

            // First, log the request
            var requestId = StatsHandler.LogRequest(ftInput);

            List<RateResponse> rateResponses = new List<RateResponse>();

            var familyTermPlans = MobileRaterServiceConfiguration.Plans.Where(p => p.Rater == "FT").ToList();

            foreach (var plan in familyTermPlans)
            {
                RateResponse rateResponse = new RateResponse();

                // Convert input model to WOW Illustration request
                if (CommonProcessor.CheckFamilyTermValid(ftInput))
                {
                    Policy policy = CreateFTRequest(plan.HeaderCode, ftInput);

                    if (CommonProcessor.ConvertRiderRating(ftInput.PrimaryDisability) > 0 && CommonProcessor.CheckFTWaiver(ftInput))
                    {
                        rateResponse.HasWaiverPremium = true;
                    }
                    else
                    {
                        rateResponse.HasWaiverPremium = false;
                    }

                    if (logger.IsDebugEnabled) logger.Debug($"Converted Generation Request {policy}");

                    // Send WOW Illustration request to WIS
                    rateResponse.ProductName = (string.IsNullOrWhiteSpace(plan.DisplayName)) ? plan.PlanId : plan.DisplayName;
                    rateResponse.HasEmbeddedDues = plan.HasEmbeddedDues;
                    rateResponse.FaceAmount = ftInput.PrimaryFaceAmount;
                    WoodmenIllustrationResponse wisResponse = CommonProcessor.PostRequest(policy as TermLifePolicy);

                    // Add RateResponse to list collection
                    rateResponse.Rate = CommonProcessor.ProcessIllustrationResponse(wisResponse);

                    // Need to suppress successful LPA responses with zero rates in case product table is incorrect or LPA changes
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

        // Build and return a specific policy type for a specific product type
        //internal static Policy BuildPolicy(FamilyTermRateInput ftInput, HeaderCode headerCodeType)
        //{
        //    if (logger.IsDebugEnabled) logger.Debug($"BuildPolicy called with FamilyTermRateInput: {ftInput.ToString()} HeaderCodeType: {headerCodeType}.");

        //    Policy policy;

        //    PolicyBuilders builder = new PolicyBuilders();

        //    switch (headerCodeType)
        //    {
        //        case HeaderCode.FamilyTerm:  // 780 Not in AvailabiltyTable
        //        case HeaderCode.FamilyTermLevel10Year: //880
        //        case HeaderCode.FamilyTermLevel20Year:  //885
        //            // Type is ProductType.FamilyTerm;
        //            policy = builder.BuildTermPolicy(ftInput, (int)headerCodeType);
        //            break;

        //        default:
        //            throw new InvalidOperationException($"Unexpected header code {headerCodeType}");
        //    }

        //    return policy;
        //}

        #region Mark's Methods - not sure if still needed with new structure; perhaps some code snippets still useful

        internal static TermLifePolicy CreateFTRequest(int headerCode, FamilyTermRateInput ftInput)
        {
            TermLifePolicy ftPolicy = new TermLifePolicy();
            try
            {
                ftPolicy = SetFTPolicyCommon(ftInput, ftPolicy, headerCode);
                NonLevelData ftNonLevel = new NonLevelData();
                ftNonLevel = CommonProcessor.SetTermNonLevelData();
                ftPolicy.NonLevelData.Add(ftNonLevel);

                if (ftInput.OtherAge.HasValue && ftInput.OtherFaceAmount.HasValue)
                {
                    Rider ftOtherRider = new Rider();
                    ftOtherRider.Name = "ftOtherRider Insured";
                    ftOtherRider.Age = ftInput.OtherAge.Value;
                    ftOtherRider.Amount = ftInput.OtherFaceAmount.Value;
                    ftOtherRider.RatingAmount = CommonProcessor.ConvertRating(ftInput.OtherRatingClass);
                    ftOtherRider.Class = CommonProcessor.SetInsuredClass(ftInput.OtherRatingClass, ftInput.OtherTobacco, ftInput.OtherAge.Value, ftInput.State);
                    ftOtherRider.RiderType = 8;
                    ftOtherRider.ToAge = 100;
                    ftPolicy.Riders.Add(ftOtherRider);
                }

                if (ftInput.PrimaryDisability.ToUpperInvariant() == "N" ||  !CommonProcessor.CheckFTWaiver(ftInput))
                {
                    // no rider present
                }
                else
                {
                    var riderClass = CommonProcessor.ConvertRiderRating(ftInput.PrimaryDisability);

                    if (riderClass > 0)
                    {
                        Rider ftDisability = new Rider();
                        ftDisability.RiderType = 1;
                        ftDisability.ToAge = 65;
                        ftDisability.Age = ftInput.PrimaryAge;
                        //ftDisability.Class = riderClass;
                        ftDisability.RatingAmount = riderClass;
                        ftDisability.RatingAmountToAge = 60;
                        ftPolicy.Riders.Add(ftDisability);
                        
                    }
                }
                return ftPolicy;
            }
            catch (Exception ex)
            {
                if (logger.IsErrorEnabled) { logger.ErrorFormat(CultureInfo.InvariantCulture, "An error occurred in CreateFTRequest for headerCode: {0}  Error: {1}.", headerCode.ToString(), ex); }
                return ftPolicy;
            }
        }

        internal static TermLifePolicy SetFTPolicyCommon(FamilyTermRateInput ftInput, TermLifePolicy termPolicy, int headerCode)
        {
            termPolicy.Agent = new AgentPerson();
            termPolicy.Agent.FirstName = "Mobile";
            termPolicy.Agent.MiddleName = string.Empty;
            termPolicy.Agent.LastName = "Rater";
            termPolicy.Agent.AddressState = "NE"; //required
            termPolicy.Agent.PhoneNumber = "4025551212"; //required'
            
            termPolicy.Client = new ClientPerson();
            termPolicy.Client.FirstName = "Mobile";
            termPolicy.Client.MiddleName = string.Empty;
            termPolicy.Client.LastName = "Rater";
            termPolicy.Client.Gender = 0;
            termPolicy.Client.Age = ftInput.PrimaryAge;
            termPolicy.ClassType = CommonProcessor.SetInsuredClass(ftInput.PrimaryRatingClass, ftInput.PrimaryTobacco, ftInput.PrimaryAge, ftInput.State);
            termPolicy.FaceAmount = ftInput.PrimaryFaceAmount;
            termPolicy.FaceCode = 1;
            termPolicy.BillType = CommonProcessor.ConvertBillType(ftInput.BillType, ftInput.PaymentMode);
            termPolicy.RatingAmount = CommonProcessor.ConvertRating(ftInput.PrimaryRatingClass);
            termPolicy.GenerateValuesTextFile = true;
            termPolicy.HeaderCode = headerCode;
            termPolicy.IssueAge = ftInput.PrimaryAge;
            termPolicy.PremiumMode = CommonProcessor.ConvertMode(ftInput.BillType, ftInput.PaymentMode, "FT");
            termPolicy.SignedState = ftInput.State;
            termPolicy.CertificateDate = DateTime.Now;
            termPolicy.SceneModifyDate = DateTime.Now;
            termPolicy.ConceptCode = 1;
            termPolicy.CategoryCode = 4;
            termPolicy.GeneratePdf = Settings.Default.GeneratePDF;
            return termPolicy;
        }

        #endregion

    }
}