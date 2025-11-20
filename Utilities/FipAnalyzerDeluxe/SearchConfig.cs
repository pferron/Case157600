
namespace FipAnalyzerDeluxe
{
    class SearchConfig
    {
        public IllustrationOptions.RatingClass RatingClass { get; set; }
        public IllustrationOptions.IllustrationType IllustrationType { get; set; }
        public IllustrationOptions.ProductType ProductType { get; set; }
        public IllustrationOptions.BillType BillType { get; set; }
        public IllustrationOptions.BillMode BillMode { get; set; }

        public bool IncludeTableRated { get; set; }
        public bool IncludeFlatExtra { get; set; }

        public IllustrationOptions.SignedState SignedState { get; set; }

        public IllustrationOptions.AgeGroup AgeGroup { get; set; }

        public bool IncludeCostBenefit { get; set; }

        public bool IncludeAcceleratedBenefit { get; set; }
        public bool IncludeAccidentalDeath { get; set; }
        public bool IncludeWaiverOfPremium { get; set; }
        public bool IncludeApplicantWaiver { get; set; }

        public bool IncludeDividendOptionCash { get; set; }

        public bool IncludeDividendOptionLeftWithWoodmen { get; set; }

        public bool IncludeDividendOptionReducePremiums { get; set; }

        public bool IncludeDividendOptionPaidUpAdditional { get; set; }
    }
}
