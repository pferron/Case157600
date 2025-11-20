using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Requests
{
    public class ReverseLookupInput
    {
        public string UserAgent { get; set; }

        [Required]
        public string SalesRepCode { get; set; }

        [Required]
        [Range(0,85)]
        public int Age { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public bool Tobacco { get; set; }

        [Range(0.0, double.MaxValue)]
        public decimal MinimumMonthlyValue { get; set; }

        [Range(0.0, double.MaxValue)]
        public decimal MaximumMonthlyValue { get; set; }
        [Required]
        public string Gender { get; set; }

        [Required]
        public bool AioGir { get; set; }

        [Required]
        public double FaceAmount { get; set; }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
