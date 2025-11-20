using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WOW.IllustrationMgmntTool.Common.LpaDashboard.DAO;

namespace LPA.Dashboard.Web.ViewModels
{
    public class RegionViewModel : BaseViewModel
    {
        public int RegionId { get; set; }
        public string Name { get; set; }
        public List<AgentDao> Agents { get; set; }    

        public RegionViewModel()
        {
            Agents = new List<AgentDao>();
            ErrorMessage = string.Empty;
        }
    }
}