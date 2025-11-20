using log4net;
using WOW.IllustrationMgmntTool.Common.DAL;

namespace LPA.Dashboard.Web.Code
{
    /// <summary>
    /// The rate data utilities.
    /// </summary>
    public class RateDataUtils
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(RateDataUtils));

        /// <summary>
        /// Gets the rate data id.
        /// </summary>
        /// <param name="rateCode">The rate code.</param>
        /// <param name="band">The band.</param>
        /// <param name="age">The age.</param>
        /// <returns>An int.</returns>
        public int GetRateDataId(int rateCode, int band, int age)
        {
            if (log.IsInfoEnabled) log.Info($"GetRateDataId called with rateCode: {rateCode}, band: {band}, age: {age}.");

            RateDataLogic rateDataLogic = new RateDataLogic();
            return rateDataLogic.GetRateDataId(rateCode, band, age);
        }
    }
}