using CsvHelper;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using PlanDBLoader.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlanDBLoader.Code
{
    public  class PlansDBInterations
    {
        #region Private Members
        /// <summary>
        /// A token for cancelling a task.
        /// </summary>
        private static CancellationTokenSource _tokenSource = new CancellationTokenSource();

        private  string _filePath;
        private  string _folderPath;
        private  HashSet<TableModel> _tables;
        private  List<string> _goodTables = new List<string> { "RateData", "RateDataByYear" };
        private  string _deploySqlFilePath;
        private  string _planCreateSqlFilePath;
        #endregion

        /// <summary>
        /// Event handler only fired on a successful completion of a plans db split
        /// </summary>
        public static event EventHandler PlansSplitComplete;

        /// <summary>
        /// The event fired when a cancel has been successfully processed.
        /// (note a call to the cancel method may not yield a cancel event, 
        /// if a long running task has already been completed
        /// the class will continue execution)
        /// </summary>
        public static event EventHandler CancelledEvent;

        /// <summary>
        /// The event periodically as the program
        /// runs
        /// </summary>
        public static event EventHandler StatusUpdate;

        /// <summary>
        /// Split the plans database file into csv files based on their table name
        /// </summary>
        /// <param name="filePath">the path to the sql file</param>
        /// <param name="outputFolderPath">the output folder for the csv files</param>
        public async Task SplitAsync(string filePath, string outputFolderPath)
        {
            if(Directory.Exists("Output"))
                Directory.Delete("Output",true);
           

            //null and file checks
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Unable to locate the file provided");

            _folderPath = outputFolderPath ?? throw new ArgumentNullException(nameof(outputFolderPath));
            _filePath = filePath;

            var deployPath = Path.Combine(_folderPath, "deploy.sql");
            var plansPath = Path.Combine(_folderPath, "Plans", "Client_PlansData_Create.sql");

            //locate files
            if (!File.Exists(deployPath))
                throw new FileNotFoundException($"Unable to find {deployPath}");
            if(!File.Exists(plansPath))
                throw new FileNotFoundException($"Unable to find {plansPath}");

            _deploySqlFilePath = deployPath;
            _planCreateSqlFilePath = plansPath;

            //get a cancel token source
            _tokenSource = new CancellationTokenSource();
            _tables = new HashSet<TableModel>();
            await EvaluateAsync();
        }

        private async Task RecreateDatabase()
        {
            //string sqlConnectionString = @"Data Source=localhost\sqlexpress; Initial Catalog=WOWPlans_DEV; Integrated Security=True";
            string sqlConnectionString = @"Server=localhost\sqlexpress;Database=WOWPlans_DEV;Trusted_Connection=True;Encrypt=False";

            string dropScript = File.ReadAllText(@"C:\Temp\LPA_DB_Work\Deploy_Dev.sql");
            string tablesCreateScript = File.ReadAllText(@"C:\Temp\LPA_DB_Work\Plans\PlansTables_Create.sql");
            string viewsCreateScript = File.ReadAllText(@"C:\Temp\LPA_DB_Work\Plans\PlansViews_Create.sql");
            string planDataScript = File.ReadAllText(@"C:\Temp\LPA_DB_Work\Plans\new.sql");

            try
            {
                Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(sqlConnectionString);

                Server server = new Server(new ServerConnection(conn));

                server.ConnectionContext.ExecuteNonQuery(dropScript);
                server.ConnectionContext.ExecuteNonQuery(tablesCreateScript);
                server.ConnectionContext.ExecuteNonQuery(viewsCreateScript);
                server.ConnectionContext.ExecuteNonQuery(planDataScript);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        /// <summary>
        /// Execute the Deploy.SQL Path at <see cref="_deploySqlFilePath"/>
        /// </summary>
        private async Task ExecuteSQLDeployment(string rateData, string rateDataByYear)
        {            
            using (var reader = new StringReader(rateData))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                // Do any configuration to `CsvReader` before creating CsvDataReader.
                using (var dr = new CsvDataReader(csv))
                {
                    var dt = new DataTable();
                    dt.Load(dr);

                    foreach (DataColumn column in dt.Columns)
                    {
                        column.ColumnName = column.ColumnName.Trim();
                    }

                    using (var rateDataCopy = new SqlBulkCopy(@"Data Source=localhost\sqlexpress; Initial Catalog=WOWPlans_DEV; Integrated Security=True"))
                    {
                        rateDataCopy.DestinationTableName = "dbo.RateData";
                        // Add mappings so that the column order doesn't matter
                        rateDataCopy.ColumnMappings.Add(dt.Columns["RateDataID"].ColumnName, "RateDataID");
                        rateDataCopy.ColumnMappings.Add(dt.Columns["RateCode"].ColumnName, "RateCode");
                        rateDataCopy.ColumnMappings.Add(dt.Columns["Age"].ColumnName, "Age");
                        rateDataCopy.ColumnMappings.Add(dt.Columns["Sex"].ColumnName, "Sex");
                        rateDataCopy.ColumnMappings.Add(dt.Columns["Class"].ColumnName, "Class");
                        rateDataCopy.ColumnMappings.Add(dt.Columns["Band"].ColumnName, "Band");
                        rateDataCopy.ColumnMappings.Add(dt.Columns["Rate1"].ColumnName, "Rate1");
                        rateDataCopy.ColumnMappings.Add(dt.Columns["Rate2"].ColumnName, "Rate2");
                        rateDataCopy.ColumnMappings.Add(dt.Columns["Rate3"].ColumnName, "Rate3");
                        rateDataCopy.ColumnMappings.Add(dt.Columns["Rate4"].ColumnName, "Rate4");
                        rateDataCopy.ColumnMappings.Add(dt.Columns["Rate5"].ColumnName, "Rate5");
                        rateDataCopy.ColumnMappings.Add(dt.Columns["Rate6"].ColumnName, "Rate6");
                        rateDataCopy.ColumnMappings.Add(dt.Columns["Rate7"].ColumnName, "Rate7");
                        rateDataCopy.ColumnMappings.Add(dt.Columns["Rate8"].ColumnName, "Rate8");
                        rateDataCopy.ColumnMappings.Add(dt.Columns["Rate9"].ColumnName, "Rate9");
                        rateDataCopy.ColumnMappings.Add(dt.Columns["Rate10"].ColumnName, "Rate10");

                        rateDataCopy.WriteToServer(dt);
                    }
                }
            }

            using (var readerRateDataByYear = new StringReader(rateDataByYear))
            using (var csvRateDataByYear = new CsvReader(readerRateDataByYear, CultureInfo.InvariantCulture))
            {
                // Do any configuration to `CsvReader` before creating CsvDataReader.
                using (var drRateDataByYear = new CsvDataReader(csvRateDataByYear))
                {
                    var dtRateDataByYear = new DataTable();
                    dtRateDataByYear.Load(drRateDataByYear);


                    foreach (DataColumn column in dtRateDataByYear.Columns)
                    {
                        column.ColumnName = column.ColumnName.Trim();
                    }

                    using (var rateDataByYearCopy = new SqlBulkCopy(@"Data Source=localhost\sqlexpress; Initial Catalog=WOWPlans_DEV; Integrated Security=True"))
                    {
                        rateDataByYearCopy.DestinationTableName = "dbo.RateDataByYear";
                        // Add mappings so that the column order doesn't matter
                        rateDataByYearCopy.ColumnMappings.Add(dtRateDataByYear.Columns["RateDataByYearID"].ColumnName, "RateDataByYearID");
                        rateDataByYearCopy.ColumnMappings.Add(dtRateDataByYear.Columns["RateCode"].ColumnName, "RateCode");
                        rateDataByYearCopy.ColumnMappings.Add(dtRateDataByYear.Columns["Age"].ColumnName, "Age");
                        rateDataByYearCopy.ColumnMappings.Add(dtRateDataByYear.Columns["Sex"].ColumnName, "Sex");
                        rateDataByYearCopy.ColumnMappings.Add(dtRateDataByYear.Columns["Class"].ColumnName, "Class");
                        rateDataByYearCopy.ColumnMappings.Add(dtRateDataByYear.Columns["Band"].ColumnName, "Band");
                        rateDataByYearCopy.ColumnMappings.Add(dtRateDataByYear.Columns["Year"].ColumnName, "Year");
                        rateDataByYearCopy.ColumnMappings.Add(dtRateDataByYear.Columns["Rate1"].ColumnName, "Rate1");
                        rateDataByYearCopy.ColumnMappings.Add(dtRateDataByYear.Columns["Rate2"].ColumnName, "Rate2");
                        rateDataByYearCopy.ColumnMappings.Add(dtRateDataByYear.Columns["Rate3"].ColumnName, "Rate3");
                        rateDataByYearCopy.ColumnMappings.Add(dtRateDataByYear.Columns["Rate4"].ColumnName, "Rate4");
                        rateDataByYearCopy.ColumnMappings.Add(dtRateDataByYear.Columns["Rate5"].ColumnName, "Rate5");
                        rateDataByYearCopy.ColumnMappings.Add(dtRateDataByYear.Columns["Rate6"].ColumnName, "Rate6");
                        rateDataByYearCopy.ColumnMappings.Add(dtRateDataByYear.Columns["Rate7"].ColumnName, "Rate7");
                        rateDataByYearCopy.ColumnMappings.Add(dtRateDataByYear.Columns["Rate8"].ColumnName, "Rate8");
                        rateDataByYearCopy.ColumnMappings.Add(dtRateDataByYear.Columns["Rate9"].ColumnName, "Rate9");
                        rateDataByYearCopy.ColumnMappings.Add(dtRateDataByYear.Columns["Rate10"].ColumnName, "Rate10");

                        rateDataByYearCopy.WriteToServer(dtRateDataByYear);
                    }
                }
            }

            _tables.Clear();
        }

        /// <summary>
        /// Evaluate the plans db file
        /// </summary>
        private  async Task EvaluateAsync()
        {
            StatusUpdate.Invoke("Starting file evaluation", EventArgs.Empty);
            var outputDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Output");
            Directory.CreateDirectory(outputDirectory);
            using (FileStream fs = File.Open(_filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            using (StreamWriter sw = new StreamWriter("Output\\new.sql"))
            {
                var tableNameRegex = new Regex(@"[^A-Za-z0-9]+", RegexOptions.Compiled);
                var headersRegex = new Regex(@"[\[\]()']+", RegexOptions.Compiled);
                var valuesRegex = new Regex(@"[\[\]']+", RegexOptions.Compiled);
                var valueSeperateRegex = new Regex("VALUES", RegexOptions.Compiled);

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    try
                    {
                        // simple make sure that we have not been cancelled.
                        if (_tokenSource.Token.IsCancellationRequested)
                        {
                            CancelledEvent.Invoke(null, EventArgs.Empty);
                            throw new OperationCanceledException("Hi I am a friendly operation cancelled exception. Ignore me.");
                        }

                        if (line.Length < 6)
                        {
                            sw.WriteLine(line);
                            continue;
                        }
                        if (line.ToLower().Substring(0, 6) != "insert")
                        {
                            sw.WriteLine(line);
                            continue;
                        }


                        //split the line at the . and the first word will be the table name
                        var lineParts = line.Split(new[] { '.' }, 2);

                        //The table name is enclosed in [] 
                        var tableName = lineParts[1].Substring(0, lineParts[1].IndexOf('('));
                        tableName = tableNameRegex.Replace(tableName, "");//Regex.Replace(tableName, @"[^A-Za-z0-9]+", "").Trim();
                        //tableName = tableName.ToLower();

                        //if the table is on the good table list create a csv file for it
                        //otherwise write the line and move on
                        if (!_goodTables.Contains(tableName))
                        {
                            sw.WriteLine(line);
                            continue;
                        }

                        var tableObject = new TableModel
                        {
                            TableName = tableName,
                            Header = new HashSet<string>(),
                            Values = new HashSet<TableValuesModel>()
                        };

                        foreach (var item in _tables)
                        {
                            if (item.TableName.ToLower() == tableName.ToLower())
                            {
                                tableObject = item;
                                break;
                            }
                        }


                        var values = valueSeperateRegex.Split(lineParts[1], 2);//Regex.Split(lineParts[1],"values", RegexOptions.IgnoreCase, 2);//lineParts[1].ToLower().Split(new string[] { "values" }, StringSplitOptions.None);
                        var newValues = valuesRegex.Replace(values[1], "");//Regex.Replace(values[1], @"[\[\]']+", "");

                        var valuesList = new TableValuesModel { Values = new List<object>() };

                        var interpretedValues = values[1].Substring(values[1].IndexOf('(')).Split(',');

                        foreach (var item in interpretedValues)
                        {
                            var newItem = item.Trim() ;

                            if (newItem.StartsWith("("))
                                newItem = newItem.Substring(1);

                            if (newItem.EndsWith(")"))
                                newItem = newItem.Substring(0, item.Length - 2);

                            valuesList.Values.Add(newItem);
                        }

                        

                        tableObject.Values.Add(valuesList);

                        var headers = values[0].Substring(values[0].IndexOf('('));
                        headers = headersRegex.Replace(headers, "");//Regex.Replace(headers, @"[\[\]()']+", "");
                        var newHeaders = headers.Split(',');

                        if (tableObject.Header.Count == 0)
                            //unfortunately hashsets do not have the .AddRange extension method so we are going to
                            //do it the old way
                            for (int i = 0; i < newHeaders.Length; i++)
                                tableObject.Header.Add(newHeaders[i]);

                        _tables.Add(tableObject);

                    }
                    catch (OperationCanceledException)
                    {
                        throw new OperationCanceledException();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Unable to read file", ex);
                    }
                }
                
            }
            await CreateCSV();
        }

        private  async Task CreateCSV()
        {
            StatusUpdate.Invoke("Creating DB", EventArgs.Empty);

            StringBuilder csvData = new StringBuilder();
            string rateData = "";
            string rateDataByYear = "";

            //new ParallelOptions { MaxDegreeOfParallelism = 5 },
            Parallel.ForEach(_tables,   item => {
                try
                {
                    var lines = new List<string>();
                    lines.Add(string.Join(",", item.Header));
                    foreach (var value in item.Values)
                    {
                        if (_tokenSource.Token.IsCancellationRequested)
                        {
                            CancelledEvent.Invoke(null, EventArgs.Empty);
                            throw new OperationCanceledException("Hi I am a friendly operation cancelled exception. Ignore me.");
                        }

                        lines.Add(string.Join(",", value.Values));
                    }

                    csvData = new StringBuilder();

                    using (var sw = new StringWriter(csvData))
                    {
                        foreach (var line in lines)
                        {
                            if (_tokenSource.Token.IsCancellationRequested)
                            {
                                CancelledEvent.Invoke(null, EventArgs.Empty);
                                throw new OperationCanceledException("Hi I am a friendly operation cancelled exception. Ignore me.");
                            }

                            sw.WriteLine(line);
                        }

                        switch (item.TableName)
                        {
                            case "RateData":
                                rateData = sw.ToString();
                                break;

                            case "RateDataByYear":
                                rateDataByYear = sw.ToString();                                

                                break;
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                }
                catch (Exception ex)
                {
                    throw new Exception("unable to table",ex);
                }
            });

            PlansSplitComplete.Invoke(null, EventArgs.Empty);

            await RecreateDatabase();
            await ExecuteSQLDeployment(rateData, rateDataByYear);
        }

        /// <summary>
        /// Cancel the process of a plans db file.
        ///(note a call to the cancel method may not yield a cancel event, 
        /// if a long running task has already been completed
        /// the class will continue execution)
        /// </summary>
        public static void Cancel()
        {
            //cancel the token.
            _tokenSource.Cancel();
        }
    }
}
