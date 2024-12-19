using System.ComponentModel.DataAnnotations;

namespace MDS.Api.Models
{
    public class CreatePersonaMadViewModel
    {
        public long id_documento { get; set; }
        public long id_pais { get; set; }
        public string numero_documento { get; set; }
        public string nombres { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        //public DateTime fecha_nacimiento { get; set; }
        public int genero { get; set; }
        //public string descripcion { get; set; }
        public string telefono_celular { get; set; }
        public bool estado { get; set; }
        public int usuario_creacion { get; set; }
        //public DateTime fecha_creacion { get; set; }
    }

    public class ActualizarPersonaMadViewModel
    {
        public long id_persona { get; set; }
        public long id_documento { get; set; }
        public long id_pais { get; set; }
        public string numero_documento { get; set; }
        public string nombres { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string email { get; set; }
        public int genero { get; set; }
        public string telefono_celular { get; set; }
        public bool estado { get; set; }
        public int usuario_modificacion { get; set; }
        public DateTime fecha_modificacion { get; set; }
    }
    
    public class CreatePersonaViewModel
    {
        //[Required]
        //public int? CPER_ID { get; set; }
        //[Required]
        public int? CPAI_IDPAIS { get; set; }
        //[Required]
        public int? CUBI_IDUBIGEO { get; set; }
        [Required]
        public string nombres { get; set; }
        [Required]
        public string apellido_paterno { get; set; }
        [Required]
        public string apellido_materno { get; set; }
        [Required]
        public string tipo_documento { get; set; }
        [Required]
        public string numero_documento { get; set; }
        //[Required]
        public DateTime fecha_nacimiento { get; set; }
        //[Required]
        public string sexo { get; set; }
        //[Required]
        public string? SPER_DEPARTAMENTO { get; set; }
        //[Required]
        public string? SPER_PROVINCIA { get; set; }
        //[Required]
        public string? SPER_DISTRITO { get; set; }
        //[Required]
        public string? SPER_DIRECCION { get; set; }
        //[Required]
        public string? SPER_EMAIL1 { get; set; }
        //[Required]
        public string? SPER_EMAIL2 { get; set; }
        //[Required]
        public string? SPER_TELEFONO_CASA { get; set; }
        //[Required]
        public string celular { get; set; }
        //[Required]
        public string? SPER_TELEFONO_CORPORATIVO { get; set; }
        //[Required]
        public bool? FPER_ESTADO { get; set; }
        //[Required]
        public int usuario_creacion { get; set; }
        //[Required]
        public DateTime? DPER_FECHA_CREACION { get; set; }
        //[Required]
        public int? NPER_USUARIO_MODIFICACION { get; set; }
        //[Required]
        public DateTime? DPER_FECHA_MODIFICACION { get; set; }
    }
}
