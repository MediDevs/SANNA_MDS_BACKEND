namespace MDS.Dto
{
    public class DetalleServicioNegocioDto
    {
        public long iddet_servicio { get; set; }
        public string? nombre { get; set; }
        public bool estado { get; set; }
    }

    public class MantenimientoDetalleServicioNegocioDto
    {
        public int id_servicio { get; set; }
        public long iddet_servicio { get; set; }
        public string? nombre { get; set; }
        public bool estado { get; set; }
        public int usuario_creacion { get; set; }
        public DateTime fecha_creacion { get; set; }
        public int usuario_modificacion { get; set; }
        public DateTime fecha_modificacion { get; set; }
    }
}
