using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WOW.WoodmenReconClient.Code
{
    static class NetworkingHelper
    {
        public static bool HasConnection(string url)
        {
            if(String.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException("URL parameter cannot be null or empty.", "url");
            }

            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead(url))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
