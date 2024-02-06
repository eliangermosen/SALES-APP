using System.ComponentModel.DataAnnotations;

namespace Sales.Domain.Entites
{
    public class Configuracion
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string? Descripcion { get; set; }
        [MaxLength(50)]
        public string? Propiedad { get; set; }
        [MaxLength(60)]
        public string? Valor { get; set; }
    }
}
