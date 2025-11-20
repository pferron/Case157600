using Newtonsoft.Json;
using System;

namespace WOW.Illustration.Model.Generation.Request
{
    /// <summary>
    /// <remarks>
    /// There are no Term Life specific fields at this time. This class was created for future use, if needed.
    /// </remarks>
    /// </summary>
    public class TermLifePolicy : TraditionalLifePolicy
    {
        private const int HeaderCodeTermBaseLevelYouthWithAcceleratedDeathBenefit = 790;
        private const int YearsToMaturityYouthTerm = 25;
        private const int YearsToMaturityTermLifeNY = 80;
        private const int YearsToMaturityTermLife = 95;
        private const string NewYork = "NY";

        public override int YearsToMaturity
        {
            get
            {
                if (HeaderCode == HeaderCodeTermBaseLevelYouthWithAcceleratedDeathBenefit)
                {
                    return YearsToMaturityYouthTerm;
                }
                else if (NewYork.Equals(SignedState, StringComparison.OrdinalIgnoreCase))
                {
                    return YearsToMaturityTermLifeNY;
                }
                else
                {
                    return YearsToMaturityTermLife;
                }
            }
        }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
