
namespace ScatterBot
{
    class ScatterBotAction
    {
        public string SourceHostname { get; set; }
        public string TargetHostname { get; set; }
        public bool UpdateWebServerVersion { get; set; }
        public bool UpdateAppServerVersion { get; set; }
        public bool UpdateLifeServerVersion { get; set; }
        public bool DeployRsuPackage { get; set; }
        public bool RestartServices { get; set; }
        public string AppServiceName { get; set; }
        public string LifeServiceName { get; set; }

        public string SourceVersionFilePath { get; set; }
        public string TargetAppVersionFilePath { get; set; }
        public string TargetLifeVersionFilePath { get; set; }
        public string TargetWebVersionFilePath { get; set; }

        public string SourceRsuFolderPath { get; set; }
        public string TargetRsuFolderPath { get; set; }
    }
}
