using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Repositorio;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Quiron.LojaVirtual.Web.Areas.Administrativo.Controllers
{
    [Authorize]
    public class ProdutoController : Controller
    {
        private ProdutosRepositorio _repositorio;

        public ProdutoController()
        {
            _repositorio = new ProdutosRepositorio();
        }

        public ActionResult Index()
        {
            var produtos = _repositorio.Produtos;
            return View(produtos);
        }

        public ViewResult Alterar(int produtoId)
        {
            Produto produto = _repositorio.Produtos
                .FirstOrDefault(p => p.ProdutoId == produtoId);

            ViewBag.tipoDeAlteracao = "Alterar";
            return View(produto);
        }

        [HttpPost]
        public ActionResult Alterar(Produto produto, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    produto.ImagemMimeType = image.ContentType;
                    produto.Imagem = new byte[image.ContentLength];
                    image.InputStream.Read(produto.Imagem, 0, image.ContentLength);
                }

                _repositorio.SalvarOuAtualizar(produto);

                TempData["mensagem"] = string.Format("{0} foi salvo com sucesso", produto.Nome);

                return RedirectToAction("Index");
            }

            ViewBag.tipoDeAlteracao = "Alterar";
            return View(produto);
        }

        public ViewResult NovoProduto() 
        {
            ViewBag.tipoDeAlteracao = "Novo Produto";
            return View("Alterar", new Produto());
        }

        [HttpPost]
        public JsonResult Excluir(int produtoId)
        {
            Produto prod = _repositorio.Excluir(produtoId);
            string mensagem = string.Empty;

            if (prod != null)
                mensagem = string.Format("{0} excluído com sucesso,", prod.Nome);

            return Json(mensagem, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Produto", new { area = "Administrativo" });
        }

        public FileContentResult ObterImagem(int produtoId)
        {
            Produto produto = _repositorio.Produtos.FirstOrDefault(x => x.ProdutoId == produtoId);

            if (produto != null)
            {
                return File(produto.Imagem, produto.ImagemMimeType);
            }

            return null;
        }
	}
}