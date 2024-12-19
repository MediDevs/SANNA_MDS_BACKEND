namespace MDS.Dto
{
    public class MedicoDto
    {
        public long id_medico { get; set; }
        public long id_persona { get; set; }
        public int id_especialidad { get; set; }
        public bool estado { get; set; }
    }
    public class MantenimientoMedicoDto
    {
        public long id_medico { get; set; }
        public long id_persona { get; set; }
        public int id_servicionegocio { get; set; }
        public int id_medicoparticular { get; set; }
        public int id_especialiadad { get; set; }
        public int id_banco { get; set; }
        public string beeper { get; set; }
        public string zona { get; set; }
        public bool yo { get; set; }
        public string cod_use { get; set; }
        public string factura { get; set; }
        public decimal pago { get; set; }
        public string cmp { get; set; }
        public int turno { get; set; }
        public int pago_noche { get; set; }
        public DateTime inicio_guardia_noche { get; set; }
        public DateTime fin_guardia_noche { get; set; }
        public bool mensaje { get; set; }
        public bool maxisalud { get; set; }
        public string numero { get; set; }
        public string login { get; set; }
        public string ruc { get; set; }
        public string cuenta_bancaria { get; set; }
        public bool sap_glf_registrado { get; set; }
        public int id_doc_id { get; set; }
        public bool pago_hhmm { get; set; }
        public bool registrado_hhmm { get; set; }
        public bool encargado_ekg { get; set; }
        public bool lector_ekg { get; set; }
        public bool dronline { get; set; }
        public bool melchorita { get; set; }
        public int last_login { get; set; }
        public bool envio_disponibilidad { get; set; }
        public bool teleconsulta_covid { get; set; }
        public bool telemedicina { get; set; }
        public bool alicorp { get; set; }
        public string conductor_asociado { get; set; }
        public bool estado { get; set; }
        public int usuario_creacion { get; set; }
        public DateTime fecha_creacion { get; set; }
        public int usuario_modificacion { get; set; }
        public DateTime fecha_modificacion { get; set; }
    }
}
