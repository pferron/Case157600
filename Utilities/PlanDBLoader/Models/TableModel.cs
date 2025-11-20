using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDBLoader.Models
{
    public class TableModel
    {
        public string TableName { get; set; }
        public HashSet<string> Header { get; set; }
        public HashSet<TableValuesModel> Values { get; set; }
    }
}
