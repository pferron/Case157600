
using Newtonsoft.Json;

namespace WOW.Illustration.Model.Generation.Request
{
    /// <summary>
    /// </summary>
    public class Rider
    {
        public int RiderType { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int Sex { get; set; }

        public decimal Amount { get; set; }

        public int IssueAge { get; set; }

        public int ToAge { get; set; }

        public int Class { get; set; }

        public int RatingAmount { get; set; }

        public int RatingAmountToAge { get; set; }

        public decimal RatingExtra { get; set; }

        public int RatingExtraToAge { get; set; }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
