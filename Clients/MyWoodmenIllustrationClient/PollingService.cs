using log4net;
using System;
using System.ServiceProcess;

namespace WOW.MyWoodmenIllustrationClient
{
    public partial class PollingService : ServiceBase
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(PollingService));
        private ServiceManager manager;

        public PollingService()
        {
            if (log.IsDebugEnabled) log.Debug("Initializing the MyWoodmen Illustration Service");
            InitializeComponent();

            ServiceName = "WOWMyWoodmenIllustrationService";
            CanPauseAndContinue = false;
            CanShutdown = true;
            CanStop = true;
            CanHandlePowerEvent = false;
            CanHandleSessionChangeEvent = false;

            manager = new ServiceManager();

            if (log.IsDebugEnabled) log.Debug("MyWoodmen Illustration Service initialized");
        }

        protected override void OnStart(string[] args)
        {
            if (log.IsInfoEnabled) log.Info("Starting the MyWoodmen Illustration Service");

            try
            {
                manager.OnStart();
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("There was an error starting the polling platform.", ex);
            }
            if (log.IsDebugEnabled) log.Debug("The MyWoodmen Illustration Service is started");
        }

        protected override void OnStop()
        {
            if (log.IsInfoEnabled) log.Info("Stopping the MyWoodmen Illustration Service");

            try
            {
                manager.OnStop();
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Exception while stopping the MyWoodmen Illustration Service", ex);
            }
            if (log.IsDebugEnabled) log.Debug("The MyWoodmen Illustration Service is stopped");
        }
    }
}
