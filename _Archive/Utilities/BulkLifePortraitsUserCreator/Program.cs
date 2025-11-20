using BulkLifePortraitsUserCreator.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Security;
using System.Xml;

namespace BulkLifePortraitsUserCreator
{
    class Program
    {
        private static string inputFilePath;
        private static string outputFolderPath;

        static void Main(string[] args)
        {
            if (!args.Any())
            {
                HelpMessage();

                return;
            }

            if (File.Exists(args[0]))
            {
                inputFilePath = args[0];
            }
            else
            {
                Console.WriteLine("Input file '{0}' wasn't found.", args[0]);
                return;
            }

            if (Directory.Exists(args[1]))
            {
                outputFolderPath = args[1];
            }
            else
            {
                Console.WriteLine("Output folder '{0}' wasn't found.", args[1]);
                return;
            }

            // Read CSV containing:
            var agents = LoadAgentList(inputFilePath);

            Console.WriteLine("Loaded {0} agents from '{1}'.", agents.Count, inputFilePath);

            foreach (var agent in agents)
            {
                var xmlDoc = CreateXmlRequest(agent);

                var fullPath = Path.Combine(outputFolderPath, agent.Id + "_" + agent.LastName + ".xml");

                XmlWriterSettings writerSettings = new XmlWriterSettings();
                writerSettings.OmitXmlDeclaration = true;
                writerSettings.Indent = true;

                using (XmlWriter xmlWriter = XmlWriter.Create(fullPath, writerSettings))
                {
                    xmlDoc.Save(xmlWriter);
                }
            }

            Console.WriteLine("XML files have been written to '{0}'.", outputFolderPath);
        }

        private static List<AgentRecord> LoadAgentList(string inputFilePath)
        {
            var agents = new List<AgentRecord>();

            var lines = File.ReadAllLines(inputFilePath);

            foreach (var line in lines)
            {
                var tmp = line.Split(',');

                var agent = new AgentRecord();
                agent.Id = tmp[0].Trim();
                agent.FirstName = tmp[1].Trim();
                agent.LastName = tmp[2].Trim();
                agent.State = tmp[3].Trim();

                agents.Add(agent);
            }

            return agents;
        }

        private static void HelpMessage()
        {
            Console.WriteLine("Arg0: Path to a CSV file containing agent info (agentId, firstname, lastname)");
            Console.WriteLine("Arg1: Path to folder to write XML files to");
        }

        private static XmlDocument CreateXmlRequest(AgentRecord agent)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Settings.Default.RequestTemplatePath);

            XmlNode uniqueIdNode = xmlDoc.SelectSingleNode("/AgentAccountSetupData/AGENT/UNIQUEID");
            XmlNode uniquePassNode = xmlDoc.SelectSingleNode("/AgentAccountSetupData/AGENT/UNIQUEPASS");
            XmlNode firstNameNode = xmlDoc.SelectSingleNode("/AgentAccountSetupData/AGENT/FIRSTNAME");
            XmlNode lastNameNode = xmlDoc.SelectSingleNode("/AgentAccountSetupData/AGENT/LASTNAME");
            XmlNode roleCodeNode = xmlDoc.SelectSingleNode("/AgentAccountSetupData/AGENT/ROLECODE");
            XmlNode languageNode = xmlDoc.SelectSingleNode("/AgentAccountSetupData/AGENT/LANGUAGE");
            XmlNode distributionNode = xmlDoc.SelectSingleNode("/AgentAccountSetupData/AGENT/PROFILES/PROFILE/DISTRIBUTION");
            XmlNode agentState = xmlDoc.SelectSingleNode("/AgentAccountSetupData/AGENT/PROFILES/PROFILE/STATE");

            uniqueIdNode.InnerText = agent.Id;
            uniquePassNode.InnerText = Membership.GeneratePassword(16, 1);
            firstNameNode.InnerText = agent.FirstName;
            lastNameNode.InnerText = agent.LastName;
            roleCodeNode.InnerText = Settings.Default.DefaultRoleCode;
            languageNode.InnerText = Settings.Default.DefaultLanguage;
            distributionNode.InnerText = Settings.Default.DefaultDistributionChannel;
            agentState.InnerText = agent.State;

            return xmlDoc;
        }
    }
}
