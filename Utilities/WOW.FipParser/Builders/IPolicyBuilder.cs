using System.Collections.Generic;
using WOW.Illustration.Model.Generation.Request;

namespace WOW.FipUtilities
{
    interface IPolicyBuilder
    {
        void HydrateAgentData(IList<FipDataModel> fipData);
        void HydrateClientData(IList<FipDataModel> fipData);
        void HydrateCommonData(IList<FipDataModel> fipData);
        void HydrateRiderData(IList<FipDataModel> fipData);
        void HydrateNonLevelData(IList<FipDataModel> fipData);
        void HydrateReports(IList<FipDataModel> fipData);
        void HydrateGeneralPolicyData(IList<FipDataModel> fipData);
        void HydratePolicySpecificData(IList<FipDataModel> fipData);

        Policy GetPolicy();
    }
}
