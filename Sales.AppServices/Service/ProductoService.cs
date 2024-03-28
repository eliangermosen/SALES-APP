using Microsoft.Extensions.Logging;
using Sales.AppServices.Contract;
using Sales.AppServices.Core;
using Sales.Infraestructure.Interfaces;

namespace Sales.AppServices.Service
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoDb _productoDb;
        private readonly ILogger<VentaService> _logger;

        public ProductoService(IProductoDb productoDb, ILogger<VentaService> logger)
        {
            _productoDb = productoDb;
            _logger = logger;
        }

        public async Task<ServiceResult> GetProductsByCategories(int category)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this._productoDb.GetProductsByCategories(category);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los productos";
                this._logger.LogError($"Error: {ex.Message}", ex.ToString());
            }
            return result;
        }
    }
}
