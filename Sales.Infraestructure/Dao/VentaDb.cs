using Sales.Domain.Entites;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.Dao
{
    public class VentaDb : DaoBase<Venta>, IVentaDb
    {
        private readonly SalesContext _salesContext;

        public VentaDb(SalesContext context) : base(context)
        {
            this._salesContext = context;
        }
    }
}
