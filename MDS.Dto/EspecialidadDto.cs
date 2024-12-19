namespace MDS.Dto
{
    public class ListadoEspecialidadDto
    {
        public long id_especialidad { get; set; }
        public string? nombre { get; set; }
        public string? general { get; set; }

    }
    public class MantenimientoEspecialidadDto
    {
        public long id_especialidad { get; set; }
        public string? nombre { get; set; }
        public string? gral_ped { get; set; }
        public string cod_espr { get; set; }
        public string tipo_prof_rimac { get; set; }
        public string abreviatura { get; set; }
        public int id_hhmm { get; set; }
        public string siteds { get; set; }
        public string cod_caract_fact { get; set; }
        public bool mostrar_app_mad { get; set; }
        public int usuario_creacion { get; set; }
        public DateTime fecha_creacion { get; set; }
        public int usuario_modificacion { get; set; }
        public DateTime fecha_modificacion { get; set; }
    }


}
