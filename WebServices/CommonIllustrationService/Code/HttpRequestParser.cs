using log4net;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Wow.CommonIllustrationService.Code
{
    public static class HttpRequestParser
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(HttpRequestParser));

        internal async static Task<string> ExtractFile(HttpRequestMessage request)
        {
            if (request.Content.IsMimeMultipartContent())
            {
                string uploadRoot = ServiceHelper.GetUploadDirectoryPath();

                var provider = new MultipartFormDataStreamProvider(uploadRoot);

                provider = await request.Content.ReadAsMultipartAsync(provider).ContinueWith(t => t.Result);

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
                return await request.Content.ReadAsStringAsync();

            }
        }
    }
}