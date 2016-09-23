using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quiron.LojaVirtual.Web.Models
{
    public class Paginacao
    {
        public int ItensTotal       { get; set; }
        public int ItensPorPagina   { get; set; }
        public int PaginaAtual      { get; set; }

        public int TotalPaginas
        {
            // Retorna o menor valor integral que é maior que ou igual ao número decimal encontrado
            get { return (int)Math.Ceiling((decimal)ItensTotal / ItensPorPagina); } 
        }
    }
}