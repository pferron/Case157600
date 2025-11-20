
using System.ComponentModel.DataAnnotations;

namespace WOW.WoodmenReconService.Models
{
    public class ReconReportRequestDataItem
    {
        [Required]
        public string DataName { get; set; }
        public string DataValue { get; set; }
    }
}