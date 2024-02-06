using Sales.Domain.Entites;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.Dao
{
    public class ConfiguracionDb : IConfiguracionDb
    {
        public bool Exist(string name)
        {
            throw new NotImplementedException();
        }

        public List<Configuracion> GetAll()
        {
            throw new NotImplementedException();
        }

        public Configuracion GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public DataResult Save(Configuracion entity)
        {
            throw new NotImplementedException();
        }
    }
}
