using WoodmenLife.Enterprise.Illustration.Models.Titanium;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WOW.Illustration.Model.Generation.Request;
using WOW.WoodmenIllustrationService.Exceptions;
using WOW.WoodmenIllustrationService.LookupBuilders;
using WoodmenLife.Enterprise.Illustration.Models.Changes;

namespace WOW.WoodmenIllustrationService.Builders
{
	public class RiderConverter
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(RiderConverter));
		private List<string> ValidCoverageOptions = new List<string> { "WMD", "ABE", "ADBCHRONILL", "ADB", "APPLWAIV", "OPAI", "2XWMD", "AIO", "AIOAUTO", "WP", "AUTOINC" };
		private List<string> ValidCoverageStatuses = new List<string> { "ACTIVE", "ACTIVE (INFORCE)", "WAIVER" };

		internal List<Rider> Build(IList<Coverage> coverages, string genderCode, DateTime? clientBirthDate, IList<ProposedRider> proposedRiders)
		{
			//Flatten the coverages and coverage options and filter the coverage options
			var coveragesCoverageOptions = coverages.SelectMany(c => c.CoverageOptions.Where(co => ValidCoverageOptions.Contains(co.CoverageOptionType.Code.ToUpper()) && ValidCoverageStatuses.Contains(co.Status.Code.ToUpper())).Select(co => new { coverage = c, coverageOption = co }));

			if (log.IsInfoEnabled)
				log.Info($"Build called with coverages.Count: {coveragesCoverageOptions.Count()} genderCode: {genderCode} clientBirthDate: {clientBirthDate}.");

			var list = new List<Rider>();
			CommonLookups commonLookups = new CommonLookups();
			var currentDateTime = DateTime.Now;

			foreach (var x in coveragesCoverageOptions)
			{
				var wimrider = new Rider
				{
					Sex = 0,
					Name = null,
					IssueAge = x.coverage.IssueAge
				};

				wimrider.RatingAmount = commonLookups.ConvertRiderRating(commonLookups.ConvertRating(x.coverageOption.PermanentTableRating?.Code ?? string.Empty));
				wimrider.RatingAmountToAge = commonLookups.CalculateAge(clientBirthDate ?? currentDateTime, x.coverageOption.PermanentTableRatingEndDate ?? currentDateTime);

				switch (x.coverageOption.CoverageOptionType.Code.ToUpper())
				{
				case "AUTOINC": // Automatic Increase						
					wimrider.RiderType = 5; // RiderType.AutomaticIncreaseRider
					wimrider.ToAge = (int)x.coverageOption.ExpirationAge;
					wimrider.Amount = x.coverageOption.CoverageOptionAmount;
					break;
				case "WP": // Waiver of Premium
					wimrider.RiderType = 11; // RiderType.WaiverOfPremiumRider				
					wimrider.ToAge = (int)x.coverageOption.ExpirationAge;
					wimrider.Amount = x.coverageOption.CoverageOptionAmount;
					break;
				case "WMD": // Waiver of Monthly Deduction
					wimrider.RiderType = 1; //RiderType.WaiverOfMonthlyDeductionRider ACORD 21
					wimrider.ToAge = 65;
					break;

				case "ABE": // Accelerated Benefit Rider -Terminal
				case "ADBCHRONILL": // Accelerated Benefit Rider -Chronic(OLD = LTCABO)
					wimrider.RiderType = 105; // RiderType.AcceleratedDeathRider ACORD 105
					wimrider.ToAge = 95;
					break;

				case "ADB": // Accidental Death Benefit
					wimrider.RiderType = 2; // RiderType.AccidentalDeathBenefitRider ACORD 23
					wimrider.ToAge = 70;
					wimrider.Amount = x.coverageOption.CoverageOptionAmount;
					break;

				// Actual IUL waiver riders
				// Applicant Waiver of Monthly Deduction rider (aka Waiver of Two Times Monthly Deduction) 
				// Waiver of Monthly Deduction rider for adult certificates (16-55)
				case "APPLWAIV": // Applicant Waiver(old = APPLWP) 
					wimrider.RiderType = 12; // RiderType.WaiverOfPremiumRider, close enough for IUL, AOCRD Other extension
					wimrider.ToAge = 21;
					break;

				case "OPAI": // Guaranteed Insurance Rider (was GUARIR) AIO and GIR are the same
				case "AIO":
				case "AIOAUTO":
					wimrider.RiderType = 3; // RiderType.GuarateedInsurabilityRider ACORD 102
					wimrider.ToAge = 40;
					wimrider.Amount = x.coverageOption.CoverageOptionAmount;
					break;

				case "2XWMD":
					wimrider.RiderType = 101;
					wimrider.ToAge = (int)x.coverageOption.ExpirationAge;
					break;

				default:
					throw new PolicyConverterException($"Invalid coverage.CoverageTypeCode: {x.coverageOption.CoverageOptionType.Code}.");
				}

				list.Add(wimrider);
			}

			if (proposedRiders != null)
			{
				foreach (var rider in proposedRiders)
				{
					var wimrider = new Rider
					{
						Sex = 0,
						Name = null,
						IssueAge = rider.IssueAge ?? 0,
						ToAge = rider.ToAge,
						RiderType = rider.RiderType,
						Amount = rider.RiderAmount ?? 0,
						RatingAmount = rider.Rating ?? 0
					};

					list.Add(wimrider);
				}
			}

			return list;
		}
	}
}