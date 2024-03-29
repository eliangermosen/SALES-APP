using Microsoft.Extensions.Logging;
using Sales.AppServices.Contract;
using Sales.AppServices.Core;
using Sales.AppServices.DTOs.Venta;
using Sales.Domain.Entites;
using Sales.Infraestructure.Interfaces;

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

        public async Task<ServiceResult> GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = await _ventaDb.GetAll();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo las ventas";
                this._logger.LogError($"Error: {ex.Message}", ex.ToString());
            }

            return result;
        }

        public async Task<ServiceResult> GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = await _ventaDb.GetById(id);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo la venta";
                this._logger.LogError($"Error: {ex.Message}", ex.ToString());
            }

            return result;
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
            }
            return result;
        }

        public async Task<ServiceResult> Save(VentaPostDTO entity)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var post = await _ventaDb.Save(new Venta()
                {
                    NumeroVenta = entity.NumeroVenta,
                    CocumentoCliente = entity.CocumentoCliente,
                    NombreCliente = entity.NombreCliente,
                    SubTotal = entity.SubTotal,
                    ImpuestoTotal = entity.ImpuestoTotal,
                    Total = entity.SubTotal + entity.ImpuestoTotal,
                    IdTipoDocumentoVenta = entity.IdTipoDocumentoVenta,
                    IdUsuario = entity.IdUsuarioCreacion,
                    IdUsuarioCreacion = entity.IdUsuarioCreacion,
                    FechaRegistro = DateTime.Now
                });

                result.Message = post.Message;
                result.Success = post.Success;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error agregando la venta";
                this._logger.LogError($"Error: {ex.Message}", ex.ToString());
            }

            return result;
        }

        public async Task<ServiceResult> Update(int id, VentaPutDTO entity)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var update = await _ventaDb.Update(new Venta()
                {
                    Id = id,
                    NumeroVenta = entity.NumeroVenta,
                    CocumentoCliente = entity.CocumentoCliente,
                    NombreCliente = entity.NombreCliente,
                    SubTotal = entity.SubTotal,
                    ImpuestoTotal = entity.ImpuestoTotal,
                    Total = entity.SubTotal + entity.ImpuestoTotal,
                    IdTipoDocumentoVenta = entity.IdTipoDocumentoVenta,
                });

                result.Message = update.Message;
                result.Success = update.Success;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error editando el negocio";
                this._logger.LogError($"Error: {ex.Message}", ex.ToString());
            }

            return result;
        }
    }
}
