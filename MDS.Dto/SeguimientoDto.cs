namespace MDS.Dto
{
    public class SeguimientoDto
    {
        public string cod_seguimiento{ get; set; }
        public string cod_historia_clinica { get; set; }
        public string fecha_creacion { get; set; }
        public string hora_creacion { get; set; }
        public string observacion { get; set; }
        public int cod_servicio { get; set; }
        public string usuario { get; set; }
        public string servicio { get; set; }
    }
}
