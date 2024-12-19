namespace MDS.Dto
{

    public class ListaDireccionDto
    {
        public string paciente { get; set; }
        public string tipo { get; set; }
        public string direccion { get; set; }
    }
    public class DireccionDto
    {
        public long id_direccion { get; set; }
        public long id_persona { get; set; }
        public string id_ubigeo { get; set; }
        public int id_tipo_direccion { get; set; }
        public string descripcion { get; set; }
        public string? anexo { get; set; }
        public string celular { get; set; }
        public string telefono_fijo { get; set; }
        public string nro_mz_lote { get; set; }
        public string? urbanizacion { get; set; }
        public string? referencia { get; set; }
        public string? dpto_interior { get; set; }
        public string? tipo_direccion { get; set; }
        public int usuario_creacion { get; set; }
        public int usuario_modificacion { get; set; }
        public string? cod_departamento { get; set; }
        public string? cod_provincia { get; set; }
        public string? cod_distrito { get; set; }
        public string? departamento { get; set; }
        public string? provincia { get; set; }
        public string? distrito { get; set; }
    }
}
