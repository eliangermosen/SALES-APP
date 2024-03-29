using Sales.AppServices.DTOs.DetalleVenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.AppServices.Contract
{
    public interface IDetalleVentaService : IService<DetalleVentaPostDTO, DetalleVentaPutDTO>
    {
    }
}
