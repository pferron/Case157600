using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using WOW.MyWoodmenIllustrationClient.Data;
using WOW.MyWoodmenIllustrationClient.Properties;
using WOW.MyWoodmenIllustrationClient.Utilities;
using WOW.Illustration.Model.Generation.Response;

namespace WOW.MyWoodmenIllustrationClient.Model
{
    internal class Request
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Request));

        /// <summary>
        /// Loads a list of illustration requests.
        /// </summary>
        /// <returns>A list of zero or more illustration requests.</returns>
        internal static List<Request> FetchRequests()
        {
            if (log.IsDebugEnabled) log.Debug("FetchRequests - Start.");

            var list = new List<Request>();
            using (var dt = IllustrationRequest.SelectNewRequests())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var request = new Request(dr);
                    list.Add(request);
                }
            }

            if (log.IsDebugEnabled) log.DebugFormat(CultureInfo.InvariantCulture, "FetchRequests - New Requests: {0}", list.Count);
            return list;
        }

        /// <summary>
        /// Reformats the specified policy ID into INGENIUM format.
        /// </summary>
        /// <param name="policyId">The input string.</param>
        /// <returns>A properly formatted policy ID or String.Empty.</returns>
        private static string FormatPolicyId(string policyId)
        {
            int policyInt;
            var formattedString = string.Empty;
            if (int.TryParse(policyId, out policyInt))
            {
                formattedString = policyInt.ToString("000000000", CultureInfo.InvariantCulture);
            }

            return formattedString;
        }

        /// <summary>
        /// Creates a new instance of this request object using the data in the specified data row.
        /// </summary>
        /// <param name="dr">The data row containing the state for this object.</param>
        private Request(DataRow dr)
        {
            PolicyId = (string)dr["PIRQ_POL_ID"];
            RequestDate = (string)dr["PIRQ_REQ_TS"];
            var temp = RequestDate.Substring(0, 10);
            temp = RequestDate.Trim();
            FipContent = (string)dr["PIRQ_FIP_FILE"];
            PolicyId = FormatPolicyId(PolicyId);
            FileName = string.Format("{0}_{1}.fip", PolicyId, temp);
            ErrorMessages = new List<string>();
        }

        internal string PolicyId { get; private set; }
        internal string FileName { get; private set; }
        private string FipContent { get; set; }
        internal FipFile FipFile { get; set; }
        internal List<string> ErrorMessages { get; private set; }

        /// <summary>
        /// The Date and Time that the Illustration request was created.
        /// </summary>
        /// <remarks>Stored as a string to preserve precision.</remarks>
        internal string RequestDate { get; private set; }
        
        /// <summary>
        /// convert base64 string from WIS to binary stream for DB2
        /// </summary>
        /// <param name="pdf"></param>
        /// <returns></returns>
        internal byte[] GetPDFAsByteArray(string pdf)
        {
            string temp = string.Empty;
            byte[] tmpBytes;
            tmpBytes = System.Convert.FromBase64String(pdf);
            return tmpBytes;
        }

        /// <summary>
        /// Processes the individual FIP request.
        /// </summary>
        internal void ProcessFipRequest()
        {
            PrepareFipFileObject();

                try
                {
                    var response = TransmitRequest();
                    byte[] pdf;
                    if (!response.HasPdfFile)
                    {
                        string pdfErr = string.Format("Failure processing fip request. PolicyId: {0}, RequestDate: {1}", PolicyId, RequestDate);
                        var errUpdate =  IllustrationRequest.UpdateAsError(PolicyId,RequestDate,pdfErr);
                    }
                    else
                    {
                        pdf = GetPDFAsByteArray(response.PdfFileAttachment);
                        IllustrationRequest.UploadPdf(PolicyId, RequestDate,pdf);
                    }
                }
                catch (Exception ex)
                {
                    if (log.IsErrorEnabled)
                    {
                        var message = string.Format(CultureInfo.InvariantCulture, "Failure processing fip request. PolicyId: {0}, RequestDate: {1}", PolicyId, RequestDate);
                        log.Error(message, ex);
                    }
                }

        }

        /// <summary>
        ///  Deserializes the FIP File object and updates the output location.
        /// </summary>
        private void PrepareFipFileObject()
        {
            if (!System.IO.Directory.Exists(Settings.Default.FipRequestFolder))
            {
                Directory.CreateDirectory(Settings.Default.FipRequestFolder);
            }
            FipFile = FipFile.Deserialize(FipContent);

            FipFile.UpdateOutputLocation(FileName);

            var path = Path.Combine(Settings.Default.FipRequestFolder, FileName);
            File.WriteAllText(path, FipFile.ToString());
        }

        /// <summary>
        /// Validates the request and FIP file.
        /// </summary>
        /// <returns>True, if valid; otherwise, False.</returns>

        /// <summary>
        /// Packs up and transmits the illustration request.
        /// </summary>
        /// <returns>The illustration response object.</returns>
        private WoodmenIllustrationResponse TransmitRequest()
        {
            using (var client = new HttpClient())
            {
                if (Settings.Default.FipRequestTimeout.Ticks > 0)
                {
                    client.Timeout = Settings.Default.FipRequestTimeout;
                }
                using (var content = new MultipartFormDataContent())
                {
                    using (var fileStream = new MemoryStream(FipFile.ToBytes(), false))
                    {
                        using (var contentStream = new StreamContent(fileStream))
                        {
                            content.Add(contentStream, "fipFile", FileName);
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                            using (var message = client.PostAsync(Settings.Default.FipRequestUrl, content))
                            {
                                message.Wait();
                                using (var responseTask = message.Result.Content.ReadAsStringAsync())
                                {
                                    responseTask.Wait();
                                    var transmitResponse = responseTask.Result;
                                    return MessageHelper.UnpackWoodmenIllustrationResponse(transmitResponse);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
