using System.ComponentModel.DataAnnotations;

namespace MDS.Api.Models
{
    public class CreateClienteViewModel
    {
        //[Required]
        public string? pk_pg { get; set; }
        public bool? FCLI_ESTADO { get; set; }
        [Required]
        public string nombre { get; set; }
        //[Required]
        public string? SCLI_DESCRIPCION { get; set; }
        //[Required]
        public string? SCLI_DIRECCION { get; set; }
        //[Required]
        public string? SCLI_DISTRITO { get; set; }
        [Required]
        public string ruc { get; set; }
        //[Required]
        public int? NCLI_DSCTO_PED { get; set; }
        //[Required]
        public decimal? NCLI_FACTOR_LAB { get; set; }
        //[Required]
        public int? NCLI_DSCTO_LAB { get; set; }
        //[Required]
        public decimal? NCLI_COSTO { get; set; }
        //[Required]
        public string? CCLI_CONV_EMP { get; set; }
        //[Required]
        public decimal? NCLI_COSTO_ALT { get; set; }
        //[Required]
        public string? SCLI_FLAG_TIPO { get; set; }
        //[Required]
        public bool? FCLI_ACTIVI_OPERACIONES { get; set; }
        //[Required]
        public decimal? NCLI_FACTOR_LAB_PROV { get; set; }
        //[Required]
        public bool? FCLI_ACTIVO_FACT { get; set; }
        //[Required]
        public int? NCLI_RELACIONADO { get; set; }
        //[Required]
        public bool? FCLI_ACTIVO_LAB { get; set; }
        //[Required]
        public bool? FCLI_ACTIVO_AMB { get; set; }
        //[Required]
        public bool? FCLI_CLIENTE_PLAYA { get; set; }
        //[Required]
        public string? SCLI_EMAIL { get; set; }
        //[Required]
        public string? SCLI_URBANIZACION { get; set; }
        //[Required]
        public int? NCLI_DIAS_PLAZO { get; set; }
        //[Required]
        public string? SCLI_COD_TIPO_DOC_ID { get; set; }
        //[Required]
        public string? SCLI_EMAIL_CON_COPIA { get; set; }
        //[Required]
        public string? SCLI_PERSONAL_CONTACTO { get; set; }
        //[Required]
        public string? SCLI_TLF_CONTACTO { get; set; }
        //[Required]
        public int? NCLI_ID_DOC_ID { get; set; }
        //[Required]
        public bool? FCLI_SAP_FLG_REGISTRADO { get; set; }
        //[Required]
        public bool? FCLI_ACTIVO_DRONLINE { get; set; }
        //[Required]
        public bool? FCLI_FLG_CARGAR_BD { get; set; }
        //[Required]
        public string? SCLI_NOM_ASEG_ONBASE { get; set; }
        //[Required]
        public bool? SCLI_VISIBLE_MELCHORITA { get; set; }
        //[Required]
        public bool? SCLI_VISIBLE_CALLMEDICO { get; set; }
        //[Required]
        public int? NCLI_DIAS_CREDITO { get; set; }
        //[Required]
        public bool? FCLI_FLG_CAPITADO { get; set; }
        //[Required]
        public bool? FCLI_VISIBLE_HOME_CARE { get; set; }
        //[Required]
        public int usuario_creacion { get; set; }
        //[Required]
        public DateTime? DCLI_FECHA_CREACION { get; set; }
        //[Required]
        public int? NCLI_USUARIO_MODIFICACION { get; set; }
        //[Required]
        public DateTime? DCLI_FECHA_MODIFICACION { get; set; }
    }
}
