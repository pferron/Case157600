using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessorShared
{
    public class ProcessorResult
    {
        public bool Pass { get; set; }
        public List<string> ErrorList { get; set; }
    }
}
