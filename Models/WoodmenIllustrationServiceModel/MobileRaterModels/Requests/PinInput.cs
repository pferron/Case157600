using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Requests
{
    public class PinInput
    {
        public string PinCode { get; set; }
        public string SalesRepCode { get; set; }

        public bool IsValid()
        {
            if(String.IsNullOrWhiteSpace(PinCode) || String.IsNullOrWhiteSpace(SalesRepCode))
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}