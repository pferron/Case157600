using log4net;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WOW.Illustration.MobileRaterValidation
{
    internal class RatingClassValidator
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(RatingClassValidator));

        // The rating class intervals span multiple lines so they need to be parsed piecewise.

        //  select MinRatingClass, MaxRatingClass
        //  from ( values (-2, -2, 'Super'), (-1, -1, 'Preferred'), (0, 1, 'Standard to Table 1'), (2, 2, 'Table 2'), (3, 3, 'Table 3'), (4, 4, 'Table 4'), 
        //      (5, 5, 'Table 5'), (6, 6, 'Table 6'), (7, 7, 'Table 7'), (8, 8, 'Table 8'), (9, 10, 'Table 9 & 10'), (11, 12, 'Table 11 & 12'), 
        //      (13, 14, 'Table 13 & 14'), (15, 16, 'Table 15 & 16')) 
        //      as RatingClassTable(MinRatingClass, MaxRatingClass, [Description])) vRating

        // Ex. select MinRatingClass, MaxRatingClass
        private static readonly Regex regexTableStart = new Regex(@"select\s*MinRatingClass\s*,\s*MaxRatingClass", RegexOptions.IgnoreCase);

        // Look for numerics (may be negative) that are either preceded by "(" and zero or more spaces
        // or preceded by a comma and zero more spaces and also followed by zero or more spaces and a comma.
        // Ex. from ( values (-2, -2, 'Super'), (-1, -1, 'Preferred'), (0, 1, 'Standard to Table 1'), (2, 2, 'Table 2'), (3, 3, 'Table 3'), (4, 4, 'Table 4'), 
        // Use look behind "?<=" and look ahead "?=" to exclude the commas and spaces from the matches.
        private static readonly Regex regexPairs = new Regex(@"(?<=\(\s*)(-?\d+)|(?<=,\s*)(-?\d+)(?=\s*,)");

        // Look for the literal string
        private static readonly Regex regexTableEnd = new Regex("RatingClassTable", RegexOptions.IgnoreCase);

        // The where clauses can be in two formats:
        // and ((MinInsuredAge >= 18 and MaxInsuredAge <= 60 and MinRatingClass >= -2 and MaxRatingClass <= 8) 

        // or

        //  and ((Gender = 'F' and MinRatingClass >= -2 and MaxRatingClass <= 
        //              case 
        //                  when MinInsuredAge >= 0 and MaxInsuredAge <= 69  then 16
        //                  when MinInsuredAge >= 70 and MaxInsuredAge <= 74 then 12
        //                  when MinInsuredAge >= 75 and MaxInsuredAge <= 79 then 8
        //                  when MinInsuredAge >= 80 and MaxInsuredAge <= 80 then 6
        //              end) 

        // Look for numerics (may be negative) or empty string (for case statement) that are either 
        // preceded by "MinRatingClass", zero or more spaces, one or more of either "=" or ">", and zero or more spaces
        // Ex. MinRatingClass >= -2
        // or preceded by "MaxRatingClass", zero or more spaces, one or more of either "<" or "=", and zero or more spaces
        // Ex. MaxRatingClass <= 8
        // or end of line preceded by "MaxRatingClass", zero or more spaces, one or more of either "<" or "=", and zero or more spaces
        // Ex. MaxRatingClass <= (EOL)
        // Use look behind "?<=" and look ahead "?=" to exclude the text, symbols, and spaces from the matches.
        private static readonly Regex regexWhere = new Regex(@"(?<=MinRatingClass\s*[=>]+\s*)(-?\d+)|(?<=MaxRatingClass\s*[<=]+\s*)(-?\d+)|(?<=MaxRatingClass\s*[<=]+\s*)$", RegexOptions.IgnoreCase);

        // Only used when processing a "Case" statement item.
        // Look for numerics that are proceded by zero or more spaces, "when ", and some other text ending with " then "
        // Ex. when MinInsuredAge >= 0 and MaxInsuredAge <= 69  then 16
        // Use look behind "?<=" to exclude the preceding text from the matches.
        private static readonly Regex regexWhereCaseItem = new Regex(@"(?<=\s*when .* then )(\d+)$", RegexOptions.IgnoreCase);

        // Only used when processing a "Case" statement item.
        // Look for the literal "end"
        private static readonly Regex regexWhereCaseEnd = new Regex(@"\s*end", RegexOptions.IgnoreCase);

        private List<int> minRatingClasses;
        private List<int> maxRatingClasses;
        private List<int> usedRatingClassMins;
        private List<int> usedRatingClassMaxs;
        private bool foundStartOfValues;
        private bool foundEndOfValues;
        private bool isFirstCaseLine;
        private bool inWhereCaseClause;
        private string file;

        public RatingClassValidator(string file)
        {
            this.file = file;
        }

        internal void Initialize()
        {
            minRatingClasses = new List<int>();
            maxRatingClasses = new List<int>();
            usedRatingClassMins = new List<int>();
            usedRatingClassMaxs = new List<int>();
            foundStartOfValues = false;
            foundEndOfValues = false;
            inWhereCaseClause = false;
            isFirstCaseLine = false;
        }

        internal void ProcessLine(string line)
        {
            if (!foundStartOfValues)
            {
                foundStartOfValues = IsStartOfValuesSection(line);
                // Move to the next line whether found or not.
                return;
            }

            if (!foundEndOfValues)
            {
                if (IsEndOfValuesSection(line))
                {
                    foundEndOfValues = true;
                    return;
                }

                LoadValues(line);
            }

            if (foundEndOfValues && (inWhereCaseClause || IsWhereLine(line)))
            {
                ValidateWhere(line);
            }
        }

        private static bool IsStartOfValuesSection(string line)
        {
            return regexTableStart.IsMatch(line);
        }

        private static bool IsWhereLine(string line)
        {
            return regexWhere.IsMatch(line);
        }

        private static bool IsEndOfValuesSection(string line)
        {
            return regexTableEnd.IsMatch(line);
        }

        private void LoadValues(string line)
        {
            var matches = regexPairs.Matches(line);
            if (matches.Count == 0)
            {
                log.Warn($"File: {file} has an unexpected RatingClass line: {line}");
            }

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
                        log.Warn($"File: {file} has a RatingClass out of order. LastMin: {lastMin} CurrentMin: {value}");
                    }

                    if (lastMax.HasValue && lastMax + 1 != value)
                    {
                        log.Warn($"File: {file} has a RatingClass out of order. LastMax: {lastMax} CurrentMin: {value}");
                    }

                    lastMin = value;
                    minRatingClasses.Add(value);
                    isMin = false;
                }
                else
                {
                    if (lastMax.HasValue && lastMax > value)
                    {
                        log.Warn($"File: {file} has a RatingClass out of order. LastMax: {lastMax} CurrentMax: {value}");
                    }

                    if (lastMin.HasValue && lastMin > value)
                    {
                        log.Warn($"File: {file} has a RatingClass out of order. LastMax: {lastMax} CurrentMax: {value}");
                    }

                    lastMax = value;
                    maxRatingClasses.Add(value);
                    isMin = true;
                }
            }
        }

        private void ValidateWhere(string line)
        {
            if (inWhereCaseClause)
            {
                if (isFirstCaseLine)
                {
                    isFirstCaseLine = false;
                    return;
                }

                if (regexWhereCaseEnd.IsMatch(line))
                {
                    inWhereCaseClause = false;
                    return;
                }

                var matches = regexWhereCaseItem.Matches(line);
                var max = int.Parse(matches[0].Value);

                if (!maxRatingClasses.Contains(max))
                {
                    log.Warn($"File: {file} has missing max RatingClass {line}");
                }
                else
                {
                    if (!usedRatingClassMaxs.Contains(max)) usedRatingClassMaxs.Add(max);
                }
            }
            else
            {
                var matches = regexWhere.Matches(line);
                if (matches.Count != 2)
                {
                    log.Warn($"File: {file} has missing RatingClass {line}");
                }
                else
                {
                    var min = int.Parse(matches[0].Value);
                    if (!minRatingClasses.Contains(min))
                    {
                        log.Warn($"File: {file} has missing min RatingClass {line}");
                    }
                    else
                    {
                        if (!usedRatingClassMins.Contains(min)) usedRatingClassMins.Add(min);
                    }

                    var value = matches[1].Value;
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        inWhereCaseClause = true;
                        isFirstCaseLine = true;
                        return;
                    }

                    var max = int.Parse(value);

                    if (!maxRatingClasses.Contains(max))
                    {
                        log.Warn($"File: {file} has missing max RatingClass {line}");
                    }
                    else
                    {
                        if (!usedRatingClassMaxs.Contains(max)) usedRatingClassMaxs.Add(max);
                    }
                }
            }
        }

        internal void CheckForUnusedValues()
        {
            if (minRatingClasses.Count > 0) minRatingClasses.RemoveAt(0); // Remove first minimum
            if (maxRatingClasses.Count > 0) maxRatingClasses.RemoveAt(maxRatingClasses.Count - 1); // Remove last maximum

            usedRatingClassMins.ForEach(a => { minRatingClasses.Remove(a); maxRatingClasses.Remove(a - 1); });
            usedRatingClassMaxs.ForEach(a => { maxRatingClasses.Remove(a); minRatingClasses.Remove(a + 1); });

            if (minRatingClasses.Count > 0)
            {
                minRatingClasses.ForEach(a => log.Warn($"File: {file} has unused min RatingClass {a}"));
            }

            if (maxRatingClasses.Count > 0)
            {
                maxRatingClasses.ForEach(a => log.Warn($"File: {file} has unused max RatingClass {a}"));
            }
        }
    }
}
