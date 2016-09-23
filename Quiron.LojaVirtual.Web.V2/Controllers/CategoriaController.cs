using Quiron.LojaVirtual.Dominio.Repositorio;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;

namespace Quiron.LojaVirtual.Web.V2.Controllers
{
    public class CategoriaController : Controller
    {
        private CategoriaRepositorio _repositorio;

        /// <summary>
        ///     Retorna um JSON com os atributos da entidade Categoria
        ///     Um dos atributos é a descrição configurada para SEO
        /// </summary>
        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterEsportes()
        {
            _repositorio = new CategoriaRepositorio();
            var categorias = from c in _repositorio.ObterCategorias()
                             select new
                             {
                                 c.CategoriaDescricao,
                                 CategoriaDescricaoSeo = c.CategoriaDescricao.ToSeoUrl(),
                                 c.CategoriaCodigo
                             };
            return Json(categorias, JsonRequestBehavior.AllowGet);
        }
    }
}