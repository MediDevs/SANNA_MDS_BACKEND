namespace MDS.Dto
{
    public class MotivoDto
    {
        public int id_motivo { get; set; }
        public int tipo_atencion { get; set; }
        public int tipo_pase { get; set; }
        public string descripcion { get; set; }
        public Boolean skill { get; set; }
        //public int usuario_creacion { get; set; }
        //public DateTime DMOT_FECHA_CREACION { get; set; }
        //public int usuario_modificacion { get; set; }
        //public DateTime DMOT_FECHA_MODIFICACION { get; set; }
    }
    public class MotivoComboDto
    {
        public int id_motivo { get; set; }
        public string descripcion { get; set; }
    }
}
