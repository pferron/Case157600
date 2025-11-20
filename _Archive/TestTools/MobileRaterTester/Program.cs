using WOW.MobileRaterService.Controllers;
using WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Requests;

namespace MobileRaterTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new LifeRateInput();

            input.State = "AL";
            input.Age = 18;
            input.Tobacco = false;
            input.FaceAmount = 45455;
            input.BillType = "PAC";
            input.PaymentMode = "Monthly";
            input.Worksite = false;
            input.Gender = "M";
            input.AccidentalDeathRider = "N";
            input.AioGir = false;
            input.AioGirAmount = null;
            input.ApplicantWaiverRider = "N";
            input.PayorAge = null;
            input.WaiverOfPremium = "N";
            input.WaiverMonthlyDeduction = "N";
            input.FlatExtra = 0;
            input.RatingClass = "Standard";
            input.Dues = 12;

            input.SalesRepCode = "010110";
            input.UserAgent = string.Empty;

            var service = new RateController();

            var response = service.FetchLifeRates(input);
        }
    }
}
