using Sales.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace Sales.Domain.Entites
{
    public class Rol : BaseEntity
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string? Descripcion { get; set; }
    }
}
