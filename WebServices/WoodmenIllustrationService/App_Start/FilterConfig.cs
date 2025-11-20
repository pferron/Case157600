using System;
using System.Web.Mvc;

namespace WOW.WoodmenIllustrationService
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            if (filters == null)
            {
                throw new ArgumentNullException("filters", "Cannot register a null GlobalFilterCollection object.");
            }

            filters.Add(new HandleErrorAttribute());
        }
    }
}
