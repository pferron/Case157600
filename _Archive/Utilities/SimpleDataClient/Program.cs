using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOW.SimpleDataClient
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("Usage:");
                Console.WriteLine("Parameter1 is the connection string to use");
                Console.WriteLine("Parameter2 is the query to execute");
                Console.WriteLine("This utility can't return recordsets yet.");

                return;
            }

            var connectionString = args[0];
            var query = args[1];

            if (String.IsNullOrWhiteSpace(connectionString))
            {
                Console.WriteLine("ConnectionString (arg0) is required.");
                return;
            }

            if (String.IsNullOrWhiteSpace(query))
            {
                Console.WriteLine("Query (arg1) is required.");
                return;
            }

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        var rowsAffected = cmd.ExecuteNonQuery();

                        Console.WriteLine("Success! Number of rows affected: {0}", rowsAffected);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occurred during execution:");
                Console.WriteLine("Exception: {0}", ex);
            }
        }
    }
}
