using log4net;
using System;

namespace WOW.Illustration.Utilities.ValuesFileParser
{
    internal class SingleValueParser
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(SingleValueParser));

        private int FixedColumnWidth;
        internal SingleValueParser(int fixedColumnWidth)
        {
            FixedColumnWidth = fixedColumnWidth;
        }

        internal bool TryParse(string line, out Tuple<string, string> pair)
        {
            var parsed = false;

            if (isParseable(line))
            {
                var name = line.Substring(0, FixedColumnWidth).Trim();
                var value = line.Substring(FixedColumnWidth).Trim();
                pair = new Tuple<string, string>(name, value);
                parsed = true;
            }
            else
            {
                if (logger.IsWarnEnabled) logger.WarnFormat("Line was not parseable: {0}", line);
                pair = null;
            }
            return parsed;
        }

        private bool isParseable(string line)
        {
            return !string.IsNullOrWhiteSpace(line) && line.Length >= FixedColumnWidth;
        }
    }
}
