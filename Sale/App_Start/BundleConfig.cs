using System.Web.Optimization;

namespace Sale
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css")
                .Include(
                "~/Content/bootstrap.min.css",
                "~/Content/fonts/font-awesome/css/font-awesome.css",
                "~/Content/animate.css",
                "~/Content/style.css"));         

            bundles.Add(new ScriptBundle("~/bundles/js")
                .Include(
                "~/Content/Scripts/jquery-3.1.1.min.js",
                "~/Content/Scripts/popper.min.js",
                "~/Content/Scripts/bootstrap.js",
                "~/Content/Scripts/plugins/metisMenu/jquery.metisMenu.js",
                "~/Content/Scripts/plugins/slimscroll/jquery.slimscroll.min.js",
                "~/Content/Scripts/app/inspinia.js",
                "~/Content/Scripts/plugins/pace/pace.min.js"));
        }
    }
}