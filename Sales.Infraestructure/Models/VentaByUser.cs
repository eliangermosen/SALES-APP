using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infraestructure.Models
{
    public class VentaByUser
    {
        public string Vendedor { get; set; } = null!;
        public int CantidadVentas { get; set; }
    }
}
