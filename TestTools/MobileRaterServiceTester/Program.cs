using MobileRaterServiceTester.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MobileRaterServiceTester
{
    class Program
    {
        private static DirectoryInfo _outputFolderPath;
        private static bool _stripResponseIds;

        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                HelpMessage();
                return;
            }

            if(args.Length < 2 || !Directory.Exists(args[1]))
            {
                Console.WriteLine("Folder path  argument is missing or the folder does not exist.");
                Console.WriteLine(String.Empty);
                HelpMessage();
                return;
            }

            if(args.Contains("no_ids"))
            {
                _stripResponseIds = true;
            }

            // read request type from arg0
            var requestType = args[0];
            string targetEndpoint = string.Empty;

            switch (requestType)
            {
                case "I":
                    targetEndpoint = Settings.Default.IndependenceSeriesEndpoint;
                    break;
                case "P":
                    targetEndpoint = Settings.Default.PatriotSeriesEndpoint;
                    break;
                case "FT":
                    targetEndpoint = Settings.Default.FamilyTermEndpoint;
                    break;
                case "LR":
                    targetEndpoint = Settings.Default.LifeRaterEndpoint;
                    break;
                case "RR":
                    targetEndpoint = Settings.Default.ReverseRaterEndpoint;
                    break;
                default:
                    Console.WriteLine($"Invalid request type: {requestType}");
                    return;
            }

            var folderPath = args[1];

            var sourceDir = new DirectoryInfo(folderPath);

            // Set output folder path
            _outputFolderPath = sourceDir.CreateSubdirectory($"ResultSet_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}");

            // loop over files
            var files = sourceDir.GetFiles("*.json");

            Console.WriteLine($"Found {files.Count()} files in folder '{sourceDir.FullName}'.");

            foreach(var file in files)
            {
                try
                {
                    //skip pre-existing response files, if found
                    if(!file.Name.Contains("RESPONSE_"))
                    {
                        SendRequest(file, targetEndpoint);
                        Console.WriteLine($"SENT:{file.Name}");
                    }
                }
                catch
                {
                    Console.WriteLine($"ERROR:{file.Name}");
                }
            }
        }

        private static void SendRequest(FileInfo file, string endpoint)
        {
            try
            {
                var json = File.ReadAllText(file.FullName);
                
                var content = new StringContent(json, Encoding.Default, "application/json");

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(Settings.Default.BaseUrl);
                    httpClient.Timeout = new TimeSpan(0, 1, 0);

                    var requestTask = httpClient.PostAsync(endpoint, content);
                    requestTask.Wait();

                    var response = requestTask.Result;

                    response.EnsureSuccessStatusCode();

                    var contentTask = response.Content.ReadAsStringAsync();
                    contentTask.Wait();

                    var outputFile = Path.Combine(_outputFolderPath.FullName, $"RESPONSE_{file.Name}");

                    var jsonResult = JsonPrettify(contentTask.Result);

                    if(_stripResponseIds)
                    {
                        jsonResult = StripResponseIds(jsonResult);
                    }

                    File.WriteAllText(outputFile, jsonResult);
                }
            }
            catch (Exception ex)
            {
                LogIt(String.Format("Error sending {0} to server.", file.Name), ex);
            }
        }

        private static string StripResponseIds(string jsonResult)
        {
            //"recordID": "12da445d-0d63-432e-b1d2-5d7c2e89ee4b"

            return Regex.Replace(jsonResult, "\"recordID\": \"[a-z0-9-]+\"", "\"recordID\": \"\"");
        }

        private static void LogIt(string message, Exception ex)
        {
            var lines = new List<string>();

            lines.Add(message);
            if(ex != null) { lines.Add(ex.ToString()); }

            File.AppendAllLines(Settings.Default.LogFile, lines);
        }

        private static void LogIt(string message)
        {
            LogIt(message, null);
        }

        private static void HelpMessage()
        {
            Console.WriteLine("Arg0: Mobile Rater Type");
            Console.WriteLine(" I: Independence Rater");
            Console.WriteLine(" P: Patriot Series Rater");
            Console.WriteLine("FT: Family Term Rater");
            Console.WriteLine("LR: Life Rater");
            Console.WriteLine("RR: Reverse Rater");

            Console.WriteLine("");
            Console.WriteLine("Arg1: Folder path to JSON test files.");
            Console.WriteLine("Enclose in quotes if there are spaces in the folder name(s).");

            Console.WriteLine("");
            Console.WriteLine("Arg2: (optional) no_ids");
            Console.WriteLine("Strips the record ID GUIDs from the responses to making comparing easier.");
        }

        private static string JsonPrettify(string json)
        {
            using (var stringReader = new StringReader(json))
            using (var stringWriter = new StringWriter())
            {
                var jsonReader = new JsonTextReader(stringReader);
                var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = Formatting.Indented };
                jsonWriter.WriteToken(jsonReader);
                return stringWriter.ToString();
            }
        }
    }
}
