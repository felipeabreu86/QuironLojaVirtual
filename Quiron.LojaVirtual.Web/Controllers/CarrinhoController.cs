using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly ProdutosRepositorio _produtosRepositorio;

        public CarrinhoController()
        {
            _produtosRepositorio = new ProdutosRepositorio();
        }

        /// <summary>
        ///     Carrega a tela do Carrinho de Compras
        /// </summary>
        /// <param name="returnUrl">URL para retorno</param>
        public ViewResult Index(Carrinho carrinho, string returnUrl)
        {
            return View(new CarrinhoViewModel
            {
                Carrinho = carrinho,
                ReturnUrl = returnUrl
            });
        }

        /// <summary>
        ///     Carrega a Partial com o resumo das compras a ser exibido no topo da página
        /// </summary>
        public PartialViewResult Resumo(Carrinho carrinho)
        {
            return PartialView(carrinho);
        }

        /// <summary>
        ///     Adiciona um item no carrinho
        /// </summary>
        /// <param name="produtoId">ID do Produto</param>
        /// <param name="returnUrl">URL para retorno</param>
        /// <returns></returns>
        public RedirectToRouteResult Adicionar(Carrinho carrinho, int produtoId, int quantidade, string returnUrl)
        {
            Produto produto = _produtosRepositorio
                              .Produtos
                              .FirstOrDefault(p => p.ProdutoId == produtoId);

            if (produto != null)
                carrinho.AdicionarItem(produto, quantidade);
         
            return RedirectToAction("Index", new { returnUrl });
        }

        /// <summary>
        ///     Remover item do carrinho
        /// </summary>
        /// <param name="produtoId">ID do Produto</param>
        /// <param name="returnUrl">URL para retorno</param>
        public RedirectToRouteResult Remover(Carrinho carrinho, int produtoId, string returnUrl)
        {
            Produto produto = _produtosRepositorio
                              .Produtos
                              .FirstOrDefault(p => p.ProdutoId == produtoId);

            if (produto != null)
                carrinho.RemoverItem(produto);

            return RedirectToAction("Index", new { returnUrl });
        }

        /// <summary>
        ///     Carrega a View com o formulário para fechar o pedido
        /// </summary>
        public ViewResult FecharPedido()
        {
            return View(new Pedido());
        }

        /// <summary>
        ///     Fecha o Pedido do cliente
        /// </summary>
        /// <param name="pedido">Pedido do Cliente</param>
        [HttpPost]
        public ViewResult FecharPedido(Carrinho carrinho, Pedido pedido)
        {
            EmailConfiguracoes email = new EmailConfiguracoes() 
            {
                EscreverArquivo = bool.Parse(ConfigurationManager.AppSettings["Email.EscreverArquivo"] ?? "false")
            };

            EmailPedido emailPedido = new EmailPedido(email);

            if (!carrinho.ItensCarrinho.Any())
                ModelState.AddModelError("ErroCarrinhoVazio", "Não foi possível concluir o pedido, o carrinho está vazio!");
            
            if (ModelState.IsValid)
            {
                emailPedido.ProcessarPedido(carrinho, pedido);
                carrinho.LimparCarrinho();
                return View("PedidoConcluido");
            }
            else
            {
                return View(pedido);
            }
        }

        /// <summary>
        ///     Carrega a página de pedido concluído com sucesso
        /// </summary>
        public ViewResult PedidoConcluido()
        {
            return View();
        }
	}
}