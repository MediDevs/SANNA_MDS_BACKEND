using MDS.Infrastructure.DbUtility;

namespace MDS.DbContext.Entities
{
    public class Medico
    {
        public long CMED_ID { get; set; }
        public long CPER_ID { get; set; }
        public int CESP_IDESPECIALIDAD { get; set; }
        public bool FMED_ESTADO { get; set; }
    }
    public class MantenimientoMedico
    {
        public long CMED_ID { get; set; }
        public long CPER_ID { get; set; }
        public int CSER_IDSERVICIO_NEGOCIO { get; set; }
        public int CPAR_IDMEDICO_PARTICULAR { get; set; }
        public int CESP_IDESPECIALIDAD { get; set; }
        public int CBAN_IDBANCO { get; set; }
        public string SMED_BEEPER { get; set; }
        public string SMED_ZONA { get; set; }
        public bool FMED_YO { get; set; }
        public string SMED_COD_USE { get; set; }
        public string SMED_FACTURA { get; set; }
        public decimal NMED_PAGO { get; set; }
        public string SMED_CMP { get; set; }
        public int NMED_TURNO { get; set; }
        public int NMED_PAGO_NOCHE { get; set; }
        public DateTime DMED_INICIO_GUARDIA_NOCHE { get; set; }
        public DateTime DMED_FIN_GUARDIA_NOCHE { get; set; }
        public bool FMED_MENSAJE { get; set; }
        public bool FMED_MAXISALUD { get; set; }
        public string SMED_NUMERO { get; set; }
        public string SMED_LOGIN { get; set; }
        public string SMED_RUC { get; set; }
        public string SMED_CUENTA_BANCARIA { get; set; }
        public bool FMED_SAP_GLF_REGISTRADO { get; set; }
        public int NMED_ID_DOC_ID { get; set; }
        public bool FMED_PAGO_HHMM { get; set; }
        public bool FMED_REGISTRADO_HHMM { get; set; }
        public bool FMED_ENCARGADO_EKG { get; set; }
        public bool FMED_LECTOR_EKG { get; set; }
        public bool FMED_DRONLINE { get; set; }
        public bool FMED_MELCHORITA { get; set; }
        public int NMED_LAST_LOGIN { get; set; }
        public bool FMED_ENVIO_DISPONIBILIDAD { get; set; }
        public bool FMED_TELECONSULTA_COVID { get; set; }
        public bool FMED_TELEMEDICINA { get; set; }
        public bool FMED_ALICORP { get; set; }
        public string SMED_CODUCTOR_ASOCIADO { get; set; }
        public bool FMED_ESTADO { get; set; }
        public int NMED_USUARIO_CREACION { get; set; }
        public DateTime DMED_FECHA_CREACION { get; set; }
        public int NMED_USUARIO_MODIFICACION { get; set; }
        public DateTime DMED_FECHA_MODIFICACION { get; set; }
    }
}