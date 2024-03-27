using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sales.Domain.Entites;
using Sales.Infraestructure.Context;
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
    }
}
