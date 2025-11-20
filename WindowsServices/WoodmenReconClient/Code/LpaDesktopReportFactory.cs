using log4net;
using Microsoft.Win32;
using System;
using System.IO;
using WOW.WoodmenReconClient.Models;
using WOW.WoodmenReconClient.Properties;

namespace WOW.WoodmenReconClient.Code
{
    class LpaDesktopReportFactory : ReportFactory
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(LpaDesktopReportFactory));

        private readonly string _regKeyPath = Settings.Default.RegKeyPath;
        private readonly string _regKeyVersion = Settings.Default.RegKeyVersion;
        private readonly string _regKeyAppPath = Settings.Default.RegKeyAppPath;
        private readonly string _relativeVersionFilePath = Settings.Default.RelativeVersionFilePath;

        public override void CreateReconReport()
        {
            base.CreateReconReport();

            base.Report.Hostname = Environment.MachineName;
            base.Report.ReportName = "LifePortraits Desktop System";

            // Using UTC since systems are distributed nationally.
            base.Report.ReportCreateDateUtc = DateTime.UtcNow;

            var lpaVersion = FetchPlatformVersion();
            var lpaRegistryVersion = FetchRegistryVersion();

            base.Report.DataItems.Add(new ReconReportDataItem { DataName = "LpaRegistryVersion", DataValue = lpaRegistryVersion });
            base.Report.DataItems.Add(new ReconReportDataItem { DataName = "LpaVersion", DataValue = lpaVersion.VersionNumber });
            base.Report.DataItems.Add(new ReconReportDataItem { DataName = "LpaVersionModifiedDate", DataValue = (lpaVersion.ModifiedDate.HasValue) ? lpaVersion.ModifiedDate.Value.ToString("s") : "Not Found" }); // using sortable date string

        }

        private string FetchRegistryVersion()
        {
            try
            {
                return GetValueFromRegKey(_regKeyPath, _regKeyVersion);
            }
            catch(Exception ex)
            {
                if(log.IsErrorEnabled) { log.Error("Error occurred while trying to read LPA version from registry.", ex); }
                return "Error";
            }
        }

        private LpaPlatformVersionModel FetchPlatformVersion()
        {
            try
            {
                var model = new LpaPlatformVersionModel();

                // Get installation path
                var lpaInstallFolderPath = GetValueFromRegKey(_regKeyPath, _regKeyAppPath);

                // Calculate path to version file
                var versionFilePath = Path.Combine(lpaInstallFolderPath, _relativeVersionFilePath);

                // Create FileInfo object to access last write datetime.
                var versionFile = new FileInfo(versionFilePath);

                //If the file doesn't exist. Then it isn't installed and should be handled as such
                if(!versionFile.Exists)
                {
                    model.ModifiedDate = null;
                    model.VersionNumber =  "Not Found";
                    return model;
                }

                // Using UTC since systems are distributed nationally.
                model.ModifiedDate = versionFile.LastWriteTimeUtc;
                model.VersionNumber = File.ReadAllText(versionFilePath).TrimEnd('\r', '\n');

                return model;
            }
            catch(Exception ex)
            {
                if(log.IsErrorEnabled) { log.Error("Error occurred while trying to read LPA version file.", ex); }
                return new LpaPlatformVersionModel() { ModifiedDate = null, VersionNumber = "Error" };
            }
        }

        private static string GetValueFromRegKey(string keyPath, string keyName)
        {
            try
            {
                if (log.IsDebugEnabled) { log.DebugFormat("Attempting to read key '{0}' at '{1}'.", keyName, keyPath); }

                using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(keyPath))
                {
                    try
                    {
                        var applicationPath = registryKey.GetValue(keyName);

                        return (string)applicationPath;
                    }
                    catch(NullReferenceException)
                    {
                        //GetValue for RegistryKey will throw a NullReferenceException if the key does not exist
                        //if that happens we can assume the version is not found and a more serious error hasn't occured.
                        return "Not Found";
                    }
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error(String.Format("An error occurred while reading the registry. Path: {0}, KeyName: {1}", keyPath, keyName), ex); }

                return null;
            }
        }
    }
}
