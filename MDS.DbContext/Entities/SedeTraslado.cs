namespace MDS.DbContext.Entities
{
    public class SedeTraslado
    {
        public long id { get; set; }
        public string? ruc { get; set; }
        public string nombre { get; set; }
        public string? ubigeo { get; set; }
        public string? direccion { get; set; }
        public string? referencia { get; set; }
        public string? cod_ubigeo { get; set; }
        public string? departamento { get; set; }
        public string? provincia { get; set; }
        public string? distrito { get; set; }
    }

    class SedeTrasladoMto
    {
        public long id { get; set; }
        public string ruc { get; set; }
        public string nombre { get; set; }
        public string ubigeo { get; set; }
        public string direccion { get; set; }
        public string referencia { get; set; }
        public string cod_ubigeo { get; set; }
        public string departamento { get; set; }
        public string provincia { get; set; }
        public string distrito { get; set; }
        public int usuario_creacion { get; set; }
        public int usuario_modificacion { get; set; }
    }

    public class SedeTrasladoFiltro
    {
        public long id { get; set; }
        public string ruc { get; set; }
        public string nombre { get; set; }
        public string ubigeo { get; set; }
        public string direccion { get; set; }
        public string referencia { get; set; }
        public string cod_ubigeo { get; set; }
        public string departamento { get; set; }
        public string provincia { get; set; }
        public string distrito { get; set; }
    }
}
