using Sales.Domain.Entites;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.Dao
{
    public class RolMenuDb : DaoBase<RolMenu>, IRolMenuDb
    {
        private readonly SalesContext _salesContext;

        public RolMenuDb(SalesContext context) : base(context)
        {
            this._salesContext = context;
        }
    }
}
