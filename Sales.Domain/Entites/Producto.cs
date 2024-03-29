using Sales.Domain.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Domain.Entites
{
    public class Producto : BaseEntity
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string? CodigoBarra { get; set; }
        [MaxLength(50)]
        public string? Marca { get; set; }
        [MaxLength(100)]
        public string? Descripcion { get; set; }
        [ForeignKey("Categoria")]
        public int? IdCategoria { get; set; }
        public int? Stock { get; set; }
        [MaxLength(500)]
        public string? UrlImagen { get; set; }
        [MaxLength(100)]
        public string? NombreImagen { get; set; }
        public decimal? Price { get; set; }
        public Categoria? Categoria { get; set; }
    }
}
