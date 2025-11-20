using log4net;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WOW.Illustration.MobileRaterValidation
{
    internal class InsuredAgeValidator
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(InsuredAgeValidator));

        // Look for numerics that are either preceded by "(" and zero or more spaces or followed by zero or more spaces and ")"
        // Ex. (0, 15), (16, 17), (18, 37), (38, 55), (56, 64), (65, 65), (66, 69), (70, 74), (75, 79), (80, 80))
        // Use look behind "?<=" and look ahead "?=" to exclude the parens and spaces from the matches.
        private static readonly Regex regexPairs = new Regex(@"(?<=\(\s*)(\d+)|(\d+)(?=\s*\))");

        // Look for the literal string
        private static readonly Regex regexTable = new Regex("InsuredAgeTable", RegexOptions.IgnoreCase);

        // Look for numerics that are either preceded by "MinInsuredAge", zero or more spaces, and one or more of either "=" or ">"
        // or preceded by "MaxInsuredAge", zero or more spaces, and one or more of either "<" or "=".
        // Ex.     or ((MinInsuredAge >= 0 and MaxInsuredAge <= 65)
        // Use look behind "?<=" and look ahead "?=" to exclude the text, symbols, and spaces from the matches.
        private static readonly Regex regexWhere = new Regex(@"(?<=MinInsuredAge\s*[=>]+\s*)(\d+)|(?<=MaxInsuredAge\s*[<=]+\s*)(\d+)", RegexOptions.IgnoreCase);

        private List<int> minAges;
        private List<int> maxAges;
        private List<int> usedAgeMins;
        private List<int> usedAgeMaxs;
        private bool foundStartOfValues;
        private string file;

        public InsuredAgeValidator(string file)
        {
            this.file = file;
        }

        internal void Initialize()
        {
            minAges = new List<int>();
            maxAges = new List<int>();
            usedAgeMins = new List<int>();
            usedAgeMaxs = new List<int>();
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
                        log.Warn($"File: {file} has an age out of order. LastMin: {lastMin} CurrentMin: {value}");
                    }

                    if (lastMax.HasValue && lastMax + 1 != value)
                    {
                        log.Warn($"File: {file} has an age out of order. LastMax: {lastMax} CurrentMin: {value}");
                    }

                    lastMin = value;
                    minAges.Add(value);
                    isMin = false;
                }
                else
                {
                    if (lastMax.HasValue && lastMax > value)
                    {
                        log.Warn($"File: {file} has an age out of order. LastMax: {lastMax} CurrentMax: {value}");
                    }

                    if (lastMin.HasValue && lastMin > value)
                    {
                        log.Warn($"File: {file} has an age out of order. LastMax: {lastMax} CurrentMax: {value}");
                    }

                    lastMax = value;
                    maxAges.Add(value);
                    isMin = true;
                }
            }
        }

        private void ValidateWhere(string line)
        {
            var matches = regexWhere.Matches(line);
            if (matches.Count != 2)
            {
                log.Warn($"File: {file} has missing age {line}");
            }
            else
            {
                var min = int.Parse(matches[0].Value);
                var max = int.Parse(matches[1].Value);

                if (!minAges.Contains(min))
                {
                    log.Warn($"File: {file} has missing min age {line}");
                }
                else
                {
                    if (!usedAgeMins.Contains(min)) usedAgeMins.Add(min);
                }

                if (!maxAges.Contains(max))
                {
                    log.Warn($"File: {file} has missing max age {line}");
                }
                else
                {
                    if (!usedAgeMaxs.Contains(max)) usedAgeMaxs.Add(max);
                }
            }
        }

        internal void CheckForUnusedValues()
        {
            if (minAges.Count > 0) minAges.RemoveAt(0); // Remove first minimum
            if (maxAges.Count > 0) maxAges.RemoveAt(maxAges.Count - 1); // Remove last maximum

            usedAgeMins.ForEach(a => { minAges.Remove(a); maxAges.Remove(a - 1); });
            usedAgeMaxs.ForEach(a => { maxAges.Remove(a); minAges.Remove(a + 1); });

            if (minAges.Count > 0)
            {
                minAges.ForEach(a => log.Warn($"File: {file} has unused min age {a}"));
            }

            if (maxAges.Count > 0)
            {
                maxAges.ForEach(a => log.Warn($"File: {file} has unused max age {a}"));
            }
        }
    }
}
