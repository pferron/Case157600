using log4net;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WOW.WoodmenIllustrationService.Models;
using WOW.WoodmenIllustrationService.Properties;

namespace WOW.WoodmenIllustrationService.Code
{
    public static class IntegrationDAO
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(IntegrationDAO));

        public static IEnumerable<StoneRiverTemplate> LoadStoneRiverIllustrationTemplates()
        {
            try
            {
                if (log.IsDebugEnabled) { log.Debug("Loading Illustration Templates."); }

                const string sql = "SELECT HeaderCode, IsInforce, TemplateId FROM TemplateMapping ORDER BY HeaderCode";

                var templates = new List<StoneRiverTemplate>();

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
                                var model = new StoneRiverTemplate();

                                model.HeaderCode = dr.GetInt32(dr.GetOrdinal("HeaderCode"));
                                model.TemplateId = dr.GetString(dr.GetOrdinal("TemplateId"));
                                model.IsInforce = dr.GetBoolean(dr.GetOrdinal("IsInforce"));

                                templates.Add(model);
                            }
                        }
                    }
                }

                if (log.IsDebugEnabled) { log.DebugFormat("Loaded {0} Templates.", templates.Count); }

                return templates;
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error("Error Loading Illustration Templates.", ex); }

                throw;
            }
        }

        public static SortedList<int, decimal> LoadRequiredFraternalDues()
        {
            try
            {
                if (log.IsDebugEnabled) { log.Debug("Loading Required Fraternal Dues."); }

                const string sql = "SELECT HeaderCode, Dues FROM RequiredFraternalDues ORDER BY HeaderCode";

                var list = new SortedList<int, decimal>();

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
                                var headerCode = dr.GetInt32(dr.GetOrdinal("HeaderCode"));
                                var dues = dr.GetDecimal(dr.GetOrdinal("Dues"));

                                list.Add(headerCode, dues);
                            }
                        }
                    }
                }

                if (log.IsDebugEnabled) { log.DebugFormat("Loaded {0} Required Fraternal Dues.", list.Count); }

                return list;
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error("Error Loading Required Fraternal Dues.", ex); }

                throw;
            }
        }
    }
}