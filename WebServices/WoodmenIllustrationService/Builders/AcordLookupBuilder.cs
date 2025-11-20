using log4net;
using System;
using System.Globalization;
using WOW.Illustration.Model.ACORD;
using WOW.WoodmenIllustrationService.Code;

namespace WOW.WoodmenIllustrationService.Builders
{
    /// <summary>
    /// This class contains methods for generating ACORD lookup objects.
    /// </summary>
    public static class AcordLookupBuilder
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(AcordLookupBuilder));

        /// <summary>
        /// Builds an ACORD Boolean object using the specified value.
        /// </summary>
        /// <param name="value">The value to set.</param>
        /// <returns>An ACORD Lookup object.</returns>
        public static OLI_LU_BOOLEAN BuildBoolean(bool value)
        {
            OLI_LU_BOOLEAN_TC tc;

            if (value)
            {
                tc = OLI_LU_BOOLEAN_TC.OLI_BOOL_TRUE;
            }
            else
            {
                tc = OLI_LU_BOOLEAN_TC.OLI_BOOL_FALSE;
            }

            return BuildFromTC<OLI_LU_BOOLEAN, OLI_LU_BOOLEAN_TC>(tc);
        }

        /// <summary>
        /// Builds the specified ACORD object using the given TC Value.
        /// </summary>
        /// <typeparam name="T">The type of ACORD object to build</typeparam>
        /// <param name="tc">The TC enumeration value for the object.</param>
        /// <returns>An ACORD object populuated with the given TC value.</returns>
        public static T BuildFromTC<T>(int tc)
            where T : class, new()
        {
            var tcType = ExtractEnumTypeFromTC<T>();
            var acordLookup = AcordLookupHelper.Convert(tcType.Name, tc);

            return Build<T>(tcType, acordLookup);
        }

        /// <summary>
        /// Builds the specified ACORD object using the given TC Value.
        /// </summary>
        /// <typeparam name="T">The type of ACORD object to build</typeparam>
        /// <typeparam name="K">The type of the TC enumeration associated with the object to build.</typeparam>
        /// <param name="tc">The TC enumeration value for the object.</param>
        /// <returns>An ACORD object populuated with the given TC value.</returns>
        public static T BuildFromTC<T, K>(K tc)
            where T : class, new()
            where K : struct
        {
            var tcType = typeof(K);
            var intValue = Convert.ToInt32(tc, CultureInfo.InvariantCulture);
            var acordLookup = AcordLookupHelper.Convert(tcType.Name, intValue);

            return Build<T>(tcType, acordLookup);
        }

        /// <summary>
        /// Builds the specified ACORD object using the given Woodmen Value.
        /// </summary>
        /// <typeparam name="T">The type of ACORD object to build</typeparam>
        /// <param name="wowValue">The Woodmen value that needs to be translated.</param>
        /// <returns>An ACORD object with the equivalent of the given Woodmen value.</returns>
        public static T BuildFromWowString<T>(string wowValue)
           where T : class, new()
        {
            var lookupType = typeof(T);

            if (wowValue == null)
            {
                var message = string.Format(CultureInfo.InvariantCulture, "{0}: WOW value not set.", lookupType.Name);
                logger.Error(message);
                throw new ArgumentNullException("wowValue", message);
            }

            var tcType = ExtractEnumTypeFromTC<T>();
            var acordLookup = AcordLookupHelper.Convert(tcType.Name, wowValue);

            return Build<T>(tcType, acordLookup);
        }

        /// <summary>
        /// Builds the specified ACORD object using the values provided.
        /// </summary>
        /// <typeparam name="T">The type of ACORD object to build.</typeparam>
        /// <param name="tcType">The Type associated with the TC enumeration.</param>
        /// <param name="acordLookup">The ID and Text values to use for the new object.</param>
        /// <returns>A strongly-typed ACORD object.</returns>
        private static T Build<T>(Type tcType, AcordLookup acordLookup) where T : class, new()
        {
            var lookupType = typeof(T);
            try
            {
                if (logger.IsDebugEnabled) logger.DebugFormat(CultureInfo.InvariantCulture, "Building Lookup Type: {0} from acordLookup: {1}", lookupType.Name, acordLookup);
                var tcEnum = Enum.ToObject(tcType, acordLookup.TC);

                dynamic lookup = new T();
                lookup.tc = (dynamic)tcEnum;
                lookup.Value = acordLookup.Value;

                // Use reflection to build the new ACORD lookup object and set its values.
                //lookupType.InvokeMember("tc", BindingFlags.SetProperty, null, lookup, new object[] { tcEnum });
                //lookupType.InvokeMember("Value", BindingFlags.SetProperty, null, lookup, new object[] { acordLookup.Value });

                return lookup;

            }
            catch (Exception ex)
            {
                if (logger.IsWarnEnabled)
                {
                    var message = string.Format(CultureInfo.InvariantCulture, "Exception while using reflection on: {0}", lookupType.Name);
                    logger.Warn(message, ex);
                }
                throw;
            }
        }

        /// <summary>
        /// Helper method used to determine the Type of the enumeration associated with the current class.
        /// </summary>
        /// <typeparam name="T">The type of ACORD object containing a TC property.</typeparam>
        /// <returns>The Type of the enumeration.</returns>
        private static Type ExtractEnumTypeFromTC<T>() where T : class, new()
        {
            var tcMember = typeof(T).GetProperty("tc");

            return tcMember.GetMethod.ReturnType;
        }
    }
}