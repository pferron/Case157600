using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceTestManager.Models
{
    public class TestExecutionModel : IViewModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public Guid TestIdentifier { get; set; }
        public string DestinationName { get; set; }

        public DateTime ExecutionDate { get; set; }

        public string Summary { get; set; }
    }
}