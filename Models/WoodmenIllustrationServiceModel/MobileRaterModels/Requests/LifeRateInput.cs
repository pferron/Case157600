using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Requests
{
    public class LifeRateInput
    {
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
        public bool Tobacco { get; set; }
        [Required]
        public decimal FaceAmount { get; set; }
        /// <summary>
        /// Expected values for PaymentMode: Monthly, Quarterly, Semi-Annual, Annual
        /// </summary>
        [Required]
        public string PaymentMode { get; set; }
        /// <summary>
        /// List Bill, PAC, Direct Bill
        /// </summary>
        [Required]
        public string BillType { get; set; }
        public bool AioGir { get; set; }
        public int? AioGirAmount { get; set; }
        /// <summary>
        /// Values can be 'N' for No, 'Y' for Yes, '2' for 200% rating, '3' for 300% rating
        /// </summary>
        public string AccidentalDeathRider { get; set; }
        /// <summary>
        /// Values can be 'N' for No, 'Y' for Yes, '2' for 200% rating, '3' for 300% rating
        /// </summary>
        public string ApplicantWaiverRider { get; set; }
        public int? PayorAge { get; set; }
        /// <summary>
        /// Values can be 'N' for No, 'Y' for Yes, '2' for 200% rating, '3' for 300% rating
        /// </summary>
        public string WaiverOfPremium { get; set; }
        /// <summary>
        /// Values can be 'N' for No, 'Y' for Yes, '2' for 200% rating, '3' for 300% rating
        /// </summary>
        public string WaiverMonthlyDeduction { get; set; }
        public decimal? FlatExtra { get; set; }
        [Required]
        public string RatingClass { get; set; }
        public bool Worksite { get; set; }
        public decimal? Dues { get; set; }
        [Required]
        public string State { get; set; }
        public string UserAgent { get; set; }
        [Required]
        public string SalesRepCode { get; set; }        

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}