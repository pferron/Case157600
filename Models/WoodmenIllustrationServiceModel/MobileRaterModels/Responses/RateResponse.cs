using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WOW.WoodmenIllustrationService.SharedModels;

namespace WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Responses
{
    public class RateResponse
    {
        public string ProductName { get; set; }
        public decimal Rate { get; set; }
        public decimal FaceAmount { get; set; }
        public bool HasAccidentalDeath { get; set; }
        public bool HasAioGir { get; set; }
        public bool HasWaiverPremium { get; set; }
        public bool HasApplicantWaiver { get; set; }
        public bool HasWaiverDeduction { get; set; }
        public bool HasError { get; set; }
        public bool HasEmbeddedDues { get; set; }
        public Guid recordID { get; set; }
    }
}