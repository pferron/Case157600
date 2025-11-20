
using System.Collections.Generic;

namespace WOW.WoodmenReconService.Models
{
    public class HomeModel
    {
        public string HostnameParameter { get; set; }
        public string LpaVersionParameter { get; set; }
        public string DeploymentDateParameter { get; set; }

        public int ReportsSubmittedToday { get; set; }
        public int ReportsSubmittedLastThirtyDays { get; set; }
        public int HostsSeenToday { get; set; }
        public int HostsSeenLastThirtyDays { get; set; }
        public bool IsDatabaseActive { get; set; }
        public List<HostData> NonCompliantHosts { get; private set; }
        public List<LpaVersionData> LpaVersionReports { get; private set; }

        public HomeModel()
        {
            NonCompliantHosts = new List<HostData>();
            LpaVersionReports = new List<LpaVersionData>();
        }
    }


}