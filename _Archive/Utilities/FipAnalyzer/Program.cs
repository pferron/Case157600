using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WOW.FipUtilities;

namespace WOW.Illustration.FipAnalyzer
{
    class Program
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Program));

        private static List<FipAnalysis> _results = new List<FipAnalysis>();

        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    HelpMessage();
                    return;
                }

                // Confirm that the first arg is a valid directory
                var directory = args[0];
                if (String.IsNullOrWhiteSpace(directory) || !Directory.Exists(directory))
                {
                    HelpMessage();
                    return;
                }

                // Let's get to work!
                AnalyzeDirectory(directory);

                // Let's pore over the results!
                GenerateSummary();

                GenerateDetails();
            }
            catch (Exception ex)
            {
                logger.Error("Error Analyzing FIP files", ex);
            }
        }

        private static void GenerateDetails()
        {
            logger.Debug("HeaderCode,ClassType,I/N,FaceAmount,IssueAge");

            foreach (var item in _results.Select(q => new
                        {
                            q.HeaderCode,
                            q.ClassType,
                            IsInforce = (q.IsInForce) ? "I" : "N",
                            q.FaceAmount,
                            q.IssueAge
                        })
                        .OrderBy(o => o.HeaderCode).ThenBy(t => t.ClassType).ThenBy(t => t.IsInforce))
            {
                logger.DebugFormat("{0},{1},{2},{3},{4}", item.HeaderCode, item.ClassType, item.IsInforce, item.FaceAmount, item.IssueAge);
            }
        }

        private static void GenerateSummary()
        {
            logger.Debug("HeaderCode,ClassType,I/N,Count");

            foreach (var item in _results.GroupBy(a => new { a.HeaderCode, a.ClassType, a.IsInForce })
                        .Select(group => new
                        {
                            HeaderCode = group.Key.HeaderCode,
                            ClassType = group.Key.ClassType,
                            IsInforce = (group.Key.IsInForce) ? "I" : "N",
                            Count = group.Count()
                        })
                        .OrderBy(o => o.HeaderCode).ThenBy(t => t.ClassType).ThenBy(t => t.IsInforce).ThenBy(t => t.Count))
            {
                logger.DebugFormat("{0},{1},{2},{3}", item.HeaderCode, item.ClassType, item.IsInforce, item.Count);
            }
        }

        private static void AnalyzeDirectory(string directory)
        {
            var files = Directory.GetFiles(directory, "*.fip", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                _results.Add(AnalyzeFile(file));
            }
        }

        private static FipAnalysis AnalyzeFile(string file)
        {
            try
            {
                var analysis = new FipAnalysis();
                analysis.Filename = Path.GetFileName(file);

                var text = File.ReadAllText(file);
                var fipModel = FipParser.GenerateFipDictionary(text);

                Dictionary<string, string> tempSection;
                string tempString;
                int tempInt;
                decimal tempDec;

                if (fipModel.TryGetValue("[SCENEPOINTERS]", out tempSection))
                {
                    if (tempSection.TryGetValue("HEADERCODE", out tempString) && int.TryParse(tempString, out tempInt))
                    {
                        analysis.HeaderCode = tempInt;
                    }

                    if (tempSection.TryGetValue("CONCEPTCODE", out tempString) && int.TryParse(tempString, out tempInt))
                    {
                        analysis.IsInForce = tempInt == 5;
                    }

                    if (tempSection.TryGetValue("CATEGORYCODE", out tempString) && int.TryParse(tempString, out tempInt))
                    {
                        analysis.CategoryCode = (CategoryCode)tempInt;
                    }

                    if (tempSection.TryGetValue("CLASSTYPE", out tempString) && int.TryParse(tempString, out tempInt))
                    {
                        if (analysis.CategoryCode == CategoryCode.FixedAnnuity)
                        {
                            analysis.ClassTypeAnnuity = (ClassTypeAnnuity)tempInt;
                        }
                        else
                        {
                            analysis.ClassTypeLife = (ClassTypeLife)tempInt;
                        }
                    }

                }

                if (fipModel.TryGetValue("[COMMONDATA]", out tempSection))
                {
                    if (tempSection.TryGetValue("RTGAMT", out tempString) && int.TryParse(tempString, out tempInt))
                    {
                        analysis.HasTableRating = tempInt > 0;
                    }

                    if (tempSection.TryGetValue("RTGEXTRA_1", out tempString) && decimal.TryParse(tempString, out tempDec))
                    {
                        analysis.HasFlatExtra = tempDec > 0M;
                    }
                }

                if (fipModel.TryGetValue("[WLDATA]", out tempSection))
                {
                    if (tempSection.TryGetValue("FACEPREMAMT", out tempString) && decimal.TryParse(tempString, out tempDec))
                    {
                        analysis.FaceAmount = tempDec;
                    }
                }

                if (fipModel.TryGetValue("[POLICYDATA]", out tempSection))
                {
                    if (tempSection.TryGetValue("ISSUEAGE", out tempString) && int.TryParse(tempString, out tempInt))
                    {
                        analysis.IssueAge = tempInt;
                    }
                }

                foreach (var pair in fipModel)
                {
                    if (pair.Key.StartsWith("[ALLRIDERDATA"))
                    {
                        tempSection = pair.Value;
                        if (tempSection.TryGetValue("TYPE", out tempString) && int.TryParse(tempString, out tempInt))
                        {
                            var type = (RiderType)tempInt;
                            switch (type)                       // DB driven eligible
                            {
                                case RiderType.WaiverOfPremium:
                                    analysis.HasWaiverOfPremium = true;
                                    break;
                                case RiderType.AccidentalDeathBenefit:
                                    analysis.HasAccidentalDeathBenefit = true;
                                    break;
                                case RiderType.GuaranteedInsurability:
                                    analysis.HasGuaranteedInsurability = true;
                                    break;
                                case RiderType.OtherInsuredRider:
                                    analysis.HasOtherInsuredRider = true;
                                    break;
                                case RiderType.ApplicantWaiver:
                                    analysis.HasApplicantWaiver = true;
                                    break;
                                case RiderType.PremiumDepositFund:
                                    analysis.HasPremiumDepositFund = true;
                                    break;
                                case RiderType.AcceleratedBenefit:
                                    analysis.HasAcceleratedBenefit = true;
                                    break;
                            }
                        }

                    }
                }

                return analysis;
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("Error analysing file '{0}'. Ex: {1}", file, ex);
                return null;
            }
        }

        private static void HelpMessage()
        {
            logger.Warn("This program will recursively scan a folder for *.FIP files.");
            logger.Warn("Output: A report detailing what types of FIP files were found.");
            logger.Warn("Arg1: Path to root FIP directory");
        }
    }
}
