using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LPA.Dashboard.Models.Deployment
{
    [XmlRoot(ElementName = "application", Namespace = "urn:schemas-microsoft-com:PAG:updater-application-block:v2:manifest")]
    public class Application
    {
        [XmlElement(ElementName = "location", Namespace = "urn:schemas-microsoft-com:PAG:updater-application-block:v2:manifest")]
        public string Location { get; set; }
        [XmlAttribute(AttributeName = "applicationDisplayName")]
        public string ApplicationDisplayName { get; set; }
        [XmlAttribute(AttributeName = "applicationId")]
        public string ApplicationId { get; set; }
    }

    [XmlRoot(ElementName = "file", Namespace = "urn:schemas-microsoft-com:PAG:updater-application-block:v2:manifest")]
    public class File
    {
        [XmlAttribute(AttributeName = "source")]
        public string Source { get; set; }
        [XmlAttribute(AttributeName = "size")]
        public string Size { get; set; }
        [XmlAttribute(AttributeName = "transient")]
        public string Transient { get; set; }
    }

    [XmlRoot(ElementName = "files", Namespace = "urn:schemas-microsoft-com:PAG:updater-application-block:v2:manifest")]
    public class Files
    {
        [XmlElement(ElementName = "file", Namespace = "urn:schemas-microsoft-com:PAG:updater-application-block:v2:manifest")]
        public List<File> File { get; set; }
        [XmlAttribute(AttributeName = "base")]
        public string Base { get; set; }
        [XmlAttribute(AttributeName = "hashComparison")]
        public string HashComparison { get; set; }
    }

    [XmlRoot(ElementName = "task", Namespace = "urn:schemas-microsoft-com:PAG:updater-application-block:v2:manifest")]
    public class Task
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "serviceName")]
        public string ServiceName { get; set; }
        [XmlAttribute(AttributeName = "timeout")]
        public string Timeout { get; set; }
        [XmlElement(ElementName = "config")]
        public Config Config { get; set; }
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
    }

    [XmlRoot(ElementName = "sqlScripts")]
    public class SqlScripts
    {
        [XmlElement(ElementName = "file")]
        public string File2 { get; set; }
    }

    [XmlRoot(ElementName = "config")]
    public class Config
    {
        [XmlElement(ElementName = "sqlScripts")]
        public SqlScripts SqlScripts { get; set; }
        [XmlElement(ElementName = "nhConfigurationFile")]
        public string NhConfigurationFile { get; set; }
        [XmlElement(ElementName = "useTransactions")]
        public string UseTransactions { get; set; }
        [XmlElement(ElementName = "backupDatabase")]
        public string BackupDatabase { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
        [XmlElement(ElementName = "processOutputFile")]
        public string ProcessOutputFile { get; set; }
        [XmlElement(ElementName = "silent")]
        public string Silent { get; set; }
        [XmlElement(ElementName = "exeArguments")]
        public string ExeArguments { get; set; }
        [XmlElement(ElementName = "exePath")]
        public string ExePath { get; set; }
        [XmlElement(ElementName = "processTimeOut")]
        public string ProcessTimeOut { get; set; }
    }

    [XmlRoot(ElementName = "tasks", Namespace = "urn:schemas-microsoft-com:PAG:updater-application-block:v2:manifest")]
    public class Tasks
    {
        [XmlElement(ElementName = "task", Namespace = "urn:schemas-microsoft-com:PAG:updater-application-block:v2:manifest")]
        public List<Task> Task { get; set; }
    }

    [XmlRoot(ElementName = "activation", Namespace = "urn:schemas-microsoft-com:PAG:updater-application-block:v2:manifest")]
    public class Activation
    {
        [XmlElement(ElementName = "tasks", Namespace = "urn:schemas-microsoft-com:PAG:updater-application-block:v2:manifest")]
        public Tasks Tasks { get; set; }
    }

    [XmlRoot(ElementName = "manifest", Namespace = "urn:schemas-microsoft-com:PAG:updater-application-block:v2:manifest")]
    public class Manifest
    {
        [XmlElement(ElementName = "version", Namespace = "urn:schemas-microsoft-com:PAG:updater-application-block:v2:manifest")]
        public string Version { get; set; }
        [XmlElement(ElementName = "requiredVersion", Namespace = "urn:schemas-microsoft-com:PAG:updater-application-block:v2:manifest")]
        public string RequiredVersion { get; set; }
        [XmlElement(ElementName = "displayName", Namespace = "urn:schemas-microsoft-com:PAG:updater-application-block:v2:manifest")]
        public string DisplayName { get; set; }
        [XmlElement(ElementName = "description", Namespace = "urn:schemas-microsoft-com:PAG:updater-application-block:v2:manifest")]
        public string Description { get; set; }
        [XmlElement(ElementName = "application", Namespace = "urn:schemas-microsoft-com:PAG:updater-application-block:v2:manifest")]
        public Application Application { get; set; }
        [XmlElement(ElementName = "files", Namespace = "urn:schemas-microsoft-com:PAG:updater-application-block:v2:manifest")]
        public Files Files { get; set; }
        [XmlElement(ElementName = "activation", Namespace = "urn:schemas-microsoft-com:PAG:updater-application-block:v2:manifest")]
        public Activation Activation { get; set; }
        [XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsd { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "manifestId")]
        public string ManifestId { get; set; }
        [XmlAttribute(AttributeName = "mandatory")]
        public string Mandatory { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
    }
}
