using System.ServiceProcess;

namespace WOW.WoodmenReconClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new ReconClientService() 
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
