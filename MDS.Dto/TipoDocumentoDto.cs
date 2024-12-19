namespace MDS.Dto
{
    public class TipoDocumentoDto
    {
        public long id { get; set; }
        public string descripcion { get; set; }
        public string codigo_sunat { get; set; }
        public string codigo_susalud { get; set; }
        public Boolean estado { get; set; }
    }
}
