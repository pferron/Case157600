
using log4net;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Principal;
using System.ServiceProcess;
using System.Threading;
using System.Xml.Linq;
using WOW.ISU.DeltaBot.Properties;
using WOW.WoodmenIllustrationService.SharedModels;

namespace WOW.ISU.DeltaBot
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        // This variable is used for tracking error flags throughout the code.
        // status is returned at the end as the exit code.
        private static ProcessStatus _status = ProcessStatus.Success;
        private static string _lpaInstallFolderPath;
        private static bool _importRequested;
        private static string _username;
        private static bool _importerProcessHasExited;

        [Flags]
        enum ProcessStatus
        {
            Success = 0,
            GeneralApplicationFailure = 1,
            LifePortraitsVerificationFailure = 2,
            WebServerUnavailable = 4,
            DataMigrationFailure = 8,
            WoodmenIllustrationServiceVerificationFailure = 16,
            FileDeletionFailure = 32,
            ApplicationRemovalFailure = 64,
            PureEdgeVerificationFailure = 128,
            WiseServerVerificationFailure = 256,
            MainMenuConfigUpdateFailure = 512,
            ArgumentParsingFailure = 1024,
            FolderCreationFailure = 2048,
            SetStartupOptionFailure = 4096,
            UsernameDetectionFailure = 8192
        }

        static int Main(string[] args)
        {
            try
            {
                // Activate log4net
                Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
                //XmlConfigurator.Configure();
                // Using helper class to configure log4net so I won't need a config file.
                LoggingHelper.ConfigureLogging();

                SummonDeltaBot();

                // Attempt to extract username from args
                _username = GetRunAsUsername(args);

                if (log.IsDebugEnabled) { log.DebugFormat("Username from args: {0}", _username); }

                // If blank, extract field code from machine name
                if (String.IsNullOrWhiteSpace(_username))
                {
                    _username = ExtractUsername(Environment.MachineName);

                    if (log.IsDebugEnabled) { log.DebugFormat("Username from machine name: {0}", _username); }
                }

                // If still null or blank, set status code
                if (String.IsNullOrWhiteSpace(_username))
                {
                    if (log.IsErrorEnabled) { log.Error("Username was not found."); }

                    _status |= ProcessStatus.UsernameDetectionFailure;
                }

                // Set path for installation root
                _lpaInstallFolderPath = GetValueFromRegKey(Settings.Default.LifePortraitsRegKeyPath, Settings.Default.LifePortraitsRegKeyName);

                if (log.IsDebugEnabled) { log.DebugFormat("LifePortraits Desktop installation location: {0}.", _lpaInstallFolderPath); }

                _importRequested = HasImportBeenRequested(args);

                // LPA needs to be installed for importing to work
                if (VerifyLifePortraitsDesktop())
                {
                    if (_importRequested)
                    {
                        // IEW32 data needs to be imported into LPA
                        // The import will link the local account to the server so internet access is required.
                        if (CanConnectToWebServer(Settings.Default.ConnectivityCheckUrl))
                        {
                            if (!MigrateDataToLifePortraits())
                            {
                                _status |= ProcessStatus.DataMigrationFailure;
                            }
                        }
                        else
                        {
                            _status |= ProcessStatus.WebServerUnavailable;
                        }
                    }
                    else
                    {
                        if (log.IsDebugEnabled) { log.Debug("IEW to LPA import skipped. Use cmd arg '-import' to execute import process."); }
                    }
                }
                else
                {
                    _status |= ProcessStatus.LifePortraitsVerificationFailure;
                }

                // Verification
                // Is the WIS service running?
                if (IsLocalServiceRunning(Settings.Default.WoodmenIllustrationServiceName))
                {
                    // Can you connect to the Heartbeat and/or DatabaseCheck end points of the WIS?
                    // The database check really should be done because it verifies that LocalDB is setup and running.
                    // Use http://localhost:2015/api/Service/DatabaseCheck to check the API and the database

                    var result = VerifyWoodmenIllustrationService(Settings.Default.ServiceCheckUrl);

                    if (result.HasError)
                    {
                        if (log.IsErrorEnabled) { log.ErrorFormat("The Woodmen Illustration Service returned an error. Result: {0}", result.Result); }

                        _status |= ProcessStatus.WoodmenIllustrationServiceVerificationFailure;
                    }
                }
                else
                {
                    if (log.IsErrorEnabled) { log.ErrorFormat("The Woodmen Illustration Service is down."); }

                    _status |= ProcessStatus.WoodmenIllustrationServiceVerificationFailure;
                }

                // Disable IEW32
                // Delete desktop shortcut, at a minimum
                if (!RemoveFiles(Settings.Default.FilesToRemove.Split(',')))
                {
                    _status |= ProcessStatus.FileDeletionFailure;
                }

                // 5 raters will need to be removed
                // Remove Solution System and other raters
                if (!RemoveApplications(Settings.Default.AppsToUninstall.Split(',')))
                {
                    _status |= ProcessStatus.ApplicationRemovalFailure;
                }

                // Verify WISE Server update
                if (!VerifyWiseServerUpdate(Settings.Default.WiseServerExePath, Settings.Default.WiseServerExeFileVersion))
                {
                    _status |= ProcessStatus.WiseServerVerificationFailure;
                }

                // Verify e-App update
                if (!VerifyPureEdgeUpdate(Settings.Default.PureEdgeIfxPath, Settings.Default.PureEdgeIfxHash))
                {
                    _status |= ProcessStatus.PureEdgeVerificationFailure;
                }

                // Update WoodmenLife Main Menu config file
                if (!UpdateMainMenuConfig(Settings.Default.MainMenuConfigPath))
                {
                    _status |= ProcessStatus.MainMenuConfigUpdateFailure;
                }

                // Create a specific folder for storing saved PDF illustrations
                if (!CreateCommonFolder(Settings.Default.IllustrationSavePath))
                {
                    _status |= ProcessStatus.FolderCreationFailure;
                }

                // Create shortcut to start sync manager at login
                // The installer is suppose to take care of this.
                // Commenting out for now.
                //if (!CreateStartupLink(Settings.Default.SyncAgentShortcutPath))
                //{
                //    _status |= ProcessStatus.SetStartupOptionFailure;
                //}
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error("General failure.", ex); }

                _status |= ProcessStatus.GeneralApplicationFailure;
            }

            var returnCode = (int)_status;

            if (log.IsInfoEnabled) { log.InfoFormat("ReturnCode: {0}", returnCode); }

            return returnCode;
        }

        /// <summary>
        /// Copies referenced .lnk file to the user's startup folder.
        /// </summary>
        /// <param name="lnkPath">Path to .lnk file.</param>
        /// <returns>True, if file is found and copied successfully; otherwise, false.</returns>
        private static bool CreateStartupLink(string lnkPath)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(lnkPath))
                {
                    if (log.IsErrorEnabled) { log.Error("Path to shortcut file is null or empty."); }

                    return false;
                }

                if (!File.Exists(lnkPath))
                {
                    if (log.IsErrorEnabled) { log.ErrorFormat("Shortcut file '{0}' does not exist.", lnkPath); }

                    return false;
                }

                if (String.IsNullOrWhiteSpace(_username))
                {
                    if (log.IsErrorEnabled) { log.Error("Username variable is null or empty."); }

                    return false;
                }

                var lnkFile = new FileInfo(lnkPath);

                var pathToStartupFolder = @"C:\Users\" + _username + @"\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup";

                var targetFile = Path.Combine(pathToStartupFolder, lnkFile.Name);

                if (Directory.Exists(pathToStartupFolder))
                {
                    File.Copy(lnkFile.FullName, targetFile, true);

                    if (log.IsDebugEnabled) { log.DebugFormat("Shortcut file '{0}' copied to '{1}'.", lnkFile.FullName, targetFile); }
                }
                else
                {
                    if (log.IsErrorEnabled) { log.ErrorFormat("Startup Folder '{0}' does not exist.", pathToStartupFolder); }

                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error("An error occurred while creating a startup shortcut.", ex); }

                return false;
            }
        }

        /// <summary>
        /// "Draws" DeltaBot in the console. This is a super-important and necessary method.
        /// </summary>
        private static void SummonDeltaBot()
        {
            Console.WriteLine("DeltaBot! GO!" + Environment.NewLine);

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine("░░░░░░░░▄▄█▀▀▄░░░░░░░");
            Console.WriteLine("░░░░░░▄█████▄▄█▄░░░░░");
            Console.WriteLine("░░░░░▄▀██████▄▄██░░░░");
            Console.WriteLine("░░░░░█░█▀░░▄▄▀█░█░░░░");
            Console.WriteLine("░░░░░▄██░░░▀▀░▀░█░░░░");
            Console.WriteLine("░░▄█▀░░▀█░▀▀▀▀▄▀▀█▄░░");
            Console.WriteLine("░▄███░▄░░▀▀▀▀▀▄░███▄░");
            Console.WriteLine("░██████░░░░░░░██████░");
            Console.WriteLine("░▀███▀█████████▀███▀░");
            Console.WriteLine("░░░░▄█▄░▀▀█▀░░░█▄░░░░");
            Console.WriteLine("░▄▄█████▄▀░▀▄█████▄▄░");
            Console.WriteLine("█████████░░░█████████");

            Console.ResetColor();

            Console.WriteLine("");
        }

        /// <summary>
        /// Creates a folder path based on the passed in string. Sets access so that all accounts and read/write to it.
        /// </summary>
        /// <param name="folderPath">String representing the folder path to create.</param>
        /// <returns>True, if successful; false if it fails.</returns>
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

        /// <summary>
        /// Parses the provided string array for an import switch.
        /// </summary>
        /// <param name="args">Expected to be the args passed into the main program.</param>
        /// <returns>True, if switch found; otherwise, false.</returns>
        private static bool HasImportBeenRequested(string[] args)
        {
            try
            {
                if (args == null || args.Length == 0)
                {
                    return false;
                }

                return args.Where(a => a.IndexOf("-import", StringComparison.InvariantCultureIgnoreCase) > -1 ||
                                       a.IndexOf("/import", StringComparison.InvariantCultureIgnoreCase) > -1).Any();
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error("An error occurred checking for import command arg.", ex); }

                _status |= ProcessStatus.ArgumentParsingFailure;

                return false;
            }
        }

        /// <summary>
        /// Parses the username from the command line args
        /// </summary>
        /// <param name="args">Command line args string array</param>
        /// <returns>Username, if found; otherwise, null</returns>
        private static string GetRunAsUsername(string[] args)
        {
            try
            {
                if (args == null || args.Length == 0)
                {
                    return null;
                }

                foreach (var arg in args)
                {
                    if (arg.IndexOf("-username=", StringComparison.InvariantCultureIgnoreCase) > -1 ||
                        arg.IndexOf("/username=", StringComparison.InvariantCultureIgnoreCase) > -1)
                    {
                        var parts = arg.Split('=');

                        return parts[1];
                    }
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error("An error occurred checking for username command arg.", ex); }

                _status |= ProcessStatus.ArgumentParsingFailure;
            }

            return null;
        }

        /// <summary>
        /// Edits the Main Menu config file to hide two buttons and update the path of another button.
        /// </summary>
        /// <param name="configFilePath">File system path to the config file.</param>
        /// <returns>True, if successful; otherwise, false.</returns>
        private static bool UpdateMainMenuConfig(string configFilePath)
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

                XElement config = XElement.Load(configFilePath);

                // Get references to the two XML nodes that need to be updated.
                var helpSettings = from xel in config.Element("applicationSettings").Element("WoodmenLifeMenu.My.MySettings").Elements()
                                   where (string)xel.Attribute("name") == "Button3Help" || (string)xel.Attribute("name") == "Button9Help"
                                   select xel;

                // Get references to the two XML nodes that need to be updated.
                var linkSettings = from xel in config.Element("applicationSettings").Element("WoodmenLifeMenu.My.MySettings").Elements()
                                   where (string)xel.Attribute("name") == "Button7AppPath"
                                   select xel;

                // Setting the Help nodes to an empty string will cause them to be hidden by the menu.
                foreach (var setting in helpSettings)
                {
                    setting.Element("value").Value = String.Empty;
                }

                // Updating the path for the Illustration button so it points to LPA Desktop
                foreach (var setting in linkSettings)
                {
                    setting.Element("value").Value = Path.Combine(_lpaInstallFolderPath, Settings.Default.LifePortraitsLauncherPath);
                }

                config.Save(configFilePath);

                if (log.IsDebugEnabled) { log.Debug("Main Menu XML file updated."); }

                return true;
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error(String.Format("An error occurred updating '{0}'.", configFilePath), ex); }

                return false;
            }
        }

        /// <summary>
        /// Queries the provided Woodmen Illustration Service end point.
        /// </summary>
        /// <param name="targetUrl">The full URL for the Web API method to check.</param>
        /// <returns>A ServiceStatus object that can indicate if the service is up or not.</returns>
        private static ServiceStatus VerifyWoodmenIllustrationService(string targetUrl)
        {
            if (log.IsDebugEnabled) { log.DebugFormat("Starting verification of Woodmen Illustration Service.", targetUrl); }

            try
            {
                if (String.IsNullOrWhiteSpace(targetUrl))
                {
                    return new ServiceStatus() { Result = "Target URL is null or blank.", HasError = true };
                }

                var response = FetchWebResponse(targetUrl);

                var model = JsonConvert.DeserializeObject<ServiceStatus>(response);

                return model;
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error(String.Format("An error occurred while verifying the Woodmen Illustration Service using URL '{0}'.", targetUrl), ex); }

                return new ServiceStatus() { Result = "Local exception occurred. Please check log.", HasError = true };
            }
        }

        /// <summary>
        /// Checks if local Windows service is currently running.
        /// </summary>
        /// <param name="serviceName">Name of service to check.</param>
        /// <returns>True, if service is running; False, if service is in another state or not found.</returns>
        private static bool IsLocalServiceRunning(string serviceName)
        {
            if (log.IsDebugEnabled) { log.DebugFormat("Checking local service '{0}'.", serviceName); }

            try
            {
                if (String.IsNullOrWhiteSpace(serviceName))
                {
                    if (log.IsErrorEnabled) { log.Error("Service name argument is null or empty."); }

                    return false;
                }

                // Note: if the service name doesn't match any service on the local machine,
                // an InvalidOperationException is thrown when the Status property is checked.
                // The exact reason for the failure appears to be well-communicated in the exception.
                ServiceController sc = new ServiceController(serviceName);

                if (sc.Status == ServiceControllerStatus.Running)
                {
                    if (log.IsDebugEnabled) { log.DebugFormat("Service '{0}' is running.", serviceName); }

                    return true;
                }

                if (log.IsDebugEnabled) { log.DebugFormat("Service '{0}' is NOT running.", serviceName); }

                return false;
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error(String.Format("There was an error checking service '{0}'.", serviceName), ex); }

                return false;
            }
        }

        /// <summary>
        /// Calculates an MD5 hash for the file provided and compares it against the expected hash provided.
        /// </summary>
        /// <returns>True, if hashes match; otherwise, false.</returns>
        private static bool VerifyPureEdgeUpdate(string filePath, string expectedHash)
        {
            // Typically, the file is located here:
            //C:\Program Files\PureEdge\Viewer 6.4\extensions\WoodmenIllustrationIFX.jar
            try
            {
                if (String.IsNullOrWhiteSpace(filePath))
                {
                    if (log.IsErrorEnabled) { log.Error("filePath argument is null or empty."); }

                    return false;
                }

                if (String.IsNullOrWhiteSpace(expectedHash))
                {
                    if (log.IsErrorEnabled) { log.Error("expectedHash argument is null or empty."); }

                    return false;
                }

                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(filePath))
                    {
                        var hash = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "");

                        if (String.Equals(expectedHash, hash, StringComparison.OrdinalIgnoreCase))
                        {
                            if (log.IsDebugEnabled) { log.Debug("PureEdge JAR update verified."); }

                            return true;
                        }
                        else
                        {
                            if (log.IsErrorEnabled) { log.ErrorFormat("PureEdge JAR does not have the expected hash. Expected: {0} :: Calculated: {1}", expectedHash, hash); }

                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error("There was an error calculating the PureEdge IFX JAR file hash.", ex); }

                return false;
            }
        }

        /// <summary>
        /// Checks the version of the file passed in and compares it to an expected value.
        /// </summary>
        /// <param name="filePath">Path to file to check.</param>
        /// <param name="expectedVersion">Version number expected as a string.</param>
        /// <returns>True, if version numbers match; otherwise, false.</returns>
        private static bool VerifyWiseServerUpdate(string filePath, string expectedVersion)
        {
            try
            {
                var fileInfo = FileVersionInfo.GetVersionInfo(filePath);

                if (expectedVersion == fileInfo.FileVersion)
                {
                    if (log.IsDebugEnabled) { log.Debug("WiseServer update verified."); }

                    return true;
                }
                else
                {
                    if (log.IsErrorEnabled) { log.ErrorFormat("WiseServer is not at the expected version. Expected: {0} :: Found: {1}", expectedVersion, fileInfo.FileVersion); }

                    return false;
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error("There was an error checking the Wise Server EXE file version.", ex); }

                return false;
            }
        }

        /// <summary>
        /// Requests the uninstallation of one or more applications.
        /// </summary>
        /// <param name="appNames">Array of application names</param>
        /// <returns>True, if successful; false, if one or more removals fail</returns>
        private static bool RemoveApplications(string[] appNames)
        {
            bool flag = true;

            try
            {
                foreach (var appName in appNames)
                {
                    if (UninstallApplicationByName(appName))
                    {
                        if (log.IsDebugEnabled) { log.DebugFormat("Application '{0}' was successfully removed.", appName); }
                    }
                    else
                    {
                        if (log.IsErrorEnabled) { log.ErrorFormat("There was an error removing '{0}'.", appName); }

                        flag = false;
                    }
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error("There was an error uninstalling applications.", ex); }

                flag = false;
            }

            return flag;
        }

        /// <summary>
        /// Requests the deletion of one or more files.
        /// </summary>
        /// <param name="filePaths">Array of filenames (full paths recommended)</param>
        /// <returns>True, if successful; false, if one or more files are missing or cannot be deleted</returns>
        private static bool RemoveFiles(string[] filePaths)
        {
            bool flag = true;

            try
            {
                foreach (var file in filePaths)
                {
                    try
                    {
                        if (File.Exists(file))
                        {
                            File.Delete(file);

                            if (log.IsDebugEnabled) { log.DebugFormat("File '{0}' deleted.", file); }
                        }
                        else
                        {
                            if (log.IsDebugEnabled) { log.DebugFormat("File '{0}' was not found.", file); }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (log.IsErrorEnabled) { log.Error(String.Format("Error deleting file '{0}'.", file), ex); }

                        flag = false;
                    }
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error("Error deleting files from system.", ex); }

                flag = false;
            }

            return flag;
        }

        /// <summary>
        /// Executes the StoneRiver data migration utility in a separate process.
        /// </summary>
        /// <returns>True, if process exits with a zero; false, if any exception occurs or a non-zero exit code is returned</returns>
        private static bool MigrateDataToLifePortraits()
        {
            if (log.IsDebugEnabled) { log.Debug("Starting IEW32 data migration to LifePortraits."); }

            try
            {
                if (String.IsNullOrWhiteSpace(_lpaInstallFolderPath))
                {
                    if (log.IsErrorEnabled) { log.Error("LPA installation folder path is not set."); }

                    return false;
                }

                if (String.IsNullOrWhiteSpace(_username))
                {
                    if (log.IsErrorEnabled) { log.Error("Username variable is not set."); }

                    return false;
                }

                var pathToImporter = Path.Combine(_lpaInstallFolderPath, Settings.Default.MigrationUtilityRelativePath);

                ProcessStartInfo importerStartInfo = new ProcessStartInfo();
                importerStartInfo.FileName = pathToImporter;
                importerStartInfo.Arguments = String.Format("/username={0}", _username);
                importerStartInfo.CreateNoWindow = true;
                importerStartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                using (var proc = Process.Start(importerStartInfo))
                {
                    if (log.IsDebugEnabled) { log.DebugFormat("Migration process started. Waiting {0} milliseconds for process to complete.", Settings.Default.MigrationUtilityTimeOut); }

                    proc.EnableRaisingEvents = true;
                    proc.Exited += new EventHandler(ImporterProcess_Exited);

                    //proc.WaitForExit(Settings.Default.MigrationUtilityTimeOut);

                    int elapsedTime = 0;
                    const int SLEEP_AMOUNT = 10000;

                    while (!_importerProcessHasExited)
                    {
                        if (elapsedTime > Settings.Default.MigrationUtilityTimeOut)
                        {
                            break;
                        }

                        Thread.Sleep(SLEEP_AMOUNT);

                        elapsedTime += SLEEP_AMOUNT;
                    }

                    proc.Refresh();

                    if (proc.HasExited)
                    {
                        if (proc.ExitCode == 0)
                        {
                            if (log.IsDebugEnabled) { log.DebugFormat("Migration process has completed successfully. Exit code: {0}", proc.ExitCode); }

                            return true;
                        }
                        else
                        {
                            if (log.IsErrorEnabled) { log.ErrorFormat("Migration process has failed. Exit code: {0}", proc.ExitCode); }
                        }
                    }
                    else
                    {
                        if (log.IsErrorEnabled) { log.Error("The IEW data migration process has timed out. Attempting to kill process."); }

                        proc.Kill();
                    }
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error("Error migrating data to LifePortraits.", ex); }
            }

            return false;
        }

        /// <summary>
        /// Method used to notify the main thread that the importer process has exited.
        /// </summary>
        private static void ImporterProcess_Exited(object sender, EventArgs e)
        {
            _importerProcessHasExited = true;

            if (log.IsDebugEnabled) { log.Debug("Importer process has exited."); }
        }

        /// <summary>
        /// Reads the registry for the LifePortraits installation path and then checks for the presence of files listed in the app.config.
        /// </summary>
        /// <returns>True, if successful; false, if files are missing or registry cannot be read.</returns>
        private static bool VerifyLifePortraitsDesktop()
        {
            if (log.IsDebugEnabled) { log.Debug("Verifying LifePortraits Desktop installation."); }

            try
            {
                bool flag = true;

                if (String.IsNullOrWhiteSpace(_lpaInstallFolderPath))
                {
                    return false;
                }

                var exePaths = new List<string>(Settings.Default.LifePortraitsExePaths.Split(','));

                if (log.IsDebugEnabled) { log.Debug("Verifying key LifePortraits Desktop files."); }

                foreach (var exePath in exePaths)
                {
                    var fullExePath = Path.Combine(_lpaInstallFolderPath, exePath);

                    if (File.Exists(fullExePath))
                    {
                        if (log.IsDebugEnabled) { log.DebugFormat("Found file '{0}'.", fullExePath); }
                    }
                    else
                    {
                        if (log.IsErrorEnabled) { log.ErrorFormat("File '{0}' is missing.", fullExePath); }
                        flag = false;
                    }
                }

                return flag;
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error("Error validating LifePortraits desktop installation.", ex); }

                return false;
            }
        }

        /// <summary>
        /// Makes a WMI request to uninstall an application. WARNING! This method can be very slow. If more than app is found with the same name, they will both be removed.
        /// </summary>
        /// <param name="programName">The application's program name. (Win32_Product.Name)</param>
        /// <returns>True, if uninstall was successful. False, if it failed.</returns>
        private static bool UninstallApplicationByName(string programName)
        {
            try
            {
                bool success = true;

                if (log.IsDebugEnabled) { log.DebugFormat("Attempting to remove application '{0}'.", programName); }

                // WMI query for installed products by name
                var mos = new ManagementObjectSearcher(String.Format("SELECT * FROM Win32_Product WHERE Name = '{0}'", programName));

                // Execute query to get collection
                var installedApps = mos.Get();

                // If collection length is zero, return false.
                if (installedApps.Count == 0)
                {
                    if (log.IsErrorEnabled) { log.ErrorFormat("Application '{0}' was not found on system.", programName); }

                    return false;
                }

                // Should only find one, usually
                foreach (ManagementObject mo in installedApps)
                {
                    uint result = (uint)mo.InvokeMethod("Uninstall", null);

                    if (result != 0)
                    {
                        success = false;
                    }
                }

                return success;
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error(String.Format("There was an error uninstalling '{0}'.", programName), ex); }

                return false;
            }
        }

        /// <summary>
        /// Sends ping request to the IP or hostname passed in.
        /// </summary>
        /// <param name="hostname">IP or hostname to ping.</param>
        /// <returns>True, if ping was successful. False, if the ping failed or there was an error pinging.</returns>
        private static bool CanPingHost(string hostname)
        {
            try
            {
                if (log.IsDebugEnabled) { log.DebugFormat("Attempting to PING host '{0}'.", hostname); }

                var pingResult = new Ping().Send(hostname).Status;

                return pingResult == IPStatus.Success;
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error(String.Format("There was an error pinging host '{0}'.", hostname), ex); }

                return false;
            }
        }

        /// <summary>
        /// Check to see if a web server is available and responding.
        /// </summary>
        /// <param name="httpAddress">URL to request.</param>
        /// <returns>True, if response is received; False, if exception is thrown trying to request response.</returns>
        private static bool CanConnectToWebServer(string httpAddress)
        {
            if (log.IsDebugEnabled) { log.DebugFormat("Checking connectivity to web server using '{0}' URL.", httpAddress); }

            try
            {
                if (String.IsNullOrWhiteSpace(httpAddress))
                {
                    if (log.IsErrorEnabled) { log.Error("HTTP address is null or empty."); }

                    return false;
                }

                var response = FetchWebResponse(httpAddress);

                return true;
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error("An error occurred while trying to check web server connectivity.", ex); }

                return false;
            }
        }

        /// <summary>
        /// Request response from web service as string.
        /// </summary>
        /// <param name="httpAddress">URL to request.</param>
        /// <returns>String representation of the content received.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
        private static string FetchWebResponse(string httpAddress)
        {
            if (String.IsNullOrEmpty(httpAddress))
            {
                if (log.IsErrorEnabled) { log.Error("HTTP address is null or empty."); }

                throw new ArgumentNullException("httpAddress", "A HTTP address to connect to is required.");
            }

            try
            {
                using (var client = new WebClient())
                {
                    client.Proxy = null;

                    // With this code, you get a warning about the stream getting disposed twice.
                    // This is safe to ignore and suppress per Jon Skeet himself.
                    using (var stream = client.OpenRead(httpAddress))
                    using (var sr = new StreamReader(stream))
                    {
                        string content = sr.ReadToEnd();

                        return content;
                    }
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error(String.Format("An error occurred while fetching a web response from '{0}'.", httpAddress), ex); }

                throw;
            }
        }

        /// <summary>
        /// Queries the registry for the install path for LifePortraits Desktop.
        /// </summary>
        /// <returns>The path to the installation root folder of LifePortraits Desktop.</returns>
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

        /// <summary>
        /// Attempts to parse a field rep code from the passed in string. Returns null if parsing fails.
        /// </summary>
        /// <param name="input">The machine name of the sales laptop. Ex. CF53GG_510041A</param>
        /// <returns>The field code from the machine name or null</returns>
        private static string ExtractUsername(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            try
            {
                // Example: CF53GG_510041A
                var parts = input.Split('_');

                if (parts.Length == 2 && parts[1].Length >= 6)
                {
                    var fieldUsername = parts[1].Substring(0, 6);

                    if (fieldUsername.All(char.IsDigit))
                    {
                        return fieldUsername;
                    }
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error(String.Format("An error occurred while extracting the value from the string. Input: {0}", input), ex); }
            }

            return null;
        }

        #region WMI_Product_Record
        // Here for informational purposes
        //uint16 AssignmentType;
        //string Caption;
        //string Description;
        //string IdentifyingNumber;
        //string InstallDate;
        //datetime InstallDate2;
        //string InstallLocation;
        //sint16 InstallState;
        //string HelpLink;
        //string HelpTelephone;
        //string InstallSource;
        //string Language;
        //string LocalPackage;
        //string Name;
        //string PackageCache;
        //string PackageCode;
        //string PackageName;
        //string ProductID;
        //string RegOwner;
        //string RegCompany;
        //string SKUNumber;
        //string Transforms;
        //string URLInfoAbout;
        //string URLUpdateInfo;
        //string Vendor;
        //uint32 WordCount;
        //string Version;

        #endregion
    }
}
