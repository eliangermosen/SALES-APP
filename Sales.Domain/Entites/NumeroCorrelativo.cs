namespace Sales.Domain.Entites
{
    public class NumeroCorrelativo
    {
        public int Id { get; set; }
        public int? UltimoNumero { get; set; }
        public int? CantidadDigitos { get; set; }
        public string? Gestion {  get; set; }
        public DateTime? FechaAutorizacion { get; set; }
    }
}
