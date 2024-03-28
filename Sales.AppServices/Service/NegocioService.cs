using Microsoft.Extensions.Logging;
using Sales.AppServices.Contract;
using Sales.AppServices.Core;
using Sales.AppServices.DTOs;
using Sales.Domain.Entites;
using Sales.Infraestructure.Interfaces;

namespace Sales.AppServices.Service
{
    public class NegocioService : INegocioService
    {
        private readonly INegocioDb _negocioDb;
        private readonly ILogger<NegocioService> _logger;

        public NegocioService(INegocioDb negocioDb, ILogger<NegocioService> logger)
        {
            _negocioDb = negocioDb;
            _logger = logger;
        }

        public async Task<ServiceResult> GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = await _negocioDb.GetAll();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los negocios";
                this._logger.LogError($"Error: {ex.Message}", ex.ToString());
            }

            return result;
        }

        public async Task<ServiceResult> GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = await _negocioDb.GetById(id);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el negocio";
                this._logger.LogError($"Error: {ex.Message}", ex.ToString());
            }

            return result;
        }

        public async Task<ServiceResult> Save(NegocioPostDTO entity)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                await _negocioDb.Save(new Negocio()
                {
                    UrlLogo = entity.UrlLogo,
                    Nombre = entity.Nombre,
                    NombreLogo = entity.NombreLogo,
                    Correo = entity.Correo,
                    Direccion = entity.Direccion,
                    Telefono = entity.Telefono,
                    NumeroDocumento = entity.NumeroDocumento,
                    PorcentajeImpuesto = entity.PorcentajeImpuesto,
                    SimboloMoneda = entity.SimboloMoneda,
                    IdUsuarioCreacion = 1
                });

                result.Message = "Negocio agregado";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error agregado el negocio";
                this._logger.LogError($"Error: {ex.Message}", ex.ToString());
            }

            return result;
        }

        public async Task<ServiceResult> Update(int id, NegocioPutDTO entity)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var update = await _negocioDb.Update(new Negocio()
                {
                    Id = id,
                    UrlLogo = entity.UrlLogo,
                    Nombre = entity.Nombre,
                    NombreLogo = entity.NombreLogo,
                    Correo = entity.Correo,
                    Direccion = entity.Direccion,
                    Telefono = entity.Telefono,
                    NumeroDocumento = entity.NumeroDocumento,
                    PorcentajeImpuesto = entity.PorcentajeImpuesto,
                    SimboloMoneda = entity.SimboloMoneda,
                    IdUsuarioCreacion = 1,
                    FechaMod = DateTime.Now,
                    IdUsuarioMod = 1
                });

                result.Message = update.Message;

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error editando el negocio";
                this._logger.LogError($"Error: {ex.Message}", ex.ToString());
            }

            return result;
        }
    }
}
