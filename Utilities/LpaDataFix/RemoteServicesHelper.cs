using System;
using System.ServiceProcess;

namespace LpaDataFix
{
    internal static class RemoteServicesHelper
    {
        public static void StartService(string host, string serviceName)
        {
            try
            {
                ServiceController serviceController = new ServiceController(serviceName, host);
                if (serviceController.Status != ServiceControllerStatus.Stopped)
                    return;
                serviceController.Start();
            }
            catch (Exception ex)
            {
                throw new RemoteServicesHelperException(string.Format("An error occurred while trying to start service '{1}' on host '{0}'.", (object)host, (object)serviceName), ex);
            }
        }

        public static void StopService(string host, string serviceName)
        {
            try
            {
                ServiceController serviceController = new ServiceController(serviceName, host);
                if (serviceController.Status == ServiceControllerStatus.Running)
                    serviceController.Stop();
                while (serviceController.Status != ServiceControllerStatus.Stopped)
                    serviceController.Refresh();
            }
            catch (Exception ex)
            {
                throw new RemoteServicesHelperException(string.Format("An error occurred while trying to stop service '{1}' on host '{0}'.", (object)host, (object)serviceName), ex);
            }
        }

        public static void RestartService(string host, string serviceName)
        {
            RemoteServicesHelper.StopService(host, serviceName);
            RemoteServicesHelper.StartService(host, serviceName);
        }
    }
}
