using Quiron.LojaVirtual.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class ProdutosRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        /// <summary>
        ///     Retorna todos os produtos cadastrados no Banco de Dados
        /// </summary>
        public IEnumerable<Produto> Produtos
        {
            get { return _context.Produtos; }
        }

        /// <summary>
        ///     Salva ou Atualiza um produto no Banco de Dados
        /// </summary>
        /// <param name="produto">Produto a ser salvo ou atualizado</param>
        public void SalvarOuAtualizar(Produto produto)
        {
            if (produto.ProdutoId == 0)
            {
                _context.Produtos.Add(produto);
            }
            else
            {
                Produto p = _context.Produtos.Find(produto.ProdutoId);

                if (p != null)
                {
                    p.Nome = produto.Nome;
                    p.Categoria = produto.Categoria;
                    p.Descricao = produto.Descricao;
                    p.Preco = produto.Preco;
                    p.Imagem = produto.Imagem;
                    p.ImagemMimeType = produto.ImagemMimeType;
                }
            }

            _context.SaveChanges();
        }

        /// <summary>
        ///     Exclui um produto do Banco de Dados
        /// </summary>
        /// <param name="produto">Produto a ser excluído</param>
        /// <returns>Retorna o produto excluído</returns>
        public Produto Excluir(int produtoId)
        {
            Produto p = _context.Produtos.Find(produtoId);

            if (p != null)
            {
                _context.Produtos.Remove(p);
                _context.SaveChanges();
            }

            return p;
        }

        /// <summary>
        ///     Responsável por obter um produto pelo ID
        /// </summary>
        /// <param name="id">ID do Produto</param>
        /// <returns></returns>
        public Produto ObterProduto(int id)
        {
            return _context.Produtos.Single(p => p.ProdutoId == id);
        }
    }
}
