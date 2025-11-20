using System.Web.Optimization;

namespace LPA.Dashboard.Web
{
    /// <summary>
    /// The bundle configuration.
    /// </summary>
    public static class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        /// <summary>
        /// Registers the bundles.
        /// </summary>
        /// <param name="bundles">The bundles.</param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                        "~/Scripts/dataTables.min.js",
                        "~/Scripts/dataTables.boostrap4.min.js",
                        "~/Scripts/dataTables.foundation.min.js",
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/umd/popper.min.js",
                  "~/Scripts/bootstrap.js",
                  "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/datetime").Include(
                 "~/Scripts/moment.js",
                 "~/Scripts/datetime.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/themes/base/*.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                      "~/Scripts/custom/common.js",
                      "~/Scripts/custom/popUps.js"));

            bundles.Add(new ScriptBundle("~/bundles/typescript").Include(
                      "~/Scripts/custom/test.js"));
        }
    }
}
