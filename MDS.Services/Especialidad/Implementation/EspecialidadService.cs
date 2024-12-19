using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using System.Data;
using MDS.Infrastructure.Helper;
using Microsoft.Data.SqlClient;

namespace MDS.Services.Especialidad.Implementation
{
    public class EspecialidadService : IEspecialidadService
    {
        private readonly IUnitOfWork _uow;

        public EspecialidadService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //By William Vilca
        public async Task<ServiceResponse> GetEspecialidades()
        {
            try
            {
                List<DbContext.Entities.Especialidad> especialidades = new List<DbContext.Entities.Especialidad>();

                especialidades = await _uow.ExecuteStoredProcAll<DbContext.Entities.Especialidad>("SPRMDS_LIST_ESPECIALIDAD");

                List<ListadoEspecialidadDto> listEspecialidad = new List<ListadoEspecialidadDto>();

                listEspecialidad = especialidades.Select(e => new ListadoEspecialidadDto { id_especialidad = e.CESP_IDESPECIALIDAD, nombre = e.SESP_NOMBRE, general = e.SESP_GRAL_PED }).ToList();

                if (!especialidades.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listEspecialidad);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> GetEspecialidad(string especialidadId)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@ID", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = especialidadId },
                };

                List<DbContext.Entities.Especialidad> especialidades = new List<DbContext.Entities.Especialidad>();

                especialidades = await _uow.ExecuteStoredProcByParam<DbContext.Entities.Especialidad>("SPRMDS_LIST_ESPECIALIDAD_BY_PARAM", parameters);

                List<ListadoEspecialidadDto> listEspecialidad = new List<ListadoEspecialidadDto>();

                listEspecialidad = especialidades.Select(e => new ListadoEspecialidadDto { id_especialidad = e.CESP_IDESPECIALIDAD, nombre = e.SESP_NOMBRE, general = e.SESP_GRAL_PED }).ToList();

                if (!listEspecialidad.Any())
                    return ServiceResponse.Return404();

                return ServiceResponse.ReturnResultWith200(listEspecialidad);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> AddEspecialidad(MantenimientoEspecialidadDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@SESP_NOMBRE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.nombre },
                    new SqlParameter("@SESP_GRAL_PED", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.gral_ped },
                    new SqlParameter("@SESP_COD_ESPR", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.cod_espr },
                    new SqlParameter("@SESP_TIPO_PROF_RIMAC", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.tipo_prof_rimac },
                    new SqlParameter("@SESP_ABREVIATURA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.abreviatura },
                    new SqlParameter("@SESP_ID_HHMM", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_hhmm },
                    new SqlParameter("@SESP_SITEDS", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.siteds },
                    new SqlParameter("@SESP_COD_CARACT_FACT", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.cod_caract_fact },
                    new SqlParameter("@FESP_MOSTRAR_APP_MAD", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.mostrar_app_mad },
                    new SqlParameter("@NESP_USUARIO_CREACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },
                    new SqlParameter("@DESP_FECHA_CREACION", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.fecha_creacion },
                    new SqlParameter("@NESP_USUARIO_MODIFICACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_modificacion },
                    new SqlParameter("@DESP_FECHA_MODIFICACION", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.fecha_modificacion },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output},
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_CREATE_ESPECIALIDAD", parameters);

                dto.id_especialidad = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

    }
}
