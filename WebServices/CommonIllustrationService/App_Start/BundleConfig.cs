using System.Web;
using System.Web.Optimization;

namespace CommonIllustrationService
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new StyleBundle("~/Content").Include("~/Content/site.css", 
                                                                 "~/Content/simpletabs.css"));
            bundles.Add(new ScriptBundle("~/Scripts").Include("~/Scripts/simpletabs_1.3.packed.js"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}
