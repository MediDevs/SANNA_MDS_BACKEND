namespace MDS.Api.Models
{
    public class CreateSeguimientoViewModel
    {
        public string cod_historia_clinica { get; set; }
        public int id_servicio { get; set; }
        public string observacion { get; set; }
        public string usuario { get; set; }
        public string? usuario_creacion_pg { get; set; }
    }
}