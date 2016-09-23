using Quiron.LojaVirtual.Dominio.Entidades;
using System;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Infraestrutura
{
    /// <summary>
    ///     ModelBinder customizado para a classe Carrinho
    ///     É necessário adicionar este ModelBinder no Global.asax
    /// </summary>
    public class CarrinhoModelBinder : IModelBinder
    {
        private const string SessionKey = "Carrinho";

        // IModelBinder - Interface define o método BindModel
        public Object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // Obtenho o carrinho da sessão
            Carrinho carrinho = null;

            if (controllerContext.HttpContext.Session != null)
                carrinho = (Carrinho)controllerContext.HttpContext.Session[SessionKey];
            
            // Criar o carrinho se não tenho a sessão
            if (carrinho == null)
            {
                carrinho = new Carrinho();

                if (controllerContext.HttpContext.Session != null)
                    controllerContext.HttpContext.Session[SessionKey] = carrinho;
            }

            // Retornar o Carrinho
            return carrinho;
        }
    }
}