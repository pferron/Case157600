using Newtonsoft.Json;
using Owin;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace WOW.WoodmenIntegrationService
{
    internal class IntegrationServiceStartup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();

            config.Services.Replace(typeof(IAssembliesResolver), new CustomAssembliesResolver());

            // Web API configuration and services
            config.Formatters.JsonFormatter.SerializerSettings.TypeNameHandling = TypeNameHandling.Auto;
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            config.Routes.IgnoreRoute("NoAXD", "{resource}.axd/{*pathInfo}");

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);
        }
    }
}
