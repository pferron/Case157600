using System;
using System.Collections.Generic;
using System.IO;

namespace FipParserTester
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                HelpMessage();
                return;
            }

            if (!String.IsNullOrEmpty(args[0]) && Directory.Exists(args[0]))
            {
                Console.WriteLine("Searching for *.FIP files in {0}.", args[0]);

                ProcessFipFilesInFolder(args[0]);
            }

            Console.WriteLine("Done!");
        }

        private static void ProcessFipFilesInFolder(string folderPath)
        {
            try
            {
                var dir = new DirectoryInfo(folderPath);

                var fipFiles = dir.GetFiles("*.fip");

                foreach (var file in fipFiles)
                {
                    try
                    {
                        string content = String.Empty;
                        var fipRequests = new List<string>();
                        string[] splitOn = new string[] { "[Illustration]", "[ILLUSTRATION]", "[illustration]" };

                        using (StreamReader streamReader = new StreamReader(file.FullName))
                        {
                            content = streamReader.ReadToEnd();
                        }

                        // Check to see if file contains more than one FIP
                        if (content.LastIndexOf("[Illustration]") > 0)
                        {
                            // Split on [Illustration] node
                            var temp = content.Split(splitOn, StringSplitOptions.RemoveEmptyEntries);

                            // Re-append [Illustration] node and add to list
                            foreach (var fipRequest in temp)
                            {
                                fipRequests.Add("[Illustration]" + fipRequest);
                            }

                        }
                        else
                        {
                            fipRequests.Add(content);
                        }

                        foreach (var fipRequest in fipRequests)
                        {
                            var policy = WOW.FipUtilities.FipParser.Parse(fipRequest);

                            Console.WriteLine("File '{0}' : PolicyType '{1}'", file.FullName, policy.GetType());
                            LogOutput(file.FullName, policy.GetType().ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("File '{0}' : PolicyType '{1}'", file.FullName, "Parsing Error");
                        LogOutput(file.FullName, ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex);
            }
        }

        private static void HelpMessage()
        {
            Console.WriteLine("Pass a folder path as the first argument. The utility will attempt to parse all *.FIP files found in the folder.");
        }

        private static void LogOutput(string filename, string result)
        {
            using (StreamWriter writer = new StreamWriter("result.txt", true))
            {
                writer.WriteLine("{0}: File '{1}'", DateTime.Now, filename);
                writer.WriteLine("Result: '{0}'", result);
            }
        }
    }
}
