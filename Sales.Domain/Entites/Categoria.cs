using Sales.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace Sales.Domain.Entites
{
    public class Categoria : BaseEntity
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Descripcion { get; set; } = null!;
    }
}
