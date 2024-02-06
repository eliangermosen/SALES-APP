using Sales.Domain.Entites;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.Dao
{
    public class CategoriaDb : ICategoriaDb
    {
        public bool Exist(string name)
        {
            throw new NotImplementedException();
        }

        public List<Categoria> GetAll()
        {
            throw new NotImplementedException();
        }

        public Categoria GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        DataResult IDaoBase<Categoria>.Save(Categoria entity)
        {
            throw new NotImplementedException();
        }
    }
}
