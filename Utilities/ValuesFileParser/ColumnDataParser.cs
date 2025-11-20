using log4net;
using System;
using System.Collections.Generic;
using System.Globalization;
using WOW.Illustration.ValuesModel;

namespace WOW.Illustration.Utilities.ValuesFileParser
{
    internal class ColumnDataParser
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(ColumnDataParser));

        private string Delimiter = string.Empty;
        internal ColumnDataParser(string delimiter)
        {
            Delimiter = delimiter;
        }

        internal bool TryParse(string line, out Tuple<ColumnDataEnum, IList<decimal>> result)
        {
            var parsed = false;
            var elements = line.Split(new string[] { Delimiter }, StringSplitOptions.None);
            var header = ColumnDataEnum.None;
            int headerInt;

            if (elements.Length > 0 && int.TryParse(elements[0], out headerInt))
            {
                if (!Enum.IsDefined(typeof(ColumnDataEnum), headerInt))
                {
                    if (logger.IsWarnEnabled) logger.WarnFormat("Unenumerated column data header code: {0}", headerInt);
                }
                header = (ColumnDataEnum)headerInt; // This might return unexpected results if multiple enums have the same value.

                var valuesList = ConvertElements(elements, 1);

                result = new Tuple<ColumnDataEnum, IList<decimal>>(header, valuesList);
                parsed = true;
            }
            else
            {
                if (logger.IsWarnEnabled) logger.WarnFormat("Unrecognized column data header code: {0}", elements[0]);
                result = null;
            }

            return parsed;
        }

        private static List<decimal> ConvertElements(string[] elements, int offset)
        {
            var list = new List<decimal>();
            var value = 0M;

            for (int i = offset; i < elements.Length; i++)
            {
                if (decimal.TryParse(elements[i], NumberStyles.Any, CultureInfo.InvariantCulture, out value))
                {
                    list.Add(value);
                }
                else
                {
                    if (logger.IsWarnEnabled) logger.WarnFormat("Could not convert decimal value: {0}", elements[i]);
                }
            }

            return list;
        }
    }

}
