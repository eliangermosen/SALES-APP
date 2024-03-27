using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infraestructure.Models
{
    public class ProductsByCategory
    {
        public int ProductoId { get; set; }
        public string? CodigoBarra { get; set; }
        public string? Marca { get; set; }
        public int? Stock { get; set; }
        public string? NombreCategoria { get; set;}
    }
}
