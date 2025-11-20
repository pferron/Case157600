using System;

namespace WOW.WoodmenIllustrationService.Code
{
    public static class DateUtilities
    {
        ///// <summary>
        ///// Calculates the End Date for a policy based on issue date, issue age of member and policy type.
        ///// </summary>
        ///// <param name="years">Number of years to add to parameter data. Based on policy type.</param>
        ///// <param name="issueDate">Date the policy was issued.</param>
        ///// <param name="issueAge">Age of member when policy was issued.</param>
        ///// <returns>DateTime representing the calculated end date.</returns>
        //public static DateTime CalculateEndDate(int years, DateTime startDate, int age)
        //{
        //    // Notes from Rudy:

        //    //Whole 120
        //    //Term 95, except in NY which is 80
        //    //AUL/NLGUL 121

        //    //Issue Date + Number - Issue Age of Member
        //    var modifier = years - age;
        //    return startDate.AddYears(modifier);
        //}

        public static int CalculateAge(DateTime birthDate, DateTime targetDate)
        {
            int age = targetDate.Year - birthDate.Year;
            if (targetDate.Month < birthDate.Month || (targetDate.Month == birthDate.Month && targetDate.Day < birthDate.Day)) age--;
            return age;
        }

        public static DateTime? GetNextAnniversary(DateTime? issueDate, DateTime? systemDate)
        {
            if (!issueDate.HasValue)
            {
                return null;
            }
            if (!systemDate.HasValue)
            {
                systemDate = DateTime.Today;
            }

            DateTime nextAnniversary = issueDate.Value;

            // This while loop condition shouldn't be true for actual prod data, but was added to ensure a sensible result is returned if it does happen for some reason.
            while (systemDate < nextAnniversary)
            {
                nextAnniversary = nextAnniversary.AddYears(-1);                
            }

            if (nextAnniversary.Year < systemDate.Value.Year)
            {
                nextAnniversary = new DateTime(systemDate.Value.Year, nextAnniversary.Month, nextAnniversary.Day); // Use the year from the current date with the issueEffectiveDate as a starting point for determining the nextAnniversary.
            }

            if (nextAnniversary < systemDate) //If nextAnniversary has already passed this year, add a year to get to the next occurrence of that date.
            { 
                nextAnniversary = nextAnniversary.AddYears(1);
            }
            
            return nextAnniversary;
        }
    }
}