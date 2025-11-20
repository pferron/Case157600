using System;
using WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Requests;
using WOW.Illustration.Model.Generation.Request;
using log4net;
using System.Globalization;
using WOW.MobileRaterService.Code;
using System.Linq;
using WOW.MobileRaterService.Properties;
using WOW.MobileRaterService.Data;
using WOW.Illustration.Model.Enums;

namespace WOW.MobileRaterService.Builders
{
    internal class PolicyBuilders
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(PolicyBuilders));

        #region Other LifeRate Support Methods - Mark??

        internal Rider BuildTermWPRider(TermLifePolicy termPolicy, LifeRateInput lrInput)
        {
            // need state and toAge
            var state = MobileRaterServiceConfiguration.StateSettings.Single(s => s.StateAbbreviation == termPolicy.SignedState);

            Rider wpRider = new Rider();
            wpRider.RiderType = 1;
            wpRider.IssueAge = termPolicy.IssueAge;
            wpRider.Amount = termPolicy.FaceAmount;
            wpRider.RatingAmount = CommonProcessor.ConvertRiderRating(lrInput.WaiverOfPremium);
            wpRider.RatingAmountToAge = state.MaxWaiverPremiumAge;

            return wpRider;
        }

        internal Rider BuildTermAppWaiverRider(TermLifePolicy termPolicy, LifeRateInput lrInput)
        {
            var state = MobileRaterServiceConfiguration.StateSettings.Single(s => s.StateAbbreviation == termPolicy.SignedState);

            Rider appWaiver = new Rider();
            appWaiver.RiderType = 12;
            appWaiver.IssueAge = termPolicy.IssueAge;
            if (lrInput.PayorAge.HasValue)
            {
                appWaiver.Age = lrInput.PayorAge.Value;
            }
            else
            {
                appWaiver.Age = 0;
            }
            appWaiver.RatingAmount = CommonProcessor.ConvertRiderRating(lrInput.AccidentalDeathRider);
            appWaiver.RatingAmountToAge = state.MaxWaiverPremiumAge;

            return appWaiver;
        }

        internal Rider BuildTermAIORider(TermLifePolicy termPolicy, LifeRateInput lrInput)
        {
            Rider aioRider = new Rider();
            aioRider.RiderType = 3;
            aioRider.IssueAge = termPolicy.IssueAge;
            aioRider.Amount = lrInput.AioGirAmount.Value;  //Value checked in validation
            aioRider.RatingAmount = lrInput.AioGirAmount.Value;
            aioRider.RatingAmountToAge = 70;

            return aioRider;
        }

        internal Rider BuildTermADBRider(TermLifePolicy tPolicy, LifeRateInput lrInput)
        {
            var state = MobileRaterServiceConfiguration.StateSettings.Single(s => s.StateAbbreviation == tPolicy.SignedState);

            Rider adbRider = new Rider();
            adbRider.RiderType = 2;
            adbRider.IssueAge = tPolicy.IssueAge;
            adbRider.Amount = CalculateMaxADValue(lrInput.FaceAmount, tPolicy.IssueAge, true);
            adbRider.RatingAmount = CommonProcessor.ConvertRiderRating(lrInput.AccidentalDeathRider);
            adbRider.RatingAmountToAge = state.MaxAcceleratedDeathBenefitAge;

            return adbRider;

        }

        internal Rider BuildwlAppWaiverRider(WholeLifePolicy wlPolicy, LifeRateInput lrInput)
        {
            var state = MobileRaterServiceConfiguration.StateSettings.Single(s => s.StateAbbreviation == wlPolicy.SignedState);

            Rider appWaiver = new Rider();
            appWaiver.RiderType = 12;
            appWaiver.IssueAge = wlPolicy.IssueAge;
            appWaiver.Age = lrInput.PayorAge.Value;  //Value check done in validation
            appWaiver.RatingAmount = CommonProcessor.ConvertRiderRating(lrInput.AccidentalDeathRider);
            appWaiver.RatingAmountToAge = state.MaxApplicantWaiverPremiumAge;

            return appWaiver;
        }

        internal Rider BuildWLAIORider(WholeLifePolicy wlPolicy, LifeRateInput lrInput)
        {
            Rider aioRider = new Rider();
            aioRider.RiderType = 3;
            aioRider.IssueAge = wlPolicy.IssueAge;
            aioRider.Amount = lrInput.AioGirAmount.Value;//value check done in validation
            //aioRider.RatingAmount = lrInput.AioGirAmount.Value;  //value check done in validation
            aioRider.RatingAmountToAge = 40;

            return aioRider;
        }

        internal Rider BuildWLWPRider(WholeLifePolicy wlPolicy, LifeRateInput lrInput)
        {
            var state = MobileRaterServiceConfiguration.StateSettings.Single(s => s.StateAbbreviation == wlPolicy.SignedState);

            Rider wpRider = new Rider();
            wpRider.RiderType = 1;
            wpRider.IssueAge = wlPolicy.IssueAge;
            wpRider.Amount = wlPolicy.FaceAmount;
            wpRider.RatingAmount = CommonProcessor.ConvertRiderRating(lrInput.WaiverOfPremium);
            wpRider.RatingAmountToAge = state.MaxWaiverPremiumAge;

            return wpRider;
        }

        internal Rider BuildWlADBRider(WholeLifePolicy wlPolicy, LifeRateInput lrInput)
        {
            var state = MobileRaterServiceConfiguration.StateSettings.Single(s => s.StateAbbreviation == wlPolicy.SignedState);

            Rider adbRider = new Rider();
            adbRider.RiderType = 2;
            adbRider.IssueAge = wlPolicy.IssueAge;
            adbRider.Amount = CalculateMaxADValue(wlPolicy.FaceAmount, wlPolicy.IssueAge);
            adbRider.RatingAmount = CommonProcessor.ConvertRiderRating(lrInput.AccidentalDeathRider);
            adbRider.RatingAmountToAge = state.MaxAcceleratedDeathBenefitAge;

            return adbRider;
        }

        private decimal CalculateMaxADValue(decimal faceAmount, int issueAge, bool is2016Term)
        {
            decimal tmpAD = faceAmount;

            if (issueAge < 16)
            {
                if (faceAmount > 25000)
                {
                    tmpAD = 25000;
                }
            }
            else
            {
                if (is2016Term)
                {
                    if (faceAmount > 99999)
                    {
                        tmpAD = 99999;
                    }
                }
                else
                {
                    if (faceAmount > 300000)
                    {
                        tmpAD = 300000;
                    }
                }
            }

            return tmpAD;
        }

        private decimal CalculateMaxADValue(decimal faceAmount, int issueAge)
        {
            return CalculateMaxADValue(faceAmount, issueAge, false);
        }

        internal Rider BuildNlgulWMDRider(NoLapseGuaranteedUniversalLifePolicy nlgulPolicy, LifeRateInput lrInput)
        {
            var state = MobileRaterServiceConfiguration.StateSettings.Single(s => s.StateAbbreviation == nlgulPolicy.SignedState);

            Rider wmdRider = new Rider();
            wmdRider.RiderType = 1;
            wmdRider.IssueAge = nlgulPolicy.IssueAge;
            wmdRider.Amount = lrInput.FaceAmount;
            wmdRider.RatingAmount = CommonProcessor.ConvertRiderRating(lrInput.WaiverMonthlyDeduction);
            wmdRider.RatingAmountToAge = state.MaxWaiverMonthlyDeductionAge;

            return wmdRider;
        }

        internal Rider BuildNlgulADBRider(NoLapseGuaranteedUniversalLifePolicy nlgulPolicy, LifeRateInput lrInput)
        {
            var state = MobileRaterServiceConfiguration.StateSettings.Single(s => s.StateAbbreviation == nlgulPolicy.SignedState);

            Rider adbRider = new Rider();
            adbRider.RiderType = 2;
            adbRider.IssueAge = nlgulPolicy.IssueAge;
            adbRider.Amount = CalculateMaxADValue(lrInput.FaceAmount, nlgulPolicy.IssueAge);
            adbRider.RatingAmount = CommonProcessor.ConvertRiderRating(lrInput.AccidentalDeathRider);
            adbRider.RatingAmountToAge = state.MaxAcceleratedDeathBenefitAge;

            return adbRider;
        }

        internal Rider BuildAulWMDRider(AccumulationUniversalLifePolicy aulPolicy, LifeRateInput lrInput)
        {
            var state = MobileRaterServiceConfiguration.StateSettings.Single(s => s.StateAbbreviation == aulPolicy.SignedState);

            Rider wmdRider = new Rider();
            wmdRider.RiderType = 1;
            wmdRider.IssueAge = aulPolicy.IssueAge;
            wmdRider.Amount = lrInput.FaceAmount;
            wmdRider.RatingAmount = CommonProcessor.ConvertRiderRating(lrInput.WaiverMonthlyDeduction);
            wmdRider.RatingAmountToAge = state.MaxWaiverMonthlyDeductionAge;

            return wmdRider;
        }

        internal Rider BuildAulGIRRider(AccumulationUniversalLifePolicy aulPolicy, LifeRateInput lrInput)
        {
            Rider girRider = new Rider();
            girRider.RiderType = 3;
            girRider.IssueAge = aulPolicy.IssueAge;
            girRider.Amount = lrInput.AioGirAmount.Value;  //value check done in validation
            girRider.RatingAmount = 0;
            girRider.RatingAmountToAge = 40;

            return girRider;
        }

        internal Rider BuildAulAppWaiverRider(AccumulationUniversalLifePolicy aulPolicy, LifeRateInput lrInput)
        {
            var state = MobileRaterServiceConfiguration.StateSettings.Single(s => s.StateAbbreviation == aulPolicy.SignedState);

            Rider appWaiver = new Rider();
            appWaiver.RiderType = 12;
            appWaiver.IssueAge = aulPolicy.IssueAge;
            appWaiver.Age = lrInput.PayorAge.Value;  //value check done in validation
            appWaiver.RatingAmount = CommonProcessor.ConvertRiderRating(lrInput.ApplicantWaiverRider);
            appWaiver.RatingAmountToAge = state.MaxApplicantWaiverPremiumAge;

            return appWaiver;
        }

        internal Rider BuildAulADBRider(AccumulationUniversalLifePolicy aulPolicy, LifeRateInput lrInput)
        {
            var state = MobileRaterServiceConfiguration.StateSettings.Single(s => s.StateAbbreviation == aulPolicy.SignedState);

            Rider adbRider = new Rider();
            adbRider.RiderType = 2;
            adbRider.IssueAge = aulPolicy.IssueAge;
            adbRider.Amount = CalculateMaxADValue(lrInput.FaceAmount, aulPolicy.IssueAge);
            adbRider.RatingAmount = CommonProcessor.ConvertRiderRating(lrInput.AccidentalDeathRider);
            adbRider.RatingAmountToAge = state.MaxAcceleratedDeathBenefitAge;

            return adbRider;
        }

        internal Rider BuildIulWMDRider(IndexedUniversalLifePolicy iulPolicy, LifeRateInput lrInput)
        {
            var state = MobileRaterServiceConfiguration.StateSettings.Single(s => s.StateAbbreviation == iulPolicy.SignedState);

            Rider wmdRider = new Rider();
            wmdRider.RiderType = 1;
            wmdRider.IssueAge = iulPolicy.IssueAge;
            wmdRider.Amount = lrInput.FaceAmount;
            wmdRider.RatingAmount = CommonProcessor.ConvertRiderRating(lrInput.WaiverMonthlyDeduction);
            wmdRider.RatingAmountToAge = state.MaxWaiverMonthlyDeductionAge;

            return wmdRider;
        }

        internal Rider BuildIulGIRRider(IndexedUniversalLifePolicy iulPolicy, LifeRateInput lrInput)
        {
            Rider girRider = new Rider();
            girRider.RiderType = 3;
            girRider.IssueAge = iulPolicy.IssueAge;
            girRider.Amount = lrInput.AioGirAmount.Value;  //value check done in validation
            girRider.RatingAmount = 0;
            girRider.RatingAmountToAge = 40;

            return girRider;
        }

        internal Rider BuildIulAppWaiverRider(IndexedUniversalLifePolicy iulPolicy, LifeRateInput lrInput)
        {
            var state = MobileRaterServiceConfiguration.StateSettings.Single(s => s.StateAbbreviation == iulPolicy.SignedState);

            Rider appWaiver = new Rider();
            appWaiver.RiderType = 12;
            appWaiver.IssueAge = iulPolicy.IssueAge;
            appWaiver.Age = lrInput.PayorAge.Value;  //value check done in validation
            appWaiver.RatingAmount = CommonProcessor.ConvertRiderRating(lrInput.ApplicantWaiverRider);
            appWaiver.RatingAmountToAge = state.MaxApplicantWaiverPremiumAge;

            return appWaiver;
        }

        internal Rider BuildIulADBRider(IndexedUniversalLifePolicy iulPolicy, LifeRateInput lrInput)
        {
            var state = MobileRaterServiceConfiguration.StateSettings.Single(s => s.StateAbbreviation == iulPolicy.SignedState);

            Rider adbRider = new Rider();
            adbRider.RiderType = 2;
            adbRider.IssueAge = iulPolicy.IssueAge;
            adbRider.Amount = CalculateMaxADValue(lrInput.FaceAmount, iulPolicy.IssueAge);
            adbRider.RatingAmount = CommonProcessor.ConvertRiderRating(lrInput.AccidentalDeathRider);
            adbRider.RatingAmountToAge = state.MaxAcceleratedDeathBenefitAge;

            return adbRider;
        }

        #endregion

        internal WholeLifePolicy BuildWholeLifePolicy(IndependenceRateInput indInput, SupportedPlan plan)
        {
            WholeLifePolicy wlPolicy = new WholeLifePolicy();
            wlPolicy.Agent = new AgentPerson();
            wlPolicy.Agent.FirstName = "Mobile";
            wlPolicy.Agent.MiddleName = string.Empty;
            wlPolicy.Agent.LastName = "Rater";
            wlPolicy.Agent.AddressState = "NE"; //required
            wlPolicy.Agent.PhoneNumber = "4025551212"; //required
            ClientPerson client = new ClientPerson();
            wlPolicy.Client = client;
            wlPolicy.Client.FirstName = "Mobile";
            wlPolicy.Client.MiddleName = string.Empty;
            wlPolicy.Client.LastName = "Rater";
            wlPolicy.Client.Age = indInput.Age;
            wlPolicy.Client.Gender = (indInput.Gender.ToUpperInvariant() == "F") ? 1 : 0;
            wlPolicy.FaceAmount = indInput.FaceAmount;
            wlPolicy.FaceCode = 1;
            wlPolicy.BillType = CommonProcessor.ConvertBillType(indInput.BillType, indInput.PaymentMode);
            wlPolicy.PremiumMode = CommonProcessor.ConvertMode(indInput.BillType, indInput.PaymentMode, "IND");
            wlPolicy.ClassType = CommonProcessor.SetInsuredClass(indInput.RatingClass, indInput.Tobacco, indInput.Age, indInput.State);
            wlPolicy.RatingAmount = CommonProcessor.ConvertRating(indInput.RatingClass);
            wlPolicy.HeaderCode = plan.HeaderCode;
            wlPolicy.IssueAge = indInput.Age;
            wlPolicy.SignedState = indInput.State;
            wlPolicy.SceneModifyDate = DateTime.Now;
            wlPolicy.ConceptCode = 1;
            wlPolicy.CategoryCode = 8; //required
            wlPolicy.GenerateValuesTextFile = true;
            wlPolicy.GeneratePdf = Settings.Default.GeneratePDF;
            wlPolicy.LodgeNumber = "16";
            wlPolicy.LodgeState = indInput.State;

            if (indInput.Dues.HasValue && !plan.HasEmbeddedDues)
            {
                wlPolicy.FraternalDues = indInput.Dues.Value;
            }
            else
            {
                wlPolicy.FraternalDues = 0M; // Explicitly set to zero for blank dues or products with embedded dues
            }

            Report rpt = new Report();
            rpt.Code = Illustration.Model.Enums.ReportType.TabularDetailWL;
            wlPolicy.Reports.Add(rpt);

            Report rpt2 = new Report();
            rpt2.Code = Illustration.Model.Enums.ReportType.NumericSummaryWL;
            wlPolicy.Reports.Add(rpt2);
            return wlPolicy;
        }

        internal WholeLifePolicy BuildWholeLifePolicy(LifeRateInput lrInput, SupportedPlan plan)
        {
            WholeLifePolicy wlPolicy = new WholeLifePolicy();
            wlPolicy.Agent = new AgentPerson();
            wlPolicy.Agent.FirstName = "Mobile";
            wlPolicy.Agent.MiddleName = string.Empty;
            wlPolicy.Agent.LastName = "Rater";
            wlPolicy.Agent.AddressState = "NE"; //required
            wlPolicy.Agent.PhoneNumber = "4025551212"; //required
            wlPolicy.Client = new ClientPerson();
            wlPolicy.Client.FirstName = "Mobile";
            wlPolicy.Client.MiddleName = string.Empty;
            wlPolicy.Client.LastName = "Rater";
            wlPolicy.Client.Gender = (lrInput.Gender.ToUpperInvariant() == "F") ? 1 : 0;
            wlPolicy.Client.Age = lrInput.Age;
            wlPolicy.ClassType = CommonProcessor.SetInsuredClass(lrInput.RatingClass, lrInput.Tobacco, lrInput.Age, lrInput.State);
            wlPolicy.FaceAmount = lrInput.FaceAmount;
            wlPolicy.FaceCode = 1;
            wlPolicy.BillType = CommonProcessor.ConvertBillType(lrInput.BillType, lrInput.PaymentMode);
            wlPolicy.RatingAmount = CommonProcessor.ConvertRating(lrInput.RatingClass);
            wlPolicy.GenerateValuesTextFile = true;
            wlPolicy.HeaderCode = plan.HeaderCode;
            wlPolicy.IssueAge = lrInput.Age;
            wlPolicy.PremiumMode = CommonProcessor.ConvertMode(lrInput.BillType, lrInput.PaymentMode, "LR");
            wlPolicy.SignedState = lrInput.State;
            wlPolicy.SceneModifyDate = DateTime.Now;
            wlPolicy.CertificateDate = DateTime.Now;
            wlPolicy.ConceptCode = 1;
            wlPolicy.CategoryCode = 8;
            wlPolicy.GeneratePdf = Settings.Default.GeneratePDF;
            wlPolicy.LodgeNumber = "16";
            wlPolicy.LodgeState = lrInput.State;

            if (lrInput.Dues.HasValue && !plan.HasEmbeddedDues)
            {
                wlPolicy.FraternalDues = lrInput.Dues.Value;
            }
            else
            {
                wlPolicy.FraternalDues = 0M; // Explicitly set to zero for blank dues or products with embedded dues
            }

            if (lrInput.FlatExtra.HasValue)
            {
                // Doing 2 years here because we use 2nd year rates for AUL
                // if we only do 1 year, flat extra falls off
                wlPolicy.RatingExtra1 = lrInput.FlatExtra.Value;
                wlPolicy.RatingExtraToAge1 = lrInput.Age + 2;
            }
            else
            {
                wlPolicy.RatingExtra1 = 0;
                wlPolicy.RatingExtraToAge1 = 0;
            }

            Report rpt = new Report();
            rpt.Code = Illustration.Model.Enums.ReportType.TabularDetailWL;
            wlPolicy.Reports.Add(rpt);
            Report rpt2 = new Report();
            rpt2.Code = Illustration.Model.Enums.ReportType.NumericSummaryWL;
            wlPolicy.Reports.Add(rpt2);

            return wlPolicy;
        }

        internal TermLifePolicy BuildTermPolicy(LifeRateInput lrInput, int headerCode)
        {
            TermLifePolicy termPolicy = new TermLifePolicy();
            try
            {
                termPolicy.Agent = new AgentPerson();
                termPolicy.Agent.FirstName = "Mobile";
                termPolicy.Agent.MiddleName = string.Empty;
                termPolicy.Agent.LastName = "Rater";
                termPolicy.Agent.AddressState = "NE"; //required
                termPolicy.Agent.PhoneNumber = "4025551212"; //required
                termPolicy.Client = new ClientPerson();
                termPolicy.Client.FirstName = "Mobile";
                termPolicy.Client.MiddleName = string.Empty;
                termPolicy.Client.LastName = "Rater";
                if (lrInput.Gender.ToUpperInvariant() == "F")
                {
                    termPolicy.Client.Gender = 1;
                }
                else
                {
                    termPolicy.Client.Gender = 0;
                }
                termPolicy.Client.Age = lrInput.Age;
                termPolicy.ClassType = CommonProcessor.SetInsuredClass(lrInput.RatingClass, lrInput.Tobacco, lrInput.Age, lrInput.State);
                termPolicy.FaceAmount = lrInput.FaceAmount;
                termPolicy.FaceCode = 1;
                termPolicy.BillType = CommonProcessor.ConvertBillType(lrInput.BillType, lrInput.PaymentMode);
                termPolicy.PremiumMode = CommonProcessor.ConvertMode(lrInput.BillType, lrInput.PaymentMode, "LR");
                termPolicy.RatingAmount = CommonProcessor.ConvertRating(lrInput.RatingClass);
                termPolicy.GenerateValuesTextFile = true;
                termPolicy.HeaderCode = headerCode;
                termPolicy.IssueAge = lrInput.Age;
                termPolicy.SignedState = lrInput.State;
                termPolicy.SceneModifyDate = DateTime.Now;
                termPolicy.CertificateDate = DateTime.Now;
                termPolicy.ConceptCode = 1;
                termPolicy.CategoryCode = 4;
                termPolicy.GeneratePdf = Settings.Default.GeneratePDF;
                termPolicy.LodgeNumber = "16";
                termPolicy.LodgeState = lrInput.State;
                termPolicy.FraternalDues = 0;  // dues embedded on 2016 term products
                if (lrInput.FlatExtra.HasValue)
                {
                    // Doing 2 years here because we use 2nd year rates
                    // if we only do 1 year, flat extra falls off
                    termPolicy.RatingExtra1 = lrInput.FlatExtra.Value;
                    termPolicy.RatingExtraToAge1 = lrInput.Age + 2;
                }
                else
                {
                    termPolicy.RatingExtra1 = 0;
                    termPolicy.RatingExtraToAge1 = 0;
                }
                //termPolicy.RatingExtraToAge1 = lrInput.Age + 1;
                Report rpt = new Report();
                rpt.Code = Illustration.Model.Enums.ReportType.TabularDetailTerm;
                termPolicy.Reports.Add(rpt);
                Report rpt2 = new Report();
                rpt2.Code = Illustration.Model.Enums.ReportType.NumericSummaryTerm;
                termPolicy.Reports.Add(rpt2);
                return termPolicy;
            }
            catch (Exception ex)
            {
                if (logger.IsErrorEnabled) { logger.ErrorFormat(CultureInfo.InvariantCulture, "An error occurred in BuildTermPolicy:  Error: {1}.", ex); }
                return termPolicy;
            }
        }

        internal WholeLifePolicy BuildWholeLifePolicy(PatriotInput patriotInput, int headerCode)
        {
            WholeLifePolicy wlPolicy = new WholeLifePolicy();
            wlPolicy.Agent = new AgentPerson();
            wlPolicy.Agent.FirstName = "Mobile";
            wlPolicy.Agent.MiddleName = string.Empty;
            wlPolicy.Agent.LastName = "Rater";
            wlPolicy.Agent.AddressState = "NE"; //required
            wlPolicy.Agent.PhoneNumber = "4025551212"; //required
            wlPolicy.Client = new ClientPerson();
            wlPolicy.Client.FirstName = "Mobile";
            wlPolicy.Client.MiddleName = string.Empty;
            wlPolicy.Client.LastName = "Rater";
            wlPolicy.Client.Gender = 0; // non-gender value, NOTE: AvailabilityTable is NULL for 274, 275
            wlPolicy.Client.Age = patriotInput.Age;
            wlPolicy.ClassType = (patriotInput.Tobacco) ? 4 : 2;
            wlPolicy.FaceAmount = 0;  // Min is 10,000 in AvailabilityTable validation query would fail
            wlPolicy.FaceCode = 1;  // IEW Flag, typically set to 1
            wlPolicy.PremiumMode = 16;      //always monthly
            wlPolicy.BillType = 3;          //always List Bill
            wlPolicy.RatingAmount = 0;
            wlPolicy.PremiumMode = CommonProcessor.ConvertMode("LISTBILL", "MONTHLY", "PAT");
            wlPolicy.HeaderCode = headerCode;
            wlPolicy.IssueAge = patriotInput.Age;
            wlPolicy.SignedState = patriotInput.State;
            wlPolicy.CertificateDate = DateTime.Now;
            wlPolicy.SceneModifyDate = DateTime.Now;
            wlPolicy.ConceptCode = 1;
            wlPolicy.CategoryCode = 8;
            wlPolicy.GenerateValuesTextFile = true;
            wlPolicy.GeneratePdf = Settings.Default.GeneratePDF;
            wlPolicy.LodgeNumber = "16";
            wlPolicy.LodgeState = patriotInput.State;
            Report rpt = new Report();
            rpt.Code = Illustration.Model.Enums.ReportType.TabularDetailWL;
            wlPolicy.Reports.Add(rpt);
            Report rpt2 = new Report();
            rpt2.Code = Illustration.Model.Enums.ReportType.NumericSummaryWL;
            wlPolicy.Reports.Add(rpt2);

            return wlPolicy;
        }

        internal TermLifePolicy BuildTermPolicy(FamilyTermRateInput ftInput, int headerCode)
        {
            TermLifePolicy termPolicy = new TermLifePolicy();
            try
            {
                termPolicy.Agent = new AgentPerson();
                termPolicy.Agent.FirstName = "Mobile";
                termPolicy.Agent.MiddleName = string.Empty;
                termPolicy.Agent.LastName = "Rater";
                termPolicy.Agent.AddressState = "NE"; //required
                termPolicy.Agent.PhoneNumber = "4025551212"; //required
                termPolicy.Client = new ClientPerson();
                termPolicy.Client.FirstName = "Mobile";
                termPolicy.Client.MiddleName = string.Empty;
                termPolicy.Client.LastName = "Rater";
                termPolicy.Client.Gender = 0;
                termPolicy.Client.Age = ftInput.PrimaryAge;
                termPolicy.ClassType = CommonProcessor.SetInsuredClass(ftInput.PrimaryRatingClass, ftInput.PrimaryTobacco, ftInput.PrimaryAge, ftInput.State);
                termPolicy.FaceAmount = ftInput.PrimaryFaceAmount;
                termPolicy.FaceCode = 1;
                termPolicy.BillType = CommonProcessor.ConvertBillType(ftInput.BillType, ftInput.PaymentMode);
                termPolicy.RatingAmount = CommonProcessor.ConvertRating(ftInput.PrimaryRatingClass);
                termPolicy.HeaderCode = headerCode;
                termPolicy.IssueAge = ftInput.PrimaryAge;
                termPolicy.PremiumMode = CommonProcessor.ConvertMode(ftInput.BillType, ftInput.PaymentMode, "FT");
                termPolicy.SignedState = ftInput.State;
                termPolicy.CertificateDate = DateTime.Now;
                termPolicy.SceneModifyDate = DateTime.Now;
                termPolicy.ConceptCode = 1;
                termPolicy.CategoryCode = 4;
                termPolicy.GenerateValuesTextFile = true;
                termPolicy.GeneratePdf = Settings.Default.GeneratePDF;
                termPolicy.LodgeNumber = "16";
                termPolicy.LodgeState = ftInput.State;
                termPolicy.FraternalDues = 0;
                termPolicy.RatingExtra1 = 0;
                termPolicy.RatingExtraToAge1 = ftInput.PrimaryAge + 1;
                Report rpt = new Report();
                rpt.Code = Illustration.Model.Enums.ReportType.TabularDetailTerm;
                termPolicy.Reports.Add(rpt);
                Report rpt2 = new Report();
                rpt2.Code = Illustration.Model.Enums.ReportType.NumericSummaryTerm;
                termPolicy.Reports.Add(rpt2);
                return termPolicy;
            }
            catch (Exception ex)
            {
                if (logger.IsErrorEnabled) { logger.ErrorFormat(CultureInfo.InvariantCulture, "An error occurred in BuildTermPolicy:  Error: {1}.", ex); }
                return termPolicy;
            }
        }

        internal NoLapseGuaranteedUniversalLifePolicy BuildNLGULPolicy(LifeRateInput lrInput, int headerCode)
        {
            NoLapseGuaranteedUniversalLifePolicy nlgPolicy = new NoLapseGuaranteedUniversalLifePolicy();
            nlgPolicy.Agent = new AgentPerson();
            nlgPolicy.Agent.FirstName = "Mobile";
            nlgPolicy.Agent.MiddleName = string.Empty;
            nlgPolicy.Agent.LastName = "Rater";
            nlgPolicy.Agent.AddressState = "NE"; //required
            nlgPolicy.Agent.PhoneNumber = "4025551212"; //required
            nlgPolicy.Client = new ClientPerson();
            nlgPolicy.Client.FirstName = "Mobile";
            nlgPolicy.Client.MiddleName = string.Empty;
            nlgPolicy.Client.LastName = "Rater";

            if (lrInput.Gender.ToUpperInvariant() == "F")
            {
                nlgPolicy.Client.Gender = 1;
            }
            else
            {
                nlgPolicy.Client.Gender = 0;
            }
            nlgPolicy.Client.Age = lrInput.Age;
            nlgPolicy.ClassType = CommonProcessor.SetInsuredClass(lrInput.RatingClass, lrInput.Tobacco, lrInput.Age, lrInput.State);
            nlgPolicy.BillType = CommonProcessor.ConvertBillType(lrInput.BillType, lrInput.PaymentMode);
            nlgPolicy.RatingAmount = CommonProcessor.ConvertRating(lrInput.RatingClass);
            nlgPolicy.GenerateValuesTextFile = true;
            nlgPolicy.HeaderCode = headerCode;
            nlgPolicy.IssueAge = lrInput.Age;
            nlgPolicy.SignedState = lrInput.State;
            nlgPolicy.SceneModifyDate = DateTime.Now;
            nlgPolicy.ConceptCode = 1;
            nlgPolicy.CategoryCode = 3;
            nlgPolicy.GeneratePdf = Settings.Default.GeneratePDF;
            if (lrInput.Dues.HasValue)
            {
                nlgPolicy.FraternalDues = lrInput.Dues.Value;
            }
            else
            {
                nlgPolicy.FraternalDues = 0;
            }
            nlgPolicy.DataDate = DateTime.Now;
            nlgPolicy.RefundOption = 3;

            // Doing 2 years here because we use 2nd year rates
            // if we only do 1 year, flat extra falls off
            if (lrInput.FlatExtra.HasValue)
            {
                nlgPolicy.RatingExtra1 = lrInput.FlatExtra.Value;
                nlgPolicy.RatingExtraToAge1 = lrInput.Age + 2;
            }
            else
            {
                nlgPolicy.RatingExtra1 = 0;
                nlgPolicy.RatingExtraToAge1 = 0;
            }

            //nlgPolicy.Agent = new AgentPerson();
            //nlgPolicy.Agent.FirstName = "Mobile";
            //nlgPolicy.Agent.MiddleName = string.Empty;
            //nlgPolicy.Agent.LastName = "Rater";
            //nlgPolicy.Client = new ClientPerson();
            //nlgPolicy.Client.FirstName = "Mobile";
            //nlgPolicy.Client.MiddleName = string.Empty;
            //nlgPolicy.Client.LastName = "Rater";
            //nlgPolicy.Client.Gender = 0;
            //nlgPolicy.ClassType = CommonProcessor.SetInsuredClass(lrInput.RatingClass, lrInput.Tobacco, lrInput.Age, lrInput.State);
            //nlgPolicy.BillType = CommonProcessor.ConvertBillType(lrInput.BillType, lrInput.PaymentMode);
            //nlgPolicy.RatingAmount = CommonProcessor.ConvertRating(lrInput.RatingClass);
            //nlgPolicy.GenerateValuesTextFile = true;
            //nlgPolicy.HeaderCode = headerCode;
            //nlgPolicy.IssueAge = lrInput.Age;
            //nlgPolicy.SignedState = lrInput.State;
            //nlgPolicy.SceneModifyDate = DateTime.MinValue;
            //nlgPolicy.ConceptCode = 1;
            //nlgPolicy.CategoryCode = 4;
            //nlgPolicy.GeneratePdf = false;

            return nlgPolicy;

        }

        internal AccumulationUniversalLifePolicy BuildAULPolicy(LifeRateInput lrInput, int headerCode)
        {
            AccumulationUniversalLifePolicy aulPolicy = new AccumulationUniversalLifePolicy();

            aulPolicy.Agent = new AgentPerson();
            aulPolicy.Agent.FirstName = "Mobile";
            aulPolicy.Agent.MiddleName = string.Empty;
            aulPolicy.Agent.LastName = "Rater";
            aulPolicy.Agent.AddressState = "NE"; //required
            aulPolicy.Agent.PhoneNumber = "4025551212"; //required

            aulPolicy.Client = new ClientPerson();
            aulPolicy.Client.FirstName = "Mobile";
            aulPolicy.Client.MiddleName = string.Empty;
            aulPolicy.Client.LastName = "Rater";
            if (lrInput.Gender.ToUpperInvariant() == "F")
            {
                aulPolicy.Client.Gender = 1;
            }
            else
            {
                aulPolicy.Client.Gender = 0;
            }
            aulPolicy.Client.Age = lrInput.Age;
            aulPolicy.Client.Birthdate = DateTime.Now.AddYears(-lrInput.Age);

            aulPolicy.ClassType = CommonProcessor.SetInsuredClass(lrInput.RatingClass, lrInput.Tobacco, lrInput.Age, lrInput.State);
            aulPolicy.BillType = CommonProcessor.ConvertBillType(lrInput.BillType, lrInput.PaymentMode);
            aulPolicy.RatingAmount = CommonProcessor.ConvertRating(lrInput.RatingClass);
            aulPolicy.HeaderCode = headerCode;
            aulPolicy.IssueDate = DateTime.Now;
            aulPolicy.DataDate = DateTime.Now;
            aulPolicy.IssueAge = lrInput.Age;
            aulPolicy.SignedState = lrInput.State;
            aulPolicy.SceneModifyDate = DateTime.Now;
            aulPolicy.ConceptCode = 1;
            aulPolicy.CategoryCode = 3;
            aulPolicy.GenerateValuesTextFile = true;
            aulPolicy.GeneratePdf = Settings.Default.GeneratePDF;
            if (lrInput.Dues.HasValue)
            {
                aulPolicy.FraternalDues = lrInput.Dues.Value;
            }
            else
            {
                aulPolicy.FraternalDues = 0;
            }
            aulPolicy.RefundOption = 3;

            // Doing 2 years here because we use 2nd year rates
            // if we only do 1 year, flat extra falls off
            if (lrInput.FlatExtra.HasValue)
            {
                aulPolicy.RatingExtra1 = lrInput.FlatExtra.Value;
                aulPolicy.RatingExtraToAge1 = lrInput.Age + 2;
            }
            else
            {
                aulPolicy.RatingExtra1 = 0;
                aulPolicy.RatingExtraToAge1 = 0;
            }
            aulPolicy.IsTAMRAApplicable = false;
            aulPolicy.NumberOfOwners = 1;
            //aulPolicy.PolicyNumber = "1111111";
            Report rpt = new Report();
            rpt.Code = Illustration.Model.Enums.ReportType.TabularDetailUL;
            aulPolicy.Reports.Add(rpt);
            Report rpt2 = new Report();
            rpt2.Code = Illustration.Model.Enums.ReportType.NumericSummaryUL;
            aulPolicy.Reports.Add(rpt2);
            return aulPolicy;

        }

        internal IndexedUniversalLifePolicy BuildIULPolicy(LifeRateInput lrInput, int headerCode)
        {
            IndexedUniversalLifePolicy iulPolicy = new IndexedUniversalLifePolicy();

            iulPolicy.Agent = new AgentPerson();
            iulPolicy.Agent.FirstName = "Mobile";
            iulPolicy.Agent.MiddleName = string.Empty;
            iulPolicy.Agent.LastName = "Rater";
            iulPolicy.Agent.AddressState = "NE"; //required
            iulPolicy.Agent.PhoneNumber = "4025551212"; //required

            iulPolicy.Client = new ClientPerson();
            iulPolicy.Client.FirstName = "Mobile";
            iulPolicy.Client.MiddleName = string.Empty;
            iulPolicy.Client.LastName = "Rater";
            if (lrInput.Gender.ToUpperInvariant() == "F")
            {
                iulPolicy.Client.Gender = 1;
            }
            else
            {
                iulPolicy.Client.Gender = 0;
            }
            iulPolicy.Client.Age = lrInput.Age;
            iulPolicy.Client.Birthdate = DateTime.Now.AddYears(-lrInput.Age);

            iulPolicy.ClassType = CommonProcessor.SetInsuredClass(lrInput.RatingClass, lrInput.Tobacco, lrInput.Age, lrInput.State);
            iulPolicy.BillType = CommonProcessor.ConvertBillType(lrInput.BillType, lrInput.PaymentMode);
            iulPolicy.RatingAmount = CommonProcessor.ConvertRating(lrInput.RatingClass);
            iulPolicy.HeaderCode = headerCode;
            iulPolicy.IssueAge = lrInput.Age;
            iulPolicy.SignedState = lrInput.State;

            iulPolicy.Lump1035Amount = 0;
            iulPolicy.Guideline7Pay = 0;
            iulPolicy.IssueDate = DateTime.Now;
            iulPolicy.SceneModifyDate = DateTime.Now;
            iulPolicy.DataDate = DateTime.Now;
            iulPolicy.GenerateValuesTextFile = true;
            iulPolicy.GeneratePdf = Settings.Default.GeneratePDF;
            iulPolicy.InitialPremium = 0;
            iulPolicy.NumberOfOwners = 1;
            //iulPolicy.PolicyNumber = "1111111";

            //if (lrInput.Dues.HasValue)
            //{
            //    iulPolicy.FraternalDues = lrInput.Dues.Value;
            //}
            //else
            //{
            iulPolicy.FraternalDues = 0;
            //}

            iulPolicy.RefundOption = 3;

            // Doing 2 years here because we use 2nd year rates
            // if we only do 1 year, flat extra falls off
            if (lrInput.FlatExtra.HasValue)
            {
                iulPolicy.RatingExtra1 = lrInput.FlatExtra.Value;
                iulPolicy.RatingExtraToAge1 = lrInput.Age + 2;
            }
            else
            {
                iulPolicy.RatingExtra1 = 0;
                iulPolicy.RatingExtraToAge1 = 0;
            }

            iulPolicy.ConceptCode = 1;
            iulPolicy.CategoryCode = 3;
            //iulPolicy.ClassType = 1;
            iulPolicy.IsTAMRAApplicable = true;

            iulPolicy.NeedsCostBenefit = false;
            iulPolicy.IsRevisedIllustration = false;

            return iulPolicy;

        }

    }
}