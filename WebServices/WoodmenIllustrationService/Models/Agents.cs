using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WOW.WoodmenIllustrationService.Models
{
    public class Agents
    {
        public Agent[] RelatedAgents { get; set; }
    }

    public class Agent
    {
        public string FRName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Type { get; set; }
        public string FRCode { get; set; }
        public string AMCode { get; set; }
        public string SMCode { get; set; }
        public string OfficePhone { get; set; }
        public string HomePhone { get; set; }
        public string StateCode { get; set; }
        public string Division { get; set; }
        public object Message { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
    }


}