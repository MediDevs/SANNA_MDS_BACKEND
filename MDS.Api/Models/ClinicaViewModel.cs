using System.ComponentModel.DataAnnotations;

namespace MDS.Api.Models
{
    public class CreateClinicaViewModel
    {
        [Required]
        public string clinica { get; set; }
        [Required]
        public string ubigeo { get; set; }
        [Required]
        public string direccion { get; set; }
        [Required]
        public string telefono { get; set; }
        public string? anexo { get; set; }
        [Required]
        public string afiliado { get; set; }
        //[Required]
        public int plan_huerfano_ilimitado { get; set; }
        public int estado { get; set; }
        public int usuario_creacion { get; set; }
    }
    public class UpdateClinicaViewModel
    {
        public string pk_pg { get; set; }
        [Required]
        public long id_clinica { get; set; }
        [Required]
        public string clinica { get; set; }
        [Required]
        public string ubigeo { get; set; }
        [Required]
        public string direccion { get; set; }
        [Required]
        public string telefono { get; set; }
        public string? anexo { get; set; }
        [Required]
        public string afiliado { get; set; }
        //[Required]
        public int plan_huerfano_ilimitado { get; set; }
        public int estado { get; set; }
        public int usuario_modificacion { get; set; }
    }
    public class DeleteClinicaViewModel
    {
        [Required]
        public long id_clinica { get; set; }
    }
}
