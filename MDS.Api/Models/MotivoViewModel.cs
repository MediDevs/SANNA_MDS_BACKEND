using System.ComponentModel.DataAnnotations;

namespace MDS.Api.Models
{
    public class CreateMotivoViewModel
    {
        [Required]
        public long NMOT_TIPO_ATENCION { get; set; }
        [Required]
        public long NMOT_TIPO_PASE { get; set; }
        [Required]
        public string SMOT_DESCRIPCION { get; set; }
        [Required]
        public Boolean FMOT_SKILL { get; set; }
        public int NMOT_USUARIO_CREACION { get; set; }
    }
    public class UpdateMotivoViewModel
    {
        [Required]
        public long CMOT_ID { get; set; }
        [Required]
        public long NMOT_TIPO_ATENCION { get; set; }
        [Required]
        public long NMOT_TIPO_PASE { get; set; }
        [Required]
        public string SMOT_DESCRIPCION { get; set; }
        [Required]
        public Boolean FMOT_SKILL { get; set; }
        public int NMOT_USUARIO_MODIFICACION { get; set; }
    }
    public class DeleteMotivoViewModel
    {
        [Required]
        public long CMOT_ID { get; set; }
    }
}
