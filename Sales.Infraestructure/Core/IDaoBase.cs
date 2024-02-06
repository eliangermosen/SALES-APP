using Sales.Domain.Core;

namespace Sales.Infraestructure.Core
{
    public interface IDaoBase<TEntity> //where TEntity : BaseEntity
    {
        DataResult Save(TEntity entity);
        List<TEntity> GetAll();
        TEntity GetById(int entityId);
        bool Exist(string name);
    }
}
