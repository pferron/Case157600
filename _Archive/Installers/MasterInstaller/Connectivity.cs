using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace WOW.ISU.MasterInstaller
{
    public static class Connectivity
    {
        /// <summary>
        /// Indicates whether any network connection is available.
        /// Filter connections below a specified speed, as well as virtual network cards.
        /// </summary>
        /// <param name="minimumSpeed">The minimum speed required. Passing 0 will not filter connection using speed.
        ///     This speed is what the interface is supposedly set to do or is suppose to be capable of, not its actual speed.
        /// 		Speed   100,000,000,000 - LAN Connection
        /// 		Speed    10,000,000,000 - LAN Connection
        /// 		Speed	    130,000,000 - Wireless N
        /// 		Speed	    120,000,000 - 120mB typical wireless N connection
        /// 		Speed       100,000,000 - 4G
        ///         Speed	     54,000,000 - 54mB typically wireless a/g connection
        ///         Speed	     11,000,000 - 11mB typically wireless b connection
        ///         Speed         2,000,000 - 3G
        /// </param>
        /// <returns>
        ///     <c>true</c> if a network connection is available; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNetworkAvailable(Uri targetHost, long minimumSpeed, out long detectedSpeed)
        {
            // Default to less than zero in case the service gets set to zero minimum speed.
            // This will allow the function to return false if no active adaptors are detected.
            detectedSpeed = -1;

            try
            {
                UdpClient client = new UdpClient(targetHost.Host, 80);
                IPAddress localAddr = ((IPEndPoint)client.Client.LocalEndPoint).Address;

                var adapters = NetworkInterface.GetAllNetworkInterfaces().Where(n => n.OperationalStatus == OperationalStatus.Up && n.NetworkInterfaceType != NetworkInterfaceType.Loopback);

                foreach (var adapter in adapters)
                {
                    if (adapter.GetIPProperties().UnicastAddresses.Any(u => u.Address.Equals(localAddr)))
                    {
                        detectedSpeed = adapter.Speed;
                    }
                }
            }
            catch
            {
                return false;
            }

            return detectedSpeed >= minimumSpeed;
        }

        public static bool IsNetworkAvailable(Uri targetHost, long minimumSpeed)
        {
            long suppressDetectedSpeed;
            return IsNetworkAvailable(targetHost, minimumSpeed, out suppressDetectedSpeed);
        }
    }
}
