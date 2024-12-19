using System.ComponentModel.DataAnnotations;

namespace MDS.Api.Models
{
    public class CreateMedicoViewModel
    {
        [Required]
        public int CPER_ID { get; set; }
        [Required]
        public int CSER_IDSERVICIO_NEGOCIO { get; set; }
        [Required]
        public int CPAR_IDMEDICO_PARTICULAR { get; set; }
        [Required]
        public int CESP_IDESPECIALIDAD { get; set; }
        [Required]
        public int CBAN_IDBANCO { get; set; }
        [Required]
        public string SMED_BEEPER { get; set; }
        [Required]
        public string SMED_ZONA { get; set; }
        [Required]
        public bool FMED_YO { get; set; }
        [Required]
        public string SMED_COD_USE { get; set; }
        [Required]
        public string SMED_FACTURA { get; set; }
        [Required]
        public decimal NMED_PAGO { get; set; }
        [Required]
        public string SMED_CMP { get; set; }
        [Required]
        public int NMED_TURNO { get; set; }
        [Required]
        public int NMED_PAGO_NOCHE { get; set; }
        [Required]
        public DateTime DMED_INICIO_GUARDIA_NOCHE { get; set; }
        [Required]
        public DateTime DMED_FIN_GUARDIA_NOCHE { get; set; }
        [Required]
        public bool FMED_MENSAJE { get; set; }
        [Required]
        public bool FMED_MAXISALUD { get; set; }
        [Required]
        public string SMED_NUMERO { get; set; }
        [Required]
        public string SMED_LOGIN { get; set; }
        [Required]
        public string SMED_RUC { get; set; }
        [Required]
        public string SMED_CUENTA_BANCARIA { get; set; }
        [Required]
        public bool FMED_SAP_GLF_REGISTRADO { get; set; }
        [Required]
        public int NMED_ID_DOC_ID { get; set; }
        [Required]
        public bool FMED_PAGO_HHMM { get; set; }
        [Required]
        public bool FMED_REGISTRADO_HHMM { get; set; }
        [Required]
        public bool FMED_ENCARGADO_EKG { get; set; }
        [Required]
        public bool FMED_LECTOR_EKG { get; set; }
        [Required]
        public bool FMED_DRONLINE { get; set; }
        [Required]
        public bool FMED_MELCHORITA { get; set; }
        [Required]
        public int NMED_LAST_LOGIN { get; set; }
        [Required]
        public bool FMED_ENVIO_DISPONIBILIDAD { get; set; }
        [Required]
        public bool FMED_TELECONSULTA_COVID { get; set; }
        [Required]
        public bool FMED_TELEMEDICINA { get; set; }
        [Required]
        public bool FMED_ALICORP { get; set; }
        [Required]
        public string SMED_CODUCTOR_ASOCIADO { get; set; }
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
