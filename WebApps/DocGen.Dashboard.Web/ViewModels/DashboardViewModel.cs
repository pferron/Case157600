using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WOW.IllustrationMgmntTool.Common.LpaDashboard.DAO;
using WOW.IllustrationMgmntTool.Common.Models.Region;

namespace LPA.Dashboard.Web.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public int RegionId { get; set; }
        public string Name { get; set; }
        public List<RegionMapping> RegionMappings { get; set; }

        public DashboardViewModel()
        {
            RegionMappings = new List<RegionMapping>();
            ErrorMessage = string.Empty;
        }
    }
}