using Quiron.LojaVirtual.Dominio.Repositorio;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;

namespace Quiron.LojaVirtual.Web.V2.Controllers
{
    public class MenuController : Controller
    {
        private MenuRepositorio _repositorio;

        /// <summary>
        ///     Retorna um JSON com os atributos da entidade Categoria
        ///     Um dos atributos é a descrição configurada para SEO
        /// </summary>
        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterEsportes()
        {
            _repositorio = new MenuRepositorio();
            var cat = _repositorio.ObterCategorias();
            var categorias = from c in cat
                             select new
                             {
                                 c.CategoriaDescricao,
                                 CategoriaDescricaoSeo = c.CategoriaDescricao.ToSeoUrl(),
                                 c.CategoriaCodigo
                             };
            return Json(categorias, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        ///     Retorna um JSON com os atributos da view MarcaVitrine
        ///     Um dos atributos é a descrição configurada para SEO
        /// </summary>
        public JsonResult ObterMarcas()
        {
            _repositorio = new MenuRepositorio();
            var listaMarcas = _repositorio.ObterMarcas();
            var marcas = from m in listaMarcas
                         select new
                         {
                             m.MarcaDescricao,
                             MarcaDescricaoSeo = m.MarcaDescricao.ToSeoUrl(),
                             m.MarcaCodigo
                         };
            return Json(marcas, JsonRequestBehavior.AllowGet);
        }
    }
}