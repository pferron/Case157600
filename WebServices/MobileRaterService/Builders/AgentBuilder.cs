using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WOW.Illustration.Model.Generation.Request;

namespace WOW.MobileRaterService.Builders
{
    public class AgentBuilder
    {
        public AgentPerson SetAgentDefaults()
        {
            AgentPerson agent = new AgentPerson();
            agent.FirstName = "Rater";
            agent.MiddleName = string.Empty;
            agent.LastName = "Application";
            agent.AddressLine1 = "1700 Farnam Street";
            agent.AddressLine2 = string.Empty;
            agent.AddressCity = "Omaha";
            agent.AddressState = "NE";
            agent.AddressZipCode = "68102";
            agent.PhoneNumber = "800-225-3108";

            return agent;
        }
    }
}