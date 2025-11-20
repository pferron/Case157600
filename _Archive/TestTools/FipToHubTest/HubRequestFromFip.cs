using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HubIllustrationServiceTest
{

    public class HubRequestFromFip
    {
        private Dictionary<string, string> Conversions;
        private Dictionary<string, string> CommonSections;
        private string DeathBenefitAmount;
        private string PermRating;
        public HubRequestFromFip(Dictionary<string,string> conversions)
        {
            Conversions = conversions;
        }
        FipSimpleParser parser;
        public (string,string) Generate(string fiptext)
        {            
            parser = new FipSimpleParser(fiptext);
            CommonSections = parser.MergeSections(new List<string> { "ScenePointers", "CommonData", "ContactBasicData", "Batch"});

            string state, tempRtg = "", tempRtg2Age = "", polId = "", issueDt = "", issueAge = "",
                   revIll = "", refOpt = "", billPrem = "", guarAge = "",
                   payMode = "", deathBO = "", annPrem = "", frDues = "", billType = "", lump = "",
                   nlgInt = "0", nlgPrem = "0.0", loanMP = "0.0", loanBal = "0.0", pdfAmt = "0.0", pdfInt = "0.0", outputname="";
            string isSmoker;
            string prefRtg;
            state = ValueOfKey(CommonSections,"State");
            polId = ValueOfKey(CommonSections,"PolicyNumber");
            issueDt = ValueOfKey(CommonSections,"SceneModifyDate");
            issueAge = ValueOfKey(CommonSections,"age");
            tempRtg = ValueOfKey(CommonSections,"RtgExtra_1");
            tempRtg2Age = ToAge2EndDate(issueDt, issueAge, ValueOfKey(CommonSections,"RtgExtraToAge_1"));
            string revIllstr = CommonSections.ContainsKey("revisedIllus") ? ValueOfKey(CommonSections,"revisedIllus") : "";
            revIll = revIllstr == "1" ? "true" : "false";
            //string needsCBstr = ValueOfKey(sec,"CostBenefit");
            //needsCB = needsCBstr == "1" ? "true" : "false";
            lump = ValueOfKey(CommonSections,"Lump1035Amt").Replace("$", "").Replace(",", "");
            (isSmoker, prefRtg) = DeconstructClassType(int.Parse(ValueOfKey(CommonSections,"ClassType")));
            outputname = ValueOfKey(CommonSections, "outputName");

            var uld = parser.MergeSections(new List<string> { "Uldata" });
            PermRating = ValueOfKey(uld,"RtgAmtPerm");
            billType = ValueOfKey(uld,"billType");
            frDues = ValueOfKey(uld,"frDues");
            refOpt = ValueOfKey(uld,"RefundOpt");
            nlgInt = ValueOfKey(uld,"NlGint");

            var nld = parser.SectionMultiples("NonLevelData");
            foreach(var item in nld)
            {
                string dtc = ValueOfKey(item,"DataTypeCode");
                switch (dtc)
                {
                    case "1":
                        DeathBenefitAmount = ValueOfKey(item,"NlAmt_1");
                        break;
                    case "2":
                        guarAge = (int.Parse(ValueOfKey(item,"NlAge")) - 1).ToString();
                        payMode = ConvertPayMode(ValueOfKey(item,"NLCode_2"));
                        billPrem = ValueOfKey(item,"NlAmt_1");
                        break;
                    case "6":
                        deathBO = ValueOfKey(item, "NlCode_1") == "1" ? "INCR" : "LEVEL";
                        break;
                    case "8":
                        if (ValueOfKey(item,"Level") == "1")
                            annPrem = ValueOfKey(item,"NlAmt_1");
                        break;
                    default:
                        throw new Exception($"NUnexpected Non Level Data TypeCode {dtc}");
                }
            }
            string coverages = GenerateCoverages();
            string json = "\"EventType\": \"issue\"," +
                           //"\"PlanId\": \"TIBNLGUL\"," +
                           $"\"StatusChangeDate\": \"{issueDt}\"," +
                           $"\"IssueStateCode\": \"{state}\"," +
                           //$"\"PermanentTableRatingCode\": {permRtg}," +
                           //$"\"TemporaryTableRatingCode\": {tempRtg}," +
                           $"\"HowManyOwners\": 1," +
                           $"\"PolicyId\": \"{polId}\"," +
                           //$"\"PolicyEffectiveDate\": \"{issueDt}\"," +
                           //$"\"IssueAge\": {issueAge}," +
                           $"\"RevisedIllustrationIndicator\": {revIll}," +
                           $"\"RefundOption\": {refOpt}," +
                           //$"\"TobaccoPremiumBasis\": \"{ConvertClassType(int.Parse(ValueOfKey(sec, "ClassType")))}\"," +
                           //$"\"DeathBenefitAmount\": {DeathBenefitAmount}," +
                           $"\"BillPremium\": {billPrem}," +
                           $"\"GuarAge\": {guarAge}," +
                           //$"\"YearsToMaturity\": {YtM}," +
                           $"\"BillingMode\": \"{payMode}\"," +
                           $"\"DeathBenefitOptionCode\": \"{deathBO}\"," +
                           $"\"AnnualInitialpremium\": {annPrem}," +
                           $"\"FraternalDues\": {frDues}," +
                           $"\"LumpAmount\": {lump}," +
                           $"\"BillingMethod\": \"{ConvertToCMBillingMethod(billType)}\"," +
                           $"\"NoLapseGuaranteedInterest\": {nlgInt}," +
                           $"\"NoLapsePremiumAmount\": {nlgPrem}," +
                           $"\"LoanModalRepayment\": {loanMP}," +
                           $"\"LoanBalanceAmount\": {loanBal}," +
                           $"\"PremiumDepositFundAmount\": {pdfAmt}," +
                           $"\"PremiumDepositFundInterestAmount\": {pdfInt}," +
                           $"{GenerateFunds()}," +
                           $"{coverages}," +
                           $"{GenerateAgent()}," +
                           $"{GenerateInsured(CommonSections)}";
            json = Regex.Replace(json,@": \.00(,)?",": 0.0$1") + ",\"GenerateIllustrationValues\": false";
            return (outputname, "{" + json + "}");
        }
        private String ValueOfKey(Dictionary<string, string> dic, string key)
        {
            if (dic.ContainsKey(key))
                return dic[key];
            else
                throw (new Exception($"Dictionary doesn't contain key '{key}'"));
        }
        private string ConvertPayMode(string fip)
        {
            switch (fip)
            {
                case "3": return "QUARTLY";   // quartely 4
                case "2": return "BIANNUAL";   // semiannual  2
                case "6": return "MNTHLY";  //  12
                case "7": return "0";   // pdf 7 ???
                default: return "ANNUAL";    // annual 1
            }
        }
        private string ConvertToCMBillingMethod(string bt)
        {
            int billingtype;
            if (!int.TryParse(bt, out billingtype))
                throw new Exception("Unexpected 'billing type' value {bt}");
            switch (billingtype)
            {
                case 1:
                    return "REGBILL";
                case 2:
                    return "LISTBILL";
                default:
                    return "NOBILL";
            }
        }
        private string ToAge2EndDate(string issuedt, string issueage, string toage)
        {
            DateTime issueDate = DateTime.Parse(issuedt);
            int issueAge = int.Parse(issueage);
            int toAge = int.Parse(toage);
            DateTime enddate = issueDate.AddYears(toAge - issueAge);
            return enddate.ToShortDateString();
        }
        private string ConvertRating(string rtg)
        {
            var res = from item in Conversions
                      where item.Key.StartsWith("Rating") && item.Value == rtg
                      select item.Key;
            string ratingcode = res.Single().Substring("Rating".Length).ToUpper();
            return ratingcode;
        }
        private string GenerateCoverages()
        {
            string issueDt = ValueOfKey(CommonSections, "SceneModifyDate");
            int issueAge = int.Parse(ValueOfKey(CommonSections, "age"));
            string planid = "TIBNLGUL";
            string classtype = ValueOfKey(CommonSections, "ClassType");
            string permrtg = PermRating;
            string temprtg = ValueOfKey(CommonSections, "RtgExtra_1");
            string temprtg2age = ToAge2EndDate(issueDt, issueAge.ToString(), ValueOfKey(CommonSections, "RtgExtraToAge_1"));

            DateTime issueDate = DateTime.Parse(ValueOfKey(CommonSections, "SceneModifyDate"));
            DateTime birthDate = DateTime.Parse(ValueOfKey(CommonSections, "birthdate"));
            DateTime maturitydate = issueDate.AddYears(121 - issueAge);

            var coveragelist = parser.SectionMultiples("AllRiderData");
            string type, coveragetype, age, faceAmt, rtg, rtg2Age, extraRtg, extraRtg2Age, json;
            string JsonCoverages = "";

            for (int x = 0; x < coveragelist.Count; x++)
            {
                var rider = coveragelist[x];
                type = ValueOfKey(rider,"type");
                switch (type)
                {
                    case "1":
                        coveragetype = "WMD";
                        break;
                    case "2":
                        coveragetype = "ADB";
                        break;
                    case "105":
                        coveragetype = "LTCABO";
                        break;
                    default:
                        throw new Exception($"Unexpected rider type {type}");
                }
                age = ValueOfKey(rider, "Age");
                faceAmt = ValueOfKey(rider, "Amount").Replace("$","").Replace(",","");
                rtg = ConvertRating(ValueOfKey(rider, "RtgAmt"));

                int toage;
                rtg2Age = ValueOfKey(rider, "RtgAmtToAge");
                if (int.TryParse(rtg2Age, out toage) && toage > 0)
                    rtg2Age = $"\"{ToAge2EndDate(issueDt, age, rtg2Age)}\"";
                else
                    rtg2Age = "null";

                extraRtg = ValueOfKey(rider, "RtgExtra");

                extraRtg2Age = ValueOfKey(rider, "RtgExtraToAge");
                toage = 0;
                if (int.TryParse(extraRtg2Age, out toage) && toage > 0)
                    extraRtg2Age = $"\"{ToAge2EndDate(issueDt, age, extraRtg2Age)}\"";
                else
                    extraRtg2Age = "null";

                json = "{" + $"\"planId\": \"{planid}\"," +
                             $"\"CoverageTypeCode\": \"{coveragetype}\"," +
                             $"\"EffectiveDate\": \"{issueDate.ToShortDateString()}\"," +
                             $"\"IssueAge\": {age}," +
                             $"\"FaceAmount\": {faceAmt}," +
                             $"\"PermanentTableRatingCode\": \"{rtg}\"," +
                             $"\"TobaccoPremiumBasisCode\": null," +
                             $"\"TemporaryFlatExtraRate\": {extraRtg}," +
                             $"\"TemporaryFlatExtraEndDate\": {extraRtg2Age}," +
                             $"\"ExpirationDate\": {rtg2Age}," +
                             $"\"MaturityDate\": null" + 
                       "}";
                JsonCoverages += (json + ",");
            }
            // now the base coverage
            string ratingcode = ConvertRating(permrtg);
            decimal extrartg = decimal.Parse(temprtg);
            string extraend = extrartg == 0 ? "null" : $"\"{temprtg2age}\"";
            string tpb = ConvertClassType(int.Parse(classtype));

            json = "{" + $"\"planId\": \"{planid}\"," +
                         $"\"CoverageTypeCode\": null," +
                         $"\"EffectiveDate\": \"{issueDate.ToShortDateString()}\"," +
                         $"\"IssueAge\": 0," +
                         $"\"FaceAmount\": {DeathBenefitAmount}," +
                         $"\"PermanentTableRatingCode\": \"{ratingcode}\"," +
                         $"\"TobaccoPremiumBasisCode\": \"{tpb}\"," +
                         $"\"TemporaryFlatExtraRate\": {extrartg}," +
                         $"\"TemporaryFlatExtraEndDate\": {extraend}," +
                         $"\"ExpirationDate\": null," +
                         $"\"MaturityDate\": \"{maturitydate.ToShortDateString()}\"" + 
                   "}";
            JsonCoverages += (json);

            return "\"Coverages\": [" + JsonCoverages + "]";
        }
        private string GenerateAgent()
        {
            var sec = parser.MergeSections(new List<string> { "AgentData" });
            string firstName = ValueOfKey(sec,"AgtFirstname");
            string middleName = ValueOfKey(sec,"AgtMiddleInitial");
            string lastName = ValueOfKey(sec,"AgtLastName");
            string nameSuffix = "";
            string addr1 = ValueOfKey(sec,"AgtAddr_1");
            string addr2 = ValueOfKey(sec,"AgtAddr_2");
            string city = ValueOfKey(sec,"AgtCity");
            string state = ValueOfKey(sec,"AgtState");
            string zip = ValueOfKey(sec,"AgtZip");
            string phone = ValueOfKey(sec,"AgtPhone");

            string json = $"\"FirstName\": {DoubleQuote(firstName)}," +
                          $"\"MiddleName\": {DoubleQuote(middleName)}," +
                          $"\"LastName\": {DoubleQuote(lastName)}," +
                          $"\"NameSuffix\": {DoubleQuote(nameSuffix)}," +
                          $"\"AddressLine1\": {DoubleQuote(addr1)}," +
                          $"\"AddressLine2\": {DoubleQuote(addr2)}," +
                          $"\"AddressCity\": \"{city}\"," +
                          $"\"AddressStateCode\": \"{state}\"," +
                          $"\"AddressZipCode\": \"{zip}\"," +
                          $"\"PhoneNumber\": \"{phone}\"";

            return "\"Agent\": {" + json + "}";
        }
        private string GenerateFunds()
        {
            return "\"Funds\": [" + "" + "]";
        }
        private string DoubleQuote(string str)
        {
            return "\"" + str + "\"";
        }
        private string GenerateInsured(Dictionary<string,string> sec)
        {
            string birthDate = ValueOfKey(sec,"birthdate");
            string age = ValueOfKey(sec,"age");
            string gender = ValueOfKey(sec, "sex") == "0" ? "MALE" : "FEMALE";
            string firstName = ValueOfKey(sec,"Firstname");
            string middleName = ValueOfKey(sec,"MiddleInitial");
            string lastName = ValueOfKey(sec,"LastName");
            string nameSuffix = ValueOfKey(sec,"NameSuffix");

            (string smoker, string rating) = DeconstructClassType(int.Parse(ValueOfKey(sec,"ClassType")));

            string json = $"\"FirstName\": {DoubleQuote(firstName)}," +
                          $"\"MiddleName\": {DoubleQuote(middleName)}," +
                          $"\"LastName\": {DoubleQuote(lastName)}," +
                          $"\"NameSuffix\": {DoubleQuote(nameSuffix)}," +
                          $"\"BirthDate\": \"{birthDate}\"," +
                          $"\"Age\": {age}," +
                          $"\"GenderCode\": \"{gender}\"";

            return "\"Client\": {" + json + "}";
        }
        private (string, string) DeconstructClassType(int classtype)
        {
            string smoker = "NONSMOKER";
            string rating = "0";
            switch (classtype)
            {
                case 1:
                    rating = "PRENONSMOKER";
                    break;
                case 2:
                    rating = "0";
                    break;
                case 3:
                    smoker = "SMOKER";
                    rating = "PRESMOKER";
                    break;
                case 4:
                    smoker = "SMOKER";
                    rating = "0";
                    break;
                case 12:
                    break;
                case 14:
                    rating = "SUPERPRE";
                    break;
                default:
                    throw new Exception($"Unexpected ClassType {classtype}");                        
            }

            return (smoker, rating);
        }
        private string ConvertClassType(int classtype)
        {
            //string smoker = "NONSMOKER";
            //string rating = "0";
            switch (classtype)
            {
                case 1:
                    return "PRENONSMOKER";
                case 2:
                    return "NONSMOKER";
                case 3:
                    return "PRESMOKER";
                case 4:
                    return "SMOKER";
                case 12:
                    return "NONSMOKER";
                case 14:
                    return "SUPERPRE";
                default:
                    throw new Exception($"Unexpected ClassType {classtype}");
            }
        }
    }
}