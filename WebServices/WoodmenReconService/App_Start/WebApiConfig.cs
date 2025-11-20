using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WOW.WoodmenReconService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            if (config == null)
            {
                throw new ArgumentNullException("config", "Cannot register a null HttpConfiguration object.");
            }

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
