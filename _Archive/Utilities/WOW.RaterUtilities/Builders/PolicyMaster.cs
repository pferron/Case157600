
using System;
using System.Globalization;
using WOW.Illustration.Model.Generation.Request;
using WOW.WoodmenIllustrationService.SharedModels;
namespace WOW.RaterUtilities
{
    class PolicyMaster
    {
        IPolicyBuilder _policyBuilder;
        RaterRequest _raterData;

        public PolicyMaster(IPolicyBuilder policyBuilder, RaterRequest raterData)
        {
            if (policyBuilder == null)
            {
                throw new ArgumentNullException("policyBuilder", "A PolicyBuilder object must be provided.");
            }

            if (raterData == null)
            {
                throw new ArgumentNullException("raterData", "Cannot convert null data to an IPolicy object.");
            }

            _policyBuilder = policyBuilder;
            _raterData = raterData;
        }

        public Policy GetPolicy()
        {
            try
            {
                _policyBuilder.HydrateAgentData(_raterData);
                _policyBuilder.HydrateClientData(_raterData);
                _policyBuilder.HydrateCommonData(_raterData);
                _policyBuilder.HydrateNonLevelData(_raterData);
                _policyBuilder.HydratePolicySpecificData(_raterData);
                _policyBuilder.HydrateRiderData(_raterData);

                return _policyBuilder.GetPolicy();
            }
            catch (Exception ex)
            {
                throw new PolicyBuilderException(String.Format(CultureInfo.InvariantCulture, "An error occurred while building a policy of type '{0}'.", _policyBuilder.GetType()), ex);
            }
        }
    }
}
