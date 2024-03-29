using Sales.AppServices.Core;
using Sales.AppServices.DTOs.Venta;

namespace Sales.AppServices.Contract
{
    public interface IVentaService : IService<VentaPostDTO, VentaPutDTO>
    {
        Task<ServiceResult> GetByVendedor(int id);
    }
}
