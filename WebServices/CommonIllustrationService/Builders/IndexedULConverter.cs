using log4net;
using System;
using Wow.CommonIllustrationService.Exceptions;
using Wow.CommonIllustrationService.LookupBuilders;
using Wow.IllustrationCommonModels.Request;
using WOW.Illustration.Model.Enums;
using WOW.Illustration.Model.Generation.Request;

namespace Wow.CommonIllustrationService.Builders
{
    public class IndexedUniversalLifePolicyConverter : CommonPolicyConverter
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(IndexedUniversalLifePolicyConverter));

        private IndexedUniversalLifePolicy _policy;

        private IllustrationRequest _request;

        private IULLookups _iULLookups = new IULLookups();


        public IndexedUniversalLifePolicyConverter(IllustrationRequest request)
        {
            _request = request;
            base.Request = request;

            _policy = new IndexedUniversalLifePolicy();
            base.Policy = _policy;
        }

        public static IndexedUniversalLifePolicyConverter CreateConverter(IllustrationRequest request)
        {
            if (log.IsInfoEnabled) log.Info($"CreateConverter called.");

            try
            {
                IndexedUniversalLifePolicyConverter iulConverter = new IndexedUniversalLifePolicyConverter(request);
                return iulConverter;
            }
            catch (Exception ex) when (!(ex is PolicyConverterException))
            {
                throw new PolicyConverterException("Exception while creating the Index UniversalLify Policy Converter", ex);
            }
        }

        protected override void HydratePolicySpecificData()
        {
            if (log.IsInfoEnabled) log.Info($"HydratePolicySpecificData called.");

            switch (_request.PlanId.ToUpper())
            {
                case "TUINDEXC":
                case "TUINDEXN":
                case "TUINDEXT":
                case "TUINDEXP":
                case "TUINDEXR":
                case "TUINDEXU":
                    _policy.HeaderCode = 123;
                    break;
                default:
                    throw new PolicyConverterException($"Invalid PlanId: {_request.PlanId} for ProdcutTypeCode: {_request.ProductTypeCode}.");
            }

            _policy.CategoryCode = 3; // UniversalLife = 3
            _policy.ConceptCode = 1; // (1 means New Business, 5 means Inforce)

            // ClassCode is not used by the WIS
            _policy.ClassType = _iULLookups.ConvertClass(Request.PlanId);

            _policy.IsTAMRAApplicable = (Request.MECAllowedIndicator ?? false) ? false : true;

            _policy.BillType = _iULLookups.ConvertBillType(Request.BillingMethodCode);

            switch (Request.IllustrationReportType.ToUpper())
            {
                case "REVISED":
                    _policy.NeedsCostBenefit = false;
                    _policy.IsRevisedIllustration = true;
                    break;

                case "COST":
                    _policy.NeedsCostBenefit = true;
                    _policy.IsRevisedIllustration = false;
                    break;

                case "BASIC":
                    _policy.NeedsCostBenefit = false;
                    _policy.IsRevisedIllustration = false;
                    break;

                default:
                    throw new Exception($"Invalid illustrationReportType: {Request.IllustrationReportType} found.");
            }
        }

        protected virtual void HydrateNonLevelData()
        {
            if (log.IsInfoEnabled) log.Info($"HydrateNonLevelData called.");

            // FaceAmount
            var nld1 = new NonLevelData();
            nld1.DataTypeCode = DataType.CoverageBenefit;
            nld1.Level = 1;
            nld1.Codes.Add(1);
            nld1.Codes.Add(0);
            nld1.Codes.Add(0);
            nld1.Codes.Add(0);
            // NLRates in the FIP were not implemented in WIM
            nld1.Amounts.Add(Request.FaceAmount);
            nld1.Amounts.Add(0);
            // NLGradePct in the FIP was not implemented in WIM
            nld1.Age = 121; // 121 for UL
            _policy.NonLevelData.Add(nld1);

            // BillingModeCode
            var nld2 = new NonLevelData();
            nld2.DataTypeCode = DataType.PaymentSchedule;
            nld2.Level = 1;
            nld2.Codes.Add(1);
            nld2.Codes.Add(_iULLookups.ConvertBillingMode(Request.BillingModeCode));
            nld2.Codes.Add(0);
            nld2.Codes.Add(0);
            // NLRates in the FIP were not implemented in WIM
            nld2.Amounts.Add(Request.BillingAmount);
            nld2.Amounts.Add(0);
            // NLGradePct in the FIP was not implemented in WIM
            nld2.Age = 121; // 121 for UL
            _policy.NonLevelData.Add(nld2);

            if (!string.IsNullOrEmpty(Request.DeathBenefitOptionCode))
            {
                // DeathBenefitOptionCode
                var nld6 = new NonLevelData();
                nld6.DataTypeCode = DataType.DeathBenefit;
                nld6.Level = 1;
                // Map LEVEL to 1 (includes) and INCR to 2 (excludes) 
                nld6.Codes.Add(Request.DeathBenefitOptionCode.Equals("LEVEL", StringComparison.InvariantCultureIgnoreCase) ? 1 : 2);
                nld6.Codes.Add(0);
                nld6.Codes.Add(0);
                nld6.Codes.Add(0);
                // NLRates in the FIP were not implemented in WIM
                nld6.Amounts.Add(0);
                nld6.Amounts.Add(0);
                // NLGradePct in the FIP was not implemented in WIM
                nld6.Age = 121; // 121 for UL
                _policy.NonLevelData.Add(nld6);
            }

            // Request.InitialPremium  NLD #8
            var nld8level1 = new NonLevelData();
            nld8level1.DataTypeCode = DataType.LumpSum;
            nld8level1.Level = 1;
            nld8level1.Codes.Add(1);
            nld8level1.Codes.Add(0);
            nld8level1.Codes.Add(0);
            nld8level1.Codes.Add(0);
            // NLRates in the FIP were not implemented in WIM
            nld8level1.Amounts.Add(Request.InitialPremium);
            nld8level1.Amounts.Add(0);
            // NLGradePct in the FIP was not implemented in WIM
            nld8level1.Age = Request.IssueAge + 1;
            _policy.NonLevelData.Add(nld8level1);

            var nld8level2 = new NonLevelData();
            nld8level2.DataTypeCode = DataType.LumpSum;
            nld8level2.Level = 2;
            nld8level2.Codes.Add(1);
            nld8level2.Codes.Add(0);
            nld8level2.Codes.Add(0);
            nld8level2.Codes.Add(0);
            // NLRates in the FIP were not implemented in WIM
            nld8level2.Amounts.Add(0);
            nld8level2.Amounts.Add(0);
            // NLGradePct in the FIP was not implemented in WIM
            nld8level2.Age = 121;
            _policy.NonLevelData.Add(nld8level2);
        }

        protected void HydrateFundData()
        {
            if(_request.Funds.Count != 2)
            {
                throw new PolicyConverterException("IUL request requires 2 Fund Accounts.");
            }

            foreach(var fund in _request.Funds)
            {
                var subAccount = new SubAccount();

                subAccount.ProductCode = _iULLookups.ConvertFundAccount(fund.FundAccountId);
                subAccount.AllocPercent = fund.FundAllocationPercent;

                _policy.SubAccounts.Add(subAccount);
            }

        }

        protected virtual void HydrateReportData()
        {
            if (log.IsInfoEnabled) log.Info($"HydrateReportData called.");

            // Level and includeGraph were not implemented in the WIM
            var report = new Report
            {
                Code = ReportType.NarrativeSummaryBase,
                InterestRate = 0,
                SalesCharge = 0,
                TermRates = 0
            };
            _policy.Reports.Add(report);

            report = new Report
            {
                Code = ReportType.NumericSummaryUL,
                InterestRate = 0,
                SalesCharge = 0,
                TermRates = 0
            };
            _policy.Reports.Add(report);

            report = new Report
            {
                Code = ReportType.TabularDetailUL,
                InterestRate = 0,
                SalesCharge = 0,
                TermRates = 0
            };
            _policy.Reports.Add(report);
        }

        public new Policy HydratePolicyData()
        {
            if (log.IsInfoEnabled) log.Info($"HydratePolicyData called.");

            base.HydratePolicyData();
            HydratePolicySpecificData();
            HydrateNonLevelData();
            HydrateFundData();
            HydrateReportData();
            return Policy;
        }

    }
}