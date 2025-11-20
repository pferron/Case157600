using log4net;
using System.Globalization;
using System.IO;
using System.Web.Hosting;
using System.Xml.Serialization;
using Wow.CommonIllustrationService.Properties;

namespace Wow.CommonIllustrationService.Code
{
    internal static class ServiceHelper
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ServiceHelper));

        private static string uploadFolderPath;
        private static string payloadFolderPath;

        /// <summary>
        /// Returns the file system folder path to the upload folder from the config file. Maps virtual paths to the file system, as well.
        /// </summary>
        /// <returns>File system folder path</returns>
        internal static string GetUploadDirectoryPath()
        {
            if (log.IsDebugEnabled) { log.Debug("Fetching folder path for file uploads."); }

            if (string.IsNullOrEmpty(uploadFolderPath))
            {
                if (log.IsDebugEnabled) { log.Debug("Calculating folder path."); }

                if (Settings.Default.UploadStorageFolder.Contains("~"))
                {
                    // This path needs to be mapped to the file system
                    uploadFolderPath = HostingEnvironment.MapPath(Settings.Default.UploadStorageFolder); // web service folder e.g. ~/App_Data/uploads
                }
                else
                {
                    // This path is a file system path
                    uploadFolderPath = Settings.Default.UploadStorageFolder;
                }

                if (log.IsDebugEnabled) { log.DebugFormat("Folder path set to '{0}'.", uploadFolderPath); }

                if (!Directory.Exists(uploadFolderPath))
                {
                    if (log.IsDebugEnabled) { log.Debug("Folder path does not exist. Creating folder path."); }

                    Directory.CreateDirectory(uploadFolderPath);

                    if (log.IsDebugEnabled) { log.Debug("Folder path created."); }
                }
            }

            return uploadFolderPath;
        }

        internal static string GetPayloadDirectoryPath()
        {
            if (log.IsDebugEnabled) { log.Debug("Fetching folder path for service payloads."); }

            if (string.IsNullOrEmpty(payloadFolderPath))
            {
                if (log.IsDebugEnabled) { log.Debug("Calculating folder path."); }

                if (Settings.Default.PayloadStorageFolder.Contains("~"))
                {
                    // This path needs to be mapped to the file system
                    payloadFolderPath = HostingEnvironment.MapPath(Settings.Default.PayloadStorageFolder); // web service folder e.g. ~/App_Data/uploads
                }
                else
                {
                    // This path is a file system path
                    payloadFolderPath = Settings.Default.PayloadStorageFolder;
                }

                if (log.IsDebugEnabled) { log.DebugFormat("Folder path set to '{0}'.", payloadFolderPath); }

                if (!Directory.Exists(payloadFolderPath))
                {
                    if (log.IsDebugEnabled) { log.Debug("Folder path does not exist. Creating folder path."); }

                    Directory.CreateDirectory(payloadFolderPath);

                    if (log.IsDebugEnabled) { log.Debug("Folder path created."); }
                }
            }

            return payloadFolderPath;
        }

        internal static string SerializeAcordObject(object toSerialize)
        {
            if (toSerialize == null)
            {
                return null;
            }

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("FIP", "http://www.fiservinsurance.com/LPES/Base/OneView");
            namespaces.Add(string.Empty, "http://ACORD.org/Standards/Life/2");
            namespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");

            var xmlSerializer = new XmlSerializer(toSerialize.GetType());

            using (StringWriter sw = new StringWriter(CultureInfo.InvariantCulture))
            {
                xmlSerializer.Serialize(sw, toSerialize, namespaces);
                return sw.ToString();
            }
        }
    }
}