
namespace MDS.Dto
{
    public class ServicioNegocioDto
    {
        public long id_servicio { get; set; }
        public string? nombre { get; set; }
        public string? grupo { get; set; }
        public bool estado { get; set; }
    }

    public class MantenimientoServicioNegocioDto
    {
        public long id_servicio { get; set; }
        public string nombre { get; set; }
        public string grupo { get; set; }
        public int uni_negocio { get; set; }
        public int tipo_operacion_precisa { get; set; }
        public string onbase_subtipo_atencion { get; set; }
        public int unccscl { get; set; }
        public string negocio_facturacion { get; set; }
        public int programa_app { get; set; }
        public bool estado { get; set; }
        public int usuario_creacion { get; set; }
        public DateTime fecha_creacion { get; set; }
        public int usuario_modificacion { get; set; }
        public DateTime fecha_modificacion { get; set; }
    }

}
