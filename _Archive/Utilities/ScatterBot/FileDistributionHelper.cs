
using System;
using System.IO;
namespace ScatterBot
{
    internal static class FileDistributionHelper
    {
        public static void DistributeFile(string sourceFilePath, string targetFilePath)
        {
            try
            {
                if (!File.Exists(sourceFilePath))
                {
                    throw new FileNotFoundException("Master version file was not found.", sourceFilePath);
                }

                File.Copy(sourceFilePath, targetFilePath, true);
            }
            catch (Exception ex)
            {
                var msg = String.Format("An error occurred while trying to copy file from '{0}' to '{1}'.", sourceFilePath, targetFilePath);

                throw new FileDistributionHelperException(msg, ex);
            }
        }

        public static void DistributeFolder(string sourceFolderPath, string targetFolderPath)
        {
            try
            {
                if (!Directory.Exists(sourceFolderPath))
                {
                    throw new DirectoryNotFoundException(String.Format("Master RSU folder '{0}' was not found.", sourceFolderPath));
                }

                if (sourceFolderPath.Equals(targetFolderPath, StringComparison.InvariantCultureIgnoreCase))
                {
                    return;
                }

                // Copy folder structure
                foreach (string sourceSubFolder in Directory.GetDirectories(sourceFolderPath, "*", SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory(sourceSubFolder.Replace(sourceFolderPath, targetFolderPath));
                }

                // Copy files
                foreach (string sourceFile in Directory.GetFiles(sourceFolderPath, "*", SearchOption.AllDirectories))
                {
                    string destinationFile = sourceFile.Replace(sourceFolderPath, targetFolderPath);
                    File.Copy(sourceFile, destinationFile, true);
                }
            }
            catch (Exception ex)
            {
                var msg = String.Format("An error occurred while trying to copy folder from '{0}' to '{1}'.", sourceFolderPath, targetFolderPath);

                throw new FileDistributionHelperException(msg, ex);
            }
        }
    }
}
