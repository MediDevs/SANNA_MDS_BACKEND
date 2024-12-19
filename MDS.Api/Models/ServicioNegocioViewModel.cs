using System.ComponentModel.DataAnnotations;

namespace MDS.Api.Models
{
    public class CreateServicioNegocioViewModel
    {
        [Required]
        public string SSER_NOMBRE { get; set; }
        [Required]
        public string SSER_GRUPO { get; set; }
        [Required]
        public int NSER_UNI_NEGOCIO { get; set; }
        [Required]
        public int NSER_TIPO_OPERACION_PRECISA { get; set; }
        [Required]
        public string SSER_ONBASE_SUBTIPO_ATENCION { get; set; }
        [Required]
        public int NSER_UNCCSCL { get; set; }
        [Required]
        public string SSER_NEGOCIO_FACTURACION { get; set; }
        [Required]
        public int NSER_PROGRAMA_APP { get; set; }
        [Required]
        public bool FSER_ESTADO { get; set; }
        [Required]
        public int NSER_USUARIO_CREACION { get; set; }
        [Required]
        public DateTime DSER_FECHA_CREACION { get; set; }
        [Required]
        public int NSER_USUARIO_MODIFICACION { get; set; }
        [Required]
        public DateTime DSER_FECHA_MODIFICACION { get; set; }

    }
}
