using Sales.Domain.Entites;
using Sales.Infraestructure.Core;

namespace Sales.Infraestructure.Interfaces
{
    internal interface INegocioDb : IDaoBase<Negocio>
    {
    }
}
