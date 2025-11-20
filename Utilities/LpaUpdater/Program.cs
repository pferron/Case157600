using log4net;
using LpaUpdater.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LpaUpdater
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        private static string _lpaInstallFolderPath;
        private static string _verisonFilePath;
        private static string _detectedLpaVersionNumber;

        //private static readonly string _sqlCommand = Resource1.Update;

        [DllImport("shell32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsUserAnAdmin();

        static int Main(string[] args)
        {
            try
            {
                log.Info("Starting update...");

                // Set directory so we can activate log4net
                Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

                // Using helper class to configure log4net so I won't need a config file.
                LoggingHelper.ConfigureLogging();

                log.Info("Logging configured...");

                // Make sure tool is running with elevated permissions
                if (!IsUserAnAdmin())
                {
                    if (log.IsErrorEnabled) { log.Error("This application requires elevated access. Please execute as Administrator. Update cancelled."); }

                    return -1;
                }

                // Set paths
                _lpaInstallFolderPath = GetValueFromRegKey(Settings.Default.LifePortraitsRegKeyPath, Settings.Default.LifePortraitsRegKeyName);

                if (log.IsDebugEnabled) { log.Debug($"LifePortraits Desktop installation location: {_lpaInstallFolderPath}."); }

                _verisonFilePath = Path.Combine(_lpaInstallFolderPath, Settings.Default.VersionFilePath);

                // Read current ver file
                _detectedLpaVersionNumber = ReadLpaVersionFile(_verisonFilePath);

                // Make sure this update applies to this host
                if (_detectedLpaVersionNumber != Settings.Default.TargetLpaVersionNumber)
                {
                    if (log.IsWarnEnabled) { log.Warn("This update does not apply to this system. Leaving system unchanged and exiting."); }

                    return 0; // going to assume version is correct or advanced and allow this utility to indicate success to SCCM.
                }

                // Stop services
                RemoteServicesHelper.StopService("localhost", Settings.Default.LifePortraitsServiceName);
                RemoteServicesHelper.StopService("localhost", Settings.Default.LifeManagerServiceName);

                log.Info("LPA services stopped...");

                // Execute SQL
                ExecuteQuery(Settings.Default.LpaConnectionString, SqlCommands.March2019AnnuityUpdate);

                log.Info("LPA database updated...");

                // Update version file
                using (var sw = new StreamWriter(_verisonFilePath, false))
                {
                    sw.Write(Settings.Default.NewLpaVersionNumber);
                }

                log.Info("LPA version file updated...");

                // Delete RSU folder data
                Delete(Path.Combine(_lpaInstallFolderPath, Settings.Default.RsuApplicationsFolderPath));
                Delete(Path.Combine(_lpaInstallFolderPath, Settings.Default.RsuDownloadFolderPath));
                Delete(Path.Combine(_lpaInstallFolderPath, Settings.Default.RsuRegistryFolderPath));

                log.Info("LPA RSU folders purged...");

                log.Info("Update complete. Restarting LPA services...");

                return 0;
            }
            catch(Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error("An error occurred while applying the LPA update.", ex); }

                log.Info("Update failed! Please see the log.");

                return -1;
            }
            finally
            {
                // Try to restart services, even if update failed otherwise.
                RemoteServicesHelper.StartService("localhost", Settings.Default.LifePortraitsServiceName);
                RemoteServicesHelper.StartService("localhost", Settings.Default.LifeManagerServiceName);

                log.Info("LPA services were restarted, if needed.");
            }


        }

        private static string ReadLpaVersionFile(string verisonFilePath)
        {
            try
            {
                if (File.Exists(verisonFilePath))
                {
                    using (var sr = new StreamReader(verisonFilePath))
                    {
                        return sr.ReadLine().Trim();
                    }
                }
                else
                {
                    throw new FileNotFoundException("LPA version file is missing.", verisonFilePath);
                }
                
            }
            catch(Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error($"Error reading file '{verisonFilePath}'.", ex); }

                throw new LpaUpdaterException($"Error reading the LPA version file location here: {verisonFilePath}", ex);
            }
        }

        internal static void CreateCommonFolder(string folderPath)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(folderPath))
                {
                    if (log.IsErrorEnabled) { log.Error("Folder path is null or empty."); }

                    throw new ArgumentException("Folder path provided is null or empty.", nameof(folderPath));
                }

                if (Directory.Exists(folderPath))
                {
                    if (log.IsInfoEnabled) { log.InfoFormat("Folder path '{0}' already exists. Contents and security will not be altered.", folderPath); }
                }

                // Using this instead of the "Everyone" string means we work on non-English systems.
                SecurityIdentifier everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);

                Directory.CreateDirectory(folderPath);

                DirectorySecurity sec = Directory.GetAccessControl(folderPath);
                sec.AddAccessRule(new FileSystemAccessRule(everyone, FileSystemRights.Modify | FileSystemRights.Synchronize, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));

                Directory.SetAccessControl(folderPath, sec);

                if (log.IsDebugEnabled) { log.DebugFormat("New folder '{0}' has been created.", folderPath); }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error(String.Format("An error occurred creating the folder '{0}'.", folderPath), ex); }

                throw new LpaUpdaterException($"Failed to create folder '{folderPath}'.", ex);
            }
        }

        private static string GetValueFromRegKey(string keyPath, string keyName)
        {
            try
            {
                if (log.IsDebugEnabled) { log.Debug($"Attempting to read key '{keyName}' at '{keyPath}'."); }

                using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(keyPath))
                {
                    var applicationPath = (string)registryKey.GetValue(keyName);

                    return applicationPath;
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error($"An error occurred while reading the registry. Path: {keyPath}, KeyName: {keyName}", ex); }

                throw new LpaUpdaterException("Error while reading the registry.", ex);
            }
        }

        private static void Delete(string folderPath)
        {
            try
            {
                var dirObj = new DirectoryInfo(folderPath);

                if (dirObj.Exists)
                {
                    dirObj.GetDirectories().ToList().ForEach(d => d.Delete(true));
                    dirObj.GetFiles().ToList().ForEach(f => f.Delete());
                }
                else
                {
                    if (log.IsWarnEnabled) log.Warn($"Folder '{folderPath}' does not exist. Skipping delete.");
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error($"Error deleting files and folders under '{folderPath}'.", ex);

                throw new LpaUpdaterException($"Error deleting RSU download folders. Path: '{folderPath}'.", ex);
            }
        }

        private static void ExecuteQuery(string connectionString, string sqlCommand)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlCommand, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                if(log.IsErrorEnabled) { log.Error("", ex); }

                throw new LpaUpdaterException("Error executing SQL command.", ex);
            }
        }
    }
}
