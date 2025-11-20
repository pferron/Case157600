using log4net;
using LpaDesktopSyncUpdater.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LpaDesktopSyncUpdater
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        private static string _lpaInstallFolderPath;

        static void Main(string[] args)
        {
            // Activate log4net
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            
            // Using helper class to configure log4net so I won't need a config file.
            LoggingHelper.ConfigureLogging();

            // Set path for installation root
            _lpaInstallFolderPath = GetValueFromRegKey(Settings.Default.LifePortraitsRegKeyPath, Settings.Default.LifePortraitsRegKeyName);

            if(String.IsNullOrWhiteSpace(_lpaInstallFolderPath))
            {
                if(log.IsErrorEnabled) { log.Error("LPA Folder Path could not be read from the registry."); }

                return;
            }

            if (log.IsDebugEnabled) { log.DebugFormat("LifePortraits Desktop installation location: {0}.", _lpaInstallFolderPath); }

            var configFilePath = Path.Combine(_lpaInstallFolderPath, Settings.Default.SyncConfigRelativePath);

            if(!File.Exists(configFilePath))
            {
                if (log.IsErrorEnabled) { log.Error("LPA Sync Config file could not be found."); }

                return;
            }

            if(UpdateSyncConfig(configFilePath))
            {
                if (log.IsDebugEnabled) { log.DebugFormat("Config file '{0}' was successfully updated.", configFilePath); }
            }
            else
            {
                if (log.IsErrorEnabled) { log.ErrorFormat("An error occurred while trying to update the config file '{0}'.", configFilePath); }
            }

            try
            {
                if (log.IsDebugEnabled) { log.DebugFormat("Attempting to restart service '{0}'.", Settings.Default.LifeManagerServiceName); }

                RemoteServicesHelper.RestartService(Environment.MachineName, Settings.Default.LifeManagerServiceName);

                if (log.IsDebugEnabled) { log.Debug("Service restart complete."); }
            }
            catch(Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error(String.Format("An error occurred while trying to restart service '{0}'.", Settings.Default.LifeManagerServiceName), ex); }

                return;
            }

            if (log.IsDebugEnabled) { log.Debug("Done!"); }
        }

        internal static bool CreateCommonFolder(string folderPath)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(folderPath))
                {
                    if (log.IsErrorEnabled) { log.Error("Folder path is null or empty."); }

                    return false;
                }

                if (Directory.Exists(folderPath))
                {
                    if (log.IsWarnEnabled) { log.WarnFormat("Folder path '{0}' already exists. Contents and security will not be altered.", folderPath); }

                    return true;
                }

                // Using this instead of the "Everyone" string means we work on non-English systems.
                SecurityIdentifier everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);

                Directory.CreateDirectory(folderPath);

                DirectorySecurity sec = Directory.GetAccessControl(folderPath);
                sec.AddAccessRule(new FileSystemAccessRule(everyone, FileSystemRights.Modify | FileSystemRights.Synchronize, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));

                Directory.SetAccessControl(folderPath, sec);

                if (log.IsDebugEnabled) { log.DebugFormat("New folder '{0}' has been created.", folderPath); }

                return true;
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error(String.Format("An error occurred creating the folder '{0}'.", folderPath), ex); }

                return false;
            }
        }

        private static bool UpdateSyncConfig(string configFilePath)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(configFilePath))
                {
                    if (log.IsErrorEnabled) { log.Error("Path to XML file is null or empty."); }

                    return false;
                }

                if (!File.Exists(configFilePath))
                {
                    if (log.IsErrorEnabled) { log.ErrorFormat("XML file '{0}' does not exist.", configFilePath); }

                    return false;
                }

                //< syncConfiguration >
                //  < applicationsSyncSettings >
                //      < syncSettings applicationId = "WOW_DESKTOP" displayName = "WOW Desktop" syncInterval = "00:10:00" behaviour = "Manual" />
                //  </ applicationsSyncSettings >
                //</ syncConfiguration >

                XElement config = XElement.Load(configFilePath);

                
                var settingsNode = config.Element("applicationsSyncSettings").Element("syncSettings");


                settingsNode.SetAttributeValue("behaviour", "Automatic");

                config.Save(configFilePath);

                return true;
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error(String.Format("An error occurred updating '{0}'.", configFilePath), ex); }

                return false;
            }
        }

        private static string GetValueFromRegKey(string keyPath, string keyName)
        {
            try
            {
                if (log.IsDebugEnabled) { log.DebugFormat("Attempting to read key '{0}' at '{1}'.", keyName, keyPath); }

                using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(keyPath))
                {
                    var applicationPath = (string)registryKey.GetValue(keyName);

                    return applicationPath;
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
