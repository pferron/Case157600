using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wow.IllustrationCommonModels.Request;

namespace CommonIllustrationServiceTester.TestCases
{
    internal class TitaniumIulLoader
    {
        internal IllustrationRequest LoadIssueIulIllus(string iulFilePath)
        {
            IllustrationRequest illustrationRequest = new IllustrationRequest();

            var jsonSource = File.ReadAllText(iulFilePath);
            // add code to load JSON file into JObject
            JArray ctfJarray = JsonConvert.DeserializeObject<JArray>(jsonSource);

            JObject ctfJObject = (JObject)ctfJarray[0];

            dynamic dynObject = ctfJObject as dynamic;

            string illustrationReportType = dynObject.illustrationInfo.illustrationReportType.code;

            if (string.IsNullOrEmpty(illustrationReportType))
            {
                throw new Exception("dynObject.illustrationInfo.illustrationReportType.code is empty or null.");
            }
            else
            {
                if (illustrationReportType.Equals("NONE", StringComparison.InvariantCultureIgnoreCase))
                {
                    // No illustration is required
                    return null;
                }
                else
                {
                    BuildIllustrationRequestMainProperties(illustrationRequest, dynObject, illustrationReportType);
                    // NOTE: We must process coverages first so we get some key values into the main properties
                    // These key values come from the main coverage property set
                    BuildIllustrationRequestCoverageProperties(illustrationRequest, dynObject);
                    BuildIllustrationRequestFundProperties(illustrationRequest, dynObject);
                    BuildIllustrationRequestAgentProperties(illustrationRequest, dynObject);
                    BuildIllustrationRequestClientProperties(illustrationRequest, dynObject);

                    return illustrationRequest;
                }
            }
        }

        private void BuildIllustrationRequestMainProperties(IllustrationRequest illustrationRequest, dynamic dynObject, string illustrationReportType)
        {
            decimal decimalTest;
            bool boolTest;

            if (decimal.TryParse(dynObject.policyInfo.initialDepositAmount.ToString(), out decimalTest))
            {
                illustrationRequest.InitialPremium = decimalTest;
            }
            else
            {
                throw new Exception("dynObject.policyInfo.initialDepositAmount is not a valid decimal.");
            }

            illustrationRequest.ApplicationSignedStateCode = dynObject.policyInfo.applicationSignedState.code;
            if (string.IsNullOrEmpty(illustrationRequest.ApplicationSignedStateCode))
            {
                throw new Exception("dynObject.policyInfo.applicationSignedState.code is empty or null.");
            }

            if (decimal.TryParse(dynObject.policyInfo.billingAmount.ToString(), out decimalTest))
            {
                illustrationRequest.BillingAmount = decimalTest;
            }
            else
            {
                throw new Exception("dynObject.policyInfo.billingAmount is not a valid decimal.");
            }

            illustrationRequest.BillingMethodCode = dynObject.policyInfo.billingMethod.code;
            if (string.IsNullOrEmpty(illustrationRequest.BillingMethodCode))
            {
                throw new Exception("dynObject.policyInfo.billingMethod.code is empty or null.");
            }

            illustrationRequest.IllustrationReportType = illustrationReportType;

            illustrationRequest.BillingModeCode = dynObject.policyInfo.billingMode.code;
            if (string.IsNullOrEmpty(illustrationRequest.BillingModeCode))
            {
                throw new Exception("dynObject.policyInfo.billingMode.code is empty or null.");
            }

            illustrationRequest.DeathBenefitOptionCode = dynObject.policyInfo.deathBenefitOption.code;
            if (string.IsNullOrEmpty(illustrationRequest.DeathBenefitOptionCode))
            {
                throw new Exception("dynObject.policyInfo.deathBenefitOption.code is empty or null.");
            }

            if (decimal.TryParse(dynObject.policyInfo.exchange1035Amount.ToString(), out decimalTest))
            {
                illustrationRequest.Exchange1035Amount = decimalTest;
            }
            else
            {
                throw new Exception("dynObject.policyInfo.exchange1035Amount is not a valid decimal.");
            }

            if (decimal.TryParse(dynObject.policyInfo.sevenPayPremiumAmount.ToString(), out decimalTest))
            {
                illustrationRequest.SevenPayPremiumAmount = decimalTest;
            }
            else
            {
                illustrationRequest.SevenPayPremiumAmount = 0;
            }

            string mecAllowedIndicator = dynObject.policyInfo.mecAllowedIndicator;
            if (string.IsNullOrEmpty(mecAllowedIndicator))
            {
                illustrationRequest.MECAllowedIndicator = false;
            }
            else
            {
                if (bool.TryParse(dynObject.policyInfo.mecAllowedIndicator.ToString(), out boolTest))
                {
                    illustrationRequest.MECAllowedIndicator = boolTest;
                }
                else
                {
                    throw new Exception("dynObject.policyInfo.mecIndicator is not a valid bool.");
                }
            }

            illustrationRequest.PolicyId = dynObject.policyId;
            if (string.IsNullOrEmpty(illustrationRequest.PolicyId))
            {
                throw new Exception("dynObject.policyId is empty or null.");
            }
        }

        private void BuildIllustrationRequestCoverageProperties(IllustrationRequest illustrationRequest, dynamic dynObject)
        {
            int intTest;
            decimal decimalTest;
            DateTime dateTimeTest;

            illustrationRequest.Coverages = new List<Coverage>();

            dynamic dynCoverageInfo = dynObject.coverageInfo;

            foreach (dynamic dynCoverage in dynCoverageInfo)
            {
                var dynCoverageDetails = dynCoverage.Value as dynamic;

                string planLegalName = dynCoverageDetails.planLegalName.ToString();

                var productTypeCode = dynCoverageDetails.productTypeCode.ToString();

                if (string.IsNullOrEmpty(productTypeCode))
                {
                    // Then coverage is actually a rider
                    Coverage coverage = new Coverage();

                    coverage.PlanId = dynCoverageDetails.planId;
                    if (string.IsNullOrEmpty(coverage.PlanId))
                    {
                        throw new Exception($"planLegalName: {planLegalName} dynCoverageDetails.planId is empty or null for rider.");
                    }

                    coverage.CoverageTypeCode = dynCoverageDetails.coverageOptionType.code;
                    if (string.IsNullOrEmpty(coverage.CoverageTypeCode))
                    {
                        throw new Exception($"planLegalName: {planLegalName} dynCoverageDetails.coverageOptionType.codeis empty or null for rider.");
                    }

                    if (string.IsNullOrEmpty(dynCoverageDetails.faceAmount.ToString()))
                    {
                        coverage.CurrentAmt = 0;
                    }
                    else
                    {
                        if (decimal.TryParse(dynCoverageDetails.faceAmount.ToString(), out decimalTest))
                        {
                            coverage.CurrentAmt = decimalTest;
                        }
                        else
                        {
                            throw new Exception($"planLegalName: {planLegalName} dynCoverageDetails.faceAmount is not a valid decimal for rider.");
                        }
                    }

                    if (int.TryParse(dynCoverageDetails.issueAge.ToString(), out intTest))
                    {
                        coverage.IssueAge = intTest;
                    }
                    else
                    {
                        throw new Exception($"planLegalName: {planLegalName} dynCoverageDetails.issueAge is not a valid integer for rider.");
                    }

                    if (string.IsNullOrEmpty(dynCoverageDetails.faceAmount.ToString()))
                    {
                        coverage.FaceAmount = 0;
                    }
                    else
                    {
                        if (decimal.TryParse(dynCoverageDetails.faceAmount.ToString(), out decimalTest))
                        {
                            coverage.FaceAmount = decimalTest;
                        }
                        else
                        {
                            throw new Exception($"planLegalName: {planLegalName} dynCoverageDetails.faceAmount is not a valid decimal for rider.");
                        }
                    }

                    coverage.TobaccoPremiumBasisCode = dynCoverageDetails.tobaccoPremiumBasis.code;
                    if (string.IsNullOrEmpty(coverage.TobaccoPremiumBasisCode))
                    {
                        coverage.TobaccoPremiumBasisCode = string.Empty;
                    }

                    string rating = dynCoverageDetails.permanentTableRatingFactor;
                    if (string.IsNullOrEmpty(rating))
                    {
                        coverage.PermanentTableRating = 0;
                    }
                    else
                    {
                        if (decimal.TryParse(rating, out decimalTest))
                        {
                            coverage.PermanentTableRating = Convert.ToInt32(decimalTest * 100);
                        }
                        else
                        {
                            coverage.PermanentTableRating = 0;
                        }
                    }

                    if (coverage.PermanentTableRating > 100) // NOTE: It is 100 and not 1.00
                    {
                        string permTableRatingEndDate = dynCoverageDetails.permanentTableRatingEndDate.ToString();
                        if (DateTime.TryParse(permTableRatingEndDate, out dateTimeTest))
                        {
                            coverage.PermanentTableRatingEndDate = dateTimeTest;
                        }
                        else
                        {
                            throw new Exception($"planLegalName: {planLegalName} dynCoverageDetails.permanentTableRatingEndDate: {permTableRatingEndDate} is not a valid date for rider when dynCoverageDetails.permanentTableRatingFactor: {coverage.PermanentTableRating} > 100.");
                        }
                    }
                    else
                    {
                        coverage.PermanentTableRatingEndDate = null;
                    }

                    illustrationRequest.Coverages.Add(coverage);
                }
                else
                {
                    // Coverage is the base coverage

                    // add code to populate some main illustrationRequest properties

                    illustrationRequest.PlanId = dynCoverageDetails.planId;
                    if (string.IsNullOrEmpty(illustrationRequest.PlanId))
                    {
                        throw new Exception("dynCoverageDetails.planId is empty or null.");
                    }

                    if (decimal.TryParse(dynCoverageDetails.faceAmount.ToString(), out decimalTest))
                    {
                        illustrationRequest.FaceAmount = decimalTest;
                    }
                    else
                    {
                        throw new Exception("dynCoverageDetails.faceAmount is not a valid decimal.");
                    }

                    if (int.TryParse(dynCoverageDetails.issueAge.ToString(), out intTest))
                    {
                        illustrationRequest.IssueAge = intTest;
                    }
                    else
                    {
                        throw new Exception("dynCoverageDetails.issueAge is not a valid integer.");
                    }

                    if (DateTime.TryParse(dynCoverageDetails.effectiveDate.ToString(), out dateTimeTest))
                    {
                        illustrationRequest.IssueDate = dateTimeTest;
                    }
                    else
                    {
                        throw new Exception("dynCoverageDetails.effectiveDate is not a valid date.");
                    }

                    illustrationRequest.ProductTypeCode = dynCoverageDetails.productTypeCode;
                    if (string.IsNullOrEmpty(illustrationRequest.ProductTypeCode))
                    {
                        throw new Exception("dynCoverageDetails.productTypeCode is empty or null.");
                    }

                    illustrationRequest.PermanentTableRatingCode = dynCoverageDetails.permanentTableRating.code;
                    if (string.IsNullOrEmpty(illustrationRequest.PermanentTableRatingCode))
                    {
                        throw new Exception("dynCoverageDetails.permanentTableRating.code is empty or null for base coverage.");
                    }
                    else
                    {
                        if (illustrationRequest.PermanentTableRatingCode.Equals("NONE", StringComparison.InvariantCultureIgnoreCase) || illustrationRequest.PermanentTableRatingCode.Trim().Length == 0)
                        {
                            illustrationRequest.PermanentTableRatingCode = string.Empty;
                        }
                    }

                    // This represents the annual amount
                    string temporaryFlatExtraAmount = dynCoverageDetails.temporaryFlatExtraAmount;
                    if (string.IsNullOrEmpty(temporaryFlatExtraAmount))
                    {
                        illustrationRequest.TemporaryFlatExtraAmount = 0;
                    }
                    else
                    {
                        if (decimal.TryParse(temporaryFlatExtraAmount, out decimalTest))
                        {
                            illustrationRequest.TemporaryFlatExtraAmount = decimalTest;
                        }
                        else
                        {
                            throw new Exception("dynObject.policyInfo.temporaryFlatExtraAmount is not a valid decimal for base coverage.");
                        }
                    }

                    // This represents the monthly rate
                    string temporaryFlatExtraRate = dynCoverageDetails.temporaryFlatExtraRate;
                    if (string.IsNullOrEmpty(temporaryFlatExtraRate))
                    {
                        illustrationRequest.TemporaryFlatExtraRateAmount = 0;
                    }
                    else
                    {
                        if (decimal.TryParse(temporaryFlatExtraRate, out decimalTest))
                        {
                            illustrationRequest.TemporaryFlatExtraRateAmount = decimalTest;
                        }
                        else
                        {
                            throw new Exception("dynObject.policyInfo.temporaryFlatExtraRate is not a valid decimal for base coverage.");
                        }
                    }

                    if (illustrationRequest.TemporaryFlatExtraAmount > 0)
                    {
                        if (DateTime.TryParse(dynCoverageDetails.temporaryFlatExtraEndDate.ToString(), out dateTimeTest))
                        {
                            illustrationRequest.TemporaryFlatExtraEndDate = dateTimeTest;
                        }
                        else
                        {
                            throw new Exception("dynCoverageDetails.temporaryFlatExtraEndDate is not a valid date for base coverage.");
                        }
                    }
                    else
                    {
                        illustrationRequest.TemporaryFlatExtraEndDate = null;
                    }
                }
            }
        }

        private void BuildIllustrationRequestFundProperties(IllustrationRequest illustrationRequest, dynamic dynObject)
        {
            decimal decimalTest;

            illustrationRequest.Funds = new List<FundAccount>();

            dynamic dynFundInfo = dynObject.policyInfo.policyFundInfo;

            foreach (dynamic dynFund in dynFundInfo)
            {
                FundAccount fund = new FundAccount();

                fund.FundAccountId = dynFund.fundAccountId;
                if (string.IsNullOrEmpty(fund.FundAccountId))
                {
                    throw new Exception("dynFundInfo.fundAccountId is empty or null.");
                }

                if (string.IsNullOrEmpty(dynFund.indexParticipationRate.ToString()))
                {
                    fund.FundAllocationPercent = 0;
                }
                else
                {
                    if (decimal.TryParse(dynFund.indexParticipationRate.ToString(), out decimalTest))
                    {
                        fund.FundAllocationPercent = decimalTest;
                    }
                    else
                    {
                        throw new Exception("dynFundInfo.indexParticipationRateis not a valid decimal.");
                    }
                }

                illustrationRequest.Funds.Add(fund);
            }
        }

        private void BuildIllustrationRequestAgentProperties(IllustrationRequest illustrationRequest, dynamic dynObject)
        {

            illustrationRequest.Agent = new AgentPerson();

            illustrationRequest.Agent.AddressCity = dynObject.policyInfo.producerInfo.addressCity;
            if (string.IsNullOrEmpty(illustrationRequest.Agent.AddressCity))
            {
                throw new Exception("dynObject.policyInfo.producerInfo.addressCity is empty or null.");
            }

            illustrationRequest.Agent.AddressLine1 = dynObject.policyInfo.producerInfo.addressLine1;
            if (string.IsNullOrEmpty(illustrationRequest.Agent.AddressLine1))
            {
                throw new Exception("dynObject.policyInfo.producerInfo.addressLine1 is empty or null.");
            }

            illustrationRequest.Agent.AddressLine2 = dynObject.policyInfo.producerInfo.addressLine2;
            if (string.IsNullOrEmpty(illustrationRequest.Agent.AddressLine2))
            {
                illustrationRequest.Agent.AddressLine2 = string.Empty;
            }

            illustrationRequest.Agent.AddressStateCode = dynObject.policyInfo.producerInfo.addressStateCode;
            if (string.IsNullOrEmpty(illustrationRequest.Agent.AddressStateCode))
            {
                throw new Exception("dynObject.policyInfo.producerInfo.addressStateCode is empty or null.");
            }

            illustrationRequest.Agent.AddressZip = dynObject.policyInfo.producerInfo.addressZip;
            if (string.IsNullOrEmpty(illustrationRequest.Agent.AddressZip))
            {
                throw new Exception("dynObject.policyInfo.producerInfo.addressZip is empty or null.");
            }

            illustrationRequest.Agent.FirstName = dynObject.policyInfo.producerInfo.firstName;
            if (string.IsNullOrEmpty(illustrationRequest.Agent.FirstName))
            {
                throw new Exception("dynObject.policyInfo.producerInfo.firstName is empty or null.");
            }

            illustrationRequest.Agent.LastName = dynObject.policyInfo.producerInfo.lastName;
            if (string.IsNullOrEmpty(illustrationRequest.Agent.LastName))
            {
                throw new Exception("dynObject.policyInfo.producerInfo.lastName is empty or null.");
            }

            illustrationRequest.Agent.MiddleName = dynObject.policyInfo.producerInfo.middleName;
            if (string.IsNullOrEmpty(illustrationRequest.Agent.MiddleName))
            {
                illustrationRequest.Agent.MiddleName = string.Empty;
            }

            illustrationRequest.Agent.PhoneNumber = dynObject.policyInfo.producerInfo.phoneNumber;
            if (string.IsNullOrEmpty(illustrationRequest.Agent.PhoneNumber))
            {
                throw new Exception("dynObject.policyInfo.producerInfo.phoneNumber is empty or null.");
            }
        }

        private void BuildIllustrationRequestClientProperties(IllustrationRequest illustrationRequest, dynamic dynObject)
        {
            DateTime dateTimeTest;

            illustrationRequest.Client = new ClientPerson();

            illustrationRequest.Client.AddressCountryCode = dynObject.clientInfo.PRIMARY.addressCountry.code;
            if (string.IsNullOrEmpty(illustrationRequest.Client.AddressCountryCode))
            {
                throw new Exception("dynObject.clientInfo.PRIMARY.addressCountry.code is empty or null.");
            }

            illustrationRequest.Client.GenderCode = dynObject.clientInfo.PRIMARY.gender.code;
            if (string.IsNullOrEmpty(illustrationRequest.Client.GenderCode))
            {
                throw new Exception("dynObject.clientInfo.PRIMARY.gender.code is empty or null.");
            }

            illustrationRequest.Client.AddressStateCode = dynObject.clientInfo.PRIMARY.addressState.code;
            if (string.IsNullOrEmpty(illustrationRequest.Client.AddressStateCode))
            {
                throw new Exception("dynObject.clientInfo.PRIMARY.addressState.code is empty or null.");
            }

            if (DateTime.TryParse(dynObject.clientInfo.PRIMARY.birthdate.ToString(), out dateTimeTest))
            {
                illustrationRequest.Client.BirthDate = dateTimeTest;
            }
            else
            {
                throw new Exception("dynObject.clientInfo.PRIMARY.birthdate is not a valid date.");
            }

            illustrationRequest.Client.FirstName = dynObject.clientInfo.PRIMARY.firstName;
            if (string.IsNullOrEmpty(illustrationRequest.Client.FirstName))
            {
                throw new Exception("dynObject.clientInfo.PRIMARY.firstName is empty or null.");
            }

            illustrationRequest.Client.LastName = dynObject.clientInfo.PRIMARY.lastName;
            if (string.IsNullOrEmpty(illustrationRequest.Client.LastName))
            {
                throw new Exception("dynObject.clientInfo.PRIMARY.lastName is empty or null.");
            }

            illustrationRequest.Client.MiddleName = dynObject.clientInfo.PRIMARY.middleName;
            if (string.IsNullOrEmpty(illustrationRequest.Client.MiddleName))
            {
                illustrationRequest.Client.MiddleName = string.Empty;
            }

            illustrationRequest.Client.NameSuffix = dynObject.clientInfo.PRIMARY.nameSuffix;
            if (string.IsNullOrEmpty(illustrationRequest.Client.NameSuffix))
            {
                illustrationRequest.Client.NameSuffix = string.Empty;
            }

            // NOTE: This age value is first retrieved from the main coverage property set
            illustrationRequest.Client.Age = illustrationRequest.IssueAge;

        }

    }
}
