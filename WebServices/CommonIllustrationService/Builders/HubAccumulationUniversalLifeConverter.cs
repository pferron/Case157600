using Wow.CommonIllustrationService.Models;
using WOW.Illustration.Model.Generation.Request;
using Hub = Wow.IllustrationCommonModels.Request;

namespace Wow.CommonIllustrationService.Builders
{
    public class HubAccumulationUniversalLifePolicyConverter : HubPolicyConverter
    {
        private Plan ingplan;
        //private Policy policy;
        public override Policy GetPolicy(Hub.IllustrationRequest request)
        {
            return base.Policy;
        }
        public override void HydratePolicySpecificData(Hub.IllustrationRequest hubPolicy)
        {
            foreach (var rep in UniversalLifeReports.Build())
                Policy.Reports.Add(rep);
        }
    }
}