using log4net;
using System;
using System.Globalization;
using System.IO;
using System.ServiceProcess;

namespace WOW.MyWoodmenIllustrationClient
{
    internal static class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        /// <summary>
        /// This is the primary method for the entire application.
        /// </summary>
        internal static void Main()
        {
            // Configure current directory so that log4net uses the service's app path instead of the system32 folder.
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

            // Wire-up unhandled exception event
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionHandler);

            if (Environment.UserInteractive)
            {
                //Just do a one-time run.
                var manager = new ServiceManager();
                manager.ProcessRun();
            }
            else
            {
                var ServicesToRun = new ServiceBase[] { new PollingService() };
                ServiceBase.Run(ServicesToRun);
            }
        }


        /// <summary>
        /// This method is used as a top-level application-wide exception handler.
        /// </summary>
        /// <param name="sender">The object sending the message.</param>
        /// <param name="e">An Unhandled Exception Event Args containing details about the exception.</param>
        internal static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            if (e == null)
            {
                log.Fatal("The MyWoodmen Illustration Client produced an unhandled exception.(Null UnhandledExceptionEventArgs)");
            }
            else if (e.ExceptionObject == null)
            {
                log.Fatal("The MyWoodmen Illustration Client produced an unhandled exception.(Null ExceptionObject)");
            }
            else
            {
                var exception = e.ExceptionObject as Exception;
                if (exception == null)
                {
                    log.FatalFormat(CultureInfo.InvariantCulture, "The MyWoodmen Illustration Client produced an unhandled exception.  e.ExceptionObject: {0}", e.ExceptionObject);
                }
                else
                {
                    log.Fatal("The MyWoodmen Illustration Client produced an unhandled exception.", exception);
                }
            }
        }
    }
}
