namespace MDS.Dto
{
    public class MedicoParticularDto
    {
        public long id_medicoparticular { get; set; }
        public string descripcion { get; set; }
        public string email { get; set; }
        public bool estado { get; set; }
    }

    public class MantenimientoMedicoParticularDto
    {
        public long id_medicoparticular { get; set; }
        public string descripcion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string email_culminacion { get; set; }
        public bool enviar_email { get; set; }
        public bool flg_proveedor_drmas { get; set; }
        public string nom_usu { get; set; }
        public bool flg_visible_prov_seg_covid { get; set; }
        public bool estado { get; set; }
        public int usuario_creacion { get; set; }
        public DateTime fecha_creacion { get; set; }
        public int usuario_modificacion { get; set; }
        public DateTime fecha_modificacion { get; set; }
    }

}
