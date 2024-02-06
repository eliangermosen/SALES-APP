using Sales.Domain.Entites;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.Dao
{
    public class NumeroCorrelativoDb : INumeroCorrelativoDb
    {
        public bool Exist(string name)
        {
            throw new NotImplementedException();
        }

        public List<NumeroCorrelativo> GetAll()
        {
            throw new NotImplementedException();
        }

        public NumeroCorrelativo GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public DataResult Save(NumeroCorrelativo entity)
        {
            throw new NotImplementedException();
        }
    }
}
