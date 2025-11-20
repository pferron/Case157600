using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Requests;
using WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Responses;


namespace ProductPremiumCollector.Models
{
    internal class Transaction
    {
        public LifeRateInput Request { get; set; }
        public List<RateResponse> Responses { get; set; }
    }
}
