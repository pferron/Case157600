using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace WOW.LifePortaitsWebServiceTester
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Count() == 0)
                {
                    // Write out usage instructions and exit
                    Console.WriteLine("This utility will pass ACORD XML files from a folder{0}to the LPA web service on LPAT1.", Environment.NewLine);
                    Console.WriteLine("The results will be written to a user-specified file.{0}", Environment.NewLine);
                    Console.WriteLine("Arg1: Path to folder containing ACORD TX111 XML files to transmit.");
                    Console.WriteLine("Arg2: Path to file to write the results to.");

                    return;
                }

                // Validation!
                if (!ValidateArgs(args))
                {
                    Console.WriteLine("The parameters provided were not valid.");
                    for (int x = 0; x < args.Length; x++)
                    {
                        Console.WriteLine("Arg {0}: {1}", x, args[x]);
                    }
                }

                // If the args are good, move the values to more readable variables
                var xmlSourceFolder = args[0];
                var resultsFilePath = args[1];

                // Reusable XML document object for loading files from the filesystem.
                var xmlDoc = new XmlDocument();

                // Query the filesystem for XML files
                var sourceDir = new DirectoryInfo(xmlSourceFolder);
                var xmlFiles = sourceDir.GetFiles("*.xml");

                Console.WriteLine("{0} request files found. Transmitting...", xmlFiles.Count());

                // New client
                //var client = new LifePortraitsGatewayServiceReference.GatewayServiceClient("BasicHttpBinding_IGatewayService");
                var client = new LifePortraitsGatewayServiceReference.GatewayServiceClient("NetTcpBinding_IGatewayService");

                var stopwatch = Stopwatch.StartNew();

                foreach (var xmlFile in xmlFiles)
                {
                    xmlDoc.Load(xmlFile.FullName);

                    var response = client.processXmlRequest(XElement.Parse(xmlDoc.OuterXml));

                    LogResponse(resultsFilePath, response.ToString(SaveOptions.DisableFormatting));
                }

                stopwatch.Stop();

                Console.WriteLine("Processed {0} files in {1} milliseconds.", xmlFiles.Count(), stopwatch.ElapsedMilliseconds);

                // Calculate average time per request
                decimal avg = (decimal)stopwatch.ElapsedMilliseconds / (decimal)xmlFiles.Count();

                Console.WriteLine("Averaging {0:0.0} milliseconds per request.", avg);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing XML requests:");
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Simple logging method. Writes the string content to the file specified.
        /// </summary>
        /// <param name="filePath">Path to file to append to</param>
        /// <param name="content">String content to write to file</param>
        private static void LogResponse(string filePath, string content)
        {
            try
            {
                using (var log = new StreamWriter(filePath, true))
                {
                    log.WriteLine(content);
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Simple validation routine for the passed in values.
        /// </summary>
        /// <param name="args">The parameters passed to the application.</param>
        /// <returns>True, if the args are good; false, if they are invalid.</returns>
        private static bool ValidateArgs(string[] args)
        {
            // If no args are passed, the app writes a help message and exits
            // so, at this point, there should be at exactly two args.
            if (args.Length != 2)
            {
                return false;
            }

            for (int x = 0; x < args.Length; x++)
            {
                // Check for missing or null values
                if (String.IsNullOrEmpty(args[x])) return false;

                // Check that target directory exists
                if (x == 0 && !Directory.Exists(args[x]))
                {
                    return false;
                }

                // Results file doesn't have to exist, so don't check for it.
                // If there's a problem writing it, we'll throw an exception at that point.
            }

            // Default return value
            return true;
        }
    }
}
