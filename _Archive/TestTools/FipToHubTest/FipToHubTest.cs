using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Newtonsoft.Json;
using SoftwareLF.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Wow.CommonIllustrationService.DAO;
using Wow.IllustrationCommonModels.Request;
using static System.IO.Path;
using FipToHubTest.Properties;

namespace HubIllustrationServiceTest
{
    public class FipToHubTesT
    {
        static private void RenameFiles(string folder)
        {
            var re = new Regex(@"^(\d{5}-)(\d+)(.+$)");
            var arr = Directory.GetFiles(folder);
            Match m;
            string name;            
            foreach (var file in arr)
            {
                name = GetFileName(file);
                m = re.Match(name);
                if (m.Success)
                    File.Move(file, Combine(folder, $"{m.Groups[1].Value}{int.Parse(m.Groups[2].Value):000}{m.Groups[3].Value}"));
            }
        }
        static private string InputFolder, OutputFolder;
        static private List<(string, int)> Fipslist;
        static private Regex rePretty = new Regex(@"(\{|\}|\[|\]|,)");
        static private Regex reImportId = new Regex(@"^Illus_(\d+)$");
        static private HubClient hubClient = new HubClient();
        static private WisClient wisClient = new WisClient();
        static ConsoleLog logger;
        //static string LogLineFormat;     // to control Log printing
        static void Main(string[] args)
        {
            //string str = FipToHubTest.JsonTest.Serialize();


            InputFolder = Settings.Default.InputFipFilePath;
            OutputFolder = Settings.Default.OutputFolder;

            //string iulrequest = File.ReadAllText(args[0]);
            //var tsk = IllustrationFromHUBServer(iulrequest, "", "Api/Illustrations/IULIllustration");
            //tsk.Wait();

            //RenamePropertyName("'IsRevisedIllustration':", "'RevisedIllustrationIndicator':");

            //
            // Input & output folder configured
            // Args: single: is the name of the (headered) csv containing a list of runid,index
            //       two: runid & runindex of the FIP
            //
            //RenameFiles(OutputFolder);
            if (args.Length==0 || args.Length > 2)
            {
                Console.WriteLine("wrong number of arguments");
                return;
            }
            if (args.Length == 1)
                if (!File.Exists(Combine(InputFolder, args[0])))
                {
                    Console.WriteLine("Input file doesn't exist");
                    return;
                }
                else
                {
                    Fipslist = ImportInput(Combine(InputFolder, args[0]));
                    if (Fipslist == null)
                        return;
                }
            else
            {
                int index;
                if (int.TryParse(args[1], out index) && index > 0 && File.Exists(Combine(InputFolder, args[0])))
                {
                    Fipslist = new List<(string, int)>();
                    Fipslist.Add((args[0], index));
                }
                else
                {
                    Console.WriteLine("File doesn't exist or position is wrong");
                    return;
                }
            }
            //ExtractFip(Fipslist);
            var settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.All;
            PdfReader.unethicalreading = true;
            PdfReader.debugmode = true;
            logger = new ConsoleLog(OutputFolder, System.Reflection.Assembly.GetEntryAssembly().GetName().Name);

            //int windowWidth;
            logger.WindowWidth = 80;

            //Wow.CommonIllustrationService.DAO.EntitiesRepository.Create();
            var converter = new HubRequestFromFip(EntitiesRepository.Conversions);
            foreach (var couple in Fipslist)
            {
                string AddFipExtension(string name)
                {
                    if (GetExtension(name) == "")
                        return name + ".fip";
                    else
                        return name;
                }

                string FipName = couple.Item1;
                int FipIndex = couple.Item2;
                string runindex = $"{FipIndex:000}";
                string fiptext = null;
                string root = null;
                string absroot = null;
                try
                {
                    var extraction = new ExtractOneFipFromMany(Combine(InputFolder, AddFipExtension(FipName)));
                    fiptext = extraction.Position(FipIndex);
                    if (fiptext == null)
                    {
                        logger.Log("Fip with index {FipIndex} is not present");
                        continue;
                    }
                    string pdfname = null, hubtext = null, ImportId="";
                    IllustrationRequest hubRequest = null;
                    try
                    {
                        var tuple = converter.Generate(fiptext);
                        pdfname = tuple.Item1;
                        hubtext = tuple.Item2;
                        var m = reImportId.Match(pdfname);
                        ImportId = m.Groups[1].Value;
                    }
                    catch (Exception ex)
                    {
                        logger.Log($"{FipName} {FipIndex}:{ex.Message}");
                    }

                    root = $"{GetFileNameWithoutExtension(FipName)}-{runindex}_{ImportId}";
                    absroot = Combine(OutputFolder, root);

                    using (var sw = new StreamWriter($"{absroot}.fip"))
                    {
                        sw.Write(fiptext);
                    }
                    if (hubtext != null)
                    {
                        using (var sw = new StreamWriter($"{absroot}_FH.json"))
                        {
                            sw.Write(hubtext);
                        }

                        try
                        {
                            hubRequest = JsonConvert.DeserializeObject<IllustrationRequest>(hubtext, settings);
                        }
                        catch (Exception ex)
                        {
                            logger.Log($"{FipName} {FipIndex}:{ex.Message}");
                        }
                    }

                    //continue;
                    //var tasks = new Task[2];
                    //tasks[0]=IllustrationFromWISServer(fiptext, $"{absroot}.pdf");
                    //tasks[0].Wait();
                    //tasks[1]=IllustrationFromHUBServer(hubtext, $"{absroot}_FH.pdf");
                    //tasks[1].Wait();
                    ////Task.WaitAll(tasks);

                    //var WisIllustration = ((Task<byte[]>)tasks[0]).Result;
                    //var HubIllustration = ((Task<byte[]>)tasks[1]).Result;

                    var WisIllustration = IllustrationFromWISServer(fiptext, $"{absroot}.pdf").Result;
                    string result = WisIllustration == null ? "KO" : "OK";
                    logger.Log($"{FipName} {runindex}: {result}");
                    /*
                    var HubIllustration = IllustrationFromHUBServer(hubtext, $"{absroot}_FH.pdf").Result;
                    if (EqualPdfText(WisIllustration, HubIllustration))
                        logger.Log($"{FipName} {runindex}: OK");
                    else
                    {
                        logger.Log($"{FipName} {runindex}:   KO");
                        //Console.ReadKey();
                    }
                    */
                }
                catch (Exception ex)
                {
                    logger.Log($"{FipName} {runindex}: {ex.Message}");
                    //Console.ReadKey();
                }
            }
            logger.Log("Any key to close");
        }
        static private List<(string,int)> ImportInput(string filename)
        {
            var retlist = new List<(string, int)>();
            using (var sr = new StreamReader(filename))
            {
                string line, sep = ",";
                var re = new Regex(@"(,|;|\(;\))$");
                var m = re.Match(GetFileNameWithoutExtension(filename));
                if (m.Success)
                    switch (m.Groups[1].Value)
                    {
                        case "(;)":
                            sep = "\t";
                            break;
                        default:
                            sep = m.Groups[1].Value;
                            break;
                    }
                string q2lit = "\"([^\"]|\"\")+\"";
                string qlit = "\"([^\"]|\"\")+\"".Replace("\"", "'");
                string nqlit = "([^\"'])[^,]*";
                var recsv = new Regex(@"(q2lit|qlit|nqlit)?(,|$)"
                            .Replace("q2lit", q2lit)
                            .Replace("nqlit", qlit)
                            .Replace("qlit", nqlit)
                            .Replace(",", sep));
                string temp = recsv.ToString();

                string getLine(StreamReader reader)
                {
                    line = reader.ReadLine();
                    while (line != null && line.Trim().Length == 0)
                        line = reader.ReadLine();
                    return line;
                }
                line = getLine(sr);
                if (line == null)
                {
                    Console.WriteLine("Input List file is empty");
                    return null;
                }
                // first non empty line
                List<string> CsvSplit(string csv)
                {
                    var ret = new List<string>();
                    m = recsv.Match(csv);
                    while (m.Success)
                    {
                        char first = m.Groups[1].Value[0];
                        if (first == '"' || first == '\'')
                            ret.Add(m.Groups[1].Value.Substring(1, m.Groups[1].Value.Length - 2));
                        else
                            ret.Add(m.Groups[1].Value);
                        if ((m.Index + m.Length) >= csv.Length)
                            break;
                        m = m.NextMatch();
                    }
                    if (!m.Success)
                        throw new Exception("Csv line not parsable");
                    return ret;
                }
                var list = CsvSplit(line);
                if (list.Count < 2)
                    throw new Exception("Inpt csv has not two columns");
                if (!Regex.Match(list[1], @"\d+").Success)
                    line = getLine(sr);
                if (line == null)
                {
                    Console.WriteLine("Input List file has no meaninful data");
                    return null;
                }
                (string name, int idx) row;
                while (line != null)
                {
                    list = CsvSplit(line);
                    row.name = list[0];
                    row.idx = int.Parse(list[1]);
                    retlist.Add(row);
                    line = getLine(sr);
                }
            }
            return retlist;
        }
        static private async Task<byte[]> IllustrationFromWISServer(string fip, string outfilename)
        {
            var wisResponse = await wisClient.GetAsync(fip);
            var filebytes = Convert.FromBase64String(wisResponse.PdfFileAttachment);
            File.WriteAllBytes(outfilename, filebytes);

            return filebytes;
        }
        //static private byte[] Illustration_FromHUBServer(string hubRequest, string outfilename)
        //{
        //    var stream = hubClient.GetAsync(hubRequest);
        //    using(var file = File.Open(outfilename, FileMode.OpenOrCreate))
        //    {
        //        stream.CopyTo(file);
        //    }
        //    var barr = stream.ToArray();
        //    return stream.ToArray();
        //}
        static private async Task<byte[]> IllustrationFromHUBServer(string hubRequest, string outfilename, string endpoint = null)
        {
            var wisResponse = await hubClient.GetAsync1(hubRequest, endpoint);
            var filebytes = Convert.FromBase64String(wisResponse.PdfFileAttachment);
            File.WriteAllBytes(outfilename, filebytes);

            return filebytes;
        }

        static private bool EqualPdfText(byte[] pdf1, byte[] pdf2)
        {
            List<string[]> GetTextFromPdf(byte[] pdf)
            {
                var plist = new List<string[]>();
                string rawtext = null;
                string[] textLines = null;
                Rectangle[] rectangles = null;
                try
                {
                    using (var reader = new PdfReader(pdf))
                    {
                        for (int x = 1; x <= reader.NumberOfPages; x++)
                        {
                            var strategy = new ExtraLocationExtractionStrategy();
                            try
                            {

                                rawtext = PdfTextExtractor.GetTextFromPage(reader, x, strategy); //Needed to provoke the parse of the page
                                textLines = strategy.GetTextLines();
                                plist.Add(textLines);
                                rectangles = strategy.GetLineRectangles();
                            }
                            catch
                            {
                                logger.Log("Error extracting text");
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception($"iText cannot parse:\n {ex.ToString()}");
                }

                return plist;
            }
            List<string[]> l1 = null, l2 = null;
            try
            {
                l1 = GetTextFromPdf(pdf1);

            }
            catch (Exception)
            {
                logger.Log("Wis Pdf not parsable");
                return false;
            }
            try
            {
                l2 = GetTextFromPdf(pdf2);

            }
            catch (Exception)
            {
                logger.Log("Hub Pdf not parsable");
                return false;
            }
            if (l1.Count != l2.Count)
                return false;
            for (int x = 0; x < l1.Count; x++)
            {
                if (l1[x].Length != l2[x].Length)
                    return false;
                for (int y = 0; y < l1[x].Length; y++)
                {
                    for (int z = 0; z < l1[x][y].Length; z++)
                        if (l1[x][y][z] != l2[x][y][z])
                            return false;
                }
            }
            return true;
        }
        static void RenamePropertyName(string oldname, string newname)
        {
            foreach(string filename in Directory.GetFiles(OutputFolder))
            {
                string text;
                if (filename.ToLower().EndsWith(".json"))
                {
                    using (var sr = new StreamReader(filename))
                    {
                        text = sr.ReadToEnd();
                    }
                    text = text.Replace(oldname, newname);
                    using (var sw = new StreamWriter(filename))
                    {
                        sw.Write(text);
                    }
                }
            }
        }
        static void ExtractFip(List<(string, int)> list)
        {
            var re = new Regex(@"outputName *, *Illus_(\d+)");
            string root, absroot, ImportId;
            foreach (var (FipName, FipIndex) in list)
            {
                var extraction = new ExtractOneFipFromMany(Combine(InputFolder, FipName + ".fip"));
                string fiptext = extraction.Position(FipIndex);
                if (fiptext == null)
                {
                    logger.Log("Fip with index {FipIndex} is not present");
                    continue;
                }
                
                var m = re.Match(fiptext);
                ImportId = m.Groups[1].Value;
                root = $"{GetFileNameWithoutExtension(FipName)}-{FipIndex:000}_{ImportId}";
                absroot = Combine(OutputFolder, root);

                using (var sw = new StreamWriter($"{absroot}.fip"))
                {
                    sw.Write(fiptext);
                }
            }
        }
    }
}
