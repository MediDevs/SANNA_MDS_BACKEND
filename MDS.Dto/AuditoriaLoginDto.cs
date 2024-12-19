using MDS.Dto.Resources;

namespace MDS.Dto
{
    public class AuditoriaLoginDto
    {
        public int codigoAuditoria { get; set; }
        public string? usuario { get; set; }
        public long? fecha { get; set; }
        public string? ip { get; set; }
        public string? origen { get; set; }
        public string? latitud { get; set; }
        public string? longitud { get; set; }
        public string? estado { get; set; }
        public int? idUsuario { get; set; }
        public string? descripcion { get; set; }
        public AuditoriaLoginResource AuditoriaLoginResource { get; set; }
    }
}
