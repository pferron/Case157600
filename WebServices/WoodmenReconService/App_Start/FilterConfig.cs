using System;
using System.Web;
using System.Web.Mvc;

namespace WOW.WoodmenReconService
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
