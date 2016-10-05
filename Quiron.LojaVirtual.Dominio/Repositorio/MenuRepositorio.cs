using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Entidades.Vitrine;
using System.Collections.Generic;
using System.Linq;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class MenuRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        /// <summary>
        ///     Obter todas as Categorias cadastradas no BD
        /// </summary>
        public IEnumerable<Categoria> ObterCategorias()
        {
            return _context.Categorias.OrderBy(c => c.CategoriaDescricao);
        }

        /// <summary>
        ///     Obter algumas marcas pela View MarcaVitrine do BD
        /// </summary>
        public IEnumerable<MarcaVitrine> ObterMarcas()
        {
            return _context.MarcaVitrine.OrderBy(m => m.MarcaDescricao);
        }

        /// <summary>
        ///     Retorna os Clubes Nacionais ordenados pela descrição
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ClubesNacionais> ObterClubesNacionais()
        {
            return _context.ClubesNacionais.OrderBy(n => n.LinhaDescricao);
        }

        /// <summary>
        ///     Retornar os clubes internacionais ordenados pela descrição
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ClubesInternacionais> ObterClubesInternacionais()
        {
            return _context.ClubesInternacionais.OrderBy(i => i.LinhaDescricao);
        }

        /// <summary>
        ///     Retornar os gêneros ordenados pela descrição
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Genero> ObterGeneros()
        {
            return _context.Generos.OrderBy(g => g.GeneroDescricao);
        }
    }
}
