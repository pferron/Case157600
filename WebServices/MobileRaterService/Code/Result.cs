using Newtonsoft.Json;

namespace WOW.MobileRaterService.Code
{
    internal class Result
    {
        public string RequestId { get; set; }

        [JsonIgnore]
        public bool HasPdf
        {
            get
            {
                return !string.IsNullOrWhiteSpace(IllustrationPdf);
            }
        }

        public string IllustrationPdf { get; set; }

        public string ErrorMessage { get; set; }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}