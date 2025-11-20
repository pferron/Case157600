using Newtonsoft.Json;

namespace WOW.Illustration.Model.Generation.Request
{
    /// <summary>
    /// DeferredAnnuityPolicy:AnnuityPolicy
    /// The deferred annuity policy object
    /// Inherits from AnnuityPolicy
    /// </summary>
    public class DeferredAnnuityPolicy : AnnuityPolicy
    {
        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
