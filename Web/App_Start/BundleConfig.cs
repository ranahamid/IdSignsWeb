using System.Web.Optimization;

namespace Web
{
    /// <summary>
    /// BundleConfig
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// RegisterBundles
        /// </summary>
        /// <param name="bundles"></param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/content/home")
                .Include(
                "~/jspm_packages/github/twbs/bootstrap@3.3.7/css/bootstrap.css",
                "~/Content/font-awesome.css",
                "~/Content/login.css"));

            bundles.Add(new StyleBundle("~/content/dashboard")
                .Include(
                "~/jspm_packages/github/twbs/bootstrap@3.3.7/css/bootstrap.css",
                "~/Content/font-awesome.css",
                "~/jspm_packages/github/rstacruz/nprogress@0.2.0/nprogress.css",
                "~/jspm_packages/github/malihu/malihu-custom-scrollbar-plugin@3.1.5/jquery.mCustomScrollbar.css",
                "~/Content/dashboard-custom.css")); 

            BundleTable.EnableOptimizations = true;
        }
    }
}