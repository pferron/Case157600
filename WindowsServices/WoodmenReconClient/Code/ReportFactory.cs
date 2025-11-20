using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOW.WoodmenReconClient.Models;

namespace WOW.WoodmenReconClient.Code
{
    abstract class ReportFactory
    {
        public ReconReport Report { get; private set; }

        public virtual void CreateReconReport()
        {
            Report = new ReconReport();
        }
    }
}
