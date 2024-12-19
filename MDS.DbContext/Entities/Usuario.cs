namespace MDS.DbContext.Entities
{
    public class Usuario
    {
        public string? SUSR_PK_POSTGRES { get; set; }
        public int CUSR_ID { get; set; }
        public int? CPER_ID { get; set; }
        public int? CTDO_ID { get; set; }
        public string? SPER_NUMERO_DOCUMENTO { get; set; }
        public string? SUSR_NOMBRE { get; set; }
        public string? SUSR_CONTRASENA { get; set; }
        public int? NPER_GENERO { get; set; }
        public string? SPER_NOMBRES { get; set; }
        public string? SPER_APELLIDO_PATERNO { get; set; }
        public string? SPER_APELLIDO_MATERNO { get; set; }
        public string? SUSR_EMAIL_CORP { get; set; }
        public string? SUSR_TLF_CELULAR_CORP { get; set; }
        public bool FUSR_DOBLE_FACTOR { get; set; }
        public bool FUSR_EMAIL_CONFIRMACION { get; set; }
        public int NUSR_INTENTOS_FALLIDOS { get; set; }
        public bool FUSR_ESTADO { get; set; }
        public int NUSR_USUARIO_CREACION { get; set; }
        public long DUSR_FECHA_CREACION { get; set; }
        public int NUSR_USUARIO_MODIFICACION { get; set; }
        public long DUSR_FECHA_MODIFICACION { get; set; }
        public DateTime DPER_FECHA_NACIMIENTO { get; set; }
    }

    public class Usuarios
    {
        public int codigoUsuario { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public int id_persona { get; set; }
        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string numero_documento { get; set; }
        public int CTDO_ID { get; set; }
        public int NPER_GENERO { get; set; }
        public string email { get; set; }
        public string telefonoMovil { get; set; }
        public Boolean estado { get; set; }
    }

    public class PersonasSinUsuario
    {
        public int id_persona { get; set; }
        public string numero_documento { get; set; }
        public string nombres { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
    }
}
