using Sales.Domain.Entites;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Models;

namespace Sales.Infraestructure.Interfaces
{
    public interface IVentaDb : IDaoBase<Venta>
    {
        VentaByUser GetByVendedor(int id);
    }
}
