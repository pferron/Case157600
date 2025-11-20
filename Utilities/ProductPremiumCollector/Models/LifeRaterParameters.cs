using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPremiumCollector.Models
{
    class LifeRaterParameters
    {
        public int Age { get; set; }
        public string Gender { get; set; }
        public bool Tobacco { get; set; }
        public decimal FaceAmount { get; set; }
        public string PaymentMode { get; set; }
        public string BillType { get; set; }
        public bool Gir { get; set; }
    }
}
