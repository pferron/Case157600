using Aspose.Pdf;
using CommonIllustrationServiceTester.Code;
using CommonIllustrationServiceTester.Properties;
using CommonIllustrationServiceTester.TestCases;
using Newtonsoft.Json;
using Polly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using Wow.IllustrationCommonModels.Request;

namespace CommonIllustrationServiceTester
{
    public partial class CISTestForm : Form
    {
        public CISTestForm()
        {
            InitializeComponent();
        }

        private void btnPlainRequest_Click(object sender, EventArgs e)
        {
            try
            {
                var illustrationRequest = GenerateIULRequest.CreateIllustrationRequest();
                illustrationRequest.PermanentTableRatingCode = "";
                illustrationRequest.Coverages = new List<Coverage>();  //Plain has only 1 coverage, this clears out the 2 coverages so we can add just 1

                Coverage coverage1 = new Coverage();
                coverage1.PlanId = "TUINDEXN";
                coverage1.CoverageTypeCode = "ADB";
                coverage1.CurrentAmt = 2000.50m;
                coverage1.IssueAge = 55;
                coverage1.FaceAmount = 500;
                coverage1.TobaccoPremiumBasisCode = "NONSMOKER";
                illustrationRequest.Coverages.Add(coverage1);

                var val = illustrationRequest.ToString();

                var k = string.Empty;
                ValidateRequest(illustrationRequest, k);
            }
            catch (Exception ex)
            {
                tbResults.Text = ex.Message;
            }
        }

        private void btnBadTestCase1_Click(object sender, EventArgs e)
        {
            try
            {
                var illustrationRequest = GenerateIULRequest.CreateIllustrationRequest();
                illustrationRequest.FaceAmount = -2;

                var k = string.Empty;
                ValidateRequest(illustrationRequest, k);
            }
            catch (Exception ex)
            {
                tbResults.Text = ex.Message;
            }
        }

        private void btnBadRequest2_Click(object sender, EventArgs e)
        {
            try
            {
                var illustrationRequest = GenerateIULRequest.CreateIllustrationRequest();
                illustrationRequest.ApplicationSignedStateCode = null;
                illustrationRequest.FaceAmount = 99000;

                var k = string.Empty;
                ValidateRequest(illustrationRequest, k);
            }
            catch (Exception ex)
            {
                tbResults.Text = ex.Message;
            }
        }

        private void btnBadRequest3_Click(object sender, EventArgs e)
        {
            try
            {
                var illustrationRequest = GenerateIULRequest.CreateIllustrationRequest();
                illustrationRequest.DeathBenefitOptionCode = null;

                var k = string.Empty;
                ValidateRequest(illustrationRequest, k);
            }
            catch (Exception ex)
            {
                tbResults.Text = ex.Message;
            }
        }

        private void btnCoverageRequest_Click(object sender, EventArgs e)
        {
            try
            {
                var illustrationRequest = GenerateIULRequest.CreateIllustrationRequest();
                illustrationRequest.PermanentTableRatingCode = "";              //CoverageRequest has no ratings, this takes the default rating out
                illustrationRequest.Coverages = new List<Coverage>();

                Coverage coverage1 = new Coverage();
                coverage1.PlanId = "TUINDEXN";
                coverage1.CoverageTypeCode = "ADB";
                coverage1.CurrentAmt = 25000;
                coverage1.IssueAge = 30;
                coverage1.FaceAmount = 25000;
                coverage1.TobaccoPremiumBasisCode = "NONSMOKER";
                illustrationRequest.Coverages.Add(coverage1);

                Coverage coverage2 = new Coverage();
                coverage2.PlanId = "TUINDEXN";
                coverage2.CoverageTypeCode = "WMD";
                coverage2.CurrentAmt = 25000;
                coverage2.IssueAge = 30;
                coverage2.FaceAmount = 25000;
                coverage2.TobaccoPremiumBasisCode = "NONSMOKER";
                illustrationRequest.Coverages.Add(coverage2);

                Coverage coverage3 = new Coverage();
                coverage3.PlanId = "TUINDEXN";
                coverage3.CoverageTypeCode = "OPAI";
                coverage3.CurrentAmt = 25000;
                coverage3.IssueAge = 45;
                coverage3.FaceAmount = 25000;
                coverage3.TobaccoPremiumBasisCode = "NONSMOKER";
                illustrationRequest.Coverages.Add(coverage3);

                var k = string.Empty;
                ValidateRequest(illustrationRequest, k);
            }
            catch (Exception ex)
            {
                tbResults.Text = ex.Message;
            }
        }

        private void btnPermanentRatingRequest_Click(object sender, EventArgs e)
        {
            try
            {
                var illustrationRequest = GenerateIULRequest.CreateIllustrationRequest();
                illustrationRequest.Coverages = new List<Coverage>();           //PermenentRatingRequest doesn't have coverages, this clears the default coverages        

                var results = ValidateIllustrationRequest.Validate(illustrationRequest);

                var k = string.Empty;
                ValidateRequest(illustrationRequest, k);
            }
            catch (Exception ex)
            {
                tbResults.Text = ex.Message;
            }
        }

        private void btnBadRequest4_Click(object sender, EventArgs e)
        {
            try
            {
                var illustrationRequest = GenerateIULRequest.CreateIllustrationRequest();
                illustrationRequest.Coverages[1].CurrentAmt = -5;

                var k = string.Empty;
                ValidateRequest(illustrationRequest, k);
            }
            catch (Exception ex)
            {
                tbResults.Text = ex.Message;
            }
        }

        private void ValidateRequest(IllustrationRequest illustrationRequest, string outputFileName)
        {
            var results = string.Empty;

            if (rbtnValidateLocally.Checked)
            {
                results = ValidateIllustrationRequest.Validate(illustrationRequest);

                if (results.Trim().Length == 0)
                {
                    tbResults.Text = "Illustration Request is Valid";
                }
                else
                {
                    tbResults.Text = results;
                }
            }
            else
            {
                try
                {
                    string url = string.Empty;
                    string region = string.Empty;

                    try
                    {
                        region = cbRegions.SelectedItem.ToString();
                    }
                    catch (Exception)
                    {
                        throw new Exception($"Must select region!");
                    }

                    url = GetRegionConnectionString(region);

                    results = GenerateIllustrationsWebServiceCall(illustrationRequest, url);

                    var pdfLocation = Settings.Default.IulOutputDirectory + outputFileName;

                    if (File.Exists(pdfLocation))
                    {
                        File.Delete(pdfLocation);
                    }

                    byte[] pdfBytes = Convert.FromBase64String(results);

                    using (System.IO.FileStream stream = new FileStream(pdfLocation, FileMode.CreateNew))
                    {
                        using (System.IO.BinaryWriter writer = new BinaryWriter(stream))
                        {
                            writer.Write(pdfBytes, 0, pdfBytes.Length);
                        }
                    }

                    tbResults.Text = $"Illustration saved to {pdfLocation}";
                }
                catch (Exception ex)
                {
                    tbResults.Text = ex.Message;
                }
            }
        }

        private string GenerateIllustrationsWebServiceCall(IllustrationRequest illustrationRequest, string url)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    // Call Illustrations web service

                    var policy = Polly.Policy.Handle<Exception>()
                        .WaitAndRetry(Settings.Default.WebCallRetries, attempt => TimeSpan.FromTicks(Settings.Default.WebCallDelay.Ticks * attempt),
                        (ex, timeSpan) =>
                        {

                        });

                    var illustrationRequest2 = illustrationRequest.ToString();

                    var jsonSerialiser = new JavaScriptSerializer();
                    var json = jsonSerialiser.Serialize(illustrationRequest);

                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    Task<HttpResponseMessage> taskPost = policy.Execute(() => httpClient.PostAsync(url, content));
                    taskPost.Wait();

                    HttpResponseMessage response = taskPost.Result;
                    var responseString = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return responseString;
                    }
                    else
                    {
                        var message = $"Status code: {response.StatusCode}. {responseString}.";
                        throw new Exception(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to complete the call to the Illustrations web service call unsuccessful for policyId: {illustrationRequest.PolicyId} Message: {ex.Message}.");
            }
        }

        private string GetRegionConnectionString(string region)
        {
            var regionUrl = string.Empty;

            switch (region.ToUpper())
            {
                case "LOCAL":
                    regionUrl = Settings.Default.IllustrationsLocalWebServiceUrl;
                    break;

                case "TEST":
                    regionUrl = Settings.Default.IllustrationsTestWebServiceUrl;
                    break;

                case "UAT":
                    regionUrl = Settings.Default.IllustrationsUatWebServiceUrl;
                    break;

                case "MODEL":
                    regionUrl = Settings.Default.IllustrationsModlWebServiceUrl;
                    break;

                case "PROD":
                    regionUrl = Settings.Default.IllustrationsProdWebServiceUrl;
                    break;

                case "INT":
                    regionUrl = Settings.Default.IllustrationsIntWebServiceUrl;
                    break;
            }

            return regionUrl;
        }

        private void btnLoadTitaniumIllusBasic_Click(object sender, EventArgs e)
        {
            try
            {
                TitaniumIulLoader titaniumIulLoader = new TitaniumIulLoader();

                var iulIllusBasicFileLocation = "C:\\Work\\TF_DEV\\WOW.Illustration\\1_DEVL\\TestTools\\CommonIllustrationServiceTester\\TestCases\\ISSUE_IUL_ILLUS_Basic.json";

                IllustrationRequest illustrationRequest = titaniumIulLoader.LoadIssueIulIllus(iulIllusBasicFileLocation);

                var illusBasicFileName = "ISSUE_IUL_ILLUS_Basic.pdf";

                if (illustrationRequest != null)
                {
                    ValidateRequest(illustrationRequest, illusBasicFileName);
                }
            }
            catch (Exception ex)
            {
                tbResults.Text = ex.Message;
            }
        }

        private void btnLoadTitaniumAmendCost_Click_1(object sender, EventArgs e)
        {
            try
            {
                TitaniumIulLoader titaniumIulLoader = new TitaniumIulLoader();

                var iulAmendFileLocation = "C:\\Work\\TF_DEV\\WOW.Illustration\\1_DEVL\\TestTools\\CommonIllustrationServiceTester\\TestCases\\ISSUE_IUL_AMEND_Cost.json";

                IllustrationRequest illustrationRequest = titaniumIulLoader.LoadIssueIulIllus(iulAmendFileLocation);

                var amendCostFileName = "ISSUE_IUL_AMEND_Cost.pdf";

                if (illustrationRequest != null)
                {
                    ValidateRequest(illustrationRequest, amendCostFileName);
                }
            }
            catch (Exception ex)
            {
                tbResults.Text = ex.Message;
            }
        }

        private void btnLoadTitaniumGeneralCost_Click(object sender, EventArgs e)
        {
            try
            {
                TitaniumIulLoader titaniumIulLoader = new TitaniumIulLoader();

                var iulGeneralFileLocation = "C:\\Work\\TF_DEV\\WOW.Illustration\\1_DEVL\\TestTools\\CommonIllustrationServiceTester\\TestCases\\ISSUE_IUL_General_Cost.json";

                IllustrationRequest illustrationRequest = titaniumIulLoader.LoadIssueIulIllus(iulGeneralFileLocation);

                var generalCostFileName = "ISSUE_IUL_GENERAL_Cost.pdf";

                if (illustrationRequest != null)
                {
                    ValidateRequest(illustrationRequest, generalCostFileName);
                }
            }
            catch (Exception ex)
            {
                tbResults.Text = ex.Message;
            }
        }

        private void btnLoadTitaniumIllusRevised_Click(object sender, EventArgs e)
        {
            try
            {
                TitaniumIulLoader titaniumIulLoader = new TitaniumIulLoader();

                var iulIllusBasicFileLocation = "C:\\Work\\TF_DEV\\WOW.Illustration\\1_DEVL\\TestTools\\CommonIllustrationServiceTester\\TestCases\\ISSUE_IUL_ILLUS_Revised.json";

                IllustrationRequest illustrationRequest = titaniumIulLoader.LoadIssueIulIllus(iulIllusBasicFileLocation);

                var illusBasicFileName = "ISSUE_IUL_ILLUS_Revised.pdf";

                if (illustrationRequest != null)
                {
                    ValidateRequest(illustrationRequest, illusBasicFileName);
                }
            }
            catch (Exception ex)
            {
                tbResults.Text = ex.Message;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
                if (result == DialogResult.OK) // Test result.
                {
                    string filePath = openFileDialog1.FileName;

                    TitaniumIulLoader titaniumIulLoader = new TitaniumIulLoader();

                    IllustrationRequest illustrationRequest = titaniumIulLoader.LoadIssueIulIllus(filePath);

                    var pdfFileName = Path.GetFileNameWithoutExtension(filePath) + ".pdf";

                    if (illustrationRequest != null)
                    {
                        ValidateRequest(illustrationRequest, pdfFileName);
                    }
                }
            }
            catch (Exception ex)
            {
                tbResults.Text = ex.Message;
            }
        }
    }
}
