using System.Collections.Generic;
using System.Web.Http.Dispatcher;

namespace WOW.WoodmenIntegrationService
{
    internal class CustomAssembliesResolver : DefaultAssembliesResolver
    {
        public override ICollection<System.Reflection.Assembly> GetAssemblies()
        {
            var assemblies = base.GetAssemblies();
            var customAssemblies = new List<System.Reflection.Assembly>();

            customAssemblies.Add(typeof(WOW.WoodmenIllustrationService.Controllers.IllustrationsController).Assembly);
            customAssemblies.Add(typeof(WOW.WoodmenIllustrationService.Controllers.ServiceController).Assembly);
            customAssemblies.Add(typeof(WOW.WoodmenIllustrationService.Controllers.SearchController).Assembly);

            foreach (var assembly in customAssemblies)
            {
                if (!assemblies.Contains(assembly))
                {
                    assemblies.Add(assembly);
                }
            }

            return assemblies;
        }
    }
}
