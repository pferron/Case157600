using Newtonsoft.Json;

namespace WOW.Illustration.Model.Generation.Request
{
    /// <summary>
    /// NoLapseGuaranteedUniversalLifePolicy:UniversalLifePolicy
    /// The no lapse guaranteed univesal life policy object
    /// Inherits from UniversalLifePolicy
    /// </summary>
    public class NoLapseGuaranteedUniversalLifePolicy : UniversalLifePolicy
    {
        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
