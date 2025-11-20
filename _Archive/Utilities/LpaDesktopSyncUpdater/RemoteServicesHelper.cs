
using System;
using System.ServiceProcess;
namespace LpaDesktopSyncUpdater
{
    internal static class RemoteServicesHelper
    {
        public static void StartService(string host, string serviceName)
        {
            try
            {
                ServiceController sc = new ServiceController(serviceName, host);

                if (sc.Status == ServiceControllerStatus.Stopped)
                {
                    sc.Start();
                }
            }
            catch (Exception ex)
            {
                var msg = String.Format("An error occurred while trying to start service '{1}' on host '{0}'.", host, serviceName);

                throw new RemoteServicesHelperException(msg, ex);
            }
        }

        public static void StopService(string host, string serviceName)
        {
            try
            {
                ServiceController sc = new ServiceController(serviceName, host);

                if (sc.Status == ServiceControllerStatus.Running)
                {
                    sc.Stop();
                }

                while (sc.Status != ServiceControllerStatus.Stopped)
                {
                    // Wait for stop
                    sc.Refresh();
                }
            }
            catch (Exception ex)
            {
                var msg = String.Format("An error occurred while trying to stop service '{1}' on host '{0}'.", host, serviceName);

                throw new RemoteServicesHelperException(msg, ex);
            }
        }

        public static void RestartService(string host, string serviceName)
        {
            StopService(host, serviceName);
            StartService(host, serviceName);
        }
    }
}
