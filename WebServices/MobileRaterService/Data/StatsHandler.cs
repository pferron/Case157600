using System;
using log4net;
using WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Requests;
using WOW.MobileRaterService.Properties;
using WOW.MobileRaterService.Models;

namespace WOW.MobileRaterService.Data
{
    internal static class StatsHandler
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(StatsHandler));

        internal static Guid LogRequest(LifeRateInput input)
        {
            try
            {
                var model = new QuoteRequest();

                using (var dbContext = new MwagDbContext())
                {
                
                    dbContext.Database.CommandTimeout = (int)Settings.Default.DatabaseQueryTimeout.TotalSeconds;

                    model.ID = Guid.NewGuid();
                    model.SalesRepCode = input.SalesRepCode;
                    model.AccessDateTime = DateTime.Now;
                    model.RaterInputModelType = input.GetType().ToString();
                    model.State = input.State;
                    model.UserAgent = input.UserAgent;
                    model.Age = input.Age;
                    model.RatingClass = input.RatingClass;
                    model.Gender = input.Gender;
                    model.Dues = input.Dues;
                    model.PaymentMode = input.PaymentMode;
                    model.BillType = input.BillType;
                    model.FaceAmount = input.FaceAmount;
                    model.Workplace = input.Worksite;
                    model.Tobacco = input.Tobacco;
                    model.LifeAD = input.AccidentalDeathRider;
                    model.AioGir = input.AioGir;
                    model.AioGirAmount = input.AioGirAmount;
                    model.AppWaiverRider = input.ApplicantWaiverRider;
                    model.PayorAge = input.PayorAge;
                    model.WaiverOfPremium = input.WaiverOfPremium;
                    model.WaiverOfMonthlyDeduction = input.WaiverMonthlyDeduction;
                    model.FlatExtra = input.FlatExtra;
                    dbContext.QuoteRequests.Add(model);
                    dbContext.SaveChanges();
                }

                return model.ID;
            }
            catch (Exception ex)
            {
                if (logger.IsErrorEnabled) { logger.Error($"{nameof(LogRequest)}: Error occurred while trying to log a Life Rater request.", ex); }

                return Guid.Empty;
            }
        }

        internal static Guid LogRequest(IndependenceRateInput input)
        {
            try
            {
                var model = new QuoteRequest();

                using (var dbContext = new MwagDbContext())
                {
                    dbContext.Database.CommandTimeout = (int)Settings.Default.DatabaseQueryTimeout.TotalSeconds;

                    model.ID = Guid.NewGuid();
                    model.SalesRepCode = input.SalesRepCode;
                    model.AccessDateTime = DateTime.Now;
                    model.RaterInputModelType = input.GetType().ToString();
                    model.Age = input.Age;
                    model.BillType = input.BillType;
                    model.Dues = input.Dues;
                    model.FaceAmount = input.FaceAmount;
                    model.Gender = input.Gender;
                    model.AD = input.HasAccidentalDeathRider;
                    //input.IsPatriotSeries //TODO: What is this for?
                    model.PaymentMode = input.PaymentMode;
                    model.RatingClass = input.RatingClass;
                    model.State = input.State;
                    model.Tobacco = input.Tobacco;
                    model.UserAgent = input.UserAgent;
                    model.Workplace = input.Worksite;
                    dbContext.QuoteRequests.Add(model);
                    dbContext.SaveChanges();
                }

                return model.ID;
            }
            catch (Exception ex)
            {
                if (logger.IsErrorEnabled) { logger.Error($"{nameof(LogRequest)}: Error occurred while trying to log a Life Rater request.", ex); }

                return Guid.Empty;
            }
        }

        internal static Guid LogRequest(PatriotInput input)
        {
            try
            {
                var model = new QuoteRequest();

                using (var dbContext = new MwagDbContext())
                {
                    dbContext.Database.CommandTimeout = (int)Settings.Default.DatabaseQueryTimeout.TotalSeconds;

                    model.ID = Guid.NewGuid();
                    model.SalesRepCode = input.SalesRepCode;
                    model.AccessDateTime = DateTime.Now;
                    model.RaterInputModelType = input.GetType().ToString();
                    model.Age = input.Age;
                    model.State = input.State;
                    model.Tobacco = input.Tobacco;
                    model.UserAgent = input.UserAgent;
                    dbContext.QuoteRequests.Add(model);
                    dbContext.SaveChanges();
                }

                return model.ID;
            }
            catch (Exception ex)
            {
                if (logger.IsErrorEnabled) { logger.Error($"{nameof(LogRequest)}: Error occurred while trying to log a Life Rater request.", ex); }

                return Guid.Empty;
            }
        }

        internal static Guid LogRequest(FamilyTermRateInput input)
        {
            try
            {
                var model = new QuoteRequest();

                using (var dbContext = new MwagDbContext())
                {
                    dbContext.Database.CommandTimeout = (int)Settings.Default.DatabaseQueryTimeout.TotalSeconds;

                    model.ID = Guid.NewGuid();
                    model.SalesRepCode = input.SalesRepCode;
                    model.AccessDateTime = DateTime.Now;
                    model.RaterInputModelType = input.GetType().ToString();
                    model.BillType = input.BillType;
                    model.OtherAge = input.OtherAge;
                    model.OtherFaceAmount = input.OtherFaceAmount;
                    model.OtherRatingClass = input.OtherRatingClass;
                    model.OtherTobacco = input.OtherTobacco;
                    model.PaymentMode = input.PaymentMode;
                    model.Age = input.PrimaryAge;
                    model.Disability = input.PrimaryDisability;
                    model.FaceAmount = input.PrimaryFaceAmount;
                    model.RatingClass = input.PrimaryRatingClass;
                    model.Tobacco = input.PrimaryTobacco;
                    model.State = input.State;
                    model.UserAgent = input.UserAgent;
                    dbContext.QuoteRequests.Add(model);
                    dbContext.SaveChanges();
                }

                return model.ID;
            }
            catch (Exception ex)
            {
                if (logger.IsErrorEnabled) { logger.Error($"{nameof(LogRequest)}: Error occurred while trying to log a Life Rater request.", ex); }

                return Guid.Empty;
            }
        }
    }
}
