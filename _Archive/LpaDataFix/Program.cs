using LpaDataFix.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LpaDataFix
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Stop LPA services
                RemoteServicesHelper.StopService("localhost", Settings.Default.LpaServiceName);
                RemoteServicesHelper.StopService("localhost", Settings.Default.LpaSyncServiceName);

                // Execute query
                var rowsAffected = ExecuteQuery();

                // Output affected rows
                Console.WriteLine("Success! Affected rows: {0}", rowsAffected);

                // Start LPA services
                RemoteServicesHelper.StartService("localhost", Settings.Default.LpaServiceName);
                RemoteServicesHelper.StartService("localhost", Settings.Default.LpaSyncServiceName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occurred:");
                Console.WriteLine("{0}", ex);
            }
        }

        private static int ExecuteQuery()
        {
            int rowsAffected = 0;

            try
            {
                using (var conn = new SqlConnection(Settings.Default.LpaConnectionString))
                {
                    conn.Open();

                    using (var cmd = new SqlCommand(Settings.Default.SqlQuery, conn))
                    {
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }

                return rowsAffected;
            }
            catch
            {
                throw;
            }
        }
    }
}
