using log4net;
using MoreLinq;
using System;
using System.Linq;
using System.Web.Mvc;
using WOW.WoodmenReconService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using WOW.WoodmenReconService.Code;

namespace WOW.WoodmenReconService.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(HomeController));

        public ActionResult Index(string LpaVersion, string DeploymentDate, string Hostname)
        {
            ViewBag.Title = "Woodmen Recon Service";

            HomeModel model;

            try
            {
                model = new HomeModel();

                var metrics = new Metrics();

                using (var ef = new WoodmenReconServiceEntities())
                {
                    // Recapture input values for redisplay
                    model.HostnameParameter = Hostname;
                    model.DeploymentDateParameter = DeploymentDate;
                    model.LpaVersionParameter = LpaVersion;

                    model.ReportsSubmittedToday = metrics.ReportSubmitted(0);
                    model.ReportsSubmittedLastThirtyDays = metrics.ReportSubmitted(30);

                    model.HostsSeenToday = metrics.DistinctHosts(0);
                    model.HostsSeenLastThirtyDays = metrics.DistinctHosts(30);

                    model.IsDatabaseActive = true;

                    DateTime _deploymentDate = DateTime.Now;

                    if (DateTime.TryParse(DeploymentDate, out _deploymentDate))
                    {
                        if(!String.IsNullOrWhiteSpace(LpaVersion))
                        {
                            var result = ef.FetchNonCompliantHosts(LpaVersion, _deploymentDate);

                            foreach(var record in result)
                            {
                                model.NonCompliantHosts.Add(new HostData { LpaVersion = record.LpaVersion, Hostname = record.Hostname });
                            }
                        }
                    }

                    if(!String.IsNullOrWhiteSpace(Hostname))
                    {
                        var lpaVersions = ef.FetchReportsByHostname(Hostname, "LpaVersion");

                        foreach (var record in lpaVersions)
                        {
                            model.LpaVersionReports.Add(new LpaVersionData { Hostname = record.Hostname, LpaVersion = record.DataValue, ReportReceivedDate = record.DateReceived });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error("Error fetching report counts.", ex); }

                ViewBag.ErrorMessage = "An exception occurred while loading this page. Please check the log.";

                model = new HomeModel();
            }

            return View(model);
        }
    }
}
