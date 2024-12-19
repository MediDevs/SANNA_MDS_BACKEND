using System.ComponentModel.DataAnnotations;

namespace MDS.Api.Models
{
    public class CreateMedicoParticularViewModel
    {
        [Required]
        public string SMED_DESCRIPCION { get; set; }
        [Required]
        public string SMED_TELEFONO { get; set; }
        [Required]
        public string SMED_EMAIL { get; set; }
        [Required]
        public string SMED_EMAIL_CULMINACION { get; set; }
        [Required]
        public bool FMED_ENVIAR_EMAIL { get; set; }
        [Required]
        public bool FMED_FLG_PROVEEDOR_DRMAS { get; set; }
        [Required]
        public string SMED_NOM_USU { get; set; }
        [Required]
        public bool FMED_FLG_VISIBLE_PROV_SEG_COVID { get; set; }
        [Required]
        public bool FMED_ESTADO { get; set; }
        [Required]
        public int NMED_USUARIO_CREACION { get; set; }
        [Required]
        public DateTime DMED_FECHA_CREACION { get; set; }
        [Required]
        public int NMED_USUARIO_MODIFICACION { get; set; }
        [Required]
        public DateTime DMED_FECHA_MODIFICACION { get; set; }

    }
}
