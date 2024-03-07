using Sales.Domain.Entites;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.Dao
{
    public class TipoDocumentoVentaDb : DaoBase<TipoDocumentoVenta>, ITipoDocumentoVentaDb
    {
        private readonly SalesContext _salesContext;

        public TipoDocumentoVentaDb(SalesContext context) : base(context)
        {
            this._salesContext = context;
        }
    }
}
