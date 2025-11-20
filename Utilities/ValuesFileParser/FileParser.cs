using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using WOW.Illustration.ValuesModel;

namespace WOW.Illustration.Utilities.ValuesFileParser
{
    public static class FileParser
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(FileParser));
        private static string fileName;

        public static IllustrationValue ParseFile(string file, int labelLength)
        {
            fileName = file;
            var model = new IllustrationValue();
            var lines = File.ReadAllLines(file);
            LoadValues(model, lines, labelLength);
            return model;
        }

        public static IllustrationValue ParseFile(string[] lines, int labelLength)
        {
            fileName = string.Empty;
            var model = new IllustrationValue();
            LoadValues(model, lines, labelLength);
            return model;
        }

        private static void LoadValues(IllustrationValue model, string[] lines, int labelLength)
        {
            const string ColumnDataMarker = @"*** Column Data ***";
            const string RiderMarker = @"Rider";
            var foundColumnDataMarker = false;

            var singleValueParser = new SingleValueParser(labelLength);
            var columnDataParser = new ColumnDataParser(",");

            Tuple<string, string> singleValuePair;
            Tuple<ColumnDataEnum, IList<decimal>> columnDataPair;

            foreach (var line in lines)
            {
                if (line.StartsWith(ColumnDataMarker, StringComparison.OrdinalIgnoreCase))
                {
                    foundColumnDataMarker = true;
                }
                else if (foundColumnDataMarker)
                {
                    if (columnDataParser.TryParse(line, out columnDataPair))
                    {
                        SetColumnDataValue(model, columnDataPair);
                    }
                    else
                    {
                        if (logger.IsWarnEnabled) logger.WarnFormat(CultureInfo.InvariantCulture, "Could not parse line: {0}", line);
                    }
                }
                else
                {
                    if (singleValueParser.TryParse(line, out singleValuePair))
                    {
                        if (line.StartsWith(RiderMarker, StringComparison.OrdinalIgnoreCase))
                        {
                            SetRiderValue(model, singleValuePair);
                        }
                        else
                        {
                            SetSingleValue(model, singleValuePair);
                        }
                    }
                    else
                    {
                        if (logger.IsWarnEnabled) logger.WarnFormat(CultureInfo.InvariantCulture, "Could not parse line: {0}", line);
                    }
                }
            }
        }

        private static void SetColumnDataValue(IllustrationValue model, Tuple<ColumnDataEnum, IList<decimal>> pair)
        {
            if (pair.Item1 != ColumnDataEnum.None)
            {
                if (model.ColumnData.ContainsKey(pair.Item1))
                {
                    if (logger.IsErrorEnabled) logger.ErrorFormat(CultureInfo.InvariantCulture, "Multiple column sets found for key {0} - {1} in file {2} ", (int)pair.Item1, pair.Item1, fileName);
                    model.ColumnData.Remove(pair.Item1);
                }
                model.ColumnData.Add(pair.Item1, pair.Item2);
            }
        }

        private static void SetRiderValue(IllustrationValue model, Tuple<string, string> pair)
        {
            switch (pair.Item1)
            {
                case "Riders:":
                    //Ignore
                    return;
                case "Riders #:":
                    //Ignore
                    return;
                case "Rider Age:":
                    var rider = new RiderValue();
                    model.Riders.Add(rider);
                    rider.Age = SafeParse(pair.Item2, 0);
                    return;
                case "Rider Amount:":
                    model.Riders[model.Riders.Count - 1].Amount = SafeParse(pair.Item2, 0M);
                    return;
                case "Rider Amount2:":
                    model.Riders[model.Riders.Count - 1].Amount2 = SafeParse(pair.Item2, 0M);
                    return;
                case "Rider Annual Prem:":
                    model.Riders[model.Riders.Count - 1].AnnualPremium = SafeParse(pair.Item2, 0M);
                    return;
                case "Rider Class:":
                    model.Riders[model.Riders.Count - 1].Class = SafeParse(pair.Item2, 0);
                    return;
                case "Rider Insured": //Note that the tag doesn't have a trailing colon.
                    model.Riders[model.Riders.Count - 1].Insured = SafeParse(pair.Item2, 0);
                    return;
                case "Rider Iss Age:":
                    model.Riders[model.Riders.Count - 1].IssueAge = SafeParse(pair.Item2, 0);
                    return;
                case "Rider Level:":
                    model.Riders[model.Riders.Count - 1].Level = SafeParse(pair.Item2, 0);
                    return;
                case "Rider Name:":
                    model.Riders[model.Riders.Count - 1].Name = pair.Item2;
                    return;
                case "Rider Rating Extra:":
                    model.Riders[model.Riders.Count - 1].RatingExtra = SafeParse(pair.Item2, 0M);
                    return;
                case "Rider Rating Extra To Age:":
                    model.Riders[model.Riders.Count - 1].RatingExtraToAge = SafeParse(pair.Item2, 0);
                    return;
                case "Rider Rating Table:":
                    model.Riders[model.Riders.Count - 1].RatingTable = SafeParse(pair.Item2, 0);
                    return;
                case "Rider Rating Table To Age:":
                    model.Riders[model.Riders.Count - 1].RatingTableToAge = SafeParse(pair.Item2, 0);
                    return;
                case "Rider Rider Code:":
                    model.Riders[model.Riders.Count - 1].RiderCode = SafeParse(pair.Item2, 0);
                    return;
                case "Rider Sex:":
                    model.Riders[model.Riders.Count - 1].Sex = SafeParse(pair.Item2, 0);
                    return;
                case "Rider To Age:":
                    model.Riders[model.Riders.Count - 1].ToAge = SafeParse(pair.Item2, 0);
                    return;
                case "Rider Toggle:":
                    model.Riders[model.Riders.Count - 1].Toggle = SafeParse(pair.Item2, 0);
                    return;
            }

            if (pair.Item1.StartsWith("Rider Misc", StringComparison.Ordinal))
            {
                model.Riders[model.Riders.Count - 1].MiscellaneousValues.Add(pair.Item2);
            }
            else
            {
                if (logger.IsWarnEnabled) logger.WarnFormat(CultureInfo.InvariantCulture, "Unknown Rider Pair - Name: {0} Value: {1}", pair.Item1, pair.Item2);
            }
        }

        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"),
        SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode",
            Justification = "Couldn't think of another way to do the object mapping")]
        private static void SetSingleValue(IllustrationValue model, Tuple<string, string> pair)
        {
            switch (pair.Item1)
            {
                case "Date/Time:":
                    model.GenerationDate = SafeParse(pair.Item2, new DateTime());
                    return;
                case "GuarIntRate:":
                    model.GuaranteedInterestRate = SafeParse(pair.Item2, 0M);
                    return;
                case "AssumIntRate:":
                    model.AssumedInterestRate = SafeParse(pair.Item2, 0M);
                    return;
                case "CurrIntRate:":
                    model.CurrentInterestRate = SafeParse(pair.Item2, 0M);
                    return;
                case "GuarLapseYear:":
                    model.GuaranteedLapseYear = SafeParse(pair.Item2, 0);
                    return;
                case "GuarLapseMonth:":
                    model.GuaranteedLapseMonth = SafeParse(pair.Item2, 0);
                    return;
                case "AssumLapseYear:":
                    model.AssumedLapseYear = SafeParse(pair.Item2, 0);
                    return;
                case "AssumLapseMonth:":
                    model.AssumedLapseMonth = SafeParse(pair.Item2, 0);
                    return;
                case "CurrLapseYear:":
                    model.CurrentLapseYear = SafeParse(pair.Item2, 0);
                    return;
                case "CurrLapseMonth:":
                    model.CurrentLapseMonth = SafeParse(pair.Item2, 0);
                    return;
                case "ZeroPremLapseYr:":
                    model.ZeroPremiumLapseYear = SafeParse(pair.Item2, 0);
                    return;
                case "ZeroPremLapseMth:":
                    model.ZeroPremiumLapseMonth = SafeParse(pair.Item2, 0);
                    return;
                case "LumpSumAmt:":
                    model.LumpSumAmount = SafeParse(pair.Item2, 0M);
                    return;
                case "Lump1035Amt:":
                    model.Lump1035Amount = SafeParse(pair.Item2, 0M);
                    return;
                case "LifeContingent:":
                    model.LifeContingent = SafeParse(pair.Item2, 0M);
                    return;
                case "GuarSettleRate:":
                    model.GuaranteedSettleRate = SafeParse(pair.Item2, 0M);
                    return;
                case "CurrSettleRate:":
                    model.CurrentSettleRate = SafeParse(pair.Item2, 0M);
                    return;
                case "GuarLapseYearGuarMort:":
                    model.GuaranteedLapseYearMortality = SafeParse(pair.Item2, 0M);
                    return;
                case "AssumLapseYearGuarMort:":
                    model.AssumedLapseYearMortality = SafeParse(pair.Item2, 0M);
                    return;
                case "CurrLapseYearGuarMort:":
                    model.CurrentLapseYearMortality = SafeParse(pair.Item2, 0M);
                    return;
                case "InitDb:":
                    model.InitialDeathBenefit = SafeParse(pair.Item2, 0M);
                    return;
                case "Minimum Premium:":
                    model.MinimumPremium = SafeParse(pair.Item2, 0M);
                    return;
                case "Target Premium:":
                    model.TargetPremium = SafeParse(pair.Item2, 0M);
                    return;
                case "Guar Net Pay 5:":
                    model.GuaranteedNetPay5 = SafeParse(pair.Item2, 0M);
                    return;
                case "Guar Net Pay 10:":
                    model.GuaranteedNetPay10 = SafeParse(pair.Item2, 0M);
                    return;
                case "Guar Net Pay 20:":
                    model.GuaranteedNetPay20 = SafeParse(pair.Item2, 0M);
                    return;
                case "Guar Surr Cost 5:":
                    model.GuaranteedSurrenderCost5 = SafeParse(pair.Item2, 0M);
                    return;
                case "Guar Surr Cost 10:":
                    model.GuaranteedSurrenderCost10 = SafeParse(pair.Item2, 0M);
                    return;
                case "Guar Surr Cost 20:":
                    model.GuaranteedSurrenderCost20 = SafeParse(pair.Item2, 0M);
                    return;
                case "Assum Net Pay 5:":
                    model.AssumedNetPay5 = SafeParse(pair.Item2, 0M);
                    return;
                case "Assum Net Pay 10:":
                    model.AssumedNetPay10 = SafeParse(pair.Item2, 0M);
                    return;
                case "Assum Net Pay 20:":
                    model.AssumedNetPay20 = SafeParse(pair.Item2, 0M);
                    return;
                case "Assum Surr Cost 5:":
                    model.AssumedSurrenderCost5 = SafeParse(pair.Item2, 0M);
                    return;
                case "Assum Surr Cost 10:":
                    model.AssumedSurrenderCost10 = SafeParse(pair.Item2, 0M);
                    return;
                case "Assum Surr Cost 20:":
                    model.AssumedSurrenderCost20 = SafeParse(pair.Item2, 0M);
                    return;
                case "Curr Net Pay 5:":
                    model.CurrentNetPay5 = SafeParse(pair.Item2, 0M);
                    return;
                case "Curr Net Pay 10:":
                    model.CurrentNetPay10 = SafeParse(pair.Item2, 0M);
                    return;
                case "Curr Net Pay 20:":
                    model.CurrentNetPay20 = SafeParse(pair.Item2, 0M);
                    return;
                case "Curr Surr Cost 5:":
                    model.CurrentSurrenderCost5 = SafeParse(pair.Item2, 0M);
                    return;
                case "Curr Surr Cost 10:":
                    model.CurrentSurrenderCost10 = SafeParse(pair.Item2, 0M);
                    return;
                case "Curr Surr Cost 20:":
                    model.CurrentSurrenderCost20 = SafeParse(pair.Item2, 0M);
                    return;
                case "Guar Net Pay 5 Guar Mort:":
                    model.GuaranteedNetPay5Mortality = SafeParse(pair.Item2, 0M);
                    return;
                case "Guar Net Pay 10 Guar Mort:":
                    model.GuaranteedNetPay10Mortality = SafeParse(pair.Item2, 0M);
                    return;
                case "Guar Net Pay 20 Guar Mort:":
                    model.GuaranteedNetPay20Mortality = SafeParse(pair.Item2, 0M);
                    return;
                case "Guar Surr Pay 5 Guar Mort:": //Note that "Pay" should be "Cost"
                    model.GuaranteedSurrenderCost5Mortality = SafeParse(pair.Item2, 0M);
                    return;
                case "Guar Surr Pay 10 Guar Mort:": //Note that "Pay" should be "Cost"
                    model.GuaranteedSurrenderCost10Mortality = SafeParse(pair.Item2, 0M);
                    return;
                case "Guar Surr Pay 20 Guar Mort:": //Note that "Pay" should be "Cost"
                    model.GuaranteedSurrenderCost20Mortality = SafeParse(pair.Item2, 0M);
                    return;
                case "Assum Net Pay 5 Guar Mort:":
                    model.AssumedNetPay5Mortality = SafeParse(pair.Item2, 0M);
                    return;
                case "Assum Net Pay 10 Guar Mort:":
                    model.AssumedNetPay10Mortality = SafeParse(pair.Item2, 0M);
                    return;
                case "Assum Net Pay 20 Guar Mort:":
                    model.AssumedNetPay20Mortality = SafeParse(pair.Item2, 0M);
                    return;
                case "Assum Surr Cost 5 Guar Mort:":
                    model.AssumedSurrenderCost5Mortality = SafeParse(pair.Item2, 0M);
                    return;
                case "Assum Surr Cost 10 Guar Mort:":
                    model.AssumedSurrenderCost10Mortality = SafeParse(pair.Item2, 0M);
                    return;
                case "Assum Surr Cost 20 Guar Mort:":
                    model.AssumedSurrenderCost20Mortality = SafeParse(pair.Item2, 0M);
                    return;
                case "Curr Net Pay 5 Guar Mort:":
                    model.CurrentNetPay5Mortality = SafeParse(pair.Item2, 0M);
                    return;
                case "Curr Net Pay 10 Guar Mort:":
                    model.CurrentNetPay10Mortality = SafeParse(pair.Item2, 0M);
                    return;
                case "Curr Net Pay 20 Guar Mort:":
                    model.CurrentNetPay20Mortality = SafeParse(pair.Item2, 0M);
                    return;
                case "Curr Surr Cost 5 Guar Mort:":
                    model.CurrentSurrenderCost5Mortality = SafeParse(pair.Item2, 0M);
                    return;
                case "Curr Surr Cost 10 Guar Mort:":
                    model.CurrentSurrenderCost10Mortality = SafeParse(pair.Item2, 0M);
                    return;
                case "Curr Surr Cost 20 Guar Mort:":
                    model.CurrentSurrenderCost20Mortality = SafeParse(pair.Item2, 0M);
                    return;
                case "Resume Year:":
                    model.ResumeYear = SafeParse(pair.Item2, 0);
                    return;
                case "Column Data:":
                    //Ignore;
                    return;
                case "Min Prem Guar:":
                    model.MinimumPremiumGuaranteed = SafeParse(pair.Item2, 0M);
                    return;
                case "Initial Sc:":
                    model.InitialSurrenderCharge = SafeParse(pair.Item2, 0M);
                    return;
                case "Back End Msg:":
                    model.BackEndMessage = pair.Item2;
                    return;
                case "Curr Num Pay:":
                    model.CurrentNumberOfPayments = SafeParse(pair.Item2, 0);
                    return;
                case "Guar Num Pay:":
                    model.GuaranteedNumberOfPayments = SafeParse(pair.Item2, 0);
                    return;
                case "Second Guar Period End:":
                    model.SecondGuaranteedPeriodEnd = SafeParse(pair.Item2, 0);
                    return;
            }

            if (pair.Item1.StartsWith("Misc ", StringComparison.Ordinal))
            {
                model.MiscellaneousValues.Add(pair.Item2);
            }
            else
            {
                if (logger.IsWarnEnabled) logger.WarnFormat(CultureInfo.InvariantCulture, "Unknown Values Pair - Name: {0} Value: {1}", pair.Item1, pair.Item2);
            }
        }

        private static DateTime SafeParse(string value, DateTime defaultValue)
        {
            DateTime dateValue;
            if (DateTime.TryParse(value, out dateValue))
            {
                return dateValue;
            }
            else
            {
                return defaultValue;
            }
        }

        private static decimal SafeParse(string value, decimal defaultValue)
        {
            decimal decimalValue;
            if (decimal.TryParse(value, out decimalValue))
            {
                return decimalValue;
            }
            else
            {
                return defaultValue;
            }
        }

        private static int SafeParse(string value, int defaultValue)
        {
            int intValue;
            if (int.TryParse(value, out intValue))
            {
                return intValue;
            }
            else
            {
                return defaultValue;
            }
        }
    }
}
