using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPA.Dashboard.Models.View
{
    public enum DeploymentRegion
    {
        UAT = 1,
        Test = 0,
        Modl = 2,
        Prod = 3,
        Int = 4
    }
    public enum Status
    {
        Pass = 0,
        Fail = 1,
        Scheduled = 2,
        InProgress = 3
    }
    public class Deployment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public string CreatedBy { get; set; }
        public List<ResourceDeployment> Deployments { get; set; }
    }

    public class ResourceDeployment
    {
        public DateTime DeploymentDate { get; set; }
        public int Region { get; set; }
        public string Version { get; set; }
        public string DeployedBy { get; set; }
    }

}
