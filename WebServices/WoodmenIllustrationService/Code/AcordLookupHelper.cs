using log4net;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace WOW.WoodmenIllustrationService.Code
{
    /// <summary>
    /// This class is used for map values into their ACORD equivalents.
    /// </summary>
    public static class AcordLookupHelper
    {
        private readonly static ILog log = LogManager.GetLogger(typeof(AcordLookupHelper));
        private static readonly IList<string> AcordLookupTypes = AcordLookupDAO.LoadAcordLookupTypeNameList();
        private static SortedList<string, SortedList<int, AcordLookup>> AcordLookupsByTC = new SortedList<string, SortedList<int, AcordLookup>>();
        private static SortedList<string, SortedList<string, AcordLookup>> AcordLookupsByWowValue = new SortedList<string, SortedList<string, AcordLookup>>();

        /// <summary>
        /// Converts the specified Woodmen Model value to an Acord Lookup object (untyped ACORD "TC" object).
        /// </summary>
        /// <param name="tcTypeName">The name of TC Type.</param>
        /// <param name="wowValue">The Woodmen value.</param>
        /// <returns>A non-ACORD object representing the value.</returns>
        public static AcordLookup Convert(string tcTypeName, string wowValue)
        {
            if (log.IsInfoEnabled) { log.Info($"Convert called with tcTypeName: {tcTypeName} wowValue: {wowValue}."); }

            SortedList<string, AcordLookup> lookupMap;
            AcordLookup acordLookup;

            if (tcTypeName == null)
            {
                var message = string.Format(CultureInfo.InvariantCulture, "Missing Argument tcTypeName: <null>, wowValue: {0}", wowValue);
                log.Error(message);
                throw new ArgumentNullException("tcTypeName", message);
            }

            if (wowValue == null)
            {
                var message = string.Format(CultureInfo.InvariantCulture, "Missing Argument tcTypeName: {0}, wowValue: <null>", tcTypeName);
                log.Error(message);
                throw new ArgumentNullException("wowValue", message);
            }

            var typeNameNormalized = tcTypeName.Replace("_", string.Empty);

            if (AcordLookupsByWowValue.ContainsKey(typeNameNormalized))
            {
                lookupMap = AcordLookupsByWowValue[typeNameNormalized];
            }
            else
            {
                // See if this is a valid lookup type
                if (AcordLookupTypes.Contains(typeNameNormalized))
                {
                    lock (log)
                    {
                        if (AcordLookupsByWowValue.ContainsKey(typeNameNormalized))
                        {
                            lookupMap = AcordLookupsByWowValue[typeNameNormalized];
                        }
                        else
                        {
                            // Load the lookup map from the data source.
                            lookupMap = AcordLookupDAO.LoadAcordLookupListByWowValue(typeNameNormalized);
                            // Add the type map to the master map.
                            AcordLookupsByWowValue.Add(typeNameNormalized, lookupMap);
                        }
                    }
                }
                else
                {
                    if (log.IsErrorEnabled) log.ErrorFormat(CultureInfo.InvariantCulture, "Could not find mapping for tcTypeName: {0}, normalized: {1}, wowValue: {2}", tcTypeName, typeNameNormalized, wowValue);
                    throw new ArgumentOutOfRangeException("tcTypeName", tcTypeName, "Tried to convert to an unknown ACORD Lookup type.");
                }
            }

            // It isn't necessary to check if the key exists first, but we need to report any missing mappings.
            if (lookupMap != null && lookupMap.ContainsKey(wowValue))
            {
                acordLookup = lookupMap[wowValue];
            }
            else if (lookupMap != null)
            {
                if (log.IsWarnEnabled) log.WarnFormat(CultureInfo.InvariantCulture, "Could not find mapped value for Woodmen Value: {0} to tcTypeName: {1}", wowValue, tcTypeName);

                // return OLI_LU_UKNOWN with the Woodmen value as the text.
                acordLookup = new AcordLookup();
                acordLookup.TC = 0;
                acordLookup.Value = wowValue;
            }
            else
            {
                if (log.IsErrorEnabled) log.ErrorFormat(CultureInfo.InvariantCulture, "Could not find mapped value for Woodmen Value: {0} to tcTypeName: {1}", wowValue, tcTypeName);
                acordLookup = null;
            }

            if (log.IsDebugEnabled) log.DebugFormat(CultureInfo.InvariantCulture, "Woodmen Value: {0} mapped to tcTypeName: {1} resulted in: {2}", wowValue, tcTypeName, acordLookup);

            return acordLookup;
        }

        /// <summary>
        /// Converts the specified ACORD TC enumeration value to an Acord Lookup object (untyped ACORD "TC" object).
        /// </summary>
        /// <param name="tcTypeName">The name of TC Type.</param>
        /// <param name="tc">The ACORD TC value to use to build the object.</param>
        /// <returns>A non-ACORD object representing the value.</returns>
        public static AcordLookup Convert(string tcTypeName, int tc)
        {
            if (log.IsInfoEnabled) { log.Info($"Convert called with tcTypeName: {tcTypeName} tc: {tc}."); }

            SortedList<int, AcordLookup> lookupMap;
            AcordLookup acordLookup;
            string typeNameNormalized;

            if (tcTypeName == null)
            {
                var message = string.Format(CultureInfo.InvariantCulture, "Missing Argument tcTypeName: {0}, tc{1}", tcTypeName, tc);
                log.Error(message);
                throw new ArgumentNullException("tcTypeName", message);
            }

            typeNameNormalized = tcTypeName.Replace("_", string.Empty);

            if (AcordLookupsByTC.ContainsKey(typeNameNormalized))
            {
                lookupMap = AcordLookupsByTC[typeNameNormalized];
            }
            else
            {
                // See if this is a valid lookup type
                if (AcordLookupTypes.Contains(typeNameNormalized))
                {
                    lock (log)
                    {
                        if (AcordLookupsByTC.ContainsKey(typeNameNormalized))
                        {
                            lookupMap = AcordLookupsByTC[typeNameNormalized];
                        }
                        else
                        {
                            // Load the lookup map from the data source.
                            lookupMap = AcordLookupDAO.LoadAcordLookupListByTC(typeNameNormalized);
                            // Add the type map to the master map.
                            AcordLookupsByTC.Add(typeNameNormalized, lookupMap);
                        }
                    }
                }
                else
                {
                    if (log.IsErrorEnabled) log.ErrorFormat(CultureInfo.InvariantCulture, "Could not find mapping for tcTypeName: {0}, normalized: {1}, tc: {2}", tcTypeName, typeNameNormalized, tc);
                    throw new ArgumentOutOfRangeException("tcTypeName", tcTypeName, "Tried to convert to an unknown ACORD Lookup type.");
                }
            }

            // It isn't necessary to check if the key exists first, but we need to report any missing mappings.
            if (lookupMap != null && lookupMap.ContainsKey(tc))
            {
                acordLookup = lookupMap[tc];
            }
            else
            {
                if (log.IsErrorEnabled) log.ErrorFormat(CultureInfo.InvariantCulture, "Could not find mapping for TC Value: {0} to ACORD type: {1}", tc, tcTypeName);
                acordLookup = null;
            }

            if (log.IsDebugEnabled) log.DebugFormat(CultureInfo.InvariantCulture, "TC Value: {0} mapped to ACORD type: {1} resulted in: {2}", tc, tcTypeName, acordLookup);

            return acordLookup;
        }

    }
}