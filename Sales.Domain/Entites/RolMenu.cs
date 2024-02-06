using Sales.Domain.Core;

namespace Sales.Domain.Entites
{
    public class RolMenu : BaseEntity
    {
        public int Id { get; set; }
        public int? IdRol { get; set; }
        public int? IdMenu { get; set; }
        public Rol? Rol { get; set; }
        public Menu? Menu { get; set; }
    }
}
