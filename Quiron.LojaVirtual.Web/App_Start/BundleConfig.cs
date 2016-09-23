using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Quiron.LojaVirtual.Web
{
    /// <summary>
    ///     Responsável por registrar os Bundles e comprimir os arquivos css e js
    ///     Necessário registrar no Global.asax
    /// </summary>
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Scripts Bundle
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-2.2.3.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.min.js"
                ));
            
            // Styles Bundle
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/Site.css",
                "~/Content/bootstrap.min.css",
                "~/Content/bootstrap-theme.css",
                "~/Content/ErroEstilo.css"
                ));

            // Habilitar/Desabilitar Optimizations
            BundleTable.EnableOptimizations = false;
        }
    }
}