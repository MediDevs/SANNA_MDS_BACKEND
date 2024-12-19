namespace MDS.Dto.Resources
{
    public class AmbulanciaResource : ResourceParameter
    {
        public string fechaDesde { get; set; } = "";
        public string fechaHasta {get; set; } = "";
        public Boolean flagUrgEmeTras { get; set; }
        public Boolean flagEventos { get; set; }
        public Boolean flagOmedica { get; set; }
        public Boolean flagCanceladas { get; set; }
        public Boolean flagFinalizadas { get; set; }
        public string codigoAtencion { get; set; } = "";
        public string codigoSited { get; set; } = "";
        public string cotizado { get; set; } = "";
        public string estado { get; set; } = "";
        public string ambulanciaRespuesta { get; set; } = "";
        public string servicio { get; set; } = "";
        public string paciente { get; set; } = "";
        public string numeroDocumento { get; set; } = "";
        public string departamento { get; set; } = "";
        public string provincia { get; set; } = "";
        public string distrito { get; set; } = "";
        public string direccion { get; set; } = "";
        public string referencia { get; set; } = "";
        public string cliente { get; set; } = "";
        public string proveedor { get; set; } = "";
        public string ambulancia { get; set; } = "";
        public string tiempo { get; set; } = "";
        public string fechaEstimada { get; set; } = "";
        public string horaEstimada { get; set; } = "";
        public string fechaLlegada { get; set; } = "";
        public string horaLlegada { get; set; } = "";
        public string fechaFinAtencion { get; set; } = "";
        public string horaFinAtencion { get; set; } = "";
        public string telefonoCelular { get; set; } = "";
        public string usuarioCreacion { get; set; } = "";
        public string motivo { get; set; } = "";
        public string flagFueraCobertura { get; set; } = "";
        public string flagCitrix { get; set; } = "";
        public string codigoProv { get; set; } = "";
        public string condicion { get; set; } = "";
        public string busqueda { get; set; } = "";
    }
}
