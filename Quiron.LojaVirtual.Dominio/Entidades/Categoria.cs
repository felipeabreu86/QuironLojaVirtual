using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string CategoriaCodigo { get; set; }
        public string CategoriaDescricao { get; set; }
    }
}
