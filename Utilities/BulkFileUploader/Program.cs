using BulkFileUploader.Properties;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using WOW.Illustration.Model.Generation.Response;

namespace BulkFileUploader
{
    class Program
    {
        private static string fipIllustrationUrl = Settings.Default.IllustrationServiceUrl;
        private static bool includeProcessingTime = Settings.Default.IncludeProcessingTime;

        private static int fileCount = 0;
        private static int failCount = 0;
        private static int exceptionCount = 0;
        private static int unsupportedCount = 0;

        private static List<int> newBusinessHeaderCodes = new List<int>();
        private static List<int> inforceHeaderCodes = new List<int>();

        private static Stopwatch stopwatch = new Stopwatch();
        private static readonly ILog logger = LogManager.GetLogger(typeof(Program));

        private static DirectoryInfo _outputFolderPath;

        static void Main(string[] args)
        {
            try
            {
                LoadHeaderCodes();

                DirectoryInfo folder;

                if (args.Length == 0)
                {
                    folder = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                }
                else
                {
                    folder = new DirectoryInfo(args[0]);
                }

                _outputFolderPath = folder.CreateSubdirectory($"ResultSet_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}");

                if (Settings.Default.MovePayloadFiles)
                {
                    var tempFiles = Directory.GetFiles(Settings.Default.PayloadPath);
                    foreach (var file in tempFiles)
                    {
                        File.Delete(file);
                    }
                }
                var files = folder.GetFiles("*.fip");

                fileCount = files.Length;

                int fileNumber = 0;

                foreach (var file in files)
                {
                    try
                    {
                        ProcessFipRequestFile(file, ++fileNumber);
                    }
                    catch (Exception ex)
                    {
                        if (logger.IsErrorEnabled) logger.Error(string.Format("There was an error processing file '{0}'.", file.FullName), ex);
                    }
                }

                if (logger.IsDebugEnabled) logger.DebugFormat("Total Files: {0}, Success: {1}, Fail: {2}, Exception: {3}, Unsupported: {4}", fileCount, (fileCount - (failCount + exceptionCount)), failCount, exceptionCount, unsupportedCount);
            }
            catch (Exception ex)
            {
                if (logger.IsErrorEnabled) logger.Error("Fatal error during batch processing", ex);
            }
        }

        private static void ProcessFipRequestFile(FileInfo fipFile, int fileNumber)
        {
            var responseStatus = ResponseStatus.Success;

            if (!IsSupported(fipFile))
            {
                responseStatus = ResponseStatus.Unsupported;
                unsupportedCount++;

                if (includeProcessingTime)
                {
                    if (logger.IsWarnEnabled) logger.WarnFormat("{0:00000}: {1,-18} ({2:#####0.000000}) Status: Unsupported", fileNumber, fipFile.Name, (stopwatch.Elapsed.TotalMilliseconds / 1000D));
                }
                else
                {
                    if (logger.IsWarnEnabled) logger.WarnFormat("{0:00000}: {1,-18} Status: Unsupported", fileNumber, fipFile.Name);
                }
            }
            else
            {
                stopwatch.Start();

                var illustrationResponse = Upload(fipIllustrationUrl, fipFile);
                var partial = Path.GetFileNameWithoutExtension(fipFile.Name) + " LPA";


                // Check string content for failure
                if (illustrationResponse == null)
                {
                    responseStatus = ResponseStatus.ServiceException;
                    exceptionCount++;
                }
                else
                {
                    if (illustrationResponse.HasError)
                    {
                        responseStatus = ResponseStatus.IllustrationError;
                        failCount++;
                    }
                    else
                    {
                        // Extract files from response
                        var newPdfFileName = Path.Combine(_outputFolderPath.FullName, partial + ".pdf");
                        var newTextFileName = Path.Combine(_outputFolderPath.FullName, partial + ".txt");

                        SaveBase64EncodedFile(newPdfFileName, illustrationResponse.PdfFileAttachment);
                        SaveBase64EncodedFile(newTextFileName, illustrationResponse.ValuesFileAttachment);
                    }
                }

                if (Settings.Default.MovePayloadFiles)
                {
                    var payloadFiles = Directory.GetFiles(Settings.Default.PayloadPath, "*.payload");
                    foreach (var payloadFile in payloadFiles)
                    {
                        var myName = Path.GetFileName(payloadFile);
                        myName = myName.Remove(myName.IndexOf('_'));
                        var myPath = Path.Combine(_outputFolderPath.FullName, partial + "_" + myName + ".xml");

                        File.Move(payloadFile, myPath);
                    }
                }

                stopwatch.Stop();

                if (includeProcessingTime)
                {
                    if (logger.IsDebugEnabled) logger.DebugFormat("{0:00000}: {1,-18} ({2:#####0.000000}) Status: {3}", fileNumber, fipFile.Name, (stopwatch.Elapsed.TotalMilliseconds / 1000D), responseStatus.ToString("G"));
                }
                else
                {
                    if (logger.IsDebugEnabled) logger.DebugFormat("{0:00000}: {1,-18} Status: {2}", fileNumber, fipFile.Name, responseStatus.ToString("G"));
                }

                stopwatch.Reset();
            }
        }

        private static void SaveBase64EncodedFile(string newFilePath, string base64FileString)
        {
            try
            {
                byte[] filebytes = Convert.FromBase64String(base64FileString);

                File.WriteAllBytes(newFilePath, filebytes);
            }
            catch (Exception ex)
            {
                if (logger.IsErrorEnabled) logger.Error("Error writing base64 file to filesystem.", ex);
            }

        }

        private static void LoadHeaderCodes()
        {
            newBusinessHeaderCodes.Add(1003);
            newBusinessHeaderCodes.Add(1001);
            newBusinessHeaderCodes.Add(1004);
            newBusinessHeaderCodes.Add(1002);
            newBusinessHeaderCodes.Add(750);
            newBusinessHeaderCodes.Add(755);
            newBusinessHeaderCodes.Add(760);
            newBusinessHeaderCodes.Add(770);
            newBusinessHeaderCodes.Add(765);
            newBusinessHeaderCodes.Add(775);
            newBusinessHeaderCodes.Add(780);
            newBusinessHeaderCodes.Add(790);
            newBusinessHeaderCodes.Add(121);
            newBusinessHeaderCodes.Add(122);
            newBusinessHeaderCodes.Add(119);
            newBusinessHeaderCodes.Add(120);
            newBusinessHeaderCodes.Add(220);
            newBusinessHeaderCodes.Add(221);
            newBusinessHeaderCodes.Add(222);
            newBusinessHeaderCodes.Add(223);
            newBusinessHeaderCodes.Add(228);
            newBusinessHeaderCodes.Add(230);
            newBusinessHeaderCodes.Add(238);
            newBusinessHeaderCodes.Add(274);
            newBusinessHeaderCodes.Add(275);
            newBusinessHeaderCodes.Add(224);
            newBusinessHeaderCodes.Add(225);
            newBusinessHeaderCodes.Add(226);
            newBusinessHeaderCodes.Add(227);
            newBusinessHeaderCodes.Add(234);
            newBusinessHeaderCodes.Add(260);
            newBusinessHeaderCodes.Add(261);
            newBusinessHeaderCodes.Add(262);
            newBusinessHeaderCodes.Add(263);
            newBusinessHeaderCodes.Add(264);
            newBusinessHeaderCodes.Add(250);
            newBusinessHeaderCodes.Add(265);
            newBusinessHeaderCodes.Add(404);
            newBusinessHeaderCodes.Add(408);
            newBusinessHeaderCodes.Add(405);
            newBusinessHeaderCodes.Add(1401);
            newBusinessHeaderCodes.Add(1405);
            newBusinessHeaderCodes.Add(1402);
            newBusinessHeaderCodes.Add(1403);
            newBusinessHeaderCodes.Add(1404);
            newBusinessHeaderCodes.Add(1406);
            newBusinessHeaderCodes.Add(1407);
            newBusinessHeaderCodes.Add(1408);
            newBusinessHeaderCodes.Add(409);
            newBusinessHeaderCodes.Add(108);
            newBusinessHeaderCodes.Add(109);
            // 2017 CSO WL
            newBusinessHeaderCodes.Add(280);
            newBusinessHeaderCodes.Add(281);
            newBusinessHeaderCodes.Add(282);
            newBusinessHeaderCodes.Add(283);
            newBusinessHeaderCodes.Add(284);
            newBusinessHeaderCodes.Add(290);
            newBusinessHeaderCodes.Add(291);
            newBusinessHeaderCodes.Add(292);
            newBusinessHeaderCodes.Add(293);
            newBusinessHeaderCodes.Add(294);
            newBusinessHeaderCodes.Add(295);
            newBusinessHeaderCodes.Add(296);
            newBusinessHeaderCodes.Add(297);
            newBusinessHeaderCodes.Add(298);



            inforceHeaderCodes.Add(121);
            inforceHeaderCodes.Add(122);
            inforceHeaderCodes.Add(119);
            inforceHeaderCodes.Add(120);
            inforceHeaderCodes.Add(110);
            inforceHeaderCodes.Add(103);
            inforceHeaderCodes.Add(104);
            inforceHeaderCodes.Add(102);
            inforceHeaderCodes.Add(105);
            inforceHeaderCodes.Add(106);
            inforceHeaderCodes.Add(107);
            inforceHeaderCodes.Add(110);
            inforceHeaderCodes.Add(101);
            inforceHeaderCodes.Add(112);
            inforceHeaderCodes.Add(113);
            inforceHeaderCodes.Add(750);
            inforceHeaderCodes.Add(755);
            inforceHeaderCodes.Add(760);
            inforceHeaderCodes.Add(770);
            inforceHeaderCodes.Add(765);
            inforceHeaderCodes.Add(775);
            inforceHeaderCodes.Add(220);
            inforceHeaderCodes.Add(221);
            inforceHeaderCodes.Add(222);
            inforceHeaderCodes.Add(223);
            inforceHeaderCodes.Add(228);
            inforceHeaderCodes.Add(230);
            inforceHeaderCodes.Add(238);
            inforceHeaderCodes.Add(224);
            inforceHeaderCodes.Add(225);
            inforceHeaderCodes.Add(226);
            inforceHeaderCodes.Add(227);
            inforceHeaderCodes.Add(234);
            inforceHeaderCodes.Add(260);
            inforceHeaderCodes.Add(261);
            inforceHeaderCodes.Add(262);
            inforceHeaderCodes.Add(263);
            inforceHeaderCodes.Add(264);
            inforceHeaderCodes.Add(274);
            inforceHeaderCodes.Add(275);
            inforceHeaderCodes.Add(790);
        }

        private static bool IsSupported(FileInfo fipFile)
        {
            int headerCode = 0;
            int conceptCode = 0;

            // Read the file by line
            foreach (var line in File.ReadLines(fipFile.FullName))
            {
                var lineElements = line.Split(',');

                // Assign key to variable
                var key = lineElements[0].Trim();

                if (key.IndexOf("HeaderCode", StringComparison.OrdinalIgnoreCase) != -1)
                {
                    headerCode = Int32.Parse(lineElements[1].Trim());
                }

                if (key.IndexOf("ConceptCode", StringComparison.OrdinalIgnoreCase) != -1)
                {
                    conceptCode = Int32.Parse(lineElements[1].Trim());
                }
            }

            // Convert to int and compare to known list of supported products
            if (conceptCode == 5 && inforceHeaderCodes.Contains(headerCode))
            {
                return true;
            }

            if (conceptCode != 5 && newBusinessHeaderCodes.Contains(headerCode))
            {
                return true;
            }

            return false;
        }

        private static WoodmenIllustrationResponse Upload(string actionUrl, FileInfo file)
        {
            try
            {
                var fileBytes = File.ReadAllBytes(file.FullName);

                HttpContent bytesContent = new ByteArrayContent(fileBytes);

                using (var client = new HttpClient())
                using (var formData = new MultipartFormDataContent())
                {
                    formData.Add(bytesContent, file.Name, file.Name);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = client.PostAsync(actionUrl, formData).Result;

                    var json = response.Content.ReadAsStringAsync().Result;

                    WoodmenIllustrationResponse illustrationResponse = JsonConvert.DeserializeObject<WoodmenIllustrationResponse>(json);

                    // We need a touch of validation here. If a 500 error is thrown, this response object is in a default state.
                    if (!illustrationResponse.Equals(new WoodmenIllustrationResponse()))
                    {
                        return illustrationResponse;
                    }

                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        private enum ResponseStatus
        {
            Success,
            ServiceException,
            IllustrationError,
            Unsupported,
        }


    }
}
