using System;
using System.Collections.Generic;
using System.Globalization;
using WOW.Illustration.ValuesModel;

namespace WOW.Illustration.Utilities.ValuesOutputComparer
{
    public class FileComparer
    {

        public class ComparisonArguments
        {
            public decimal DecimalTolerance { get; set; }
            public bool RelevantValuesOnly { get; set; }
            public bool ExcludeLastColumnErrors { get; set; }
            public Enums.ProductType ProductType { get; set; }
        }

        public List<DifferencePair> Diffs { get; private set; }

        private ComparisonArguments Args;

        private FileComparer(ComparisonArguments args)
        {
            Diffs = new List<DifferencePair>();
            Args = args;
        }

        public static List<DifferencePair> Compare(IllustrationValue iewModel, IllustrationValue lpaModel, ComparisonArguments args)
        {
            FileComparer fileComparer = new FileComparer(args);
            if (!args.RelevantValuesOnly)
            {
                fileComparer.Compare(iewModel.AssumedInterestRate, lpaModel.AssumedInterestRate, "AssumedInterestRate");
                fileComparer.Compare(iewModel.AssumedLapseMonth, lpaModel.AssumedLapseMonth, "AssumedLapseMonth");
                fileComparer.Compare(iewModel.AssumedLapseYear, lpaModel.AssumedLapseYear, "AssumedLapseYear");
                fileComparer.Compare(iewModel.AssumedLapseYearMortality, lpaModel.AssumedLapseYearMortality, "AssumedLapseYearMortality");
                fileComparer.Compare(iewModel.AssumedNetPay10, lpaModel.AssumedNetPay10, "AssumedNetPay10");
                fileComparer.Compare(iewModel.AssumedNetPay10Mortality, lpaModel.AssumedNetPay10Mortality, "AssumedNetPay10Mortality");
                fileComparer.Compare(iewModel.AssumedNetPay20, lpaModel.AssumedNetPay20, "AssumedNetPay20");
                fileComparer.Compare(iewModel.AssumedNetPay20Mortality, lpaModel.AssumedNetPay20Mortality, "AssumedNetPay20Mortality");
                fileComparer.Compare(iewModel.AssumedNetPay5, lpaModel.AssumedNetPay5, "AssumedNetPay5");
                fileComparer.Compare(iewModel.AssumedNetPay5Mortality, lpaModel.AssumedNetPay5Mortality, "AssumedNetPay5Mortality");
                fileComparer.Compare(iewModel.AssumedSurrenderCost10, lpaModel.AssumedSurrenderCost10, "AssumedSurrenderCost10");
                fileComparer.Compare(iewModel.AssumedSurrenderCost10Mortality, lpaModel.AssumedSurrenderCost10Mortality, "AssumedSurrenderCost10Mortality");
                fileComparer.Compare(iewModel.AssumedSurrenderCost20, lpaModel.AssumedSurrenderCost20, "AssumedSurrenderCost20");
                fileComparer.Compare(iewModel.AssumedSurrenderCost20Mortality, lpaModel.AssumedSurrenderCost20Mortality, "AssumedSurrenderCost20Mortality");
                fileComparer.Compare(iewModel.AssumedSurrenderCost5, lpaModel.AssumedSurrenderCost5, "AssumedSurrenderCost5");
                fileComparer.Compare(iewModel.AssumedSurrenderCost5Mortality, lpaModel.AssumedSurrenderCost5Mortality, "AssumedSurrenderCost5Mortality");
                fileComparer.Compare(iewModel.CurrentInterestRate, lpaModel.CurrentInterestRate, "CurrentInterestRate");
                fileComparer.Compare(iewModel.CurrentLapseYearMortality, lpaModel.CurrentLapseYearMortality, "CurrentLapseYearMortality");
                fileComparer.Compare(iewModel.CurrentNetPay10, lpaModel.CurrentNetPay10, "CurrentNetPay10");
                fileComparer.Compare(iewModel.CurrentNetPay10Mortality, lpaModel.CurrentNetPay10Mortality, "CurrentNetPay10Mortality");
                fileComparer.Compare(iewModel.CurrentNetPay20, lpaModel.CurrentNetPay20, "CurrentNetPay20");
                fileComparer.Compare(iewModel.CurrentNetPay20Mortality, lpaModel.CurrentNetPay20Mortality, "CurrentNetPay20Mortality");
                fileComparer.Compare(iewModel.CurrentNetPay5, lpaModel.CurrentNetPay5, "CurrentNetPay5");
                fileComparer.Compare(iewModel.CurrentNetPay5Mortality, lpaModel.CurrentNetPay5Mortality, "CurrentNetPay5Mortality");
                fileComparer.Compare(iewModel.CurrentSettleRate, lpaModel.CurrentSettleRate, "CurrentSettleRate");
                fileComparer.Compare(iewModel.CurrentSurrenderCost10Mortality, lpaModel.CurrentSurrenderCost10Mortality, "CurrentSurrenderCost10Mortality");
                fileComparer.Compare(iewModel.CurrentSurrenderCost20Mortality, lpaModel.CurrentSurrenderCost20Mortality, "CurrentSurrenderCost20Mortality");
                fileComparer.Compare(iewModel.CurrentSurrenderCost5, lpaModel.CurrentSurrenderCost5, "CurrentSurrenderCost5");
                fileComparer.Compare(iewModel.CurrentSurrenderCost5Mortality, lpaModel.CurrentSurrenderCost5Mortality, "CurrentSurrenderCost5Mortality");
                fileComparer.Compare(iewModel.GuaranteedInterestRate, lpaModel.GuaranteedInterestRate, "GuaranteedInterestRate");
                fileComparer.Compare(iewModel.GuaranteedLapseYearMortality, lpaModel.GuaranteedLapseYearMortality, "GuaranteedLapseYearMortality");
                fileComparer.Compare(iewModel.GuaranteedNetPay10, lpaModel.GuaranteedNetPay10, "GuaranteedNetPay10");
                fileComparer.Compare(iewModel.GuaranteedNetPay10Mortality, lpaModel.GuaranteedNetPay10Mortality, "GuaranteedNetPay10Mortality");
                fileComparer.Compare(iewModel.GuaranteedNetPay20, lpaModel.GuaranteedNetPay20, "GuaranteedNetPay20");
                fileComparer.Compare(iewModel.GuaranteedNetPay20Mortality, lpaModel.GuaranteedNetPay20Mortality, "GuaranteedNetPay20Mortality");
                fileComparer.Compare(iewModel.GuaranteedNetPay5, lpaModel.GuaranteedNetPay5, "GuaranteedNetPay5");
                fileComparer.Compare(iewModel.GuaranteedNetPay5Mortality, lpaModel.GuaranteedNetPay5Mortality, "GuaranteedNetPay5Mortality");
                fileComparer.Compare(iewModel.GuaranteedSettleRate, lpaModel.GuaranteedSettleRate, "GuaranteedSettleRate");
                fileComparer.Compare(iewModel.GuaranteedSurrenderCost10, lpaModel.GuaranteedSurrenderCost10, "GuaranteedSurrenderCost10");
                fileComparer.Compare(iewModel.GuaranteedSurrenderCost10Mortality, lpaModel.GuaranteedSurrenderCost10Mortality, "GuaranteedSurrenderCost10Mortality");
                fileComparer.Compare(iewModel.GuaranteedSurrenderCost20, lpaModel.GuaranteedSurrenderCost20, "GuaranteedSurrenderCost20");
                fileComparer.Compare(iewModel.GuaranteedSurrenderCost20Mortality, lpaModel.GuaranteedSurrenderCost20Mortality, "GuaranteedSurrenderCost20Mortality");
                fileComparer.Compare(iewModel.GuaranteedSurrenderCost5, lpaModel.GuaranteedSurrenderCost5, "GuaranteedSurrenderCost5");
                fileComparer.Compare(iewModel.GuaranteedSurrenderCost5Mortality, lpaModel.GuaranteedSurrenderCost5Mortality, "GuaranteedSurrenderCost5Mortality");
                fileComparer.Compare(iewModel.InitialDeathBenefit, lpaModel.InitialDeathBenefit, "InitialDeathBenefit");
                fileComparer.Compare(iewModel.InitialSurrenderCharge, lpaModel.InitialSurrenderCharge, "InitialSurrenderCharge");
                fileComparer.Compare(iewModel.LifeContingent, lpaModel.LifeContingent, "LifeContingent");
                fileComparer.Compare(iewModel.Lump1035Amount, lpaModel.Lump1035Amount, "Lump1035Amount");
                fileComparer.Compare(iewModel.LumpSumAmount, lpaModel.LumpSumAmount, "LumpSumAmount");
                fileComparer.Compare(iewModel.MinimumPremium, lpaModel.MinimumPremium, "MinimumPremium");
                fileComparer.Compare(iewModel.MinimumPremiumGuaranteed, lpaModel.MinimumPremiumGuaranteed, "MinimumPremiumGuaranteed");
                fileComparer.Compare(iewModel.BackEndMessage, lpaModel.BackEndMessage, "BackEndMessage");
                fileComparer.Compare(iewModel.CurrentNumberOfPayments, lpaModel.CurrentNumberOfPayments, "CurrentNumberOfPayments");
                fileComparer.Compare(iewModel.GuaranteedNumberOfPayments, lpaModel.GuaranteedNumberOfPayments, "GuaranteedNumberOfPayments");
                //fileComparer.Compare(value1.GenerationDate, value2.GenerationDate, "GenerationDate");
                fileComparer.Compare(iewModel.MiscellaneousValues, lpaModel.MiscellaneousValues, "Miscellaneous Values");
            }

            fileComparer.Compare(iewModel.CurrentLapseMonth, lpaModel.CurrentLapseMonth, "Current Lapse Month");
            fileComparer.Compare(iewModel.CurrentLapseYear, lpaModel.CurrentLapseYear, "Current Lapse Year");
            fileComparer.Compare(iewModel.CurrentSurrenderCost10, lpaModel.CurrentSurrenderCost10, "Current Surrender Cost 10");
            fileComparer.Compare(iewModel.CurrentSurrenderCost20, lpaModel.CurrentSurrenderCost20, "Current Surrender Cost 20");
            fileComparer.Compare(iewModel.GuaranteedLapseMonth, lpaModel.GuaranteedLapseMonth, "Guaranteed Lapse Month");
            fileComparer.Compare(iewModel.GuaranteedLapseYear, lpaModel.GuaranteedLapseYear, "Guaranteed Lapse Year");
            fileComparer.Compare(iewModel.ZeroPremiumLapseMonth, lpaModel.ZeroPremiumLapseMonth, "Zero Premium Lapse Month");
            fileComparer.Compare(iewModel.ZeroPremiumLapseYear, lpaModel.ZeroPremiumLapseYear, "Zero Premium Lapse Year");

            if (args.RelevantValuesOnly)
            {
                var count = iewModel.MiscellaneousValues.Count;
                if (count > 3)
                {
                    var temp = iewModel.MiscellaneousValues[3];
                    iewModel.MiscellaneousValues.Clear();
                    if (!string.IsNullOrWhiteSpace(temp)) iewModel.MiscellaneousValues.Add(temp);
                }

                count = lpaModel.MiscellaneousValues.Count;
                if (count > 3)
                {
                    var temp = lpaModel.MiscellaneousValues[3];
                    lpaModel.MiscellaneousValues.Clear();
                    if (!string.IsNullOrWhiteSpace(temp)) lpaModel.MiscellaneousValues.Add(temp);
                }

                fileComparer.Compare(iewModel.MiscellaneousValues, lpaModel.MiscellaneousValues, "Miscellaneous Values");
                switch (args.ProductType)
                {
                    case WOW.Illustration.Utilities.ValuesOutputComparer.Enums.ProductType.NoLapse:
                        fileComparer.CompareUL(iewModel.ColumnData, lpaModel.ColumnData, "Column Data");
                        break;
                    case WOW.Illustration.Utilities.ValuesOutputComparer.Enums.ProductType.AccumulatedUniversalLife:
                        fileComparer.CompareUL(iewModel.ColumnData, lpaModel.ColumnData, "Column Data");
                        break;
                    case WOW.Illustration.Utilities.ValuesOutputComparer.Enums.ProductType.WholeLife:
                        fileComparer.CompareWholeLife(iewModel.ColumnData, lpaModel.ColumnData, "Column Data");
                        break;
                    case WOW.Illustration.Utilities.ValuesOutputComparer.Enums.ProductType.Red:
                        fileComparer.CompareRed(iewModel.ColumnData, lpaModel.ColumnData, "Column Data");
                        break;
                    case WOW.Illustration.Utilities.ValuesOutputComparer.Enums.ProductType.Term:
                        fileComparer.CompareTerm(iewModel.ColumnData, lpaModel.ColumnData, "Column Data");
                        break;
                    case WOW.Illustration.Utilities.ValuesOutputComparer.Enums.ProductType.FamilyTerm:
                        fileComparer.CompareTerm(iewModel.ColumnData, lpaModel.ColumnData, "Column Data");
                        break;
                    case WOW.Illustration.Utilities.ValuesOutputComparer.Enums.ProductType.YouthTerm:
                        // No column data compared.
                        break;
                    case WOW.Illustration.Utilities.ValuesOutputComparer.Enums.ProductType.FixedAnnuity:
                        fileComparer.CompareAnnuity(iewModel.ColumnData, lpaModel.ColumnData, "Column Data");
                        break;
                    default:
                        fileComparer.Compare(iewModel.ColumnData, lpaModel.ColumnData, "Column Data");
                        break;
                }

                fileComparer.CompareColumn(iewModel.ColumnData, lpaModel.ColumnData, "Column Data", ColumnDataEnum.CurrentBasis);
                fileComparer.CompareColumn(iewModel.ColumnData, lpaModel.ColumnData, "Column Data", ColumnDataEnum.GuaranteedDeathBenefit);
                fileComparer.CompareColumn(iewModel.ColumnData, lpaModel.ColumnData, "Column Data", ColumnDataEnum.GuaranteedSettlementOptionIncome);
            }
            else
            {
                fileComparer.Compare(iewModel.ColumnData, lpaModel.ColumnData, "Column Data");
            }

            return fileComparer.Diffs;
        }

        private void AddDiff(object iewValue, object lpaValue, string name)
        {
            var diff = new DifferencePair(name, iewValue.ToString(), lpaValue.ToString());

            Diffs.Add(diff);
        }

        private void Compare(DateTime iewValue, DateTime lpaValue, string name)
        {
            if (!DateTime.Equals(iewValue, lpaValue))
            {
                AddDiff(iewValue, lpaValue, name);
            }
        }

        private void Compare(decimal iewValue, decimal lpaValue, string name)
        {
            if (!IsEqual(iewValue, lpaValue))
            {
                AddDiff(iewValue, lpaValue, name);
            }
        }

        private void Compare(IList<string> iewValue, IList<string> lpaValue, string name)
        {
            int index = 0;

            foreach (var item1 in iewValue)
            {
                var label = string.Format(CultureInfo.CurrentUICulture, "Misc {0}", index + 1);
                if (iewValue.Count == 1) label = "Misc 4";

                if (index < lpaValue.Count)
                {
                    var item2 = lpaValue[index];
                    ++index;
                    Compare(item1, item2, label);
                }
                else
                {
                    ++index;
                    AddDiff(item1, string.Empty, label);
                }
            }

            while (index < lpaValue.Count)
            {
                var label = string.Format(CultureInfo.CurrentUICulture, "Misc {0}", index + 1);
                if (lpaValue.Count == 1) label = "Misc 4";

                var item2 = lpaValue[index];
                ++index;
                AddDiff(string.Empty, item2, label);
            }
        }

        private void Compare(int iewValue, int value2, string name)
        {
            if (iewValue != value2)
            {
                AddDiff(iewValue, value2, name);
            }
        }

        private void CompareAnnuity(SortedList<ColumnDataEnum, IList<decimal>> iewValue, SortedList<ColumnDataEnum, IList<decimal>> lpaValue, string name)
        {
            var key = ColumnDataEnum.GuaranteedNetSurrenderValuePremium;
            CompareColumn(iewValue, lpaValue, name, key);

            key = ColumnDataEnum.GuaranteedNetSurrenderValueRollover;
            CompareColumn(iewValue, lpaValue, name, key);

            key = ColumnDataEnum.NonGuaranteedNetSurrenderValuePremium;
            CompareColumn(iewValue, lpaValue, name, key);

            key = ColumnDataEnum.NonGuaranteedNetSurrenderValueRollover;
            CompareColumn(iewValue, lpaValue, name, key);

            key = ColumnDataEnum.GuaranteedAccountValue;
            CompareColumn(iewValue, lpaValue, name, key);

            //key = ColumnDataEnum.CurrentBasis;
            //CompareColumn(iewValue, lpaValue, name, key);

            key = ColumnDataEnum.GuaranteedNetAccountValue;
            CompareColumn(iewValue, lpaValue, name, key);
        }

        private void CompareRed(SortedList<ColumnDataEnum, IList<decimal>> iewValue, SortedList<ColumnDataEnum, IList<decimal>> lpaValue, string name)
        {
            var key = ColumnDataEnum.GuaranteedAccountValue;
            CompareColumn(iewValue, lpaValue, name, key);

            key = ColumnDataEnum.GuaranteedReducedPaidUp;
            CompareColumn(iewValue, lpaValue, name, key);

            key = ColumnDataEnum.GuaranteedDeathBenefitCB;
            CompareColumn(iewValue, lpaValue, name, key);

            key = ColumnDataEnum.ExtendedTermInsuranceDays;
            CompareColumn(iewValue, lpaValue, name, key);

            key = ColumnDataEnum.ExtendedTermInsuranceYears;
            CompareColumn(iewValue, lpaValue, name, key);
        }

        private void CompareTerm(SortedList<ColumnDataEnum, IList<decimal>> iewValue, SortedList<ColumnDataEnum, IList<decimal>> lpaValue, string name)
        {
            var key = ColumnDataEnum.GuaranteedAcceleratedDeathBenefitPremiumCB;
            CompareColumn(iewValue, lpaValue, name, key);

            key = ColumnDataEnum.GuaranteedWaiverOfPremiumCB;
            CompareColumn(iewValue, lpaValue, name, key);

            key = ColumnDataEnum.GuaranteedTotalPremiumCB;
            CompareColumn(iewValue, lpaValue, name, key);

            key = ColumnDataEnum.GuaranteedCashOutlay;
            CompareColumn(iewValue, lpaValue, name, key);

            key = ColumnDataEnum.CurrentBasePremiumCB;
            CompareColumn(iewValue, lpaValue, name, key);

            key = ColumnDataEnum.GuaranteedBasePremiumCB;
            CompareColumn(iewValue, lpaValue, name, key);

            key = ColumnDataEnum.GuaranteedOtherInsuredPremiumsCB;
            CompareColumn(iewValue, lpaValue, name, key);

            key = ColumnDataEnum.CurrentCashOutlay;
            CompareColumn(iewValue, lpaValue, name, key);
        }

        private void CompareUL(SortedList<ColumnDataEnum, IList<decimal>> iewValue, SortedList<ColumnDataEnum, IList<decimal>> lpaValue, string name)
        {
            var key = ColumnDataEnum.SurrenderChargeRate;
            CompareColumn(iewValue, lpaValue, name, key);

            key = ColumnDataEnum.WaiverOfPremiumRate;
            CompareColumn(iewValue, lpaValue, name, key);

            key = ColumnDataEnum.GuaranteedModalPremium;
            CompareColumn(iewValue, lpaValue, name, key);

            if (Args.ProductType == Enums.ProductType.AccumulatedUniversalLife)
            {
                key = ColumnDataEnum.AulGuaranteedCostOfInsuranceRate;
                CompareColumn(iewValue, lpaValue, name, key);

                key = ColumnDataEnum.GuaranteedDeathBenefitFactor;
                CompareColumn(iewValue, lpaValue, name, key);

                key = ColumnDataEnum.CumulativePremium;
                CompareColumn(iewValue, lpaValue, name, key);
            }
            else
            {
                key = ColumnDataEnum.NlgulGuaranteedCostOfInsuranceRate;
                CompareColumn(iewValue, lpaValue, name, key);

                key = ColumnDataEnum.CumulativePremium;
                CompareColumn(iewValue, lpaValue, name, key);
            }
        }

        private void CompareWholeLife(SortedList<ColumnDataEnum, IList<decimal>> iewValue, SortedList<ColumnDataEnum, IList<decimal>> lpaValue, string name)
        {
            var key = ColumnDataEnum.GuaranteedAccountValue;
            CompareColumn(iewValue, lpaValue, name, key);

            // Really only needed for Change Packages.
            key = ColumnDataEnum.GuaranteedNetPaymentOtherInsuredCB;
            CompareColumn(iewValue, lpaValue, name, key);

            key = ColumnDataEnum.GuaranteedReducedPaidUp;
            CompareColumn(iewValue, lpaValue, name, key);

            key = ColumnDataEnum.ExtendedTermInsuranceYears;
            CompareColumn(iewValue, lpaValue, name, key);

            key = ColumnDataEnum.ExtendedTermInsuranceDays;
            CompareColumn(iewValue, lpaValue, name, key);
        }

        private void CompareColumn(SortedList<ColumnDataEnum, IList<decimal>> iewColumnList, SortedList<ColumnDataEnum, IList<decimal>> lpaColumnList, string name, ColumnDataEnum key)
        {
            if (iewColumnList.ContainsKey(key) && lpaColumnList.ContainsKey(key))
            {
                IList<decimal> iewColumn = iewColumnList[key];
                IList<decimal> lpaColumn = lpaColumnList[key];
                var shortCircuit = false;
                var index = 0;

                foreach (var iewValue in iewColumn)
                {
                    if (index < lpaColumn.Count)
                    {
                        var lpaValue = lpaColumn[index];
                        ++index;
                        if (!IsEqual(iewValue, lpaValue))
                        {
                            var label = string.Format(CultureInfo.CurrentUICulture, "{0} {1}-{2} ({3})", name, (int)key, key, index);
                            AddDiff(iewValue, lpaValue, label);
                            shortCircuit = true;
                            break;
                        }
                    }
                    else
                    {
                        ++index;
                        var label = string.Format(CultureInfo.CurrentUICulture, "{0} {1}-{2} ({3})", name, (int)key, key, index);
                        AddDiff(iewValue, string.Empty, label);
                        shortCircuit = true;
                        break;
                    }
                }

                if (index < lpaColumn.Count && !shortCircuit)
                {
                    if (!Args.ExcludeLastColumnErrors)
                    {
                        var lpaValue = lpaColumn[index];
                        index++;
                        var label = string.Format(CultureInfo.CurrentUICulture, "{0} {1}-{2} ({3})", name, (int)key, key, index);
                        AddDiff(string.Empty, lpaValue, label);
                    }
                }
            }
            else if (iewColumnList.ContainsKey(key) || lpaColumnList.ContainsKey(key))
            {
                var label = string.Format(CultureInfo.CurrentUICulture, "{0} {1}-{2} ({3})", name, (int)key, key, 0);
                if (iewColumnList.ContainsKey(key))
                {
                    AddDiff(iewColumnList[key][0], string.Empty, label);
                }
                else
                {
                    AddDiff(string.Empty, lpaColumnList[key][0], label);
                }
            }
        }

        private void Compare(SortedList<ColumnDataEnum, IList<decimal>> iewValue, SortedList<ColumnDataEnum, IList<decimal>> lpaValue, string name)
        {
            foreach (ColumnDataEnum key in Enum.GetValues(typeof(ColumnDataEnum)))
            {
                CompareColumn(iewValue, lpaValue, name, key);
            }
        }

        private void Compare(string iewValue, string lpaValue, string name)
        {
            if (!string.Equals(iewValue, lpaValue))
            {
                AddDiff(iewValue, lpaValue, name);
            }
        }

        private bool IsEqual(decimal iewValue, decimal lpaValue)
        {
            var diff = Math.Abs(iewValue - lpaValue);
            return Args.DecimalTolerance > diff;
        }
    }
}
