namespace MDS.DbContext.Entities
{
    public class DetalleServicioNegocio
    {
        public long CDSN_IDDETSERVICIO { get; set; }

        public string? SDSN_NOMBRE { get; set; }

        public bool FDSN_ESTADO { get; set; }
    }

    public class MantenimientoDetalleServicioNegocio
    {
        public int CDSN_IDSERVICIO { get; set; }

        public long CDSN_IDDETSERVICIO { get; set; }

        public string? SDSN_NOMBRE { get; set; }

        public bool FDSN_ESTADO { get; set; }

        public int NDSN_USUARIO_CREACION { get; set; }
        public DateTime DDSN_FECHA_CREACION { get; set; }

        public int NDSN_USUARIO_MODIFICACION { get; set; }

        public DateTime DDSN_FECHA_MODIFICACION { get; set; }
    }
}
