using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using WOW.Illustration.Model.Generation.Request;

namespace WOW.FipUtilities
{
    class PolicyMaster
    {
        IPolicyBuilder _policyBuilder;
        IList<FipDataModel> _fipData;

        public PolicyMaster(IPolicyBuilder policyBuilder, IList<FipDataModel> fipData)
        {
            if (policyBuilder == null)
            {
                throw new ArgumentNullException("policyBuilder", "A PolicyBuilder object must be provided.");
            }

            if (fipData == null)
            {
                throw new ArgumentNullException("fipData", "Cannot convert null data to an IPolicy object.");
            }

            if (!fipData.Any())
            {
                throw new ArgumentException("Cannot convert an empty list to an IPolicy object.", "fipData");
            }

            _policyBuilder = policyBuilder;
            _fipData = fipData;
        }

        public Policy GetPolicy()
        {
            try
            {
                _policyBuilder.HydrateAgentData(_fipData);
                _policyBuilder.HydrateClientData(_fipData);
                _policyBuilder.HydrateGeneralPolicyData(_fipData);
                _policyBuilder.HydrateCommonData(_fipData);
                _policyBuilder.HydrateNonLevelData(_fipData);
                _policyBuilder.HydratePolicySpecificData(_fipData);
                _policyBuilder.HydrateReports(_fipData);
                _policyBuilder.HydrateRiderData(_fipData);

                return _policyBuilder.GetPolicy();
            }
            catch (Exception ex)
            {
                throw new PolicyBuilderException(String.Format(CultureInfo.InvariantCulture, "An error occurred while building a policy of type '{0}'.", _policyBuilder.GetType()), ex);
            }
        }
    }
}
