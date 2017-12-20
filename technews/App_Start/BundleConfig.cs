using System.Web;
using System.Web.Optimization;

namespace technews
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                      "~/Scripts/galleryviewthemes/jquery.easing.1.3.js",
                      "~/Scripts/galleryviewthemes/jquery.galleryview.2.1.1.min.js",
                      "~/Scripts/galleryviewthemes/jquery.galleryview.setup.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
         

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));




            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css",
                      "~/Content/featured_slide.css",
                      "~/Content/forms.css",
                      "~/Content/layout.css",
                      "~/Content/navi.css",
                      "~/Content/tables.css"));


        }
    }
}
