using System.ComponentModel.DataAnnotations;

namespace MDS.Api.Models
{
    public class LoginUsuarioViewModel
    {
        [Required(ErrorMessage = "El usuario es requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Debe tener mínimo 3 caracteres y máximo 50 caracteres")]
        [DataType(DataType.Text)]
        public string usuario { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [DataType(DataType.Password)]
        public string contrasena { get; set; }
    }

    public class UpdateUsuarioViewModel
    {
        public int? id_persona { get; set; }
        public int? id_usuario { get; set; }
        public DateTime? fecha_nacimiento { get; set; }
        public int? sexo { get; set; }
        public string contrasena { get; set; }
        public string? email { get; set; }
        public string? telefonoMovil { get; set; }
        public string usuario_modificacion { get; set; }
    }

    public class CreateUsuarioViewModel
    {
        public int? id_persona { get; set; }
        public int? tipo_documento { get; set; }
        public string? numero_documento { get; set; }
        public DateTime? fecha_nacimiento { get; set; }
        public string? nombres { get; set; }
        public string? apellidoPaterno { get; set; }
        public string? apellidoMaterno { get; set; }
        public int? sexo { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string? email { get; set; }
        public string? telefonoMovil { get; set; }
        public string usuario_creacion { get; set; }
    }

    public class ActivarUsuarioViewModel
    {
        public int id_persona { get; set; }
        public string usuario_creacion { get; set; }
    }

    public class DesactivarUsuarioViewModel
    {
        public int id_persona { get; set; }
        public string usuario_creacion { get; set; }
    }

    public class ActivarDobleFactorUsuarioViewModel
    {
        public int id_usuario { get; set; }
    }
}
