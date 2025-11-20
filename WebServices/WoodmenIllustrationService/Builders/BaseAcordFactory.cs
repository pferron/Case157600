using log4net;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using WOW.Illustration.Model.ACORD;
using WOW.Illustration.Model.Enums;
using WOW.Illustration.Model.Generation.Request;
using WOW.Illustration.Model.LPES.Base;
using WOW.Illustration.Model.LPES.OLifeExtensions;
using WOW.WoodmenIllustrationService.Code;
using WOW.WoodmenIllustrationService.Models;

namespace WOW.WoodmenIllustrationService.Builders
{
    public abstract class BaseAcordFactory
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(BaseAcordFactory));

        protected static readonly SortedList<int, decimal> RequiredFraternalDues = IntegrationDAO.LoadRequiredFraternalDues();

        public static BaseAcordFactory BuildFactory(Illustration.Model.Generation.Request.Policy policy)
        {
            if (log.IsDebugEnabled) log.DebugFormat($"ACORD BuildFactory called.");

            BaseAcordFactory newFactory = null;

            if (policy == null)
            {
                throw new ArgumentNullException("policy", "An ACORD factory cannot be created for a null policy object.");
            }

            if (policy is TraditionalLifePolicy)
            {
                if (log.IsInfoEnabled) { log.Info($"Build TraditionalAcordFactory policy."); }
                newFactory = new TraditionalAcordFactory();
            }
            else if (policy is UniversalLifePolicy)
            {
                if (log.IsInfoEnabled) { log.Info($"Build UniversalAcordFactory policy."); }
                newFactory = new UniversalAcordFactory();
            }
            else if (policy is AnnuityPolicy)
            {
                if (log.IsInfoEnabled) { log.Info($"Build AnnuityAcordFactory policy."); }
                newFactory = new AnnuityAcordFactory();
            }
            else
            {
                var message = string.Format(CultureInfo.InvariantCulture, "Invalid policy type specified: {0}", policy.GetType());
                throw new AcordRequestFactoryException(message);
            }

            return newFactory;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]

        protected TXLife acordRequest;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]

        protected IllustrationRequest_Type illustrationRequest;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]

        protected readonly string agentId = "AG-" + Guid.NewGuid().ToString("N");
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]

        protected readonly string primaryInsuredId = "PR-" + Guid.NewGuid().ToString("N");
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]

        protected readonly string otherInsuredId = "OI-" + Guid.NewGuid().ToString("N");
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]

        protected IList<StoneRiverTemplate> templateIds = IntegrationDAO.LoadStoneRiverIllustrationTemplates().ToList();


        protected BaseAcordFactory()
        {
            // Create request object
            acordRequest = new TXLife();

            // Making slots for the two primary ACORD objects, namely UserAuthRequest & TXLifeRequest
            acordRequest.Items = new object[2];
        }
        public TXLife CreateLifeRequestModel(Illustration.Model.Generation.Request.Policy policy, SharedModels.ServiceRequestConfig config)
        {
            if (log.IsDebugEnabled) log.DebugFormat($"CreateLifeRequestModel called.");

            if (policy == null)
            {
                throw new ArgumentNullException("policy", "A Life Request Model cannot be created for a null policy object.");
            }

            try
            {
                acordRequest.Items[0] = HydrateAuthenticationValues(config);
                acordRequest.Items[1] = HydrateLifeRequest(policy, config);

                acordRequest.Version = "2.22.00";

                return acordRequest;
            }
            catch (Exception ex)
            {
                throw new AcordRequestFactoryException(string.Format(CultureInfo.InvariantCulture, "There was an error creating a TXLife request object from the Policy object. Certificate: {0}", policy.PolicyNumber), ex);
            }
        }

        /// <summary>
        /// Creates the UserAuthRequest node of the request based on values from the config file.
        /// </summary>
        /// <returns>Hydrated UserAuthRequest object.</returns>
        private static UserAuthRequest HydrateAuthenticationValues(SharedModels.ServiceRequestConfig config)
        {
            // Create auth object
            var user = new UserAuthRequest();

            // Create two element array for username and password
            user.Items = new object[2];

            // Username is just a string
            user.Items[0] = config.Username;
            // The password is an object (for some reason)
            user.Items[1] = new UserPswd() { Item = config.Password };

            // This array is apparently used to identify the types of the objects in the above array. Weird...
            user.ItemsElementName = new ItemsChoiceType[2];
            user.ItemsElementName[0] = ItemsChoiceType.UserLoginName;
            user.ItemsElementName[1] = ItemsChoiceType.UserPswd;

            return user;
        }

        private TXLifeRequest HydrateLifeRequest(Illustration.Model.Generation.Request.Policy policy, SharedModels.ServiceRequestConfig config)
        {
            var transactionId = Guid.NewGuid().ToString("N");
            var txLifeRequest = new TXLifeRequest();

            // Set the request ID
            txLifeRequest.TransRefGUID = transactionId;

            // Set the Transtype
            txLifeRequest.TransType = AcordLookupBuilder.BuildFromTC<OLI_LU_TRANS_TYPE_CODES>((int)OLI_LU_TRANS_TYPE_CODES_TC.OLI_TRANS_ILLCAL);

            txLifeRequest.IllustrationRequest = HydrateIllustrationRequest(policy);
            txLifeRequest.OLifE = HydrateOLifE(policy, config);

            return txLifeRequest;
        }

        private IllustrationRequest_Type HydrateIllustrationRequest(Illustration.Model.Generation.Request.Policy policy)
        {
            // We're using a class-level variable here because we need to populate the Txns from a separate section of the ACORD model.
            illustrationRequest = new IllustrationRequest_Type();

            var fipExt = new AcordIllustrationRequestExtension() { SystemCode = "Woodmen Illustration Service", VendorCode = "FISERV" };
            illustrationRequest.OLifEExtension = fipExt;
            fipExt.BatchMode = AcordLookupBuilder.BuildBoolean(true);

            if (policy is AdjustableLifeFlexibleLifePolicy)
            {
                if (policy.MinimumPremiumToEndow == true)
                {
                    fipExt.SolveParameters = HydrateSolveParameters(policy);
                }
            }

            if (policy.GenerateValuesTextFile)
            {
                fipExt.IllustrationValuesPageRequest = AcordLookupBuilder.BuildBoolean(true);
            }

            if (policy.GeneratePdf)
            {
                // NOTE: This doesn't seem to have any impact on the output.
                // Set ImageType. The StoneRiver document doesn't list any options besides PDF.
                //illustrationRequest.ImageType = AcordLookupBuilder.BuildFromTC<OLI_LU_IMAGEFORMAT>((int)OLI_LU_IMAGEFORMAT_TC.OLI_IMAGE_PDF);

                // NOTE: This doesn't seem to have any impact on the output.
                // Set Attachment Location. The StoneRiver document doesn't list any options besides inline.
                //illustrationRequest.AttachmentLocation = AcordLookupBuilder.BuildFromTC<OLI_LU_ATTACHLOCATION>((int)OLI_LU_ATTACHLOCATION_TC.OLI_INLINE);

                // Assign reports array to illustration request
                illustrationRequest.IllustrationReportRequest = HydrateIllustrationReportRequests(policy);
            }

            return illustrationRequest;
        }

        private Solve_Parameters HydrateSolveParameters(Illustration.Model.Generation.Request.Policy policy)
        {
            var solveParameters = new Solve_Parameters();

            solveParameters.SolveFor = AcordLookupBuilder.BuildFromTC<SOLVE_FOR>((int)SOLVE_FOR_TC.Premium);            
            solveParameters.SolveCriteria = AcordLookupBuilder.BuildFromTC<SOLVE_CRITERIA>((int)SOLVE_CRITERIA_TC.MaximumCash);   
            solveParameters.SolveInterestBasis = AcordLookupBuilder.BuildFromTC<SOLVE_INTEREST_BASIS>((int)SOLVE_INTEREST_BASIS_TC.NonGuaranteed);
            solveParameters.SolveCashValue = (double)policy.AdditionalPremiumAmount;
            solveParameters.SolveTargetAge = policy.SettlementAge;                         
            solveParameters.SolveStartWhen = AcordLookupBuilder.BuildFromTC<SOLVE_START_WHEN>((int)SOLVE_START_WHEN_TC.Always);

            return solveParameters;
        }


        protected abstract IllustrationTxn_Type[] HydrateIllustrationTxns(Illustration.Model.Generation.Request.Policy policy, string coverageId);

        private OLifE HydrateOLifE(Illustration.Model.Generation.Request.Policy policy, SharedModels.ServiceRequestConfig config)
        {
            var oLife = new OLifE();

            // objects in the items array are Party, Holding, etc.
            var oLifeObjects = new List<object>();

            // Create Party objects for agents, members, etc.
            var partyData = HydratePartyData(policy, config);

            // Policy data
            var holdingData = HydrateHoldingData(policy);

            if (!policy.IsInforce && !string.IsNullOrWhiteSpace(policy.PolicyNumber))
            {
                // Financial Statement
                var financialStatement = HydrateFinancialStatement(policy, holdingData[0].id);

                oLifeObjects.Add(financialStatement);
            }

            // Add object arrays to collection
            oLifeObjects.AddRange(partyData.ToList());
            oLifeObjects.AddRange(holdingData.ToList());

            // If this is an inforce request, we need to add a financial statement
            // Select the holding that is marked inforce so we can pass its id to the builder
            var inforceHolding = holdingData.SingleOrDefault(h => h.HoldingStatus != null && h.HoldingStatus.tc == OLI_LU_HOLDSTAT_TC.OLI_HOLDSTAT_ACTIVE);

            if (inforceHolding != null)
            {
                // Financial Statement
                var financialStatement = HydrateFinancialStatement(policy, inforceHolding.id);

                oLifeObjects.Add(financialStatement);
            }

            // Convert list to array and return
            oLife.Items = oLifeObjects.ToArray();

            return oLife;
        }

        private Party[] HydratePartyData(Illustration.Model.Generation.Request.Policy policy, SharedModels.ServiceRequestConfig config)
        {
            var parties = new List<Party>();

            if (policy.Agent != null)
            {
                var agentParty = new Party();

                agentParty.id = agentId;
                agentParty.PartyTypeCode = AcordLookupBuilder.BuildFromTC<OLI_LU_PARTY>((int)OLI_LU_PARTY_TC.OLI_PT_PERSON);

                // Create a Person object for the agent
                var person = new Illustration.Model.ACORD.Person();
                person.FirstName = policy.Agent.FirstName;
                person.MiddleName = policy.Agent.MiddleName;
                person.LastName = policy.Agent.LastName;
                if (!string.IsNullOrWhiteSpace(policy.Agent.NameSuffix))
                {
                    person.Suffix = policy.Agent.NameSuffix;
                }

                agentParty.Address = new Address();
                agentParty.Address.AddressTypeCode = AcordLookupBuilder.BuildFromTC<OLI_LU_ADTYPE>((int)OLI_LU_ADTYPE_TC.OLI_ADTYPE_BUS);
                agentParty.Address.Line1 = policy.Agent.AddressLine1;
                agentParty.Address.Line2 = policy.Agent.AddressLine2;
                agentParty.Address.City = policy.Agent.AddressCity;
                agentParty.Address.AddressState = policy.Agent.AddressState;
                agentParty.Address.AddressStateTC = AcordLookupBuilder.BuildFromWowString<OLI_LU_STATE>(policy.Agent.AddressState);
                agentParty.Address.Zip = policy.Agent.AddressZipCode;

                var phoneNumber = String.Join("", policy.Agent.PhoneNumber.Where(char.IsDigit));

                if (phoneNumber.Length == 10)
                {
                    var phone = new Phone();
                    phone.PhoneTypeCode = AcordLookupBuilder.BuildFromTC<OLI_LU_PHONETYPE>((int)OLI_LU_PHONETYPE_TC.OLI_PHONETYPE_BUS);
                    phone.AreaCode = phoneNumber.Substring(0, 3);
                    phone.DialNumber = phoneNumber.Substring(3, 7);

                    agentParty.Phone = new Phone[] { phone };
                }

                // Indicated as required by TX 111 doc, but StoneRiver does not require this field for agents
                //person.Gender = AcordLookupBuilder.BuildFromTC<OLI_LU_GENDER>((int)OLI_LU_GENDER_TC.OLI_UNKNOWN);
                // Indicated as required by TX 111 doc, but StoneRiver does not require this field for agents
                //person.BirthDate = DateTime.MinValue;

                // Apparently, item is used for a Person object or a Organization object.
                // Attach the Person object to the party
                agentParty.Item = person;

                // Create Producer object for agent party
                agentParty.Producer = new Producer();

                //This needs an LPA username. Per SR, we need to create a dummy service agent account.
                agentParty.Producer.CRDNumber = config.Username;

                var distributionChannel = new DistributionChannelInfo_Type();

                distributionChannel.DistributionChannel = AcordLookupBuilder.BuildFromTC<OLI_LU_DISTCHAN>((int)OLI_LU_DISTCHAN_TC.OLI_OTHER);
                distributionChannel.DistributionChannelName = config.DistributionChannel;

                agentParty.Producer.CarrierAppointment = new DistributionChannelInfo_Type[] { distributionChannel };


                // Finally, add the party object to the list.
                parties.Add(agentParty);
            }

            if (policy.Client != null)
            {
                var clientParty = new Party();

                clientParty.id = primaryInsuredId;
                clientParty.PartyTypeCode = AcordLookupBuilder.BuildFromTC<OLI_LU_PARTY>((int)OLI_LU_PARTY_TC.OLI_PT_PERSON);
                // StoneRiver doc refers to GovtID as SSN, but SSN was not detected in sample FIPS.
                // Not a required field.
                //clientParty.GovtID;
                //clientParty.GovtIDTC;

                // Create a Person object for the client
                var person = new Illustration.Model.ACORD.Person();
                person.FirstName = policy.Client.FirstName;
                person.MiddleName = policy.Client.MiddleName;
                person.LastName = policy.Client.LastName;
                if (!string.IsNullOrWhiteSpace(policy.Client.NameSuffix))
                {
                    person.Suffix = policy.Client.NameSuffix;
                }

                // Required by TX 111
                person.Gender = AcordLookupBuilder.BuildFromWowString<OLI_LU_GENDER>(policy.Client.Gender.ToString(CultureInfo.InvariantCulture));
                person.BirthDate = policy.Client.Birthdate;
                person.BirthDateSpecified = person.BirthDate > DateTime.MinValue; // Required for DOB to serialize properly.
                person.Age = policy.Client.Age.ToString();
                person.DOBEstimated = AcordLookupBuilder.BuildBoolean(!person.BirthDateSpecified);

                // Attach the Person object to the party
                clientParty.Item = person;

                // Finally, add the party object to the list.
                parties.Add(clientParty);
            }

            // Check for Other Insured record(s) attached to the policy record.
            // Extract this data to a new party object and add to list.
            var otherInsuredRider = policy.Riders.SingleOrDefault(r => r.RiderType == 8);

            if (otherInsuredRider != null)
            {
                var otherInsuredParty = new Party();

                otherInsuredParty.id = otherInsuredId;
                otherInsuredParty.PartyTypeCode = AcordLookupBuilder.BuildFromTC<OLI_LU_PARTY>((int)OLI_LU_PARTY_TC.OLI_PT_PERSON);

                // Create a Person object for the agent
                var person = new Illustration.Model.ACORD.Person();

                // Expecting a "FirstName LastName" value for the other insured's name
                var nameParts = otherInsuredRider.Name.Split(' ');
                person.FirstName = nameParts[0];
                person.LastName = (nameParts.Length == 2) ? nameParts[1] : string.Empty;

                // Required by TX 111
                person.Gender = AcordLookupBuilder.BuildFromWowString<OLI_LU_GENDER>(otherInsuredRider.Sex.ToString(CultureInfo.InvariantCulture));

                // Required by TX 111, Calculate birth date assuming that it is on the 1st of the year
                person.BirthDate = new DateTime(policy.SceneModifyDate.Year, 1, 1).AddYears(-otherInsuredRider.Age);
                person.BirthDateSpecified = true;
                person.Age = otherInsuredRider.Age.ToString();
                person.DOBEstimated = AcordLookupBuilder.BuildFromTC<OLI_LU_BOOLEAN>((int)OLI_LU_BOOLEAN_TC.OLI_BOOL_FALSE);

                // Apparently, item is used for a Person object or a Organization object.
                // Attach the Person object to the party
                otherInsuredParty.Item = person;

                parties.Add(otherInsuredParty);
            }

            return parties.ToArray();
        }

        protected abstract HOLDING_TYPE[] HydrateHoldingData(Illustration.Model.Generation.Request.Policy policy);


        protected static HOLDING_TYPE InitializeHolding(Illustration.Model.Generation.Request.Policy policy)
        {
            if (policy == null)
            {
                throw new ArgumentNullException("policy", "A Holding cannot be initialized for a null policy object.");
            }

            // Create holding object
            var holding = new HOLDING_TYPE();

            holding.id = "Pol-" + Guid.NewGuid().ToString("N");

            // Create and assign new policy object
            holding.Policy = new Illustration.Model.ACORD.Policy();
            holding.Policy.ProductType = AcordLookupBuilder.BuildFromWowString<OLI_LU_POLPROD>(policy.CategoryCode.ToString(CultureInfo.InvariantCulture));
            holding.Policy.ProductCode = policy.HeaderCode.ToString(CultureInfo.InvariantCulture);
            holding.Policy.Jurisdiction = AcordLookupBuilder.BuildFromWowString<OLI_LU_STATE>(policy.SignedState);
            holding.Policy.PolNumber = policy.PolicyNumber;

            return holding;
        }


        protected static HOLDING_TYPE InitializeInforceHolding(Illustration.Model.Generation.Request.Policy policy)
        {
            if (policy == null)
            {
                throw new ArgumentNullException("policy", "Cannot create an inforce holding for a null policy object.");
            }

            // If policy is not Inforce or if the NonLevelPolicyData section is missing, we can't proceed.
            if (!policy.IsInforce)
            {
                throw new AcordRequestFactoryException(string.Format(CultureInfo.InvariantCulture, "Cannot create an inforce holding for a new business illustration request. Certificate: {0}", policy.PolicyNumber));
            }

            // Get a handle on the inforce data
            if (policy.NonLevelPolicyData == null)
            {
                throw new AcordRequestFactoryException(string.Format(CultureInfo.InvariantCulture, "The NonLevelPolicyData is null for inforce policy '{0}'.", policy.PolicyNumber));
            }

            // Create holding object
            var holding = new HOLDING_TYPE();

            holding.id = "Pol-" + Guid.NewGuid().ToString("N");

            // Create and assign new policy object
            holding.Policy = new Illustration.Model.ACORD.Policy();
            holding.HoldingStatus = AcordLookupBuilder.BuildFromTC<OLI_LU_HOLDSTAT>((int)OLI_LU_HOLDSTAT_TC.OLI_HOLDSTAT_ACTIVE); //1
            holding.Policy.IssueDate = policy.IssueDate;
            holding.Policy.IssueDateSpecified = true;

            return holding;
        }


        protected static FinancialStatement_Type HydrateFinancialStatement(Illustration.Model.Generation.Request.Policy policy, string holdingId)
        {
            if (policy == null)
            {
                throw new ArgumentNullException("policy", "Cannot create a financial statement for a null policy object.");
            }

            if (string.IsNullOrEmpty(holdingId))
            {
                throw new ArgumentNullException("holdingId", "Cannot create a financial statement without a valid holding ID.");
            }

            var statement = new FinancialStatement_Type();

            statement.PolicyStatement = new PolicyStatement_Type();
            statement.PolicyStatement.HoldingID = holdingId;
            statement.PolicyStatement.PolNumber = policy.PolicyNumber;

            if (policy.IsInforce)
            {
                var detail = new PolicyStatementDetail_Type();

                //EndDate		PolicyData/DataDate
                //PolicyValueAtEndDate		PolicyData/AccountValue
                //SurrenderChargeAmt		PolicyData/SurrCharge
                //TotalAmtWthdrwn		PolicyData/FreeWdrl
                //LoanBalance		PolicyData/StdLoanBalance
                //TotalLoanIntAmt		PolicyData/LoanIntAmt
                //TotCumPremAmt		PolicyData/CumPremium

                detail.EndDate = policy.DataDate;
                detail.EndDateSpecified = (policy.DataDate != DateTime.MinValue);

                detail.PolicyValueAtEndDate = policy.AccountValue;
                detail.PolicyValueAtEndDateSpecified = (policy.AccountValue != 0M);

                detail.SurrenderChargeAmt = policy.SurrenderCharge;
                detail.SurrenderChargeAmtSpecified = (policy.SurrenderCharge != 0M);

                detail.TotalAmtWthdrwn = policy.FreeWithdrawal;
                detail.TotalAmtWthdrwnSpecified = (policy.FreeWithdrawal != 0M);

                detail.LoanBalance = policy.StandardLoanBalance;
                detail.LoanBalanceSpecified = (policy.StandardLoanBalance != 0M);

                detail.TotalLoanIntAmt = policy.LoanInterestAmount;
                detail.TotalLoanIntAmtSpecified = (policy.LoanInterestAmount != 0M);

                detail.TotCumPremAmt = policy.CumulativePremium;
                detail.TotCumPremAmtSpecified = (policy.CumulativePremium != 0M);                

                if (policy is IndexedUniversalLifePolicy)
                {
                    detail.PolicyValueAtEndDate = policy.FixedAccountValue;
                    detail.PolicyValueAtEndDateSpecified = (policy.FixedAccountValue != 0M);
                }

                if (policy is AdjustableLifeFlexibleLifePolicy)
                {
                    detail.PolicyValueAtEndDate = policy.BaseCashValue;
                    detail.PolicyValueAtEndDateSpecified = (policy.BaseCashValue != 0M);
                }

                if (policy is WholeLifePolicy || policy is IndexedUniversalLifePolicy || policy is AdjustableLifeFlexibleLifePolicy)
                {
                    var fipExt = AddInforcePolicyStatementDetailExtension(policy);

                    // Add extension to detail level
                    detail.OLifEExtension = new OLifEExtension[] { fipExt };
                }

                // Add detail level to policy statement level
                statement.PolicyStatement.PolicyStatementDetail = new PolicyStatementDetail_Type[] { detail };
            }
            return statement;
        }

        private static AcordPolicyStatementDetailExtension AddInforcePolicyStatementDetailExtension(Illustration.Model.Generation.Request.Policy policy)
        {
            var fipExt = new AcordPolicyStatementDetailExtension() { SystemCode = "Woodmen Illustration Service", VendorCode = "FISERV" };

            //PDFBalance		PolicyData/WLPDFB
            //AveragePDFBalance		PolicyData/AvgPDFBal
            //AverageLoanBalance		PolicyData/AvgLoanBal
            //RefundOnDeposit		PolicyData/DivAccums
            //AverageRefundOnDeposit		PolicyData/AvgRefDepBal
            //PUAInsurance		PolicyData/repPuaInsurance
            //CCVPUAInsurance		PolicyData/CCVPUA
            //RefundLastAnniversary		PolicyData/RefundLast
            //BaseCashValue		PolicyData/BaseCV

            //LoanBalWithInt, 0 
            //PDFBalWithInt, 23351.05 
            //RefDepWithInt, 0 
            //RefDepIntRate, 4.9 
            //PDFIntRate, 3.85

            fipExt.PDFBalance = policy.WLPDFB;
            fipExt.AveragePDFBalance = policy.AveragePremiumDepositFundBalance;
            fipExt.AverageLoanBalance = policy.AverageLoanBalance;
            fipExt.RefundOnDeposit = policy.AccumulatedDividends;
            fipExt.AverageRefundOnDeposit = policy.AverageRefundsOnDepositBalance;
            fipExt.PUAInsurance = policy.PaidUpAdditionsInsurance;
            fipExt.CCVPUAInsurance = policy.CurrentCashValueOfPaidUpInsurance;
            fipExt.RefundLastAnniversary = policy.RefundAtLastAnniversary;
            fipExt.BaseCashValue = policy.BaseCashValue;
            fipExt.CashValueIndexed = policy.IndexedAccountValue;
            fipExt.CumulativeNoLapsePremium = policy.CumulativeNoLapsePremium;            

            fipExt.LoanBalanceWithInterest = policy.LoanBalanceWithInterest;
            fipExt.PremiumDepositFundWithInterest = policy.PremiumDepositFundBalanceWithInterest;
            fipExt.RefundOnDepositWithInterest = policy.RefundsOnDepositWithInterest;
            fipExt.RefundOnDepositInterestRate = policy.RefundsOnDepositInterestRate;
            fipExt.PremiumDepositFundInterestRate = policy.PremiumDepositFundInterestRate;           

            return fipExt;
        }


        protected static LifeUSA_Type HydrateInforceLifeUsaData(Illustration.Model.Generation.Request.Policy policy)
        {
            if (policy == null)
            {
                throw new ArgumentNullException("policy", "Cannot create a LifeUSA object for a null policy object.");
            }

            var lifeUsa = new LifeUSA_Type();

            lifeUsa.MECInd = AcordLookupBuilder.BuildBoolean(policy.IsModifiedEndowmentContract);
            lifeUsa.SevenPayPrem = policy.Guideline7Pay;
            lifeUsa.SevenPayPremSpecified = (policy.Guideline7Pay > decimal.Zero);
            lifeUsa.CumSevenPayPrem = policy.Guideline7PayPremium;
            lifeUsa.CumSevenPayPremSpecified = (policy.Guideline7PayPremium > decimal.Zero);

            if (policy is AdjustableLifeFlexibleLifePolicy)
            {
                lifeUsa.SevenPayPremStartDate = policy.SevenPayPremStartDate;
            }

            return lifeUsa;
        }


        protected static LifeUSA_Type HydrateLifeUsaData(Illustration.Model.Generation.Request.Policy policy)
        {
            if (policy == null)
            {
                throw new ArgumentNullException("policy", "Cannot create a LifeUSA object for a null policy object.");
            }

            var lifeUsa = new LifeUSA_Type();

            lifeUsa.Amount1035 = policy.Lump1035Amount;
            lifeUsa.Amount1035Specified = (lifeUsa.Amount1035 > decimal.Zero);

            //lifeUsa.Basis1035 // This field is not used per Mark K.
            lifeUsa.MEC1035 = AcordLookupBuilder.BuildFromWowString<OLI_LU_BOOLEAN>(policy.IsModifiedEndowmentContract.ToString(CultureInfo.InvariantCulture));

            return lifeUsa;
        }


        protected LifeParticipant[] HydrateBaseLifeParticipantData(Illustration.Model.Generation.Request.Policy policy, DateTime baseDate)
        {
            if (policy == null)
            {
                throw new ArgumentNullException("policy", "Cannot create participant data for a null policy object.");
            }

            var iulPolicy = policy as IndexedUniversalLifePolicy;
            var alflPolicy = policy as AdjustableLifeFlexibleLifePolicy;

            // Create object list
            var lifeParticipants = new List<LifeParticipant>();

            // Create agent object for base coverage only
            var agent = new LifeParticipant();

            // Add agent object to list
            lifeParticipants.Add(agent);

            // Set agent ID and role code
            agent.PartyID = agentId;
            agent.LifeParticipantRoleCode = AcordLookupBuilder.BuildFromTC<OLI_LU_PARTICROLE>((int)OLI_LU_PARTICROLE_TC.OLI_PARTICROLE_PRIMAGENT);

            // Create primary insured object
            var insured = new LifeParticipant();

            // Add insured object to list
            lifeParticipants.Add(insured);

            // Set party ID, role and class type
            insured.PartyID = primaryInsuredId;
            insured.LifeParticipantRoleCode = AcordLookupBuilder.BuildFromTC<OLI_LU_PARTICROLE>((int)OLI_LU_PARTICROLE_TC.OLI_PARTICROLE_PRIMARY);

            insured.TobaccoPremiumBasis = AcordLookupBuilder.BuildFromWowString<OLI_LU_TOBPREMBASIS>(policy.ClassType.ToString(CultureInfo.InvariantCulture));
            if (insured.TobaccoPremiumBasis.tc == OLI_LU_TOBPREMBASIS_TC.OLI_UNKNOWN)
            {
                insured.TobaccoPremiumBasis = null;
            }

            //If IUL policy and NewClassType is set then use it
            insured.UnderwritingClass = (policy is IndexedUniversalLifePolicy && iulPolicy != null && iulPolicy.NewClassType != null)
                ? AcordLookupBuilder.BuildFromWowString<OLI_LU_UNWRITECLASS>(iulPolicy.NewClassType?.ToString(CultureInfo.InvariantCulture))
                : AcordLookupBuilder.BuildFromWowString<OLI_LU_UNWRITECLASS>(policy.ClassType.ToString(CultureInfo.InvariantCulture));

            //If ALFL policy and NewClassType then use it and also include UWClass
            insured.UnderwritingClass = (policy is AdjustableLifeFlexibleLifePolicy && alflPolicy != null && alflPolicy.NewClassType != null)
                ? AcordLookupBuilder.BuildFromWowString<OLI_LU_UNWRITECLASS>(alflPolicy.NewClassType?.ToString(CultureInfo.InvariantCulture))
                : AcordLookupBuilder.BuildFromWowString<OLI_LU_UNWRITECLASS>(policy.ClassType.ToString(CultureInfo.InvariantCulture));

            // If the UnderwritingClass is set to Other, an OLifEExtension object will be needed.
            // This value could represent a class like 'Juvenile Standard' / 12, for example.
            if (insured.UnderwritingClass.tc == OLI_LU_UNWRITECLASS_TC.OLI_OTHER)
            {
                // Create list for extensions
                var extensions = new List<OLifEExtension>();

                // Create object for rating
                // Only expecting Juvenile Standard at this time
                var fipExt = new AcordLifeParticipantExtension() { SystemCode = "Woodmen Illustration Service", VendorCode = "FISERV" };

                // Add objec to list
                extensions.Add(fipExt);

                //If ALFL policy and NewClassType then change UWClass
                if (policy is AdjustableLifeFlexibleLifePolicy && alflPolicy.NewClassType != null)
                {
                    fipExt.UnderwritingClass = AcordLookupBuilder.BuildFromWowString<FIP_UW_CLASS_TYPE>(alflPolicy.NewClassType?.ToString(CultureInfo.InvariantCulture));
                }
                else
                {
                    fipExt.UnderwritingClass = AcordLookupBuilder.BuildFromWowString<FIP_UW_CLASS_TYPE>(policy.ClassType.ToString(CultureInfo.InvariantCulture));
                }
                
                // Add array to parent object
                insured.OLifEExtension = extensions.ToArray();
            }
            else if (insured.UnderwritingClass.tc == OLI_LU_UNWRITECLASS_TC.OLI_UNKNOWN)
            {
                insured.UnderwritingClass = null;
            }

            // If RatingAmount is not '0', we need a SubstandardRating element
            // If RatingExtra1 is greater than 0, we need a flat extra SubstandardRating element
            // If its an IUL policy then use NewRatingAmount if set            

            if (policy.RatingAmount > 0 || policy.RatingExtra1 > 0 || (iulPolicy != null && iulPolicy.NewRatingAmount != null) || (alflPolicy != null && alflPolicy.NewRatingAmount != null))
            {
                //TempTableRating		rtgAmt
                //TempTableRatingEndDate		corresponds to Business rule is that the rating ends at Age 65 or issue age + 20, whichever is greater
                //TempFlatEndDate		corresponds to rtgExtraToAge
                //TempFlatExtraAmt		rtgExtra

                var substandardRatings = new List<SubstandardRating_Type>();

                // Table Rating
                if (policy.RatingAmount > 0 || (iulPolicy != null && iulPolicy.NewRatingAmount != null) || (alflPolicy != null && alflPolicy.NewRatingAmount != null))
                {
                    var subRating = new SubstandardRating_Type();
                    substandardRatings.Add(subRating);

                    subRating.id = "SubStd-" + Guid.NewGuid().ToString("N");
					                  
					
					if (policy is AdjustableLifeFlexibleLifePolicy && policy.HasFaceIncreaseToMaxOut == true)
					{
						//Use NewRatingAmount for ALFL policies if set
						subRating.PermTableRating = alflPolicy?.NewRatingAmount != null
						   ? AcordLookupBuilder.BuildFromWowString<OLI_LU_RATINGS>(alflPolicy.NewRatingAmount == 0 ? "R1" : alflPolicy.NewRatingAmount?.ToString(CultureInfo.InvariantCulture))
						   : AcordLookupBuilder.BuildFromWowString<OLI_LU_RATINGS>(policy.RatingAmount.ToString(CultureInfo.InvariantCulture));

						if (subRating.PermTableRating.tc == OLI_LU_RATINGS_TC.OLI_UNKNOWN)
						{
							subRating.PermTableRating = null;
						}
						else if (subRating.PermTableRating.tc != OLI_LU_RATINGS_TC.OLI_TBLRATE_NONE)
						{
							subRating.PermTableRatingEndDate = CalculateTableRatingEndDate(policy, baseDate);
							subRating.PermTableRatingEndDateSpecified = true;
						}
					}
					else
					{
						if (policy is IndexedUniversalLifePolicy)
						{
							//Use NewRatingAmount for IUL policies if set
							subRating.TempTableRating = iulPolicy?.NewRatingAmount != null
								? AcordLookupBuilder.BuildFromWowString<OLI_LU_RATINGS>(iulPolicy.NewRatingAmount == 0 ? "R1" : iulPolicy.NewRatingAmount?.ToString(CultureInfo.InvariantCulture))
								: AcordLookupBuilder.BuildFromWowString<OLI_LU_RATINGS>(policy.RatingAmount.ToString(CultureInfo.InvariantCulture));
						}
						else
						{
							//Use NewRatingAmount for ALFL policies if set
							subRating.TempTableRating = policy is AdjustableLifeFlexibleLifePolicy && alflPolicy?.NewRatingAmount != null
							   ? AcordLookupBuilder.BuildFromWowString<OLI_LU_RATINGS>(alflPolicy.NewRatingAmount == 0 ? "R1" : alflPolicy.NewRatingAmount?.ToString(CultureInfo.InvariantCulture))
							   : AcordLookupBuilder.BuildFromWowString<OLI_LU_RATINGS>(policy.RatingAmount.ToString(CultureInfo.InvariantCulture));
						}

						if (subRating.TempTableRating.tc == OLI_LU_RATINGS_TC.OLI_UNKNOWN)
						{
							subRating.TempTableRating = null;
						}
						else if (subRating.TempTableRating.tc != OLI_LU_RATINGS_TC.OLI_TBLRATE_NONE || policy is IndexedUniversalLifePolicy || policy is AdjustableLifeFlexibleLifePolicy)
						{
							subRating.TempTableRatingStartDate = baseDate; // issue date for IF, otherwise, certificate date
							subRating.TempTableRatingStartDateSpecified = true;

							subRating.TempTableRatingEndDate = CalculateTableRatingEndDate(policy, baseDate);
							subRating.TempTableRatingEndDateSpecified = true;
						}
					}						
                }

                // Flat Extra rating
                if (policy.RatingExtra1 > 0)
                {
                    var subRating = new SubstandardRating_Type();
                    substandardRatings.Add(subRating);

                    subRating.id = "SubStd-" + Guid.NewGuid().ToString("N");

                    subRating.TempFlatExtraAmt = policy.RatingExtra1;
                    subRating.TempFlatExtraAmtSpecified = true;

                    if (policy.IsInforce)
                    {
                        subRating.TempFlatStartDate = policy.IssueDate;
                        var modifier = policy.RatingExtraToAge1 - policy.IssueAge;
                        subRating.TempFlatEndDate = policy.IssueDate.AddYears(modifier);
                    }
                    else
                    {
                        subRating.TempFlatStartDate = policy.SceneModifyDate;
                        var modifier = policy.RatingExtraToAge1 - policy.Client.Age;
                        subRating.TempFlatEndDate = policy.SceneModifyDate.AddYears(modifier);
                    }
                    subRating.TempFlatStartDateSpecified = true;
                    subRating.TempFlatEndDateSpecified = true;
                }

                insured.SubstandardRating = substandardRatings.ToArray();
            }

            return lifeParticipants.ToArray();
        }


        protected abstract DateTime CalculateTableRatingEndDate(Illustration.Model.Generation.Request.Policy policy, DateTime baseDate);


        protected abstract DateTime CalculateRiderTableRatingEndDate(Illustration.Model.Generation.Request.Policy policy, DateTime riderDate, int riderAge);

        protected LifeParticipant[] HydrateInforceBaseLifeParticipantData(Illustration.Model.Generation.Request.Policy policy)
        {
            if (policy == null)
            {
                throw new ArgumentNullException("policy", "Cannot create inforce life participant data for a null policy object.");
            }

            // Create object list
            var lifeParticipants = new List<LifeParticipant>();

            // Create primary insured object
            var insured = new LifeParticipant();

            // Add insured object to list
            lifeParticipants.Add(insured);

            // Set party ID, role and class type
            insured.PartyID = primaryInsuredId;
            insured.LifeParticipantRoleCode = AcordLookupBuilder.BuildFromTC<OLI_LU_PARTICROLE>((int)OLI_LU_PARTICROLE_TC.OLI_PARTICROLE_PRIMARY);

            insured.TobaccoPremiumBasis = AcordLookupBuilder.BuildFromWowString<OLI_LU_TOBPREMBASIS>(policy.ClassType.ToString(CultureInfo.InvariantCulture));

            if (insured.TobaccoPremiumBasis.tc == OLI_LU_TOBPREMBASIS_TC.OLI_UNKNOWN)
            {
                insured.TobaccoPremiumBasis = null;
            }

            insured.UnderwritingClass = AcordLookupBuilder.BuildFromWowString<OLI_LU_UNWRITECLASS>(policy.ClassType.ToString(CultureInfo.InvariantCulture));

            // If the UnderwritingClass is set to Other, an OLifEExtension object will be needed.
            // This value could represent a class like 'Juvenile Standard' / 12, for example.
            if (insured.UnderwritingClass.tc == OLI_LU_UNWRITECLASS_TC.OLI_OTHER)
            {
                // Create list for extensions
                var extensions = new List<OLifEExtension>();

                // Create object for rating
                // Only expecting Juvenile Standard at this time
                var fipExt = new AcordLifeParticipantExtension() { SystemCode = "Woodmen Illustration Service", VendorCode = "FISERV" };

                // Add objec to list
                extensions.Add(fipExt);

                fipExt.UnderwritingClass = AcordLookupBuilder.BuildFromWowString<FIP_UW_CLASS_TYPE>(policy.ClassType.ToString(CultureInfo.InvariantCulture));

                // Add array to parent object
                insured.OLifEExtension = extensions.ToArray();
            }
            else if (insured.UnderwritingClass.tc == OLI_LU_UNWRITECLASS_TC.OLI_UNKNOWN)
            {
                insured.UnderwritingClass = null;
            }

            // If RatingAmount is not '0', we need a SubstandardRating element
            // If RatingExtra1 is greater than 0, we need a flat extra SubstandardRating element
            if (policy.RatingAmount > 0 || policy.RatingExtra1 > 0)
            {
                //TempTableRating		rtgAmt
                //TempTableRatingEndDate		corresponds to rtgAmtToAge
                //TempFlatEndDate		corresponds to rtgExtraToAge
                //TempFlatExtraAmt		rtgExtra

                var substandardRatings = new List<SubstandardRating_Type>();

                // Table Rating
                if (policy.RatingAmount > 0)
                {
                    var subRating = new SubstandardRating_Type();
                    substandardRatings.Add(subRating);

                    subRating.id = "SubStd-" + Guid.NewGuid().ToString("N");

					if (policy is AdjustableLifeFlexibleLifePolicy && policy.HasFaceIncreaseToMaxOut == true)
					{
						subRating.PermTableRating = AcordLookupBuilder.BuildFromWowString<OLI_LU_RATINGS>(policy.RatingAmount.ToString(CultureInfo.InvariantCulture));
						if (subRating.PermTableRating.tc == OLI_LU_RATINGS_TC.OLI_UNKNOWN)
						{
							subRating.PermTableRating = null;
						}
						else if (subRating.PermTableRating.tc != OLI_LU_RATINGS_TC.OLI_TBLRATE_NONE)
						{
							subRating.PermTableRatingEndDate = CalculateTableRatingEndDate(policy, policy.IssueDate);
							subRating.PermTableRatingEndDateSpecified = true;
						}
					}
					else
					{
						subRating.TempTableRating = AcordLookupBuilder.BuildFromWowString<OLI_LU_RATINGS>(policy.RatingAmount.ToString(CultureInfo.InvariantCulture));
						if (subRating.TempTableRating.tc == OLI_LU_RATINGS_TC.OLI_UNKNOWN)
						{
							subRating.TempTableRating = null;
						}
						else if (subRating.TempTableRating.tc != OLI_LU_RATINGS_TC.OLI_TBLRATE_NONE)
						{
							subRating.TempTableRatingStartDate = policy.IssueDate;
							subRating.TempTableRatingStartDateSpecified = true;

							subRating.TempTableRatingEndDate = CalculateTableRatingEndDate(policy, policy.IssueDate);
							subRating.TempTableRatingEndDateSpecified = true;
						}
					}					
                }

                // Flat Extra rating
                if (policy.RatingExtra1 > 0)
                {
                    var subRating = new SubstandardRating_Type();
                    substandardRatings.Add(subRating);

                    subRating.id = "SubStd-" + Guid.NewGuid().ToString("N");

                    subRating.TempFlatExtraAmt = policy.RatingExtra1;
                    subRating.TempFlatExtraAmtSpecified = true;

                    subRating.TempFlatStartDate = policy.IssueDate;
                    subRating.TempFlatStartDateSpecified = true;

                    var modifier = policy.RatingExtraToAge1 - policy.IssueAge;
                    subRating.TempFlatEndDate = policy.IssueDate.AddYears(modifier);
                    subRating.TempFlatEndDateSpecified = true;
                }

                insured.SubstandardRating = substandardRatings.ToArray();
            }

            return lifeParticipants.ToArray();
        }

        protected LifeParticipant[] HydrateRiderLifeParticipantData(Illustration.Model.Generation.Request.Rider rider,
                                                                    DateTime riderDate, Illustration.Model.Generation.Request.Policy policy)
        {
            if (rider == null)
            {
                throw new ArgumentNullException("rider", "Cannot create rider life participant data for a null rider object.");
            }

            // Create object list
            var lifeParticipants = new List<LifeParticipant>();

            // Create primary insured object
            var insured = new LifeParticipant();
            // Add insured object to list
            lifeParticipants.Add(insured);

            // Set party ID, role and class type
            insured.PartyID = (rider.RiderType == 8) ? otherInsuredId : primaryInsuredId;
            insured.LifeParticipantRoleCode = AcordLookupBuilder.BuildFromTC<OLI_LU_PARTICROLE>((int)OLI_LU_PARTICROLE_TC.OLI_PARTICROLE_PRIMARY);

            // Add Tobacco & Underwriting Basis if Rider Type 8 (Other Insured)
            if (rider.RiderType == 8)
            {
                insured.TobaccoPremiumBasis = AcordLookupBuilder.BuildFromWowString<OLI_LU_TOBPREMBASIS>(rider.Class.ToString(CultureInfo.InvariantCulture));
                insured.UnderwritingClass = AcordLookupBuilder.BuildFromWowString<OLI_LU_UNWRITECLASS>(rider.Class.ToString(CultureInfo.InvariantCulture));
            }

            // Add ratings, if needed
            // If RatingAmount is greater than 0, we need a SubstandardRating element
            // If RatingExtra is greater than 0, we need a flat extra SubstandardRating element
            if (rider.RatingAmount > 0 || rider.RatingExtra > 0)
            {
                //TempTableRating		    rtgAmt
                //TempTableRatingEndDate	corresponds to rtgAmtToAge
                //TempFlatEndDate		    corresponds to rtgExtraToAge
                //TempFlatExtraAmt		    rtgExtra

                var substandardRatings = new List<SubstandardRating_Type>();

                // Table Rating
                if (rider.RatingAmount > 0)
                {
                    var subRating = new SubstandardRating_Type();
                    substandardRatings.Add(subRating);

                    subRating.id = "SubStd-" + Guid.NewGuid().ToString("N");

                    // For EZ and Independence plans, if the base is rated
                    if (rider.RiderType == 2 && policy.RatingAmount > 0)
                    {
                        switch (policy.HeaderCode)          // magic numbers
                        {
                            case 224:
                            case 225:
                            case 226:
                            case 227:
                            case 234:
                            case 260:
                            case 261:
                            case 262:
                            case 263:
                            case 264:
                            case 290:
                            case 291:
                            case 292:
                            case 293:
                            case 294:
                                rider.RatingAmount = 3;     // it's magic too
                                break;
                        }
                    }

                    // We need to prepend an 'R' to the numeric string due to a collision with table ratings on the base coverage.
                    // Riders are table rated at 100%, 200% or 300% using FIP values 1, 2 and 3.
                    // 1, 2 and 3 on the base coverage are 125%, 150% & 175%.
                    // Other Insured Rider use normal table ratings
                    string wowRating;
                    if (rider.RiderType == 8)
                    {
                        // Normal table rating
                        wowRating = rider.RatingAmount.ToString(CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        // Rider table rating
                        wowRating = string.Format(CultureInfo.InvariantCulture, "R{0}", rider.RatingAmount);
                    }
                    subRating.TempTableRating = AcordLookupBuilder.BuildFromWowString<OLI_LU_RATINGS>(wowRating);

                    if (subRating.TempTableRating.tc == OLI_LU_RATINGS_TC.OLI_UNKNOWN)
                    {
                        subRating.TempTableRating = null;
                    }
                    else if (subRating.TempTableRating.tc != OLI_LU_RATINGS_TC.OLI_TBLRATE_NONE)
                    {
                        int riderAge;
                        if (rider.RiderType == 8)
                        {
                            // Use the other insured's age rather than issue age 
                            // (the issue age is intentionally set to the primary's age).
                            riderAge = rider.Age;
                        }
                        else
                        {
                            riderAge = rider.IssueAge;
                        }

                        subRating.TempTableRatingStartDate = riderDate;
                        subRating.TempTableRatingStartDateSpecified = true;

                        subRating.TempTableRatingEndDate = CalculateRiderTableRatingEndDate(policy, riderDate, riderAge);
                        subRating.TempTableRatingEndDateSpecified = true;
                    }
                }

                // Flat Extra rating
                if (rider.RatingExtra > 0)
                {
                    var subRating = new SubstandardRating_Type();
                    substandardRatings.Add(subRating);

                    subRating.id = "SubStd-" + Guid.NewGuid().ToString("N");

                    subRating.TempFlatExtraAmt = rider.RatingExtra;
                    subRating.TempFlatExtraAmtSpecified = true;

                    int baseAge;
                    if (rider.RiderType == 8)
                    {
                        // Use the other insured's age rather than issue age 
                        // (the issue age is intentionally set to the primary's age).
                        baseAge = rider.Age;
                    }
                    else
                    {
                        baseAge = rider.IssueAge;
                    }

                    subRating.TempFlatStartDate = riderDate;
                    subRating.TempFlatStartDateSpecified = true;

                    var modifier = rider.RatingExtraToAge - baseAge;
                    subRating.TempFlatEndDate = riderDate.AddYears(modifier);
                    subRating.TempFlatEndDateSpecified = true;
                }

                insured.SubstandardRating = substandardRatings.ToArray();
            }

            return lifeParticipants.ToArray();
        }

        private static IllustrationReportRequest_Type[] HydrateIllustrationReportRequests(Illustration.Model.Generation.Request.Policy policy)
        {
            // Set IllustrationReportRequest objects
            // There's only two options, TX 111 Basic Illustration or TX 111 Other
            // The TX 111 Other requires an OLifEExtension for StoneRiver specific reports
            var illustrationReportRequests = new List<IllustrationReportRequest_Type>();

            // Basic Illustration is required
            var basicIllustrationRequest = new IllustrationReportRequest_Type();

            // Add basic illustration to list
            illustrationReportRequests.Add(basicIllustrationRequest);

            basicIllustrationRequest.id = "RPT-" + Guid.NewGuid().ToString("N");
            basicIllustrationRequest.IllustrationReportType = AcordLookupBuilder.BuildFromTC<OLI_LU_ILLUSREPORTTYPE>((int)OLI_LU_ILLUSREPORTTYPE_TC.ILL_REP_BASIC);

            // Loop over reports attached to the policy object and create report objects
            foreach (var report in policy.Reports.Where(r => r.Code > ReportType.None))
            {
                // Create new report object
                var reportRequest = new IllustrationReportRequest_Type();

                // Add report objec to list
                illustrationReportRequests.Add(reportRequest);

                // Hydrate data
                reportRequest.id = "RPT-" + Guid.NewGuid().ToString("N");
                // StoneRiver document indicates that only Basic Illustration and Other are supported
                reportRequest.IllustrationReportType = AcordLookupBuilder.BuildFromTC<OLI_LU_ILLUSREPORTTYPE>((int)OLI_LU_ILLUSREPORTTYPE_TC.OLI_OTHER);

                // For Other reports, we need to create a OLifEExtension object
                var fipExt = new AcordIllustrationReportRequestExtension() { SystemCode = "Woodmen Illustration Service", VendorCode = "FISERV" };
                fipExt.ReportCode = AcordLookupBuilder.BuildFromWowString<REPORT_CODE_TYPE>(((int)report.Code).ToString(CultureInfo.InvariantCulture));

                // Jian at StoneRiver indicated that LifePortraits doesn't have a option for including graph vs text anymore.
                // The values were mapped in the database, but the code has been commented out.

                //if (report.IncludeGraph)
                //{
                //    ext.ReportIncludeGraph = AcordLookupBuilder.BuildFromWowString<INCLUDE_GRAPH_TYPE>(report.IncludeGraph.ToString(CultureInfo.InvariantCulture));
                //}

                fipExt.ReportInterestRate = report.InterestRate;
                fipExt.ReportSalesCharge = report.SalesCharge;
                fipExt.ReportTermRates = report.TermRates;

                reportRequest.OLifEExtension = new OLifEExtension[] { fipExt };
            }

            return illustrationReportRequests.ToArray();
        }

        /// <summary>
        /// Generates an array of in-force AcordPolicyExtensions based on the base policy object. The array typically only contains one element.
        /// </summary>
        /// <param name="policy">WOW.Illustration.Model.Generation.Request.Policy</param>
        /// <returns>An array of AcordPolicyExtension as OLifEExtension or null, if the properties are unspecified for serialization.</returns>

        protected virtual OLifEExtension[] HydrateInforcePolicyExtensionData(Illustration.Model.Generation.Request.Policy policy)
        {
            if (policy == null)
            {
                throw new ArgumentNullException("policy", "Cannot create an inforce policy extension for a null policy object.");
            }

            if (!policy.IsInforce)
            {
                throw new AcordRequestFactoryException(string.Format(CultureInfo.InvariantCulture, "Cannot create inforce policy extension data for new business illustration request. Certificate: {0}", policy.PolicyNumber));
            }

            // Create custom extension object
            var fipExt = new AcordPolicyExtension() { SystemCode = "Woodmen Illustration Service", VendorCode = "FISERV" };

            //ModalLoanRepay - UL only, moved to TraditionalAcordFactory
            //APFBlance - no mapping provided, but field is listed
            //StatKind - only present for Legacy illustration requests
            //RefundsOnDeposit
            //NLGLoadTarget
            //NLGAccountValue

            fipExt.StatKind = policy.StatKind;
            fipExt.RefundsOnDeposit = policy.AdditionalInsuranceOnDeposit;
            fipExt.NLGLoadTarget = policy.TargetPremium;
            fipExt.NLGAccountValue = policy.NoLapseGuaranteeAccount;


            // This logic is to suppress returning an extension with zero values because the serializer will hide all the zero field.
            // This causes an empty tag to appear in the XML and LifePortraits chokes on it.
            if (fipExt.StatKindSpecified ||
                fipExt.RefundsOnDepositSpecified ||
                fipExt.NLGLoadTargetSpecified ||
                fipExt.NLGAccountValueSpecified)
            {
                return new OLifEExtension[] { fipExt };
            }
            else
            {
                return null;
            }
        }

        protected virtual OLifEExtension[] HydrateInforcePolicyRefundExtensionData(Illustration.Model.Generation.Request.Policy policy)
        {
            if (policy == null)
            {
                throw new ArgumentNullException("policy", "Cannot create an inforce policy extension for a null policy object.");
            }

            if (!policy.IsInforce)
            {
                throw new AcordRequestFactoryException(string.Format(CultureInfo.InvariantCulture, "Cannot create inforce policy extension data for new business illustration request. Certificate: {0}", policy.PolicyNumber));
            }

            // Create custom extension object
            var fipExt = new AcordPolicyExtension() { SystemCode = "Woodmen Illustration Service", VendorCode = "FISERV" };

            fipExt.RefundsOnDeposit = policy.RefundsOnDepositWithInterest;
            fipExt.RefundLastAnniversary = policy.RefundAtLastAnniversary;
            fipExt.FaceAmountInforceFromRefunds = policy.FaceAmountInforceFromRefunds;
            fipExt.Tamra7PayPremium = policy.Tamra7PayPremium;
            fipExt.PostDEFRAMXCV = policy.PostDEFRAMXCV;
            fipExt.PostDEFRAMXCVSpecified = true;  //Set Specified so the field populates in this section

            if (policy.PolicyOnWaiver)
            {
                fipExt.PolicyOnWaiver = 1;
                fipExt.PolicyOnWaiverSpecified = true;
            }

            var alflPolicy = policy as AdjustableLifeFlexibleLifePolicy;
            if (alflPolicy != null)
            {
                if (alflPolicy.InforceRefundOption != 0)
                {
                    fipExt.InforceRefunds = AcordLookupBuilder.BuildFromWowString<REFUNDS_TYPE>(alflPolicy.InforceRefundOption.ToString(CultureInfo.InvariantCulture));
                    fipExt.InforceRefundsSpecified = true;
                }
            }

            fipExt.YTDAccumulatedRefunds = policy.YTDAccumulatedRefunds;            

            UniversalLifePolicy universalLifePolicy = (UniversalLifePolicy)policy;
            fipExt.ModalLoanRepay = universalLifePolicy.ModalizedLoanRepayment;

            if (fipExt.RefundsOnDepositSpecified || fipExt.FaceAmountInforceFromRefundsSpecified || fipExt.PostDEFRAMXCVSpecified || fipExt.PolicyOnWaiverSpecified || fipExt.YTDAccumulatedRefundsSpecified || fipExt.InforceRefundsSpecified)
            {
                return new OLifEExtension[] { fipExt };
            }
            else
            {
                return null;
            }
        }
    }
}