using Sales.AppServices.DTOs.Negocio;

namespace Sales.AppServices.Contract
{
    public interface INegocioService : IService<NegocioPostDTO, NegocioPutDTO>
    {
    }
}
