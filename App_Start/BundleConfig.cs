using System.Web.Optimization;

namespace DelishWebsite
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/js/jquery-ui.js",
                        "~/Scripts/js/app.js",
                        "~/Scripts/js/easing.js",
                        "~/Scripts/js/jquery.flexisel.js",
                        "~/Scripts/js/lightbox-plus-jquery.min.js",
                        "~/Scripts/js/modernizr.custom.js",
                        "~/Scripts/js/move-top.js",
                        "~/Scripts/js/numcsroller-1.0.js",
                        "~/Scripts/js/particles.js",
                        "~/Scripts/js/responsiveslides.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/style.css",
                      "~/Content/css/font-awesome.css",
                      "~/Content/css/jquery-ui.css",
                      "~/Content/css/lightbox.css"));
        }
    }
}
