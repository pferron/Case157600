using System;
using System.Web.Http;

namespace WOW.WoodmenIllustrationService
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            if (config == null)
            {
                throw new ArgumentNullException("config", "Cannot register a null HttpConfiguration object.");
            }

            // Enable tracing
            config.EnableSystemDiagnosticsTracing();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SerializerSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
        }
    }
}
