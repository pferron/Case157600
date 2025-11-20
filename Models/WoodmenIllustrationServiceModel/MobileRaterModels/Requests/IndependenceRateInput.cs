
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Requests
{
    public class IndependenceRateInput
    {
        [Required]
        [Range(0,85)]
        public int Age { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string RatingClass { get; set; }
        /// <summary>
        /// Expected values for Gender: M, F, U
        /// </summary>
        [Required]
        public string Gender { get; set; }
        [Required]
        public decimal? Dues { get; set; }
        /// <summary>
        /// Expected values for PaymentMode: Monthly, Quarterly, Semi-Annual, Annual
        /// </summary>
        [Required]
        public string PaymentMode { get; set; }
        /// <summary>
        /// Expected values for BillType: List Bill, PAC, Direct Bill
        /// </summary>
        [Required]
        public string BillType { get; set; }
        [Required]
        public decimal FaceAmount { get; set; }
        public bool Worksite { get; set; }
        public bool Tobacco { get; set; }
        public bool HasAccidentalDeathRider { get; set; }
        public string UserAgent { get; set; }
        [Required]
        public string SalesRepCode { get; set; }
        public bool IsPatriotSeries { get; set; }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}