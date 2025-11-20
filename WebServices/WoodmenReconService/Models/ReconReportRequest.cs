using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WOW.WoodmenReconService.Models
{
    public class ReconReportRequest
    {
        [Required]
        public string Hostname { get; set; }
        public string ReportName { get; set; }
        public DateTime ReportCreateDateUtc { get; set; }

        public List<ReconReportRequestDataItem> DataItems { get; set; }
    }
}