using log4net;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace WOW.WoodmenIllustrationService.Code
{
    public static class HttpRequestParser
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(HttpRequestParser));

        internal static string ExtractFile(HttpRequestMessage request)
        {
            if (request.Content.IsMimeMultipartContent())
            {
                string uploadRoot = ServiceHelper.GetUploadDirectoryPath();

                var provider = new MultipartFormDataStreamProvider(uploadRoot);

                var task = Task.Run(async () => await request.Content.ReadAsMultipartAsync(provider));
                task.Wait();
                provider = task.Result;
                
                var fileData = provider.FileData.First();

                var localName = fileData.LocalFileName;
                var content = File.ReadAllText(localName);

                if (log.IsDebugEnabled)
                {
                    var embeddedName = fileData.Headers.ContentDisposition.FileName;
                    log.DebugFormat("File {0} was successfully uploaded as '{1}'.", embeddedName, localName);
                }

                return content;
            }
            else
            {
                log.Error("Invalid request received. Request must be in a multipart/form-data request.");

                var errorResponse = request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Request must be a multipart/form-data request and contain one file.");
                throw new HttpResponseException(errorResponse);
            }
        }

        internal static string ExtractUserName(HttpRequestMessage request)
        {
            IEnumerable<string> headerValues;
            string username;

            if (request.Headers.TryGetValues("X-USERNAME", out headerValues))
            {
                username = headerValues.FirstOrDefault();
                log.DebugFormat("Username '{0}' was extracted from header 'X-USERNAME'.", username);
            }
            else
            {
                username = null;
                log.DebugFormat("Header 'X-USERNAME' was not detected in request.");
            }

            return username;
        }
    }
}