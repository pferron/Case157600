using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Requests
{
    public class AppointmentInput
    {
        public string QuoteId { get; set; }
        public bool HasAppointment { get; set; }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}