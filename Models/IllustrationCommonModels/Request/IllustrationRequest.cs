using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Validation.ChildObject;
using Validation.ChildObjectList;

namespace Wow.IllustrationCommonModels.Request
{
    public class IllustrationRequest
    {
        [Required, MinLength(1, ErrorMessage = "ApplicationSignedStateCode cannot be empty.")]
        public string ApplicationSignedStateCode { get; set; }

        [Required, Range(0, int.MaxValue, ErrorMessage = "BillingAmount must be 0 or greater.")]
        public decimal BillingAmount { get; set; }

        [Required, MinLength(1, ErrorMessage = "BillingMethodCode cannot be empty.")]
        public string BillingMethodCode { get; set; }

        [Required, MinLength(1, ErrorMessage = "BillingModeCode cannot be empty.")]
        public string BillingModeCode { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "DeathBenefitOptionCode cannot be null.")]
        public string DeathBenefitOptionCode { get; set; }

        [Required, Range(0, int.MaxValue, ErrorMessage = "Exchange1035Amount must be 0 or greater.")]
        public decimal Exchange1035Amount { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "SevenPayPremiumAmount must be 0 or greater.")]
        public decimal SevenPayPremiumAmount { get; set; }

        [Required, Range(0, int.MaxValue, ErrorMessage = "FaceAmount must be 0 or greater.")]
        public decimal FaceAmount { get; set; }

        [Required, MinLength(1, ErrorMessage = "IllustrationReportType cannot be empty.")]
        public string IllustrationReportType { get; set; }

        //To be used later for InForce illustrations
        [Required, Range(0, int.MaxValue, ErrorMessage = "IllustrationTypeCode must be greater than zero.")]
        public int IllustrationTypeCode { get; set; }

        [Required, Range(0, int.MaxValue, ErrorMessage = "InitialPremium must be 0 or greater.")]
        public decimal InitialPremium { get; set; }

        [Required, Range(0, 85, ErrorMessage = "IssueAge must be greater than 0.")]
        public int IssueAge { get; set; }

        [Required(ErrorMessage = "IssueDate cannot be empty.")]
        public DateTime? IssueDate { get; set; }

        [Required(ErrorMessage = "MECAllowedIndicator cannot be empty.")]
        public bool? MECAllowedIndicator { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "PermanentTableRatingCode cannot be null.")]
        public string PermanentTableRatingCode { get; set; }

        // Not used. The WIM / ACORD conversion uses the current age or issue age
        //public DateTime? PermanentTableRatingEndDate { get; set; }

        [Required, MinLength(1, ErrorMessage = "PlanId cannot be empty.")]
        public string PlanId { get; set; }

        [Required, MinLength(1, ErrorMessage = "PolicyId cannot be empty.")]
        public string PolicyId { get; set; }

        [Required, MinLength(1, ErrorMessage = "ProductTypeCode cannot be empty.")]
        public string ProductTypeCode { get; set; }

        [Required, Range(0, double.MaxValue, ErrorMessage = "TemporaryFlatExtraRateAmount must be 0 or greater.")]
        public decimal TemporaryFlatExtraRateAmount { get; set; }

        public DateTime? TemporaryFlatExtraEndDate { get; set; }

        [Required, Range(0, double.MaxValue, ErrorMessage = "TemporaryFlatExtraAmount must be 0 or greater.")]
        public decimal TemporaryFlatExtraAmount { get; set; }
        
        [Required, CompositeObjectValidation]
        public AgentPerson Agent { get; set; }

        [Required, CompositeObjectValidation]
        public ClientPerson Client { get; set; }


        [CompositeValidateEachItem]
        public IList<Coverage> Coverages { get; set; }

        [CompositeValidateEachItem]
        public IList<FundAccount> Funds { get; set; }


        public IllustrationRequest()
        {
            Agent = new AgentPerson();
            Client = new ClientPerson();
            Funds = new List<FundAccount>();
            Coverages = new List<Coverage>();
        }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
