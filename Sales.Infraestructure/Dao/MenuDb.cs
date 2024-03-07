using Sales.Domain.Entites;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.Dao
{
    public class MenuDb : DaoBase<Menu>, IMenuDb
    {
        private readonly SalesContext _salesContext;
        public MenuDb(SalesContext context) : base(context)
        {
            this._salesContext = context;
        }
    }
}
