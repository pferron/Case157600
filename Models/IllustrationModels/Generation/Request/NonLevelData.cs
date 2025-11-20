using Newtonsoft.Json;
using System.Collections.Generic;

namespace WOW.Illustration.Model.Generation.Request
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1027:MarkEnumsWithFlags")]
    public enum DataType
    {
        None = 0,
        CoverageBenefit = 1,
        PaymentSchedule = 2,
        PartialSurrender = 3,
        Loan = 4,
        Repayment = 5,
        DeathBenefit = 6,
        LumpSum = 8,
        PaymentScheduleTraditional = 9
    }

    /// <summary>
    /// Non level data object
    /// Additional policy specific data
    /// </summary>
    public class NonLevelData
    {
        public DataType DataTypeCode { get; set; }

        public int Level { get; set; }

        public IList<int> Codes { get; private set; }

        public IList<decimal> Amounts { get; private set; }

        /// <summary>FIP:NLAge</summary>
        public int Age { get; set; }

        public int ToAge { get; set; }

        public NonLevelData()
        {
            Codes = new List<int>();
            Amounts = new List<decimal>();
        }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
