using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SyncLoadTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var tasks = CreateTaskList(1000);

            tasks.ForEach(p => p.Start());

            Task.WaitAll(tasks.ToArray());
        }

        static List<Task> CreateTaskList(int quantity)
        {
            var tasks = new List<Task>();

            for (int x = 0; x < quantity; x++)
            {
                tasks.Add(new Task(LoadTestDatabase));
            }

            return tasks;
        }

        static async void LoadTestDatabase()
        {
            Task<int> task = ExecuteTestSproc();

            int x = await task;

            Console.WriteLine("Record count: " + x);
        }

        private async static Task<int> ExecuteTestSproc()
        {
            int count = 0;
            // Create new stopwatch.
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            using (var conn = new SqlConnection("Pooling=false;Server=lpasqlt1;Database=WOWLPES_TEST;Trusted_Connection=True;Integrated Security=SSPI;"))
            {
                await conn.OpenAsync();

                using (var cmd = new SqlCommand("dbo.spDataSyncLoadTester", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    count = (int)await cmd.ExecuteScalarAsync();
                }
            }

            stopwatch.Stop();

            Console.WriteLine("Task Execution Time: " + stopwatch.ElapsedMilliseconds);

            return count;
        }
    }
}
