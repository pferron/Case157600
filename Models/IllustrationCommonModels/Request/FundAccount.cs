using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Wow.IllustrationCommonModels.Request
{
    public class FundAccount
    {
        [Required, MinLength(1, ErrorMessage = "FundAccountId cannot be empty.")]
        public string FundAccountId { get; set; }

        [Required, Range(0, double.MaxValue, ErrorMessage = "FundAllocationPercent must be 0 or greater.")]
        public decimal FundAllocationPercent { get; set; }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
