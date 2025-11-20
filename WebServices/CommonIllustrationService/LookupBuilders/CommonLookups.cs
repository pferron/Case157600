using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wow.CommonIllustrationService.Exceptions;

namespace Wow.CommonIllustrationService.LookupBuilders
{
    public class CommonLookups
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(CommonLookups));

        /// <summary>
        /// Converts Common Model rating code to Sapiens value for WIM.
        /// </summary>
        /// <param name="permanentTableRatingCode">Common Model rating code</param>
        /// <returns>Sapiens code for perm rating</returns>
        internal int ConvertRating(string permanentTableRatingCode)
        {
            if (log.IsInfoEnabled) log.Info($"ConvertRating called with permanentTableRatingCode: {permanentTableRatingCode}.");

            //OLI_TBLRATE_A   1
            //OLI_TBLRATE_B   2
            //OLI_TBLRATE_C   3
            //OLI_TBLRATE_D   4
            //OLI_TBLRATE_E   5
            //OLI_TBLRATE_F   6
            //OLI_TBLRATE_G   7
            //OLI_TBLRATE_H   8
            //OLI_TBLRATE_I   9
            //OLI_TBLRATE_J   10
            //OLI_TBLRATE_K   11
            //OLI_TBLRATE_L   12
            //OLI_TBLRATE_M   13
            //OLI_TBLRATE_N   14
            //OLI_TBLRATE_O   15
            //OLI_TBLRATE_P   16

            // The WIM uses the FIP value, so we have to take the CIM ACORD value,
            // convert it to FIP and then back to ACORD.
            // https://wiki.woodmen.net/display/COMM/OLI_LU_RATINGS
            //PermanentTableRatingCode can be empty or NONE
            var ratingCode = permanentTableRatingCode.Trim();
            if (ratingCode.Length == 0 || ratingCode.Equals("NONE", StringComparison.InvariantCultureIgnoreCase))
            {
                return 0;
            }

            switch (permanentTableRatingCode.ToUpper())
            {
                case "A":
                    return 1;
                case "B":
                    return 2;
                case "C":
                    return 3;
                case "D":
                    return 4;
                case "E":
                    return 5;
                case "F":
                    return 6;
                case "G":
                    return 7;
                case "H":
                    return 8;
                case "I":
                    return 9;
                case "J":
                    return 10;
                case "K":
                    return 11;
                case "L":
                    return 12;
                case "M":
                    return 13;
                case "N":
                    return 14;
                case "O":
                    return 15;
                case "P":
                    return 16;
                default:
                    throw new PolicyConverterException($"ConvertRating failed to process invalid permanentTableRatingCode: {permanentTableRatingCode} while executing the Common Policy Converter.");
            }

        }

        internal int ConvertRiderRating(int permanentTableRating)
        {
            if (log.IsInfoEnabled) log.Info($"ConvertRiderRating called with permanentTableRating: {permanentTableRating}.");
            
            // The WIM uses the FIP value, so we have to take the CIM ACORD value,
            // convert it to FIP and then back to ACORD.
            // https://wiki.woodmen.net/display/COMM/OLI_LU_RATINGS
            //PermanentTableRatingCode can be empty or NONE

            switch (permanentTableRating)
            {
                case 100:
                    return 0;
                case 200:
                    return 2;
                case 300:
                    return 3;                
                default:
                    throw new PolicyConverterException($"ConvertRating failed to process invalid permanentTableRating: {permanentTableRating} while executing the Common Policy Converter.");
            }

        }

        internal int CalculateAge(DateTime dateOfBirth, DateTime targetDate)
        {
            if (log.IsInfoEnabled) log.Info($"CalculateAge called with dateOfBirth: {dateOfBirth.ToShortDateString()} targetDate: {targetDate.ToShortDateString()}.");

            if (targetDate <= dateOfBirth)
            {
                throw new PolicyConverterException($"CalculateAge failed to process while executing the Common Policy Converter. dateOfBirth: {dateOfBirth} is after specified targetDate: {targetDate}.");

            }

            int age = 0;
            age = targetDate.Year - dateOfBirth.Year;
            if (targetDate.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }
    }
}