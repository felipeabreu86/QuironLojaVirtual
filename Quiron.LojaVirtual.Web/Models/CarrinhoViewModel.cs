using Quiron.LojaVirtual.Dominio.Entidades;

namespace Quiron.LojaVirtual.Web.Models
{
    /// <summary>
    ///     A ViewModel permite modelar várias entidades a partir de um ou mais modelos em um único objeto
    /// </summary>
    public class CarrinhoViewModel
    {
        public Carrinho Carrinho    { get; set; }
        public string ReturnUrl     { get; set; }
    }
}