using System.Web;
using System.Web.Optimization;

namespace Quiron.LojaVirtual.Web.V2
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        // For more information on SmartMenu, visit http://www.smartmenus.org/
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/css").Include(
                "~/css/*.css"
                ));
            bundles.Add(new ScriptBundle("~/js").Include(
                "~/js/jquery.js",
                "~/js/bootstrap.js"
                ));
            bundles.Add(new StyleBundle("~/Content/startmenu").Include(
                "~/Content/sm-core-css.css",
                "~/Content/sm-mint/sm-mint.css"
                ));
            bundles.Add(new ScriptBundle("~/Scripts/startmenu").Include(
                "~/js/jquery.navgoco.js",
                "~/Scripts/jquery.smartmenus.js"
                ));
            bundles.Add(new ScriptBundle("~/Scripts/jsprojetos").Include(
                "~/Scripts/menu.js"
                ));
            BundleTable.EnableOptimizations = false;
        }
    }
}
