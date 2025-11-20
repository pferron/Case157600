using Newtonsoft.Json;

namespace WOW.Illustration.Model.Generation.Request
{
    public class SubAccount
    {
        /// <summary>
        /// ProductCode 100 is Fixed Account; ProductCode 200 is Indexed Account;
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// ACORD suggests a decimal data type for this property, but WoodmenLife will only use whole values for this field.
        /// </summary>
        public decimal AllocPercent { get; set; }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
