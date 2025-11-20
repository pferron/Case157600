using Newtonsoft.Json;
using System.Globalization;

namespace WOW.PEIllustrationModel.Response
{
    public class FipResponse
    {
        public string ErrorMessage { get; set; }

        [JsonIgnore]
        public bool HasError
        {
            get
            {
                return !string.IsNullOrWhiteSpace(ErrorMessage);
            }
        }


        public string PdfFilePath { get; set; }

        [JsonIgnore]
        public bool HasPdfFile
        {
            get
            {
                return !string.IsNullOrWhiteSpace(PdfFilePath);
            }
        }

        public string ValuesFilePath { get; set; }

        [JsonIgnore]
        public bool HasValuesFile
        {
            get
            {
                return !string.IsNullOrWhiteSpace(ValuesFilePath);
            }
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, " Error Message: {0}, PDF File Path: {1}, Values File Path: {2}", ErrorMessage, PdfFilePath, ValuesFilePath);
        }
    }
}
