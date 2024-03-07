using Sales.Domain.Entites;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.Dao
{
    public class NegocioDb : DaoBase<Negocio>, INegocioDb
    {
        private readonly SalesContext _salesContext;

        public NegocioDb(SalesContext context) : base(context)
        {
            this._salesContext = context;
        }
    }
}
