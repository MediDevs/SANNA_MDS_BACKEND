namespace MDS.Dto
{
    public class UsuarioDto
    {
        public string? pk_pg { get; set; }
        public int codigoUsuario { get; set; }
        public string? ip { get; set; }
        public int? tipo_documento { get; set; }
        public string? numero_documento { get; set; }
        public DateTime? fecha_nacimiento { get; set; }
        public int? sexo { get; set; }
        public string? usuario { get; set; }
        public string? contrasena { get; set; }
        public string? nombres { get; set; }
        public string? apellidoPaterno { get; set; }
        public string? apellidoMaterno { get; set; }
        public string? email { get; set; }
        public string? telefonoMovil { get; set; }
        public string? latitud { get; set; }
        public string? longitud { get; set; }
        public bool? estado { get; set; }
        public bool? dobleFactor { get; set; }
        public bool? emailConfirmacion { get; set; }
        public int? intentosFallidos { get; set; }
        public int? id_usuario { get; set; }
        public int? id_persona { get; set; }
        public string? usuario_creacion { get; set; }
        public string? usuario_modificacion{ get; set; }
    }

    public class PersonasSinUsuarioDto
    {
        public int id_persona { get; set; }
        public string numero_documento { get; set; }
        public string nombres { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
    }
}
