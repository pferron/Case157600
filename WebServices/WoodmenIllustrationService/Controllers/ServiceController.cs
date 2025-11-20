using log4net;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using System.Web.Http;
using WOW.WoodmenIllustrationService.Code;
using WOW.WoodmenIllustrationService.Properties;
using WOW.WoodmenIllustrationService.SharedModels;

namespace WOW.WoodmenIllustrationService.Controllers
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

        [HttpGet]
        [ActionName("DatabaseCheck")]
        public ServiceStatus DatabaseCheck()
        {
            if (log.IsDebugEnabled) { log.Debug("DatabaseCheck requested."); }

            try
            {
                // Try to connect to database
                string connStr = Settings.Default.IntegrationDbConnectionString;

                using (var sqlConn = new SqlConnection(connStr))
                {
                    sqlConn.Open();

                    if (log.IsDebugEnabled) { log.Debug("Database is online."); }

                    return new ServiceStatus { Result = "ONLINE", HasError = false };
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error("DatabaseCheck: Error connecting to database.", ex); }

                return new ServiceStatus { Result = "OFFLINE", HasError = true };
            }
        }

        [HttpGet]
        [ActionName("PurgeUploads")]
        public ServiceStatus PurgeUploads()
        {
            if (log.IsDebugEnabled) { log.Debug("PurgeUploads requested."); }

            try
            {
                var folderPaths = new List<string>();
                folderPaths.Add(ServiceHelper.GetUploadDirectoryPath());
                folderPaths.Add(ServiceHelper.GetPayloadDirectoryPath());

                PurgeFolders(folderPaths.ToArray());

                return new ServiceStatus { Result = "SUCCESS", HasError = false };
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error("An error occurred w.", ex); }

                return new ServiceStatus { Result = "FAILURE", HasError = true };
            }
        }

        private void PurgeFolders(string[] folderPaths)
        {
            var tasks = new List<Task>();

            foreach (var folder in folderPaths)
            {
                if (Directory.Exists(folder))
                {
                    var dir = new DirectoryInfo(folder);

                    foreach (var file in dir.GetFiles())
                    {
                        tasks.Add(Task.Run(() => File.Delete(file.FullName)));
                    }
                }
            }

            Task.WaitAll(tasks.ToArray());
        }
    }
}
