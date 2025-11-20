using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSandbox
{
    public class IndependenceRateInput
    {
        [Required]
        [Range(0, 85)]
        public int Age { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string RatingClass { get; set; }
        /// <summary>
        /// Expected values for Gender: M, F, U
        /// </summary>
        [Required]
        public string Gender { get; set; }
        [Required]
        public decimal Dues { get; set; }
        /// <summary>
        /// Expected values for PaymentMode: Monthly, Quarterly, Semi-Annual, Annual
        /// </summary>
        [Required]
        public string PaymentMode { get; set; }
        /// <summary>
        /// Expected values for BillType: List Bill, PAC, Direct Bill
        /// </summary>
        [Required]
        public string BillType { get; set; }
        [Required]
        public decimal FaceAmount { get; set; }
        public bool Workplace { get; set; }
        public bool Tobacco { get; set; }
        public bool HasAccidentalDeathRider { get; set; }
        public string UserAgent { get; set; }
        public string NetworkType { get; set; }
        [Required]
        public string SalesRepCode { get; set; }
        public bool IsPatriotSeries { get; set; }
    }
}
