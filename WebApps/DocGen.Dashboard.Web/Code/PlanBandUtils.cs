using log4net;
using WOW.IllustrationMgmntTool.Common.DAL;

namespace LPA.Dashboard.Web.Code
{
    /// <summary>
    /// The plan band utilities.
    /// </summary>
    public class PlanBandUtils
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(PlanBandUtils));

        /// <summary>
        /// Gets the plan band id.
        /// </summary>
        /// <param name="productId">The product id.</param>
        /// <param name="band">The band.</param>
        /// <returns>An int.</returns>
        public int GetPlanBandId(int productId, int band)
        {
            if (log.IsInfoEnabled) log.Info($"GetPlanBandId called with productId: {productId}, band: {band}.");

            PlanBandLogic planBandLogic = new PlanBandLogic();
            return planBandLogic.GetPlanBandId(productId, band);
        }
    }
}