using System;
using System.Linq;
using WOW.Illustration.Model.Generation.Request;
using WOW.WoodmenIllustrationService.SharedModels;

namespace WOW.RaterUtilities
{
    abstract class PolicyBuilder : IPolicyBuilder
    {
        public Policy Policy { get; set; }

        /// <summary>
        /// No agent data is provided from the rater app, so this method populates default values
        /// </summary>
        /// <param name="raterData">Request from rater application.</param>
        public virtual void HydrateAgentData(RaterRequest raterData)
        {
            Policy.Agent = new AgentPerson();

            //Policy.Agent.Id = "999999";
            Policy.Agent.FirstName = "Rater";
            Policy.Agent.MiddleName = string.Empty;
            Policy.Agent.LastName = "Application";
            Policy.Agent.AddressLine1 = "1700 Farnam Street";
            Policy.Agent.AddressLine2 = string.Empty;
            Policy.Agent.AddressCity = "Omaha";
            Policy.Agent.AddressState = "NE";
            Policy.Agent.AddressZipCode = "68102";
            Policy.Agent.PhoneNumber = "800-225-3108";
            // Only present for certain states
            //Policy.Agent.LicenseNumber = String.Empty;
            //Policy.Agent.LicenseState = String.Empty;

        }

        /// <summary>
        /// Parses client data from the rater request object.
        /// </summary>
        /// <param name="raterData">Request from rater application.</param>
        public virtual void HydrateClientData(RaterRequest raterData)
        {
            Policy.Client = new ClientPerson();

            Policy.Client.FirstName = raterData.FirstName;
            Policy.Client.MiddleName = string.Empty;
            Policy.Client.LastName = raterData.LastName;
            Policy.Client.NameSuffix = string.Empty;
            Policy.Client.Age = raterData.Age;
            Policy.Client.Birthdate = raterData.BirthDate;
            Policy.Client.Gender = raterData.Sex;
            Policy.Client.AddressState = raterData.State;
            //Policy.Client.Country = "USA";
        }

        /// <summary>
        /// Parses common data from the rater request object.
        /// </summary>
        /// <param name="raterData">Request from rater application.</param>
        public virtual void HydrateCommonData(RaterRequest raterData)
        {
            //We don't need the PDF file for rater requests.
            Policy.GeneratePdf = false;
            //TODO: Eliminate dependency on the Text file
            Policy.GenerateValuesTextFile = true;

            Policy.CategoryCode = raterData.CategoryCode;
            Policy.ConceptCode = raterData.ConceptCode;
            Policy.HeaderCode = raterData.HeaderCode;
            Policy.ClassType = raterData.ClassType;
            Policy.IsRevisedIllustration = false;
            Policy.NeedsCostBenefit = false;
            Policy.SceneModifyDate = DateTime.Now;

            // Fetch the state value
            var tmpState = raterData.State;
            int stateCode;

            // Try to parse to int to see if it is a state code
            if (int.TryParse(tmpState, out stateCode))
            {
                Policy.SignedState = StateHelper.GetStateAbbreviation(stateCode);
            }
            else
            {
                // The state value is longer that a state abbreviation and a state code
                // Pass the state name in for the abbreviation
                if (tmpState.Length > 2)
                {
                    Policy.SignedState = StateHelper.GetStateAbbreviation(tmpState);
                }
                else
                {
                    Policy.SignedState = tmpState;
                }
            }

            //Policy.PlanIsUnisex = (raterData.PlanUnisex == 1);
            //Policy.PlanIsQualified = (raterData.PlanQualified == 1);
            Policy.RatingAmount = raterData.RtgAmt;
            //Policy.RatingAmountToAge = raterData.RtgAmtToAge;
            Policy.RatingExtra1 = raterData.RtgExtra_1;
            //Policy.RatingExtra2 = raterData.RtgExtra_2;
            Policy.RatingExtraToAge1 = raterData.RtgExtra_1ToAge;
            //Policy.RatingExtraToAge2 = raterData.RtgExtra_2ToAge;
            Policy.Lump1035Amount = raterData.Lump1035Amt;
            Policy.SettlementAge = 0;
            //Policy.LoanInterestUsage = (raterData.LoanUsageType == 1);
            //Policy.PrintToAge = 0;
            Policy.PolicyNumber = string.Empty;
            //Policy.WithdrawalToLoan = raterData.WdrlToLoan;
            //Policy.StateNAICApproved = (raterData.StateNAICApproved == 1);
            Policy.NumberOfOwners = 1;
            Policy.BelowMinimumPremium = false;
        }

        /// <summary>
        /// Parses rider data from the [ALLRIDERDATA] section of a FIP file.
        /// </summary>
        /// <param name="fipData">Object representation of a FIP file.</param>
        public virtual void HydrateRiderData(RaterRequest raterData)
        {
            if (raterData.Riders.Any())
            {
                foreach (var item in raterData.Riders)
                {
                    var rider = new Rider();

                    rider.Age = item.Age;
                    rider.Amount = item.Amount;
                    rider.Class = item.Class;
                    rider.IssueAge = item.IssueAge;
                    rider.Name = item.Name;
                    rider.RatingAmount = item.RatingAmount;
                    rider.RatingExtra = 0;
                    rider.RatingExtraToAge = 0;
                    rider.Sex = 0;
                    rider.RiderType = item.Type;

                    // The Bridge will include the [ALLRIDERDATA] even if there are no riders.
                    // So, I'm going to suppress any default rider objects here.
                    // This may not apply to the rating app, but it is a nice safety feature.
                    if (rider.RiderType > 0)
                    {
                        Policy.Riders.Add(rider);
                    }
                }
            }
        }

        /// <summary>
        /// Parses non-level data from the [NONLEVELDATA] & [NONLEVELPOLICYDATA] sections of a FIP file.
        /// </summary>
        /// <param name="fipData">Object representation of a FIP file.</param>
        public virtual void HydrateNonLevelData(RaterRequest raterData)
        {
            if (raterData.NonLevelData.Any())
            {
                foreach (var item in raterData.NonLevelData)
                {
                    var data = new NonLevelData();

                    data.Age = item.Age;
                    data.Amounts.Add(item.Amount1);
                    //data.Amounts.Add(item.Amount2);
                    data.Codes.Add(item.Code1);
                    data.Codes.Add(item.Code2);
                    data.DataTypeCode = (DataType)item.DataTypeCode;
                    //data.GradePercent = 0M;
                    data.Level = item.Level;
                    //data.Rates.Add(item.Rate);

                    Policy.NonLevelData.Add(data);
                }
            }
        }

        public abstract void HydratePolicySpecificData(RaterRequest raterData);

        /// <summary>
        /// Returns the loaded IPolicy object.
        /// </summary>
        public abstract Policy GetPolicy();
    }
}
