using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sales.Domain.Entites;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.Dao
{
    public class NegocioDb : DaoBase<Negocio>, INegocioDb
    {
        private readonly SalesContext _salesContext;
        private readonly ILogger<NegocioDb> _logger;
        private readonly IConfiguration _configuration;

        public NegocioDb(SalesContext context,
                        ILogger<NegocioDb> logger,
                        IConfiguration configuration) : base(context)
        {
            this._salesContext = context;
            this._logger = logger;
            this._configuration = configuration;
        }

        public override async Task<List<Negocio>> GetAll()
        {
            List<Negocio> listaNegocio = new List<Negocio>();

            try
            {
                return await base.GetEntitiesWithFilters(neg => !neg.Eliminado);
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error cargando los negocios.", ex.ToString());

                throw;
            }
        }
    }
}
