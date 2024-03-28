using Microsoft.Extensions.Logging;
using Sales.AppServices.Contract;
using Sales.AppServices.Core;
using Sales.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.AppServices.Service
{
    public class VentaService : IVentaService
    {
        private readonly IVentaDb _ventaDb;
        private readonly ILogger<VentaService> _logger;

        public VentaService(IVentaDb ventaDb, ILogger<VentaService> logger)
        {
            _ventaDb = ventaDb;
            _logger = logger;
        }

        public async Task<ServiceResult> GetByVendedor(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this._ventaDb.GetByVendedor(id);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo las ventas";
                this._logger.LogError($"Error: {ex.Message}", ex.ToString());
                //result.Message = $"Error obteniendo el departamento. {ex.Message}";
            }
            return result;
        }
    }
}
