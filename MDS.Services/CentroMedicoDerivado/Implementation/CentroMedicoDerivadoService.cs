using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using Microsoft.Data.SqlClient;
using System.Data;
using MDS.Infrastructure.Helper;

namespace MDS.Services.CentroMedicoDerivado.Implementation
{
    public class CentroMedicoDerivadoService : ICentroMedicoDerivadoService
    {
        private readonly IUnitOfWork _uow;

        public CentroMedicoDerivadoService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetCentroMedicoDerivadoByTipoReferencia(int tipo_referencia)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoTipoReferencia", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = tipo_referencia },
                };

                List<DbContext.Entities.CentroMedicoDerivado> centrosMedicosDerivados = new List<DbContext.Entities.CentroMedicoDerivado>();

                centrosMedicosDerivados = await _uow.ExecuteStoredProcByParam<DbContext.Entities.CentroMedicoDerivado>("SPRMDS_LIST_CENTRO_MEDICO_BY_TIPO_REFERENCIA", parameters);

                List<CentroMedicoDerivadoDto> listCentrosMedicosDerivados = new List<CentroMedicoDerivadoDto>();

                listCentrosMedicosDerivados = centrosMedicosDerivados.Select(s => new CentroMedicoDerivadoDto { id = s.CCEN_ID, nombre = s.SCEN_NOMBRE }).ToList();

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