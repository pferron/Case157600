using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wow.IllustrationCommonModels.Request;

namespace CommonIllustrationServiceTester.Code
{
    internal class GenerateIULRequest
    {
        private static IllustrationRequest illustrationRequest;

        internal static IllustrationRequest CreateIllustrationRequest()
        {
            illustrationRequest = new IllustrationRequest();

            PopulateMainProperties();
            PopulateAgent();
            PopulateClient();
            PopulateCoverages();

            return illustrationRequest;
        }

        private static void PopulateMainProperties()
        {
            illustrationRequest.PlanId = "TUINDEXC";
            illustrationRequest.ProductTypeCode = "INDXUL";
            illustrationRequest.IllustrationTypeCode = 1;
            illustrationRequest.IssueDate = DateTime.Now;
            illustrationRequest.IssueAge = 55;
            illustrationRequest.ApplicationSignedStateCode = "NE";
            illustrationRequest.Exchange1035Amount = 1000.50m;
            illustrationRequest.PolicyId = "009292895";
            illustrationRequest.FaceAmount = 500000;
            illustrationRequest.BillingModeCode = "MNTHLY";
            illustrationRequest.BillingAmount = 100.50m;
            illustrationRequest.BillingMethodCode = "PAC";
            illustrationRequest.InitialPremium = 600.20m;
            illustrationRequest.IllustrationReportType = "COST";
            illustrationRequest.MECAllowedIndicator = false;
            illustrationRequest.PermanentTableRatingCode = "C";
            illustrationRequest.DeathBenefitOptionCode = "INCR";
            illustrationRequest.TemporaryFlatExtraEndDate = DateTime.Parse("01-02-2030");
            illustrationRequest.TemporaryFlatExtraRateAmount = 100;
        }

        private static void PopulateAgent()
        {
            illustrationRequest.Agent = new AgentPerson();
            illustrationRequest.Agent.FirstName = "Jane";
            illustrationRequest.Agent.MiddleName = "Alex";
            illustrationRequest.Agent.LastName = "Doe";
            illustrationRequest.Agent.AddressLine1 = "123 Rainbow Rd";
            illustrationRequest.Agent.AddressLine2 = "";
            illustrationRequest.Agent.AddressCity = "Omaha";
            illustrationRequest.Agent.AddressStateCode = "NE";
            illustrationRequest.Agent.AddressZip = "68145";
            illustrationRequest.Agent.PhoneNumber = "4023331234";
        }

        private static void PopulateClient()
        {
            illustrationRequest.Client = new ClientPerson();
            illustrationRequest.Client.FirstName = "John";
            illustrationRequest.Client.MiddleName = "Jesse";
            illustrationRequest.Client.LastName = "Parker";
            illustrationRequest.Client.NameSuffix = "Jr.";
            illustrationRequest.Client.BirthDate = DateTime.Parse("09-07-84");
            illustrationRequest.Client.GenderCode = "Male";
            illustrationRequest.Client.AddressStateCode = "NE";
            illustrationRequest.Client.AddressCountryCode = "1";

        }

        private static void PopulateCoverages()
        {
            illustrationRequest.Coverages = new List<Coverage>();
            Coverage coverage1 = new Coverage();
            coverage1.PlanId = "TUINDEXN";
            coverage1.CoverageTypeCode = "ABE";
            coverage1.CurrentAmt = 100;
            coverage1.IssueAge = 55;
            coverage1.FaceAmount = 500;
            coverage1.TobaccoPremiumBasisCode = "NONSMOKER";
            illustrationRequest.Coverages.Add(coverage1);

            Coverage coverage2 = new Coverage();
            coverage2.PlanId = "TUINDEXN";
            coverage2.CoverageTypeCode = "ADBCHRONILL";
            coverage2.CurrentAmt = 2321.22m;
            coverage2.IssueAge = 21;
            coverage2.FaceAmount = 200.12m;
            coverage2.TobaccoPremiumBasisCode = "PRESMOKER";
            illustrationRequest.Coverages.Add(coverage2);
        }
    }
}
