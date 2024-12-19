namespace MDS.Dto
{

    public class UbigeoDatosDto
    {
        public string departamento { get; set; }
        public string provincia { get; set; }
        public string distrito { get; set; }
    }

    public class UbigeoCodigoDto
    {
        public string codigo_ubigeo { get; set; }
    }
    public class UbigeosDto
    {
        public string codigo { get; set; }
        public string departamento { get; set; }
        public string provincia { get; set; }
        public string distrito { get; set; }
    }

    public class UbigeoDto
    {
        public string codigo { get; set; }
        public string id_departamento { get; set; }
        public string departamento { get; set; }
        public string id_provincia { get; set; }
        public string provincia { get; set; }
        public string id_distrito { get; set; }
        public string distrito { get; set; }
    }
    public class DepartamentoDto
    {
        public string id { get; set; }
        public string nombre { get; set; }
    }
    public class ProvinciaDto
    {
        public string id { get; set; }
        public string nombre { get; set; }
    }
    public class DistritoDto
    {
        public string id { get; set; }
        public string nombre { get; set; }
    }
}
