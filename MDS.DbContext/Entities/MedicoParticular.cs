namespace MDS.DbContext.Entities
{
    public class MedicoParticular
    {
        public long CMED_IDMEDICOPARTICULAR { get; set; }

        public string SMED_DESCRIPCION { get; set; }

        public string SMED_EMAIL { get; set; }

        public bool FMED_ESTADO { get; set; }

    }

    public class MantenimientoMedicoParticular
    {
        public long CMED_IDMEDICOPARTICULAR { get; set; }

        public string SMED_DESCRIPCION { get; set; }

        public string SMED_TELEFONO { get; set; }

        public string SMED_EMAIL { get; set; }

        public string SMED_EMAIL_CULMINACION { get; set; }

        public bool FMED_ENVIAR_EMAIL { get; set; }

        public bool FMED_FLG_PROVEEDOR_DRMAS { get; set; }

        public string SMED_NOM_USU { get; set; }

        public bool FMED_FLG_VISIBLE_PROV_SEG_COVID { get; set; }

        public bool FMED_ESTADO { get; set; }

        public int NMED_USUARIO_CREACION { get; set; }

        public DateTime DMED_FECHA_CREACION { get; set; }

        public int NMED_USUARIO_MODIFICACION { get; set; }

        public DateTime DMED_FECHA_MODIFICACION { get; set; }


    }
}
