using System;
using System.Web.Optimization;

namespace WOW.WoodmenReconService
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

            bundles.Add(new StyleBundle("~/Content").Include("~/Content/Site.css"));
            //bundles.Add(new ScriptBundle("~/Scripts").Include("~/Scripts/simpletabs_1.3.packed.js"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}
