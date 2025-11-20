using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WOW.WoodmenIllustrationService.SharedModels;

namespace WOW.RaterUtilities.Tests
{
    [TestClass]
    public class RaterTester
    {
        private string _url = "http://appserv-t6:2015/";

        [TestMethod]
        public async Task RequestFamilyTermRate()
        {
            //TODO: Tests need to be redone
            var request = JsonConvert.DeserializeObject<RaterRequest>("{\"FirstName\":\"Rate\",\"LastName\":\"FamTerm\",\"Sex\":0,\"BirthDate\":\"1985-12-09T00:00:00\",\"Age\":30,\"State\":\"ID\",\"ConformToTamra\":1,\"Misc2\":\"2\",\"Misc3\":\"0\",\"Misc4\":null,\"Misc7\":null,\"Misc8\":null,\"Misc9\":null,\"Misc10\":null,\"LoanUsageType\":0,\"Lump1035Amt\":0.0,\"LumpSumUsage\":0,\"PlanQualified\":0,\"PlanUnisex\":0,\"RtgAmt\":0,\"RtgAmtToAge\":65,\"RtgExtra_1\":0.0,\"RtgExtra_1ToAge\":90,\"RtgExtra_2\":0.0,\"RtgExtra_2ToAge\":95,\"RtgAmtPerm\":0,\"RtgAmtPermToAge\":0,\"SettlementAge\":65,\"ResumeAge\":0,\"RefundOpt\":0,\"Ten35Basis\":0.0,\"WdrlToLoan\":0,\"StateNAICApproved\":1,\"RTOAge\":0,\"RTOAmount\":0.0,\"RPUPrimaryDiv\":0,\"PUAStopPremium\":0,\"VanishMaintainCode\":0,\"VanishType\":0,\"FrDues\":30.0,\"ClassType\":2,\"HeaderCode\":780,\"CategoryCode\":4,\"ConceptCode\":1,\"StrategyCode\":1,\"PremMode\":52,\"BillType\":1,\"FaceCode\":1,\"FacePremAmt\":50000.0,\"SearchType\":0,\"SearchTarget\":0.0,\"searchAssumption\":0,\"SearchAge\":0,\"SearchPremium\":0.0,\"SearchIntRate\":0.0,\"SearchPremiumPercentage\":0.0,\"SearchPremiumToAge\":0,\"SearchTargetCode\":0,\"Riders\":[{\"Type\":8,\"SubType\":1,\"IssueAge\":30,\"ToAge\":92,\"RatingAmount\":2,\"RatingAmountToAge\":92,\"Age\":48,\"Toggle\":1,\"Amount\":0.0,\"Level\":1,\"Class\":4,\"Name\":null}],\"Joints\":[],\"NonLevelData\":[]}");

            var result = await SendRequest(request);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Rate1 > 0M);
            Assert.IsTrue(result.Rate2 > 0M);
        }

        [TestMethod]
        public async Task RequestIndependenceSeriesRate()
        {
            //TODO: Tests need to be redone
            var request = JsonConvert.DeserializeObject<RaterRequest>("{\"FirstName\":\"Rate\",\"LastName\":\"Independence\",\"Sex\":0,\"BirthDate\":\"1935-12-09T00:00:00\",\"Age\":80,\"State\":\"NC\",\"ConformToTamra\":1,\"Misc2\":\"2\",\"Misc3\":\"0\",\"Misc4\":null,\"Misc7\":null,\"Misc8\":null,\"Misc9\":null,\"Misc10\":null,\"LoanUsageType\":0,\"Lump1035Amt\":0.0,\"LumpSumUsage\":0,\"PlanQualified\":0,\"PlanUnisex\":1,\"RtgAmt\":0,\"RtgAmtToAge\":85,\"RtgExtra_1\":0.0,\"RtgExtra_1ToAge\":80,\"RtgExtra_2\":0.0,\"RtgExtra_2ToAge\":120,\"RtgAmtPerm\":0,\"RtgAmtPermToAge\":0,\"SettlementAge\":65,\"ResumeAge\":0,\"RefundOpt\":0,\"Ten35Basis\":0.0,\"WdrlToLoan\":0,\"StateNAICApproved\":1,\"RTOAge\":0,\"RTOAmount\":0.0,\"RPUPrimaryDiv\":0,\"PUAStopPremium\":0,\"VanishMaintainCode\":0,\"VanishType\":0,\"FrDues\":12.0,\"ClassType\":4,\"HeaderCode\":274,\"CategoryCode\":8,\"ConceptCode\":1,\"StrategyCode\":1,\"PremMode\":74,\"BillType\":3,\"FaceCode\":1,\"FacePremAmt\":10000.0,\"SearchType\":0,\"SearchTarget\":0.0,\"searchAssumption\":0,\"SearchAge\":0,\"SearchPremium\":0.0,\"SearchIntRate\":0.0,\"SearchPremiumPercentage\":0.0,\"SearchPremiumToAge\":0,\"SearchTargetCode\":0,\"Riders\":[{\"Type\":0,\"SubType\":0,\"IssueAge\":0,\"ToAge\":0,\"RatingAmount\":0,\"RatingAmountToAge\":0,\"Age\":0,\"Toggle\":0,\"Amount\":0.0,\"Level\":0,\"Class\":0,\"Name\":null}],\"Joints\":[],\"NonLevelData\":[]}");

            var result = await SendRequest(request);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Rate1 > 0M);
            Assert.IsTrue(result.Rate2 > 0M);
        }

        [TestMethod]
        public async Task RequestLifeRaterRate()
        {
            //TODO: Tests need to be redone
            var request = JsonConvert.DeserializeObject<RaterRequest>("{\"FirstName\":\"Life\",\"LastName\":\"Rates\",\"Sex\":0,\"BirthDate\":\"0001-01-01T00:00:00\",\"Age\":42,\"State\":\"LA\",\"ConformToTamra\":0,\"Misc2\":null,\"Misc3\":null,\"Misc4\":\"0\",\"Misc7\":null,\"Misc8\":\"12/09/2015\",\"Misc9\":\"0\",\"Misc10\":\"0\",\"LoanUsageType\":0,\"Lump1035Amt\":0.0,\"LumpSumUsage\":0,\"PlanQualified\":0,\"PlanUnisex\":0,\"RtgAmt\":4,\"RtgAmtToAge\":62,\"RtgExtra_1\":0.0,\"RtgExtra_1ToAge\":65,\"RtgExtra_2\":0.0,\"RtgExtra_2ToAge\":65,\"RtgAmtPerm\":4,\"RtgAmtPermToAge\":62,\"SettlementAge\":0,\"ResumeAge\":0,\"RefundOpt\":1,\"Ten35Basis\":0.0,\"WdrlToLoan\":0,\"StateNAICApproved\":1,\"RTOAge\":0,\"RTOAmount\":0.0,\"RPUPrimaryDiv\":0,\"PUAStopPremium\":0,\"VanishMaintainCode\":0,\"VanishType\":0,\"FrDues\":6.0,\"ClassType\":2,\"HeaderCode\":121,\"CategoryCode\":3,\"ConceptCode\":1,\"StrategyCode\":1,\"PremMode\":0,\"BillType\":3,\"FaceCode\":0,\"FacePremAmt\":0.0,\"SearchType\":1,\"SearchTarget\":0.0,\"searchAssumption\":1,\"SearchAge\":120,\"SearchPremium\":0.0,\"SearchIntRate\":0.0,\"SearchPremiumPercentage\":0.0,\"SearchPremiumToAge\":0,\"SearchTargetCode\":0,\"Riders\":[{\"Type\":2,\"SubType\":0,\"IssueAge\":0,\"ToAge\":70,\"RatingAmount\":2,\"RatingAmountToAge\":70,\"Age\":0,\"Toggle\":0,\"Amount\":99999.0,\"Level\":0,\"Class\":0,\"Name\":null}],\"Joints\":[{\"Sex\":0,\"ClassType\":0,\"Age\":0,\"BirthDate\":\"0001-01-01T00:00:00\"}],\"NonLevelData\":[{\"DataTypeCode\":8,\"Level\":2,\"Code1\":1,\"Code2\":0,\"Rate\":0.0,\"Amount1\":0.0,\"Amount2\":0.0,\"Age\":96}]}");

            var result = await SendRequest(request);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Rate1 > 0M);
            Assert.IsTrue(result.Rate2 > 0M);
        }

        [TestMethod]
        public async Task RequestWoodmenAtWorkRate()
        {
            //TODO: Tests need to be redone
            var request = JsonConvert.DeserializeObject<RaterRequest>("");

            var result = await SendRequest(request);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Rate1 > 0M);
            Assert.IsTrue(result.Rate2 > 0M);
        }

        public async Task RequestAulRate()
        {
            //TODO: Tests need to be redone
            var request = JsonConvert.DeserializeObject<RaterRequest>("");

            var result = await SendRequest(request);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Rate1 > 0M);
            Assert.IsTrue(result.Rate2 > 0M);
        }

        private async Task<RaterResponse> SendRequest(RaterRequest request)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PostAsJsonAsync("api/Rater/FetchRate", request);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<RaterResponse>();
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
