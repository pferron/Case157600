using System.Web.Http;

namespace LPA.Dashboard.Web
{
    /// <summary>
    /// The web api configuration.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// TODO: Add Summary
        /// </summary>
        /// <param name="config">The configuration.</param>
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
