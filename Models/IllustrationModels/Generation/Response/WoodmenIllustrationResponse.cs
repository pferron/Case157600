
using Newtonsoft.Json;

namespace WOW.Illustration.Model.Generation.Response
{
    public class WoodmenIllustrationResponse
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


        public string PdfFileAttachment { get; set; }

        [JsonIgnore]
        public bool HasPdfFile
        {
            get
            {
                return !string.IsNullOrWhiteSpace(PdfFileAttachment);
            }
        }

        public string ValuesFileAttachment { get; set; }

        [JsonIgnore]
        public bool HasValuesFile
        {
            get
            {
                return !string.IsNullOrWhiteSpace(ValuesFileAttachment);
            }
        }

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

            var p = obj as WoodmenIllustrationResponse;

            if (p == null)
            {
                return false;
            }

            return (RequestId == p.RequestId) &&
                (ErrorMessage == p.ErrorMessage) &&
                (PdfFileAttachment == p.PdfFileAttachment) &&
                (ValuesFileAttachment == p.ValuesFileAttachment);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}