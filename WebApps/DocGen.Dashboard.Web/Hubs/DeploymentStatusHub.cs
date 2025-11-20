using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPA.Dashboard.Web.Hubs
{
    public class DeploymentStatusHub : Hub
    {
        public static void UpdateClients(string message)
        {
            var context = Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<Hubs.DeploymentStatusHub>();
            context.Clients.All.addDeploymentStatus(message);
        }
    }
}