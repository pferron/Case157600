using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Requests
{
    public class FamilyTermRateInput
    {
        [Required]
        public string State { get; set; }
        /// <summary>
        /// Monthly, Quarterly, Semi-Annual, Annual
        /// </summary>
        [Required]
        public string PaymentMode { get; set; }
        /// <summary>
        /// List Bill, PAC, Direct Bill
        /// </summary>
        [Required]
        public string BillType { get; set; }
        [Required]
        public int PrimaryAge { get; set; }
        public bool PrimaryTobacco { get; set; }
        [Required]
        public decimal PrimaryFaceAmount { get; set; }
        [Required]
        public string PrimaryRatingClass { get; set; }
        public string PrimaryDisability { get; set; }
        public int? OtherAge { get; set; }
        public bool OtherTobacco { get; set; }
        public decimal? OtherFaceAmount { get; set; }
        public string OtherRatingClass { get; set; }
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