using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WOW.Illustration.Model.Generation.Request;

namespace WOW.MobileRaterService.Builders
{
    public class CommonDataBuilder: Policy
    {
        public Policy BuildCommonDefaults()
        {
            CommonDataBuilder policy = new CommonDataBuilder();
            policy.NeedsCostBenefit = false;
            policy.GeneratePdf = false;
            policy.GenerateValuesTextFile = true;
            policy.ConceptCode = 1;
            policy.IsRevisedIllustration = false;
            policy.NeedsCostBenefit = false;
            policy.SceneModifyDate = DateTime.Now;
            AgentBuilder agent = new AgentBuilder();
            policy.Agent = agent.SetAgentDefaults();
            ClientBuilder client = new ClientBuilder();
            policy.Client = client.BuildClient();

            return policy;

        }
    }
}