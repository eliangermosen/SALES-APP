using Sales.Domain.Entites;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.Dao
{
    public class RolDb : DaoBase<Rol>, IRolDb
    {
        private readonly SalesContext _salesContext;

        public RolDb(SalesContext context) : base(context)
        {
            this._salesContext = context;
        }
    }
}
