using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.AppServices.DTOs.Negocio
{
    public class NegocioGetDTO
    {
        public int Id { get; set; }
        [MaxLength(500)]
        public string? UrlLogo { get; set; }
        [MaxLength(100)]
        public string? NombreLogo { get; set; }
        [MaxLength(50)]
        public string? NumeroDocumento { get; set; }
        [MaxLength(50)]
        public string? Nombre { get; set; }
        [MaxLength(50)]
        public string? Correo { get; set; }
        [MaxLength(50)]
        public string? Direccion { get; set; }
        [MaxLength(50)]
        public string? Telefono { get; set; }
    }
}
