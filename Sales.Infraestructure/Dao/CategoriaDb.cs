using Sales.Domain.Entites;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.Dao
{
    public class CategoriaDb : DaoBase<Categoria>, ICategoriaDb
    {
        private readonly SalesContext _salesContext;
        public CategoriaDb(SalesContext context) : base(context)
        {
            this._salesContext = context;
        }
        public override Task<DataResult> Save(Categoria entity)
        {
            //con base llamo a la clase pricipal o padre en este caso DaoBase
            return base.Save(entity);
        }
        public override async Task<List<Categoria>> GetAll()
        {
            return await base.GetEntitiesWithFilters(cat => !cat.Eliminado);
        }
    }
}
