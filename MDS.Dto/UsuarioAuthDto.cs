namespace MDS.Dto
{
    public class UsuarioAuthDto
    {
        public UsuarioAuthDto()
        {
            token = string.Empty;
        }
        public int id { get; set; }
        public string? pk_pg { get; set; }
        public string? usuario { get; set; }
        public string? nombres { get; set; }
        public string? apellidoPaterno { get; set; }
        public string? apellidoMaterno { get; set; }
        public string? email { get; set; }
        public string? telefonoMovil { get; set; }
        public string? token { get; set; }
        public bool esAutentificado { get; set; }
        public bool? dobleFactor { get; set; }
        public string? foto { get; set; }
        public List<AppClaimDto> claims { get; set; }
        public List<object> menu { get; set; }
    }
}
