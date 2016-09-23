using Quiron.LojaVirtual.Web.Models;
using System;
using System.Text;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Helpers
{
    public static class PaginacaoHelpers
    {
        public static MvcHtmlString PageLinks (this HtmlHelper html, Paginacao paginacao, Func<int, string> paginaUrl)
        {
            StringBuilder resultado = new StringBuilder();

            for (int numeroPagina = 1; 
                numeroPagina <= paginacao.TotalPaginas; 
                numeroPagina++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", paginaUrl(numeroPagina));
                tag.InnerHtml = numeroPagina.ToString();
                tag.AddCssClass("btn btn-default");

                if (numeroPagina == paginacao.PaginaAtual)
                {
                    tag.AddCssClass("btn-primary");
                    tag.AddCssClass("selected");                    
                }

                resultado.Append(tag);
            }

            return MvcHtmlString.Create(resultado.ToString());
        }
    }
}