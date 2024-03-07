using Sales.Domain.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Domain.Entites
{
    public class Usuario : BaseEntity
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string? Nombre { get; set; }
        [MaxLength(50)]
        public string? Correo { get; set; }
        [MaxLength(50)]
        public string? Telefono { get; set; }
        [ForeignKey("Rol")]
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
