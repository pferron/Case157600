using log4net;
using System.Data;
using System.Globalization;
using WOW.MobileRaterService.Data;
namespace WOW.MobileRaterService.Models
{
    internal class Validation
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Validation));

        internal int HeaderCode { get; set; }
        internal bool IsAIO { get; set; }
        internal decimal? AioGirAmount { get; set; }
        internal int? ApplicantWaiverRating { get; set; }
        internal int? AccidentalDeathRating { get; set; }
        internal int? AWPRating { get; set; }
        internal int? WaiverPremiumRating { get; set; }
        internal int? WaiverMonthlyDeductionRating { get; set; }
        internal int BaseRating { get; set; }

    }
}