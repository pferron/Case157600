using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Wow.IllustrationCommonModels.Request
{
    public class Coverage
    {
        [Required, MinLength(1, ErrorMessage = "Coverage PlanId cannot be empty.")]
        public string PlanId { get; set; }

        [Required, MinLength(1, ErrorMessage = "Coverage CoverageTypeCode cannot be empty.")]
        public string CoverageTypeCode { get; set; }

        [Required, Range(0, int.MaxValue, ErrorMessage = "Coverage CurrentAmt must be 0 or greater.")]
        public decimal CurrentAmt { get; set; }

        [Required, Range(0, 85, ErrorMessage = "Coverage IssueAge must be greater than 0.")]
        public int IssueAge { get; set; }

        [Required, Range(0, int.MaxValue, ErrorMessage = "Coverage FaceAmount must be 0 or greater.")]
        public decimal FaceAmount { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "Coverage TobaccoPremiumBasisCode cannot be null, but may be empty.")]
        public string TobaccoPremiumBasisCode { get; set; }

        [Required, Range(0, int.MaxValue, ErrorMessage = "Coverage Rating must be greater than 0.")]
        public int PermanentTableRating { get; set; }

        public DateTime? PermanentTableRatingEndDate { get; set; }


        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
