using Sales.Domain.Entites;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.Dao
{
    public class DetalleVentaDb : DaoBase<DetalleVenta>, IDetalleVentaDb
    {
        private readonly SalesContext _salesContext;
        public DetalleVentaDb(SalesContext context) : base(context)
        {
            this._salesContext = context;
        }
    }
}
