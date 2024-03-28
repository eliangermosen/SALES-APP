using Sales.AppServices.DTOs;

namespace Sales.AppServices.Contract
{
    public interface INegocioService : IService<NegocioPostDTO, NegocioPutDTO>
    {
    }
}
