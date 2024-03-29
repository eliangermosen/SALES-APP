using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Domain.Entites
{
    public class DetalleVenta
    {
        public int Id { get; set; }
        [ForeignKey("Venta")]
        public int? IdVenta { get; set; }
        public int? IdProducto { get; set; }
        [MaxLength(100)]
        public string? MarcaProducto { get; set; }
        [MaxLength(100)]
        public string? DescripcionProducto { get; set; }
        [MaxLength(100)]
        public string? CategoriaProducto { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Total { get; set; }
        public Venta? Venta { get; set;}
    }
}
