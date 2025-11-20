using log4net;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WOW.Illustration.MobileRaterValidation
{
    internal class StateGroupValidator
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(StateGroupValidator));

        // Look for numerics that are preceded by "(" and zero or more spaces
        // Ex. ( values (1003, 'Non-NY'), (101, 'NY'))
        // Use look behind "?<=" to exclude the parens and spaces from the matches.
        private static readonly Regex regexCodes = new Regex(@"(?<=\(\s*)(\d+)");

        // Look for the literal string
        private static readonly Regex regexTable = new Regex("StatesTable", RegexOptions.IgnoreCase);

        // Look for numerics that are preceded by "StateGroupId", zero or more spaces, and "="
        // Ex. (StateGroupId = 1003 and MinInsuredAge >= 18 and MaxInsuredAge <= 80)
        // Use look behind "?<=" to exclude the text, symbols, and spaces from the matches.
        private static readonly Regex regexWhere = new Regex(@"(?<=StateGroupId\s*[=]+\s*)(\d+)", RegexOptions.IgnoreCase);

        private List<int> codes;
        private List<int> usedCodes;
        private bool foundStartOfValues;
        private string file;

        public StateGroupValidator(string file)
        {
            this.file = file;
        }

        internal void Initialize()
        {
            codes = new List<int>();
            usedCodes = new List<int>();
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
            var matches = regexCodes.Matches(line);
            foreach (Match match in matches)
            {
                var value = int.Parse(match.Value);
                codes.Add(value);
            }
        }

        private void ValidateWhere(string line)
        {
            var matches = regexWhere.Matches(line);
            if (matches.Count > 1)
            {
                log.Warn($"File: {file} has two states on a line {line}");
            }
            else
            {
                var code = int.Parse(matches[0].Value);

                if (!codes.Contains(code))
                {
                    log.Warn($"File: {file} has missing state code {line}");
                }
                else
                {
                    if (!usedCodes.Contains(code)) usedCodes.Add(code);
                }
            }
        }

        internal void CheckForUnusedValues()
        {
            if (usedCodes.Count > 0 && codes.Count > 1)
            {
                usedCodes.ForEach(a => codes.Remove(a));

                if (codes.Count > 0)
                {
                    //This doesn't look at effective dates, which might be why a state called out separately.
                    codes.ForEach(a => log.Warn($"File: {file} MAY have unused states {a}"));
                }
            }
        }
    }
}
