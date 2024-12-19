namespace MDS.DbContext.Entities
{

    public class ListaDireccion
    {
        public string PACIENTE { get; set; }
        public string TIPO { get; set; }
        public string DIRECCION { get; set; }
    }


    public class Direccion
    {
        public long CDIR_ID { get; set; }
        public string CUBI_ID { get; set; }
        public long CPER_ID { get; set; }
        public int NDIR_TIPO_DIRECCION { get; set; }
        public string SDIR_DESCRIPCION { get; set; }
        public string? SDIR_ANEXO { get; set; }
        public string SDIR_TLF_CELULAR { get; set; }
        public string SDIR_TLF_FIJO { get; set; }
        public string SDIR_NRO_LOTE { get; set; }
        public string? SDIR_URBANIZACION { get; set; }
        public string? SDIR_REFERENCIA { get; set; }
        public string? SDIR_INTERIOR { get; set; }
        public string tipo_direccion { get; set; }
        public string? SUBI_DEPARTAMENTO { get; set; }
        public string? SUBI_PROVINCIA { get; set; }
        public string? SUBI_DISTRITO { get; set; }
        public string? SUBI_COD_DPTO { get; set; }
        public string? SUBI_COD_PROV { get; set; }
        public string? SUBI_COD_DIST { get; set; }
    }
}