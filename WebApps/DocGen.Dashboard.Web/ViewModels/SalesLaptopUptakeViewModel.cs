using Highsoft.Web.Mvc.Charts;
using LPA.Dashboard.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WOW.IllustrationMgmntTool.Common.Models.Reporting;

namespace LPA.Dashboard.Web.ViewModels
{
    public class SalesLaptopUptakeViewModel : BaseViewModel
    {
        public List<VersionCount> VersionCounts { get; set; }
        public List<StatusCount> StatusCounts { get; set; }
        public List<VersionParams> VersionParams { get; set; }
        public List<PieSeriesData> PieData { get; set; }

        public SalesLaptopUptakeViewModel()
        {
            ErrorMessage = string.Empty;
            PieData = new List<PieSeriesData>();
            VersionParams = new List<VersionParams>();
            StatusCounts = new List<StatusCount>();
            VersionCounts = new List<VersionCount>();
        }

    }
}