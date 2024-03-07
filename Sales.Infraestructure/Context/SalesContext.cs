using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entites;

namespace Sales.Infraestructure.Context
{
    public class SalesContext : DbContext
    {
        public SalesContext(DbContextOptions<SalesContext> options) : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<>
        //}

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Configuracion> Configuracion { get; set; }
        public DbSet<DetalleVenta> DetalleVenta { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Negocio> Negocio { get; set; }
        public DbSet<NumeroCorrelativo> NumeroCorrelativo { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<RolMenu> RolMenu { get; set; }
        public DbSet<TipoDocumentoVenta> TipoDocumentoVenta { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Venta> Venta { get; set; }
    }
}
