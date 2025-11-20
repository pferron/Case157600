
using Newtonsoft.Json;

namespace WOW.Illustration.Model.Generation.Request
{
    public class WholeLifePolicy : TraditionalLifePolicy
    {
        private const int YearsToMaturityWholeLife = 120;

        public bool Is20Pay { get { return HeaderCode == 262 || HeaderCode == 226 || HeaderCode == 222 || HeaderCode == 282 || HeaderCode == 292; } }

        public bool Is10Pay { get { return HeaderCode == 283 || HeaderCode == 293; } }

        public bool Is2017CsoWholeLifePaidUpAt65 { get { return HeaderCode == 281 || HeaderCode == 291; } }

        public override int YearsToMaturity
        {
            get { return YearsToMaturityWholeLife; }
        }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
