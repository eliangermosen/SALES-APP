using Sales.Domain.Entites;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.Dao
{
    public class ConfiguracionDb : DaoBase<Configuracion>, IConfiguracionDb
    {
        private readonly SalesContext _salesContext;
        public ConfiguracionDb(SalesContext context) : base(context)
        {
            this._salesContext = context;
        }

        public override DataResult Save(Configuracion entity)
        {
            DataResult result = new DataResult();
            // logica para almacenar
            return result;
            //return base.Save(entity);
        }
    }
}
