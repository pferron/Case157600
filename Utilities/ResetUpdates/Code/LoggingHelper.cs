using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using ResetUpdates.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResetUpdates.Code
{
    internal class LoggingHelper
    {
        public static void ConfigureLogging()
        {
            var hierarchy = (Hierarchy)LogManager.GetRepository();

            var patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = "%date [%thread] %-5level %logger - %message%newline";
            patternLayout.ActivateOptions();

            var fileAppender = new FileAppender();
            fileAppender.AppendToFile = true;
            fileAppender.File = Settings.Default.LogFilePath;
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
