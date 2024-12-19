using System.ComponentModel.DataAnnotations;

namespace MDS.Api.Models
{
    public class CreateDetalleServicioNegocioViewModel
    {
        [Required]
        public int CDSN_IDSERVICIO { get; set; }
        [Required]
        public string? SDSN_NOMBRE { get; set; }
        [Required]
        public bool FDSN_ESTADO { get; set; }
        [Required]
        public int NDSN_USUARIO_CREACION { get; set; }
        [Required]
        public DateTime DDSN_FECHA_CREACION { get; set; }
        [Required]
        public int NDSN_USUARIO_MODIFICACION { get; set; }
        [Required]
        public DateTime DDSN_FECHA_MODIFICACION { get; set; }
    }
}
