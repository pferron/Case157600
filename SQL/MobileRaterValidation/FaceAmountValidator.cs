using log4net;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WOW.Illustration.MobileRaterValidation
{
    internal class FaceAmountValidator
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(FaceAmountValidator));

        // Look for numerics that are either preceded by "(" and zero or more spaces or followed by zero or more spaces and ")"
        // Ex. (25000, 99999), (100000, 2000000000) 
        // Use look behind "?<=" and look ahead "?=" to exclude the parens and spaces from the matches.
        private static readonly Regex regexPairs = new Regex(@"(?<=\(\s*)(\d+)|(\d+)(?=\s*\))");

        // Look for the literal string
        private static readonly Regex regexTable = new Regex("FaceAmountTable", RegexOptions.IgnoreCase);

        // Look for numerics that are either preceded by "MinFaceAmount", zero or more spaces, and one or more of either "=" or ">"
        // or preceded by "MaxFaceAmount", zero or more spaces, and one or more of either "<" or "=".
        // Ex. and (MinFaceAmount >= 25000 and MaxFaceAmount <= 99999)
        // Use look behind "?<=" and look ahead "?=" to exclude the text, symbols, and spaces from the matches.
        private static readonly Regex regexWhere = new Regex(@"(?<=MinFaceAmount\s*[=>]+\s*)(\d+)|(?<=MaxFaceAmount\s*[<=]+\s*)(\d+)", RegexOptions.IgnoreCase);

        private List<int> minFaceAmounts;
        private List<int> maxFaceAmounts;
        private List<int> usedFaceAmountMins;
        private List<int> usedFaceAmountMaxs;
        private bool hasFixedFaceAmounts;
        private bool foundStartOfValues;
        private string file;


        public FaceAmountValidator(string file)
        {
            this.file = file;
        }

        internal void Initialize()
        {
            minFaceAmounts = new List<int>();
            maxFaceAmounts = new List<int>();
            usedFaceAmountMins = new List<int>();
            usedFaceAmountMaxs = new List<int>();
            hasFixedFaceAmounts = true;
            foundStartOfValues = false;
        }

        internal void ProcessLine(string line)
        {
            if (!foundStartOfValues)
            {
                if (IsStartOfValuesSection(line))
                {
                    foundStartOfValues = true;
                    LoadValues(line);
                }
            }
            else if (IsWhereLine(line))
            {
                ValidateWhere(line);
            }
        }

        private static bool IsStartOfValuesSection(string line)
        {
            return regexTable.IsMatch(line);
        }

        private static bool IsWhereLine(string line)
        {
            return regexWhere.IsMatch(line);
        }

        private void LoadValues(string line)
        {
            var matches = regexPairs.Matches(line);
            var isMin = true;
            int? lastMin = null;
            int? lastMax = null;
            foreach (Match match in matches)
            {
                var value = int.Parse(match.Value);
                if (isMin)
                {
                    if (lastMin.HasValue && lastMin > value)
                    {
                        log.Warn($"File: {file} has a face amount out of order. LastMin: {lastMin} CurrentMin: {value}");
                    }

                    if (!hasFixedFaceAmounts && lastMax.HasValue && lastMax + 1 != value)
                    {
                        log.Warn($"File: {file} has a face amount out of order. LastMax: {lastMax} CurrentMin: {value}");
                    }

                    lastMin = value;
                    minFaceAmounts.Add(value);
                    isMin = false;
                }
                else
                {
                    if (lastMax.HasValue && lastMax > value)
                    {
                        log.Warn($"File: {file} has a face amount out of order. LastMax: {lastMax} CurrentMax: {value}");
                    }

                    if (lastMin.HasValue && lastMin > value)
                    {
                        log.Warn($"File: {file} has a face amount out of order. LastMax: {lastMax} CurrentMax: {value}");
                    }

                    hasFixedFaceAmounts = hasFixedFaceAmounts && value == lastMin;

                    lastMax = value;
                    maxFaceAmounts.Add(value);
                    isMin = true;
                }
            }
        }

        private void ValidateWhere(string line)
        {
            var matches = regexWhere.Matches(line);
            if (matches.Count != 2)
            {
                log.Warn($"File: {file} has missing FaceAmount {line}");
            }
            else
            {
                var min = int.Parse(matches[0].Value);
                var max = int.Parse(matches[1].Value);

                if (!minFaceAmounts.Contains(min))
                {
                    log.Warn($"File: {file} has missing min FaceAmount {line}");
                }
                else
                {
                    if (!usedFaceAmountMins.Contains(min)) usedFaceAmountMins.Add(min);
                }

                if (!maxFaceAmounts.Contains(max))
                {
                    log.Warn($"File: {file} has missing max FaceAmount {line}");
                }
                else
                {
                    if (!usedFaceAmountMaxs.Contains(max)) usedFaceAmountMaxs.Add(max);
                }
            }
        }

        internal void CheckForUnusedValues()
        {
            // Don't bother checking the fixed levels for usage.
            if (!hasFixedFaceAmounts)
            {
                if (minFaceAmounts.Count > 0) minFaceAmounts.RemoveAt(0); // Remove first minimum
                if (maxFaceAmounts.Count > 0) maxFaceAmounts.RemoveAt(maxFaceAmounts.Count - 1); // Remove last maximum

                usedFaceAmountMins.ForEach(a => { minFaceAmounts.Remove(a); maxFaceAmounts.Remove(a - 1); });
                usedFaceAmountMaxs.ForEach(a => { maxFaceAmounts.Remove(a); minFaceAmounts.Remove(a + 1); });

                if (minFaceAmounts.Count > 0)
                {
                    minFaceAmounts.ForEach(a => log.Warn($"File: {file} has unused min FaceAmount {a}"));
                }

                if (maxFaceAmounts.Count > 0)
                {
                    maxFaceAmounts.ForEach(a => log.Warn($"File: {file} has unused max FaceAmount {a}"));
                }
            }
        }
    }
}
