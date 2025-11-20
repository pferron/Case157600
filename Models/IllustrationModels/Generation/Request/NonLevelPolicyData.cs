using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WOW.Illustration.Model.Generation.Request
{
    /// <summary>
    /// Non level policy data
    /// For inforce illustrations
    /// </summary>
    public class NonLevelPolicyData
    {
        public DateTime EffectiveDate { get; set; }

        /// <summary>FIP:NLAmount_1 thru NLAmount_6, NLAmount_1 is typically the face amount of the policy. NLAmount_2 thru NLAmount_6 are typically 0.</summary>
        public IList<decimal> NonLevelAmounts { get; private set; }

        public NonLevelPolicyData()
        {
            NonLevelAmounts = new List<decimal>();
        }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
