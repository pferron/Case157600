using log4net;
using Newtonsoft.Json;
using ProductPremiumCollectorService.Code;
using ProductPremiumCollectorService.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Timers;
using ProductPremiumCollectorService.Properties;

namespace ProductPremiumCollectorService
{
    public partial class CollectorService : ServiceBase
    {
        public CollectorService()
        {
            InitializeComponent();
        }

        private static readonly ILog log = LogManager.GetLogger(typeof(CollectorService));        
        private static System.Timers.Timer aTimer;               

        protected override void OnStart(string[] args)
        {
            //Check if need to continue processing previously started run
            //Check database for new request
            string transactionPath = Path.Combine(Settings.Default.TransactionPath, "transactions.json");
            //string transactionPath = "transactions.json";
            DbFunctions dbFunctions = new DbFunctions();
            log4net.Config.XmlConfigurator.Configure();

            List<Transaction> transactions;
            Transactions loadTransactions = new Transactions();

            transactions = loadTransactions.LoadPreviousRun();

            if (transactions.Count > 0)
            {
                ProductRequest productRequest = dbFunctions.GetPreviousData();
                productRequest.Transactions = transactions;

                if (productRequest != null)
                {
                    loadTransactions.ProcessTransactions(productRequest);
                    File.Delete(transactionPath);
                }                
            }
            SetTimer();
        }

        public void onDebug()
        {
            OnStart(null);
        }
        

        private void GetRequests()
        {
            DbFunctions dbFunctions = new DbFunctions();
            Transactions processTransactions = new Transactions();
            ProductRequest request = dbFunctions.GetRequests();            
            
            if (request.Transactions.Count > 0)
            {
                aTimer.Stop();
                processTransactions.ProcessTransactions(request);
                dbFunctions.DeleteRequest();
                aTimer.Start();
            }           
        }

        private void SetTimer()
        {
            // Create a timer with an 15 min. interval.
            aTimer = new System.Timers.Timer(900000);
            //aTimer = new System.Timers.Timer(5000);

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            aTimer.Start();
        }

        private void OnTimer(object sender, ElapsedEventArgs args)
        {
            //Query DB for new requests
            GetRequests();
        }

        protected override void OnStop()
        {
            aTimer.Stop();
            aTimer.Dispose();
        }
    }
}
