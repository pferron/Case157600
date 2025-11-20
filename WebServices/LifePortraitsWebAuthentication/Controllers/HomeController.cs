using log4net;
using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WOW.LifePortraitsWebAuthentication.Properties;

namespace WOW.LifePortraitsWebAuthentication.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(HomeController));

        /// <summary>
        /// Displays default page with status of database. Useful for heartbeat monitoring. Directs user to MyWoodmen, just in case.
        /// </summary>
        /// <returns>Status page</returns>
        public ActionResult Index()
        {
            ViewBag.Title = "LPA Integration Service Dashboard";

            return View();
        }

        /// <summary>
        /// Generic error page
        /// </summary>
        /// <param name="ServiceErrorModel">Error object with an error code and message</param>
        /// <returns>Error page</returns>
        public ActionResult Error(ServiceErrorModel model)
        {
            ViewBag.Title = "Error";

            return View(model);
        }

        public async Task<ActionResult> StartLpaSession(string Username)
        {
            throw new NotSupportedException("For security reasons, this feature is disabled when the app is promoted to servers.");
            
            //Make REST call to web api service, redirect to returned URL
            var url = await RequestNewSession(Username);

            return Redirect(url);
        }

        private async Task<string> RequestNewSession(string Username)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string baseUrl = Request.Url.GetComponents(UriComponents.SchemeAndServer, UriFormat.UriEscaped); // Expected to be http://hostname (no slash)
                    string appName = Request.ApplicationPath; // Should be /AppName for IIS apps
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var query = HttpUtility.ParseQueryString(string.Empty);
                    query["Username"] = Username;

                    // Append application name in IIS environment, if needed
                    var apiWithParams = (appName.Length > 1) ? appName + "/api/Integration/RequestLpaSession?" + query.ToString() : "/api/Integration/RequestLpaSession?" + query.ToString();

                    if (log.IsDebugEnabled) { log.DebugFormat(CultureInfo.InvariantCulture, "Url: {0}, QueryString: {1}", baseUrl + appName, apiWithParams); }

                    // HTTP GET
                    var response = await client.GetAsync(apiWithParams).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        // This will return either the LifePortraits URL or the error URL with an error code attached to it.
                        return await response.Content.ReadAsAsync<string>().ConfigureAwait(false);
                    }
                    else
                    {
                        // This condition will occur when the request to the integration service failed before reaching the LPA SSO service.
                        if (log.IsErrorEnabled) { log.ErrorFormat("The LPA SSO Integration Service returned a failure message. StatusCode: {0}; Reason: {1}", response.StatusCode, response.ReasonPhrase); }

                        return Settings.Default.AuthErrorUrl;
                    }
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error(String.Format(CultureInfo.InvariantCulture, "There was an error creating a new session for user {0}.", Username), ex); }

                return Settings.Default.AuthErrorUrl;
            }
        }
    }
}
