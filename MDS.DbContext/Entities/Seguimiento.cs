using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MDS.DbContext.Entities
{
    public class Seguimiento
    {
        public string CATE_ID { get; set; }
        public string CCAS_ID { get; set; }
        public string CPED_ID { get; set; }
        public string CSER_ID { get; set; }
        public string SSEG_OBSERVACION { get; set; }
        public string CSNC_ID { get; set; }
        public string SSEG_SNC { get; set; }
        public string SSEG_DIAS_SNC { get; set; }
        public string SSEG_MONTO { get; set; }
        public string SSEG_TIPO_REGISTRO { get; set; }
        public string DSEG_FECHA_FINALIZADO { get; set; }
        public string CSEG_TIPO_ENVIO { get; set; }
        public int NSEG_ESTADO_INCIDENCIA { get; set; }
        public int NSEG_NRO_INCIDENCIA { get; set; }
        public string CSEG_TIPO_MEDICO { get; set; }
        public string CSEG_RECLAMO { get; set; }
        public string DSEG_FECHA_CREACION { get; set; }
        public int NSEG_USUARIO_CREACION { get; set; }
        public string NSEG_USUARIO_MODIFICACION { get; set; }
        public string DSEG_FECHA_MODIFICACION { get; set; }
    }

    public class SeguimientoList
    {
        public string cod_historia_clinica { get; set; }
        public string fecha_creacion { get; set; }
        public string hora_creacion { get; set; }
        public string observacion { get; set; }
        public string usuario { get; set; }
        public string servicio { get; set; }

    }
}
