using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WOW.MobileRaterService.Models
{
    internal class ValidationInput
    {
        internal int HeaderCode { get; set; }
        internal string StateCode { get; set; }
        internal int InsuredAge { get; set; }
        internal bool IsAIO { get; set; }
        internal bool IsTobaccoUser { get; set; }
        internal decimal FaceAmount { get; set; }
        internal string BillingMethod { get; set; }
        internal string BillingMode { get; set; }
        internal bool? IsWorkplace { get; set; }
        internal string Gender { get; set; }
        internal int? ADBRating { get; set; }
        internal decimal? AioGirAmount { get; set; }
        internal int? PayorAge { get; set; }
        internal int? ADRating { get; set; }
        internal int? AWPRating { get; set; }
        internal int? WaiverPremiumRating { get; set; }
        internal int? WaiverMonthlyDeductionRating { get; set; }
        internal int BaseRating { get; set; }
        internal int? OtherInsuredRating { get; set; }
        internal bool? OtherTobacco { get; set; }
        internal decimal? OtherFaceAmount { get; set; }


    }
}