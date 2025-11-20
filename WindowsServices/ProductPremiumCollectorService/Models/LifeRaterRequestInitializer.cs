using System;
using WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Requests;

namespace ProductPremiumCollectorService.Models
{
    internal static class LifeRaterRequestInitializer
    {
        static bool AioGir = false;
        static string AccidentalDeathRider = @"N";
        static string ApplicantWaiverRider = @"N";
        static string WaiverOfPremium = @"N";
        static string WaiverMonthlyDeduction = @"N";
        static string RatingClass = @"Standard";
        static bool Worksite = false;
        static string State = @"NE";
        static string UserAgent = @"ProductPremiumCollector";
        static string SalesRepCode = @"1890";

        internal static LifeRateInput BuildRequest(LifeRaterParameters input)
        {
            var request = new LifeRateInput();

            int? aioGirAmount = null;

            if (input.Gir)
            {
                aioGirAmount = input.FaceAmount < 50000 ? (int?)input.FaceAmount : 50000;
            }

            request.AccidentalDeathRider = AccidentalDeathRider;
            request.Age = input.Age;
            request.AioGir = input.Gir;
            request.AioGirAmount = aioGirAmount;
            request.ApplicantWaiverRider = ApplicantWaiverRider;
            request.BillType = input.BillType;
            request.Dues = null;
            request.FaceAmount = input.FaceAmount;
            request.FlatExtra = null;
            request.Gender = input.Gender;
            request.PaymentMode = input.PaymentMode;
            request.PayorAge = null;
            request.RatingClass = RatingClass;
            request.SalesRepCode = SalesRepCode;
            request.State = State;
            request.Tobacco = input.Tobacco;
            request.UserAgent = UserAgent;
            request.WaiverMonthlyDeduction = WaiverMonthlyDeduction;
            request.WaiverOfPremium = WaiverOfPremium;
            request.Worksite = Worksite;

            return request;
        }
    }
}
