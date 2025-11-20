using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using System.Data;
using System.Globalization;
using WOW.MobileRaterService.Data;

namespace WOW.MobileRaterService.Models
{
    public class Product
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Product));

        public int CombinationID { get; set; }
        public int HeaderCode { get; set; }
        public int StateGroupId { get; set; }
        public int MinInsuredAge { get; set; }
        public int MaxInsuredAge { get; set; }
        public bool IsTobaccoUser { get; set; }
        public int? MinRatingClass { get; set; }
        public int MaxRatingClass { get; set; }
        public int MinFaceAmount { get; set; }
        public int MaxFaceAmount { get; set; }
        public string Gender { get; set; }
        public bool IsWorkplace { get; set; }
        public string BillingMethod { get; set; }
        public string BillingMode { get; set; }
        public bool IsAio { get; set; }
        public int? MinAioAmount { get; set; }
        public int? MaxAioAmount { get; set; }
        public int? AwpRating { get; set; }
        public int? MinPayorAge { get; set; }
        public int? MaxPayorAge { get; set; }
        public int? AccidentalDeathRating { get; set; }
        public int? WaiverOfPremiumRating { get; set; }
        public int? WaiverOfMonthlyDeductionRating { get; set; }
    }
}