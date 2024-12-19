using System.ComponentModel.DataAnnotations;

namespace MDS.Api.Models
{
    public class CreateDireccionViewModel
    {

        [Required]
        public long id_persona { get; set; }
        public string id_ubigeo { get; set; }
        public int id_tipo_direccion { get; set; }
        [Required]
        public string descripcion { get; set; }
        public string anexo { get; set; }
        [Required]
        public string celular { get; set; }
        public string telefono_fijo { get; set; }
        public string nro_mz_lote { get; set; }
        public string urbanizacion { get; set; }
        public string referencia { get; set; }
        public string dpto_interior { get; set; }
        public int usuario_creacion { get; set; }
        public char? SDIR_LONGITUD { get; set; }
        public char? SDIR_LATITUD { get; set; }
    }
    
    public class UpdateDireccionViewModel
    {
        [Required]
        public long id_direccion { get; set; }

        [Required]
        public long id_persona { get; set; }
        public string id_ubigeo { get; set; }
        public int id_tipo_direccion { get; set; }
        [Required]
        public string descripcion { get; set; }

        public string anexo { get; set; }
        [Required]
        public string celular { get; set; }
        public string telefono_fijo { get; set; }
        public string nro_mz_lote { get; set; }
        public string urbanizacion { get; set; }
        public string referencia { get; set; }
        public string dpto_interior { get; set; }
        public int usuario_modificacion { get; set; }
        public char? SDIR_LONGITUD { get; set; }
        public char? SDIR_LATITUD { get; set; }
    }
    public class DeleteDireccionViewModel
    {
        [Required]
        public long CDIR_ID { get; set; }
        [Required]
        public long CPER_ID { get; set; }
    }
}
