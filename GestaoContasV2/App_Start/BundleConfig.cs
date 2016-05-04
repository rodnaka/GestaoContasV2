using System.Web;
using System.Web.Optimization;

namespace GestaoContasV2
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-{version}.intellisense.js",
                        "~/Scripts/jquery-{version}.min.js",
                        "~/Scripts/jquery-{version}.min.map",
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/jquery-ui-{version}.min.js",
                        "~/Scripts/jquery.signalR-{version}.js",
                        "~/Scripts/jquery.signalR-{version}.min.js",
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.validate.unobtrusive.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-theme.css",
                      "~/Content/bootstrap-theme.css.map",
                      "~/Content/bootstrap-theme.min.css",
                      "~/Content/bootstrap-theme.min.css.map",
                      "~/Content/bootstrap.css.map",
                      "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap.min.css.map",
                      "~/Content/themes/base/datepicker.css",
                      "~/Content/themes/base/theme.css",
                      "~/Content/themes/base/all.css",
                      "~/Content/themes/base/base.css",
                      "~/Content/site.css"));
            
        }
    }
}
