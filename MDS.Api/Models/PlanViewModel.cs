using System.ComponentModel.DataAnnotations;

namespace MDS.Api.Models
{
    public class CreatePlanViewModel
    {
        [Required]
        public string SPLA_NOMBRE { get; set; }
        public Boolean FPLA_ESTADO { get; set; }
        public int NPLA_USUARIO_CREACION { get; set; }
    }
    public class UpdatePlanViewModel
    {
        [Required]
        public long CPLA_ID { get; set; }
        [Required]
        public string SPLA_NOMBRE { get; set; }
        public Boolean FPLA_ESTADO { get; set; }
        public int NPLA_USUARIO_MODIFICACION { get; set; }
    }
    public class DeletePlanViewModel
    {
        [Required]
        public long CPLA_ID { get; set; }
    }
}
