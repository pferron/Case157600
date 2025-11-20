using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WoodmenLife.Enterprise.Illustration.Models.Titanium;

namespace WOW.WoodmenIllustrationService.Code
{
    public class CoverageHelper
    {
        public Coverage GetBaseCoverage(IList<Coverage> Coverages)
        {
            return Coverages.First(c => c.CoverageId == "AAA");
        }

        public decimal GetFaceAmountFromPaidUpAddition(IList<Coverage> Coverages)
        {
            decimal paidUpFaceAmount = 0;

            foreach (var Coverage in Coverages)
            {
                if (Coverage.CoverageIncreaseClassification != null)
                {
                    if (Coverage.CoverageIncreaseClassification.Code == "PUA")
                    {
                        paidUpFaceAmount += Coverage.FaceAmount;
                    }
                }
            }
            return paidUpFaceAmount;
        }
    }
}