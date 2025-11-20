using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using LpaDesktopSyncUpdater.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LpaDesktopSyncUpdater
{
    internal class LoggingHelper
    {
        public static void ConfigureLogging()
        {
            var hierarchy = (Hierarchy)LogManager.GetRepository();

            var patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = "%date [%thread] %-5level %logger - %message%newline";
            patternLayout.ActivateOptions();

            var consoleLayout = new PatternLayout();
            consoleLayout.ConversionPattern = "%-5level %message%newline";
            consoleLayout.ActivateOptions();

            var logFilePath = Path.Combine(Settings.Default.LoggingFolderPath, "LpaDesktopSyncUpdater.log");

            if (!Directory.Exists(Settings.Default.LoggingFolderPath))
            {
                // Calls utility method on main class to create a folder that everyone can read and write to.
                Program.CreateCommonFolder(Settings.Default.LoggingFolderPath);
            }

            var consoleAppender = new ConsoleAppender();
            consoleAppender.Layout = consoleLayout;
            consoleAppender.ActivateOptions();
            hierarchy.Root.AddAppender(consoleAppender);

            var fileAppender = new FileAppender();
            fileAppender.AppendToFile = true;
            fileAppender.File = logFilePath;
            fileAppender.Layout = patternLayout;
            fileAppender.ActivateOptions();
            hierarchy.Root.AddAppender(fileAppender);

            var memory = new MemoryAppender();
            memory.ActivateOptions();
            hierarchy.Root.AddAppender(memory);

            hierarchy.Root.Level = Level.Debug;
            hierarchy.Configured = true;
        }
    }
}
