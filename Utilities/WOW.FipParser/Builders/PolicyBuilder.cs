using System;
using System.Collections.Generic;
using System.Linq;
using WOW.Illustration.Model.Enums;
using WOW.Illustration.Model.Generation.Request;

namespace WOW.FipUtilities
{
    abstract class PolicyBuilder : IPolicyBuilder
    {
        public Policy Policy { get; set; }

        /// <summary>
        /// Parses agent data from the [ILLUSTRATION] and [AGENTDATA] sections of a FIP file.
        /// </summary>
        /// <param name="fipData">Object representation of a FIP file.</param>
        public virtual void HydrateAgentData(IList<FipDataModel> fipData)
        {
            Policy.Agent = new AgentPerson();

            var illustrationSection = fipData.FirstOrDefault(f => f.Section == "[ILLUSTRATION]");
            var agentDataSection = fipData.FirstOrDefault(f => f.Section == "[AGENTDATA]");

            //if (illustrationSection != null)
            //{
            //    Policy.Agent.Id = illustrationSection.Data.SafeGetValue("AGENTID", "0");
            //}
            //else
            //{
            //    Policy.Agent.Id = "0";
            //}

            if (agentDataSection != null)
            {
                Policy.Agent.FirstName = agentDataSection.Data.SafeGetValue("AGTFIRSTNAME");
                Policy.Agent.MiddleName = agentDataSection.Data.SafeGetValue("AGTMIDDLEINITIAL");
                Policy.Agent.LastName = agentDataSection.Data.SafeGetValue("AGTLASTNAME");
                Policy.Agent.AddressLine1 = agentDataSection.Data.SafeGetValue("AGTADDR_1");
                Policy.Agent.AddressLine2 = agentDataSection.Data.SafeGetValue("AGTADDR_2");
                Policy.Agent.AddressCity = agentDataSection.Data.SafeGetValue("AGTCITY");
                Policy.Agent.AddressState = agentDataSection.Data.SafeGetValue("AGTSTATE");
                Policy.Agent.AddressZipCode = agentDataSection.Data.SafeGetValue("AGTZIP");
                Policy.Agent.PhoneNumber = agentDataSection.Data.SafeGetValue("AGTPHONE");
                // Only present for certain states
                //Policy.Agent.LicenseNumber = agentDataSection.Data.SafeGetValue("AGTLICENSENBR");
                //Policy.Agent.LicenseState = agentDataSection.Data.SafeGetValue("AGTLICENSESTATE");
            }
        }

        /// <summary>
        /// Parses member data from the [CONTACTBASICDATA] section of a FIP file.
        /// </summary>
        /// <param name="fipData">Object representation of a FIP file.</param>
        public virtual void HydrateClientData(IList<FipDataModel> fipData)
        {
            Policy.Client = new ClientPerson();

            var contactBasicDataSection = fipData.FirstOrDefault(f => f.Section == "[CONTACTBASICDATA]");

            if (contactBasicDataSection != null)
            {
                Policy.Client.FirstName = contactBasicDataSection.Data.SafeGetValue("FIRSTNAME");
                Policy.Client.MiddleName = contactBasicDataSection.Data.SafeGetValue("MIDDLEINITIAL");
                Policy.Client.LastName = contactBasicDataSection.Data.SafeGetValue("LASTNAME");
                Policy.Client.NameSuffix = contactBasicDataSection.Data.SafeGetValue("NAMESUFFIX");
                Policy.Client.Age = contactBasicDataSection.Data.SafeGetValue("AGE", 0);
                Policy.Client.Birthdate = contactBasicDataSection.Data.SafeGetValue("BIRTHDATE", DateTime.MinValue);
                Policy.Client.Gender = contactBasicDataSection.Data.SafeGetValue("SEX", 0);
                //Policy.Client.Country = contactBasicDataSection.Data.SafeGetValue("COUNTRY", "USA");
            }
            else
            {
                throw new FipParseException("Required [CONTACTBASICDATA] section is missing.");
            }
        }

        /// <summary>
        /// Parses common data from the [SCENEPOINTERS] and [COMMONDATA] sections of a FIP file.
        /// </summary>
        /// <param name="fipData">Object representation of a FIP file.</param>
        public virtual void HydrateCommonData(IList<FipDataModel> fipData)
        {
            var scenePointersSection = fipData.FirstOrDefault(f => f.Section == "[SCENEPOINTERS]");
            var commonDataSection = fipData.FirstOrDefault(f => f.Section == "[COMMONDATA]");

            //Default anything coming in via FIP as requiring both to ensure backwards compatibility.
            Policy.GeneratePdf = true;
            Policy.GenerateValuesTextFile = true;

            // [ScenePointers]
            if (scenePointersSection != null)
            {
                Policy.CategoryCode = scenePointersSection.Data.SafeGetValue("CATEGORYCODE", 0);
                Policy.ConceptCode = scenePointersSection.Data.SafeGetValue("CONCEPTCODE", 0);
                Policy.HeaderCode = scenePointersSection.Data.SafeGetValue("HEADERCODE", 0);
                //Policy.ClassCode = scenePointersSection.Data.SafeGetValue("CLASSCODE", 0);
                Policy.ClassType = scenePointersSection.Data.SafeGetValue("CLASSTYPE", 0);
                Policy.IsRevisedIllustration = scenePointersSection.Data.SafeGetValue("REVISEDILLUS", false);
                //Policy.RevisedComment = scenePointersSection.Data.SafeGetValue("REVISEDCOMMENT");
                Policy.NeedsCostBenefit = scenePointersSection.Data.SafeGetValue("COSTBENEFIT", false);
                Policy.SceneModifyDate = scenePointersSection.Data.SafeGetValue("SCENEMODIFYDATE", DateTime.MinValue);

                // Fetch the state value
                var tmpState = scenePointersSection.Data.SafeGetValue("WOWSTATE");
                int stateCode;

                // Try to parse to int to see if it is a state code
                if (Int32.TryParse(tmpState, out stateCode))
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
            }
            else
            {
                throw new FipParseException("Required [SCENEPOINTERS] section is missing.");
            }

            // [CommonData]
            if (commonDataSection != null)
            {
                //Policy.PlanIsUnisex = commonDataSection.Data.SafeGetValue("PLANUNISEX", false);
                //Policy.PlanIsQualified = commonDataSection.Data.SafeGetValue("PLANQUALIFIED", false);
                //RTGAMT, RTGAMTTOAGE, RTGEXTRA_1, RTGEXTRATOAGE_1 are also in the PolicyData section.
                if (Policy.RatingAmount == 0)
                {
                    Policy.RatingAmount = commonDataSection.Data.SafeGetValue("RTGAMT", 0);
                }
                //Policy.RatingAmountToAge = commonDataSection.Data.SafeGetValue("RTGAMTTOAGE", 0);
                if (Policy.RatingExtra1 == 0M)
                {
                    Policy.RatingExtra1 = commonDataSection.Data.SafeGetValue("RTGEXTRA_1", 0M);
                }
                if (Policy.RatingExtra1 > 0M) // only applies if rating extra set.
                {
                    Policy.RatingExtraToAge1 = commonDataSection.Data.SafeGetValue("RTGEXTRATOAGE_1", 0);
                }
                //Policy.RatingExtra2 = commonDataSection.Data.SafeGetValue("RTGEXTRA_2", 0M);
                //Policy.RatingExtraToAge2 = commonDataSection.Data.SafeGetValue("RTGEXTRATOAGE_2", 0);
                Policy.Lump1035Amount = commonDataSection.Data.SafeGetValue("LUMP1035AMT", 0M);
                Policy.SettlementAge = commonDataSection.Data.SafeGetValue("SETTLEMENTAGE", 0);
                //Policy.LoanInterestUsage = commonDataSection.Data.SafeGetValue("LOANINTUSAGE", false);
                //Policy.PrintToAge = commonDataSection.Data.SafeGetValue("PRINTTOAGE", 0);
                if (string.IsNullOrWhiteSpace(Policy.PolicyNumber))
                {
                    Policy.PolicyNumber = commonDataSection.Data.SafeGetValue("POLICYNUMBER");
                }
                //Policy.WithdrawalToLoan = commonDataSection.Data.SafeGetValue("WDRLTOLOAN", 0M);
                //Policy.StateNAICApproved = commonDataSection.Data.SafeGetValue("STATENAICAPPROVED", false);
                Policy.NumberOfOwners = commonDataSection.Data.SafeGetValue("NUMBEROFOWNERS", 0);

                //Policy.Ten35Basis = commonDataSection.Data.SafeGetValue("TEN35BASIS", 0);
                Policy.BelowMinimumPremium = commonDataSection.Data.SafeGetValue("BELOWMINPREM", false);
                //Policy.RetirementIncludeOption = commonDataSection.Data.SafeGetValue("RETIREMENTINCOPT", false);
                //Policy.RetirementMode = commonDataSection.Data.SafeGetValue("RETIREMENTMODE", 0);
                //Policy.RetirementAge = commonDataSection.Data.SafeGetValue("RETIREMENTAGE", 0);
                //Policy.PrintAsTobacco = commonDataSection.Data.SafeGetValue("PRINTASTOBACCO", false);
            }
            else
            {
                throw new FipParseException("Required [COMMONDATA] section is missing.");
            }
        }

        /// <summary>
        /// Parses rider data from the [ALLRIDERDATA] section of a FIP file.
        /// </summary>
        /// <param name="fipData">Object representation of a FIP file.</param>
        public virtual void HydrateRiderData(IList<FipDataModel> fipData)
        {
            // Riders repeat under the section, so there can be multiple FipDataModels for the riders section.
            var allRiderDataSection = fipData.Where(f => f.Section == "[ALLRIDERDATA]");
            // [AllRiderData]
            if (allRiderDataSection.Any())
            {
                foreach (var fipSection in allRiderDataSection)
                {
                    var rider = new Rider();

                    rider.Age = fipSection.Data.SafeGetValue("AGE", 0);
                    rider.Amount = fipSection.Data.SafeGetValue("AMOUNT", 0M);
                    rider.Class = fipSection.Data.SafeGetValue("CLASS", 0);
                    rider.IssueAge = fipSection.Data.SafeGetValue("ISSAGE", 0);
                    rider.Name = fipSection.Data.SafeGetValue("NAME");
                    rider.RatingAmount = fipSection.Data.SafeGetValue("RTGAMT", 0);
                    rider.RatingAmountToAge = fipSection.Data.SafeGetValue("RTGAMTTOAGE", 0);
                    rider.RatingExtra = fipSection.Data.SafeGetValue("RTGEXTRA", 0M);
                    rider.RatingExtraToAge = fipSection.Data.SafeGetValue("RTGEXTRATOAGE", 0);
                    rider.Sex = fipSection.Data.SafeGetValue("SEX", 0);
                    rider.RiderType = fipSection.Data.SafeGetValue("TYPE", 0);

                    // The Bridge will include the [ALLRIDERDATA] even if there are no riders.
                    // So, I'm going to suppress any default rider objects here.
                    if (rider.RiderType > 0)
                    {
                        Policy.Riders.Add(rider);
                    }
                }
            }
            //else
            //{
            //    // FIP files don't always have a [AllRiderData] section
            //}
        }

        /// <summary>
        /// Parses non-level data from the [NONLEVELDATA] & [NONLEVELPOLICYDATA] sections of a FIP file.
        /// </summary>
        /// <param name="fipData">Object representation of a FIP file.</param>
        public virtual void HydrateNonLevelData(IList<FipDataModel> fipData)
        {
            // NonLevelData repeats under the section, so there can be multiple FipDataModels for the NonLevelData section.
            var nonLevelDataSection = fipData.Where(f => f.Section == "[NONLEVELDATA]");

            // NonLevelPolicyData does not appear to repeat under the section
            var nonLevelPolicyDataSection = fipData.Where(f => f.Section == "[NONLEVELPOLICYDATA]");

            if (nonLevelDataSection.Any())
            {
                foreach (var fipSection in nonLevelDataSection)
                {
                    var data = new NonLevelData();

                    // NLAmt doesn't seem to go past 2 elements.
                    data.Amounts.Add(fipSection.Data.SafeGetValue("NLAMT_1", 0M));
                    data.Amounts.Add(fipSection.Data.SafeGetValue("NLAMT_2", 0M));
                    // NLCode doesn't seem to go past 4 elements.
                    data.Codes.Add(fipSection.Data.SafeGetValue("NLCODE_1", 0));
                    data.Codes.Add(fipSection.Data.SafeGetValue("NLCODE_2", 0));
                    data.Codes.Add(fipSection.Data.SafeGetValue("NLCODE_3", 0));
                    data.Codes.Add(fipSection.Data.SafeGetValue("NLCODE_4", 0));
                    data.DataTypeCode = (DataType)fipSection.Data.SafeGetValue("DATATYPECODE", 0);
                    //data.GradePercent = fipSection.Data.SafeGetValue("NLGRADEPCT", 0M);
                    // Not always present
                    data.Level = fipSection.Data.SafeGetValue("LEVEL", 0);
                    // NLRate doesn't seem to go past 2 elements.
                    //data.Rates.Add(fipSection.Data.SafeGetValue("NLRATE_1", 0));
                    //data.Rates.Add(fipSection.Data.SafeGetValue("NLRATE_2", 0));

                    //This is a hack because MyWoodmen isn't passing the correct age for these non-level elements.
                    if (Policy is NoLapseGuaranteedUniversalLifePolicy && (data.DataTypeCode == DataType.CoverageBenefit || data.DataTypeCode == DataType.DeathBenefit))
                    {
                        data.Age = 121;
                    }
                    else
                    {
                        data.Age = fipSection.Data.SafeGetValue("NLAGE", 0);
                    }

                    Policy.NonLevelData.Add(data);
                }
            }

            if (nonLevelPolicyDataSection.Any())
            {
                foreach (var fipSection in nonLevelPolicyDataSection)
                {
                    var data = new NonLevelPolicyData();

                    //data.DataTypeCode = fipSection.Data.SafeGetValue("DATATYPECODE", 0);
                    //data.EffectiveAge = fipSection.Data.SafeGetValue("EFFECTIVEAGE", 0);
                    //data.EffectiveMonth = fipSection.Data.SafeGetValue("EFFECTIVEMONTH", 0);
                    //data.EffectiveYear = fipSection.Data.SafeGetValue("EFFECTIVEYEAR", 0);
                    data.EffectiveDate = fipSection.Data.SafeGetValue("EFFECTIVEDATE", DateTime.MinValue);
                    //data.Level = fipSection.Data.SafeGetValue("LEVEL", 1);
                    data.NonLevelAmounts.Add(fipSection.Data.SafeGetValue("NLAMOUNT_1", 0M));
                    data.NonLevelAmounts.Add(fipSection.Data.SafeGetValue("NLAMOUNT_2", 0M));
                    data.NonLevelAmounts.Add(fipSection.Data.SafeGetValue("NLAMOUNT_3", 0M));
                    data.NonLevelAmounts.Add(fipSection.Data.SafeGetValue("NLAMOUNT_4", 0M));
                    data.NonLevelAmounts.Add(fipSection.Data.SafeGetValue("NLAMOUNT_5", 0M));
                    data.NonLevelAmounts.Add(fipSection.Data.SafeGetValue("NLAMOUNT_6", 0M));

                    Policy.NonLevelPolicyData.Add(data);
                }
            }
        }

        /// <summary>
        /// Parses report data from the [REPORTS] section of a FIP file.
        /// </summary>
        /// <param name="fipData">Object representation of a FIP file.</param>
        public virtual void HydrateReports(IList<FipDataModel> fipData)
        {
            // Reports repeat under the section, so there can be multiple FipDataModels for the reports section.
            var reportsSection = fipData.Where(f => f.Section == "[REPORTS]");

            // [Reports]
            if (reportsSection.Any())
            {
                foreach (var fipSection in reportsSection)
                {
                    var report = new Report();

                    report.Code = (ReportType)fipSection.Data.SafeGetValue("CODE", 0);
                    //report.IncludeGraph = fipSection.Data.SafeGetValue("INCLUDEGRAPH", false);
                    report.InterestRate = fipSection.Data.SafeGetValue("INTERESTRATE", 0M);
                    //report.Level = fipSection.Data.SafeGetValue("LEVEL", 0);
                    report.SalesCharge = fipSection.Data.SafeGetValue("SALESCHARGE", 0M);
                    report.TermRates = fipSection.Data.SafeGetValue("TERMRATES", 0); // The Bridge has this hard-coded to '0'. Not sure why.

                    Policy.Reports.Add(report);
                }
            }
            else if (Policy is AccumulationUniversalLifePolicy)
            {
                var report = new Report();
                report.Code = ReportType.NarrativeSummaryBase;
                Policy.Reports.Add(report);

                report = new Report();
                report.Code = ReportType.NumericSummaryUL;
                Policy.Reports.Add(report);

                report = new Report();
                report.Code = ReportType.TabularDetailUL;
                Policy.Reports.Add(report);
            }
        }

        /// <summary>
        /// Parses policy data from the [POLICYDATA] section of a FIP file.
        /// </summary>
        /// <param name="fipData">Object representation of a FIP file.</param>
        public virtual void HydrateGeneralPolicyData(IList<FipDataModel> fipData)
        {
            var policyDataSection = fipData.FirstOrDefault(f => f.Section == "[POLICYDATA]");

            if (policyDataSection != null)
            {
                Policy.IssueDate = policyDataSection.Data.SafeGetValue("ISSUEDATE", DateTime.MinValue);
                //Policy.IssueDateEntered = (Policy.IssueDate > DateTime.MinValue); // Moved to getter
                Policy.IssueAge = policyDataSection.Data.SafeGetValue("ISSUEAGE", 0);
                if (string.IsNullOrWhiteSpace(Policy.PolicyNumber))
                {
                    Policy.PolicyNumber = policyDataSection.Data.SafeGetValue("POLICYNUMBER");
                }
                //Policy.Class = policyDataSection.Data.SafeGetValue("CLASS", 0);
                //RTGAMT, RTGAMTTOAGE, RTGEXTRA_1, RTGEXTRATOAGE_1 are also in the CommonData section.
                if (Policy.RatingAmount == 0)
                {
                    Policy.RatingAmount = policyDataSection.Data.SafeGetValue("RTGAMT", 0);
                }
                //Policy.RatingAmountToAge = policyDataSection.Data.SafeGetValue("RTGAMTTOAGE", 0);
                if (Policy.RatingExtra1 == 0M)
                {
                    Policy.RatingExtra1 = policyDataSection.Data.SafeGetValue("RTGEXTRA_1", 0M);
                }

                if (Policy.RatingExtra1 > 0) // only applies if rating extra set.
                {
                    Policy.RatingExtraToAge1 = policyDataSection.Data.SafeGetValue("RTGEXTRATOAGE_1", 0);
                }
                //Policy.RatingExtra2 = policyDataSection.Data.SafeGetValue("RTGEXTRA_2", 0M);
                //Policy.RatingExtraToAge2 = policyDataSection.Data.SafeGetValue("RTGEXTRATOAGE_2", 0);
                Policy.DataDate = policyDataSection.Data.SafeGetValue("DATADATE", DateTime.MinValue);
                //Policy.Year = policyDataSection.Data.SafeGetValue("YEAR", 0);
                //Policy.Month = policyDataSection.Data.SafeGetValue("MONTH", 0);
                Policy.AccountValue = policyDataSection.Data.SafeGetValue("ACCOUNTVALUE", 0M);
                Policy.SurrenderCharge = policyDataSection.Data.SafeGetValue("SURRCHARGE", 0M);
                Policy.CumulativePremium = policyDataSection.Data.SafeGetValue("CUMPREMIUM", 0M);
                //Policy.CumulativeWithdrawal = policyDataSection.Data.SafeGetValue("CUMWDRL", "0");
                Policy.StandardLoanBalance = policyDataSection.Data.SafeGetValue("STDLOANBALANCE", 0M);
                //Policy.PreferredLoanBalance = policyDataSection.Data.SafeGetValue("PRFLOANBALANCE", "0");
                //Policy.GuidelineSinglePremium = policyDataSection.Data.SafeGetValue("GSP", "0");
                //Policy.CumulativeGuidelineLevelPremium = policyDataSection.Data.SafeGetValue("CUMGLP", "0");
                //Policy.GuidelineLevelPremium = policyDataSection.Data.SafeGetValue("GLP", "0");
                Policy.IsModifiedEndowmentContract = policyDataSection.Data.SafeGetValue("MEC", false);
                Policy.LoanInterestAmount = policyDataSection.Data.SafeGetValue("LOANINTAMT", 0M);
                Policy.Guideline7Pay = policyDataSection.Data.SafeGetValue("G7P", 0M);
                //Policy.Guideline7PayYear = policyDataSection.Data.SafeGetValue("G7PYEAR", 0);
                Policy.Guideline7PayPremium = policyDataSection.Data.SafeGetValue("G7PPREMIUM", 0M);
                Policy.AccumulatedDividends = policyDataSection.Data.SafeGetValue("DIVACCUMS", 0M);
                //Policy.PaidUpAdditions = policyDataSection.Data.SafeGetValue("PUA", "0");
                //Policy.PaidUpAdditionsCashValue = policyDataSection.Data.SafeGetValue("PUACASHVALUE", "0");
                //Policy.PaidUpAdditionsRider = policyDataSection.Data.SafeGetValue("PUARIDER", "0");
                //Policy.PaidUpAdditionsRiderCashValue = policyDataSection.Data.SafeGetValue("PUARIDERCASHVALUE", "0");
                //Policy.repAdditionalInsuranceFromRefunds = policyDataSection.Data.SafeGetValue("REPADDINSFROMREFUNDS", "0");
                Policy.AdditionalInsuranceOnDeposit = policyDataSection.Data.SafeGetValue("REPADDINSONDEPOSIT", 0M);
                Policy.PaidUpAdditionsInsurance = policyDataSection.Data.SafeGetValue("REPPUAINSURANCE", 0M);
                //Policy.RepoRatingAmountPermanent = policyDataSection.Data.SafeGetValue("REPORTGAMTPERM", "0");
                //Policy.RepoRatingAmountPermanentToAge = policyDataSection.Data.SafeGetValue("REPORTGAMTPERM_TOAGE", "35");
                Policy.StatKind = policyDataSection.Data.SafeGetValue("STATKIND", 0);
                // A dollar sign is present in the FIP files sometimes. Code to strip it was added to the extension.
                Policy.WLPDFB = policyDataSection.Data.SafeGetValue("WLPDFB", 0M);
                Policy.RefundAtLastAnniversary = policyDataSection.Data.SafeGetValue("REFUNDLAST", 0M);
                Policy.AverageLoanBalance = policyDataSection.Data.SafeGetValue("AVGLOANBAL", 0M);
                Policy.AveragePremiumDepositFundBalance = policyDataSection.Data.SafeGetValue("AVGPDFBAL", 0M);
                Policy.AverageRefundsOnDepositBalance = policyDataSection.Data.SafeGetValue("AVGREFDEPBAL", 0M);
                Policy.CurrentCashValueOfPaidUpInsurance = policyDataSection.Data.SafeGetValue("CCVPUA", 0M);
                Policy.BaseCashValue = policyDataSection.Data.SafeGetValue("BASECV", 0M);
                Policy.LoanBalanceWithInterest = policyDataSection.Data.SafeGetValue("LOANBALWITHINT", 0M);
                Policy.PremiumDepositFundBalanceWithInterest = policyDataSection.Data.SafeGetValue("PDFBALWITHINT", 0M);
                Policy.RefundsOnDepositWithInterest = policyDataSection.Data.SafeGetValue("REFDEPWITHINT", 0M);
                Policy.RefundsOnDepositInterestRate = policyDataSection.Data.SafeGetValue("REFDEPINTRATE", 0M);
                Policy.PremiumDepositFundInterestRate = policyDataSection.Data.SafeGetValue("PDFINTRATE", 0M);
                Policy.FreeWithdrawal = policyDataSection.Data.SafeGetValue("FREEWDRL", 0M);
                Policy.NoLapseGuaranteeAccount = policyDataSection.Data.SafeGetValue("NLGACCOUNT", 0M);
                Policy.TargetPremium = policyDataSection.Data.SafeGetValue("TARGETPREM", 0M);
            }
            else
            {
                // This section is not present in annuities
                //throw new FipParseException("Required [POLICYDATA] section is missing.");
            }
        }

        public abstract void HydratePolicySpecificData(IList<FipDataModel> fipData);

        /// <summary>
        /// Returns the loaded IPolicy object.
        /// </summary>
        public abstract Policy GetPolicy();
    }
}
