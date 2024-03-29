using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.AppServices.DTOs.DetalleVenta
{
    public class DetalleVentaPutDTO
    {
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
    }
}
