using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Requests
{
    public class PatriotInput
    {
        public string UserAgent { get; set; }
        [Required]
        public string SalesRepCode { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string State { get; set; }
        public bool Tobacco { get; set; }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}