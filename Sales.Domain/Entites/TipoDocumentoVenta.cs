using Sales.Domain.Core;

namespace Sales.Domain.Entites
{
    public class TipoDocumentoVenta : BaseEntity
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
    }
}
