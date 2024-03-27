using Sales.Domain.Entites;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Models;

namespace Sales.Infraestructure.Interfaces
{
    public interface IProductoDb : IDaoBase<Producto>
    {
        List<ProductsByCategory> GetProductsByCategories(int category);
    }
}
