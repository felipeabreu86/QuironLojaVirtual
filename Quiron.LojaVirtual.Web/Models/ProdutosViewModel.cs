using Quiron.LojaVirtual.Dominio.Entidades;
using System.Collections.Generic;

namespace Quiron.LojaVirtual.Web.Models
{
    /// <summary>
    ///     A ViewModel permite modelar várias entidades a partir de um ou mais modelos em um único objeto
    /// </summary>
    public class ProdutosViewModel
    {
        public IEnumerable<Produto> Produtos    { get; set; }
        public Paginacao Paginacao              { get; set; }
        public string CategoriaAtual            { get; set; }
    }
}