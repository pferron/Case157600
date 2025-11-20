using LPA.Dashboard.Models.Deployment;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml.Serialization;
using File = LPA.Dashboard.Models.Deployment.File;

namespace LPA.Dashboard.Web
{
    /// <summary>
    /// The processor.
    /// </summary>
    public class Processor
    {
        #region Private Members
        /// <summary>
        /// The base folder path that the mainManifest is in
        /// </summary>
        private readonly string _basePath;

        /// <summary>
        /// The highest version in the folder list
        /// </summary>
        private string _oldVersion;

        /// <summary>
        /// The update highest version in the folder list, so for example if _oldVersion is 1.2.3.4, this will be
        /// 1.3.3.4. Essentially this updates the minor version number by one.
        /// </summary>
        private string _newVersion;

        /// <summary>
        /// The uploaded EXE or SQL file
        /// </summary>
        private readonly HttpPostedFileBase[] _file;

        /// <summary>
        /// The description to add in the updateManifest
        /// </summary>
        private readonly string _description;

        /// <summary>
        /// The manifest id that is saved in the updateManifest and mainManifest
        /// </summary>
        private Guid _manifestId;

        /// <summary>
        /// The actual physical path to the <see cref="_file"/>
        /// </summary>
        private readonly string _pathToFile;

        /// <summary>
        /// The name of the working folder, this folder is created when the tool is working and removed
        /// once the publish is complete.
        /// </summary>
        private readonly string _workingFolderName = "Working";

        /// <summary>
        /// The name of the working folder, this folder is created when the tool is working and removed
        /// once the publish is complete.
        /// </summary>
        private readonly string _historyFolderName = "history";

        /// <summary>
        /// The url that is used in the manifest
        /// </summary>
        private readonly string _url;

        /// <summary>
        /// The path that the files will be output to, unfortunately i can not update the files myself so instead the files will be created in this
        /// directory and then manually copied over. Because of security concerns.
        /// </summary>
        private readonly string _promotePath;

        /// <summary>
        /// The local base path of the where the Remote System Update (RSU) is created, for example in the test region that
        /// could be \\promote\deployment\Windows\lpa\test\RSU
        /// </summary>
        private string _localPath;

        /// <summary>
        /// A list of the files that were uploaded.
        /// </summary>
        private List<string> _uploadedFiles;

        /// <summary>
        /// The connection string that is used to connect to the database
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// The deployment date selected by the user
        /// </summary>
        private readonly string _deploymentDate;

        #endregion

        /// <summary>
        /// The local base path of the where the Remote System Update (RSU) is created, for example in the test region that
        /// could be \\promote\deployment\Windows\lpa\test\RSU
        /// </summary>
        public string LocalPath { get { return _localPath; } }

        /// <summary>
        /// The log that happens, used to email to team / admins
        /// </summary>
        public List<string> Log { get; }

        /// <summary>
        /// The constructor for processing a folder that already exists.
        /// </summary>
        /// <param name="basePath">The base folder path that the resource update file is in</param>
        /// <param name="pathToFile">The physical path to previous update folder</param>
        /// <param name="manifestId">The manifest GUID, needed in case multiple deployment locations</param>
        /// <param name="url">The url of the remote server, for example lpa-test.woodmen.net</param>
        /// <param name="promotePath">The path to the \\promote folder for the given region</param>
        /// <param name="connectionString">The connection string that is used to connect to the database</param>
        /// <param name="description">The description, not needed</param>
        /// <param name="deploymentDate">The deployment date selected by the user</param>
        public Processor(string basePath, string pathToFile, Guid manifestId, string url, string promotePath,
                         string connectionString, string description, string deploymentDate, string version) : this(basePath, description, manifestId, url, promotePath, connectionString, deploymentDate, version)
        {
            Log = new List<string>();
            _pathToFile = pathToFile;
            _newVersion = version;
        }

        /// <summary>
        /// The constructor for processing a file that needs to be saved to the physical basePath
        /// </summary>
        /// <param name="basePath">The base folder that the manifest is in</param>
        /// <param name="file">The file</param>
        /// <param name="description">The description</param>
        /// <param name="manifestId">The manifest GUID, needed in case multiple deployment locations</param>
        /// <param name="url">The url of the remote server, for example lpa-test.woodmen.net</param>
        /// <param name="promotePath">The path to the \\promote folder for the given region</param>
        /// <param name="connectionString">The connection string that is used to connect to the database</param>
        public Processor(string basePath, HttpPostedFileBase[] file, string description, Guid manifestId, string url,
                         string promotePath, string connectionString, string deploymentDate, string version) : this(basePath, description, manifestId, url, promotePath, connectionString, deploymentDate, version)
        {
            Log = new List<string>();
            _file = file ?? throw new ArgumentNullException(nameof(file));
            _newVersion = version;

            Log.Add($"Created processor with basePath: {basePath}, description: {description}, " +
                $"manifestId: {manifestId} url: {url}, promotePath: {promotePath}, and connectionString:" +
                $"{connectionString}, deploymentDate: {deploymentDate}");
        }

        /// <summary>
        /// Private Constructor
        /// </summary>
        /// <param name="basePath">The base folder path that the resource update file is in</param>
        /// <param name="description">The description of the </param>
        /// <param name="manifestId">The manifest GUID, needed in case multiple deployment locations</param>
        /// <param name="url">The url of the remote server, for example lpa-test.woodmen.net</param>
        private Processor(string basePath, string description, Guid manifestId, string url, string promotePath, string connectionString, string deploymentDate, string version)
        {
            _basePath = basePath ?? throw new ArgumentNullException(nameof(basePath));
            _description = description ?? throw new ArgumentNullException(nameof(description));
            _manifestId = manifestId;
            _url = url ?? throw new ArgumentNullException(nameof(url));
            _promotePath = promotePath ?? throw new ArgumentNullException(nameof(promotePath));
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            _uploadedFiles = new List<string>();
            _deploymentDate = deploymentDate;
            _newVersion = version;
        }

        /// <summary>
        /// The method that process the file
        /// </summary>
        /// <returns>The version of the file.</returns>
        public string Process()
        {
            try
            {
                Log.Add("Starting to process.");

                PreparePromoteFolder();
                CreateUpdateFolder();
                CreateUpdateManifest();
                ModifyMainManifest();
                CreateVersionFile();
                CreateReconScript();
                //TODO: Version 2
                //ExecuteSql();

                Log.Add("Finished processing.");
                return _newVersion;
            }
            catch (Exception ex)
            {
                Log.Add($"Exception in process: {ex}");
                Log.Add($"Stack Trace: {ex.StackTrace}");
                Log.Add($"Inner Exception: {ex.StackTrace}");
                //Rollback();
                throw;
            }
        }

        /// <summary>
        /// Process a deployment that has already been created
        /// </summary>
        /// <returns>a string</returns>
        public string ProcessAlreadyDeployed()
        {
            try
            {
                Log.Add("Starting to process a deployment that already exists.");

                //get the promote folder ready
                PreparePromoteFolder();
                CreateUpdateFolder();
                CreateUpdateManifest();
                ModifyMainManifest();
                CreateVersionFile();
                CreateReconScript();
                //TODO: Version 2
                //ExecuteSql();

                return _newVersion;
            }
            catch (Exception ex)
            {
                Log.Add($"Exception in process: {ex}");
                Log.Add($"Stack Trace: {ex.StackTrace}");
                Log.Add($"Inner Exception: {ex.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// Once the files already have been created using <see cref="Process"/> then we can
        /// copy the files over to any destination that is required...
        /// </summary>
        /// <param name="serverPath">The destination path of local files</param>
        public void CopyFilesToLocalServer(string serverPath)
        {
            Log.Add($"Copying Files from {serverPath}");
            var source = new DirectoryInfo(_localPath);

            //get today's date
            //var date = DateTime.Now.ToString("yyyy-MM-dd");

            //create a new folder with the deployment date
            var targetServerPath = Path.Combine(serverPath, _deploymentDate);

            Log.Add($"Target server path: {targetServerPath}");
            Directory.CreateDirectory(targetServerPath);

            //set the target for the migrate
            var target = new DirectoryInfo(targetServerPath);

            //copy all of the files over from the local path to the server path
            MigrateFiles(source, target);
        }

        /// <summary>
        /// Copy the files that were created in the promote folder to the RSU folder on the server.
        /// </summary>
        /// <param name="path"></param>
        public void CopyFilesToRemoteSystemUpdatePath(string path)
        {
            Log.Add($"Copy Files To Remote System Update Path. Path: {path}");

            //get from the local directory just the files inside of the RSU version
            var source = new DirectoryInfo(Path.Combine(_localPath, _newVersion));

            //create the version folder
            Directory.CreateDirectory(Path.Combine(path, _newVersion));

            //set the target to the server path's version
            var target = new DirectoryInfo(Path.Combine(path, _newVersion));

            //copy all of the files over from the local path to the server path
            MigrateFiles(source, target);

            //replace the mainManifest.
            System.IO.File.Copy(Path.Combine(_localPath, "mainManifest.xml"), Path.Combine(path, "mainManifest.xml"), true);
        }

        /// <summary>
        /// Update the version file that is on the server with the one that we created
        /// inside of the <see cref="_localPath"/>
        /// </summary>
        /// <param name="serverPath">The path to the version file on the server</param>
        public void UpdateVersionFile(string serverPath)
        {
            Log.Add($"Updating version file at: {serverPath}");

            //get the path for the new version file before we write it.
            var verPath = Path.Combine(_localPath, "system.ver");

            System.IO.File.Copy(verPath, serverPath, true);
        }

        /// <summary>
        /// Use the <see cref="_promotePath"/> to prepare the promote folder
        /// </summary>
        private void PreparePromoteFolder()
        {
            Log.Add("Preparing Promote Folder");

            //get the RSU path
            var promoteRsuPath = Path.Combine(_promotePath, "RSU");

            Log.Add($"Promote RSU Path: {promoteRsuPath}");

            //check if the directory exists
            if (!Directory.Exists(promoteRsuPath))
                Directory.CreateDirectory(promoteRsuPath);

            Log.Add($"{promoteRsuPath} already exists or successfully executed.");

            //get the info about the promote path and the RSU path            
            var promoteRsuContents = new DirectoryInfo(promoteRsuPath);
            var promoteRsuArchive = new DirectoryInfo(Path.Combine(_promotePath, "archive", "RSU"));
                        
            //move all of the files that are in the RSU folder to the RSU archive
            MigrateFiles(promoteRsuContents, promoteRsuArchive);

            //clear out RSU folder
            EmptyDirectory(promoteRsuContents.FullName);

            //set a path with today's date in the RSU path 
            //var date = DateTime.Now.ToString("yyyy-MM-dd");
            _localPath = Path.Combine(promoteRsuPath, _deploymentDate);

            //create the local path that is used to store all RSU related things for today's date
            Directory.CreateDirectory(_localPath);

            Log.Add($"Successfully created {_localPath}");
        }


        /// <summary>
        /// Empty a directory, but leave the base folder
        /// </summary>
        /// <param name="DirectoryPath">Directory to empty</param>
        private void EmptyDirectory(string DirectoryPath)
        {
            DirectoryInfo di = new DirectoryInfo(DirectoryPath);

            try
            {
                foreach (FileInfo file in di.EnumerateFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.EnumerateDirectories())
                {
                    dir.Delete(true);
                }
            }
            catch (IOException)
            {
                Log.Add($"Failed to empty directory {DirectoryPath}");
            }            
        }

        /// <summary>
        /// Move all files from the source to the target recursively
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        private void MigrateFiles(DirectoryInfo source, DirectoryInfo target)
        {
            Log.Add($"Copying from source: '{source.FullName}' to target: '{target.FullName}'");
            if (target.FullName.Contains(Properties.Settings.Default.IntegrationServer))
            {
                foreach (FileInfo file in source.GetFiles().Where(f => f.Name == "system.ver"))
                    file.CopyTo(Path.Combine(target.FullName, file.Name), true);
            }            
            else
            {
                foreach (DirectoryInfo dir in source.GetDirectories().Where(f => f.Name != "archive"))
                    MigrateFiles(dir, target.CreateSubdirectory(dir.Name));

                var fileInfos = target.FullName.Contains(Properties.Settings.Default.ProdServerPrefix)
                    ? source.GetFiles().Where(f => f.Name != "InsertRowDeployedLPAVersions.sql")
                    : source.GetFiles();

                foreach (FileInfo file in fileInfos)
                    file.CopyTo(Path.Combine(target.FullName, file.Name), true);
            }
        }

        /// <summary>
        /// Clean up the folders, the Working directory contents need to be moved up a directory
        /// So all content inside of the <see cref="_workingFolderName"/> directory would join
        /// the base directory. So that once the main manifest is updated it will instantly pick up the changes.
        /// </summary>
        /// <param name="source">The Working directory</param>
        /// <param name="target">The folder directory</param>
        private void CleanUpFolders(DirectoryInfo source, DirectoryInfo target)
        {
            foreach (DirectoryInfo dir in source.GetDirectories())
                CleanUpFolders(dir, target.CreateSubdirectory(dir.Name));
            foreach (FileInfo file in source.GetFiles())
                file.CopyTo(Path.Combine(target.FullName, file.Name));
        }

        /// <summary>
        /// Roll back the changes created by the tool.
        /// </summary>
        private void Rollback()
        {
            try
            {
                ///TODO: Version2
                throw new Exception("Security.");
                Directory.Delete(_basePath + $"{_workingFolderName}", true);
            }
            catch (DirectoryNotFoundException)
            {
                //this is okay, that means we didn't make it far enough to create the Working directory.
            }
        }

        /// <summary>
        /// Update the main manifest
        /// </summary>
        private void ModifyMainManifest()
        {
            const string namespaceName = "urn:schemas-microsoft-com:PAG:updater-application-block:v2:manifest";
            string filename = _basePath + "\\mainManifest.xml";

            Log.Add($"Reading MainManifest from {filename}");

            //create new instance of XmlDocument
            XDocument doc = XDocument.Load(filename);

            doc.Root.Element("{urn:schemas-microsoft-com:PAG:updater-application-block:v2:manifest}includedManifests").Add(new XElement(XName.Get("manifest", namespaceName),
                new XAttribute("location", $"{_newVersion}\\updateManifest.xml"),
                new XAttribute("manifestId", "{" + _manifestId.ToString() + "}")));

            doc.Save(Path.Combine(_localPath, "mainManifest.xml"));

            Log.Add("Modifying main manifest");
        }

        /// <summary>
        /// Determine the new version that is
        /// </summary>
        private void CreateUpdateFolder()
        {
            Log.Add("Creating Update Folder");

            //a list of the folders in the directory
            //zero files will be evaluated.
            var folders = Directory.GetDirectories(_basePath);

            //prepare to find the highest
            int highest = 0;

            //prepare
            string fullVersion = "";

            foreach (var folder in folders)
            {
                //ignore the Working folder
                if (folder.Contains($"{_workingFolderName}"))
                    continue;

                //ignore the History folder
                if (folder.Contains($"{_historyFolderName}"))
                    continue;

                //The folder object is the whole path and we just want the name.
                var actualFolderName = folder.Substring(folder.LastIndexOf(@"\"));

                //split that name into parts so 1.2.3.4 would give us 2
                var parts = folder.Split('.');
                int.TryParse(parts[1], out int version);

                //update the highest value
                if (version > highest)
                {
                    highest = version;
                    fullVersion = actualFolderName;
                }
            }

            //change the versions
            //_newVersion is now passed in from the Create and Deploy to Next Region forms
            _oldVersion += highest;
            //_newVersion += highest + 1;
            string newVersionFolderName = $"\\{_newVersion}";
            _oldVersion = fullVersion.Replace("\\", "");

            //attempt to create the new folder

            Log.Add("Creating new folder");

            var currentVersionFolder = Directory.CreateDirectory(Path.Combine(_localPath, _newVersion));

            Log.Add("Successfully created new folder");
            Log.Add($"New version is: {_newVersion} and the new local path for the version is: {currentVersionFolder.FullName}");

            if (_file != null)
            {
                //counters
                var sqlCount = 0;
                var exeCount = 0;

                Log.Add("Going through files.");
                foreach (var file in _file)
                {
                    //get the file extension
                    var fileType = Path.GetExtension(file.FileName);
                    Log.Add($"Uploaded File Name: {file.FileName} has {fileType} extension");

                    switch (fileType.ToLower())
                    {
                        case ".sql":
                            var sqlPath = Path.Combine(currentVersionFolder.FullName, sqlCount == 0 ? "Update.sql" : $"Update_{sqlCount}.sql");
                            _uploadedFiles.Add(sqlPath);
                            file.SaveAs(sqlPath);
                            sqlCount++;

                            Log.Add($"{file.FileName} has been saved to {sqlPath}");
                            break;
                        case ".exe":
                            var exePath = Path.Combine(currentVersionFolder.FullName, exeCount == 0 ? "Update.exe" : $"Update_{exeCount}.exe");
                            _uploadedFiles.Add(exePath);
                            file.SaveAs(exePath);
                            exeCount++;

                            Log.Add($"{file.FileName} has been saved to {exePath}");
                            break;
                        default:
                            throw new Exception("An unknown file type was uploaded, only EXE and SQL are supported at this time");
                    }
                }
                //_file.SaveAs(currentVersionFolder.FullName + "\\" + "Update.sql"); //TODO: fix to add name.
                Log.Add("Saving Update File.");
                return;
            }

            Log.Add("No uploaded files detected, assuming that we already have them.");

            //Since no file was uploaded we must be moving the files so just get all of the
            //EXE and SQL files.
            var extensions = new List<string> { ".exe", ".sql" };
            _uploadedFiles = Directory.GetFiles(_pathToFile,
                "*.*",
                SearchOption.AllDirectories).Where(file => extensions.Contains(Path.GetExtension(file))).ToList();

            Log.Add($"Searching for .exe and .sql returned {_uploadedFiles.Count} file(s) and a result of '{string.Join(", ", _uploadedFiles)}' ");

            //go through the files on the server and copy them to the \\promote path and prepare them
            //to be copied to the destination server
            foreach (var file in _uploadedFiles)
            {
                Log.Add($"Copying File: '{file}' to '{currentVersionFolder.FullName}'");
                System.IO.File.Copy(file, Path.Combine(currentVersionFolder.FullName, Path.GetFileName(file)), true);
                Log.Add("Successfully copied file.");
            }
        }

        /// <summary>
        /// Dynamically create update manifest for the contents of the Remote System Update
        /// </summary>
        private void CreateUpdateManifest()
        {
            Log.Add("Creating Update Manifest");
            var manifest = new Manifest
            {
                ManifestId = "{" + _manifestId.ToString() + "}",
                Mandatory = "Yes",
                Xmlns = "urn:schemas-microsoft-com:PAG:updater-application-block:v2:manifest",
                Version = _newVersion,
                RequiredVersion = _oldVersion,
                DisplayName = _description,
                Application = new Application
                {
                    ApplicationDisplayName = "WOW_DESKTOP",
                    ApplicationId = "WOW_DESKTOP",
                    Location = @"..\..\LifePortraits"
                },
                Files = new Files
                {
                    Base = _url + "/RSU/" + _newVersion,
                    HashComparison = "No",
                    File = GetFileDetails()
                },
                Activation = new Activation
                {
                    Tasks = new Tasks
                    {
                        Task = GetTaskByExtension()
                    }
                }
            };

            var path = Path.Combine(_localPath, _newVersion, "updateManifest.xml");
            using (var writer = new StreamWriter(path))
            {
                var serializer = new XmlSerializer(manifest.GetType());
                serializer.Serialize(writer, manifest);
            }
            Log.Add("Update Manifest Created");
        }

        /// <summary>
        /// Get the correct number of tasks needs for the updateManifest and the correct type
        /// for EXE and SQL
        /// </summary>
        /// <returns>A list of tasks that are used to create the update manifest.</returns>
        private List<Task> GetTaskByExtension()
        {
            //add the task that stops the service
            var returnList = new List<Task> {
                new Task
                {
                    Type = "Microsoft.ApplicationBlocks.Updater.ActivationProcessors.ServiceStopProcessor, Microsoft.ApplicationBlocks.Updater.ActivationProcessors, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    Name = "StopLifePortraitsWebServer",
                    ServiceName = "LifePortraitsWebServer - WOW",
                    Timeout = "00:30:00"
                }
            };

            foreach (var file in _uploadedFiles)
            {
                //get the file extension

                //generate by file ext
                switch (Path.GetExtension(file))
                {
                    //in the case that it is a SQL file add the correct task
                    case ".sql":
                        returnList.Add(new Task
                        {
                            Type = "Microsoft.ApplicationBlocks.Updater.DatabaseActivationProcessors.SqlServerDatabaseUpdaterProcessor, Microsoft.ApplicationBlocks.Updater.DatabaseActivationProcessors, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            Name = "SqlServerDatabaseUpdater",
                            Config = new Config
                            {
                                Xmlns = "",
                                SqlScripts = new SqlScripts
                                {
                                    File2 = Path.GetFileName(file)
                                },
                                NhConfigurationFile = "PlanDatabase.config",
                                UseTransactions = "true",
                                BackupDatabase = "true"
                            }
                        });
                        break;
                    case ".exe":
                        returnList.Add(new Task
                        {
                            Type = "Microsoft.ApplicationBlocks.Updater.ActivationProcessors.LaunchExecutableProcessor, Microsoft.ApplicationBlocks.Updater.ActivationProcessors",
                            Name = "Patch",
                            Config = new Config
                            {
                                Xmlns = "",
                                ProcessOutputFile = @"%WINDIR%\TEMP\WOW_Patch_Result.log",
                                Silent = "true",
                                ExeArguments = string.Empty,
                                ExePath = Path.GetFileName(file),
                                ProcessTimeOut = "00:05:00"
                            }
                        });
                        break;
                    default:
                        throw new Exception("Unsupported file type uploaded");
                }
            }

            //add the start tasks
            returnList.AddRange(new List<Task>
            {
                new Task
                {
                    Type = "Microsoft.ApplicationBlocks.Updater.ActivationProcessors.VersionUpdaterProcessor, Microsoft.ApplicationBlocks.Updater.ActivationProcessors, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    Name = "UpdateSystemVersion",
                    Version = _newVersion
                },
                new Task
                {
                    Type = "Microsoft.ApplicationBlocks.Updater.ActivationProcessors.ServiceStartProcessor, Microsoft.ApplicationBlocks.Updater.ActivationProcessors, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    Name = "StartLifePortraitsWebServer",
                    ServiceName = "LifePortraitsWebServer - WOW",
                    Timeout = "00:30:00"
                }
            });

            return returnList;
        }

        /// <summary>
        /// Generate a list of details for the update manifest
        /// </summary>
        /// <returns>File details for the update manifest</returns>
        private List<File> GetFileDetails()
        {
            Log.Add("Creating file details");

            //create the list
            var returnList = new List<File>();

            //loop through the files 
            foreach (var file in _uploadedFiles)
            {
                //get the file info
                var info = new FileInfo(file);
                var name = info.Name;

                Log.Add($"File {name} and size of {info.Length}");

                returnList.Add(new File
                {
                    Source = name,
                    Size = info.Length.ToString(),
                    Transient = "No"
                });
            }

            Log.Add("Created file details");

            //return the list of files that are needed
            return returnList;
        }

        /// <summary>
        /// Create the system.ver file inside of the RSU folder
        /// </summary>
        private void CreateVersionFile()
        {
            Log.Add("Creating new version file");
            //get the path for the new version file before we write it.
            var verPath = Path.Combine(_localPath, "system.ver");

            //write out the new version to the file.
            System.IO.File.WriteAllText(verPath, _newVersion);
            Log.Add("Created new version file");
        }

        /// <summary>
        /// Create the InsertRowDeployedLPAVersions.sql file inside of the RSU folder
        /// </summary>
        private void CreateReconScript()
        {
            if (_promotePath.IndexOf("prod", StringComparison.OrdinalIgnoreCase) == -1) { return; }

            Log.Add("Creating new RECON Script");

            var verPath = Path.Combine(new string[] { _localPath, _newVersion, "InsertRowDeployedLPAVersions.sql" });

            System.IO.File.WriteAllText(verPath, $"insert into DeployedLPAVersions (LPAVersion, DeploymentDate) Values ('{_newVersion}','{_deploymentDate}')");

            Log.Add("Created new RECON Script");
        }

        /// <summary>
        /// Execute the update SQL against the server.
        /// </summary>
        private void ExecuteSql()
        {
            Log.Add("Executing SQL");

            string sqlText = "";

            foreach (var file in _uploadedFiles)
            {
                Log.Add($"Checking if {file} is a SQL file");

                //get the file extension
                switch (Path.GetExtension(file))
                {
                    case ".sql":
                        Log.Add("Reading SQL");
                        sqlText += System.IO.File.ReadAllText(file);
                        break;
                }
            }

            //create and open the connection
            using (var connection = new SqlConnection(_connectionString))
            {
                Log.Add("creating connection");

                //open the connection
                connection.Open();

                Log.Add("Starting transaction");
                //start the transaction
                var transaction = connection.BeginTransaction();

                try
                {
                    Log.Add($"SQL is {sqlText}");

                    Log.Add("Executing command");
                    //set the command and execute it
                    var command = new SqlCommand(sqlText, connection, transaction);
                    command.ExecuteNonQuery();

                    Log.Add("SQL executed");
                    //commit
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Log.Add($"An exception occurred {ex.Message}");
                    Log.Add($"Stack Trace: {ex.StackTrace}");
                    Log.Add($"Inner Exception: {ex.StackTrace}");

                    // Attempt to roll back the transaction.
                    try
                    {
                        Log.Add("Attempting a rollback");
                        transaction.Rollback();
                        Log.Add("Rollback Complete");
                    }
                    catch (Exception ex2)
                    {
                        Log.Add($"An exception occurred {ex2.Message}");
                        Log.Add($"Stack Trace: {ex2.StackTrace}");
                        Log.Add($"Inner Exception: {ex2.StackTrace}");
                        // This catch block will handle any errors that may have occurred
                        // on the server that would cause the rollback to fail, such as
                        // a closed connection.
                    }

                    throw new Exception("Unable to execute SQL, the files should be on the \\promote path, please complete" +
                        "the deployment as usual and revisit the logs");
                }
            }
        }
    }
}