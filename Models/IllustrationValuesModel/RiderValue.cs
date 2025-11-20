using System.Collections.Generic;

namespace WOW.Illustration.ValuesModel
{
    public class RiderValue
    {
        public RiderValue()
        {
            MiscellaneousValues = new List<string>();
            Name = string.Empty;
        }

        public int Age { get; set; }
        public decimal Amount { get; set; }
        public decimal Amount2 { get; set; }
        public decimal AnnualPremium { get; set; }
        public int Class { get; set; }
        public int Insured { get; set; }
        public int IssueAge { get; set; }
        public int Level { get; set; }
        public IList<string> MiscellaneousValues { get; set; }
        public string Name { get; set; }
        public decimal RatingExtra { get; set; }
        public int RatingExtraToAge { get; set; }
        public int RatingTable { get; set; }
        public int RatingTableToAge { get; set; }
        public int RiderCode { get; set; }
        public int Sex { get; set; }
        public int ToAge { get; set; }
        public int Toggle { get; set; }
    }
}
