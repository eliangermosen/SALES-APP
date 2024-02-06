namespace Sales.AppServices.Core
{
    internal class ServiceResult
    {
        public string? Message { get; set; }
        public bool Success { get; set; }
        public dynamic? Data { get; set; }
    }
}
