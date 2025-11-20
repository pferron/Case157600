using log4net;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using WOW.ISU.ImportBot.Properties;

namespace WOW.ISU.ImportBot
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        private static string _lpaInstallFolderPath;
        private static string _username;
        private static bool _importerProcessHasExited;
        private static string _importSuccessFileName;
        private static bool _silentMode;

        static void Main(string[] args)
        {
            try
            {
                // Activate log4net
                Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

                // Using helper class to configure log4net so I won't need a config file.
                LoggingHelper.ConfigureLogging();

                // Attempt to extract username from args
                _username = GetRunAsUsername(args);

                _silentMode = IsSilentModeRequested(args);

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
                    if (log.IsErrorEnabled) { log.Error("Username was not found. Exiting."); }

                    DisplayUserMessage("Username was not detected. Import failed!");

                    return;
                }

                // Set path for installation root
                _lpaInstallFolderPath = GetValueFromRegKey(Settings.Default.LifePortraitsRegKeyPath, Settings.Default.LifePortraitsRegKeyName);

                // Set filename for import marker file
                _importSuccessFileName = String.Format("ImportBot_{0}.txt", _username);

                // Check to see if the import has already been run successfully
                var importSuccessFilePath = Path.Combine(_lpaInstallFolderPath, _importSuccessFileName);

                if (log.IsDebugEnabled) { log.DebugFormat("ImportSuccessFilePath: {0}", importSuccessFilePath); }

                if (File.Exists(importSuccessFilePath))
                {
                    if (log.IsDebugEnabled) { log.DebugFormat("Previous successful import detected for user '{0}'. Exiting.", _username); }

                    DisplayUserMessage(String.Format("Data for user '{0}' has already been imported. If you need to re-run the import process, please contact the Help Desk.", _username));

                    return;
                }

                if (MigrateDataToLifePortraits())
                {
                    // Write file to LPLA folder to indicate that import was successful.
                    WriteTriggerFile();

                    DisplayUserMessage("Import Complete!");

                    return;
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error("General failure.", ex); }
            }

            DisplayUserMessage("Import failed! Please contact the Help Desk.");
        }

        /// <summary>
        /// Uses Windows Forms to display message to user, if silent mode is not active.
        /// </summary>
        /// <param name="msg">String message to display to user</param>
        private static void DisplayUserMessage(string msg)
        {
            if (!_silentMode)
            {
                MessageBox.Show(msg, "ImportBot Message");
            }
        }

        /// <summary>
        /// Checks for a silent switch on the command line
        /// </summary>
        /// <param name="args">String array of command line args</param>
        /// <returns>True, if switch found; false otherwise</returns>
        private static bool IsSilentModeRequested(string[] args)
        {
            try
            {
                if (args == null || args.Length == 0)
                {
                    return false;
                }

                foreach (var arg in args)
                {
                    if (arg.IndexOf("-silent", StringComparison.InvariantCultureIgnoreCase) > -1 ||
                        arg.IndexOf("/silent", StringComparison.InvariantCultureIgnoreCase) > -1)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error("An error occurred checking for silent command arg.", ex); }
            }

            return false;
        }

        /// <summary>
        /// This method writes a file that used to indicate that the import was successful.
        /// </summary>
        private static void WriteTriggerFile()
        {
            var filePath = Path.Combine(_lpaInstallFolderPath, _importSuccessFileName);

            try
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine("This files indicates that the user '{0}' has already imported IEW data and should not run the import tool again.", _username);
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error(String.Format("Error writing the importer trigger file '{0}'.", filePath), ex); }
            }
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
            }

            return null;
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

                if (!File.Exists(pathToImporter))
                {
                    if (log.IsErrorEnabled) { log.Error("Importer utility was not found."); }

                    return false;
                }

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
                            if (log.IsErrorEnabled) { log.ErrorFormat("Migration process may have failed. Exit code: {0}", proc.ExitCode); }
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
    }
}
