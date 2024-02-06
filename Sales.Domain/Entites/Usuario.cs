using Sales.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace Sales.Domain.Entites
{
    public class Usuario : BaseEntity
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }
        [MaxLength(50)]
        public string? Correo { get; set; }
        [MaxLength(50)]
        public string? Telefono { get; set; }
        public int IdRol { get; set; }
        [MaxLength(500)]
        public string? UrlFoto { get; set; }
        [MaxLength(100)]
        public string? NombreFoto { get; set; }
        [MaxLength(100)]
        public string? Clave { get; set; }
        public Rol? Rol { get; set; }
    }
}
