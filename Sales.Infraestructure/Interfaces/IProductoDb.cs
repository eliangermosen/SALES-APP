using Sales.Domain.Entites;
using Sales.Infraestructure.Core;

namespace Sales.Infraestructure.Interfaces
{
    public interface IProductoDb : IDaoBase<Producto>
    {
    }
}
