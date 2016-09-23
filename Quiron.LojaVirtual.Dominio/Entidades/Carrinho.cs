using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class Carrinho
    {
        private readonly List<ItemCarrinho> _itemCarrinho = new List<ItemCarrinho>();

        // Adicionar
        public void AdicionarItem(Produto produto, int quantidade)
        {
            ItemCarrinho item = _itemCarrinho.FirstOrDefault(p => p.Produto.ProdutoId == produto.ProdutoId);

            if (item == null)
                _itemCarrinho.Add(new ItemCarrinho(produto, quantidade));
            else
                item.Quantidade = quantidade; 
        }

        // Remover
        public void RemoverItem(Produto produto)
        {
            _itemCarrinho.RemoveAll(p => p.Produto.ProdutoId == produto.ProdutoId);
        }

        // Obter o Valor Total
        public decimal ObterValorTotal()
        {
            return _itemCarrinho.Sum(p => p.Produto.Preco * p.Quantidade);
        }

        // Limpar o Carrinho
        public void LimparCarrinho()
        {
            _itemCarrinho.Clear();
        }

        // Itens do Carrinho
        public IEnumerable<ItemCarrinho> ItensCarrinho
        {
            get { return _itemCarrinho; }
        }
    }

    public class ItemCarrinho
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        
        public ItemCarrinho(Produto produto, int quantidade)
        {
            this.Produto = produto;
            this.Quantidade = quantidade;
        }
    }
}
