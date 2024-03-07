using Microsoft.EntityFrameworkCore;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Core;

namespace Sales.Infraestructure.Dao
{
    public abstract class DaoBase<TEntity> : IDaoBase<TEntity> where TEntity : class
    {
        private readonly SalesContext _context;
        private DbSet<TEntity> _entities;

        public DaoBase(SalesContext context)
        {
            this._context = context;
            this._entities = context.Set<TEntity>();
        }

        public virtual bool Exist(Func<TEntity, bool> filter)
        {
            return this._entities.Any(filter);
        }

        public virtual List<TEntity> GetAll()
        {
            return this._entities.ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return this._entities.Find(id);
        }

        public virtual List<TEntity> GetEntitiesWithFilters(Func<TEntity, bool> filter)
        {
            throw new NotImplementedException();
        }

        public virtual DataResult Save(TEntity entity)
        {
            DataResult result = new DataResult();

            this._entities.Add(entity);

            result.Success = true;

            return result;
        }

        public virtual DataResult Update(TEntity entity)
        {
            DataResult result = new DataResult();

            this._entities.Update(entity);

            result.Success = true;

            return result;
        }

        public virtual int Commit()
        {
            return this._context.SaveChanges();
        }
    }
}
