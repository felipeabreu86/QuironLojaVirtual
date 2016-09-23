using System.ComponentModel.DataAnnotations;

namespace Quiron.LojaVirtual.Dominio.Entidades.Vitrine
{
    /// <summary>
    ///     Esta classe representa a View MarcaVitrine do BD
    /// </summary>
    public class MarcaVitrine
    {
        [Key]
        public string MarcaCodigo { get; set; }
        public string MarcaDescricao { get; set; }
    }
}
