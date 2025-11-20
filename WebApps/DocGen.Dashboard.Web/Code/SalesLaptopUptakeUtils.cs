using log4net;
using System;
using System.Collections.Generic;
using WOW.IllustrationMgmntTool.Common.DAL;
using WOW.IllustrationMgmntTool.Common.Models.Reporting;

namespace LPA.Dashboard.Web.Code
{
    /// <summary>
    /// The sales laptop uptake utilities.
    /// </summary>
    public class SalesLaptopUptakeUtils
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SalesLaptopUptakeUtils));

        /// <summary>
        /// Gets the version counts.
        /// </summary>
        /// <returns>A list of version counts.</returns>
        public List<VersionCount> GetVersionCounts()
        {
            if (log.IsInfoEnabled) log.Info("GetVersionCounts called.");

            SalesLaptopUptakeLogic reportingLogic = new SalesLaptopUptakeLogic();

            return reportingLogic.GetVersionCounts();
        }

        /// <summary>
        /// Gets the pie chart data.
        /// </summary>
        /// <returns>A list of status counts.</returns>
        public List<StatusCount> GetPieChartData()
        {
            if (log.IsInfoEnabled) log.Info("GetPieChartData called.");

            LaptopUptake laptopUptake = new LaptopUptake();
            SalesLaptopUptakeLogic reportingLogic = new SalesLaptopUptakeLogic();

            laptopUptake.StatusCounts = reportingLogic.GetStatusCounts();

            List<StatusCount> statusCounts = new List<StatusCount>();

            StatusCount currentStatusCount = new StatusCount
            {
                Status = "Current",
                Total = 0
            };
            statusCounts.Add(currentStatusCount);

            StatusCount rsuStatusCount = new StatusCount
            {
                Status = "Inactive",
                Total = 0
            };
            statusCounts.Add(rsuStatusCount);

            StatusCount sccmStatusCount = new StatusCount
            {
                Status = "Not Current",
                Total = 0
            };
            statusCounts.Add(sccmStatusCount);

            foreach (var status in laptopUptake.StatusCounts)
            {
                if (status.Status.Equals("current", StringComparison.InvariantCultureIgnoreCase))
                {
                    statusCounts[0].Total = status.Total;
                }
                if (status.Status.Equals("Inactive", StringComparison.InvariantCultureIgnoreCase))
                {
                    statusCounts[1].Total = status.Total;
                }
                if (status.Status.Equals("Not Current", StringComparison.InvariantCultureIgnoreCase))
                {
                    statusCounts[2].Total = status.Total;
                }
            }

            return statusCounts;
        }
    }
}