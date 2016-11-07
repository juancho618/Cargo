using System.Web;
using System.Web.Optimization;

namespace Cargo
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/selectize.js")
                .Include("~/Scripts/sweetalert.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-select.js",
                      "~/Scripts/light-bootstrap-dashboard.js",
                      "~/Scripts/light-bootstrap-checkbox-radio-switch.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular")
                .Include("~/Scripts/angular.min.js")
                .IncludeDirectory("~/Scripts/app/directives", "*.js")
                .Include("~/Scripts/app/app.js")
                .Include("~/Scripts/app/components/ui-bootstrap-tpls-2.1.3.min.js")
                .IncludeDirectory("~/Scripts/app/controllers", "*.js")
                .IncludeDirectory("~/Scripts/app/controllers/courier", "*.js")
                .IncludeDirectory("~/Scripts/app/controllers/unitType", "*.js")
                .IncludeDirectory("~/Scripts/app/controllers/delivery", "*.js")
                );

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/selectize.css",
                      "~/Content/selectize.default.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/animate.css",
                      "~/Content/light-bootstrap-dashboard.css",
                      "~/Content/pe-icon-7-stroke.css",
                      "~/Content/sweetalert.css"));
        }
    }
}
