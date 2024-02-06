using Sales.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace Sales.Domain.Entites
{
    public class Negocio
    {
        public Negocio()
        {
            this.FechaRegistro = DateTime.Now;
            this.FechaMod = null;
            this.IdUsuarioMod = null;
            this.IdUsuarioElimino = null;
            this.FechaElimino = null;
            this.Eliminado = false;
        }
        public int Id { get; set; }
        [MaxLength(500)]
        public string? UrlLogo { get; set; }
        [MaxLength(100)]
        public string? NombreLogo { get; set; }
        [MaxLength(50)]
        public string? NumeroDocumento { get; set; }
        [MaxLength(50)]
        public string? Nombre {  get; set; }
        [MaxLength(50)]
        public string? Correo { get; set; }
        [MaxLength(50)]
        public string? Direccion { get; set; }
        [MaxLength(50)]
        public string? Telefono { get; set; }
        public decimal? PorcentajeImpuesto { get; set; }
        public string? SimboloMoneda { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public DateTime? FechaMod { get; set; }
        public int? IdUsuarioMod { get; set; }
        public int? IdUsuarioElimino { get; set; }
        public DateTime? FechaElimino { get; set; }
        public bool Eliminado { get; set; }
    }
}
