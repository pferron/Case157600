using log4net;
using System;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;

namespace WOW.MobileRaterService.Data
{
    internal static class DataValueUtilities
    {

        private static readonly ILog log = LogManager.GetLogger(typeof(DataValueUtilities));

        // Extension method to accept DataRow and field name to return valid value or a Null value
        internal static T GetValueOrDefault<T>(IDataRecord row, string fieldName)
        {
            int ordinal = row.GetOrdinal(fieldName);
            return GetValueOrDefault<T>(row, ordinal);
        }

        // Support method to assist in getting valid or Null value for an ordinal position
        internal static T GetValueOrDefault<T>(this IDataRecord row, int ordinal)
        {
            return (T)(row.IsDBNull(ordinal) ? default(T) : row.GetValue(ordinal));
        }

        /// <summary>
        /// The date used in MS code to represent Null.
        /// </summary>
        public static readonly DateTime ZeroDate = new DateTime();

        /// <summary>
        /// The date used in DB2 to represent Null.
        /// </summary>
        public static readonly DateTime ZeroDateDB2 = new DateTime(1111, 11, 11);

        /// <summary>
        /// The datetime used in DB2 to represent Null.
        /// </summary>
        public static readonly DateTime ZeroDateTimeDB2 = new DateTime(1111, 11, 11, 11, 11, 11);

        /// <summary>
        /// Converts the specified value into the type indicated by type of <paramref name="defaultValue"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if the object is not convertible.</param>
        /// <returns>The converted value if possible; otherwise <paramref name="defaultValue"/></returns>
        /// <remarks>Currently, this function only checks for DBNull values.
        /// It should be expanded to include other non-convertible types.</remarks>
        public static bool NZ(Field value, object defaultValue)
        {
            var message = string.Format(CultureInfo.InvariantCulture, "The Data.Field data type should not be passed to the NZ function.\nEnsure the data row is being referenced in for this field: {0}", value.Name);
            if (log.IsErrorEnabled) log.Error(message);
            throw new ArgumentOutOfRangeException("value", message);
        }

        /// <summary>
        /// Converts the specified value into the type indicated by type of <paramref name="defaultValue"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if the object is not convertible.</param>
        /// <returns>The converted value if possible; otherwise <paramref name="defaultValue"/></returns>
        /// <remarks>Currently, this function only checks for DBNull values.
        /// It should be expanded to include other non-convertible types.</remarks>
        public static bool NZ(object value, bool defaultValue)
        {
            bool blnReturn;

            if (!bool.TryParse(NZ(value, string.Empty), out blnReturn))
            {
                blnReturn = defaultValue;
            }

            return blnReturn;
        }

        /// <summary>
        /// Converts the specified value into the type indicated by type of <paramref name="defaultValue"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if the object is not convertible.</param>
        /// <returns>The converted value if possible; otherwise <paramref name="defaultValue"/></returns>
        /// <remarks>Currently, this function only checks for DBNull values.
        /// It should be expanded to include other non-convertible types.</remarks>
        public static byte NZ(object value, byte defaultValue)
        {
            byte bytReturn;

            if (!byte.TryParse(NZ(value, string.Empty), out bytReturn))
            {
                bytReturn = defaultValue;
            }

            return bytReturn;
        }

        /// <summary>
        /// Converts the specified value into the type indicated by type of <paramref name="defaultValue"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if the object is not convertible.</param>
        /// <returns>The converted value if possible; otherwise <paramref name="defaultValue"/></returns>
        /// <remarks>Currently, this function only checks for DBNull values.
        /// It should be expanded to include other non-convertible types.</remarks>
        public static char NZ(object value, char defaultValue)
        {
            char chrReturn;

            if (!char.TryParse(NZ(value, "XYZ"), out chrReturn))
            {
                chrReturn = defaultValue;
            }

            return chrReturn;
        }

        /// <summary>
        /// Converts the specified value into the type indicated by type of <paramref name="defaultValue"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if the object is not convertible.</param>
        /// <returns>The converted value if possible; otherwise <paramref name="defaultValue"/></returns>
        /// <remarks>Currently, this function only checks for DBNull values.
        /// It should be expanded to include other non-convertible types.</remarks>
        public static DateTime NZ(object value, DateTime defaultValue)
        {
            DateTime dtmReturn;

            if (!DateTime.TryParse(NZ(value, string.Empty), out dtmReturn))
            {
                dtmReturn = defaultValue;
            }

            return dtmReturn;
        }

        /// <summary>
        /// Converts the specified value into the type indicated by type of <paramref name="defaultValue"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if the object is not convertible.</param>
        /// <returns>The converted value if possible; otherwise <paramref name="defaultValue"/></returns>
        /// <remarks>Currently, this function only checks for DBNull values.
        /// It should be expanded to include other non-convertible types.</remarks>
        public static decimal NZ(object value, decimal defaultValue)
        {
            decimal decReturn;

            if (!decimal.TryParse(NZ(value, string.Empty), out decReturn))
            {
                decReturn = defaultValue;
            }

            return decReturn;
        }

        /// <summary>
        /// Converts the specified value into the type indicated by type of <paramref name="defaultValue"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if the object is not convertible.</param>
        /// <returns>The converted value if possible; otherwise <paramref name="defaultValue"/></returns>
        /// <remarks>Currently, this function only checks for DBNull values.
        /// It should be expanded to include other non-convertible types.</remarks>
        public static double NZ(object value, double defaultValue)
        {
            double dblReturn;

            if (!double.TryParse(NZ(value, string.Empty), out dblReturn))
            {
                dblReturn = defaultValue;
            }

            return dblReturn;
        }

        /// <summary>
        /// Converts the specified value into the type indicated by type of <paramref name="defaultValue"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if the object is not convertible.</param>
        /// <returns>The converted value if possible; otherwise <paramref name="defaultValue"/></returns>
        public static int NZ(object value, int defaultValue)
        {
            int intReturn;

            if (!int.TryParse(NZ(value, string.Empty), out intReturn))
            {
                intReturn = defaultValue;
            }

            return intReturn;
        }

        /// <summary>
        /// Converts the specified value into the type indicated by type of <paramref name="defaultValue"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if the object is not convertible.</param>
        /// <returns>The converted value if possible; otherwise <paramref name="defaultValue"/></returns>
        public static long NZ(object value, long defaultValue)
        {
            long lngReturn;

            if (!long.TryParse(NZ(value, string.Empty), out lngReturn))
            {
                lngReturn = defaultValue;
            }

            return lngReturn;
        }

        /// <summary>
        /// Converts the specified value into the type indicated by type of <paramref name="defaultValue"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if the object is not convertible.</param>
        /// <returns>The converted value if possible; otherwise <paramref name="defaultValue"/></returns>
        public static float NZ(object value, float defaultValue)
        {
            float sngReturn;

            if (!float.TryParse(NZ(value, string.Empty), out sngReturn))
            {
                sngReturn = defaultValue;
            }

            return sngReturn;
        }

        /// <summary>
        /// Converts the specified value into the type indicated by type of <paramref name="defaultValue"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if the object is not convertible.</param>
        /// <returns>The converted value if possible; otherwise <paramref name="defaultValue"/></returns>
        public static string NZ(object value, string defaultValue)
        {
            string strReturn = null;

            if (value is ValueType)
            {
                strReturn = Convert.ToString(value, CultureInfo.InvariantCulture);
                if (Regex.IsMatch(strReturn, @".*Fields\..*\.Name"))
                {
                    throw new ArgumentOutOfRangeException("value", "The Data.Field data type should not be passed to the NZ function.\nEnsure the data row is being referenced in for this field:" + strReturn);
                }
            }
            else
            {
                strReturn = value as string;

                if (strReturn == null)
                {
                    strReturn = defaultValue;
                }
            }

            return strReturn;
        }

        /// <summary>
        /// Truncates the specified string to the length given.
        /// </summary>
        /// <param name="value">The string to truncate.</param>
        /// <param name="maxLength">The maximum length allowed for the string.</param>
        /// <returns>The truncated string.</returns>
        /// <remarks>Any leading or trailing spaces are removed.</remarks>
        public static string Truncate(object value, int maxLength)
        {
            return Truncate(value, maxLength, string.Empty);
        }

        /// <summary>
        /// Truncates the specified string to the length given.
        /// </summary>
        /// <param name="value">The string to truncate.</param>
        /// <param name="maxLength">The maximum length allowed for the string.</param>
        /// <param name="marker">A string that should be appended indicating that the text was truncated.</param>
        /// <returns>The truncated string.</returns>
        /// <remarks>Any leading or trailing spaces are removed.</remarks>
        public static string Truncate(object value, int maxLength, string marker)
        {
            return Truncate(NZ(value, string.Empty), maxLength, marker);
        }

        /// <summary>
        /// Truncates the specified string to the length given.
        /// </summary>
        /// <param name="value">The string to truncate.</param>
        /// <param name="maxLength">The maximum length allowed for the string.</param>
        /// <returns>The truncated string.</returns>
        /// <remarks>Any leading or trailing spaces are removed.</remarks>
        public static string Truncate(string value, int maxLength)
        {
            return Truncate(value, maxLength, string.Empty);
        }

        /// <summary>
        /// Truncates the specified string to the length given.
        /// </summary>
        /// <param name="value">The string to truncate.</param>
        /// <param name="maxLength">The maximum length allowed for the string.</param>
        /// <param name="marker">A string that should be appended indicating that the text was truncated.</param>
        /// <returns>The truncated string.</returns>
        /// <remarks>Any leading or trailing spaces are removed.</remarks>
        public static string Truncate(string value, int maxLength, string marker)
        {
            if (value == null || marker == null)
            {
                throw new InvalidOperationException("Missing value or marker parameter.");
            }

            string strReturn = value.Trim();

            if (strReturn.Length > maxLength)
            {
                strReturn = strReturn.Remove(maxLength - marker.Length).TrimEnd();
                //NOTE: An empty truncate flag always returns True on the EndsWith function.
                if (!strReturn.EndsWith(marker, StringComparison.OrdinalIgnoreCase))
                {
                    strReturn += marker;
                }
            }

            return strReturn;
        }
    }
}