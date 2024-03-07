using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sales.Domain.Entites;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Exceptions;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.Dao
{
    public class UsuarioDb : DaoBase<Usuario>, IUsuarioDb
    {
        private readonly SalesContext _salesContext;
        private readonly ILogger<UsuarioDb> _logger;
        private readonly IConfiguration _configuration;

        public UsuarioDb(SalesContext context,
                        ILogger<UsuarioDb> logger,
                        IConfiguration configuration) : base(context)
        {
            this._salesContext = context;
            this._logger = logger;
            this._configuration = configuration;
        }

        public override DataResult Save(Usuario entity)
        {
            DataResult result = new DataResult();

            try
            {
                if (base.Exist(user => user.Nombre == entity.Nombre))
                    throw new UsuarioException(this._configuration["UsuarioMessage:NameDuplicate"]);

                base.Save(entity);
                base.Commit();

            }
            catch (Exception ex)
            {
                result.Message = this._configuration["UsuarioMessage:ErrorSave"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public override DataResult Update(Usuario entity)
        {
            DataResult result = new DataResult();

            try
            {

                Usuario userToUpdate = base.GetById(entity.Id);

                userToUpdate.Nombre = entity.Nombre;
                userToUpdate.Telefono = entity.Telefono;
                userToUpdate.Correo = entity.Correo;
                userToUpdate.IdRol = entity.IdRol;
                userToUpdate.UrlFoto = entity.UrlFoto;
                userToUpdate.Clave = entity.Clave;
                userToUpdate.NombreFoto = entity.NombreFoto;
                userToUpdate.Clave = entity.Clave;

                userToUpdate.FechaMod = entity.FechaMod;
                userToUpdate.IdUsuarioMod = entity.IdUsuarioMod;
                userToUpdate.EsActivo = entity.EsActivo;

                base.Update(entity);
                base.Commit();
            }
            catch (Exception ex)
            {

                result.Message = this._configuration["UsuarioMessage:ErrorUpdate"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
