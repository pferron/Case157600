using log4net;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WOW.MobileRaterService.Properties;
using WOW.MobileRaterService.Data;
using WOW.MobileRaterService.Models;
using WOW.WoodmenIllustrationService.SharedModels;

namespace WOW.MobileRaterService.Controllers
{
    public class ServiceController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ServiceController));

        [HttpGet]
        [ActionName("DatabaseCheck")]
        public ServiceStatus DatabaseCheck()
        {
            if (log.IsDebugEnabled) { log.Debug("DatabaseCheck requested."); }

            try
            {
                using (var ef = new MobileRaterServiceEntities())
                {
                    ef.Database.CommandTimeout = (int)Settings.Default.DatabaseQueryTimeout.TotalSeconds;

                    if(ef.Database.Exists())
                    {
                        if (log.IsDebugEnabled) { log.Debug("Database is online."); }

                        return new ServiceStatus { Result = "ONLINE", HasError = false };
                    }
                    else
                    {
                        if (log.IsErrorEnabled) { log.Error("Database is missing."); }

                        return new ServiceStatus { Result = "OFFLINE", HasError = true };
                    }
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error("DatabaseCheck: Error connecting to database.", ex); }

                return new ServiceStatus { Result = "OFFLINE", HasError = true };
            }
        }
    }
}
