using System.Web.Mvc;
using System.Web.Routing;

namespace Quiron.LojaVirtual.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Inicializar as rotas via Atributos
            routes.MapMvcAttributeRoutes();

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // rotas criadas para gerar uma URL amigável durante a paginação e categorização dos produtos

            // Rota 1 - /

            routes.MapRoute(
                null, 
                "", 
                new { controller = "Vitrine", action = "ListaProdutos", categoria = (string)null, pagina = 1 }
            );

            // Rota 2 - /PaginaX
            routes.MapRoute(
                null,
                "Pagina{pagina}",
                new { controller = "Vitrine", action = "ListaProdutos", categoria = (string)null }, 
                new { pagina = @"\d+" }
            );

            // Rota 3 - /Categoria
            routes.MapRoute(
                null,
                "{categoria}", 
                new { controller = "Vitrine", action = "ListaProdutos", pagina = 1 }
            );

            // Rota 4 /Categoria/PaginaX
            routes.MapRoute(
                null,
                "{categoria}/Pagina{pagina}", 
                new { controller = "Vitrine", action = "ListaProdutos" }, 
                new { pagina = @"\d+" }
            );

            // Rota 5 - /ObterImagem/produtoId
            //routes.MapRoute(
            //    "ObterImagem",
            //    "Vitrine/ObterImagem/{produtoId}",
            //    new {controller = "Vitrine", action = "ObterImagem", produtoId = UrlParameter.Optional});

            // Default
            routes.MapRoute(
                name: null,
                url: "{controller}/{action}"
            );
        }
    }
}
