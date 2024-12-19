
namespace MDS.DbContext.Entities
{
    public class ServicioNegocio
    {
        public long CSER_ID { get; set; }

        public string? SSER_NOMBRE { get; set; }

        public string? SSER_GRUPO { get; set; }

        public bool FSER_ESTADO { get; set; }

    }

    public class MantenimientoServicioNegocio
    {

        public long CSER_IDSERVICIO { get; set; }
        public string SSER_NOMBRE { get; set; }

        public string SSER_GRUPO { get; set; }

        public int NSER_UNI_NEGOCIO { get; set; }


        public int NSER_TIPO_OPERACION_PRECISA { get; set; }

        public string SSER_ONBASE_SUBTIPO_ATENCION { get; set; }

        public int NSER_UNCCSCL { get; set; }

        public string SSER_NEGOCIO_FACTURACION { get; set; }

        public int NSER_PROGRAMA_APP { get; set; }

        public bool FSER_ESTADO { get; set; }

        public int NSER_USUARIO_CREACION { get; set; }

        public DateTime DSER_FECHA_CREACION { get; set; }

        public int NSER_USUARIO_MODIFICACION { get; set; }

        public DateTime DSER_FECHA_MODIFICACION { get; set; }


    }
}
