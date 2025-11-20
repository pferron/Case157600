using log4net;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using WOW.Illustration.Model.Generation.Request;
using WOW.Illustration.Model.Generation.Response;
using WOW.MobileRaterService.Data;
using WOW.MobileRaterService.Properties;
using WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Requests;


namespace WOW.MobileRaterService.Code
{
    public static class CommonProcessor
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(CommonProcessor));

        //enum PlanName
        //{
        //    AUL,
        //    EZ_GDB,
        //    EZ_WKGDB,
        //    EZ_LP100,
        //    EZ_LP65,
        //    EZ_LP20,
        //    EZ_WKLP100,
        //    EZ_WKLP65,
        //    EZ_WKLP20,
        //    FT10_2016,
        //    FT20_2016,
        //    LP100,
        //    LP20,
        //    LP65,
        //    NLG80,
        //    NLG100,
        //    NLG120,
        //    Term10_2016,
        //    Term15_2016,
        //    Term20_2016,
        //    Term30_2016,
        //    U20Term,
        //    U30Term,
        //    WNLG80,
        //    WNLG100,
        //    WNLG120,
        //    WKAUL,
        //    WKLP100,
        //    WKLP65
        //}

        internal static WoodmenIllustrationResponse PostRequest(Policy policy)
        {
            try
            {
                var settings = new JsonSerializerSettings();
                settings.TypeNameHandling = TypeNameHandling.All;

                if (logger.IsDebugEnabled) logger.Debug($"PostRequest called.");

                var state = JsonConvert.SerializeObject(policy, settings);
                if (logger.IsDebugEnabled) logger.Debug($"PostRequest serialized policy:{state}.");

                var content = new StringContent(state, Encoding.Default, "application/json");

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(Settings.Default.GenerationRequestBaseUri);
                    httpClient.Timeout = Settings.Default.GenerationRequestTimeout;

                    var requestTask = httpClient.PostAsync(Settings.Default.GenerationRequestMethod, content);
                    requestTask.Wait();

                    var response = requestTask.Result;
                    response.EnsureSuccessStatusCode();

                    var contentTask = response.Content.ReadAsAsync<WoodmenIllustrationResponse>();
                    contentTask.Wait();

                    return contentTask.Result;
                }
            }
            catch (Exception ex)
            {
                if (logger.IsDebugEnabled) logger.Debug($"Error in PostRequest {ex}.");
                return null;
            }
        }

        internal static Rider AddWLADRider(WholeLifePolicy policy, WOW.MobileRaterService.Models.ValidationInput validation)
        {
            int maxAge = 0;
            if (logger.IsDebugEnabled) logger.Debug($"AddWLADBRider called.");

            var state = MobileRaterServiceConfiguration.StateSettings.Single(s => s.StateAbbreviation == policy.SignedState);

            maxAge = state.MaxAcceleratedDeathBenefitAge;
            Rider adbRider = new Rider();
            adbRider.Age = validation.InsuredAge;
            adbRider.Amount = validation.FaceAmount;
            adbRider.Class = 0;
            adbRider.IssueAge = validation.InsuredAge;
            adbRider.Name = string.Empty;
            adbRider.RatingAmount = validation.ADRating.Value;
            //to age from states class
            //adbRider.RatingAmountToAge = fipSection.Data.SafeGetValue("RTGAMTTOAGE", 0);
            adbRider.RatingExtra = 0;
            adbRider.RatingExtraToAge = 0;
            if (validation.Gender.ToUpperInvariant() == "F")
            {
                adbRider.Sex = 1;
            }
            else
            {
                adbRider.Sex = 0;
            }

            adbRider.RiderType = 2;
            return adbRider;
        }

        internal static void SavePDF(WoodmenIllustrationResponse wisResponse, string planID)
        {
            if (logger.IsDebugEnabled) logger.Debug($"SavePDF called with planID: {planID}.");

            StringBuilder sb = new StringBuilder();
            string filename = string.Empty;
            sb.Append(ServiceHelper.GetPayloadDirectoryPath());
            sb.Append("\\" + planID);
            sb.Append("_" + DateTime.Now.ToShortDateString().Replace("/", "_") + "_" + DateTime.Now.ToShortTimeString().Replace(":", "_"));
            filename = sb.ToString().Replace(" ", "_");
            if (wisResponse.HasPdfFile && wisResponse.HasValuesFile)
            {
                try
                {
                    if (logger.IsDebugEnabled) { logger.DebugFormat(CultureInfo.InvariantCulture, "Saving PDF attachment: {0}.", filename + ".pdf"); }
                    SaveDecodedFile(filename + ".pdf", wisResponse.PdfFileAttachment);

                    if (logger.IsDebugEnabled) { logger.DebugFormat(CultureInfo.InvariantCulture, "Saving TXT attachment: {0}.", filename + ".txt"); }
                    SaveDecodedFile(filename + ".txt", wisResponse.ValuesFileAttachment);
                }
                catch (Exception ex)
                {
                    if (logger.IsErrorEnabled) { logger.Error(String.Format(CultureInfo.InvariantCulture, "An error occurred while executing savePDF"), ex); }

                    throw;
                }
            }
        }
        private static void SaveDecodedFile(string targetFilePath, string encodedContent)
        {
            if (String.IsNullOrWhiteSpace(targetFilePath))
            {
                if (logger.IsErrorEnabled) { logger.Error("SaveDecodedFile: 'targetFilePath' is null or empty."); }
                throw new ArgumentException("A file path is required to use this method.", "targetFilePath");
            }

            if (String.IsNullOrWhiteSpace(encodedContent))
            {
                if (logger.IsErrorEnabled) { logger.Error("SaveDecodedFile: 'encodedContent' is null or empty."); }
                throw new ArgumentException("Base64 encoded data is required to use this method.", "encodedContent");
            }

            try
            {
                var filebytes = Convert.FromBase64String(encodedContent);
                File.WriteAllBytes(targetFilePath, filebytes);
            }
            catch (Exception ex)
            {
                if (logger.IsErrorEnabled) { logger.Error(String.Format(CultureInfo.InvariantCulture, "An error occurred while writing out file '{0}'.", targetFilePath), ex); }

                throw;
            }
        }


        internal static int ConvertRatingForValidation(string ratingClass)
        {
            if (logger.IsDebugEnabled) logger.Debug($"ConvertRating called.");

            int rating = 0;
            try
            {
                ratingClass = ratingClass.ToUpperInvariant();

                switch (ratingClass)                        // DB driven eligible
                {
                    case "STANDARD":
                    case "RED":
                    case "BLUE - STANDARD":
                        rating = 0;
                        break;
                    case "PREFERRED":
                        rating = -1;
                        break;
                    case "SUPER PREFERRED":
                    case "SUPER-PREFERRED":
                        rating = -2;
                        break;
                    case "TABLE 1":
                    case "WHITE - SPECIAL":
                        rating = 1;
                        break;
                    case "TABLE 2":
                        rating = 2;
                        break;
                    case "TABLE 3":
                        rating = 3;
                        break;
                    case "TABLE 4":
                        rating = 4;
                        break;
                    case "TABLE 5":
                        rating = 5;
                        break;
                    case "TABLE 6":
                        rating = 6;
                        break;
                    case "TABLE 7":
                        rating = 7;
                        break;
                    case "TABLE 8":
                        rating = 8;
                        break;
                    case "TABLE 9":
                        rating = 9;
                        break;
                    case "TABLE 10":
                        rating = 10;
                        break;
                    case "TABLE 11":
                        rating = 11;
                        break;
                    case "TABLE 12":
                        rating = 12;
                        break;
                    case "TABLE 13":
                        rating = 13;
                        break;
                    case "TABLE 14":
                        rating = 14;
                        break;
                    case "TABLE 15":
                        rating = 15;
                        break;
                    case "TABLE 16":
                        rating = 16;
                        break;
                    default:
                        rating = MobileRaterServiceConfiguration.MaxTableRating + 1;
                        break;
                }


                return rating;
            }

            catch (Exception ex)
            {
                if (logger.IsDebugEnabled) logger.DebugFormat(CultureInfo.InvariantCulture, "ConvertRiderForValidation - Error - {0}", ex);
                return rating;
            }
        }

        internal static int ConvertIndependenceADRating(IndependenceRateInput input)
        {
            if (logger.IsDebugEnabled) logger.Debug($"ConvertIndependenceADRating called.");

            int adbRating = 0;
            if (input.HasAccidentalDeathRider)
            {
                if (ConvertRating(input.RatingClass) > 0)
                {
                    adbRating = 3;
                }
                else
                {
                    adbRating = 1;
                }
            }

            return adbRating;
        }

        internal static decimal ProcessIllustrationResponse(WoodmenIllustrationResponse response)
        {
            if (logger.IsDebugEnabled) logger.Debug($"ProcessIllustrationResponse called with response.");

            decimal rate = 0;

            try
            {
                if (response.HasValuesFile)
                {
                    using (var streamReader = new StreamReader(new MemoryStream(Convert.FromBase64String(response.ValuesFileAttachment))))
                    {
                        string line;
                        //string wholeFile = streamReader.ReadToEnd();

                        while ((line = streamReader.ReadLine()) != null && rate == 0)
                        {
                            if (logger.IsDebugEnabled) logger.Debug($"ProcessIllustrationResponse values: {line}.");
                            if (line.Substring(0, 5) == Settings.Default.PremiumColumn)
                            {
                                var lineArray = line.Split(',');
                                
                                if (decimal.TryParse(lineArray[2], out rate))
                                {
                                    logger.DebugFormat("Request ID: {0}, PremiumColumn: {1}, Rate: {2:C}", response.RequestId, Settings.Default.PremiumColumn, rate);
                                    return rate;
                                }
                                else
                                {
                                    return 0;
                                }
                            }
                        }
                    }
                }

                return rate;
            }
            catch (Exception ex)
            {
                if (logger.IsDebugEnabled) logger.DebugFormat(CultureInfo.InvariantCulture, "ProcessIllustrationResponse - Error - {0}", ex);
                return rate;
            }
        }

        internal static int ConvertRating(string ratingClass)
        {
            if (logger.IsDebugEnabled) logger.Debug($"ConvertRating called.");

            int rating;
            try
            {
                ratingClass = ratingClass.ToUpperInvariant();

                switch (ratingClass)
                {
                    case "STANDARD":                // DB driven eligible
                    case "PREFERRED":
                    case "SUPER PREFERRED":
                    case "SUPER-PREFERRED":
                    case "RED":
                    case "BLUE - STANDARD":
                        rating = 0;
                        break;
                    case "TABLE 1":
                    case "WHITE - SPECIAL":
                        rating = 1;
                        break;
                    case "TABLE 2":
                        rating = 2;
                        break;
                    case "TABLE 3":
                        rating = 3;
                        break;
                    case "TABLE 4":
                        rating = 4;
                        break;
                    case "TABLE 5":
                        rating = 5;
                        break;
                    case "TABLE 6":
                        rating = 6;
                        break;
                    case "TABLE 7":
                        rating = 7;
                        break;
                    case "TABLE 8":
                        rating = 8;
                        break;
                    case "TABLE 9":
                        rating = 9;
                        break;
                    case "TABLE 10":
                        rating = 10;
                        break;
                    case "TABLE 11":
                        rating = 11;
                        break;
                    case "TABLE 12":
                        rating = 12;
                        break;
                    case "TABLE 13":
                        rating = 13;
                        break;
                    case "TABLE 14":
                        rating = 14;
                        break;
                    case "TABLE 15":
                        rating = 15;
                        break;
                    case "TABLE 16":
                        rating = 16;
                        break;
                    default:
                        rating = MobileRaterServiceConfiguration.MaxTableRating + 1;
                        break;
                }


                return rating;
            }

            catch (Exception ex)
            {
                rating = MobileRaterServiceConfiguration.MaxTableRating + 1;
                if (logger.IsErrorEnabled) { logger.ErrorFormat(CultureInfo.InvariantCulture, "An error occurred in ConvertRiderRating: {0}.", ex); }
                return rating;
            }

        }

        //internal static int? ConvertAWPRiderRating(LifeRateInput input)
        //{
        //    int Rid;
        //}

        internal static string ConvertBillType(string billType)
        {
            switch (billType.ToUpperInvariant())
            {
                case "LIST BILL":   // DB driven eligible
                case "LISTBILL":
                    return "L";

                case "PAC":
                    return "P";

                case "DIRECT BILL":
                    return "D";

                default:
                    return "L";
            }
        }

        internal static string ConvertPaymentMode(string paymentMode)
        {
            switch (paymentMode.ToUpperInvariant())
            {
                case "MONTHLY":     // DB driven eligible
                    return "M";

                case "QUARTERLY":
                    return "Q";

                case "SEMI-ANNUAL":
                case "SEMI-ANNUALLY":
                case "SEMI ANNUAL":
                    return "S";

                case "ANNUAL":
                    return "A";

                default:
                    return "M";
            }
        }







        #region Other Support Methods - Mark???

        //public static int? ConverRiderRating(bool inRating)
        //{
        //    int outRating;
        //    if (inRating == true)
        //    {
        //        outRating = 1;
        //    }
        //    else
        //    {
        //        outRating = 0;
        //    }
        //    return outRating;

        // }

        internal static NonLevelData SetTermNonLevelData()
        {
            if (logger.IsDebugEnabled) logger.Debug($"SetTermNonLevelData called.");
            NonLevelData termNonLevel = new NonLevelData();
            termNonLevel.Level = 1;
            termNonLevel.Amounts.Add(0);
            termNonLevel.Amounts.Add(0);
            termNonLevel.Codes.Add(104);
            termNonLevel.Codes.Add(0);
            termNonLevel.Codes.Add(0);
            termNonLevel.Codes.Add(0);
            termNonLevel.Age = 95;
            return termNonLevel;
        }

        internal static NonLevelData SetWholeLifeNonLevelData()
        {
            if (logger.IsDebugEnabled) logger.Debug($"SetWLNonLevelData called.");
            NonLevelData wlNonLevel = new NonLevelData();
            wlNonLevel.Level = 9;
            wlNonLevel.Amounts.Add(0);
            wlNonLevel.Amounts.Add(0);
            wlNonLevel.Codes.Add(101);
            wlNonLevel.Codes.Add(0);
            wlNonLevel.Codes.Add(0);
            wlNonLevel.Codes.Add(0);
            wlNonLevel.Age = 120;
            return wlNonLevel;
        }

        public static bool CheckFamilyTermValid(FamilyTermRateInput ftInput)
        {
            if (logger.IsDebugEnabled) logger.Debug($"CheckFamilyTermValid called.");

            decimal ft50 = 50000M;
            decimal ft100 = 100000M;
            decimal ft250 = 250000M;
            decimal ft500 = 500000;

            int minIssueAge = 18;
            int maxIssueAge = 50;
            
            try
            {
                //No quoting allowed for NY
                if (ftInput.State.Equals("NY", StringComparison.InvariantCultureIgnoreCase))
                {
                    return false;
                }

                // Primary Insured Validation
                if ((ftInput.PrimaryAge < minIssueAge) || (ftInput.PrimaryAge > maxIssueAge))
                {
                    return false;
                }

                if (!((ftInput.PrimaryFaceAmount == ft50) || (ftInput.PrimaryFaceAmount == ft100) || (ftInput.PrimaryFaceAmount == ft250) || (ftInput.PrimaryFaceAmount == ft500)))
                {
                    return false;
                }

                if (String.IsNullOrWhiteSpace(ftInput.PrimaryDisability))
                {
                    return false;
                }

                var rating = ConvertRating(ftInput.PrimaryRatingClass);

                if (rating > MobileRaterServiceConfiguration.MaxTableRating)
                {
                    return false;
                }

                // Other Insured Validation
                if (ftInput.OtherAge.HasValue)
                {
                    if (ftInput.OtherAge.Value < minIssueAge)
                    {
                        return false;
                    }

                    if (ftInput.OtherAge.Value > maxIssueAge)
                    {
                        return false;
                    }

                    if (!((ftInput.OtherFaceAmount.Value == ft50) || (ftInput.OtherFaceAmount.Value == ft100) || (ftInput.OtherFaceAmount.Value == ft250) || (ftInput.OtherFaceAmount.Value == ft500)))
                    {
                        return false;
                    }

                    if (ftInput.PrimaryFaceAmount < ftInput.OtherFaceAmount.Value)
                    {
                        return false;
                    }

                    var otherRating = ConvertRating(ftInput.OtherRatingClass);

                    if (otherRating > MobileRaterServiceConfiguration.MaxTableRating)
                    {
                        return false;
                    }
                }
                
                return true;
            }
            catch (Exception ex)
            {
                if (logger.IsErrorEnabled) { logger.ErrorFormat(CultureInfo.InvariantCulture, "An error occurred in CheckFamilyTermValid: {0}.", ex); }
                return false;
            }
        }

        public static bool CheckFTWaiver(FamilyTermRateInput ftInput)
        {
            if(String.IsNullOrWhiteSpace(ftInput.PrimaryDisability))
            {
                return false;
            }

            if (ftInput.PrimaryDisability.ToUpperInvariant() != "N")
            {
                var disabilityRating = ConvertRiderRating(ftInput.PrimaryDisability);

                var primaryRating = ConvertRatingForValidation(ftInput.PrimaryRatingClass);
                var otherRating = (ftInput.OtherAge.HasValue) ? ConvertRatingForValidation(ftInput.OtherRatingClass) : primaryRating;

                var rating = (primaryRating >= otherRating) ? primaryRating : otherRating;

                if(rating <= 1) // Super-Preferred, Preferred, Standard, Table 1
                {
                    return true;
                }
                else if(disabilityRating == 1 && rating >= 2)
                {
                    return false;
                }
                else if(disabilityRating == 2 && rating >= 4)
                {
                    return false;
                }
                else if(rating >= 6)
                {
                    return false;
                }
            }
            
            return true;
        }
        public static int ConvertRiderRating(string inRating)
        {
            int outRating;
            try
            {
                if (logger.IsDebugEnabled) logger.Debug($"ConvertRiderRating called.");

                if (String.IsNullOrWhiteSpace(inRating))
                {
                    return MobileRaterServiceConfiguration.MaxRiderRating + 1;
                }

                switch (inRating.ToUpperInvariant())
                {
                    case "N":       // DB driven eligible
                        outRating = 0;
                        break;
                    case "Y":
                        outRating = 1;
                        break;
                    case "2":
                        outRating = 2;
                        break;
                    case "3":
                        outRating = 3;
                        break;
                    default:
                        outRating = MobileRaterServiceConfiguration.MaxRiderRating + 1;
                        break;
                }

                return outRating;
            }
            catch (Exception ex)
            {
                outRating = MobileRaterServiceConfiguration.MaxRiderRating + 1;
                if (logger.IsErrorEnabled) { logger.ErrorFormat(CultureInfo.InvariantCulture, "An error occurred in ConvertRiderRating: {0}.", ex); }
                return outRating;
            }
        }

        internal static int SetInsuredClass(string ratingClass, bool tobacco, int age, string state)
        {
            if (logger.IsDebugEnabled) logger.Debug($"SetInsuredClass called.");
            int insuredClass = 0;
            if ((age < 18 && !(state == "NY")) || ratingClass.ToUpperInvariant() == "RED")
            {
                insuredClass = 12;
            }
            else
            {
                switch (ratingClass.ToUpperInvariant())
                {
                    case "PREFERRED":       // Eligible for replacing with DB driven Enums
                        if (tobacco)
                        {
                            insuredClass = 3;
                        }
                        else
                        {
                            insuredClass = 1;
                        }
                        break;
                    case "SUPER-PREFERRED":
                    case "SUPER PREFERRED":
                        insuredClass = 5;
                        break;
                    default:
                        if (tobacco)
                        {
                            insuredClass = 4;
                        }
                        else
                        {
                            insuredClass = 2;
                        }
                        break;
                }
            }
            return insuredClass;
        }

        //internal static string SetResponsePlanByHeaderCode(int headerCode, int nlgToAge)
        //{
        //    string planName = string.Empty;
        //    switch (headerCode)
        //    {
        //        case 119:
        //            switch (nlgToAge)
        //            {
        //                case 81:
        //                    planName = PlanName.NLG80.ToString();
        //                    break;

        //                case 101:
        //                    planName = PlanName.NLG100.ToString();
        //                    break;

        //                case 121:
        //                    planName = PlanName.NLG120.ToString();
        //                    break;

        //                default:
        //                    planName = PlanName.NLG120.ToString();
        //                    break;
        //            }
        //            break;

        //        case 120:
        //            switch (nlgToAge)
        //            {
        //                case 81:
        //                    planName = PlanName.NLG80.ToString();
        //                    break;

        //                case 101:
        //                    planName = PlanName.NLG100.ToString();
        //                    break;

        //                case 121:
        //                    planName = PlanName.NLG120.ToString();
        //                    break;

        //                default:
        //                    planName = PlanName.NLG120.ToString();
        //                    break;
        //            }
        //            break;


        //        case 121:
        //            planName = PlanName.AUL.ToString();
        //            break;

        //        case 122:
        //            planName = PlanName.WKAUL.ToString();
        //            break;

        //        case 220:
        //            planName = PlanName.LP100.ToString();
        //            break;

        //        case 221:
        //            planName = PlanName.LP65.ToString();
        //            break;
        //        case 222:
        //            planName = PlanName.LP20.ToString();
        //            break;

        //        case 250:
        //            planName = PlanName.EZ_GDB.ToString();
        //            break;

        //        case 260:
        //            planName = PlanName.EZ_LP100.ToString();
        //            break;

        //        case 261:
        //            planName = PlanName.EZ_LP65.ToString();
        //            break;

        //        case 262:
        //            planName = PlanName.EZ_LP20.ToString();
        //            break;

        //        case 264:
        //            planName = PlanName.EZ_WKLP100.ToString();
        //            break;

        //        case 265:
        //            planName = PlanName.EZ_WKLP65.ToString();
        //            break;

        //        case 274:
        //            planName = PlanName.WKLP100.ToString();
        //            break;

        //        case 275:
        //            planName = PlanName.WKLP65.ToString();
        //            break;

        //        case 850:
        //            planName = PlanName.Term10_2016.ToString();
        //            break;

        //        case 855:
        //            planName = PlanName.Term15_2016.ToString();
        //            break;
        //        case 860:
        //            planName = PlanName.Term20_2016.ToString();
        //            break;
        //        case 865:
        //            planName = PlanName.Term30_2016.ToString();
        //            break;
        //        case 870:
        //            planName = PlanName.U20Term.ToString();
        //            break;
        //        case 875:
        //            planName = PlanName.U30Term.ToString();
        //            break;
        //        case 880:
        //            planName = PlanName.FT10_2016.ToString();
        //            break;
        //        case 885:
        //            planName = PlanName.FT20_2016.ToString();
        //            break;

        //        default:
        //            break;
        //    }

        //    return planName;
        //}

        internal static int ConvertBillType(string billType, string premMode)
        {
            int bType = 0;
            switch (billType.ToUpperInvariant())
            {
                case "LIST BILL":   // eligible to replacing with Enums
                case "LISTBILL":
                    bType = 3;
                    break;
                case "DIRECT":
                case "DIRECT BILL":
                    bType = 1;
                    break;
                default:
                    bType = 2;
                    break;
            }
            return bType;
        }

        internal static int ConvertMode(string billType, string premMode, string rater)
        {
            if (logger.IsDebugEnabled) logger.Debug($"ConvertMode called.");

            int convertedMode = 0;
            switch (premMode.ToUpperInvariant())
            {
                case "MONTHLY":
                    if (rater == "LR" || rater == "FT")
                    {
                        if (billType.ToUpperInvariant() == "LIST BILL" || billType.ToUpperInvariant() == "LISTBILL")
                        {
                            convertedMode = 16;
                        }
                        else
                        {
                            convertedMode = 14;
                        }
                    }
                    else
                    {
                        switch (billType.ToUpperInvariant())
                        {
                            case "LIST BILL":
                            case "LISTBILL":
                                convertedMode = 74;
                                break;
                            case "DIRECT":
                            case "DIRECT BILL":
                                convertedMode = 54;
                                break;
                            default:
                                convertedMode = 64;
                                break;
                        }
                    }
                    break;
                case "QUARTERLY":
                    if (rater == "LR" || rater == "FT")
                    {
                        convertedMode = 20;
                    }
                    else
                    {
                        switch (billType.ToUpperInvariant())
                        {
                            case "LIST BILL":
                            case "LISTBILL":
                                convertedMode = 73;
                                break;
                            case "DIRECT":
                            case "DIRECT BILL":
                                convertedMode = 53;
                                break;
                            default:
                                convertedMode = 63;
                                break;
                        }
                    }
                    break;
                case "SEMI ANNUAL":
                case "SEMI-ANNUAL":
                    if (rater == "LR" || rater == "FT")
                    {
                        convertedMode = 12;
                    }
                    else
                    {
                        switch (billType.ToUpperInvariant())
                        {
                            case "LIST BILL":
                            case "LISTBILL":
                                convertedMode = 72;
                                break;
                            case "DIRECT":
                            case "DIRECT BILL":
                                convertedMode = 52;
                                break;
                            default:
                                convertedMode = 62;
                                break;
                        }
                    }
                    break;

                case "ANNUAL":
                case "ANNUALLY":
                    convertedMode = 1;
                    break;

            }
            return convertedMode;
        }

        internal static WoodmenIllustrationResponse UnpackWoodmenIllustrationResponse(string message)
        {
            if (message == null)
            {
                var errorMessage = "UnpackWoodmenIllustrationResponse - Null message received.";
                if (logger.IsErrorEnabled) logger.Error(errorMessage);
                throw new ArgumentNullException("message", errorMessage);
            }
            else if (string.IsNullOrWhiteSpace(message))
            {
                var errMessage = "UnpackWoodmenIllustrationResponse - Empty message received.";
                if (logger.IsErrorEnabled) logger.Error(errMessage);
                throw new ArgumentOutOfRangeException("message", errMessage);
            }

            if (logger.IsDebugEnabled) logger.DebugFormat(CultureInfo.InvariantCulture, "UnpackWoodmenIllustrationResponse - message received. {0}", message);

            // Try to deserialize message
            var response = JsonConvert.DeserializeObject<WoodmenIllustrationResponse>(message);

            // if (logger.IsDebugEnabled) logger.DebugFormat(CultureInfo.InvariantCulture, "UnpackWoodmenIllustrationResponse - Response message - {0}", response);
            return response;
        }

        internal static int? RateFTRider(bool rider, int baseRating, int otherRatingClass)
        {
            if (logger.IsDebugEnabled) logger.Debug($"RateFTRider called.");

            int rating;
            if (rider == false)
            {
                rating = 0;
            }
            else
            {
                if ((baseRating == otherRatingClass) || (baseRating > otherRatingClass))
                {
                    switch (baseRating)
                    {
                        case 1:
                            rating = 1;
                            break;
                        case 2:
                        case 3:
                            rating = 2;
                            break;
                        case 4:
                        case 5:
                            rating = 3;
                            break;
                        default:
                            rating = 0;
                            break;
                    }
                }
                else
                {
                    switch (otherRatingClass)
                    {
                        case 1:
                            rating = 1;
                            break;
                        case 2:
                        case 3:
                            rating = 2;
                            break;
                        case 4:
                        case 5:
                            rating = 3;
                            break;
                        default:
                            rating = 0;
                            break;
                    }

                }
            }
            return rating;
        }

        internal static NoLapseGuaranteedUniversalLifePolicy SetNLGULNonLevelData(LifeRateInput lrInput, string planID, NoLapseGuaranteedUniversalLifePolicy policy)
        {
            if (logger.IsDebugEnabled) logger.Debug($"SetNLGULNonLevelData called.");
            int toAge;
            switch (planID.ToUpperInvariant())
            {
                case "NLG80":
                case "WNLG80":
                    toAge = 81;
                    break;
                case "NLG100":
                case "WNLG100":
                    toAge = 101;
                    break;
                case "NLG120":
                case "WNLG120":
                    toAge = 121;
                    break;
                default:
                    toAge = 121;
                    break;

            }

            var nlcb = new NonLevelData();
            nlcb.DataTypeCode = DataType.CoverageBenefit;
            nlcb.Amounts.Add(lrInput.FaceAmount);
            nlcb.Level = 1;
            nlcb.Codes.Add(1);
            nlcb.Codes.Add(0);
            nlcb.Codes.Add(0);
            nlcb.Codes.Add(0);
            nlcb.Amounts.Add(0);
            nlcb.Age = 121;
            policy.NonLevelData.Add(nlcb);


            var nlps = new NonLevelData();
            nlps.DataTypeCode = DataType.PaymentSchedule;
            nlps.Level = 1;
            switch (planID)
            {
                case "NLG80":
                case "WNLG80":
                    nlps.Codes.Add(13);
                    break;
                case "NLG100":
                case "WNLG100":
                    nlps.Codes.Add(14);
                    break;
                case "NLG120":
                case "WNLG120":
                    nlps.Codes.Add(12);
                    break;

            }
            switch (lrInput.PaymentMode.ToUpperInvariant())
            {
                case "MONTHLY":
                    nlps.Codes.Add(6);
                    break;
                case "QUARTERLY":
                    nlps.Codes.Add(3);
                    break;
                case "SEMI-ANNUAL":
                    nlps.Codes.Add(2);
                    break;
                case "ANNUAL":
                    nlps.Codes.Add(1);
                    break;
            }
            nlps.Age = toAge;
            nlps.Codes.Add(0);
            nlps.Codes.Add(0);
            nlps.Amounts.Add(0);
            nlps.Amounts.Add(0);
            nlps.Level = 1;
            policy.NonLevelData.Add(nlps);

            var nldb = new NonLevelData();
            nldb.DataTypeCode = DataType.DeathBenefit;
            nldb.Level = 1;
            nldb.Codes.Add(1);
            nldb.Codes.Add(0);
            nldb.Codes.Add(0);
            nldb.Codes.Add(0);
            nldb.Amounts.Add(0);
            nldb.Amounts.Add(0);
            nldb.Age = 121;
            policy.NonLevelData.Add(nldb);

            var nlia = new NonLevelData();
            nlia.DataTypeCode = DataType.LumpSum;
            nlia.Level = 2;
            nlia.Codes.Add(1);
            nlia.Codes.Add(0);
            nlia.Codes.Add(0);
            nlia.Codes.Add(0);
            nlia.Amounts.Add(0);
            nlia.Amounts.Add(0);
            nlia.Age = 121;
            policy.NonLevelData.Add(nlia);
            return policy;

        }

        internal static AccumulationUniversalLifePolicy SetAULNonLevelData(LifeRateInput lrInput, string planID, AccumulationUniversalLifePolicy policy)
        {
            if (logger.IsDebugEnabled) logger.Debug($"SetAULNonLevelData called.");

            var nlcb = new NonLevelData();
            nlcb.DataTypeCode = DataType.CoverageBenefit;
            nlcb.Level = 1;
            nlcb.Codes.Add(1);
            nlcb.Codes.Add(0);
            nlcb.Codes.Add(0);
            nlcb.Codes.Add(0);
            nlcb.Amounts.Add(lrInput.FaceAmount);
            nlcb.Amounts.Add(0);
            nlcb.Age = 121;
            policy.NonLevelData.Add(nlcb);

            var nlps = new NonLevelData();
            nlps.DataTypeCode = (DataType.PaymentSchedule);
            nlps.Level = 1;
            nlps.Codes.Add(3);

            switch (lrInput.PaymentMode.ToUpperInvariant())
            {
                case "MONTHLY":
                    nlps.Codes.Add(6);
                    break;
                case "QUARTERLY":
                    nlps.Codes.Add(3);
                    break;
                case "SEMI-ANNUAL":
                    nlps.Codes.Add(2);
                    break;
                case "ANNUAL":
                    nlps.Codes.Add(1);
                    break;
            }
            nlps.Codes.Add(0);
            nlps.Codes.Add(0);
            nlps.Amounts.Add(0);
            nlps.Amounts.Add(0);
            nlps.Age = 121;
            policy.NonLevelData.Add(nlps);

            var nldb = new NonLevelData();
            nldb.DataTypeCode = DataType.DeathBenefit;
            nldb.Level = 1;
            nldb.Codes.Add(1);
            nldb.Codes.Add(0);
            nldb.Codes.Add(0);
            nldb.Codes.Add(0);
            nldb.Amounts.Add(lrInput.FaceAmount);
            nldb.Amounts.Add(0);
            nldb.Age = 121;
            policy.NonLevelData.Add(nldb);

            var nlia1 = new NonLevelData();
            nlia1.DataTypeCode = DataType.LumpSum;
            nlia1.Level = 1;
            nlia1.Codes.Add(1);
            nlia1.Codes.Add(0);
            nlia1.Codes.Add(0);
            nlia1.Codes.Add(0);
            nlia1.Amounts.Add(0);
            nlia1.Amounts.Add(0);
            nlia1.Age = lrInput.Age + 1;
            policy.NonLevelData.Add(nlia1);

            var nlia = new NonLevelData();
            nlia.DataTypeCode = DataType.LumpSum;
            nlia.Level = 2;
            nlia.Codes.Add(1);
            nlia.Codes.Add(0);
            nlia.Codes.Add(0);
            nlia.Codes.Add(0);
            nlia.Amounts.Add(0);
            nlia.Amounts.Add(0);
            nlia.Age = 121;
            policy.NonLevelData.Add(nlia);
            return policy;
        }


        internal static IndexedUniversalLifePolicy SetIULNonLevelData(LifeRateInput lrInput, string planID, IndexedUniversalLifePolicy policy)
        {
            if (logger.IsDebugEnabled) logger.Debug($"SetIULNonLevelData called.");

            var nlcb = new NonLevelData();
            nlcb.DataTypeCode = DataType.CoverageBenefit;
            nlcb.Level = 1;
            nlcb.Codes.Add(1);
            nlcb.Codes.Add(0);
            nlcb.Codes.Add(0);
            nlcb.Codes.Add(0);
            // NLRates in the FIP were not implemented in WIM
            nlcb.Amounts.Add(lrInput.FaceAmount);
            nlcb.Amounts.Add(0);
            // NLGradePct in the FIP was not implemented in WIM
            nlcb.Age = 121; // 121 for UL
            policy.NonLevelData.Add(nlcb);

            var nlps = new NonLevelData();
            nlps.DataTypeCode = DataType.PaymentSchedule;
            nlps.Level = 1;
            nlps.Codes.Add(3);
            switch (lrInput.PaymentMode.ToUpperInvariant())
            {
                case "MONTHLY":
                    nlps.Codes.Add(6);
                    break;
                case "QUARTERLY":
                    nlps.Codes.Add(3);
                    break;
                case "SEMI-ANNUAL":
                    nlps.Codes.Add(2);
                    break;
                case "ANNUAL":
                    nlps.Codes.Add(1);
                    break;
            }
            nlps.Codes.Add(0);
            nlps.Codes.Add(0);
            nlps.Amounts.Add(0);
            nlps.Amounts.Add(0);
            nlps.Age = 121; // 121 for UL
            policy.NonLevelData.Add(nlps);

            var nldb = new NonLevelData();
            nldb.DataTypeCode = DataType.DeathBenefit;
            nldb.Level = 1;
            nldb.Codes.Add(1);
            nldb.Codes.Add(0);
            nldb.Codes.Add(0);
            nldb.Codes.Add(0);
            nldb.Amounts.Add(lrInput.FaceAmount);
            nldb.Amounts.Add(0);
            nldb.Age = 121;
            policy.NonLevelData.Add(nldb);

            var nlia1 = new NonLevelData();
            nlia1.DataTypeCode = DataType.LumpSum;
            nlia1.Level = 1;
            nlia1.Codes.Add(1);
            nlia1.Codes.Add(0);
            nlia1.Codes.Add(0);
            nlia1.Codes.Add(0);
            nlia1.Amounts.Add(0);
            nlia1.Amounts.Add(0);
            nlia1.Age = lrInput.Age + 1;
            policy.NonLevelData.Add(nlia1);

            var nlia = new NonLevelData();
            nlia.DataTypeCode = DataType.LumpSum;
            nlia.Level = 2;
            nlia.Codes.Add(1);
            nlia.Codes.Add(0);
            nlia.Codes.Add(0);
            nlia.Codes.Add(0);
            nlia.Amounts.Add(0);
            nlia.Amounts.Add(0);
            nlia.Age = 121;
            policy.NonLevelData.Add(nlia);
            return policy;
        }

        #endregion

    }
}