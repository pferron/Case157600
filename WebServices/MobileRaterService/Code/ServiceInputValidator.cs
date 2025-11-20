using System;
using log4net;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;
using WOW.MobileRaterService.Models;
using WOW.MobileRaterService.Properties;
using WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Requests;
using System.Text;
using WOW.MobileRaterService.Data;
using WOW.MobileRaterService.Code;
using System.Linq;

namespace WOW.MobileRaterService.Code
{
    internal static class ServiceInputValidator
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(ServiceInputValidator));

        // Method to validate input parameters for products
        internal static List<Validation> ValidateInput(ValidationInput input)
        {
            if (logger.IsDebugEnabled) logger.Debug($"ValidateInput called with ValidationInput: {input}.");

            if (logger.IsDebugEnabled) logger.Debug($"Date Override?: {Settings.Default.OverrideDate} Override Date Value: {Settings.Default.OverrideDateValue.ToShortDateString()}");

            DateTime queryDate = (Settings.Default.OverrideDate) ? Settings.Default.OverrideDateValue : DateTime.Today;

            try
            {
                var validations = new List<Validation>();
                var matchingProducts = new List<Product>();

                using (var ef = new MobileRaterServiceEntities())
                {
                    ef.Database.CommandTimeout = (int)Settings.Default.DatabaseQueryTimeout.TotalSeconds;

                    var results = ef.FetchAvaliableProducts(input.StateCode,
                        input.HeaderCode,
                        input.InsuredAge,
                        input.IsTobaccoUser,
                        decimal.ToInt32(input.FaceAmount),
                        input.BillingMethod,
                        input.BillingMode,
                        input.IsWorkplace,
                        input.Gender,
                        input.BaseRating,
                        queryDate);

                    foreach(var record in results)
                    {
                        var product = new Product();

                        product.IsTobaccoUser = (record.IsTobaccoUser.HasValue) ? record.IsTobaccoUser.Value : false;
                        product.IsAio = (record.IsAIO.HasValue) ? record.IsAIO.Value : false;
                        product.MinAioAmount = (record.MinAIOAmount.HasValue) ? record.MinAIOAmount.Value : 0;
                        product.MaxAioAmount = (record.MaxAIOAmount.HasValue) ? record.MaxAIOAmount.Value : 0;
                        product.AwpRating = record.AWPRating;
                        product.MinPayorAge = record.MinPayorAge;
                        product.MaxPayorAge = record.MaxPayorAge;
                        product.AccidentalDeathRating = record.ADRating;
                        product.WaiverOfPremiumRating = record.WPRating;
                        product.WaiverOfMonthlyDeductionRating = record.WMDRating;

                        matchingProducts.Add(product);
                    }
                }

                var validation = new Validation();
                validation.HeaderCode = input.HeaderCode;

                if (matchingProducts.Count > 0)
                {
                    // Checking AIO option
                    if (input.IsAIO)
                    {
                        if (matchingProducts.Any(p => (p.IsAio == input.IsAIO && p.IsAio)))
                        {
                            if (input.AioGirAmount.HasValue)
                            {
                                validation.IsAIO = true;
                            }
                            else
                            {
                                validation.IsAIO = false;
                            }
                        }
                        else
                        {
                            validation.IsAIO = false;
                        }
                    }
                    else
                    {
                        validation.IsAIO = false;
                    }

                    if (matchingProducts.Any(p => p.AccidentalDeathRating == input.ADRating))
                    {
                        validation.AccidentalDeathRating = input.ADRating;
                    }
                    else
                    {
                        validation.AccidentalDeathRating = 0;
                    }

                    if (matchingProducts.Any(p => p.AwpRating == input.AWPRating))
                    {
                        if (matchingProducts.Any(p => p.MaxPayorAge > input.PayorAge))
                        {
                            if (matchingProducts.Any(p => p.MinPayorAge < input.PayorAge))
                            {
                                validation.AWPRating = input.AWPRating;
                                validation.ApplicantWaiverRating = input.AWPRating;
                            }
                            else
                            {
                                validation.AWPRating = 0;
                            }
                        }
                        else
                        {
                            validation.AWPRating = 0;
                        }
                    }
                    else
                    {
                        validation.AWPRating = 0;
                    }

                    if (matchingProducts.Any(p => p.WaiverOfMonthlyDeductionRating == input.WaiverMonthlyDeductionRating))
                    {
                        validation.WaiverMonthlyDeductionRating = input.WaiverMonthlyDeductionRating;
                    }
                    else
                    {
                        validation.WaiverMonthlyDeductionRating = 0;
                    }

                    if (matchingProducts.Any(p => p.WaiverOfPremiumRating == input.WaiverPremiumRating))
                    {
                        validation.WaiverPremiumRating = input.WaiverPremiumRating;
                    }
                    else
                    {
                        validation.WaiverPremiumRating = 0;
                    }

                    validations.Add(validation);
                }
                if (logger.IsDebugEnabled) logger.Debug($"ValidateInput: Validations returned {validations.Count}.");

                return validations;
            }
            catch (Exception ex)
            {
                if (logger.IsErrorEnabled) logger.Error($"There was an error executing 'ValidateInput'.", ex);
                throw;
            }
        }

        internal static ValidationInput BuildCheckInputs(IndependenceRateInput input, SupportedPlan plan)
        {
            ValidationInput queryInput = new ValidationInput();

            try
            {
                queryInput.IsAIO = false;

                if (input.HasAccidentalDeathRider)
                {
                    queryInput.ADRating = CommonProcessor.ConvertIndependenceADRating(input);
                }
                else
                {
                    queryInput.ADRating = 0;
                }

                queryInput.ADBRating = queryInput.ADRating;
                queryInput.IsAIO = false;
                queryInput.AioGirAmount = 0; // Default to 0
                queryInput.AWPRating = 0; // Default to 0
                queryInput.BaseRating = CommonProcessor.ConvertRatingForValidation(input.RatingClass);
                queryInput.BillingMode = CommonProcessor.ConvertPaymentMode(input.PaymentMode);
                queryInput.BillingMethod = CommonProcessor.ConvertBillType(input.BillType);
                queryInput.FaceAmount = input.FaceAmount;
                queryInput.Gender = input.Gender;
                queryInput.HeaderCode = plan.HeaderCode;
                queryInput.InsuredAge = input.Age;
                queryInput.IsTobaccoUser = input.Tobacco;
                queryInput.IsWorkplace = input.Worksite;
                queryInput.PayorAge = 0; // Default to 0
                queryInput.StateCode = input.State;
                queryInput.WaiverMonthlyDeductionRating = 0; // Default to 0
                queryInput.WaiverPremiumRating = 0; // Default to 0

                return queryInput;
            }
            catch(Exception ex)
            {
                if (logger.IsErrorEnabled) logger.Error($"There was an error executing BuildCheckInputs with independence inputs.", ex);

                return queryInput;
            }
        }

        internal static ValidationInput BuildCheckInputs(PatriotInput input, SupportedPlan curPlan)
        {
            ValidationInput queryInput = new ValidationInput();

            try
            {
                //queryInput.IsAIO = false; // AvailabilityTable has all NULL
                queryInput.ADRating = 0; // AvailabilityTable has all NULL
                queryInput.ADBRating = 0;
                queryInput.IsAIO = false;
                queryInput.AioGirAmount = 0; // MinAIOAmount and MaxAIOAmount both 0
                queryInput.AWPRating = 0; // AvailabilityTable has all NULL
                queryInput.BaseRating = 0; // MinRating and MaxRating both 0
                queryInput.BillingMode = "M"; // Monthly
                queryInput.BillingMethod = "L";  // List Bill
                queryInput.FaceAmount = curPlan.FaceAmount;  // Min is 10,000 in Availability table
                queryInput.Gender = "M"; // Availability table on includes M for Patriot Series
                queryInput.HeaderCode = curPlan.HeaderCode;
                queryInput.InsuredAge = input.Age; // Availability table shows 16 to 80
                queryInput.IsTobaccoUser = input.Tobacco;
                queryInput.IsWorkplace = true; // Availability table shows 1 for Patriot Series
                queryInput.PayorAge = 0; // MinPayorAge and MaxPayorAge both NULL
                queryInput.StateCode = input.State; // Necessary for StateGroupsMap table join
                queryInput.WaiverMonthlyDeductionRating = 0; // AvailabilityTable has all NULL
                queryInput.WaiverPremiumRating = 0; // AvailabilityTable has all NULL

                return queryInput;
            }
            catch(Exception ex)
            {
                if (logger.IsErrorEnabled) logger.Error($"There was an error executing BuildCheckInputs with patriot inputs.", ex);

                return queryInput;
            }
        }

        internal static ValidationInput BuildCheckInputs(FamilyTermRateInput input, SupportedPlan plan)
        {
            ValidationInput queryInput = new ValidationInput();

            try
            {
                queryInput.IsAIO = false;
                queryInput.ADBRating = 0;
                queryInput.AioGirAmount = 0;
                queryInput.AWPRating = 0;
                queryInput.WaiverMonthlyDeductionRating = 0;
                queryInput.BaseRating = CommonProcessor.ConvertRatingForValidation(input.PrimaryRatingClass);
                queryInput.BillingMode = CommonProcessor.ConvertPaymentMode(input.PaymentMode);
                queryInput.BillingMethod = CommonProcessor.ConvertBillType(input.BillType);
                queryInput.FaceAmount = input.PrimaryFaceAmount;
                queryInput.HeaderCode = plan.HeaderCode;
                queryInput.InsuredAge = input.PrimaryAge;
                queryInput.IsTobaccoUser = input.PrimaryTobacco;
                queryInput.IsWorkplace = false;
                queryInput.PayorAge = 0;
                queryInput.StateCode = input.State;
                queryInput.WaiverPremiumRating = CommonProcessor.ConvertRiderRating(input.PrimaryDisability);

                return queryInput;
            }
            catch(Exception ex)
            {
                if (logger.IsErrorEnabled) logger.Error($"There was an error executing BuildCheckInputs with FamilyTerm inputs.", ex);

                return queryInput;
            }
        }

        internal static ValidationInput BuildCheckInputs(LifeRateInput input, SupportedPlan plan)
        {
            ValidationInput queryInput = new ValidationInput();

            try
            {
                if (input.AioGir)
                {
                    queryInput.IsAIO = true;
                }
                else
                {
                    queryInput.IsAIO = false;
                }
                queryInput.ADBRating = CommonProcessor.ConvertRiderRating(input.AccidentalDeathRider);
                queryInput.ADRating = queryInput.ADBRating;
                queryInput.AioGirAmount = (input.AioGirAmount.HasValue) ? input.AioGirAmount.Value : 0M;
                //queryInput.AWPRating = 0; // Values 0, 1, NULL
                queryInput.AWPRating = CommonProcessor.ConvertRiderRating(input.ApplicantWaiverRider);
                queryInput.BaseRating = CommonProcessor.ConvertRatingForValidation(input.RatingClass);
                queryInput.BillingMode = CommonProcessor.ConvertPaymentMode(input.PaymentMode);
                queryInput.BillingMethod = CommonProcessor.ConvertBillType(input.BillType);
                queryInput.FaceAmount = input.FaceAmount;
                queryInput.Gender = input.Gender;
                queryInput.HeaderCode = plan.HeaderCode;
                queryInput.InsuredAge = input.Age;
                queryInput.IsTobaccoUser = input.Tobacco;
                queryInput.IsWorkplace = input.Worksite;

                if (queryInput.AWPRating > 0)
                {
                    queryInput.PayorAge = input.PayorAge;
                }
                else
                {
                    queryInput.PayorAge = 0;
                }

                queryInput.StateCode = input.State;
                queryInput.WaiverMonthlyDeductionRating = CommonProcessor.ConvertRiderRating(input.WaiverMonthlyDeduction);
                queryInput.WaiverPremiumRating = CommonProcessor.ConvertRiderRating(input.WaiverOfPremium);

                return queryInput;
            }
            catch(Exception ex)
            {
                if (logger.IsErrorEnabled) logger.Error($"There was an error executing BuildCheckInputs with liferate inputs.", ex);

                return queryInput;
            }
        }
    }
}