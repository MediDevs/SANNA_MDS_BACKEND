using System.ComponentModel.DataAnnotations;

namespace MDS.Api.Models
{
    public class CreatePeriodoViewModel
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public bool Estado { get; set; }
    }

}
