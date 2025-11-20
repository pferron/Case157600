using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleDeploymentService
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args == null)
                return;

            HttpClientHandler handler = new HttpClientHandler
            {
                UseDefaultCredentials = true
            };
            using (var client = new HttpClient(handler))
            {
                var result = await client.GetAsync(args[0]);
            }
        }
    }
}
