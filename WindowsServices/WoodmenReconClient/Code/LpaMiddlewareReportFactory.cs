using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInstaller;
using WOW.WoodmenReconClient.Models;

namespace WOW.WoodmenReconClient.Code
{
    class LpaMiddlewareReportFactory : ReportFactory
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(LpaServerReportFactory));

        private const string _woodmenIllustrationService = "Woodmen Illustration Service";
        private const string _myWoodmenIllustrationService = "MyWoodmenIllustrationClientInstaller";

        public override void CreateReconReport()
        {
            base.CreateReconReport();

            base.Report.Hostname = Environment.MachineName;
            base.Report.ReportName = "LPA Middleware Server Report";

            // Using UTC since systems are distributed nationally.
            base.Report.ReportCreateDateUtc = DateTime.UtcNow;

            Report.DataItems.Add(new ReconReportDataItem { DataName = "Woodmen Illustration Service Version", DataValue = FetchInstalledVersion(_woodmenIllustrationService) });
            Report.DataItems.Add(new ReconReportDataItem { DataName = "MyWoodmen Illustration Client Version", DataValue = FetchInstalledVersion(_myWoodmenIllustrationService) });
        }

        /// <summary>
        /// Find the version of the first product that contains the productName
        /// </summary>
        /// <param name="productName">The product that is installed through windows installer product name</param>
        /// <returns>The version of the product otherwise not found.</returns>
        public string FetchInstalledVersion(string productName)
        {
            try
            {
                if (log.IsDebugEnabled) log.Debug($"Attempting to find '{productName}' in installed products");

                //get the installer things started
                Type type = Type.GetTypeFromProgID("WindowsInstaller.Installer");
                Installer installer = Activator.CreateInstance(type) as Installer;
                StringList products = installer.Products;

                //loop through all installed products from Window's Installer
                foreach (string productGuid in products)
                {
                    //get the name and version
                    string name = installer.ProductInfo[productGuid, "ProductName"].ToLower();
                    string version = installer.ProductInfo[productGuid, "VersionString"];


                    //check if the installed product contains the product name
                    if (name.Contains(productName.ToLower()))
                    {
                        if (log.IsDebugEnabled) { log.Debug("Found"); }
                        //return the first instance of product name
                        return version;
                    }
                }

                return "Not Found";
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error($"Unable to fetch product version of '{productName}'", ex);
                return "Error";
            }
        }
    }
}
