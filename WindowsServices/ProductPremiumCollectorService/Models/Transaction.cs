using System.Collections.Generic;
using WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Requests;
using WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Responses;

namespace ProductPremiumCollectorService.Models
{
    public class Transaction
    {
        public LifeRateInput Request { get; set; }
        public List<RateResponse> Responses { get; set; }       
    }
}
