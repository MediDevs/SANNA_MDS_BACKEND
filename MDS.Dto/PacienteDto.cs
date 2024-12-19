namespace MDS.Dto
{

    public class PacienteDniDto
    {
        public long codigo { get; set; }
        public long id_paciente { get; set; }
        public string dni { get; set; }
        public string paciente { get; set; }
    }
    public class PacienteDto
    {
        public long id_paciente { get; set; }
        public string numero_documento { get; set; }
        public int id_tipo_documento { get; set; }
        public string tipo_documento { get; set; }
        public string nombres { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public int sexo { get; set; }
        //public string fecha_nacimiento { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string movil { get; set; }
        public string? telefono { get; set; }
        public string? correo_electronico { get; set; }
        public long? id_persona { get; set; }
        public int? edad { get; set; }
        //public int? id_servicio { get; set; }
        public bool? estado { get; set; }
    }

    public class MantenimientoPacienteDto
    {
        public long Id_paciente { get; set; }
        public long id_persona { get; set; }
        //public int id_servicio { get; set; }
        public DateTime finc { get; set; }
        public string cod_par { get; set; }
        public DateTime fcre { get; set; }
        public bool bol_act { get; set; }
        public string obs { get; set; }
        public bool flg_correo { get; set; }
        public string usucre_email { get; set; }
        public string usumodif_email { get; set; }
        public string flag_ficha { get; set; }
        public bool flag_bloq { get; set; }
        public bool flag_vip { get; set; }
        public int clasificacion { get; set; }
        public string vip { get; set; }
        public int cod_subclasif { get; set; }
        public DateTime fecha_vigencia { get; set; }
        public bool flg_registrar_pac_tablet { get; set; }
        public bool clave { get; set; }
        public string tipo_clave { get; set; }
        public string obs_clave { get; set; }
        public bool consent_informado { get; set; }
        public bool consent_recibir_info { get; set; }
        public bool consent_firma_const { get; set; }
        public bool consmt_ri { get; set; }
        public bool flg_conflictivo_callmed { get; set; }
        public bool flg_activo_farmacia { get; set; }
        public int norden_obs { get; set; }
        public string grupo_cronicos { get; set; }
        public bool flg_paquete_salud { get; set; }
        public bool estado { get; set; }
        public int usuario_creacion { get; set; }
        public DateTime fecha_creacion { get; set; }
        public int usuario_modificacion { get; set; }
        public DateTime fecha_modificacion { get; set; }
    }

}
