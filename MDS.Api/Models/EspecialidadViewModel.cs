using System.ComponentModel.DataAnnotations;

namespace MDS.Api.Models
{
    public class CreateEspecialidadViewModel
    {
        [Required]
        public string? SESP_NOMBRE { get; set; }
        [Required]
        public string? SESP_GRAL_PED { get; set; }
        [Required]
        public string SESP_COD_ESPR { get; set; }
        [Required]
        public string SESP_TIPO_PROF_RIMAC { get; set; }
        [Required]
        public string SESP_ABREVIATURA { get; set; }
        [Required]
        public int SESP_ID_HHMM { get; set; }
        [Required]
        public string SESP_SITEDS { get; set; }
        [Required]
        public string SESP_COD_CARACT_FACT { get; set; }
        [Required]
        public bool FESP_MOSTRAR_APP_MAD { get; set; }
        [Required]
        public int NESP_USUARIO_CREACION { get; set; }
        [Required]
        public DateTime DESP_FECHA_CREACION { get; set; }
        [Required]
        public int NESP_USUARIO_MODIFICACION { get; set; }
        [Required]
        public DateTime DESP_FECHA_MODIFICACION { get; set; }


    }
}
