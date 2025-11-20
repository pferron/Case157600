using log4net;
using System.Web.Http;
using WOW.WoodmenIllustrationService.SharedModels;

namespace Wow.CommonIllustrationService.Controllers
{
    public class ServiceController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ServiceController));

        [HttpGet]
        [ActionName("Heartbeat")]
        public ServiceStatus Heartbeat()
        {
            if (log.IsDebugEnabled) { log.Debug("Heartbeat requested."); }

            return new ServiceStatus { Result = "ONLINE", HasError = false };
        }

    }
}
