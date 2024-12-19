namespace MDS.Dto
{
    public class EspecialidadCallMedicoDto
    {
        public long id_centro_medico { get; set; }
        public string centro_medico { get; set; }
        public long id_especialidad_call_medico { get; set; }
        public string especialidad_call_medico { get; set; }
        public Boolean estado { get; set; }
    }
}
