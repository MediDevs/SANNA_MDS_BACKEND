using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using Microsoft.Data.SqlClient;
using System.Data;
using MDS.Infrastructure.Helper;

namespace MDS.Services.CentroMedicoDerivado.Implementation
{
    public class EspecialidadCallMedicoService : IEspecialidadCallMedicoService
    {
        private readonly IUnitOfWork _uow;

        public EspecialidadCallMedicoService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetEspecialidadCallMedicoByCentroMedico(int id_centro_medico)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoCentroMedico", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = id_centro_medico },
                };

                List<DbContext.Entities.EspecialidadCallMedico> centrosMedicosDerivados = new List<DbContext.Entities.EspecialidadCallMedico>();

                centrosMedicosDerivados = await _uow.ExecuteStoredProcByParam<DbContext.Entities.EspecialidadCallMedico>("SPRMDS_LIST_ESPECIALIDAD_CALLMEDICO_BY_CENTRO_MEDICO", parameters);

                List<EspecialidadCallMedicoDto> listCentrosMedicosDerivados = new List<EspecialidadCallMedicoDto>();

                listCentrosMedicosDerivados = centrosMedicosDerivados.Select(s => new EspecialidadCallMedicoDto
                {
                    id_centro_medico = s.CCEN_ID,
                    centro_medico = s.SCEN_NOMBRE,
                    id_especialidad_call_medico = s.CECM_ID,
                    especialidad_call_medico= s.SECM_NOMBRE,
                    estado = s.FDCE_ESTADO
                }).ToList();

                if (!listCentrosMedicosDerivados.Any())
                    return ServiceResponse.Return404();

                return ServiceResponse.ReturnResultWith200(listCentrosMedicosDerivados);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

    }
}