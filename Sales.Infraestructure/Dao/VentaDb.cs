using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sales.Domain.Entites;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Interfaces;
using Sales.Infraestructure.Models;

namespace Sales.Infraestructure.Dao
{
    public class VentaDb : DaoBase<Venta>, IVentaDb
    {
        private readonly SalesContext _salesContext;
        private readonly ILogger<VentaDb> _logger;
        private readonly IConfiguration _configuration;

        public VentaDb(SalesContext context, 
                        ILogger<VentaDb> logger, 
                        IConfiguration configuration) : base(context)
        {
            this._salesContext = context;
            this._logger = logger;
            this._configuration = configuration;
        }

        public VentaByUser GetByVendedor(int id)
        {
            VentaByUser ventaByUser = new VentaByUser();

            try
            {
                ventaByUser = (from user in _salesContext.Usuario
                               join sale in _salesContext.Venta
                               on user.Id equals sale.IdUsuario
                               where user.Eliminado == false
                               && sale.IdUsuario == id
                               //group new { user.Nombre } by user.Nombre
                               group user by user.Id
                               into myGroup
                               orderby myGroup.Count() descending
                               select new VentaByUser()
                               {
                                   Vendedor = myGroup.FirstOrDefault().Nombre,
                                   CantidadVentas = myGroup.Count()
                               }).FirstOrDefault();
                return ventaByUser;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public override async Task<List<Venta>> GetAll()
        {
            List<Venta> listVenta = new List<Venta>();

            try
            {
                listVenta = await (from venta in _salesContext.Venta
                             join tipoDocumento in _salesContext.TipoDocumentoVenta
                                on venta.IdTipoDocumentoVenta equals tipoDocumento.Id
                             join user in _salesContext.Usuario
                                on venta.IdUsuario equals user.Id
                             where user.Eliminado == false
                             select new Venta()
                             {
                                 NumeroVenta = venta.NumeroVenta,
                                 CocumentoCliente = venta.CocumentoCliente,
                                 NombreCliente = venta.NombreCliente,
                                 SubTotal = venta.SubTotal,
                                 ImpuestoTotal = venta.ImpuestoTotal,
                                 Total = venta.Total,
                                 TipoDocumentoVenta = new TipoDocumentoVenta()
                                 {
                                     Descripcion = tipoDocumento.Descripcion
                                 },
                                 Usuario = new Usuario()
                                 {
                                     Nombre = user.Nombre,
                                     Telefono = user.Telefono,
                                     Correo = user.Correo,
                                 }
                             })
                             .ToListAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error cargando las ventas.", ex.ToString());
            }

            return listVenta;
        }

        public override async Task<Venta> GetById(int id)
        {
            Venta sale = new Venta();

            try
            {
                sale = await (from venta in _salesContext.Venta
                               join tipoDocumento in _salesContext.TipoDocumentoVenta
                                    on venta.IdTipoDocumentoVenta equals tipoDocumento.Id
                                join user in _salesContext.Usuario
                                    on venta.IdUsuario equals user.Id
                                where user.Eliminado == false
                                select new Venta()
                                {
                                    NumeroVenta = venta.NumeroVenta,
                                    CocumentoCliente = venta.CocumentoCliente,
                                    NombreCliente = venta.NombreCliente,
                                    SubTotal = venta.SubTotal,
                                    ImpuestoTotal = venta.ImpuestoTotal,
                                    Total = venta.Total,
                                    TipoDocumentoVenta = new TipoDocumentoVenta()
                                    {
                                        Descripcion = tipoDocumento.Descripcion
                                    },
                                    Usuario = new Usuario()
                                    {
                                        Nombre = user.Nombre,
                                        Telefono = user.Telefono,
                                        Correo = user.Correo,
                                    }
                                })
                            .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error cargando la venta.", ex.ToString());
            }

            return sale;
        }

        public override async Task<DataResult> Save(Venta entity)
        {
            DataResult dataResult = new DataResult();

            try
            {
                await base.Save(entity);
                dataResult.Message = "Venta guardada";
            }
            catch (Exception ex)
            {
                dataResult.Message = this._configuration["VentaMessage:ErrorSave"];
                dataResult.Success = false;
                this._logger.LogError(dataResult.Message, ex.ToString());
            }

            return dataResult;
        }
    }
}
