
using Newtonsoft.Json;
using WOW.Illustration.Model.Enums;

namespace WOW.Illustration.Model.Generation.Request
{
    /// <summary>
    /// Report:Policy
    /// The base class for reports
    /// Inherits from Policy
    /// </summary>
    public class Report
    {
        public ReportType Code { get; set; }

        public decimal InterestRate { get; set; }

        public decimal SalesCharge { get; set; }

        // Seems like this would be a decimal, but the StoneRiver code has it as an int
        public int TermRates { get; set; }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
