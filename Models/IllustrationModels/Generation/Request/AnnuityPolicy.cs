using Newtonsoft.Json;
using System.Collections.Generic;

namespace WOW.Illustration.Model.Generation.Request
{
    /// <summary>
    /// AnnuityPolicy:Policy
    /// The abstract annuity policy product object
    /// Inherits from Policy
    /// </summary>
    public abstract class AnnuityPolicy : Policy
    {
        /// <summary>FIP:primaryPct, typically, set to 0</summary>
        public decimal PrimaryPercent { get; set; }

        /// <summary>Typically, set to 10</summary>
        public int CertainYear { get; set; }

        /// <summary>FIP:DfrAnCertYr, typically set to 9</summary>
        public int DeferredAnnuityCertainYear { get; set; }

        /// <summary>FIP:InitGuarPeriod, set to 1 when initial period is one year, set to 0 when intial period is one month.</summary>
        public int? InitialGuaranteePeriod { get; set; }

        /// <summary>FIP:AnRateCode, typically set to 0</summary>
        public int AnnuityRateCode { get; set; }

        /// <summary>FIP:HdrBandRate1 thru HdrBandRate6</summary>
        public IList<decimal> HeaderBandRates { get; private set; }

        /// <summary>FIP:SecondaryGuarRate</summary>
        public decimal SecondaryGuaranteeRate { get; set; }

        /// <summary>FIP:MinGuarRate</summary>
        public decimal MinimumGuaranteeRate { get; set; }

        public decimal BonusRate { get; set; }

        protected AnnuityPolicy()
        {
            HeaderBandRates = new List<decimal>();
        }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
