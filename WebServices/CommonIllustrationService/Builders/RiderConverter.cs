using System;
using System.Collections.Generic;
using log4net;
using WOW.Illustration.Model.Generation.Request;
using Wow.CommonIllustrationService.DAO;
using Wow.IllustrationCommonModels.Request;
using Wow.CommonIllustrationService.Exceptions;
using Wow.CommonIllustrationService.LookupBuilders;

namespace Wow.CommonIllustrationService.Builders
{
    public class RiderConverter
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(RiderConverter));

        internal List<Rider> Build(IList<Coverage> coverages, string genderCode, DateTime? clientBirthDate)
        {
            if (log.IsInfoEnabled) log.Info($"Build called with coverages.Count: {coverages.Count} genderCode: {genderCode} clientBirthDate: {clientBirthDate}.");

            var list = new List<Rider>();
            CommonLookups commonLookups = new CommonLookups();
            var currentDateTime = DateTime.Now;

            foreach (var coverage in coverages)
            {
                var wimrider = new Rider
                {
                    Sex = genderCode.ToLower() == "male" ? 0 : 1,
                    Name = "",
                    IssueAge = coverage.IssueAge,
                    Amount = coverage.CurrentAmt
                };

                switch (coverage.CoverageTypeCode.ToUpper())
                {
                    case "WMD": // Waiver of Monthly Deduction
                        wimrider.RiderType = 1; //RiderType.WaiverOfMonthlyDeductionRider ACORD 21
                        wimrider.RatingAmount = commonLookups.ConvertRiderRating(coverage.PermanentTableRating);                        
                        wimrider.RatingAmountToAge = commonLookups.CalculateAge(clientBirthDate ?? currentDateTime, coverage.PermanentTableRatingEndDate ?? currentDateTime);
                        break;

                    case "ABE": // Accelerated Benefit Rider -Terminal
                    case "ADBCHRONILL": // Accelerated Benefit Rider -Chronic(OLD = LTCABO)
                        wimrider.RiderType = 105; // RiderType.AcceleratedDeathRider ACORD 105
                        break;

                    case "ADB": // Accidental Death Benefit
                        wimrider.RiderType = 2; // RiderType.AccidentalDeathBenefitRider ACORD 23
                        wimrider.RatingAmount = commonLookups.ConvertRiderRating(coverage.PermanentTableRating);
                        wimrider.RatingAmountToAge = commonLookups.CalculateAge(clientBirthDate ?? currentDateTime, coverage.PermanentTableRatingEndDate ?? currentDateTime);
                        break;

                    // Actual IUL waiver riders
                    // Applicant Waiver of Monthly Deduction rider (aka Waiver of Two Times Monthly Deduction) 
                    // Waiver of Monthly Deduction rider for adult certificates (16-55)
                    case "APPLWAIV": // Applicant Waiver(old = APPLWP) 
                        wimrider.RiderType = 12; // RiderType.WaiverOfPremiumRider, close enough for IUL, AOCRD Other extension
                        wimrider.RatingAmount = commonLookups.ConvertRiderRating(coverage.PermanentTableRating);
                        wimrider.RatingAmountToAge = commonLookups.CalculateAge(clientBirthDate ?? currentDateTime, coverage.PermanentTableRatingEndDate ?? currentDateTime);
                        break;

                    case "OPAI": // Guaranteed Insurance Rider (was GUARIR) AIO and GIR are the same
                        wimrider.RiderType = 3; // RiderType.GuarateedInsurabilityRider ACORD 102
                        break;

                    default:
                        throw new PolicyConverterException($"Invalid coverage.CoverageTypeCode: {coverage.CoverageTypeCode}.");

                }

                list.Add(wimrider);
            }

            return list;
        }

    }
}