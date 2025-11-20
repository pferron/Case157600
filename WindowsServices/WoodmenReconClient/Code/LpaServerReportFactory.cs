using log4net;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Linq;
using WOW.WoodmenReconClient.Models;
using System.Management;
using System.Diagnostics;
using WindowsInstaller;

namespace WOW.WoodmenReconClient.Code
{
    class LpaServerReportFactory : ReportFactory
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(LpaServerReportFactory));

        private const string _regPath = @"SOFTWARE\Wow6432Node\StoneRiver\ACL";
        private const string _appServerKey = "AppServerPath";
        private const string _lifeServerKey = "LifeServerPath";
        private const string _webServerKey = "WebServerPath";


        private const string _relativeAppServerPath = @"Server\system.ver";
        private const string _relativeLifeServerPath = @"LifeServer\system.ver";
        private const string _relativeWebServerPath = @"Web\bin\system.ver";

        private const string _acceleraterAppServer = "Accelerate® ES APP SERVER";
        private const string _acceleraterLifeServer = "Accelerate® ES LIFE SERVER";
        private const string _acceleraterWebServer = "Accelerate® ES WEB SERVER";

        public override void CreateReconReport()
        {
            base.CreateReconReport();

            base.Report.Hostname = Environment.MachineName;
            base.Report.ReportName = "LPA App Server Report";

            // Using UTC since systems are distributed nationally.
            base.Report.ReportCreateDateUtc = DateTime.UtcNow;

            // Fetch LPA server data points
            var appServerSoftwareVersion = FetchSoftwareVersion(LpaServerType.AppServer);
            var lifeServerSoftwareVersion = FetchSoftwareVersion(LpaServerType.LifeServer);
            var webServerSoftwareVersion = FetchSoftwareVersion(LpaServerType.WebServer);



            Report.DataItems.Add(new ReconReportDataItem { DataName = "App Server Software Version", DataValue = appServerSoftwareVersion });
            Report.DataItems.Add(new ReconReportDataItem { DataName = "Life Server Software Version", DataValue = lifeServerSoftwareVersion });
            Report.DataItems.Add(new ReconReportDataItem { DataName = "Web Server Software Version", DataValue = webServerSoftwareVersion });

            Report.DataItems.Add(new ReconReportDataItem { DataName = "Accelerate ES APP SERVER", DataValue = FetchInstalledVersion(_acceleraterAppServer) });
            Report.DataItems.Add(new ReconReportDataItem { DataName = "Accelerate ES LIFE SERVER", DataValue = FetchInstalledVersion(_acceleraterLifeServer) });
            Report.DataItems.Add(new ReconReportDataItem { DataName = "Accelerate ES WEB SERVER", DataValue = FetchInstalledVersion(_acceleraterWebServer) });
            

        }

        /// <summary>
        /// Get the software versions of LPA Server Types
        /// </summary>
        /// <param name="appServer">The type of app server</param>
        /// <returns>The version based on the app server</returns>
        private string FetchSoftwareVersion(LpaServerType appServer)
        {
            try
            {
                switch (appServer)
                {
                    case LpaServerType.AppServer:
                        return GetFileVersion(GetValueFromRegKey(_regPath, _appServerKey), _relativeAppServerPath);
                    case LpaServerType.LifeServer:
                        return GetFileVersion(GetValueFromRegKey(_regPath, _lifeServerKey), _relativeLifeServerPath);
                    case LpaServerType.WebServer:
                        return GetFileVersion(GetValueFromRegKey(_regPath, _webServerKey), _relativeWebServerPath);
                    default:
                        throw new NotImplementedException();
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error($"Unable to Fetch Software version for {appServer} type", ex);
                return "Error";
            }
        }

        /// <summary>
        /// Find the version of the first product that contains the productName
        /// </summary>
        /// <param name="productName">The product that is installed through windows installer product name</param>
        /// <returns>The version of the product otherwise not found.</returns>
        public string FetchInstalledVersion(string productName)
        {
            try
            {
                if (log.IsDebugEnabled) log.Debug($"Attempting to find '{productName}' in installed products");

                //get the installer things started
                Type type = Type.GetTypeFromProgID("WindowsInstaller.Installer");
                Installer installer = Activator.CreateInstance(type) as Installer;
                StringList products = installer.Products;

                //loop through all installed products from Window's Installer
                foreach (string productGuid in products)
                {
                    //get the name and version
                    string name = installer.ProductInfo[productGuid, "ProductName"].ToLower();
                    string version = installer.ProductInfo[productGuid, "VersionString"];

                    if(log.IsDebugEnabled) { log.Debug($"Checking product name: {name} against {productName.ToLower()}"); }

                    //check if the installed product contains the product name
                    if (name.Contains(productName.ToLower()))
                    {
                        if(log.IsDebugEnabled) { log.Debug("Found"); }
                        //return the first instance of product name
                        return version;
                    }
                }

                return "Not Found";
            } catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error($"Unable to fetch product version of '{productName}'", ex);
                return "Error";
            }
        }

        private string FetchProductVersion(string productName)
        {
            try
            {
                ManagementObjectSearcher mgmtObjSearcher = new ManagementObjectSearcher($"SELECT name,version FROM Win32_Product where name like '%{productName}%'");
                ManagementObjectCollection colDisks = mgmtObjSearcher.Get();

                foreach (ManagementObject objDisk in colDisks)
                {
                    Console.WriteLine($"Result from name like '{productName}' Name: {objDisk["name"]}");
                    return (string)objDisk["Version"];
                }

                return "Not Found";
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Unable to fetch product version", ex);
                return "Error";
            }
        }

        /// <summary>
        /// Get the value of a registry item given the key path and key name
        /// </summary>
        /// <param name="keyPath">The path of the registry item</param>
        /// <param name="keyName">The actual name of the key in the registry</param>
        /// <returns>The value of the key as a string</returns>
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
                    catch (NullReferenceException)
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

        /// <summary>
        /// Verify the file information of a .ver file
        /// </summary>
        /// <param name="path">The path from the registry entry</param>
        /// <param name="relativePath">the relative path from the registry entry</param>
        /// <returns>The version of the file</returns>
        private string GetFileVersion(string path, string relativePath)
        {
            try
            {
                var versionFilePath = Path.Combine(path, relativePath);
                var actualFile = new FileInfo(versionFilePath);

                if(!actualFile.Exists)
                {
                    return "Not Found";
                }

                return File.ReadAllText(versionFilePath).TrimEnd('\r', '\n');

            }
            catch (Exception ex)
            {
                //handle and return error
                if (log.IsErrorEnabled) log.Error("Unable to Verify File Information", ex);
                return "Error";
            }
        }


        private enum LpaServerType
        {
            AppServer,
            LifeServer,
            WebServer
        }
    }
}
