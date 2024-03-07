using Sales.Domain.Entites;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.Dao
{
    public class ProductoDb : DaoBase<Producto>, IProductoDb
    {
        private readonly SalesContext _salesContext;

        public ProductoDb(SalesContext context) : base(context)
        {
            this._salesContext = context;
        }
    }
}
