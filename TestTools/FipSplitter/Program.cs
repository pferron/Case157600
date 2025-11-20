using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace FipSplitter
{
    class Program
    {
        private static bool _deleteOriginalFile;
        private static bool _addProductTypeToFileName;
        private static bool _addOriginalOutputName;
        private static bool _addStatusToFileName;

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                HelpMessage();
                return;
            }

            if (args.Length > 1)
            {
                if (!Boolean.TryParse(args[1], out _deleteOriginalFile))
                {
                    Console.WriteLine("Unable to parse second parameter.");
                }
            }

            if (args.Length > 2)
            {
                if (!Boolean.TryParse(args[2], out _addProductTypeToFileName))
                {
                    Console.WriteLine("Unable to parse third parameter.");
                }
            }

            if (args.Length > 3)
            {
                if (!Boolean.TryParse(args[3], out _addOriginalOutputName))
                {
                    Console.WriteLine("Unable to parse fourth parameter.");
                }
            }

            if (args.Length > 4)
            {
                if (!Boolean.TryParse(args[4], out _addStatusToFileName))
                {
                    Console.WriteLine("Unable to parse fifth parameter.");
                }
            }

            if (!String.IsNullOrEmpty(args[0]) && Directory.Exists(args[0]))
            {
                Console.WriteLine("Searching for *.FIP files in {0}.", args[0]);

                SplitFipFilesInFolder(args[0]);
            }

            Console.WriteLine("Done!");
        }

        private static void SplitFipFilesInFolder(string folderPath)
        {
            var dir = new DirectoryInfo(folderPath);

            var fipFiles = dir.GetFiles("*.fip");

            foreach (var file in fipFiles)
            {
                try
                {
                    // Read file into string
                    string content = File.ReadAllText(file.FullName);

                    // Check to see if there's multiple illustration requests in the file
                    if (content.LastIndexOf("[Illustration]") > 0)
                    {
                        // if so, pass file to split method
                        var fipStrings = SplitFipFile(content);

                        WriteFipFiles(dir.FullName, file.Name, fipStrings);

                        if (_deleteOriginalFile)
                        {
                            File.Delete(file.FullName);
                        }
                    }
                    else
                    {
                        var prefix = string.Empty;

                        // Rename single request FIP files, if requested
                        if (_addProductTypeToFileName)
                        {
                            prefix = GetProductTypeCode(content) + "_";
                        }

                        if (_addStatusToFileName)
                        {
                            prefix = GetStatus(content) + "_" + prefix;
                        }

                        if (_addOriginalOutputName)
                        {
                            prefix = GetOriginalOutputFileName(content) + "_" + prefix;
                        }

                        // Only rename the file if the name wil change.
                        if (prefix.Length > 0)
                        {
                            var newFullFilePath = Path.Combine(file.DirectoryName, prefix + file.Name);

                            File.Move(file.FullName, newFullFilePath);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error splitting file '{0}'.", file.FullName);
                    Console.WriteLine("Error: {0}", ex);
                }
            }
        }

        private static void WriteFipFiles(string folderPath, string originalFileName, IEnumerable<string> fipStrings)
        {
            var filecount = 0;

            try
            {
                foreach (var fip in fipStrings)
                {
                    // Add file count to string for crafting the new file name
                    var fileNamePrefix = String.Empty;
                    var fileNameSuffix = String.Format("-{0:0000}.fip", ++filecount);

                    if (_addProductTypeToFileName)
                    {
                        fileNamePrefix = GetProductTypeCode(fip) + "_";
                    }

                    if (_addStatusToFileName)
                    {
                        fileNamePrefix = GetStatus(fip) + "_" + fileNamePrefix;
                    }

                    if (_addOriginalOutputName)
                    {
                        fileNamePrefix = GetOriginalOutputFileName(fip) + "_" + fileNamePrefix;
                    }

                    // Replace the existing .FIP extension with the new string with extension
                    // Add prefix based on CategoryCode
                    var newFileName = fileNamePrefix + Path.GetFileNameWithoutExtension(originalFileName) + fileNameSuffix;

                    // Combine new file name with folder path
                    var newFilePath = Path.Combine(folderPath, newFileName);

                    // Write the fip request to the new file
                    File.WriteAllText(newFilePath, fip);
                }
            }
            catch
            {
                throw;
            }
        }

        private static string GetOriginalOutputFileName(string fip)
        {
            string fileName = string.Empty;
            Match match = Regex.Match(fip, @"outputName[ ]*,[ ]*(Illus_[0-9]+)", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                fileName = match.Groups[1].Value;
            }
            return fileName;
        }

        private static string GetStatus(string fip)
        {
            string status = string.Empty;
            Match match = Regex.Match(fip, @"ConceptCode[ ]*,[ ]*([0-9]+)", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                var statusCode = match.Groups[1].Value;
                if ("1".Equals(statusCode))
                {
                    status = "NewBiz";
                }
                else if ("5".Equals(statusCode))
                {
                    status = "Inforce";
                }
                else
                {
                    status = "Unknown";
                }
            }
            return status;
        }

        private static string GetProductTypeCode(string fip)
        {
            Match match = Regex.Match(fip, @"CategoryCode[ ]*,[ ]*([0-9]+)", RegexOptions.IgnoreCase);
            Match match2 = Regex.Match(fip, @"HeaderCode[ ]*,[ ]*([0-9]+)", RegexOptions.IgnoreCase);

            int headerCode = 0;
            if (match2.Success)
            {
                headerCode = int.Parse(match2.Groups[1].Value);
            }

            // Here we check the Match instance.
            if (match.Success)
            {
                // Finally, we get the Group value and display it.
                string categoryCode = match.Groups[1].Value;

                switch (categoryCode)       // magic numbers
                {
                    case "3":
                        if (headerCode == 119 || headerCode == 120)
                        {
                            return "NLGUL";
                        }
                        else if (headerCode == 121 || headerCode == 122)
                        {
                            return "AUL";
                        }
                        return "UL";

                    case "4":
                        if (headerCode == 780)
                        {
                            return "FT";
                        }
                        else if (headerCode == 790)
                        {
                            return "YT";
                        }
                        return "TERM";

                    case "6":
                        return "ANN";

                    case "8":
                        return "WL";

                    case "10":
                        if (headerCode == 1001)
                        {
                            return "FPDA-NB";
                        }
                        else if (headerCode == 1002)
                        {
                            return "FPDA-B";
                        }
                        else if (headerCode == 1003)
                        {
                            return "SPDA-NB";
                        }
                        else if (headerCode == 1004)
                        {
                            return "SPDA-B";
                        }
                        return "ANN";

                    default:
                        return "UNK";
                }
            }
            else
            {
                return "404";
            }
        }

        private static IEnumerable<string> SplitFipFile(string content)
        {
            try
            {
                // List for extracted fip requests
                var fipList = new List<string>();

                // Split citeria
                string[] splitOn = new string[] { "[Illustration]", "[ILLUSTRATION]", "[illustration]" };

                // Split on [Illustration] node
                var fipRequests = content.Split(splitOn, StringSplitOptions.RemoveEmptyEntries);

                foreach (var fipRequest in fipRequests)
                {
                    // Re-append [Illustration] node and add to list
                    fipList.Add("[Illustration]" + fipRequest);
                }

                return fipList;
            }
            catch
            {
                throw;
            }
        }

        private static void HelpMessage()
        {
            Console.WriteLine("Pass a folder path as the first argument.");
            Console.WriteLine("The utility will attempt to split any *.FIP files found in the folder into separate files.");
            Console.WriteLine("Pass 'true' for second argument if you want to delete the original FIP file after splitting.");
            Console.WriteLine("Pass 'true' for the third argument if you want the prefix each FIP with a product type indicator.");
            Console.WriteLine("Pass 'true' for the fourth argument if you want the prefix each FIP with the output name specified in its contents.");
            Console.WriteLine("Pass 'true' for the fifth argument if you want to include the policy status (New Biz/Inforce) in the name of the file.");
        }
    }
}
