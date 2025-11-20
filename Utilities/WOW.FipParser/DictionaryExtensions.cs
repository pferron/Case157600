using System;
using System.Collections.Generic;

namespace WOW.FipUtilities
{
    internal static class DictionaryExtensions
    {
        /// <summary>
        /// Returns the value associated with the provided key, if it exists. Otherwise, it returns an empty string.
        /// </summary>
        /// <param name="key">Dictionary key to lookup.</param>
        /// <returns>Dictionary value or empty string.</returns>
        public static string SafeGetValue<K>(this Dictionary<K, string> dictionary, K key)
        {
            if (dictionary.ContainsKey(key))
            {
                return dictionary[key];
            }
            else
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// Returns the value associated with the provided key, if it exists. Otherwise, it returns the defaultValue argument.
        /// </summary>
        /// <param name="key">Dictionary key to lookup.</param>
        /// <param name="defaultValue">Value to return if key is not found or value does not parse to the value type.</param>
        /// <returns>Dictionary value or default value.</returns>
        public static string SafeGetValue<K>(this Dictionary<K, string> dictionary, K key, string defaultValue)
        {
            if (dictionary.ContainsKey(key))
            {
                return dictionary[key];
            }
            else
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Returns the value associated with the provided key, if it exists. Otherwise, it returns the defaultValue argument.
        /// </summary>
        /// <param name="key">Dictionary key to lookup.</param>
        /// <param name="defaultValue">Value to return if key is not found or value does not parse to the value type.</param>
        /// <returns>Dictionary value or default value.</returns>
        public static int SafeGetValue<K>(this Dictionary<K, string> dictionary, K key, int defaultValue)
        {
            if (dictionary.ContainsKey(key))
            {
                int v;

                if (Int32.TryParse(dictionary[key], out v))
                {
                    return v;
                }
                else
                {
                    return defaultValue;
                }

            }
            else
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Returns the value associated with the provided key, if it exists. Otherwise, it returns the defaultValue argument.
        /// </summary>
        /// <param name="key">Dictionary key to lookup.</param>
        /// <param name="defaultValue">Value to return if key is not found or value does not parse to the value type.</param>
        /// <returns>Dictionary value or default value.</returns>
        public static decimal SafeGetValue<K>(this Dictionary<K, string> dictionary, K key, decimal defaultValue)
        {
            if (dictionary.ContainsKey(key))
            {
                decimal v;

                if (Decimal.TryParse(dictionary[key], System.Globalization.NumberStyles.Currency, System.Globalization.CultureInfo.CurrentCulture, out v))
                {
                    return v;
                }
                else
                {
                    return defaultValue;
                }
            }
            else
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Returns the value associated with the provided key, if it exists. Otherwise, it returns the defaultValue argument.
        /// </summary>
        /// <param name="key">Dictionary key to lookup.</param>
        /// <param name="defaultValue">Value to return if key is not found or value does not parse to the value type.</param>
        /// <returns>Dictionary value or default value.</returns>
        public static DateTime SafeGetValue<K>(this Dictionary<K, string> dictionary, K key, DateTime defaultValue)
        {
            if (dictionary.ContainsKey(key))
            {
                DateTime v;

                if (DateTime.TryParse(dictionary[key], out v))
                {
                    return v;
                }
                else
                {
                    return defaultValue;
                }
            }
            else
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Returns the value associated with the provided key, if it exists. Otherwise, it returns the defaultValue argument. Returns 'true' for '1' and 'false' for '0'.
        /// </summary>
        /// <param name="key">Dictionary key to lookup.</param>
        /// <param name="defaultValue">Value to return if key is not found or value does not parse to the value type.</param>
        /// <returns>Dictionary value or default value.</returns>
        public static bool SafeGetValue<K>(this Dictionary<K, string> dictionary, K key, bool defaultValue)
        {
            if (dictionary.ContainsKey(key))
            {
                bool v;

                // If it parses correctly, return the parsed value. This works for string likes 'True', 'true', 'False' and 'false';
                // FIP files typically use '1' and '0', so this will usually fail, but was included for completeness.
                if (Boolean.TryParse(dictionary[key], out v))
                {
                    return v;
                }

                if (dictionary[key] == "1")
                {
                    return true;
                }

                if (dictionary[key] == "0")
                {
                    return false;
                }

                return defaultValue;
            }
            else
            {
                return defaultValue;
            }
        }
    }
}
