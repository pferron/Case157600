using Highsoft.Web.Mvc.Charts;
using log4net;
using LPA.Dashboard.Web.Code;
using LPA.Dashboard.Web.ViewModels;
using System.Collections.Generic;

namespace LPA.Dashboard.Web.ActionCode
{
    /// <summary>
    /// The sales laptop uptake actions.
    /// </summary>
    public class SalesLaptopUptakeActions
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SalesLaptopUptakeActions));

        /// <summary>
        /// Process sales laptop up take.
        /// </summary>
        /// <returns>SalesLaptopUptakeViewModel</returns>
        internal SalesLaptopUptakeViewModel ProcessSalesLaptopUptake()
        {
            if (log.IsInfoEnabled) log.Info("SalesLaptopUptakeActions called.");

            SalesLaptopUptakeViewModel salesLaptopUptakeViewModel = new SalesLaptopUptakeViewModel();

            SalesLaptopUptakeUtils reportingUtils = new SalesLaptopUptakeUtils();

            salesLaptopUptakeViewModel.VersionCounts = reportingUtils.GetVersionCounts();

            var statusCounts = reportingUtils.GetPieChartData();

            List<PieSeriesData> pieData = new List<PieSeriesData>
            {
                new PieSeriesData { Name = "Current", Y = statusCounts[0].Total },
                new PieSeriesData { Name = "Inactive", Y = statusCounts[1].Total },
                new PieSeriesData { Name = "Not Current", Y = statusCounts[2].Total }
            };

            salesLaptopUptakeViewModel.StatusCounts = statusCounts;
            salesLaptopUptakeViewModel.PieData = pieData;

            return salesLaptopUptakeViewModel;
        }
    }
}