namespace Sales.Domain.Core
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            this.EsActivo = true;
            this.FechaRegistro = DateTime.Now;
            this.FechaMod = null;
            this.IdUsuarioMod = null;
            this.IdUsuarioElimino = null;
            this.FechaElimino = null;
            this.Eliminado = false;
        }

        public bool EsActivo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public DateTime? FechaMod { get; set; }
        public int? IdUsuarioMod { get; set; }
        public int? IdUsuarioElimino { get; set; }
        public DateTime? FechaElimino { get; set; }
        public bool Eliminado { get; set; }
    }
}
