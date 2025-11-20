using log4net;
using System;
using System.Linq;
using System.Threading.Tasks;
using WOW.Illustration.Model.Generation.Request;
using WOW.WoodmenIllustrationService.Code;
using WOW.WoodmenIllustrationService.LookupBuilders;
using WOW.WoodmenIllustrationService.Models;
using WoodmenLife.Enterprise.Illustration.Models.Titanium;

namespace WOW.WoodmenIllustrationService.Builders
{
    public abstract class CommonPolicyConverter
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(CommonPolicyConverter));

        protected TiPolicyDetail Request;
        protected Policy Policy { get; set; }

        public CommonPolicyConverter()
        {
        }

        // This forces descendant class to override method even if it will be empty
        abstract protected void HydratePolicySpecificData();

        protected void HydrateAgentData()
        {
            if (log.IsInfoEnabled) log.Info($"HydrateAgentData called.");

            FasatUtilities fasatUtilities = new FasatUtilities();

            var rep = Request.PolicyProducers.First(p => p.ProducerRole.Code == "SERVAGENT");

            Task<Agents> task = Task.Run(() => fasatUtilities.GetAgents(rep.ProducerId));
            task.Wait();

            var agents = task.Result;

            var agent = agents.RelatedAgents.First(a => a.FRCode == rep.ProducerId);

            Policy.Agent = new AgentPerson
            {                
                FirstName = agent.FirstName.Trim(),
                MiddleName = agent.MiddleName.Trim(),
                LastName = agent.LastName.Trim(),
                NameSuffix = agent.Suffix.Trim(),
                AddressLine1 = agent.Address1.Trim(),
                AddressLine2 = agent.Address2.Trim(),
                AddressCity = agent.City.Trim(),
                AddressState = agent.State.Trim(),
                AddressZipCode = agent.Zip.Trim(),
                PhoneNumber = agent.OfficePhone.Trim()
            };
            
        }

        protected void HydrateClientData()
        {
            if (log.IsInfoEnabled) log.Info($"HydrateClientData called.");

            CommonLookups commonLookups = new CommonLookups();
            ClientHelper clientHelper = new ClientHelper();

            Client primaryClient = clientHelper.GetPrimaryClient(Request.PolicyClients, Request.Clients);

            Policy.Client = new ClientPerson
            {
                FirstName = primaryClient.FirstName,
                MiddleName = primaryClient.MiddleName,
                LastName = primaryClient.LastName,
                NameSuffix = primaryClient.NameSuffix,
                // This is needed because Client.BirthDate is nullable for validation rules
                // However, if code reaches here then it will be a valid DateTime value
                Birthdate = primaryClient.BirthDate ?? DateTime.Now,
                Age = commonLookups.CalculateAge(primaryClient.BirthDate ?? DateTime.Now, DateTime.Today),
                Gender = primaryClient.Gender.Code.ToLower() == "male" ? 0 : 1                
            };
        }

        protected virtual void HydrateCommonData()
        {
            if (log.IsInfoEnabled) log.Info($"HydrateCommonData called.");

            CommonLookups commonLookups = new CommonLookups();
            CoverageHelper coverageHelper = new CoverageHelper();
            ClientHelper clientHelper = new ClientHelper();

            Client primaryClient = clientHelper.GetPrimaryClient(Request.PolicyClients,Request.Clients);

            Coverage baseCoverage = coverageHelper.GetBaseCoverage(Request.Coverages);

            Policy.PolicyNumber = Request.PolicyId;
            Policy.SignedState = Request.ApplicationSignedState.Code;

            Policy.Lump1035Amount = 0.0M;            

            // This is needed because Request.IssueDate is nullable for validation rules
            // However, if code reaches here then it will be a valid DateTime value
            Policy.IssueDate = Request.EffectiveDate ?? DateTime.Now;
            Policy.SceneModifyDate = Request.EffectiveDate ?? DateTime.Now;
            Policy.DataDate = Request.AsOfDate ?? DateTime.Now;
            Policy.IssueAge = coverageHelper.GetBaseCoverage(Request.Coverages).IssueAge;

            Policy.GeneratePdf = true;
            Policy.GenerateValuesTextFile = false;            

            // Maps CIM 'A' to Sapiens '1', etc.
            if (baseCoverage.PermanentTableRating != null)
            {
                Policy.RatingAmount = commonLookups.ConvertRating(baseCoverage.PermanentTableRating.Code);
            }
            else
            {
                Policy.RatingAmount = 0;
            }
                                    
            // Request.PermanentTableRatingEndDate is not used because the WIS calculates the end date internally

            Policy.InitialPremium = 0.0M;
            Policy.NumberOfOwners = 0; // Number of sigs is fixed on LPA output, so setting to 1, similar to the PrintExpert Bridge

            // Not needed for IUL, this is an AUL only feature.
            // PrintAsTobacco is true if the product is AUL and the age is less than 19, per Bridge

            var currentDateTime = DateTime.Now;
            Policy.RatingExtraToAge1 = baseCoverage.TemporaryFlatExtraEndDate.HasValue
                ? commonLookups.CalculateAge(primaryClient.BirthDate ?? currentDateTime, baseCoverage.TemporaryFlatExtraEndDate.Value)
                : 0;
            Policy.RatingExtra1 = CalculateAnnualFlatExtraAmount(baseCoverage.TemporaryPerThousandAmount); // NOTE: This represents the annual amount
        }

        protected decimal RoundNearestHalf(decimal value)
        {
            var integerPart = decimal.Truncate(value);
            var fractionPart = value - decimal.Truncate(integerPart);
            var roundedFractionPart = Math.Round(fractionPart * 2, MidpointRounding.AwayFromZero) / 2;
            var newValue = integerPart + roundedFractionPart;
            return newValue;
        }
        protected decimal CalculateAnnualFlatExtraAmount(decimal? monthlyAmount)
        {
            if (monthlyAmount == 0 || monthlyAmount is null)
            {
                return 0;
            }
            double annualAmount = (double)monthlyAmount * 12.5;

            decimal roundedAnnualAmount = RoundNearestHalf((decimal)annualAmount);
            return roundedAnnualAmount;
        }

        protected virtual void HydrateRiderData()
        {
            CoverageHelper coverageHelper = new CoverageHelper();
            ClientHelper clientHelper = new ClientHelper();
            
            Client primaryClient = clientHelper.GetPrimaryClient(Request.PolicyClients, Request.Clients);
            

            if (log.IsInfoEnabled) log.Info($"HydrateRiderData called.");

            // This is needed because Request.IssueDate is nullable for validation rules
            // However, if code reaches here then it will be a valid DateTime value
            //var requestDate = Request.IssueDate ?? DateTime.Now;

            var riderConverter = new RiderConverter();            
            var riders = riderConverter.Build(Request.Coverages, primaryClient.Gender.Code, primaryClient.BirthDate, Request.ProposedChanges?.ProposedRiders);

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

            if (Request.ProposedChanges?.ProposedFaceAmountChange?.ReduceFaceAmount != true)
            {
                HydrateRiderData();
            }
            return Policy;
        }
    }
}