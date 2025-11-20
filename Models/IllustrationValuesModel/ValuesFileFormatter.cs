using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace WOW.Illustration.ValuesModel
{
    public static class ValuesFileFormatter
    {
        private static int LabelLength;
        private static StringBuilder sb;

        public static string Format(IllustrationValue input, int labelLength)
        {
            return Format(input, labelLength, false);
        }

        public static string Format(IllustrationValue input, int labelLength, bool relevantFieldsOnly)
        {
            LabelLength = labelLength;
            sb = new StringBuilder();
            if (relevantFieldsOnly)
            {
                AppendLine("GuarIntRate:", input.GuaranteedInterestRate);
                AppendLine("GuarLapseYear:", input.GuaranteedLapseYear);
                AppendLine("GuarLapseMonth:", input.GuaranteedLapseMonth);
                AppendLine("CurrLapseYear:", input.CurrentLapseYear);
                AppendLine("CurrLapseMonth:", input.CurrentLapseMonth);
                AppendLine("Curr Surr Cost 10:", input.CurrentSurrenderCost10);
                AppendLine("Curr Surr Cost 20:", input.CurrentSurrenderCost20);
                AppendLine("ZeroPremLapseYr:", input.ZeroPremiumLapseYear);
                AppendLine("ZeroPremLapseMth:", input.ZeroPremiumLapseMonth);

                if (input.MiscellaneousValues.Count > 3 && !string.IsNullOrWhiteSpace(input.MiscellaneousValues[3]))
                {
                    AppendLine("Misc 4:", input.MiscellaneousValues[3]);
                }
            }
            else
            {
                var value = input.GenerationDate.ToString("MM/dd/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                AppendLine("Date/Time:", value);

                AppendLine("GuarIntRate:", input.GuaranteedInterestRate);
                AppendLine("AssumIntRate:", input.AssumedInterestRate);
                AppendLine("CurrIntRate:", input.CurrentInterestRate);
                AppendLine("GuarLapseYear:", input.GuaranteedLapseYear);
                AppendLine("GuarLapseMonth:", input.GuaranteedLapseMonth);
                AppendLine("AssumLapseYear:", input.AssumedLapseYear);
                AppendLine("AssumLapseMonth:", input.AssumedLapseMonth);
                AppendLine("CurrLapseYear:", input.CurrentLapseYear);
                AppendLine("CurrLapseMonth:", input.CurrentLapseMonth);
                AppendLine("ZeroPremLapseYr:", input.ZeroPremiumLapseYear);
                AppendLine("ZeroPremLapseMth:", input.ZeroPremiumLapseMonth);
                AppendLine("LumpSumAmt:", input.LumpSumAmount);
                AppendLine("Lump1035Amt:", input.Lump1035Amount);
                AppendLine("LifeContingent:", input.LifeContingent);
                AppendLine("GuarSettleRate:", input.GuaranteedSettleRate);
                AppendLine("CurrSettleRate:", input.CurrentSettleRate);
                AppendLine("GuarLapseYearGuarMort:", input.GuaranteedLapseYearMortality);
                AppendLine("AssumLapseYearGuarMort:", input.AssumedLapseYearMortality);
                AppendLine("CurrLapseYearGuarMort:", input.CurrentLapseYearMortality);
                AppendLine("InitDb:", input.InitialDeathBenefit);
                AppendLine("Minimum Premium:", input.MinimumPremium);
                AppendLine("Target Premium:", input.TargetPremium);
                AppendLine("Guar Net Pay 5:", input.GuaranteedNetPay5);
                AppendLine("Guar Net Pay 10:", input.GuaranteedNetPay10);
                AppendLine("Guar Net Pay 20:", input.GuaranteedNetPay20);
                AppendLine("Guar Surr Cost 5:", input.GuaranteedSurrenderCost5);
                AppendLine("Guar Surr Cost 10:", input.GuaranteedSurrenderCost10);
                AppendLine("Guar Surr Cost 20:", input.GuaranteedSurrenderCost20);
                AppendLine("Assum Net Pay 5:", input.AssumedNetPay5);
                AppendLine("Assum Net Pay 10:", input.AssumedNetPay10);
                AppendLine("Assum Net Pay 20:", input.AssumedNetPay20);
                AppendLine("Assum Surr Cost 5:", input.AssumedSurrenderCost5);
                AppendLine("Assum Surr Cost 10:", input.AssumedSurrenderCost10);
                AppendLine("Assum Surr Cost 20:", input.AssumedSurrenderCost20);
                AppendLine("Curr Net Pay 5:", input.CurrentNetPay5);
                AppendLine("Curr Net Pay 10:", input.CurrentNetPay10);
                AppendLine("Curr Net Pay 20:", input.CurrentNetPay20);
                AppendLine("Curr Surr Cost 5:", input.CurrentSurrenderCost5);
                AppendLine("Curr Surr Cost 10:", input.CurrentSurrenderCost10);
                AppendLine("Curr Surr Cost 20:", input.CurrentSurrenderCost20);
                AppendLine("Guar Net Pay 5 Guar Mort:", input.GuaranteedNetPay5Mortality);
                AppendLine("Guar Net Pay 10 Guar Mort:", input.GuaranteedNetPay10Mortality);
                AppendLine("Guar Net Pay 20 Guar Mort:", input.GuaranteedNetPay20Mortality);
                //These should have been called Surr Cost
                AppendLine("Guar Surr Pay 5 Guar Mort:", input.GuaranteedSurrenderCost5Mortality);
                AppendLine("Guar Surr Pay 10 Guar Mort:", input.GuaranteedSurrenderCost10Mortality);
                AppendLine("Guar Surr Pay 20 Guar Mort:", input.GuaranteedSurrenderCost20Mortality);
                AppendLine("Assum Net Pay 5 Guar Mort:", input.AssumedNetPay5Mortality);
                AppendLine("Assum Net Pay 10 Guar Mort:", input.AssumedNetPay10Mortality);
                AppendLine("Assum Net Pay 20 Guar Mort:", input.AssumedNetPay20Mortality);
                AppendLine("Assum Surr Cost 5 Guar Mort:", input.AssumedSurrenderCost5Mortality);
                AppendLine("Assum Surr Cost 10 Guar Mort:", input.AssumedSurrenderCost10Mortality);
                AppendLine("Assum Surr Cost 20 Guar Mort:", input.AssumedSurrenderCost20Mortality);
                AppendLine("Curr Net Pay 5 Guar Mort:", input.CurrentNetPay5Mortality);
                AppendLine("Curr Net Pay 10 Guar Mort:", input.CurrentNetPay10Mortality);
                AppendLine("Curr Net Pay 20 Guar Mort:", input.CurrentNetPay20Mortality);
                AppendLine("Curr Surr Cost 5 Guar Mort:", input.CurrentSurrenderCost5Mortality);
                AppendLine("Curr Surr Cost 10 Guar Mort:", input.CurrentSurrenderCost10Mortality);
                AppendLine("Curr Surr Cost 20 Guar Mort:", input.CurrentSurrenderCost20Mortality);
                AppendLine("Resume Year:", input.ResumeYear);
                AppendLine("Riders:", "See Below");
                AppendLine("Riders #:", input.Riders.Count);

                foreach (var rider in input.Riders)
                {
                    FormatAndAppend(rider);
                }

                AppendLine("Column Data:", "See Below");
                AppendLine("Min Prem Guar:", input.MinimumPremiumGuaranteed);
                AppendLine("Initial Sc:", input.InitialSurrenderCharge);
                AppendLine("Back End Msg:", input.BackEndMessage);
                AppendLine("Curr Num Pay:", input.CurrentNumberOfPayments);
                AppendLine("Guar Num Pay:", input.GuaranteedNumberOfPayments);
                AppendLine("Second Guar Period End:", input.SecondGuaranteedPeriodEnd);

                var i = 0;
                foreach (var item in input.MiscellaneousValues)
                {
                    i++;
                    var label = string.Format("Misc {0}:", i);
                    AppendLine(label, item);
                }
            }

            FormatAndAppend(input.ColumnData, relevantFieldsOnly);

            var result = sb.ToString();
            sb = null;
            LabelLength = 0;

            return result;
        }

        private static void FormatAndAppend(RiderValue input)
        {
            AppendLine("Rider Age:", input.Age);
            AppendLine("Rider Amount:", input.Amount);
            AppendLine("Rider Amount2:", input.Amount2);
            AppendLine("Rider Annual Prem:", input.AnnualPremium);
            AppendLine("Rider Class:", input.Class);
            //Note that there is no column in the label.
            AppendLine("Rider Insured", input.Insured);
            AppendLine("Rider Iss Age:", input.IssueAge);
            AppendLine("Rider Level:", input.Level);

            var i = 0;
            foreach (var item in input.MiscellaneousValues)
            {
                i++;
                var label = string.Format("Rider Misc{0}:", i);
                AppendLine(label, item);
            }

            AppendLine("Rider Name:", input.Name);
            AppendLine("Rider Rating Extra:", input.RatingExtra);
            AppendLine("Rider Rating Extra To Age:", input.RatingExtraToAge);
            AppendLine("Rider Rating Table:", input.RatingTable);
            AppendLine("Rider Rating Table To Age:", input.RatingTableToAge);
            AppendLine("Rider Rider Code:", input.RiderCode);
            AppendLine("Rider Sex:", input.Sex);
            AppendLine("Rider To Age:", input.ToAge);
            AppendLine("Rider Toggle:", input.Toggle);
        }

        private static void FormatAndAppend(SortedList<ColumnDataEnum, IList<decimal>> columnData, bool relevantFieldsOnly)
        {
            sb.AppendLine("*** Column Data ***");
            foreach (var columnPair in columnData)
            {
                if (!relevantFieldsOnly || Enum.IsDefined(typeof(ColumnDataEnum), columnPair.Key))
                {
                    sb.Append((int)columnPair.Key);
                    foreach (var multivalue in columnPair.Value)
                    {
                        sb.AppendFormat(",{0}", multivalue);
                    }
                    sb.AppendLine();
                }
            }
        }

        private static void AppendLine(string label, object value)
        {
            var paddedLabel = label.PadRight(LabelLength);
            sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0}{1}", paddedLabel, value));
        }
    }
}
