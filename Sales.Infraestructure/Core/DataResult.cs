namespace Sales.Infraestructure.Core
{
    public class DataResult
    {
        public DataResult()
        {
            this.Success = true;
        }

        public bool Success { get; set; } = true;
        public string? Message { get; set; }
    }
}
