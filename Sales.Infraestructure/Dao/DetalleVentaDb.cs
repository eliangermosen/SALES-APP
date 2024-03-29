using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sales.Domain.Entites;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.Dao
{
    public class DetalleVentaDb : DaoBase<DetalleVenta>, IDetalleVentaDb
    {
        private readonly SalesContext _salesContext;
        private readonly ILogger<DetalleVentaDb> _logger;
        private readonly IConfiguration _configuration;
        public DetalleVentaDb(SalesContext context,
                                ILogger<DetalleVentaDb> logger,
                                IConfiguration configuration) : base(context)
        {
            this._salesContext = context;
            this._logger = logger;
            this._configuration = configuration;
        }

        public override async Task<List<DetalleVenta>> GetAll()
        {
            List<DetalleVenta> listDetalleVenta = new List<DetalleVenta>();

            try
            {
                listDetalleVenta = await (from detalles in _salesContext.DetalleVenta
                                          join venta in _salesContext.Venta
                                            on detalles.IdVenta equals venta.Id
                                          //join producto in _salesContext.Producto
                                          //  on detalles.IdProducto equals producto.Id
                                          //where producto.Eliminado == false
                                          select new DetalleVenta()
                                          {
                                              MarcaProducto = detalles.MarcaProducto,
                                              DescripcionProducto = detalles.DescripcionProducto,
                                              CategoriaProducto = detalles.CategoriaProducto,
                                              Cantidad = detalles.Cantidad,
                                              Precio = detalles.Precio,
                                              Total = detalles.Total,
                                              Venta = new Venta()
                                              {
                                                  CocumentoCliente = venta.CocumentoCliente,
                                                  NombreCliente = venta.NombreCliente,
                                                  NumeroVenta = venta.NumeroVenta,
                                                  SubTotal = venta.SubTotal,
                                                  ImpuestoTotal = venta.ImpuestoTotal,
                                                  Total = venta.Total
                                              }
                                          })
                                          .ToListAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error cargando los detalles de las ventas.", ex.ToString());
            }

            return listDetalleVenta;
        }

        public override async Task<DetalleVenta> GetById(int id)
        {
            DetalleVenta detallesVenta = new DetalleVenta();

            try
            {
                detallesVenta = await(from detalles in _salesContext.DetalleVenta
                                         join venta in _salesContext.Venta
                                           on detalles.IdVenta equals venta.Id
                                         select new DetalleVenta()
                                         {
                                             MarcaProducto = detalles.MarcaProducto,
                                             DescripcionProducto = detalles.DescripcionProducto,
                                             CategoriaProducto = detalles.CategoriaProducto,
                                             Cantidad = detalles.Cantidad,
                                             Precio = detalles.Precio,
                                             Total = detalles.Total,
                                             Venta = new Venta()
                                             {
                                                 CocumentoCliente = venta.CocumentoCliente,
                                                 NombreCliente = venta.NombreCliente,
                                                 NumeroVenta = venta.NumeroVenta,
                                                 SubTotal = venta.SubTotal,
                                                 ImpuestoTotal = venta.ImpuestoTotal,
                                                 Total = venta.Total
                                             }
                                         })
                                         .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error cargando el detalle de la venta.", ex.ToString());
            }

            return detallesVenta;
        }

        public override async Task<DataResult> Save(DetalleVenta entity)
        {
            DataResult dataResult = new DataResult();

            try
            {
                await base.Save(entity);
                dataResult.Message = "Detalle Venta guardado";
            }
            catch (Exception ex)
            {
                dataResult.Message = this._configuration["DetalleVentaMessage:ErrorSave"];
                dataResult.Success = false;
                this._logger.LogError(dataResult.Message, ex.ToString());
            }

            return dataResult;
        }

        public override async Task<DataResult> Update(DetalleVenta entity)
        {
            DataResult result = new DataResult();

            try
            {
                DetalleVenta detalleVentaUpdate = await base.GetById(entity.Id);

                detalleVentaUpdate.MarcaProducto = entity.MarcaProducto;
                detalleVentaUpdate.DescripcionProducto = entity.DescripcionProducto;
                detalleVentaUpdate.CategoriaProducto = entity.CategoriaProducto;
                detalleVentaUpdate.Cantidad = entity.Cantidad;
                detalleVentaUpdate.Precio = entity.Precio;
                detalleVentaUpdate.Total = entity.Total;

                await base.Update(detalleVentaUpdate);
                await base.Commit();
                result.Message = "Detalle venta editado";
            }
            catch (Exception ex)
            {
                result.Message = this._configuration["DetalleVentaMessage:ErrorUpdate"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
