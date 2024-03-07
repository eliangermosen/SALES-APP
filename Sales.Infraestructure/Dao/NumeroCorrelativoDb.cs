using Sales.Domain.Entites;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.Dao
{
    public class NumeroCorrelativoDb : DaoBase<NumeroCorrelativo>, INumeroCorrelativoDb
    {
        private readonly SalesContext _salesContext;

        public NumeroCorrelativoDb(SalesContext context) : base(context)
        {
            this._salesContext = context;
        }
    }
}
