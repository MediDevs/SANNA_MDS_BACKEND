using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using System.Data;
using MDS.Infrastructure.Helper;
using Microsoft.Data.SqlClient;

namespace MDS.Services.Periodo.Implementation
{
    public class PeriodoService : IPeriodoService
    {

        private readonly IUnitOfWork _uow;

        public PeriodoService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //By William Vilca
        public async Task<ServiceResponse> GetPeriodos()
        {
            try
            {
                List<DbContext.Entities.Periodo> periodos = new List<DbContext.Entities.Periodo>();

                periodos = await _uow.ExecuteStoredProcAll<DbContext.Entities.Periodo>("SPRMDS_LIST_PERIODO");

                List<PeriodoDto> listPeriodo = new List<PeriodoDto>();

                listPeriodo = periodos.Select(p => new PeriodoDto { id_periodo = p.CPDO_ID, Nombre = p.SPDO_NOMBRE, Estado = p.FPDO_ESTADO }).ToList();


                return ServiceResponse.ReturnResultWith200(listPeriodo);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> GetPeriodo(long periodoId)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@ID", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = periodoId },
                };

                List<DbContext.Entities.Periodo> periodos = new List<DbContext.Entities.Periodo>();

                periodos = await _uow.ExecuteStoredProcByParam<DbContext.Entities.Periodo>("SPRMDS_LIST_PERIODO_BY_PARAM", parameters);

                List<PeriodoDto> listPeriodo = new List<PeriodoDto>();

                listPeriodo = periodos.Select(p => new PeriodoDto { id_periodo = p.CPDO_ID, Nombre = p.SPDO_NOMBRE, Estado = p.FPDO_ESTADO }).ToList();


                return ServiceResponse.ReturnResultWith200(listPeriodo);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> AddPeriodo(PeriodoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Nombre", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.Nombre },
                    new SqlParameter("@Estado", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.Estado },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_CREATE_PERIODO", parameters);

                dto.id_periodo = Convert.ToInt64(response);

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