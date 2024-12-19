namespace MDS.DbContext.Entities
{
    public class Pais
    {
        public int CPAI_ID { get; set; }
        public string SPAI_NOMBRE { get; set; }
        public string SPAI_PREFIJO { get; set; }
        public Boolean FPAI_ESTADO { get; set; }
        //public int? FPAI_ELIMINADO { get; set; }
        //public int? NPAI_USUARIO_CREACION { get; set; }
        //public DateTime? DPAI_FECHA_ELIMINACION { get; set; }
        //public int? DPAI_FECHA_MODIFICACION { get; set; }
        //public DateTime? NPAI_USUARIO_MODIFICACION { get; set; }
    }
}