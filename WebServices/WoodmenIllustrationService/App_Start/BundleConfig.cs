using System;
using System.Web.Optimization;

namespace WOW.WoodmenIllustrationService
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            if (bundles == null)
            {
                throw new ArgumentNullException("bundles", "Cannot register a null BundleCollection object.");
            }

            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js","~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content").Include("~/Content/Site.css", "~/Content/simpletabs.css"));
            bundles.Add(new ScriptBundle("~/Scripts").Include("~/Scripts/simpletabs_1.3.packed.js"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}
