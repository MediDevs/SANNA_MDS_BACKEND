namespace MDS.Infrastructure.Helper
{
    public class WebServiceResponse
    {
        public bool Success { get; set; } = false;
        public string Datetime { get; set; } = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        public string Message { get; set; }
        public int AffectedRows { get; set; }
        public string PrimaryKeyGenerado { get; set; }
    }
}
