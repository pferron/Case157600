using WOW.Illustration.Model.Generation.Request;
using WOW.WoodmenIllustrationService.SharedModels;

namespace WOW.RaterUtilities
{
    interface IPolicyBuilder
    {
        void HydrateAgentData(RaterRequest raterData);
        void HydrateClientData(RaterRequest raterData);
        void HydrateCommonData(RaterRequest raterData);
        void HydrateRiderData(RaterRequest raterData);
        void HydrateNonLevelData(RaterRequest raterData);
        void HydratePolicySpecificData(RaterRequest raterData);

        Policy GetPolicy();
    }
}
