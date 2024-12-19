namespace MDS.Api.Models
{
    public class CreateSedeTrasladoViewModel
    {
        public string? ruc { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string referencia { get; set; }
        public string cod_ubigeo { get; set; }
        public int usuario_creacion { get; set; }
    }

    public class UpdateSedeTrasladoViewModel
    {
        public long id { get; set; }
        public string? ruc { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string referencia { get; set; }
        public string cod_ubigeo { get; set; }
        public int usuario_modificacion { get; set; }
    }
}
