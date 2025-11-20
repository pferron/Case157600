using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WOW.WoodmenReconService.Models
{
    public class LpaVersionData
    {
        public string Hostname { get; set; }
        public string LpaVersion { get; set; }
        public DateTime ReportReceivedDate { get; set; }
    }
}