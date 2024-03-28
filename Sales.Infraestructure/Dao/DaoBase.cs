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

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await this._entities.ToListAsync();
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await this._entities.FindAsync(id);
        }

        public async virtual Task<List<TEntity>> GetEntitiesWithFilters(Func<TEntity, bool> filter)
        {
            return this._entities.Where(filter).ToList();
        }

        public virtual async Task<DataResult> Save(TEntity entity)
        {
            DataResult result = new DataResult();

            this._entities.Add(entity);

            await this.Commit();

            result.Success = true;

            return result;
        }

        public virtual async Task<DataResult> Update(TEntity entity)
        {
            DataResult result = new DataResult();

            this._entities.Update(entity);

            //this.Commit();

            result.Success = true;

            return result;
        }

        public async virtual Task<int> Commit()
        {
            return await this._context.SaveChangesAsync();
        }

    }
}
