using log4net;
using Newtonsoft.Json;
using ProductPremiumCollectorService.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Requests;
using ProductPremiumCollectorService.Properties;

namespace ProductPremiumCollectorService.Code
{
    public class Transactions
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Transactions));
        private static MobileRaterClient _client;       
        static int count = 0;

        public List<Transaction> LoadPreviousRun()
        {            
            List<Transaction> transactions = new List<Transaction>();
            string transactionPath = Path.Combine(Settings.Default.TransactionPath, "transactions.json");
            //string transactionPath = "transactions.json";

            if (File.Exists(transactionPath))
            {
                transactions = null;
                log.Debug("skip detected");
                string text = File.ReadAllText(transactionPath);
                transactions = JsonConvert.DeserializeObject<List<Transaction>>(text);
            }

            return transactions;
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

            _client = new MobileRaterClient(Settings.Default.MobileRaterService_BaseURL, "api/Rate/FetchLifeRatesByHeaderCode", new TimeSpan(0, 1, 0));

            Parallel.ForEach(transactions, new ParallelOptions() { MaxDegreeOfParallelism = 10 }, (transaction) =>
            {
                //log.Debug($"Request #{Task.CurrentId} started.");
                var response = _client.SendRequest(transaction.Request, headerCode, rateDeterminationDate);

                Interlocked.Increment(ref counter);

                //if (response == null || response.Any(r => r.HasError) || response.Count == 0)
                //    log.Debug($"Null for {counter}");

                transaction.Responses = response;


                if (counter % 500 == 0) log.Debug($"finished {counter}");
                //log.Debug($"Request #{Task.CurrentId} ended.");

                //progress.Report((double)counter / total);
            });

            _client.Dispose();

            return transactions;
            //}
        }

        public void ProcessTransactions(ProductRequest productRequest)
        {
            var maxIterations = 500;
            var iterationCounter = 1;            
            DbFunctions dbFunctions = new DbFunctions();
            string transactionPath = Path.Combine(Settings.Default.TransactionPath, "transactions.json");
            //string transactionPath = "transactions.json";

            try
            {
                var pendingTransactions = productRequest.Transactions.Where(t => t.Responses == null || t.Responses.Any(r => r.HasError));
                var max = pendingTransactions.Count();
                while (pendingTransactions.Any())
                {
                    File.Delete(transactionPath);
                    File.WriteAllText(transactionPath, JsonConvert.SerializeObject(pendingTransactions));
                    log.Debug($"Processing {pendingTransactions.Count()} requests...");

                    int stop = pendingTransactions.Count() > 1000 ? 1000 : pendingTransactions.Count();
                    var topTen = pendingTransactions.Take(stop).ToList();
                    pendingTransactions.ToList().RemoveRange(0, stop);

                    var result = Transmit(topTen, productRequest.HeaderCode, productRequest.RateDeterminationDate);

                    var resultsWithoutErrors = result.Where(t => t.Responses == null || t.Responses.All(x => !x.HasError) || t.Responses.Count != 0).ToList(); //t.Responses != null ||
                    result = result.Where(t => t.Responses == null || t.Responses.All(x => x.HasError) || t.Responses.Count == 0).ToList();

                    count += resultsWithoutErrors.Count;
                    log.Debug($"Saving {count}");

                    pendingTransactions.ToList().AddRange(result);

                    dbFunctions.StoreResults(resultsWithoutErrors);

                    iterationCounter++;

                    if (iterationCounter >= maxIterations)
                    {
                        break;
                    }
                }

                dbFunctions.UpdateQuotes();
            }
            catch (Exception ex)
            {
                log.Error(ex);

                var recipients = Properties.Settings.Default.EmailList.Cast<string>().ToArray();
                SmtpHelper.Send(recipients, "Product Premium Collector Service Transaction Error", "Error Processing Transaction: " + ex.Message, true);
            }           
        }

        public List<Transaction> GenerateTransactions(ProductRequest productRequest)
        {
            var transactions = new List<Transaction>();

            var requests = GenerateRequests(productRequest.StartingAge, productRequest.MaxAge, productRequest.StartingFaceAmount, productRequest.MaxFaceAmount);

            foreach (var request in requests)
            {
                var transaction = new Transaction();
                transaction.Request = request;

                transactions.Add(transaction);
            }

            return transactions;
        }

        public List<LifeRateInput> GenerateRequests(int startingAge, int maxAge, int startingFaceAmount, int maxFaceAmount)
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
