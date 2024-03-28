using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sales.Domain.Entites;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Exceptions;
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
                return await base.GetEntitiesWithFilters(neg => !neg.Eliminado );
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error cargando los negocios.", ex.ToString());
            }

            return listaNegocio;
        }

        public override async Task<Negocio> GetById(int id)
        {
            return await base.GetById(id);
        }

        public override async Task<DataResult> Save(Negocio entity)
        {
            DataResult result = new DataResult();

            try
            {
                if (base.Exist(neg => neg.Nombre == entity.Nombre))
                    throw new NegocioException(this._configuration["NegocioMessage:NameDuplicate"]);

                await base.Save(entity);
            }
            catch (Exception ex)
            {
                result.Message = this._configuration["NegocioMessage:ErrorSave"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public override async Task<DataResult> Update(Negocio entity)
        {
            DataResult result = new DataResult();
            
            try
            {

                Negocio negocioToUpdate = await base.GetById(entity.Id);

                negocioToUpdate.FechaMod = entity.FechaMod;
                negocioToUpdate.IdUsuarioMod = entity.IdUsuarioMod;
                negocioToUpdate.Nombre = entity.Nombre;
                negocioToUpdate.NombreLogo = entity.NombreLogo;
                negocioToUpdate.UrlLogo = entity.UrlLogo;
                negocioToUpdate.Correo = entity.Correo;
                negocioToUpdate.Direccion = entity.Direccion;
                negocioToUpdate.Telefono = entity.Telefono;
                negocioToUpdate.NumeroDocumento = entity.NumeroDocumento;
                negocioToUpdate.PorcentajeImpuesto = entity.PorcentajeImpuesto;
                negocioToUpdate.SimboloMoneda = entity.SimboloMoneda;


                await base.Update(negocioToUpdate);
                await base.Commit();
                result.Message = "Negocio editado";
            }
            catch (Exception ex)
            {

                result.Message = this._configuration["NegocioMessage:ErrorUpdate"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
