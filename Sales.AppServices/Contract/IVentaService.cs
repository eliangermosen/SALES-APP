using Sales.AppServices.Core;

namespace Sales.AppServices.Contract
{
    public interface IVentaService
    {
        Task<ServiceResult> GetByVendedor(int id);
    }
}
