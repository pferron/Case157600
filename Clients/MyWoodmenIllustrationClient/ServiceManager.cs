using log4net;
using System.Threading;
using WOW.MyWoodmenIllustrationClient.Model;
using WOW.MyWoodmenIllustrationClient.Properties;

namespace WOW.MyWoodmenIllustrationClient
{
    internal class ServiceManager
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ServiceManager));
        private static bool abort = false;
        private Thread thread;

        internal void OnStart()
        {
            thread = new Thread(StartPollingCycle);
            thread.Name = "PollingThread";
            thread.IsBackground = false;
            thread.Start();
        }

        internal void StartPollingCycle()
        {
            var db2PollingFrequency = Settings.Default.DB2PollingFrequency;
            if (db2PollingFrequency <= 0) db2PollingFrequency = 0;
            var shortSleep = Settings.Default.ShortSleep_ms;
            if (shortSleep <= 0) shortSleep = 1000;

            var index = 0;

            do
            {
                if ((index % db2PollingFrequency) == 0)
                {
                    index = 0;
                    ProcessRun();
                }
                index++;

                Thread.Sleep(shortSleep);
            } while (!abort);
        }

        internal void ProcessRun()
        {
            var requests = Request.FetchRequests();

            foreach (var request in requests)
            {
                request.ProcessFipRequest();
            }
        }

        internal void OnStop()
        {
            abort = true;
            if (thread.ThreadState != ThreadState.Unstarted)
            {
                thread.Join(Settings.Default.ThreadTimeout_ms);
            }
        }
    }
}
