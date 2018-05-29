using System.Web;
using System.Web.Optimization;

namespace ACS.WEB
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/dataTable").Include(
                        "~/Scripts/DataTables/*js"));
            bundles.Add(new StyleBundle("~/Content/datatable/css").Include(
                      "~/Scripts/DataTables/*css"));

            bundles.Add(new ScriptBundle("~/bundles/fileInput").Include(
                        "~/Scripts/kartik-v-bootstrap-fileinput-e03b535/js/fileinput.js",
                        "~/Scripts/kartik-v-bootstrap-fileinput-e03b535/js/plugins/*.js")
                        );
            bundles.Add(new StyleBundle("~/Content/fileInput/css").Include(
                      "~/Scripts/kartik-v-bootstrap-fileinput-e03b535/css/*css"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
