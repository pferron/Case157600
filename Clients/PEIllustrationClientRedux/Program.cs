using log4net;
using System;
using System.Globalization;
using WOW.PEIllustrationClient.Code;

namespace WOW.PEIllustrationClient
{
    class Program
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            // Wire-up log4net
            log4net.Config.XmlConfigurator.Configure();

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(ErrorHandler);

            try
            {
                // Check for a passed parameter
                if (args.Length == 0)
                {
                    if (logger.IsErrorEnabled) { logger.Error("PrintExpert Illustration Client called with no run id."); }
                    return;
                }

                int runID;

                // Parse the value and send the request to RabbitMQ
                if (Int32.TryParse(args[0], out runID))
                {
                    var illusRun = new IllustrationRun(runID);
                    illusRun.StartRun();
                }
                else
                {
                    if (logger.IsErrorEnabled) { logger.ErrorFormat(CultureInfo.InvariantCulture, "Invalid parameter launching PrintExpert Illustration Client: {0}.", args[0]); }
                }

                return;
            }
            catch (Exception ex)
            {
                if (logger.IsErrorEnabled) { logger.Error(String.Format(CultureInfo.InvariantCulture, "There was an error launching PEIllustrationClient with parameter {0}.", args[0]), ex); }
            }
        }

        static void ErrorHandler(object sender, UnhandledExceptionEventArgs args)
        {
            if(args != null)
            {
                var ex = args.ExceptionObject as System.Exception;

                if (logger.IsErrorEnabled) { logger.Error("An unhandled exception occurred:", ex); }
            }
            else
            {
                if (logger.IsErrorEnabled) { logger.Error("An unhandled exception occurred. Unhandled exception object was not available."); }
            }
        }
    }
}
