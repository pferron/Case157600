using log4net;
using System.Data.SqlClient;
using WOW.WoodmenIllustrationService.Properties;

namespace WOW.WoodmenIllustrationService.Code
{
    public static class LifePortraitsDAO
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(LifePortraitsDAO));

        /// <summary>
        /// Fetches the current NLGUL interest based on the current date using RateCode 70001 thru 70012
        /// </summary>
        /// <returns>NLGUL interest rate</returns>
        public static decimal FetchCurrentNlgInterestRate()
        {
            // This query is kept here as a constant because it is not unusual for the vendor to drop the entire Plans database and reload it.
            // A sproc or function might not get preserved.
            const string sql = "select Rate1 from dbo.RateData where RateCode = (select max(RateCode) from dbo.PlanRate where EffectiveDate = (select max(EffectiveDate) from dbo.PlanRate where RateVariable = 200400 and EffectiveDate < GETDATE()) and RateVariable = 200400)";

            decimal result = 0M;

            using (SqlConnection conn = new SqlConnection(Settings.Default.LifePortraitsDbConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandTimeout = Settings.Default.SqlCommandTimeout;
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            result = dr.GetDecimal(0);
                        }
                    }
                }
            }

            return result;
        }
    }
}