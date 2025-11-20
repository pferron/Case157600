using log4net;
using Newtonsoft.Json;
using ProductPremiumCollector.Code;
using ProductPremiumCollector.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Requests;
using WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Responses;
using CommandLine;

namespace ProductPremiumCollector
{   

    class Program
    {
        public class Options
        {
            [Option('h', "headerCode", Required = true, HelpText = "The header code to gather rates for.  The default is 0 to gather for all products.")]
            public int HeaderCode { get; set; }

            [Option('s', "startingAge", Required = true, HelpText = "The minumum age to gather rates for.  The default is 0.")]
            public int StartingAge { get; set; }

            [Option('m', "maxAge", Required = true, HelpText = "The maximum age to gather rates for.  The default is 85.")]
            public int MaxAge { get; set; }

            [Option('f', "startingFaceAmount", Required = true, HelpText = "The minimum face amount to gather rates for.  The default is 25000.")]
            public decimal StartingFaceAmount { get; set; }

            [Option('a', "maxFaceAmount", Required = true, HelpText = "The maximum face amount to gather rates for.  The default is 2000000.")]
            public decimal MaxFaceAmount { get; set; }

            [Option('r', "rateDeterminationDate", Required = true, HelpText = "The rate determination date to gather rates for.  The default is null.")]
            public DateTime? RateDeterminationDate { get; set; }
        }

        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        //private static SemaphoreSlim _semaphore = new SemaphoreSlim(10, 10);
        private static MobileRaterClient _client;
        static int count = 0;
        private static int _headerCode = 0;
        private static DateTime? _rateDeterminationDate = null;

        /// <summary>
        /// Collects product premium for Premium Input Rater on Mobile Rater        
        /// </summary>
        /// <param name="headerCode">The header code to gather rates for.  The default is 0.</param>
        /// <param name="startingAge">The minimum age to gather rates for.  The default is 0.</param>
        /// <param name="maxAge">The maximum age to gather rates for.  The default is 85</param>
        /// <param name="startingFaceAmount">The minimum face amount to gather rates for.  The default is 25000M</param>
        /// <param name="maxFaceAmount">The maximum face amount to gather rates for.  The default is 2000000M</param>
        static void Main(string[] args)
        {
            // Wire up log4net
            log4net.Config.XmlConfigurator.Configure();

            var maxIterations = 500;
            var iterationCounter = 1;

            var times = new List<TimeSpan>();
            var average = new TimeSpan(DateTime.Now.Ticks);
            var timeToComplete = new TimeSpan(DateTime.Now.Ticks);
            var options = new Options();
            List<Transaction> transactions = new List<Transaction>();

            try
            {
                CommandLine.Parser.Default.ParseArguments<Options>(args)
                    .WithParsed<Options>(o =>
                    {
                        if (o.HeaderCode == 0)
                        {
                            _client = new MobileRaterClient("https://lpamw-test.woodmen.net/mobileraterservice/", "api/Rate/FetchLifeRates", new TimeSpan(0, 1, 0));

                            // Load collection of request parameters
                            transactions = GenerateTransactions();
                        }
                        else
                        {
                            _client = new MobileRaterClient("http://localhost:57601/", "api/Rate/FetchLifeRatesByHeaderCode", new TimeSpan(0, 1, 0));
                           
                            // Load collection of request parameters
                            transactions = GenerateTransactions(o.StartingAge, o.MaxAge, o.StartingFaceAmount, o.MaxFaceAmount);
                            _headerCode = o.HeaderCode;
                            _rateDeterminationDate = o.RateDeterminationDate;

                            Thread.Sleep(10000);
                        }
                    });

                

                if (File.Exists("transactions.json"))
                {
                    transactions = null;
                    log.Debug("skip detected");
                    string text = File.ReadAllText("transactions.json");
                    transactions = JsonConvert.DeserializeObject<List<Transaction>>(text);

                }


                var pendingTransactions = transactions.Where(t => t.Responses == null || t.Responses.Any(r => r.HasError));
                var max = pendingTransactions.Count();
                while (pendingTransactions.Any())
                {
                    log.Debug("Starting.");

                    var sw = new Stopwatch();
                    sw.Start();

                    File.Delete("transactions.json");
                    File.WriteAllText("transactions.json", JsonConvert.SerializeObject(pendingTransactions));
                    log.Debug($"Processing {pendingTransactions.Count()} requests...");

                    int stop = pendingTransactions.Count() > 1000 ? 1000 : pendingTransactions.Count();
                    var topTen = pendingTransactions.Take(stop).ToList();
                    pendingTransactions.ToList().RemoveRange(0, stop);

                    var result = Transmit(topTen, _headerCode, _rateDeterminationDate);

                    var resultsWithoutErrors = result.Where(t => t.Responses == null || t.Responses.All(x => !x.HasError) || t.Responses.Count != 0).ToList(); //t.Responses != null ||
                    result = result.Where(t => t.Responses == null || t.Responses.All(x => x.HasError) || t.Responses.Count == 0).ToList();

                    count += resultsWithoutErrors.Count;
                    log.Debug($"Saving {count}");

                    pendingTransactions.ToList().AddRange(result);

                    StoreResults(resultsWithoutErrors);

                    sw.Stop();
                    var time = sw.Elapsed;
                    log.Debug($"Finished in: {time.ToString("hh\\:mm\\:ss")}");


                    times.Add(sw.Elapsed);


                    var newAverage = new TimeSpan((long)times.Select(ts => ts.Ticks).Average());
                    
                    log.Debug($"Average time: {newAverage.ToString("hh\\:mm\\:ss")} a difference of {CalculatePercentageTrend(average.Ticks, newAverage.Ticks)}");

                    average = new TimeSpan((long)times.Select(ts => ts.Ticks).Average());

                    var a = ((max - count) / 1000);
                    var newCompleteTime = TimeSpan.FromTicks((long)(average.Ticks * a));

                    log.Debug($"The estimated time to complete is: {DateTime.Now.AddTicks(newCompleteTime.Ticks).ToString()}({newCompleteTime.Days} days," +
                        $" {newCompleteTime.Hours} hours, {newCompleteTime.Minutes} minutes, {newCompleteTime.Seconds} seconds.) " +
                        $"A difference of {CalculatePercentageTrend(timeToComplete.Ticks, newCompleteTime.Ticks)}");

                    timeToComplete = newCompleteTime;

                    iterationCounter++;

                    if (iterationCounter >= maxIterations)
                    {
                        break;
                    }


                }

                //log.Debug("Web service requests complete.");

                //StoreResults(transactions);

                //log.Debug("Results recorded to database.");
            }
            catch (Exception ex)
            {
                log.Debug(ex);
            }
            finally
            {
                _client.Dispose();
            }

            Console.WriteLine("Done");
            Console.Read();

        }

        public static string CalculatePercentageTrend(long previous, long current)
        {
            return ((current - previous) / (double)previous).ToString("p");
        }

        private static IEnumerable<Transaction> Transmit(IEnumerable<Transaction> transactions, int headerCode = 0, DateTime? rateDeterminationDate = null)
        {
            //using (var progress = new ProgressBar())
            //{
            int counter = 0;
            int total = transactions.Count();

            var sync = new object();
            Parallel.ForEach(transactions, new ParallelOptions() { MaxDegreeOfParallelism = 10 }, (transaction) =>
            {

                //log.Debug($"Request #{Task.CurrentId} started.");
                var response = _client.SendRequest(transaction.Request, headerCode, rateDeterminationDate);

                Interlocked.Increment(ref counter);

                if (response == null || response.Any(r => r.HasError) || response.Count == 0)
                    log.Debug($"Null for {counter}");

                transaction.Responses = response;


                if(counter % 500 == 0 )log.Debug($"finished {counter}");
                //log.Debug($"Request #{Task.CurrentId} ended.");

                //progress.Report((double)counter / total);
            });

            return transactions;
            //}
        }

        private static List<Transaction> GenerateTransactions(int startingAge = 0, int maxAge = 85, decimal startingFaceAmount = 25000M, decimal maxFaceAmount = 2000000M)
        {
            var transactions = new List<Transaction>();

            var requests = GenerateRequests(startingAge, maxAge, startingFaceAmount, maxFaceAmount);

            foreach (var request in requests)
            {
                var transaction = new Transaction();
                transaction.Request = request;
                
                transactions.Add(transaction);
            }

            return transactions;
        }

        private static DataTable GetTable()
        {
            var data = new DataTable();
            data.Columns.Add(new DataColumn()
            {
                ColumnName = "Age",
                DataType = typeof(int),
            });
            data.Columns.Add(new DataColumn()
            {
                ColumnName = "Gender",
                DataType = typeof(string),
            });
            data.Columns.Add(new DataColumn()
            {
                ColumnName = "Tobacco",
                DataType = typeof(bool),
            });
            data.Columns.Add(new DataColumn()
            {
                ColumnName = "FaceAmount",
                DataType = typeof(decimal),
            });
            data.Columns.Add(new DataColumn()
            {
                ColumnName = "PaymentMode",
                DataType = typeof(string),
            });
            data.Columns.Add(new DataColumn()
            {
                ColumnName = "BillType",
                DataType = typeof(string),
            });
            data.Columns.Add(new DataColumn()
            {
                ColumnName = "Quote",
                DataType = typeof(decimal),
            });
            data.Columns.Add(new DataColumn()
            {
                ColumnName = "DateCalculated",
                DataType = typeof(DateTime),
            });
            data.Columns.Add(new DataColumn()
            {
                ColumnName = "ProductName",
                DataType = typeof(string),
            });
            data.Columns.Add(new DataColumn()
            {
                ColumnName = "AioGir",
                DataType = typeof(bool),
            });
            return data;
        }


        private static void StoreResults(IEnumerable<Transaction> transactions)
        {
            try
            {
                log.Debug($"Saving {transactions.ToList().Count} records to the db {DateTime.Now}");

                var data = GetTable();

                foreach (var transaction in transactions)
                {
                    foreach (var response in transaction.Responses.ToList().Where(r => r.ProductName != null))//.Responses.Where(r => !r.HasError))
                    {
                        data.Rows.Add(new object[]
                        {
                            transaction.Request.Age,
                            transaction.Request.Gender,
                            transaction.Request.Tobacco,
                            transaction.Request.FaceAmount,
                            transaction.Request.PaymentMode,
                            transaction.Request.BillType,
                            response.Rate,
                            DateTime.Today,
                            response.ProductName,
                            response.HasAioGir
                        });
                    }
                }

                File.Delete("last.json");
                File.WriteAllText("last.json", JsonConvert.SerializeObject(data));

                using (var connection = new SqlConnection("data source=tst-sql-db-2;initial catalog=MobileRaterService;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"))
                {
                    connection.Open();
                    using (var bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.KeepIdentity, null))
                    {
                        bulkCopy.DestinationTableName = "Shadow.ProductQuotes";

                        //shift the columns which allows sql server to autoincrement the first column (id)
                        bulkCopy.ColumnMappings.Add(0, 1);
                        bulkCopy.ColumnMappings.Add(1, 2);
                        bulkCopy.ColumnMappings.Add(2, 3);
                        bulkCopy.ColumnMappings.Add(3, 4);
                        bulkCopy.ColumnMappings.Add(4, 5);
                        bulkCopy.ColumnMappings.Add(5, 6);
                        bulkCopy.ColumnMappings.Add(6, 7);
                        bulkCopy.ColumnMappings.Add(7, 8);
                        bulkCopy.ColumnMappings.Add(8, 9);
                        bulkCopy.ColumnMappings.Add(9, 10);

                        //save
                        bulkCopy.WriteToServer(data);
                    }
                }

                //using (var ef = new MobileRaterServiceEntities())
                //{
                //    // Truncate table
                //    //ef.PurgeProductQuotes();
                //    // Disable autodetect to speed things up a bit
                //    ef.Configuration.AutoDetectChangesEnabled = false;

                //    foreach (var transaction in transactions)
                //    {
                //        foreach (var response in transaction.Responses)//.Responses.Where(r => !r.HasError))
                //        {
                //            try
                //            {
                //                var record = new ProductQuote();

                //                record.Age = transaction.Request.Age;
                //                record.BillType = transaction.Request.BillType;
                //                record.DateCalculated = DateTime.Today;
                //                record.FaceAmount = transaction.Request.FaceAmount;
                //                record.Gender = transaction.Request.Gender;
                //                record.PaymentMode = transaction.Request.PaymentMode;
                //                record.Quote = response.Rate;
                //                record.Tobacco = transaction.Request.Tobacco;
                //                record.ProductName = response.ProductName;
                //                record.AioGir = response.HasAioGir;

                //                ef.ProductQuotes.Add(record);
                //            }
                //            catch (Exception ex)
                //            {
                //                log.Debug(ex);
                //            }
                //        }

                //        // Save 1 to many responses in one go
                //        ef.SaveChanges();
                //    }
                //}
                log.Debug($"Done saving to db {DateTime.Now}");
            }
            catch (Exception ex)
            {
                log.Debug(ex);

                throw;
            }
        }

        private static List<LifeRateInput> GenerateRequests(int startingAge, int maxAge, decimal startingFaceAmount, decimal maxFaceAmount)
        {
            var requests = new List<LifeRateInput>();

            var genders = new List<string>() { "M", "F" };
            var tobaccos = new List<bool>() { true, false };
            var girs = new List<bool>() { true, false };
            var modes = new List<string>() { "Monthly", "Annual" };
            var methods = new List<string>() { "PAC" };
            var ages = new List<int>();
            var faceAmounts = new List<decimal>();
            
            int ageStep = 1;

            for (int i = startingAge; i <= maxAge; i += ageStep)
            {
                ages.Add(i);
            }

                                  
            decimal faceAmountStep = 5000M; //5000

            for (decimal i = startingFaceAmount; i <= maxFaceAmount; i += faceAmountStep)
            {
                faceAmounts.Add(i);
            }

            foreach (var gender in genders)
            {
                foreach (var gir in girs)
                {
                    foreach (var tobacco in tobaccos)
                    {
                        foreach (var mode in modes)
                        {
                            foreach (var method in methods)
                            {
                                foreach (var age in ages)
                                {
                                    foreach (var faceAmount in faceAmounts)
                                    {
                                        if (mode == "Monthly" && method == "Direct Bill")
                                        {
                                            continue; // monthly and direct aren't allowed
                                        }

                                        if (age < 18 && tobacco)
                                        {
                                            continue; // Tobacco is not allowed under 18
                                        }

                                        var parameters = new LifeRaterParameters();
                                        parameters.Age = age;
                                        parameters.BillType = method;
                                        parameters.FaceAmount = faceAmount;
                                        parameters.Gender = gender;
                                        parameters.PaymentMode = mode;
                                        parameters.Tobacco = tobacco;
                                        parameters.Gir = gir;

                                        requests.Add(LifeRaterRequestInitializer.BuildRequest(parameters));
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return requests;
        }
    }
}
