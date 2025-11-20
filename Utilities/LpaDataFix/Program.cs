using System;
using System.Data.SqlClient;
using LpaDataFix.Properties;

namespace LpaDataFix
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                RemoteServicesHelper.StopService("localhost", Settings.Default.LpaServiceName);
                RemoteServicesHelper.StopService("localhost", Settings.Default.LpaSyncServiceName);
                Console.WriteLine("Success! Affected rows: {0}", (object)Program.ExecuteQuery());
                RemoteServicesHelper.StartService("localhost", Settings.Default.LpaServiceName);
                RemoteServicesHelper.StartService("localhost", Settings.Default.LpaSyncServiceName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occurred:");
                Console.WriteLine("{0}", (object)ex);
            }
            finally
            {
                Console.ReadKey(); 
            }
        }

        private static int ExecuteQuery()
        {
            int num = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(@Settings.Default.LpaConnectionString))
                {
                    connection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(Settings.Default.SqlQuery, connection))
                        num = sqlCommand.ExecuteNonQuery();

                    using (SqlCommand sqlCommand = new SqlCommand(Settings.Default.ObjRefSql, connection))
                        num += sqlCommand.ExecuteNonQuery();
                }
                
                return num;
            }
            catch
            {
                throw;
            }
        }
    }
}
