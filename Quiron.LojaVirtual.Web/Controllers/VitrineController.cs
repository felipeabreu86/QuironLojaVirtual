using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutosRepositorio _produtosRepositorio = null;
        public const int produtosPorPagina = 12;

        /// <summary>
        ///     Construtor default
        /// </summary>
        public VitrineController()
        {
            _produtosRepositorio = new ProdutosRepositorio();
        }

        /// <summary>
        ///     Responsável por listar os produtos randomicamente
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        public ActionResult ListaProdutos(string categoria)
        {
            ProdutosViewModel viewModel = new ProdutosViewModel();
            var rnd = new Random();
            if (categoria != null)
            {
                viewModel.Produtos = _produtosRepositorio.Produtos
                    .Where(p => p.Categoria == categoria)
                    .OrderBy(p => rnd.Next())
                    .ToList();
            }
            else
            {
                viewModel.Produtos = _produtosRepositorio.Produtos
                        .OrderBy(p => rnd.Next())
                        .Take(produtosPorPagina)
                        .ToList();
            }            
            return View(viewModel);
        }

        /// <summary>
        ///     Responsável por recuperar todos os Produtos e filtrá-los a partir do n° da página
        ///     escolhida e da definição da quantidade de produtos por página.
        /// </summary>
        //public ActionResult ListaProdutos(string categoria, int pagina = 1)
        //{
        //    ProdutosViewModel viewModel = new ProdutosViewModel()
        //    {
        //        Produtos = 
        //            _produtosRepositorio.Produtos
        //            .Where(p => categoria == null || p.Categoria == categoria)
        //            .OrderBy(p => p.Descricao)
        //            .Skip((pagina - 1) * produtosPorPagina) // Ignora os n primeiros elementos da lista
        //            .Take(produtosPorPagina),               // Retorna os n primeiros elementos da lista
        //        Paginacao = new Paginacao() 
        //            { 
        //                PaginaAtual = pagina,
        //                ItensPorPagina = produtosPorPagina,
        //                ItensTotal = categoria == null ? 
        //                    _produtosRepositorio.Produtos.Count() : 
        //                    _produtosRepositorio.Produtos.Count(e => e.Categoria == categoria)
        //            },
        //        CategoriaAtual = categoria
        //    };            
        //    return View(viewModel);
        //}

        /// <summary>
        ///     Retorna a imagem dado o Id de um produto
        /// </summary>
        /// <param name="produtoId">Id do produto</param>
        /// <returns>Imagem do produto</returns>
        [Route("Vitrine/ObterImagem/{produtoId}")]
        public FileContentResult ObterImagem(int produtoId)
        {
            Produto produto = _produtosRepositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);
            if (produto != null)
            {
                return File(produto.Imagem, produto.ImagemMimeType);
            }
            return null;
        }

        /// <summary>
        ///     Retorna a view com o detalhamento do Produto passado como parâmetro (id)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("DetalhesProduto/{id}/{produto}")]
        public ViewResult Detalhes(int id)
        {
            Produto produto = _produtosRepositorio.ObterProduto(id);
            return View(produto);
        }
	}
}