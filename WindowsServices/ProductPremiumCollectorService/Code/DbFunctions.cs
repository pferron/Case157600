using System;
using System.Data.SqlClient;
using log4net;
using ProductPremiumCollectorService.Properties;
using System.Linq;
using ProductPremiumCollectorService.Models;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Data;

namespace ProductPremiumCollectorService.Code
{    
    public class DbFunctions
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(DbFunctions));
        private static MobileRaterClient _client;

        public void DeleteRequest()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Settings.Default.DbConnectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlDelete = new SqlCommand("DELETE from PremiumCollectorRequests WHERE Status = 1", sqlConnection))
                    {
                        sqlDelete.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);

                var recipients = Properties.Settings.Default.EmailList.Cast<string>().ToArray();
                SmtpHelper.Send(recipients, "Product Premium Collector Service DB Error", "Error Deleting Request: " + ex.Message, true);
            }            
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


        public void StoreResults(IEnumerable<Transaction> transactions)
        {
            string transactionPath = Path.Combine(Settings.Default.TransactionPath, "last.json");
            //string transactionPath = "last.json";

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

                File.Delete(transactionPath);
                File.WriteAllText(transactionPath, JsonConvert.SerializeObject(data));

                using (var connection = new SqlConnection(Settings.Default.DbConnectionString))
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

                log.Debug($"Done saving to db {DateTime.Now}");
            }
            catch (Exception ex)
            {
                log.Error(ex);

                var recipients = Properties.Settings.Default.EmailList.Cast<string>().ToArray();
                SmtpHelper.Send(recipients, "Product Premium Collector Service DB Error", "Error Storing Results: " + ex.Message, true);
            }
        }

        public void UpdateQuotes()
        {
            try
            {
                string sqlUpdateString = @"UPDATE dbo.ProductQuotes 
                                    SET 
	                                    Quote = sp.Quote, DateCalculated = CONVERT(date, getdate()) 
                                    FROM 
	                                    dbo.ProductQuotes pq
                                    INNER JOIN
                                        Shadow.ProductQuotes sp
                                    ON 
                                        pq.Age = sp.Age and
	                                    pq.AioGir = sp.AioGir and
	                                    pq.BillType = sp.BillType and
	                                    pq.FaceAmount = sp.FaceAmount and
	                                    pq.Gender = sp.Gender and
	                                    pq.PaymentMode = sp.PaymentMode and
	                                    pq.ProductName = sp.ProductName and
	                                    pq.Tobacco = sp.Tobacco";

                using (SqlConnection sqlConnection = new SqlConnection(Settings.Default.DbConnectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlUpdate = new SqlCommand(sqlUpdateString, sqlConnection))
                    {
                        sqlUpdate.ExecuteNonQuery();
                    }

                    sqlUpdateString = "truncate table shadow.productquotes"; 

                    using (SqlCommand sqlTruncate = new SqlCommand(sqlUpdateString, sqlConnection))
                    {
                        sqlTruncate.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);

                var recipients = Properties.Settings.Default.EmailList.Cast<string>().ToArray();
                SmtpHelper.Send(recipients, "Product Premium Collector Service DB Error", "Error Updating Quotes: " + ex.Message, true);

            }
            
        }

        public ProductRequest GetPreviousData()
        {
            ProductRequest request = new ProductRequest();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Settings.Default.DbConnectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("SELECT top 1 HeaderCode, RateDeterminationDate FROM PremiumCollectorRequests WHERE Status = 1", sqlConnection))
                    {
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            {
                                // Grabbing 1 request...delete after getting requests
                                _client = new MobileRaterClient(Settings.Default.MobileRaterService_BaseURL, "api/Rate/FetchLifeRatesByHeaderCode", new TimeSpan(0, 1, 0));

                                request.HeaderCode = sqlDataReader.GetInt32(0);
                                request.RateDeterminationDate = sqlDataReader.GetDateTime(1);
                            }
                        }
                    }
                }

                return request;
            }   
            catch(Exception ex)
            {
                log.Error(ex);

                var recipients = Properties.Settings.Default.EmailList.Cast<string>().ToArray();
                SmtpHelper.Send(recipients, "Product Premium Collector Service DB Error", "Error Getting Previous Data: " + ex.Message, true);
                return null;
            }              
        }

        public ProductRequest GetRequests()
        {
            int id = 0;
            Transactions policyTransactions = new Transactions();
            List<Transaction> transactions = new List<Transaction>();
            ProductRequest request = new ProductRequest();
            var recipients = Properties.Settings.Default.EmailList.Cast<string>().ToArray();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Settings.Default.DbConnectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("SELECT top 1 Id, HeaderCode, MinAge, MaxAge, MinFaceAmount, MaxFaceAmount, RateDeterminationDate FROM PremiumCollectorRequests", sqlConnection))
                    {
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            {
                                // Grabbing 1 request...delete after getting requests
                                _client = new MobileRaterClient(Settings.Default.MobileRaterService_BaseURL, "api/Rate/FetchLifeRatesByHeaderCode", new TimeSpan(0, 1, 0));
                                                                
                                request.HeaderCode = sqlDataReader.GetInt32(1);
                                request.StartingAge = sqlDataReader.GetInt32(2);
                                request.MaxAge = sqlDataReader.GetInt32(3);
                                request.StartingFaceAmount = sqlDataReader.GetInt32(4);
                                request.MaxFaceAmount = sqlDataReader.GetInt32(5);
                                request.RateDeterminationDate = sqlDataReader.GetDateTime(6);

                                id = sqlDataReader.GetInt32(0);

                                SmtpHelper.Send(recipients, "Product Premium Collector Status", "Processing Request: " + request.ToString(),true);

                                // Load collection of request parameters
                                request.Transactions = policyTransactions.GenerateTransactions(request);                                
                            }
                        }
                    }

                    using (SqlCommand sqlDelete = new SqlCommand("UPDATE PremiumCollectorRequests Set Status = 1 WHERE Id = @p0", sqlConnection))
                    {
                        SqlParameter param0 = new SqlParameter("@p0", id);
                        sqlDelete.Parameters.Add(param0);

                        sqlDelete.ExecuteNonQuery();
                    }
                }

                return request;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                                
                SmtpHelper.Send(recipients, "Product Premium Collector Service DB Error", "Error Getting Requests: " + ex.Message, true);
                return request;
            }            
        }
    }
}
