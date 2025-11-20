using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Responses
{
    public class ReverseLookupResponse
    {
        public string PolicyType { get; set; }
        public decimal FaceAmount { get; set; }
        public decimal MonthlyPremium { get; set; }
        public decimal AnnualPremium { get; set; }
    }
}
