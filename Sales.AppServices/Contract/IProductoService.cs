using Sales.AppServices.Core;

namespace Sales.AppServices.Contract
{
    public interface IProductoService
    {
        Task<ServiceResult> GetProductsByCategories(int category);
    }
}
