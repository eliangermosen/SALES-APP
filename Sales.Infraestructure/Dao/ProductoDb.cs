using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sales.Domain.Entites;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Interfaces;
using Sales.Infraestructure.Models;

namespace Sales.Infraestructure.Dao
{
    public class ProductoDb : DaoBase<Producto>, IProductoDb
    {
        private readonly SalesContext _salesContext;
        private readonly ILogger<ProductoDb> _logger;
        private readonly IConfiguration _configuration;

        public ProductoDb(SalesContext context,
                        ILogger<ProductoDb> logger,
                        IConfiguration configuration) : base(context)
        {
            this._salesContext = context;
            this._logger = logger;
            _configuration = configuration;
        }

        public List<ProductsByCategory> GetProductsByCategories(int category)
        {
            List<ProductsByCategory> listProducts = new List<ProductsByCategory>();

            try
            {
                listProducts = (from producto in _salesContext.Producto
                                join categoria in _salesContext.Categoria 
                                on producto.IdCategoria equals categoria.Id
                                where producto.Eliminado == false
                                && categoria.Eliminado == false
                                && categoria.Id == category
                                orderby producto.FechaRegistro descending
                                select new ProductsByCategory()
                                {
                                    ProductoId = producto.Id,
                                    CodigoBarra = producto.CodigoBarra,
                                    Marca = producto.Marca,
                                    Stock = producto.Stock,
                                    NombreCategoria = categoria.Descripcion
                                }).ToList();
                return listProducts;
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error cargando los productos.", ex.ToString());
                throw;
            }
        }
    }
}
