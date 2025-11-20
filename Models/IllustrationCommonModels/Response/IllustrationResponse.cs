
using Newtonsoft.Json;

namespace Wow.IllustrationCommonModels.Response
{
    public class IllustrationResponse
    {
        public string RequestId { get; set; }

        public string ErrorMessage { get; set; }

        [JsonIgnore]
        public bool HasError
        {
            get
            {
                return !string.IsNullOrWhiteSpace(ErrorMessage);
            }
        }

        // Illustration PDF Base64 response.
        public string PdfFileAttachment { get; set; }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(this, settings);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var p = obj as IllustrationResponse;

            if (p == null)
            {
                return false;
            }

            return (RequestId == p.RequestId) &&
                (ErrorMessage == p.ErrorMessage) &&
                (PdfFileAttachment == p.PdfFileAttachment);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}