using Sales.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace Sales.Domain.Entites
{
    public class Menu : BaseEntity
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Descripcion { get; set; } = null!;
        public int? IdMenuPadre { get; set; }
        [MaxLength(30)]
        public string? Icono { get; set; }
        [MaxLength(30)]
        public string? Controlador { get; set; }
        [MaxLength(30)]
        public string? Paginacion { get; set; }
    }
}
