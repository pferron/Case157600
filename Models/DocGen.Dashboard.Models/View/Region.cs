using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPA.Dashboard.Models.View
{
    public class Region
    {
        public int RegionId { get; set; }
        public string Name { get; set; }
        public List<Agent> Agents { get; set; }

        public Region()
        {
            Agents = new List<Agent>();
        }
    }
}
