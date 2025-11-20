using log4net;
using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Web.Hosting;
using System.Xml;
using WOW.WoodmenIllustrationService.Properties;

namespace WOW.WoodmenIllustrationService.Code
{
    /// <summary>
    /// Helper class for writing XML payloads to files so they can be associated with captured error messages.
    /// </summary>
    internal static class LargePayloadLogger
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(LargePayloadLogger));

        private static string payloadStorageFolderPath;

        public static PayloadLoggerResponse LogPayloadToFile(XmlElement element, string filePrefix)
        {
            return LogPayloadToFile(element, filePrefix, string.Empty);
        }

        public static PayloadLoggerResponse LogPayloadToFile(XmlElement element, string filePrefix, string fileId)
        {
            var sb = new StringBuilder();
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            using (var xmlWriter = XmlWriter.Create(sb, settings))
            {
                element.WriteTo(xmlWriter);
            }

            return LogPayloadToFile(sb.ToString(), filePrefix, fileId);
        }

        /// <summary>
        /// Utility method to write serialized data to the file system for later analysis. Returns null if there's an error writing the file out.
        /// </summary>
        /// <param name="fileContents">String representation of an object or a other data</param>
        /// <param name="filePrefix">A string to prepend the file name to make sorting and finding the file easier.</param>
        /// <param name="fileId">A string to use at the file name. When combined with the prefix feature, this is useful for pairing request and responses together.</param>
        /// <returns>Full path to logged file</returns>
        public static PayloadLoggerResponse LogPayloadToFile(string fileContents, string filePrefix, string fileId)
        {
            // Exposed for logging
            var filePath = string.Empty;

            try
            {
                // Calculate GUID for file name, if needed
                if (string.IsNullOrEmpty(fileId))
                {
                    fileId = Guid.NewGuid().ToString("N");
                }

                // Read folder location from setttings.
                var fileStoragePath = GetPayloadStorageFolderPath();

                // Use fileId as file name with user prefix
                filePath = Path.Combine(fileStoragePath, string.Format(CultureInfo.InvariantCulture, "{0}_{1}.{2}", filePrefix, fileId, Settings.Default.PayloadFileExtension));

                // Write string to file
                File.WriteAllText(filePath, fileContents);

                // Return object that has file path and ID
                return new PayloadLoggerResponse { PayloadFileId = fileId, PayloadFilePath = filePath };
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error(string.Format(CultureInfo.InvariantCulture, "There was an error writing content to file '{0}'.", filePath), ex); }

                return null;
            }
        }

        /// <summary>
        /// Utility method to write serialized data to the file system for later analysis. The file name will contain the provided prefix value.
        /// </summary>
        /// <param name="fileContents">String representation of an object or a other data</param>
        /// <param name="filePrefix">A string to prepend to the file name to make sorting and finding the file easier.</param>
        /// <returns>Object with the file path and file ID as a GUID</returns>
        public static PayloadLoggerResponse LogPayloadToFile(string fileContents, string filePrefix)
        {
            return LogPayloadToFile(fileContents, filePrefix, null);
        }

        /// <summary>
        /// Utility method to write serialized data to the file system for later analysis.
        /// </summary>
        /// <param name="fileContents">String representation of an object or a other data</param>
        /// <returns>Object with the file path and file ID as a GUID</returns>
        public static PayloadLoggerResponse LogPayloadToFile(string fileContents)
        {
            return LogPayloadToFile(fileContents, string.Empty);
        }

        /// <summary>
        /// Fetches path to payload storage folder
        /// </summary>
        /// <returns>Folder path on file system</returns>
        private static string GetPayloadStorageFolderPath()
        {
            if (string.IsNullOrEmpty(payloadStorageFolderPath))
            {
                if (Settings.Default.PayloadStorageFolder.Contains("~"))
                {
                    // This path needs to be mapped to the file system
                    payloadStorageFolderPath = HostingEnvironment.MapPath(Settings.Default.PayloadStorageFolder); // web service folder e.g. ~/App_Data/uploads
                }
                else
                {
                    // This path is a file system path
                    payloadStorageFolderPath = Settings.Default.PayloadStorageFolder;
                }

                if (!Directory.Exists(payloadStorageFolderPath))
                {
                    Directory.CreateDirectory(payloadStorageFolderPath);
                }
            }

            return payloadStorageFolderPath;
        }
    }

    internal class PayloadLoggerResponse
    {
        public string PayloadFileId { get; set; }
        public string PayloadFilePath { get; set; }
    }
}