using System.ComponentModel.DataAnnotations;

namespace Sales.AppServices.DTOs.Venta
{
    public class VentaPutDTO
    {
        //public int Id { get; set; }
        [MaxLength(6)]
        public string? NumeroVenta { get; set; }
        public int? IdTipoDocumentoVenta { get; set; }
        //public int? IdUsuario { get; set; }
        [MaxLength(10)]
        public string? CocumentoCliente { get; set; }
        [MaxLength(20)]
        public string? NombreCliente { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? ImpuestoTotal { get; set; }
        //public decimal? Total { get; set; }
        //public DateTime FechaRegistro { get; set; }
        //public int IdUsuarioCreacion { get; set; }
    }
}
