using Microsoft.Extensions.Logging;
using Sales.AppServices.Contract;
using Sales.AppServices.Core;
using Sales.AppServices.DTOs.DetalleVenta;
using Sales.Domain.Entites;
using Sales.Infraestructure.Dao;
using Sales.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.AppServices.Service
{
    public class DetalleVentaService : IDetalleVentaService
    {
        private readonly IDetalleVentaDb _detalleVentaDb;
        private readonly ILogger<DetalleVentaService> _logger;

        public DetalleVentaService(IDetalleVentaDb detalleVentaDb, ILogger<DetalleVentaService> logger)
        {
            _detalleVentaDb = detalleVentaDb;
            _logger = logger;
        }

        public async Task<ServiceResult> GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = await _detalleVentaDb.GetAll();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los detalles de las ventas";
                this._logger.LogError($"Error: {ex.Message}", ex.ToString());
            }

            return result;
        }

        public async Task<ServiceResult> GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = await _detalleVentaDb.GetById(id);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el detalle de la venta";
                this._logger.LogError($"Error: {ex.Message}", ex.ToString());
            }

            return result;
        }

        public async Task<ServiceResult> Save(DetalleVentaPostDTO entity)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                await _detalleVentaDb.Save(new DetalleVenta()
                {
                    Cantidad = entity.Cantidad,
                    CategoriaProducto = entity.CategoriaProducto,
                    MarcaProducto = entity.MarcaProducto,
                    DescripcionProducto = entity.DescripcionProducto,
                    Precio = entity.Precio,
                    Total = entity.Total
                });

                result.Message = "Detalle venta agregado";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error agregado el detalle venta";
                this._logger.LogError($"Error: {ex.Message}", ex.ToString());
            }

            return result;
        }

        public async Task<ServiceResult> Update(int id, DetalleVentaPutDTO entity)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                await _detalleVentaDb.Save(new DetalleVenta()
                {
                    Cantidad = entity.Cantidad,
                    CategoriaProducto = entity.CategoriaProducto,
                    MarcaProducto = entity.MarcaProducto,
                    DescripcionProducto = entity.DescripcionProducto,
                    Precio = entity.Precio,
                    Total = entity.Total
                });

                result.Message = "Detalle venta editado";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error editando el detalle venta";
                this._logger.LogError($"Error: {ex.Message}", ex.ToString());
            }

            return result;
        }
    }
}
