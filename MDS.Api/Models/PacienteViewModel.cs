using System.ComponentModel.DataAnnotations;

namespace MDS.Api.Models
{
    public class CreatePacienteViewModel
    {
        //[Required]
        public int id_persona { get; set; }
        //[Required]
        public DateTime DPAC_FINC { get; set; }
        //[Required]
        public string SPAC_COD_PAR { get; set; }
        //[Required]
        public DateTime DPAC_FCRE { get; set; }
        //[Required]
        public bool FPAC_BOL_ACT { get; set; }
        //[Required]
        public string SPAC_OBS { get; set; }
        //[Required]
        public bool FPAC_FLG_CORREO { get; set; }
        //[Required]
        public string SPAC_USUCRE_EMAIL { get; set; }
        //[Required]
        public string SPAC_USUMODIF_EMAIL { get; set; }
        //[Required]
        public string SPAC_FLAG_FICHA { get; set; }
        //[Required]
        public bool FPAC_FLAG_BLOQ { get; set; }
        //[Required]
        public bool FPAC_FLAG_VIP { get; set; }
        //[Required]
        public int NPAC_CLASIFICACION { get; set; }
        //[Required]
        public string SPAC_VIP { get; set; }
        //[Required]
        public int NPAC_COD_SUBCLASIF { get; set; }
        //[Required]
        public DateTime DPAC_FECHA_VIGENCIA { get; set; }
        //[Required]
        public bool FPAC_FLG_REGISTRAR_PAC_TABLET { get; set; }
        //[Required]
        public bool FPAC_CLAVE { get; set; }
        //[Required]
        public string SPAC_TIPO_CLAVE { get; set; }
        //[Required]
        public string SPAC_OBS_CLAVE { get; set; }
        //[Required]
        public bool FPAC_CONSENT_INFORMADO { get; set; }
        //[Required]
        public bool FPAC_CONSENT_RECIBIR_INFO { get; set; }
        //[Required]
        public bool FPAC_CONSENT_FIRMA_CONST { get; set; }
        //[Required]
        public bool FPAC_CONSMT_RI { get; set; }
        //[Required]
        public bool FPAC_FLG_CONFLICTIVO_CALLMED { get; set; }
        //[Required]
        public bool FPAC_FLG_ACTIVO_FARMACIA { get; set; }
        //[Required]
        public int NPAC_NORDEN_OBS { get; set; }
        //[Required]
        public string SPAC_GRUPO_CRONICOS { get; set; }
        //[Required]
        public bool FPAC_FLG_PAQUETE_SALUD { get; set; }
        //[Required]
        public bool FPAC_ESTADO { get; set; }
        //[Required]
        public int NPAC_USUARIO_CREACION { get; set; }
        //[Required]
        public DateTime DPAC_FECHA_CREACION { get; set; }
        //[Required]
        public int NPAC_USUARIO_MODIFICACION { get; set; }
        //[Required]
        public DateTime DPAC_FECHA_MODIFICACION { get; set; }
    }
}
