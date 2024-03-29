using Sales.Domain.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Domain.Entites
{
    public class RolMenu : BaseEntity
    {
        public int Id { get; set; }
        [ForeignKey("Rol")]
        public int? IdRol { get; set; }
        [ForeignKey("Menu")]
        public int? IdMenu { get; set; }
        public Rol? Rol { get; set; }
        public Menu? Menu { get; set; }
    }
}
