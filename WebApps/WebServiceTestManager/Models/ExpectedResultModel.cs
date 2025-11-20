using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceTestManager.Models
{
    public class ExpectedResultModel
    {
        public Guid Id { get; set; }
        public Guid TestId { get; set; }
        public string PropertyName { get; set; }
        public string ExpectedValue { get; set; }
        public int Type { get; set; }
    }
}