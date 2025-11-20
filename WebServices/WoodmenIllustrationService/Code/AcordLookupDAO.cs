using log4net;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WOW.WoodmenIllustrationService.Properties;

namespace WOW.WoodmenIllustrationService.Code
{
    /// <summary>
    /// Class containing methods for accessing the ACORD Lookup data source.
    /// </summary>
    public static class AcordLookupDAO
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(AcordLookupDAO));

        /// <summary>
        /// Loads a list of ACORD lookup objects keyed by their TC code.
        /// </summary>
        /// <param name="normalizedCode">The ACORD type that should be loaded. The name should have all spaces and underscores removed and be upper case.</param>
        /// <returns>A list of zero or more data values for the specified type</returns>
        public static SortedList<int, AcordLookup> LoadAcordLookupListByTC(string normalizedCode)
        {
            if (log.IsInfoEnabled) { log.Info($"LoadAcordLookupListByTC called with normalizedCode: {normalizedCode}."); }

            const string sql = "SELECT t1.Tc, t1.Text FROM AcordLookup t1 INNER JOIN AcordLookupType t2 ON t1.AcordLookupTypeId = t2.AcordLookupTypeId WHERE t2.NormalizedCode = @NormalizedCode ORDER BY t1.Tc ";

            var list = new SortedList<int, AcordLookup>();
            AcordLookup lookup;

            if (string.IsNullOrWhiteSpace(normalizedCode))
            {
                string message = "Normalized Code was not set.";
                log.Error(message);
                throw new ArgumentOutOfRangeException("normalizedCode", message);
            }

            using (SqlConnection conn = new SqlConnection(Settings.Default.IntegrationDbConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandTimeout = Settings.Default.SqlCommandTimeout;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@NormalizedCode", normalizedCode);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lookup = new AcordLookup();
                            lookup.TC = dr.GetInt32(0);
                            lookup.Value = dr.GetString(1);
                            list.Add(lookup.TC, lookup);
                        }
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Loads a list of ACORD lookup objects keyed by their Woodmen equivalent.
        /// </summary>
        /// <param name="normalizedCode">The ACORD type that should be loaded. The name should have all spaces and underscores removed and be upper case.</param>
        /// <returns>A list of zero or more data values for the specified type</returns>
        public static SortedList<string, AcordLookup> LoadAcordLookupListByWowValue(string normalizedCode)
        {
            if (log.IsInfoEnabled) { log.Info($"LoadAcordLookupListByWowValue called with normalizedCode: {normalizedCode}."); }

            const string sql = "SELECT t1.Tc, t1.Text, t3.WowValue FROM AcordLookup t1 INNER JOIN AcordLookupType t2 ON t1.AcordLookupTypeId = t2.AcordLookupTypeId INNER JOIN WowToAcordMap t3 ON t1.AcordLookupId = t3.AcordLookupId WHERE t2.NormalizedCode = @NormalizedCode ORDER BY t1.Tc ";

            var list = new SortedList<string, AcordLookup>();
            AcordLookup lookup;

            if (string.IsNullOrWhiteSpace(normalizedCode))
            {
                string message = "Normalized Code was not set.";
                log.Error(message);
                throw new ArgumentOutOfRangeException("normalizedCode", message);
            }

            using (SqlConnection conn = new SqlConnection(Settings.Default.IntegrationDbConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandTimeout = Settings.Default.SqlCommandTimeout;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@NormalizedCode", normalizedCode);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lookup = new AcordLookup();
                            lookup.TC = dr.GetInt32(0);
                            lookup.Value = dr.GetString(1);
                            var key = dr.GetString(2);
                            list.Add(key, lookup);
                        }
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Loads a list of ACORD Lookup Type names.
        /// </summary>
        /// <returns>A list of zero or more type names.</returns>
        public static IList<string> LoadAcordLookupTypeNameList()
        {
            if (log.IsInfoEnabled) { log.Info($"LoadAcordLookupTypeNameList called."); }

            const string sql = "SELECT NormalizedCode FROM AcordLookupType ORDER BY NormalizedCode ";

            var list = new List<string>();

            using (SqlConnection conn = new SqlConnection(Settings.Default.IntegrationDbConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandTimeout = Settings.Default.SqlCommandTimeout;
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(dr.GetString(0));
                        }
                    }
                }
            }

            return list;
        }

    }
}