using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.OleDb;
using log4net;
using WOW.MobileRaterService.Properties;


namespace WOW.MobileRaterService.Data
{
    public static class PinDAO
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(PinDAO));

        /// <summary>
        /// Validates Sales Rep Pin Code against DB2 data
        /// </summary>
        /// <param name="pinCode">Numeric string representing the user's PIN code</param>
        /// <param name="salesRepCode">Numeric string representing the user's sale rep code</param>
        /// <returns>Either 1 on success or 0 on Error/Failed Login</returns>
        public static int ValidatePinCode(string pinCode, string salesRepCode)
        {
            const string sql = "select fpc_fr_cd from wowtb.fr_pin_code where fpc_pin_cd = ? and fpc_fr_cd = ? and fpc_expr_dt >= ?";

            int returnCode = 0;

            try
            {
                using (OleDbConnection DB2Conn = new OleDbConnection(Settings.Default.DB2ConnectionString))
                {
                    DB2Conn.Open();

                    using (var command = new OleDbCommand(sql, DB2Conn))
                    {
                        command.Parameters.Add(new OleDbParameter("@fpc_pin_cd", pinCode));
                        command.Parameters.Add(new OleDbParameter("@fpc_fr_cd", salesRepCode));
                        command.Parameters.Add(new OleDbParameter("@fpc_expr_dt", DateTime.Today.ToString("yyyy-MM-dd")));

                        using (var reader = command.ExecuteReader())
                        {
                            if(reader.HasRows)
                            {
                                returnCode = 1;
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                if(log.IsErrorEnabled) { log.Error($"Error occurred while checking PIN '{pinCode}' for Sale Rep '{salesRepCode}'.", ex); }

                returnCode = 0;
            }

            return returnCode;
        }
    }
}