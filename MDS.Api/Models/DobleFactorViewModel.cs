using System.ComponentModel.DataAnnotations;

namespace MDS.Api.Models
{
    public class GeneraDobleFactorViewModel
    {
        [Required(ErrorMessage = "El correo es requerido")]
        [DataType(DataType.Text)]
        public string email { get; set; }
    }

    public class ValidateDobleFactorViewModel
    {
        [Required(ErrorMessage = "El correo es requerido")]
        [DataType(DataType.Text)]
        public string email { get; set; }

        [Required(ErrorMessage = "El código es requerido")]
        [DataType(DataType.Text)]
        public string? key { get; set; }
    }
}
