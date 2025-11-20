using log4net;
using Common = Wow.IllustrationCommonModels.Request;
using WOW.Illustration.Model.Generation.Request;
using System;
using WOW.Illustration.Model.Enums;
using Wow.CommonIllustrationService.DAO;
using Wow.CommonIllustrationService.Exceptions;
using Wow.CommonIllustrationService.LookupBuilders;

namespace Wow.CommonIllustrationService.Builders
{

    public abstract class CommonPolicyConverter
    {

        private static readonly ILog log = LogManager.GetLogger(typeof(CommonPolicyConverter));

        protected Common.IllustrationRequest Request;
        protected Policy Policy { get; set; }

        public CommonPolicyConverter()
        {
        }

        // This forces descendant class to override method even if it will be empty
        abstract protected void HydratePolicySpecificData();

        protected void HydrateAgentData()
        {
            if (log.IsInfoEnabled) log.Info($"HydrateAgentData called.");

            Policy.Agent = new AgentPerson
            {
                FirstName = Request.Agent.FirstName,
                MiddleName = Request.Agent.MiddleName,
                LastName = Request.Agent.LastName,
                //NameSuffix = request.Agent.NameSuffix,
                AddressLine1 = Request.Agent.AddressLine1,
                AddressLine2 = Request.Agent.AddressLine2,
                AddressCity = Request.Agent.AddressCity,
                AddressState = Request.Agent.AddressStateCode,
                AddressZipCode = Request.Agent.AddressZip,
                PhoneNumber = Request.Agent.PhoneNumber
            };
        }

        protected void HydrateClientData()
        {
            if (log.IsInfoEnabled) log.Info($"HydrateClientData called.");

            Policy.Client = new ClientPerson
            {
                FirstName = Request.Client.FirstName,
                MiddleName = Request.Client.MiddleName,
                LastName = Request.Client.LastName,
                NameSuffix = Request.Client.NameSuffix,
                // This is needed because Client.BirthDate is nullable for validation rules
                // However, if code reaches here then it will be a valid DateTime value
                Birthdate = Request.Client.BirthDate ?? DateTime.Now,
                Age = Request.Client.Age,
                Gender = Request.Client.GenderCode.ToLower() == "male" ? 0 : 1
                // AddressStateCode and AddressCountryCode not required for WIM request
            };
        }

        protected virtual void HydrateCommonData()
        {
            if (log.IsInfoEnabled) log.Info($"HydrateCommonData called.");

            CommonLookups commonLookups = new CommonLookups();

            Policy.PolicyNumber = Request.PolicyId;
            Policy.SignedState = Request.ApplicationSignedStateCode;

            Policy.Lump1035Amount = Request.Exchange1035Amount;
            Policy.Guideline7Pay = Request.SevenPayPremiumAmount;

            // This is needed because Request.IssueDate is nullable for validation rules
            // However, if code reaches here then it will be a valid DateTime value
            Policy.IssueDate = Request.IssueDate ?? DateTime.Now;
            Policy.SceneModifyDate = Request.IssueDate ?? DateTime.Now;
            Policy.DataDate = Request.IssueDate ?? DateTime.Now;

            Policy.GeneratePdf = true;
            Policy.GenerateValuesTextFile = false;

            // Maps CIM 'A' to Sapiens '1', etc.
            Policy.RatingAmount = commonLookups.ConvertRating(Request.PermanentTableRatingCode);
            // Request.PermanentTableRatingEndDate is not used because the WIS calculates the end date internally

            Policy.InitialPremium = Request.InitialPremium;
            Policy.NumberOfOwners = 1; // Number of sigs is fixed on LPA output, so setting to 1, similar to the PrintExpert Bridge

            // Not needed for IUL, this is an AUL only feature.
            // PrintAsTobacco is true if the product is AUL and the age is less than 19, per Bridge

            var currentDateTime = DateTime.Now;
            Policy.RatingExtraToAge1 = commonLookups.CalculateAge(Request.Client.BirthDate ?? currentDateTime, Request.TemporaryFlatExtraEndDate ?? currentDateTime);
            Policy.RatingExtra1 = Request.TemporaryFlatExtraAmount; // NOTE: This represents the annual amount

        }

        protected virtual void HydrateRiderData()
        {
            if (log.IsInfoEnabled) log.Info($"HydrateRiderData called.");

            // This is needed because Request.IssueDate is nullable for validation rules
            // However, if code reaches here then it will be a valid DateTime value
            var requestDate = Request.IssueDate ?? DateTime.Now;

            var riderConverter = new RiderConverter();
            var riders = riderConverter.Build(Request.Coverages, Request.Client.GenderCode, Request.Client.BirthDate);

            foreach (var rider in riders)
            {
                Policy.Riders.Add(rider);
            }
        }

        protected virtual Policy HydratePolicyData()
        {
            if (log.IsInfoEnabled) log.Info($"HydratePolicyData called.");

            HydrateAgentData();
            HydrateClientData();
            HydrateCommonData();
            HydrateRiderData();
            return Policy;
        }


 

    }

}